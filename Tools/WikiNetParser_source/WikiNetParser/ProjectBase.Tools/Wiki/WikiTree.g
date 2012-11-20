tree grammar WikiTree;

options {
// language = 'Java'; output=AST; ASTLabelType=CommonTree; tokenVocab=WikiParser;
 language = 'CSharp3'; output=AST; ASTLabelType=CommonTree; tokenVocab=WikiParser;
}
@header{ 
//using System.Text;
}
@namespace { ProjectBase.Tools.Wiki
}
//see: WikiTree.Code.cs

execute  			: statement*;
statement			: table | block | lists | NEWLINE -> ;
element  			: block | lists | atom | codeText | tag ;
inlineElement : atom | codeText | tag ;
atom    			: inline | anchor | name | image ;

// table
table 	 :  ^(tab=TABLE  { Append("<table>\r\n"); } tableHead* 
												 { Append("<tbody>\r\n"); } tableRow* { Append("</tbody>"); } { Append("</table>\r\n"); }  );
tableHead:  ^(tr=TH      { Append("<thead><tr>"); } tableCell*  { Append("</tr></thead>\r\n"); }  );
tableRow :  ^(tr=TROW    { Append("<tr>"); } 			  tableCell*  { Append("</tr>\r\n"); }  );
tableCell:  ^(td=TCELL   { Append("<td>"); } 			  inlineElement*  { Append("</td>"); }  );

// lists
lists    : ^(l=LIST    { Append("<ul>\r\n"); } NEWLINE* (li)* NEWLINE* { Append("</ul>\r\n"); } )
         | ^(n=NUMERIC { Append("<ol>\r\n"); } NEWLINE* (li)* NEWLINE* { Append("</ol>\r\n"); } ) ;
li 			 : ^(LISTITEM  { Append("<li>"); } 		 inlineElement+ lists*   { Append("</li>\r\n"); } ) ;

// elements
block    : ^(b=ELEMENT { BlockTag($b.Text, false); }  element*  		 { BlockTag($b.Text, true); } );
inline   : ^(i=INLINE  { InlineTag($i.Text, false); } inlineElement* { InlineTag($i.Text, true); }  );        

// url
tag      : ^(TAG 			 	 { TagElement(false); } 	 codeText* { TagElement(true); } );
anchor   : ^(A_ELEMENT   { SpecialTextStart(); }   pureText* { SpecialTextEnd(AnchorTemplate);}  attrText { Append("</a>");} );
name     : ^(NAME_ELEMENT{ Append("<a name=\""); } pureText* { Append("\" ></a>");}  );

// image
image     : ^(IMG_ELEMENT { SpecialTextStart(); } (pureText)* { SpecialTextEnd(ImageTemplate);} imageAttrs* { Append("\" />");} );
imageAttrs: ^(style=ATTR pt=WORD { ImageAttr($pt.Text, $style.Text); } );
attrText  : ^(ATTR (simpleText | image)* );


// texts
simpleText  : alwaysText
            | txt=(HTML_BASE | COMMENT | QUOTED | SYMBOLS | LT | GT             	
            	| CSHARP_BASE | CSHARP_FLOW | CSHARP_SPECIAL | CSHARP_TYPES)
               { Append($txt); }
            | whs=WS       { Append(" "); }
;
pureText    : alwaysText
            | txt=(HTML_BASE | COMMENT | QUOTED | SYMBOLS | LT | GT 
	            | COLON | ASTERIX | UNDER
            	| CSHARP_BASE | CSHARP_FLOW | CSHARP_SPECIAL | CSHARP_TYPES)
               { Append($txt); }
            | whs=WS
;
codeText    : alwaysText
            |  hb=HTML_BASE     { SpanClassTag($hb.Text , "html");}
            | cmt=COMMENT       { SpanClassTag($cmt.Text, "cmmnt");}
            | qtd=QUOTED        { SpanClassTag($qtd.Text, "qtd");  }
            |   s=(SYMBOLS | LT | GT) { SpanClassTag($s.Text, "smbl"); }
            | csb=CSHARP_BASE   { SpanClassTag($csb.Text, "base"); }
            | csf=CSHARP_FLOW   { SpanClassTag($csf.Text, "flw"); }
            | css=CSHARP_SPECIAL{ SpanClassTag($css.Text, "spcl"); }
            | cst=CSHARP_TYPES  { SpanClassTag($cst.Text, "type"); }
            | whs=WS       { Append(WhiteSpaceText($whs.Text)); }
;
alwaysText   :  txt=( WORD | NOCONTROL | COLORS | STYLES 
				     | ATTR_TEXT | ATTR_HEIGHT | ATTR_WIDTH | ATTR_FLOAT 
				     | ASTERIX | UNDER
				     | COLON ) { Append($txt); }
             | esc=ESCAPE   { Append(EscapedText($esc.Text)); }
             | ^(BREAK { Append("\r\n<br />"); })
             | NEWLINE ->
;