lexer grammar WikiLexer;
options {
//  language = 'Java';
  language = 'CSharp3'; 
}
@namespace { ProjectBase.Tools.Wiki
}
@lexer::members  { 
  int inliner = 0;
  int position = 0;
	int table = 0;
} 

/* BLOCKS */
CODE_BEGIN :'[CODE';   CODE_END  :'CODE]';
HTML_BEGIN :'[HTML';   HTML_END  :'HTML]';  
XML_BEGIN  :'[XML';    XML_END   :'XML]';  

PRE_BEGIN  :'[PRE';    PRE_END   :'PRE]';  
BQ_BEGIN   :'[BQ';     BQ_END    :'BQ]';  

LI_ITEM	   : {inliner == 0 && position == 0}?=> '* '  { ++position; };
LI_ITEM2   : {inliner == 0 && position == 0}?=> '** '  { ++position; };
LI_ITEM3   : {inliner == 0 && position == 0}?=> '*** '  { ++position; };
NUM_ITEM   : {inliner == 0 && position == 0}?=> '# '  { ++position; };
NUM_ITEM2  : {inliner == 0 && position == 0}?=> '## '  { ++position; };
NUM_ITEM3  : {inliner == 0 && position == 0}?=> '### '  { ++position; };

LI_BEGIN   :'[LI';     LI_END    :'LI]';
NUM_BEGIN  :'[NUM';    NUM_END   :'NUM]';


/* LEXER */
NEWLINE :   ('\r'? '\n') 	{ inliner = 0; position = 0; table = 0; };
WS      : '  ' | ' ' | '\t';

COMMENT : '/*'    ( options {greedy=false;} : . )* '*/'
        | '&lt;!--' ( options {greedy=false;} : . )* '--&gt;'
        | '/// '  ( options {greedy=false;} : . )* NEWLINE
        | '// '   ( options {greedy=false;} : . )* NEWLINE
        | '<!--'  ( options {greedy=false;} : . )* '-->'
;
QUOTED  : '"' 		( options {greedy=false;} : . )* '"'
        | '&quot;' ( options {greedy=false;} : . )* '&quot;'
;
       
LT      :  ('&lt;' | LTSIGN) SLASH?  { position++; };
GT      :  SLASH? ( '&gt;' | GTSIGN) { position++; };

ESCAPE  : ('[[]' | '[]]' | '[:]' | '[|]' | '[<]' | '[>]' | '[&gt;]' | '[&lt;]' | '["]' | '[&quot;]' |	'[*]' | '[#]' | '[_]'
) { position++; };

A       : ('[URL:' ) { ++inliner; position++; };
NAME    : ('[NAME:') { ++inliner; position++; };
IMG     : ('[IMG:' ) { ++inliner; position++; };
INLINE_BEGIN: '[' (STYLES | COLORS) ':' { inliner++; position++; };

TABLE : { (position == 0 || table > 0 ) }?=> ( '| ' ) { position++; ++table; }; 
THEAD : { (position == 0 || table > 0 ) }?=> ( '|| ' ) { position++; ++table; }; 
NOCONTROL:{inliner <=0}?=> ( ']' | '|' ) { position++; };
CLOSE   : {inliner > 0}?=> ']'           { inliner--; };
VLINE   : {inliner > 0}?=> '|';
  
/* ATTRIBUTES */
ATTR_TEXT    : 'TEXT';
ATTR_HEIGHT  : 'HEIGHT';
ATTR_WIDTH   : 'WIDTH';
ATTR_FLOAT   : 'FLOAT';

COLORS  : ( 'BLUE' | 'RED' | 'GREEN' | 'OLIVE' | 'LIME' | 'PURPLE' 
 | 'YELLOW' | 'MAROON' | 'SILVER' | 'ORANGE' | 'NAVY' | 'TEAL' | 'PINK' ) { position++; }
;
STYLES: ( 'B' | 'I' | 'U' | 'S' | 'SAMP' | 'V'   | 'VAR' 
 | 'SUB' | 'SUP' | 'BIG' | 'SMALL' | 'DFN' | 'DEF' ) 		{ position++; }
;

/* FRAGMENTS for easier reading */
fragment EXCLAM: '!'; // '\u0021'
//--fragment QSIGN : '"'; // '\u0022' - defined elsewhere
fragment HASH  : '#'; // '\u0023'
fragment PERCENT  : '%'; // '\u0025'
fragment AMPR  : '&'; // '\u0026'
fragment LEFT  : '('; // '\u0028'
fragment RIGHT : ')'; // '\u0029'
ASTERIX : '*'  { ++position; }; // '\u002b'
fragment DOT   : '.'; // '\u002e'         
fragment SLASH : '/'; // '\u002f'
COLON   : ':'  { ++position; }; // '\u003a' 
fragment SEMI  : ';'; // '\u003b'
fragment LTSIGN: '<'; // '\u003c' 
fragment EQUAL : '='; // '\u003d'
fragment GTSIGN: '>'; // '\u003e' 
fragment QUEST : '?'; // '\u003f'
//fragment OPEN  : '['; // '\u005b'  - defined elsewhere
//fragment CLOSE : ']'; // '\u005d'  - defined elsewhere
UNDER   					: {inliner <= 0}?=> '_'    { ++position; }; // '\u005f'
fragment UNDERIN  : {inliner > 0}?=>  '_' ;
fragment LCB   : '{'; // '\u007b'
//VLINE : '|'; // '\u007b'  - defined elsewhere
fragment RCB   : '}'; // '\u007d'
fragment DIGIT   : '\u0030'.. '\u0039';
fragment UPPER  : '\u0041'.. '\u005a';
fragment LOWER  : '\u0061'.. '\u007a';
fragment NOTLEADING : '\u0024'| '\u0025' | '\u0027' | '\u002b'..'\u002d' | '\u0040' | '\u005c' | '\u005e' | '\u0060'
;
fragment UNICODREST : '\u007e' .. '\ufffe'; // the last is the EOF
fragment LETTER: DIGIT | LOWER | UPPER | SEMI | NOTLEADING | UNICODREST 
//						 	 | INUNDER
			   			 | QUEST | PERCENT | SLASH | HASH | DOT 
;

/* SPECIAL groups definition */
SYMBOLS:  (AMPR | EQUAL | EXCLAM | LEFT | RIGHT | LCB | RCB) { position++; };
CSHARP_BASE    : ( 'class' | 'public' | 'protected' | 'private' | 'abstract' 
                  | 'virtual' | 'new' | 'struct' | 'const'
                  | 'void' | 'interface' | 'get' | 'set'
                  | 'readonly' | 'override' | 'default'| 'enum' | 'sealed ' 
                  | 'namespace' | 'params' | 'ref' | 'out' | 'base' 
                  | 'unchecked' | 'extern' | 'unsafe'| 'checked' | 'operator' | 'implicit' | 'explicit' 
                  ) { position++; };
CSHARP_TYPES    : ( 'string' | 'int' | 'long' | 'short' | 'byte' 
                  | 'decimal' | 'sbyte' | 'uint' | 'ulong' | 'ushort' 
                  | 'char' | 'object'  | 'Guid' | 'var' //| 'float'
                  | 'function'
                  ) { position++; };
CSHARP_FLOW     : ( 'switch' | 'case' | 'if' | 'else' | 'while' | 'do' | 'for' 
                  | 'foreach' | 'break' | 'continue' | 'return' | 'using'
                  | 'try' | 'catch' | 'goto' | 'throw' | 'finally' | 'in' | 'lock' 
                  ) { position++; };
CSHARP_SPECIAL  : ( 'as' | 'is' | 'null' | 'true' | 'false' | 'event' | 'this'
									| 'Equals' | 'Is()' | 'IsNull()' | 'IList' 
                  | 'params' | 'typeof' | 'delegate' 
                  | 'Where' | 'Select' | 'Any' | 'IDictionary' | 'ToDisplay' | 'Func'
                  ) { position++; };
HTML_BASE       : ( 'href' | 'style' | 'rel' | 'title' | 'src' | 'value' 
                  | 'id' | 'name' | 'type' | 'link' 
                ) { position++; };
IBTOKEN     : {inliner == 0 && position == 0}?=> (
              '|CITE ' | '|BQ ' 
            | '|P '  | '|PR ' | '|PC ' 
            | '|P1 ' | '|P2 ' | '|P3 '
	          | '|H1 ' | '|H2 ' | '|H3 ' | '|H4 ' | '|H5 ' | '|H6 ' 
         ) { ++position; } // to be used only at the beginning of the line
;
WORD: (UNDERIN | LETTER)+ { position++; }
;