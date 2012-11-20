parser grammar WikiParser;
options {
//  language = 'Java'; output=AST; tokenVocab=WikiLexer; k=12; 
  language = 'CSharp3'; output=AST; tokenVocab=WikiLexer; k=12;
}
tokens{ 
  /* imaginary */
  BREAK;
  ELEMENT; NAME_ELEMENT;  A_ELEMENT;    IMG_ELEMENT;   
  TABLE;   TROW;   TCELL;  TH;
  ATTR;    INLINE;  TAG;    
  LIST;    NUMERIC;   LISTITEM;	
}
@namespace { ProjectBase.Tools.Wiki
}

// starting point 
execute  			: elements* EOF!;
elements 			: ( table | blocks | lists | inlineBlock | emptyBlock )+ ;
inlineElements: ( inline | atom | text )+ ;
lists    			: li | liLine | num | numLine ;
atom     			: anchor | anchorImg | name | image | tag | boldText | italicText | specialSigns | LT | GT;


// BLOCKS
// blocks, has explicit start and end tokens 
blocks:    CODE_BEGIN   elements CODE_END -> ^(ELEMENT["code"] elements) 
			|	   HTML_BEGIN   elements HTML_END -> ^(ELEMENT["html"] elements) 
			|    XML_BEGIN    elements XML_END  -> ^(ELEMENT["xml"]  elements) 
			|    BQ_BEGIN     elements BQ_END   -> ^(ELEMENT["bq"]   elements)
			|    PRE_BEGIN    elements PRE_END  -> ^(ELEMENT["pre"]  elements);

// UL
li    	 : LI_BEGIN WS* terminator? liInner+ LI_END    -> ^(LIST liInner+); // [LI line line ... LI] 
liInner  : inlineElements terminator? li? num? terminator?  -> ^(LISTITEM inlineElements li? num?);
 // * , ** 
liLine   : liItem+ 					  									       -> ^(LIST liItem+); // * line
liItem   : LI_ITEM inlineElements terminator liGroup2? numGroup2?  -> ^(LISTITEM inlineElements liGroup2? numGroup2? );
liGroup2 : liItem2+ 					  										   -> ^(LIST liItem2+); // ** line
liItem2  : LI_ITEM2 inlineElements terminator liGroup3? numGroup3? -> ^(LISTITEM inlineElements liGroup3? numGroup3? );
liGroup3 : liItem3+ 					  										   -> ^(LIST liItem3+); // *** line
liItem3  : LI_ITEM3 inlineElements terminator   		   -> ^(LISTITEM inlineElements);
// OL
num    	 : NUM_BEGIN WS* terminator? numInner+ NUM_END   -> ^(NUMERIC numInner+); // [NUM line line ... NUMs] 
numInner : inlineElements terminator? num? li? terminator? -> ^(LISTITEM inlineElements num? li?);
 // # , ## 
numLine  : numItem+ 					  											   -> ^(NUMERIC numItem+);  // # line
numItem  : NUM_ITEM inlineElements terminator numGroup2? liGroup2? -> ^(LISTITEM inlineElements numGroup2? liGroup2? );
numGroup2: numItem2+ 					  										     -> ^(NUMERIC numItem2+); // ## line
numItem2 : NUM_ITEM2 inlineElements terminator numGroup3? liGroup3? -> ^(LISTITEM inlineElements numGroup3? liGroup3? );
numGroup3: numItem3+ 					  										     -> ^(NUMERIC numItem3+); // ### line
numItem3 : NUM_ITEM3 inlineElements terminator   			   -> ^(LISTITEM inlineElements);


// table
table 		 : tableHead* tableRow+ -> ^(TABLE tableHead* tableRow+) ;
tableHead	 : THEAD tableCell+ (terminator | EOF) -> ^(TH tableCell+);
tableRow	 : TABLE tableCell+ (terminator | EOF) -> ^(TROW tableCell+);
tableCell	 : (TABLE | THEAD)? inlineElements -> ^(TCELL inlineElements);
cellContent: (inline | atom | text);

// INLINES
// Style and Color: [B:bold text] 
inline 		 : ib=INLINE_BEGIN inlineElements CLOSE 	-> ^(INLINE[$ib] inlineElements)
;
// Paragraphs: |CITE ....text.... end_of_line 
inlineBlock: ib=IBTOKEN inlineElements ( terminator | EOF )?  -> ^(ELEMENT[$ib] inlineElements)
			 		 | terminator
;
// cover the remaining cases: text till the EOF 
emptyBlock : inlineElements ( terminator | EOF )?   -> ^(ELEMENT["empty"] inlineElements)
;



// ATOMS
italicText 	: UNDER phrase UNDER  -> ^(INLINE["[I:"] phrase)
				 	  | UNDER phrase WS // not a bold
;
boldText		: ASTERIX phrase ASTERIX -> ^(INLINE["[B:"] phrase)
				 	  | ASTERIX phrase WS // not italic
;
// [NAME:home] to <a name ... 
name  :  NAME text CLOSE                      -> ^(NAME_ELEMENT text)
;
// [IMG: urlText] | [IMG: urlText | HEIGHT:100px | WIDTH: 100px | FLOAT:left] 
image :   IMG urlText imageAttrs* WS* CLOSE		-> ^(IMG_ELEMENT urlText imageAttrs* )
;
imageAttrs: widthText | heightText | floatText // img attributes height, width, float - Optional!
;
heightText : WS? VLINE WS? ATTR_HEIGHT COLON? WS? t=WORD       -> ^(ATTR["height"] $t); //-> ^(ATTR_HEIGHT $t);
widthText  : WS? VLINE WS? ATTR_WIDTH  COLON? WS? t=WORD       -> ^(ATTR["width"] $t); //-> ^(ATTR_WIDTH $t) ;
floatText  : WS? VLINE WS? ATTR_FLOAT  COLON? WS? t=WORD       -> ^(ATTR["float"] $t); //-> ^(ATTR_FLOAT $t) ;

// the xml statement recognizer - to get pieces <, > .. for a special rendering 
tag	: lt=LT  text gt=GT    -> ^(TAG $lt text $gt)
		|	lt=LT  text terminator text gt=GT    -> ^(TAG $lt text ^(BREAK) text $gt)
;
// [URL:...] to <a href ... 
anchor:
  A href=urlText CLOSE 																						// 1) [URL:url] -> <a href="url">url</a> 
          -> ^(A_ELEMENT $href ^(ATTR["text"] $href ) ) 
| A href=urlText VLINE WS? ATTR_TEXT COLON? txt=anchorInner CLOSE // 2) a) [URL:url | TEXT: txt] -> <a href="url">txt</a> 
          -> ^(A_ELEMENT $href ^(ATTR["text"] $txt) ) 					  // 2) b) [URL:url | TEXT: [IMG:src]] -> <a href="url"><img src="src" /></a> 
;
// <a ..><img ...
anchorImg :
  A txt=anchorInner VLINE href=urlText CLOSE 											// 3) a) [URL:txt|url] -> <a href="url">txt</a> 
          -> ^(A_ELEMENT $href ^(ATTR["text"] $txt) )							// 3) b) [URL: [IMG:src] |url] -> <a href="url"><img src="src" /></a> 
;
anchorInner: ( (WS? image WS?) | urlText ) // inner text/image of the anchor element
;



// TEXTS 
// URL Text 
urlText : ( quoted | safeText);
quoted: ( WS? QUOTED WS? );
safeText : (WS
	| ESCAPE
	| ATTR_TEXT | ATTR_HEIGHT | ATTR_WIDTH | ATTR_FLOAT 
	| HTML_BASE | CSHARP_BASE | CSHARP_FLOW | CSHARP_SPECIAL | CSHARP_TYPES 
	| COLORS | STYLES
	| COLON 
	| ASTERIX | UNDER
	| SYMBOLS | WORD 
)+
;
phrase: ( ESCAPE
	| NOCONTROL
	| COMMENT | QUOTED	
	| ATTR_TEXT | ATTR_HEIGHT | ATTR_WIDTH | ATTR_FLOAT
	| HTML_BASE | CSHARP_BASE | CSHARP_FLOW | CSHARP_SPECIAL | CSHARP_TYPES | SYMBOLS
	| COLORS | STYLES
	| COLON
	| WORD 
)+
( WS ( ESCAPE
	| NOCONTROL
	| COMMENT | QUOTED	
	| ATTR_TEXT | ATTR_HEIGHT | ATTR_WIDTH | ATTR_FLOAT
	| HTML_BASE | CSHARP_BASE | CSHARP_FLOW | CSHARP_SPECIAL | CSHARP_TYPES 
	| COLORS | STYLES
	| COLON
	|	SYMBOLS	| WORD 
	)+
)* 
	;
specialSigns: UNDER | ASTERIX
;
// plain text (almost every sign, except the special ones
text: ( WS
	| ESCAPE
	| NOCONTROL
	| COMMENT | QUOTED	
	| ATTR_TEXT | ATTR_HEIGHT | ATTR_WIDTH | ATTR_FLOAT
	| HTML_BASE | CSHARP_BASE | CSHARP_FLOW | CSHARP_SPECIAL | CSHARP_TYPES 
	| COLORS | STYLES
	| COLON
	|	SYMBOLS	| WORD 
)+
;
terminator: NEWLINE ;