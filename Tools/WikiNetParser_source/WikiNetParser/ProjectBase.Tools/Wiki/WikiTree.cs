// $ANTLR 3.3 Nov 30, 2010 12:45:30 catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g 2011-05

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162

 
//using System.Text;


using System.Collections.Generic;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using RewriteRuleITokenStream = Antlr.Runtime.Tree.RewriteRuleTokenStream;using Stack = System.Collections.Generic.Stack<object>;
using List = System.Collections.IList;
using ArrayList = System.Collections.Generic.List<object>;


namespace  ProjectBase.Tools.Wiki

{
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.3 Nov 30, 2010 12:45:30")]
[System.CLSCompliant(false)]
public partial class WikiTree : Antlr.Runtime.Tree.TreeParser
{
	internal static readonly string[] tokenNames = new string[] {
		"<invalid>", "<EOR>", "<DOWN>", "<UP>", "CODE_BEGIN", "CODE_END", "HTML_BEGIN", "HTML_END", "XML_BEGIN", "XML_END", "PRE_BEGIN", "PRE_END", "BQ_BEGIN", "BQ_END", "LI_ITEM", "LI_ITEM2", "LI_ITEM3", "NUM_ITEM", "NUM_ITEM2", "NUM_ITEM3", "LI_BEGIN", "LI_END", "NUM_BEGIN", "NUM_END", "NEWLINE", "WS", "COMMENT", "QUOTED", "LTSIGN", "SLASH", "LT", "GTSIGN", "GT", "ESCAPE", "A", "NAME", "IMG", "STYLES", "COLORS", "INLINE_BEGIN", "TABLE", "THEAD", "NOCONTROL", "CLOSE", "VLINE", "ATTR_TEXT", "ATTR_HEIGHT", "ATTR_WIDTH", "ATTR_FLOAT", "EXCLAM", "HASH", "PERCENT", "AMPR", "LEFT", "RIGHT", "ASTERIX", "DOT", "COLON", "SEMI", "EQUAL", "QUEST", "UNDER", "UNDERIN", "LCB", "RCB", "DIGIT", "UPPER", "LOWER", "NOTLEADING", "UNICODREST", "LETTER", "SYMBOLS", "CSHARP_BASE", "CSHARP_TYPES", "CSHARP_FLOW", "CSHARP_SPECIAL", "HTML_BASE", "IBTOKEN", "WORD", "BREAK", "ELEMENT", "NAME_ELEMENT", "A_ELEMENT", "IMG_ELEMENT", "TROW", "TCELL", "TH", "ATTR", "INLINE", "TAG", "LIST", "NUMERIC", "LISTITEM"
	};
	public const int EOF=-1;
	public const int CODE_BEGIN=4;
	public const int CODE_END=5;
	public const int HTML_BEGIN=6;
	public const int HTML_END=7;
	public const int XML_BEGIN=8;
	public const int XML_END=9;
	public const int PRE_BEGIN=10;
	public const int PRE_END=11;
	public const int BQ_BEGIN=12;
	public const int BQ_END=13;
	public const int LI_ITEM=14;
	public const int LI_ITEM2=15;
	public const int LI_ITEM3=16;
	public const int NUM_ITEM=17;
	public const int NUM_ITEM2=18;
	public const int NUM_ITEM3=19;
	public const int LI_BEGIN=20;
	public const int LI_END=21;
	public const int NUM_BEGIN=22;
	public const int NUM_END=23;
	public const int NEWLINE=24;
	public const int WS=25;
	public const int COMMENT=26;
	public const int QUOTED=27;
	public const int LTSIGN=28;
	public const int SLASH=29;
	public const int LT=30;
	public const int GTSIGN=31;
	public const int GT=32;
	public const int ESCAPE=33;
	public const int A=34;
	public const int NAME=35;
	public const int IMG=36;
	public const int STYLES=37;
	public const int COLORS=38;
	public const int INLINE_BEGIN=39;
	public const int TABLE=40;
	public const int THEAD=41;
	public const int NOCONTROL=42;
	public const int CLOSE=43;
	public const int VLINE=44;
	public const int ATTR_TEXT=45;
	public const int ATTR_HEIGHT=46;
	public const int ATTR_WIDTH=47;
	public const int ATTR_FLOAT=48;
	public const int EXCLAM=49;
	public const int HASH=50;
	public const int PERCENT=51;
	public const int AMPR=52;
	public const int LEFT=53;
	public const int RIGHT=54;
	public const int ASTERIX=55;
	public const int DOT=56;
	public const int COLON=57;
	public const int SEMI=58;
	public const int EQUAL=59;
	public const int QUEST=60;
	public const int UNDER=61;
	public const int UNDERIN=62;
	public const int LCB=63;
	public const int RCB=64;
	public const int DIGIT=65;
	public const int UPPER=66;
	public const int LOWER=67;
	public const int NOTLEADING=68;
	public const int UNICODREST=69;
	public const int LETTER=70;
	public const int SYMBOLS=71;
	public const int CSHARP_BASE=72;
	public const int CSHARP_TYPES=73;
	public const int CSHARP_FLOW=74;
	public const int CSHARP_SPECIAL=75;
	public const int HTML_BASE=76;
	public const int IBTOKEN=77;
	public const int WORD=78;
	public const int BREAK=79;
	public const int ELEMENT=80;
	public const int NAME_ELEMENT=81;
	public const int A_ELEMENT=82;
	public const int IMG_ELEMENT=83;
	public const int TROW=84;
	public const int TCELL=85;
	public const int TH=86;
	public const int ATTR=87;
	public const int INLINE=88;
	public const int TAG=89;
	public const int LIST=90;
	public const int NUMERIC=91;
	public const int LISTITEM=92;

	// delegates
	// delegators

	#if ANTLR_DEBUG
		private static readonly bool[] decisionCanBacktrack =
			new bool[]
			{
				false, // invalid decision
				false, false, false, false, false, false, false, false, false, false, 
				false, false, false, false, false, false, false, false, false, false, 
				false, false, false, false, false, false, false, false, false, false, 
				false
			};
	#else
		private static readonly bool[] decisionCanBacktrack = new bool[0];
	#endif
	public WikiTree( ITreeNodeStream input )
		: this( input, new RecognizerSharedState() )
	{
	}
	public WikiTree(ITreeNodeStream input, RecognizerSharedState state)
		: base(input, state)
	{
		ITreeAdaptor treeAdaptor = null;
		CreateTreeAdaptor(ref treeAdaptor);
		TreeAdaptor = treeAdaptor ?? new CommonTreeAdaptor();

		OnCreated();
	}
		
	// Implement this function in your helper file to use a custom tree adaptor
	partial void CreateTreeAdaptor(ref ITreeAdaptor adaptor);

	private ITreeAdaptor adaptor;

	public ITreeAdaptor TreeAdaptor
	{
		get
		{
			return adaptor;
		}
		set
		{
			this.adaptor = value;
		}
	}

	public override string[] TokenNames { get { return WikiTree.tokenNames; } }
	public override string GrammarFileName { get { return "catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g"; } }


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	#region Rules
	public class execute_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>
	{
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } } object IAstRuleReturnScope.Tree { get { return Tree; } }
	}

	partial void Enter_execute();
	partial void Leave_execute();

	// $ANTLR start "execute"
	// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:14:1: execute : ( statement )* ;
	[GrammarRule("execute")]
	private WikiTree.execute_return execute()
	{
		Enter_execute();
		EnterRule("execute", 1);
		TraceIn("execute", 1);
		WikiTree.execute_return retval = new WikiTree.execute_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = null;

		CommonTree _first_0 = null;
		CommonTree _last = null;

		WikiTree.statement_return statement1 = default(WikiTree.statement_return);


		try { DebugEnterRule(GrammarFileName, "execute");
		DebugLocation(14, 24);
		try
		{
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:14:13: ( ( statement )* )
			DebugEnterAlt(1);
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:14:15: ( statement )*
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(14, 15);
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:14:15: ( statement )*
			try { DebugEnterSubRule(1);
			while (true)
			{
				int alt1=2;
				try { DebugEnterDecision(1, decisionCanBacktrack[1]);
				int LA1_0 = input.LA(1);

				if ((LA1_0==NEWLINE||LA1_0==TABLE||LA1_0==ELEMENT||(LA1_0>=LIST && LA1_0<=NUMERIC)))
				{
					alt1=1;
				}


				} finally { DebugExitDecision(1); }
				switch ( alt1 )
				{
				case 1:
					DebugEnterAlt(1);
					// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:14:15: statement
					{
					DebugLocation(14, 15);
					_last = (CommonTree)input.LT(1);
					PushFollow(Follow._statement_in_execute55);
					statement1=statement();
					PopFollow();

					adaptor.AddChild(root_0, statement1.Tree);

					}
					break;

				default:
					goto loop1;
				}
			}

			loop1:
				;

			} finally { DebugExitSubRule(1); }


			}

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("execute", 1);
			LeaveRule("execute", 1);
			Leave_execute();
		}
		DebugLocation(14, 24);
		} finally { DebugExitRule(GrammarFileName, "execute"); }
		return retval;

	}
	// $ANTLR end "execute"

	public class statement_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>
	{
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } } object IAstRuleReturnScope.Tree { get { return Tree; } }
	}

	partial void Enter_statement();
	partial void Leave_statement();

	// $ANTLR start "statement"
	// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:15:1: statement : ( table | block | lists | NEWLINE ->);
	[GrammarRule("statement")]
	private WikiTree.statement_return statement()
	{
		Enter_statement();
		EnterRule("statement", 2);
		TraceIn("statement", 2);
		WikiTree.statement_return retval = new WikiTree.statement_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = null;

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree NEWLINE5=null;
		WikiTree.table_return table2 = default(WikiTree.table_return);
		WikiTree.block_return block3 = default(WikiTree.block_return);
		WikiTree.lists_return lists4 = default(WikiTree.lists_return);

		CommonTree NEWLINE5_tree=null;
		RewriteRuleNodeStream stream_NEWLINE=new RewriteRuleNodeStream(adaptor,"token NEWLINE");

		try { DebugEnterRule(GrammarFileName, "statement");
		DebugLocation(15, 49);
		try
		{
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:15:13: ( table | block | lists | NEWLINE ->)
			int alt2=4;
			try { DebugEnterDecision(2, decisionCanBacktrack[2]);
			switch (input.LA(1))
			{
			case TABLE:
				{
				alt2=1;
				}
				break;
			case ELEMENT:
				{
				alt2=2;
				}
				break;
			case LIST:
			case NUMERIC:
				{
				alt2=3;
				}
				break;
			case NEWLINE:
				{
				alt2=4;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 2, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(2); }
			switch (alt2)
			{
			case 1:
				DebugEnterAlt(1);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:15:15: table
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(15, 15);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._table_in_statement65);
				table2=table();
				PopFollow();

				adaptor.AddChild(root_0, table2.Tree);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:15:23: block
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(15, 23);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._block_in_statement69);
				block3=block();
				PopFollow();

				adaptor.AddChild(root_0, block3.Tree);

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:15:31: lists
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(15, 31);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._lists_in_statement73);
				lists4=lists();
				PopFollow();

				adaptor.AddChild(root_0, lists4.Tree);

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:15:39: NEWLINE
				{
				DebugLocation(15, 39);
				_last = (CommonTree)input.LT(1);
				NEWLINE5=(CommonTree)Match(input,NEWLINE,Follow._NEWLINE_in_statement77);  
				stream_NEWLINE.Add(NEWLINE5);



				{
				// AST REWRITE
				// elements: 
				// token labels: 
				// rule labels: retval
				// token list labels: 
				// rule list labels: 
				// wildcard labels: 
				retval.Tree = root_0;
				RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

				root_0 = (CommonTree)adaptor.Nil();
				// 15:47: ->
				{
					DebugLocation(15, 50);
					root_0 = null;
				}

				retval.Tree = root_0;}

				}
				break;

			}
			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("statement", 2);
			LeaveRule("statement", 2);
			Leave_statement();
		}
		DebugLocation(15, 49);
		} finally { DebugExitRule(GrammarFileName, "statement"); }
		return retval;

	}
	// $ANTLR end "statement"

	public class element_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>
	{
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } } object IAstRuleReturnScope.Tree { get { return Tree; } }
	}

	partial void Enter_element();
	partial void Leave_element();

	// $ANTLR start "element"
	// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:16:1: element : ( block | lists | atom | codeText | tag );
	[GrammarRule("element")]
	private WikiTree.element_return element()
	{
		Enter_element();
		EnterRule("element", 3);
		TraceIn("element", 3);
		WikiTree.element_return retval = new WikiTree.element_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = null;

		CommonTree _first_0 = null;
		CommonTree _last = null;

		WikiTree.block_return block6 = default(WikiTree.block_return);
		WikiTree.lists_return lists7 = default(WikiTree.lists_return);
		WikiTree.atom_return atom8 = default(WikiTree.atom_return);
		WikiTree.codeText_return codeText9 = default(WikiTree.codeText_return);
		WikiTree.tag_return tag10 = default(WikiTree.tag_return);


		try { DebugEnterRule(GrammarFileName, "element");
		DebugLocation(16, 52);
		try
		{
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:16:13: ( block | lists | atom | codeText | tag )
			int alt3=5;
			try { DebugEnterDecision(3, decisionCanBacktrack[3]);
			switch (input.LA(1))
			{
			case ELEMENT:
				{
				alt3=1;
				}
				break;
			case LIST:
			case NUMERIC:
				{
				alt3=2;
				}
				break;
			case NAME_ELEMENT:
			case A_ELEMENT:
			case IMG_ELEMENT:
			case INLINE:
				{
				alt3=3;
				}
				break;
			case NEWLINE:
			case WS:
			case COMMENT:
			case QUOTED:
			case LT:
			case GT:
			case ESCAPE:
			case STYLES:
			case COLORS:
			case NOCONTROL:
			case ATTR_TEXT:
			case ATTR_HEIGHT:
			case ATTR_WIDTH:
			case ATTR_FLOAT:
			case ASTERIX:
			case COLON:
			case UNDER:
			case SYMBOLS:
			case CSHARP_BASE:
			case CSHARP_TYPES:
			case CSHARP_FLOW:
			case CSHARP_SPECIAL:
			case HTML_BASE:
			case WORD:
			case BREAK:
				{
				alt3=4;
				}
				break;
			case TAG:
				{
				alt3=5;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 3, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(3); }
			switch (alt3)
			{
			case 1:
				DebugEnterAlt(1);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:16:15: block
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(16, 15);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._block_in_element91);
				block6=block();
				PopFollow();

				adaptor.AddChild(root_0, block6.Tree);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:16:23: lists
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(16, 23);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._lists_in_element95);
				lists7=lists();
				PopFollow();

				adaptor.AddChild(root_0, lists7.Tree);

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:16:31: atom
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(16, 31);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._atom_in_element99);
				atom8=atom();
				PopFollow();

				adaptor.AddChild(root_0, atom8.Tree);

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:16:38: codeText
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(16, 38);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._codeText_in_element103);
				codeText9=codeText();
				PopFollow();

				adaptor.AddChild(root_0, codeText9.Tree);

				}
				break;
			case 5:
				DebugEnterAlt(5);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:16:49: tag
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(16, 49);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._tag_in_element107);
				tag10=tag();
				PopFollow();

				adaptor.AddChild(root_0, tag10.Tree);

				}
				break;

			}
			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("element", 3);
			LeaveRule("element", 3);
			Leave_element();
		}
		DebugLocation(16, 52);
		} finally { DebugExitRule(GrammarFileName, "element"); }
		return retval;

	}
	// $ANTLR end "element"

	public class inlineElement_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>
	{
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } } object IAstRuleReturnScope.Tree { get { return Tree; } }
	}

	partial void Enter_inlineElement();
	partial void Leave_inlineElement();

	// $ANTLR start "inlineElement"
	// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:17:1: inlineElement : ( atom | codeText | tag );
	[GrammarRule("inlineElement")]
	private WikiTree.inlineElement_return inlineElement()
	{
		Enter_inlineElement();
		EnterRule("inlineElement", 4);
		TraceIn("inlineElement", 4);
		WikiTree.inlineElement_return retval = new WikiTree.inlineElement_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = null;

		CommonTree _first_0 = null;
		CommonTree _last = null;

		WikiTree.atom_return atom11 = default(WikiTree.atom_return);
		WikiTree.codeText_return codeText12 = default(WikiTree.codeText_return);
		WikiTree.tag_return tag13 = default(WikiTree.tag_return);


		try { DebugEnterRule(GrammarFileName, "inlineElement");
		DebugLocation(17, 38);
		try
		{
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:17:15: ( atom | codeText | tag )
			int alt4=3;
			try { DebugEnterDecision(4, decisionCanBacktrack[4]);
			switch (input.LA(1))
			{
			case NAME_ELEMENT:
			case A_ELEMENT:
			case IMG_ELEMENT:
			case INLINE:
				{
				alt4=1;
				}
				break;
			case NEWLINE:
			case WS:
			case COMMENT:
			case QUOTED:
			case LT:
			case GT:
			case ESCAPE:
			case STYLES:
			case COLORS:
			case NOCONTROL:
			case ATTR_TEXT:
			case ATTR_HEIGHT:
			case ATTR_WIDTH:
			case ATTR_FLOAT:
			case ASTERIX:
			case COLON:
			case UNDER:
			case SYMBOLS:
			case CSHARP_BASE:
			case CSHARP_TYPES:
			case CSHARP_FLOW:
			case CSHARP_SPECIAL:
			case HTML_BASE:
			case WORD:
			case BREAK:
				{
				alt4=2;
				}
				break;
			case TAG:
				{
				alt4=3;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 4, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(4); }
			switch (alt4)
			{
			case 1:
				DebugEnterAlt(1);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:17:17: atom
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(17, 17);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._atom_in_inlineElement115);
				atom11=atom();
				PopFollow();

				adaptor.AddChild(root_0, atom11.Tree);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:17:24: codeText
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(17, 24);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._codeText_in_inlineElement119);
				codeText12=codeText();
				PopFollow();

				adaptor.AddChild(root_0, codeText12.Tree);

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:17:35: tag
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(17, 35);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._tag_in_inlineElement123);
				tag13=tag();
				PopFollow();

				adaptor.AddChild(root_0, tag13.Tree);

				}
				break;

			}
			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("inlineElement", 4);
			LeaveRule("inlineElement", 4);
			Leave_inlineElement();
		}
		DebugLocation(17, 38);
		} finally { DebugExitRule(GrammarFileName, "inlineElement"); }
		return retval;

	}
	// $ANTLR end "inlineElement"

	public class atom_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>
	{
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } } object IAstRuleReturnScope.Tree { get { return Tree; } }
	}

	partial void Enter_atom();
	partial void Leave_atom();

	// $ANTLR start "atom"
	// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:18:1: atom : ( inline | anchor | name | image );
	[GrammarRule("atom")]
	private WikiTree.atom_return atom()
	{
		Enter_atom();
		EnterRule("atom", 5);
		TraceIn("atom", 5);
		WikiTree.atom_return retval = new WikiTree.atom_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = null;

		CommonTree _first_0 = null;
		CommonTree _last = null;

		WikiTree.inline_return inline14 = default(WikiTree.inline_return);
		WikiTree.anchor_return anchor15 = default(WikiTree.anchor_return);
		WikiTree.name_return name16 = default(WikiTree.name_return);
		WikiTree.image_return image17 = default(WikiTree.image_return);


		try { DebugEnterRule(GrammarFileName, "atom");
		DebugLocation(18, 44);
		try
		{
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:18:12: ( inline | anchor | name | image )
			int alt5=4;
			try { DebugEnterDecision(5, decisionCanBacktrack[5]);
			switch (input.LA(1))
			{
			case INLINE:
				{
				alt5=1;
				}
				break;
			case A_ELEMENT:
				{
				alt5=2;
				}
				break;
			case NAME_ELEMENT:
				{
				alt5=3;
				}
				break;
			case IMG_ELEMENT:
				{
				alt5=4;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 5, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(5); }
			switch (alt5)
			{
			case 1:
				DebugEnterAlt(1);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:18:14: inline
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(18, 14);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._inline_in_atom137);
				inline14=inline();
				PopFollow();

				adaptor.AddChild(root_0, inline14.Tree);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:18:23: anchor
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(18, 23);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._anchor_in_atom141);
				anchor15=anchor();
				PopFollow();

				adaptor.AddChild(root_0, anchor15.Tree);

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:18:32: name
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(18, 32);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._name_in_atom145);
				name16=name();
				PopFollow();

				adaptor.AddChild(root_0, name16.Tree);

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:18:39: image
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(18, 39);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._image_in_atom149);
				image17=image();
				PopFollow();

				adaptor.AddChild(root_0, image17.Tree);

				}
				break;

			}
			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("atom", 5);
			LeaveRule("atom", 5);
			Leave_atom();
		}
		DebugLocation(18, 44);
		} finally { DebugExitRule(GrammarFileName, "atom"); }
		return retval;

	}
	// $ANTLR end "atom"

	public class table_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>
	{
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } } object IAstRuleReturnScope.Tree { get { return Tree; } }
	}

	partial void Enter_table();
	partial void Leave_table();

	// $ANTLR start "table"
	// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:21:1: table : ^(tab= TABLE ( tableHead )* ( tableRow )* ) ;
	[GrammarRule("table")]
	private WikiTree.table_return table()
	{
		Enter_table();
		EnterRule("table", 6);
		TraceIn("table", 6);
		WikiTree.table_return retval = new WikiTree.table_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = null;

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree tab=null;
		WikiTree.tableHead_return tableHead18 = default(WikiTree.tableHead_return);
		WikiTree.tableRow_return tableRow19 = default(WikiTree.tableRow_return);

		CommonTree tab_tree=null;

		try { DebugEnterRule(GrammarFileName, "table");
		DebugLocation(21, 104);
		try
		{
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:21:9: ( ^(tab= TABLE ( tableHead )* ( tableRow )* ) )
			DebugEnterAlt(1);
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:21:12: ^(tab= TABLE ( tableHead )* ( tableRow )* )
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(21, 12);
			_last = (CommonTree)input.LT(1);
			{
			CommonTree _save_last_1 = _last;
			CommonTree _first_1 = null;
			CommonTree root_1 = (CommonTree)adaptor.Nil();DebugLocation(21, 17);
			_last = (CommonTree)input.LT(1);
			tab=(CommonTree)Match(input,TABLE,Follow._TABLE_in_table165); 
			tab_tree = (CommonTree)adaptor.DupNode(tab);

			root_1 = (CommonTree)adaptor.BecomeRoot(tab_tree, root_1);


			DebugLocation(21, 25);
			 Append("<table>\r\n"); 

			if ( input.LA(1)==TokenTypes.Down ) {
			    Match(input, TokenTypes.Down, null); 
			    DebugLocation(21, 52);
			    // catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:21:52: ( tableHead )*
			    try { DebugEnterSubRule(6);
			    while (true)
			    {
			    	int alt6=2;
			    	try { DebugEnterDecision(6, decisionCanBacktrack[6]);
			    	int LA6_0 = input.LA(1);

			    	if ((LA6_0==TH))
			    	{
			    		alt6=1;
			    	}


			    	} finally { DebugExitDecision(6); }
			    	switch ( alt6 )
			    	{
			    	case 1:
			    		DebugEnterAlt(1);
			    		// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:21:52: tableHead
			    		{
			    		DebugLocation(21, 52);
			    		_last = (CommonTree)input.LT(1);
			    		PushFollow(Follow._tableHead_in_table170);
			    		tableHead18=tableHead();
			    		PopFollow();

			    		adaptor.AddChild(root_1, tableHead18.Tree);

			    		}
			    		break;

			    	default:
			    		goto loop6;
			    	}
			    }

			    loop6:
			    	;

			    } finally { DebugExitSubRule(6); }

			    DebugLocation(22, 14);
			     Append("<tbody>\r\n"); 
			    DebugLocation(22, 41);
			    // catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:22:41: ( tableRow )*
			    try { DebugEnterSubRule(7);
			    while (true)
			    {
			    	int alt7=2;
			    	try { DebugEnterDecision(7, decisionCanBacktrack[7]);
			    	int LA7_0 = input.LA(1);

			    	if ((LA7_0==TROW))
			    	{
			    		alt7=1;
			    	}


			    	} finally { DebugExitDecision(7); }
			    	switch ( alt7 )
			    	{
			    	case 1:
			    		DebugEnterAlt(1);
			    		// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:22:41: tableRow
			    		{
			    		DebugLocation(22, 41);
			    		_last = (CommonTree)input.LT(1);
			    		PushFollow(Follow._tableRow_in_table189);
			    		tableRow19=tableRow();
			    		PopFollow();

			    		adaptor.AddChild(root_1, tableRow19.Tree);

			    		}
			    		break;

			    	default:
			    		goto loop7;
			    	}
			    }

			    loop7:
			    	;

			    } finally { DebugExitSubRule(7); }

			    DebugLocation(22, 51);
			     Append("</tbody>"); 
			    DebugLocation(22, 75);
			     Append("</table>\r\n"); 

			    Match(input, TokenTypes.Up, null); 
			}adaptor.AddChild(root_0, root_1);_last = _save_last_1;
			}


			}

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("table", 6);
			LeaveRule("table", 6);
			Leave_table();
		}
		DebugLocation(22, 104);
		} finally { DebugExitRule(GrammarFileName, "table"); }
		return retval;

	}
	// $ANTLR end "table"

	public class tableHead_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>
	{
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } } object IAstRuleReturnScope.Tree { get { return Tree; } }
	}

	partial void Enter_tableHead();
	partial void Leave_tableHead();

	// $ANTLR start "tableHead"
	// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:23:1: tableHead : ^(tr= TH ( tableCell )* ) ;
	[GrammarRule("tableHead")]
	private WikiTree.tableHead_return tableHead()
	{
		Enter_tableHead();
		EnterRule("tableHead", 7);
		TraceIn("tableHead", 7);
		WikiTree.tableHead_return retval = new WikiTree.tableHead_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = null;

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree tr=null;
		WikiTree.tableCell_return tableCell20 = default(WikiTree.tableCell_return);

		CommonTree tr_tree=null;

		try { DebugEnterRule(GrammarFileName, "tableHead");
		DebugLocation(23, 99);
		try
		{
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:23:10: ( ^(tr= TH ( tableCell )* ) )
			DebugEnterAlt(1);
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:23:13: ^(tr= TH ( tableCell )* )
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(23, 13);
			_last = (CommonTree)input.LT(1);
			{
			CommonTree _save_last_1 = _last;
			CommonTree _first_1 = null;
			CommonTree root_1 = (CommonTree)adaptor.Nil();DebugLocation(23, 17);
			_last = (CommonTree)input.LT(1);
			tr=(CommonTree)Match(input,TH,Follow._TH_in_tableHead207); 
			tr_tree = (CommonTree)adaptor.DupNode(tr);

			root_1 = (CommonTree)adaptor.BecomeRoot(tr_tree, root_1);


			DebugLocation(23, 26);
			 Append("<thead><tr>"); 

			if ( input.LA(1)==TokenTypes.Down ) {
			    Match(input, TokenTypes.Down, null); 
			    DebugLocation(23, 53);
			    // catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:23:53: ( tableCell )*
			    try { DebugEnterSubRule(8);
			    while (true)
			    {
			    	int alt8=2;
			    	try { DebugEnterDecision(8, decisionCanBacktrack[8]);
			    	int LA8_0 = input.LA(1);

			    	if ((LA8_0==TCELL))
			    	{
			    		alt8=1;
			    	}


			    	} finally { DebugExitDecision(8); }
			    	switch ( alt8 )
			    	{
			    	case 1:
			    		DebugEnterAlt(1);
			    		// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:23:53: tableCell
			    		{
			    		DebugLocation(23, 53);
			    		_last = (CommonTree)input.LT(1);
			    		PushFollow(Follow._tableCell_in_tableHead216);
			    		tableCell20=tableCell();
			    		PopFollow();

			    		adaptor.AddChild(root_1, tableCell20.Tree);

			    		}
			    		break;

			    	default:
			    		goto loop8;
			    	}
			    }

			    loop8:
			    	;

			    } finally { DebugExitSubRule(8); }

			    DebugLocation(23, 65);
			     Append("</tr></thead>\r\n"); 

			    Match(input, TokenTypes.Up, null); 
			}adaptor.AddChild(root_0, root_1);_last = _save_last_1;
			}


			}

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("tableHead", 7);
			LeaveRule("tableHead", 7);
			Leave_tableHead();
		}
		DebugLocation(23, 99);
		} finally { DebugExitRule(GrammarFileName, "tableHead"); }
		return retval;

	}
	// $ANTLR end "tableHead"

	public class tableRow_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>
	{
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } } object IAstRuleReturnScope.Tree { get { return Tree; } }
	}

	partial void Enter_tableRow();
	partial void Leave_tableRow();

	// $ANTLR start "tableRow"
	// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:24:1: tableRow : ^(tr= TROW ( tableCell )* ) ;
	[GrammarRule("tableRow")]
	private WikiTree.tableRow_return tableRow()
	{
		Enter_tableRow();
		EnterRule("tableRow", 8);
		TraceIn("tableRow", 8);
		WikiTree.tableRow_return retval = new WikiTree.tableRow_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = null;

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree tr=null;
		WikiTree.tableCell_return tableCell21 = default(WikiTree.tableCell_return);

		CommonTree tr_tree=null;

		try { DebugEnterRule(GrammarFileName, "tableRow");
		DebugLocation(24, 89);
		try
		{
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:24:10: ( ^(tr= TROW ( tableCell )* ) )
			DebugEnterAlt(1);
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:24:13: ^(tr= TROW ( tableCell )* )
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(24, 13);
			_last = (CommonTree)input.LT(1);
			{
			CommonTree _save_last_1 = _last;
			CommonTree _first_1 = null;
			CommonTree root_1 = (CommonTree)adaptor.Nil();DebugLocation(24, 17);
			_last = (CommonTree)input.LT(1);
			tr=(CommonTree)Match(input,TROW,Follow._TROW_in_tableRow234); 
			tr_tree = (CommonTree)adaptor.DupNode(tr);

			root_1 = (CommonTree)adaptor.BecomeRoot(tr_tree, root_1);


			DebugLocation(24, 26);
			 Append("<tr>"); 

			if ( input.LA(1)==TokenTypes.Down ) {
			    Match(input, TokenTypes.Down, null); 
			    DebugLocation(24, 51);
			    // catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:24:51: ( tableCell )*
			    try { DebugEnterSubRule(9);
			    while (true)
			    {
			    	int alt9=2;
			    	try { DebugEnterDecision(9, decisionCanBacktrack[9]);
			    	int LA9_0 = input.LA(1);

			    	if ((LA9_0==TCELL))
			    	{
			    		alt9=1;
			    	}


			    	} finally { DebugExitDecision(9); }
			    	switch ( alt9 )
			    	{
			    	case 1:
			    		DebugEnterAlt(1);
			    		// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:24:51: tableCell
			    		{
			    		DebugLocation(24, 51);
			    		_last = (CommonTree)input.LT(1);
			    		PushFollow(Follow._tableCell_in_tableRow246);
			    		tableCell21=tableCell();
			    		PopFollow();

			    		adaptor.AddChild(root_1, tableCell21.Tree);

			    		}
			    		break;

			    	default:
			    		goto loop9;
			    	}
			    }

			    loop9:
			    	;

			    } finally { DebugExitSubRule(9); }

			    DebugLocation(24, 63);
			     Append("</tr>\r\n"); 

			    Match(input, TokenTypes.Up, null); 
			}adaptor.AddChild(root_0, root_1);_last = _save_last_1;
			}


			}

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("tableRow", 8);
			LeaveRule("tableRow", 8);
			Leave_tableRow();
		}
		DebugLocation(24, 89);
		} finally { DebugExitRule(GrammarFileName, "tableRow"); }
		return retval;

	}
	// $ANTLR end "tableRow"

	public class tableCell_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>
	{
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } } object IAstRuleReturnScope.Tree { get { return Tree; } }
	}

	partial void Enter_tableCell();
	partial void Leave_tableCell();

	// $ANTLR start "tableCell"
	// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:25:1: tableCell : ^(td= TCELL ( inlineElement )* ) ;
	[GrammarRule("tableCell")]
	private WikiTree.tableCell_return tableCell()
	{
		Enter_tableCell();
		EnterRule("tableCell", 9);
		TraceIn("tableCell", 9);
		WikiTree.tableCell_return retval = new WikiTree.tableCell_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = null;

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree td=null;
		WikiTree.inlineElement_return inlineElement22 = default(WikiTree.inlineElement_return);

		CommonTree td_tree=null;

		try { DebugEnterRule(GrammarFileName, "tableCell");
		DebugLocation(25, 89);
		try
		{
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:25:10: ( ^(td= TCELL ( inlineElement )* ) )
			DebugEnterAlt(1);
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:25:13: ^(td= TCELL ( inlineElement )* )
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(25, 13);
			_last = (CommonTree)input.LT(1);
			{
			CommonTree _save_last_1 = _last;
			CommonTree _first_1 = null;
			CommonTree root_1 = (CommonTree)adaptor.Nil();DebugLocation(25, 17);
			_last = (CommonTree)input.LT(1);
			td=(CommonTree)Match(input,TCELL,Follow._TCELL_in_tableCell263); 
			td_tree = (CommonTree)adaptor.DupNode(td);

			root_1 = (CommonTree)adaptor.BecomeRoot(td_tree, root_1);


			DebugLocation(25, 26);
			 Append("<td>"); 

			if ( input.LA(1)==TokenTypes.Down ) {
			    Match(input, TokenTypes.Down, null); 
			    DebugLocation(25, 51);
			    // catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:25:51: ( inlineElement )*
			    try { DebugEnterSubRule(10);
			    while (true)
			    {
			    	int alt10=2;
			    	try { DebugEnterDecision(10, decisionCanBacktrack[10]);
			    	int LA10_0 = input.LA(1);

			    	if (((LA10_0>=NEWLINE && LA10_0<=QUOTED)||LA10_0==LT||(LA10_0>=GT && LA10_0<=ESCAPE)||(LA10_0>=STYLES && LA10_0<=COLORS)||LA10_0==NOCONTROL||(LA10_0>=ATTR_TEXT && LA10_0<=ATTR_FLOAT)||LA10_0==ASTERIX||LA10_0==COLON||LA10_0==UNDER||(LA10_0>=SYMBOLS && LA10_0<=HTML_BASE)||(LA10_0>=WORD && LA10_0<=BREAK)||(LA10_0>=NAME_ELEMENT && LA10_0<=IMG_ELEMENT)||(LA10_0>=INLINE && LA10_0<=TAG)))
			    	{
			    		alt10=1;
			    	}


			    	} finally { DebugExitDecision(10); }
			    	switch ( alt10 )
			    	{
			    	case 1:
			    		DebugEnterAlt(1);
			    		// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:25:51: inlineElement
			    		{
			    		DebugLocation(25, 51);
			    		_last = (CommonTree)input.LT(1);
			    		PushFollow(Follow._inlineElement_in_tableCell274);
			    		inlineElement22=inlineElement();
			    		PopFollow();

			    		adaptor.AddChild(root_1, inlineElement22.Tree);

			    		}
			    		break;

			    	default:
			    		goto loop10;
			    	}
			    }

			    loop10:
			    	;

			    } finally { DebugExitSubRule(10); }

			    DebugLocation(25, 67);
			     Append("</td>"); 

			    Match(input, TokenTypes.Up, null); 
			}adaptor.AddChild(root_0, root_1);_last = _save_last_1;
			}


			}

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("tableCell", 9);
			LeaveRule("tableCell", 9);
			Leave_tableCell();
		}
		DebugLocation(25, 89);
		} finally { DebugExitRule(GrammarFileName, "tableCell"); }
		return retval;

	}
	// $ANTLR end "tableCell"

	public class lists_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>
	{
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } } object IAstRuleReturnScope.Tree { get { return Tree; } }
	}

	partial void Enter_lists();
	partial void Leave_lists();

	// $ANTLR start "lists"
	// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:28:1: lists : ( ^(l= LIST ( NEWLINE )* ( li )* ( NEWLINE )* ) | ^(n= NUMERIC ( NEWLINE )* ( li )* ( NEWLINE )* ) );
	[GrammarRule("lists")]
	private WikiTree.lists_return lists()
	{
		Enter_lists();
		EnterRule("lists", 10);
		TraceIn("lists", 10);
		WikiTree.lists_return retval = new WikiTree.lists_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = null;

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree l=null;
		CommonTree n=null;
		CommonTree NEWLINE23=null;
		CommonTree NEWLINE25=null;
		CommonTree NEWLINE26=null;
		CommonTree NEWLINE28=null;
		WikiTree.li_return li24 = default(WikiTree.li_return);
		WikiTree.li_return li27 = default(WikiTree.li_return);

		CommonTree l_tree=null;
		CommonTree n_tree=null;
		CommonTree NEWLINE23_tree=null;
		CommonTree NEWLINE25_tree=null;
		CommonTree NEWLINE26_tree=null;
		CommonTree NEWLINE28_tree=null;

		try { DebugEnterRule(GrammarFileName, "lists");
		DebugLocation(28, 98);
		try
		{
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:28:10: ( ^(l= LIST ( NEWLINE )* ( li )* ( NEWLINE )* ) | ^(n= NUMERIC ( NEWLINE )* ( li )* ( NEWLINE )* ) )
			int alt17=2;
			try { DebugEnterDecision(17, decisionCanBacktrack[17]);
			int LA17_0 = input.LA(1);

			if ((LA17_0==LIST))
			{
				alt17=1;
			}
			else if ((LA17_0==NUMERIC))
			{
				alt17=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 17, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(17); }
			switch (alt17)
			{
			case 1:
				DebugEnterAlt(1);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:28:12: ^(l= LIST ( NEWLINE )* ( li )* ( NEWLINE )* )
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(28, 12);
				_last = (CommonTree)input.LT(1);
				{
				CommonTree _save_last_1 = _last;
				CommonTree _first_1 = null;
				CommonTree root_1 = (CommonTree)adaptor.Nil();DebugLocation(28, 15);
				_last = (CommonTree)input.LT(1);
				l=(CommonTree)Match(input,LIST,Follow._LIST_in_lists296); 
				l_tree = (CommonTree)adaptor.DupNode(l);

				root_1 = (CommonTree)adaptor.BecomeRoot(l_tree, root_1);


				DebugLocation(28, 24);
				 Append("<ul>\r\n"); 

				if ( input.LA(1)==TokenTypes.Down ) {
				    Match(input, TokenTypes.Down, null); 
				    DebugLocation(28, 48);
				    // catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:28:48: ( NEWLINE )*
				    try { DebugEnterSubRule(11);
				    while (true)
				    {
				    	int alt11=2;
				    	try { DebugEnterDecision(11, decisionCanBacktrack[11]);
				    	int LA11_0 = input.LA(1);

				    	if ((LA11_0==NEWLINE))
				    	{
				    		alt11=1;
				    	}


				    	} finally { DebugExitDecision(11); }
				    	switch ( alt11 )
				    	{
				    	case 1:
				    		DebugEnterAlt(1);
				    		// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:28:48: NEWLINE
				    		{
				    		DebugLocation(28, 48);
				    		_last = (CommonTree)input.LT(1);
				    		NEWLINE23=(CommonTree)Match(input,NEWLINE,Follow._NEWLINE_in_lists303); 
				    		NEWLINE23_tree = (CommonTree)adaptor.DupNode(NEWLINE23);

				    		adaptor.AddChild(root_1, NEWLINE23_tree);


				    		}
				    		break;

				    	default:
				    		goto loop11;
				    	}
				    }

				    loop11:
				    	;

				    } finally { DebugExitSubRule(11); }

				    DebugLocation(28, 57);
				    // catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:28:57: ( li )*
				    try { DebugEnterSubRule(12);
				    while (true)
				    {
				    	int alt12=2;
				    	try { DebugEnterDecision(12, decisionCanBacktrack[12]);
				    	int LA12_0 = input.LA(1);

				    	if ((LA12_0==LISTITEM))
				    	{
				    		alt12=1;
				    	}


				    	} finally { DebugExitDecision(12); }
				    	switch ( alt12 )
				    	{
				    	case 1:
				    		DebugEnterAlt(1);
				    		// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:28:58: li
				    		{
				    		DebugLocation(28, 58);
				    		_last = (CommonTree)input.LT(1);
				    		PushFollow(Follow._li_in_lists307);
				    		li24=li();
				    		PopFollow();

				    		adaptor.AddChild(root_1, li24.Tree);

				    		}
				    		break;

				    	default:
				    		goto loop12;
				    	}
				    }

				    loop12:
				    	;

				    } finally { DebugExitSubRule(12); }

				    DebugLocation(28, 63);
				    // catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:28:63: ( NEWLINE )*
				    try { DebugEnterSubRule(13);
				    while (true)
				    {
				    	int alt13=2;
				    	try { DebugEnterDecision(13, decisionCanBacktrack[13]);
				    	int LA13_0 = input.LA(1);

				    	if ((LA13_0==NEWLINE))
				    	{
				    		alt13=1;
				    	}


				    	} finally { DebugExitDecision(13); }
				    	switch ( alt13 )
				    	{
				    	case 1:
				    		DebugEnterAlt(1);
				    		// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:28:63: NEWLINE
				    		{
				    		DebugLocation(28, 63);
				    		_last = (CommonTree)input.LT(1);
				    		NEWLINE25=(CommonTree)Match(input,NEWLINE,Follow._NEWLINE_in_lists311); 
				    		NEWLINE25_tree = (CommonTree)adaptor.DupNode(NEWLINE25);

				    		adaptor.AddChild(root_1, NEWLINE25_tree);


				    		}
				    		break;

				    	default:
				    		goto loop13;
				    	}
				    }

				    loop13:
				    	;

				    } finally { DebugExitSubRule(13); }

				    DebugLocation(28, 72);
				     Append("</ul>\r\n"); 

				    Match(input, TokenTypes.Up, null); 
				}adaptor.AddChild(root_0, root_1);_last = _save_last_1;
				}


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:29:12: ^(n= NUMERIC ( NEWLINE )* ( li )* ( NEWLINE )* )
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(29, 12);
				_last = (CommonTree)input.LT(1);
				{
				CommonTree _save_last_1 = _last;
				CommonTree _first_1 = null;
				CommonTree root_1 = (CommonTree)adaptor.Nil();DebugLocation(29, 15);
				_last = (CommonTree)input.LT(1);
				n=(CommonTree)Match(input,NUMERIC,Follow._NUMERIC_in_lists332); 
				n_tree = (CommonTree)adaptor.DupNode(n);

				root_1 = (CommonTree)adaptor.BecomeRoot(n_tree, root_1);


				DebugLocation(29, 24);
				 Append("<ol>\r\n"); 

				if ( input.LA(1)==TokenTypes.Down ) {
				    Match(input, TokenTypes.Down, null); 
				    DebugLocation(29, 48);
				    // catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:29:48: ( NEWLINE )*
				    try { DebugEnterSubRule(14);
				    while (true)
				    {
				    	int alt14=2;
				    	try { DebugEnterDecision(14, decisionCanBacktrack[14]);
				    	int LA14_0 = input.LA(1);

				    	if ((LA14_0==NEWLINE))
				    	{
				    		alt14=1;
				    	}


				    	} finally { DebugExitDecision(14); }
				    	switch ( alt14 )
				    	{
				    	case 1:
				    		DebugEnterAlt(1);
				    		// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:29:48: NEWLINE
				    		{
				    		DebugLocation(29, 48);
				    		_last = (CommonTree)input.LT(1);
				    		NEWLINE26=(CommonTree)Match(input,NEWLINE,Follow._NEWLINE_in_lists336); 
				    		NEWLINE26_tree = (CommonTree)adaptor.DupNode(NEWLINE26);

				    		adaptor.AddChild(root_1, NEWLINE26_tree);


				    		}
				    		break;

				    	default:
				    		goto loop14;
				    	}
				    }

				    loop14:
				    	;

				    } finally { DebugExitSubRule(14); }

				    DebugLocation(29, 57);
				    // catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:29:57: ( li )*
				    try { DebugEnterSubRule(15);
				    while (true)
				    {
				    	int alt15=2;
				    	try { DebugEnterDecision(15, decisionCanBacktrack[15]);
				    	int LA15_0 = input.LA(1);

				    	if ((LA15_0==LISTITEM))
				    	{
				    		alt15=1;
				    	}


				    	} finally { DebugExitDecision(15); }
				    	switch ( alt15 )
				    	{
				    	case 1:
				    		DebugEnterAlt(1);
				    		// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:29:58: li
				    		{
				    		DebugLocation(29, 58);
				    		_last = (CommonTree)input.LT(1);
				    		PushFollow(Follow._li_in_lists340);
				    		li27=li();
				    		PopFollow();

				    		adaptor.AddChild(root_1, li27.Tree);

				    		}
				    		break;

				    	default:
				    		goto loop15;
				    	}
				    }

				    loop15:
				    	;

				    } finally { DebugExitSubRule(15); }

				    DebugLocation(29, 63);
				    // catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:29:63: ( NEWLINE )*
				    try { DebugEnterSubRule(16);
				    while (true)
				    {
				    	int alt16=2;
				    	try { DebugEnterDecision(16, decisionCanBacktrack[16]);
				    	int LA16_0 = input.LA(1);

				    	if ((LA16_0==NEWLINE))
				    	{
				    		alt16=1;
				    	}


				    	} finally { DebugExitDecision(16); }
				    	switch ( alt16 )
				    	{
				    	case 1:
				    		DebugEnterAlt(1);
				    		// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:29:63: NEWLINE
				    		{
				    		DebugLocation(29, 63);
				    		_last = (CommonTree)input.LT(1);
				    		NEWLINE28=(CommonTree)Match(input,NEWLINE,Follow._NEWLINE_in_lists344); 
				    		NEWLINE28_tree = (CommonTree)adaptor.DupNode(NEWLINE28);

				    		adaptor.AddChild(root_1, NEWLINE28_tree);


				    		}
				    		break;

				    	default:
				    		goto loop16;
				    	}
				    }

				    loop16:
				    	;

				    } finally { DebugExitSubRule(16); }

				    DebugLocation(29, 72);
				     Append("</ol>\r\n"); 

				    Match(input, TokenTypes.Up, null); 
				}adaptor.AddChild(root_0, root_1);_last = _save_last_1;
				}


				}
				break;

			}
			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("lists", 10);
			LeaveRule("lists", 10);
			Leave_lists();
		}
		DebugLocation(29, 98);
		} finally { DebugExitRule(GrammarFileName, "lists"); }
		return retval;

	}
	// $ANTLR end "lists"

	public class li_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>
	{
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } } object IAstRuleReturnScope.Tree { get { return Tree; } }
	}

	partial void Enter_li();
	partial void Leave_li();

	// $ANTLR start "li"
	// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:30:1: li : ^( LISTITEM ( inlineElement )+ ( lists )* ) ;
	[GrammarRule("li")]
	private WikiTree.li_return li()
	{
		Enter_li();
		EnterRule("li", 11);
		TraceIn("li", 11);
		WikiTree.li_return retval = new WikiTree.li_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = null;

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree LISTITEM29=null;
		WikiTree.inlineElement_return inlineElement30 = default(WikiTree.inlineElement_return);
		WikiTree.lists_return lists31 = default(WikiTree.lists_return);

		CommonTree LISTITEM29_tree=null;

		try { DebugEnterRule(GrammarFileName, "li");
		DebugLocation(30, 95);
		try
		{
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:30:8: ( ^( LISTITEM ( inlineElement )+ ( lists )* ) )
			DebugEnterAlt(1);
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:30:10: ^( LISTITEM ( inlineElement )+ ( lists )* )
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(30, 10);
			_last = (CommonTree)input.LT(1);
			{
			CommonTree _save_last_1 = _last;
			CommonTree _first_1 = null;
			CommonTree root_1 = (CommonTree)adaptor.Nil();DebugLocation(30, 12);
			_last = (CommonTree)input.LT(1);
			LISTITEM29=(CommonTree)Match(input,LISTITEM,Follow._LISTITEM_in_li362); 
			LISTITEM29_tree = (CommonTree)adaptor.DupNode(LISTITEM29);

			root_1 = (CommonTree)adaptor.BecomeRoot(LISTITEM29_tree, root_1);


			DebugLocation(30, 22);
			 Append("<li>"); 

			Match(input, TokenTypes.Down, null); 
			DebugLocation(30, 45);
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:30:45: ( inlineElement )+
			int cnt18=0;
			try { DebugEnterSubRule(18);
			while (true)
			{
				int alt18=2;
				try { DebugEnterDecision(18, decisionCanBacktrack[18]);
				int LA18_0 = input.LA(1);

				if (((LA18_0>=NEWLINE && LA18_0<=QUOTED)||LA18_0==LT||(LA18_0>=GT && LA18_0<=ESCAPE)||(LA18_0>=STYLES && LA18_0<=COLORS)||LA18_0==NOCONTROL||(LA18_0>=ATTR_TEXT && LA18_0<=ATTR_FLOAT)||LA18_0==ASTERIX||LA18_0==COLON||LA18_0==UNDER||(LA18_0>=SYMBOLS && LA18_0<=HTML_BASE)||(LA18_0>=WORD && LA18_0<=BREAK)||(LA18_0>=NAME_ELEMENT && LA18_0<=IMG_ELEMENT)||(LA18_0>=INLINE && LA18_0<=TAG)))
				{
					alt18=1;
				}


				} finally { DebugExitDecision(18); }
				switch (alt18)
				{
				case 1:
					DebugEnterAlt(1);
					// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:30:45: inlineElement
					{
					DebugLocation(30, 45);
					_last = (CommonTree)input.LT(1);
					PushFollow(Follow._inlineElement_in_li370);
					inlineElement30=inlineElement();
					PopFollow();

					adaptor.AddChild(root_1, inlineElement30.Tree);

					}
					break;

				default:
					if (cnt18 >= 1)
						goto loop18;

					EarlyExitException eee18 = new EarlyExitException( 18, input );
					DebugRecognitionException(eee18);
					throw eee18;
				}
				cnt18++;
			}
			loop18:
				;

			} finally { DebugExitSubRule(18); }

			DebugLocation(30, 60);
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:30:60: ( lists )*
			try { DebugEnterSubRule(19);
			while (true)
			{
				int alt19=2;
				try { DebugEnterDecision(19, decisionCanBacktrack[19]);
				int LA19_0 = input.LA(1);

				if (((LA19_0>=LIST && LA19_0<=NUMERIC)))
				{
					alt19=1;
				}


				} finally { DebugExitDecision(19); }
				switch ( alt19 )
				{
				case 1:
					DebugEnterAlt(1);
					// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:30:60: lists
					{
					DebugLocation(30, 60);
					_last = (CommonTree)input.LT(1);
					PushFollow(Follow._lists_in_li373);
					lists31=lists();
					PopFollow();

					adaptor.AddChild(root_1, lists31.Tree);

					}
					break;

				default:
					goto loop19;
				}
			}

			loop19:
				;

			} finally { DebugExitSubRule(19); }

			DebugLocation(30, 69);
			 Append("</li>\r\n"); 

			Match(input, TokenTypes.Up, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
			}


			}

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("li", 11);
			LeaveRule("li", 11);
			Leave_li();
		}
		DebugLocation(30, 95);
		} finally { DebugExitRule(GrammarFileName, "li"); }
		return retval;

	}
	// $ANTLR end "li"

	public class block_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>
	{
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } } object IAstRuleReturnScope.Tree { get { return Tree; } }
	}

	partial void Enter_block();
	partial void Leave_block();

	// $ANTLR start "block"
	// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:33:1: block : ^(b= ELEMENT ( element )* ) ;
	[GrammarRule("block")]
	private WikiTree.block_return block()
	{
		Enter_block();
		EnterRule("block", 12);
		TraceIn("block", 12);
		WikiTree.block_return retval = new WikiTree.block_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = null;

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree b=null;
		WikiTree.element_return element32 = default(WikiTree.element_return);

		CommonTree b_tree=null;

		try { DebugEnterRule(GrammarFileName, "block");
		DebugLocation(33, 97);
		try
		{
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:33:10: ( ^(b= ELEMENT ( element )* ) )
			DebugEnterAlt(1);
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:33:12: ^(b= ELEMENT ( element )* )
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(33, 12);
			_last = (CommonTree)input.LT(1);
			{
			CommonTree _save_last_1 = _last;
			CommonTree _first_1 = null;
			CommonTree root_1 = (CommonTree)adaptor.Nil();DebugLocation(33, 15);
			_last = (CommonTree)input.LT(1);
			b=(CommonTree)Match(input,ELEMENT,Follow._ELEMENT_in_block396); 
			b_tree = (CommonTree)adaptor.DupNode(b);

			root_1 = (CommonTree)adaptor.BecomeRoot(b_tree, root_1);


			DebugLocation(33, 24);
			 BlockTag(b.Text, false); 

			if ( input.LA(1)==TokenTypes.Down ) {
			    Match(input, TokenTypes.Down, null); 
			    DebugLocation(33, 55);
			    // catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:33:55: ( element )*
			    try { DebugEnterSubRule(20);
			    while (true)
			    {
			    	int alt20=2;
			    	try { DebugEnterDecision(20, decisionCanBacktrack[20]);
			    	int LA20_0 = input.LA(1);

			    	if (((LA20_0>=NEWLINE && LA20_0<=QUOTED)||LA20_0==LT||(LA20_0>=GT && LA20_0<=ESCAPE)||(LA20_0>=STYLES && LA20_0<=COLORS)||LA20_0==NOCONTROL||(LA20_0>=ATTR_TEXT && LA20_0<=ATTR_FLOAT)||LA20_0==ASTERIX||LA20_0==COLON||LA20_0==UNDER||(LA20_0>=SYMBOLS && LA20_0<=HTML_BASE)||(LA20_0>=WORD && LA20_0<=IMG_ELEMENT)||(LA20_0>=INLINE && LA20_0<=NUMERIC)))
			    	{
			    		alt20=1;
			    	}


			    	} finally { DebugExitDecision(20); }
			    	switch ( alt20 )
			    	{
			    	case 1:
			    		DebugEnterAlt(1);
			    		// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:33:55: element
			    		{
			    		DebugLocation(33, 55);
			    		_last = (CommonTree)input.LT(1);
			    		PushFollow(Follow._element_in_block401);
			    		element32=element();
			    		PopFollow();

			    		adaptor.AddChild(root_1, element32.Tree);

			    		}
			    		break;

			    	default:
			    		goto loop20;
			    	}
			    }

			    loop20:
			    	;

			    } finally { DebugExitSubRule(20); }

			    DebugLocation(33, 68);
			     BlockTag(b.Text, true); 

			    Match(input, TokenTypes.Up, null); 
			}adaptor.AddChild(root_0, root_1);_last = _save_last_1;
			}


			}

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("block", 12);
			LeaveRule("block", 12);
			Leave_block();
		}
		DebugLocation(33, 97);
		} finally { DebugExitRule(GrammarFileName, "block"); }
		return retval;

	}
	// $ANTLR end "block"

	public class inline_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>
	{
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } } object IAstRuleReturnScope.Tree { get { return Tree; } }
	}

	partial void Enter_inline();
	partial void Leave_inline();

	// $ANTLR start "inline"
	// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:34:1: inline : ^(i= INLINE ( inlineElement )* ) ;
	[GrammarRule("inline")]
	private WikiTree.inline_return inline()
	{
		Enter_inline();
		EnterRule("inline", 13);
		TraceIn("inline", 13);
		WikiTree.inline_return retval = new WikiTree.inline_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = null;

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree i=null;
		WikiTree.inlineElement_return inlineElement33 = default(WikiTree.inlineElement_return);

		CommonTree i_tree=null;

		try { DebugEnterRule(GrammarFileName, "inline");
		DebugLocation(34, 101);
		try
		{
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:34:10: ( ^(i= INLINE ( inlineElement )* ) )
			DebugEnterAlt(1);
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:34:12: ^(i= INLINE ( inlineElement )* )
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(34, 12);
			_last = (CommonTree)input.LT(1);
			{
			CommonTree _save_last_1 = _last;
			CommonTree _first_1 = null;
			CommonTree root_1 = (CommonTree)adaptor.Nil();DebugLocation(34, 15);
			_last = (CommonTree)input.LT(1);
			i=(CommonTree)Match(input,INLINE,Follow._INLINE_in_inline422); 
			i_tree = (CommonTree)adaptor.DupNode(i);

			root_1 = (CommonTree)adaptor.BecomeRoot(i_tree, root_1);


			DebugLocation(34, 24);
			 InlineTag(i.Text, false); 

			if ( input.LA(1)==TokenTypes.Down ) {
			    Match(input, TokenTypes.Down, null); 
			    DebugLocation(34, 55);
			    // catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:34:55: ( inlineElement )*
			    try { DebugEnterSubRule(21);
			    while (true)
			    {
			    	int alt21=2;
			    	try { DebugEnterDecision(21, decisionCanBacktrack[21]);
			    	int LA21_0 = input.LA(1);

			    	if (((LA21_0>=NEWLINE && LA21_0<=QUOTED)||LA21_0==LT||(LA21_0>=GT && LA21_0<=ESCAPE)||(LA21_0>=STYLES && LA21_0<=COLORS)||LA21_0==NOCONTROL||(LA21_0>=ATTR_TEXT && LA21_0<=ATTR_FLOAT)||LA21_0==ASTERIX||LA21_0==COLON||LA21_0==UNDER||(LA21_0>=SYMBOLS && LA21_0<=HTML_BASE)||(LA21_0>=WORD && LA21_0<=BREAK)||(LA21_0>=NAME_ELEMENT && LA21_0<=IMG_ELEMENT)||(LA21_0>=INLINE && LA21_0<=TAG)))
			    	{
			    		alt21=1;
			    	}


			    	} finally { DebugExitDecision(21); }
			    	switch ( alt21 )
			    	{
			    	case 1:
			    		DebugEnterAlt(1);
			    		// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:34:55: inlineElement
			    		{
			    		DebugLocation(34, 55);
			    		_last = (CommonTree)input.LT(1);
			    		PushFollow(Follow._inlineElement_in_inline427);
			    		inlineElement33=inlineElement();
			    		PopFollow();

			    		adaptor.AddChild(root_1, inlineElement33.Tree);

			    		}
			    		break;

			    	default:
			    		goto loop21;
			    	}
			    }

			    loop21:
			    	;

			    } finally { DebugExitSubRule(21); }

			    DebugLocation(34, 70);
			     InlineTag(i.Text, true); 

			    Match(input, TokenTypes.Up, null); 
			}adaptor.AddChild(root_0, root_1);_last = _save_last_1;
			}


			}

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("inline", 13);
			LeaveRule("inline", 13);
			Leave_inline();
		}
		DebugLocation(34, 101);
		} finally { DebugExitRule(GrammarFileName, "inline"); }
		return retval;

	}
	// $ANTLR end "inline"

	public class tag_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>
	{
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } } object IAstRuleReturnScope.Tree { get { return Tree; } }
	}

	partial void Enter_tag();
	partial void Leave_tag();

	// $ANTLR start "tag"
	// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:37:1: tag : ^( TAG ( codeText )* ) ;
	[GrammarRule("tag")]
	private WikiTree.tag_return tag()
	{
		Enter_tag();
		EnterRule("tag", 14);
		TraceIn("tag", 14);
		WikiTree.tag_return retval = new WikiTree.tag_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = null;

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree TAG34=null;
		WikiTree.codeText_return codeText35 = default(WikiTree.codeText_return);

		CommonTree TAG34_tree=null;

		try { DebugEnterRule(GrammarFileName, "tag");
		DebugLocation(37, 81);
		try
		{
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:37:10: ( ^( TAG ( codeText )* ) )
			DebugEnterAlt(1);
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:37:12: ^( TAG ( codeText )* )
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(37, 12);
			_last = (CommonTree)input.LT(1);
			{
			CommonTree _save_last_1 = _last;
			CommonTree _first_1 = null;
			CommonTree root_1 = (CommonTree)adaptor.Nil();DebugLocation(37, 14);
			_last = (CommonTree)input.LT(1);
			TAG34=(CommonTree)Match(input,TAG,Follow._TAG_in_tag456); 
			TAG34_tree = (CommonTree)adaptor.DupNode(TAG34);

			root_1 = (CommonTree)adaptor.BecomeRoot(TAG34_tree, root_1);


			DebugLocation(37, 24);
			 TagElement(false); 

			if ( input.LA(1)==TokenTypes.Down ) {
			    Match(input, TokenTypes.Down, null); 
			    DebugLocation(37, 49);
			    // catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:37:49: ( codeText )*
			    try { DebugEnterSubRule(22);
			    while (true)
			    {
			    	int alt22=2;
			    	try { DebugEnterDecision(22, decisionCanBacktrack[22]);
			    	int LA22_0 = input.LA(1);

			    	if (((LA22_0>=NEWLINE && LA22_0<=QUOTED)||LA22_0==LT||(LA22_0>=GT && LA22_0<=ESCAPE)||(LA22_0>=STYLES && LA22_0<=COLORS)||LA22_0==NOCONTROL||(LA22_0>=ATTR_TEXT && LA22_0<=ATTR_FLOAT)||LA22_0==ASTERIX||LA22_0==COLON||LA22_0==UNDER||(LA22_0>=SYMBOLS && LA22_0<=HTML_BASE)||(LA22_0>=WORD && LA22_0<=BREAK)))
			    	{
			    		alt22=1;
			    	}


			    	} finally { DebugExitDecision(22); }
			    	switch ( alt22 )
			    	{
			    	case 1:
			    		DebugEnterAlt(1);
			    		// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:37:49: codeText
			    		{
			    		DebugLocation(37, 49);
			    		_last = (CommonTree)input.LT(1);
			    		PushFollow(Follow._codeText_in_tag468);
			    		codeText35=codeText();
			    		PopFollow();

			    		adaptor.AddChild(root_1, codeText35.Tree);

			    		}
			    		break;

			    	default:
			    		goto loop22;
			    	}
			    }

			    loop22:
			    	;

			    } finally { DebugExitSubRule(22); }

			    DebugLocation(37, 59);
			     TagElement(true); 

			    Match(input, TokenTypes.Up, null); 
			}adaptor.AddChild(root_0, root_1);_last = _save_last_1;
			}


			}

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("tag", 14);
			LeaveRule("tag", 14);
			Leave_tag();
		}
		DebugLocation(37, 81);
		} finally { DebugExitRule(GrammarFileName, "tag"); }
		return retval;

	}
	// $ANTLR end "tag"

	public class anchor_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>
	{
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } } object IAstRuleReturnScope.Tree { get { return Tree; } }
	}

	partial void Enter_anchor();
	partial void Leave_anchor();

	// $ANTLR start "anchor"
	// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:38:1: anchor : ^( A_ELEMENT ( pureText )* attrText ) ;
	[GrammarRule("anchor")]
	private WikiTree.anchor_return anchor()
	{
		Enter_anchor();
		EnterRule("anchor", 15);
		TraceIn("anchor", 15);
		WikiTree.anchor_return retval = new WikiTree.anchor_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = null;

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree A_ELEMENT36=null;
		WikiTree.pureText_return pureText37 = default(WikiTree.pureText_return);
		WikiTree.attrText_return attrText38 = default(WikiTree.attrText_return);

		CommonTree A_ELEMENT36_tree=null;

		try { DebugEnterRule(GrammarFileName, "anchor");
		DebugLocation(38, 126);
		try
		{
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:38:10: ( ^( A_ELEMENT ( pureText )* attrText ) )
			DebugEnterAlt(1);
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:38:12: ^( A_ELEMENT ( pureText )* attrText )
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(38, 12);
			_last = (CommonTree)input.LT(1);
			{
			CommonTree _save_last_1 = _last;
			CommonTree _first_1 = null;
			CommonTree root_1 = (CommonTree)adaptor.Nil();DebugLocation(38, 14);
			_last = (CommonTree)input.LT(1);
			A_ELEMENT36=(CommonTree)Match(input,A_ELEMENT,Follow._A_ELEMENT_in_anchor483); 
			A_ELEMENT36_tree = (CommonTree)adaptor.DupNode(A_ELEMENT36);

			root_1 = (CommonTree)adaptor.BecomeRoot(A_ELEMENT36_tree, root_1);


			DebugLocation(38, 26);
			 SpecialTextStart(); 

			Match(input, TokenTypes.Down, null); 
			DebugLocation(38, 52);
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:38:52: ( pureText )*
			try { DebugEnterSubRule(23);
			while (true)
			{
				int alt23=2;
				try { DebugEnterDecision(23, decisionCanBacktrack[23]);
				int LA23_0 = input.LA(1);

				if (((LA23_0>=NEWLINE && LA23_0<=QUOTED)||LA23_0==LT||(LA23_0>=GT && LA23_0<=ESCAPE)||(LA23_0>=STYLES && LA23_0<=COLORS)||LA23_0==NOCONTROL||(LA23_0>=ATTR_TEXT && LA23_0<=ATTR_FLOAT)||LA23_0==ASTERIX||LA23_0==COLON||LA23_0==UNDER||(LA23_0>=SYMBOLS && LA23_0<=HTML_BASE)||(LA23_0>=WORD && LA23_0<=BREAK)))
				{
					alt23=1;
				}


				} finally { DebugExitDecision(23); }
				switch ( alt23 )
				{
				case 1:
					DebugEnterAlt(1);
					// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:38:52: pureText
					{
					DebugLocation(38, 52);
					_last = (CommonTree)input.LT(1);
					PushFollow(Follow._pureText_in_anchor491);
					pureText37=pureText();
					PopFollow();

					adaptor.AddChild(root_1, pureText37.Tree);

					}
					break;

				default:
					goto loop23;
				}
			}

			loop23:
				;

			} finally { DebugExitSubRule(23); }

			DebugLocation(38, 62);
			 SpecialTextEnd(AnchorTemplate);
			DebugLocation(38, 98);
			_last = (CommonTree)input.LT(1);
			PushFollow(Follow._attrText_in_anchor497);
			attrText38=attrText();
			PopFollow();

			adaptor.AddChild(root_1, attrText38.Tree);
			DebugLocation(38, 107);
			 Append("</a>");

			Match(input, TokenTypes.Up, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
			}


			}

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("anchor", 15);
			LeaveRule("anchor", 15);
			Leave_anchor();
		}
		DebugLocation(38, 126);
		} finally { DebugExitRule(GrammarFileName, "anchor"); }
		return retval;

	}
	// $ANTLR end "anchor"

	public class name_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>
	{
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } } object IAstRuleReturnScope.Tree { get { return Tree; } }
	}

	partial void Enter_name();
	partial void Leave_name();

	// $ANTLR start "name"
	// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:39:1: name : ^( NAME_ELEMENT ( pureText )* ) ;
	[GrammarRule("name")]
	private WikiTree.name_return name()
	{
		Enter_name();
		EnterRule("name", 16);
		TraceIn("name", 16);
		WikiTree.name_return retval = new WikiTree.name_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = null;

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree NAME_ELEMENT39=null;
		WikiTree.pureText_return pureText40 = default(WikiTree.pureText_return);

		CommonTree NAME_ELEMENT39_tree=null;

		try { DebugEnterRule(GrammarFileName, "name");
		DebugLocation(39, 86);
		try
		{
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:39:10: ( ^( NAME_ELEMENT ( pureText )* ) )
			DebugEnterAlt(1);
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:39:12: ^( NAME_ELEMENT ( pureText )* )
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(39, 12);
			_last = (CommonTree)input.LT(1);
			{
			CommonTree _save_last_1 = _last;
			CommonTree _first_1 = null;
			CommonTree root_1 = (CommonTree)adaptor.Nil();DebugLocation(39, 14);
			_last = (CommonTree)input.LT(1);
			NAME_ELEMENT39=(CommonTree)Match(input,NAME_ELEMENT,Follow._NAME_ELEMENT_in_name513); 
			NAME_ELEMENT39_tree = (CommonTree)adaptor.DupNode(NAME_ELEMENT39);

			root_1 = (CommonTree)adaptor.BecomeRoot(NAME_ELEMENT39_tree, root_1);


			DebugLocation(39, 26);
			 Append("<a name=\""); 

			if ( input.LA(1)==TokenTypes.Down ) {
			    Match(input, TokenTypes.Down, null); 
			    DebugLocation(39, 52);
			    // catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:39:52: ( pureText )*
			    try { DebugEnterSubRule(24);
			    while (true)
			    {
			    	int alt24=2;
			    	try { DebugEnterDecision(24, decisionCanBacktrack[24]);
			    	int LA24_0 = input.LA(1);

			    	if (((LA24_0>=NEWLINE && LA24_0<=QUOTED)||LA24_0==LT||(LA24_0>=GT && LA24_0<=ESCAPE)||(LA24_0>=STYLES && LA24_0<=COLORS)||LA24_0==NOCONTROL||(LA24_0>=ATTR_TEXT && LA24_0<=ATTR_FLOAT)||LA24_0==ASTERIX||LA24_0==COLON||LA24_0==UNDER||(LA24_0>=SYMBOLS && LA24_0<=HTML_BASE)||(LA24_0>=WORD && LA24_0<=BREAK)))
			    	{
			    		alt24=1;
			    	}


			    	} finally { DebugExitDecision(24); }
			    	switch ( alt24 )
			    	{
			    	case 1:
			    		DebugEnterAlt(1);
			    		// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:39:52: pureText
			    		{
			    		DebugLocation(39, 52);
			    		_last = (CommonTree)input.LT(1);
			    		PushFollow(Follow._pureText_in_name516);
			    		pureText40=pureText();
			    		PopFollow();

			    		adaptor.AddChild(root_1, pureText40.Tree);

			    		}
			    		break;

			    	default:
			    		goto loop24;
			    	}
			    }

			    loop24:
			    	;

			    } finally { DebugExitSubRule(24); }

			    DebugLocation(39, 62);
			     Append("\" ></a>");

			    Match(input, TokenTypes.Up, null); 
			}adaptor.AddChild(root_0, root_1);_last = _save_last_1;
			}


			}

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("name", 16);
			LeaveRule("name", 16);
			Leave_name();
		}
		DebugLocation(39, 86);
		} finally { DebugExitRule(GrammarFileName, "name"); }
		return retval;

	}
	// $ANTLR end "name"

	public class image_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>
	{
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } } object IAstRuleReturnScope.Tree { get { return Tree; } }
	}

	partial void Enter_image();
	partial void Leave_image();

	// $ANTLR start "image"
	// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:42:1: image : ^( IMG_ELEMENT ( pureText )* ( imageAttrs )* ) ;
	[GrammarRule("image")]
	private WikiTree.image_return image()
	{
		Enter_image();
		EnterRule("image", 17);
		TraceIn("image", 17);
		WikiTree.image_return retval = new WikiTree.image_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = null;

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree IMG_ELEMENT41=null;
		WikiTree.pureText_return pureText42 = default(WikiTree.pureText_return);
		WikiTree.imageAttrs_return imageAttrs43 = default(WikiTree.imageAttrs_return);

		CommonTree IMG_ELEMENT41_tree=null;

		try { DebugEnterRule(GrammarFileName, "image");
		DebugLocation(42, 129);
		try
		{
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:42:11: ( ^( IMG_ELEMENT ( pureText )* ( imageAttrs )* ) )
			DebugEnterAlt(1);
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:42:13: ^( IMG_ELEMENT ( pureText )* ( imageAttrs )* )
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(42, 13);
			_last = (CommonTree)input.LT(1);
			{
			CommonTree _save_last_1 = _last;
			CommonTree _first_1 = null;
			CommonTree root_1 = (CommonTree)adaptor.Nil();DebugLocation(42, 15);
			_last = (CommonTree)input.LT(1);
			IMG_ELEMENT41=(CommonTree)Match(input,IMG_ELEMENT,Follow._IMG_ELEMENT_in_image536); 
			IMG_ELEMENT41_tree = (CommonTree)adaptor.DupNode(IMG_ELEMENT41);

			root_1 = (CommonTree)adaptor.BecomeRoot(IMG_ELEMENT41_tree, root_1);


			DebugLocation(42, 27);
			 SpecialTextStart(); 

			if ( input.LA(1)==TokenTypes.Down ) {
			    Match(input, TokenTypes.Down, null); 
			    DebugLocation(42, 51);
			    // catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:42:51: ( pureText )*
			    try { DebugEnterSubRule(25);
			    while (true)
			    {
			    	int alt25=2;
			    	try { DebugEnterDecision(25, decisionCanBacktrack[25]);
			    	int LA25_0 = input.LA(1);

			    	if (((LA25_0>=NEWLINE && LA25_0<=QUOTED)||LA25_0==LT||(LA25_0>=GT && LA25_0<=ESCAPE)||(LA25_0>=STYLES && LA25_0<=COLORS)||LA25_0==NOCONTROL||(LA25_0>=ATTR_TEXT && LA25_0<=ATTR_FLOAT)||LA25_0==ASTERIX||LA25_0==COLON||LA25_0==UNDER||(LA25_0>=SYMBOLS && LA25_0<=HTML_BASE)||(LA25_0>=WORD && LA25_0<=BREAK)))
			    	{
			    		alt25=1;
			    	}


			    	} finally { DebugExitDecision(25); }
			    	switch ( alt25 )
			    	{
			    	case 1:
			    		DebugEnterAlt(1);
			    		// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:42:52: pureText
			    		{
			    		DebugLocation(42, 52);
			    		_last = (CommonTree)input.LT(1);
			    		PushFollow(Follow._pureText_in_image541);
			    		pureText42=pureText();
			    		PopFollow();

			    		adaptor.AddChild(root_1, pureText42.Tree);

			    		}
			    		break;

			    	default:
			    		goto loop25;
			    	}
			    }

			    loop25:
			    	;

			    } finally { DebugExitSubRule(25); }

			    DebugLocation(42, 63);
			     SpecialTextEnd(ImageTemplate);
			    DebugLocation(42, 97);
			    // catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:42:97: ( imageAttrs )*
			    try { DebugEnterSubRule(26);
			    while (true)
			    {
			    	int alt26=2;
			    	try { DebugEnterDecision(26, decisionCanBacktrack[26]);
			    	int LA26_0 = input.LA(1);

			    	if ((LA26_0==ATTR))
			    	{
			    		alt26=1;
			    	}


			    	} finally { DebugExitDecision(26); }
			    	switch ( alt26 )
			    	{
			    	case 1:
			    		DebugEnterAlt(1);
			    		// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:42:97: imageAttrs
			    		{
			    		DebugLocation(42, 97);
			    		_last = (CommonTree)input.LT(1);
			    		PushFollow(Follow._imageAttrs_in_image547);
			    		imageAttrs43=imageAttrs();
			    		PopFollow();

			    		adaptor.AddChild(root_1, imageAttrs43.Tree);

			    		}
			    		break;

			    	default:
			    		goto loop26;
			    	}
			    }

			    loop26:
			    	;

			    } finally { DebugExitSubRule(26); }

			    DebugLocation(42, 109);
			     Append("\" />");

			    Match(input, TokenTypes.Up, null); 
			}adaptor.AddChild(root_0, root_1);_last = _save_last_1;
			}


			}

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("image", 17);
			LeaveRule("image", 17);
			Leave_image();
		}
		DebugLocation(42, 129);
		} finally { DebugExitRule(GrammarFileName, "image"); }
		return retval;

	}
	// $ANTLR end "image"

	public class imageAttrs_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>
	{
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } } object IAstRuleReturnScope.Tree { get { return Tree; } }
	}

	partial void Enter_imageAttrs();
	partial void Leave_imageAttrs();

	// $ANTLR start "imageAttrs"
	// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:43:1: imageAttrs : ^(style= ATTR pt= WORD ) ;
	[GrammarRule("imageAttrs")]
	private WikiTree.imageAttrs_return imageAttrs()
	{
		Enter_imageAttrs();
		EnterRule("imageAttrs", 18);
		TraceIn("imageAttrs", 18);
		WikiTree.imageAttrs_return retval = new WikiTree.imageAttrs_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = null;

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree style=null;
		CommonTree pt=null;

		CommonTree style_tree=null;
		CommonTree pt_tree=null;

		try { DebugEnterRule(GrammarFileName, "imageAttrs");
		DebugLocation(43, 72);
		try
		{
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:43:11: ( ^(style= ATTR pt= WORD ) )
			DebugEnterAlt(1);
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:43:13: ^(style= ATTR pt= WORD )
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(43, 13);
			_last = (CommonTree)input.LT(1);
			{
			CommonTree _save_last_1 = _last;
			CommonTree _first_1 = null;
			CommonTree root_1 = (CommonTree)adaptor.Nil();DebugLocation(43, 20);
			_last = (CommonTree)input.LT(1);
			style=(CommonTree)Match(input,ATTR,Follow._ATTR_in_imageAttrs561); 
			style_tree = (CommonTree)adaptor.DupNode(style);

			root_1 = (CommonTree)adaptor.BecomeRoot(style_tree, root_1);



			Match(input, TokenTypes.Down, null); 
			DebugLocation(43, 28);
			_last = (CommonTree)input.LT(1);
			pt=(CommonTree)Match(input,WORD,Follow._WORD_in_imageAttrs565); 
			pt_tree = (CommonTree)adaptor.DupNode(pt);

			adaptor.AddChild(root_1, pt_tree);

			DebugLocation(43, 34);
			 ImageAttr(pt.Text, style.Text); 

			Match(input, TokenTypes.Up, null); adaptor.AddChild(root_0, root_1);_last = _save_last_1;
			}


			}

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("imageAttrs", 18);
			LeaveRule("imageAttrs", 18);
			Leave_imageAttrs();
		}
		DebugLocation(43, 72);
		} finally { DebugExitRule(GrammarFileName, "imageAttrs"); }
		return retval;

	}
	// $ANTLR end "imageAttrs"

	public class attrText_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>
	{
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } } object IAstRuleReturnScope.Tree { get { return Tree; } }
	}

	partial void Enter_attrText();
	partial void Leave_attrText();

	// $ANTLR start "attrText"
	// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:44:1: attrText : ^( ATTR ( simpleText | image )* ) ;
	[GrammarRule("attrText")]
	private WikiTree.attrText_return attrText()
	{
		Enter_attrText();
		EnterRule("attrText", 19);
		TraceIn("attrText", 19);
		WikiTree.attrText_return retval = new WikiTree.attrText_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = null;

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree ATTR44=null;
		WikiTree.simpleText_return simpleText45 = default(WikiTree.simpleText_return);
		WikiTree.image_return image46 = default(WikiTree.image_return);

		CommonTree ATTR44_tree=null;

		try { DebugEnterRule(GrammarFileName, "attrText");
		DebugLocation(44, 42);
		try
		{
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:44:11: ( ^( ATTR ( simpleText | image )* ) )
			DebugEnterAlt(1);
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:44:13: ^( ATTR ( simpleText | image )* )
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(44, 13);
			_last = (CommonTree)input.LT(1);
			{
			CommonTree _save_last_1 = _last;
			CommonTree _first_1 = null;
			CommonTree root_1 = (CommonTree)adaptor.Nil();DebugLocation(44, 15);
			_last = (CommonTree)input.LT(1);
			ATTR44=(CommonTree)Match(input,ATTR,Follow._ATTR_in_attrText578); 
			ATTR44_tree = (CommonTree)adaptor.DupNode(ATTR44);

			root_1 = (CommonTree)adaptor.BecomeRoot(ATTR44_tree, root_1);



			if ( input.LA(1)==TokenTypes.Down ) {
			    Match(input, TokenTypes.Down, null); 
			    DebugLocation(44, 20);
			    // catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:44:20: ( simpleText | image )*
			    try { DebugEnterSubRule(27);
			    while (true)
			    {
			    	int alt27=3;
			    	try { DebugEnterDecision(27, decisionCanBacktrack[27]);
			    	int LA27_0 = input.LA(1);

			    	if (((LA27_0>=NEWLINE && LA27_0<=QUOTED)||LA27_0==LT||(LA27_0>=GT && LA27_0<=ESCAPE)||(LA27_0>=STYLES && LA27_0<=COLORS)||LA27_0==NOCONTROL||(LA27_0>=ATTR_TEXT && LA27_0<=ATTR_FLOAT)||LA27_0==ASTERIX||LA27_0==COLON||LA27_0==UNDER||(LA27_0>=SYMBOLS && LA27_0<=HTML_BASE)||(LA27_0>=WORD && LA27_0<=BREAK)))
			    	{
			    		alt27=1;
			    	}
			    	else if ((LA27_0==IMG_ELEMENT))
			    	{
			    		alt27=2;
			    	}


			    	} finally { DebugExitDecision(27); }
			    	switch ( alt27 )
			    	{
			    	case 1:
			    		DebugEnterAlt(1);
			    		// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:44:21: simpleText
			    		{
			    		DebugLocation(44, 21);
			    		_last = (CommonTree)input.LT(1);
			    		PushFollow(Follow._simpleText_in_attrText581);
			    		simpleText45=simpleText();
			    		PopFollow();

			    		adaptor.AddChild(root_1, simpleText45.Tree);

			    		}
			    		break;
			    	case 2:
			    		DebugEnterAlt(2);
			    		// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:44:34: image
			    		{
			    		DebugLocation(44, 34);
			    		_last = (CommonTree)input.LT(1);
			    		PushFollow(Follow._image_in_attrText585);
			    		image46=image();
			    		PopFollow();

			    		adaptor.AddChild(root_1, image46.Tree);

			    		}
			    		break;

			    	default:
			    		goto loop27;
			    	}
			    }

			    loop27:
			    	;

			    } finally { DebugExitSubRule(27); }


			    Match(input, TokenTypes.Up, null); 
			}adaptor.AddChild(root_0, root_1);_last = _save_last_1;
			}


			}

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("attrText", 19);
			LeaveRule("attrText", 19);
			Leave_attrText();
		}
		DebugLocation(44, 42);
		} finally { DebugExitRule(GrammarFileName, "attrText"); }
		return retval;

	}
	// $ANTLR end "attrText"

	public class simpleText_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>
	{
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } } object IAstRuleReturnScope.Tree { get { return Tree; } }
	}

	partial void Enter_simpleText();
	partial void Leave_simpleText();

	// $ANTLR start "simpleText"
	// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:48:1: simpleText : ( alwaysText | txt= ( HTML_BASE | COMMENT | QUOTED | SYMBOLS | LT | GT | CSHARP_BASE | CSHARP_FLOW | CSHARP_SPECIAL | CSHARP_TYPES ) | whs= WS );
	[GrammarRule("simpleText")]
	private WikiTree.simpleText_return simpleText()
	{
		Enter_simpleText();
		EnterRule("simpleText", 20);
		TraceIn("simpleText", 20);
		WikiTree.simpleText_return retval = new WikiTree.simpleText_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = null;

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree txt=null;
		CommonTree whs=null;
		WikiTree.alwaysText_return alwaysText47 = default(WikiTree.alwaysText_return);

		CommonTree txt_tree=null;
		CommonTree whs_tree=null;

		try { DebugEnterRule(GrammarFileName, "simpleText");
		DebugLocation(48, 0);
		try
		{
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:48:13: ( alwaysText | txt= ( HTML_BASE | COMMENT | QUOTED | SYMBOLS | LT | GT | CSHARP_BASE | CSHARP_FLOW | CSHARP_SPECIAL | CSHARP_TYPES ) | whs= WS )
			int alt28=3;
			try { DebugEnterDecision(28, decisionCanBacktrack[28]);
			switch (input.LA(1))
			{
			case NEWLINE:
			case ESCAPE:
			case STYLES:
			case COLORS:
			case NOCONTROL:
			case ATTR_TEXT:
			case ATTR_HEIGHT:
			case ATTR_WIDTH:
			case ATTR_FLOAT:
			case ASTERIX:
			case COLON:
			case UNDER:
			case WORD:
			case BREAK:
				{
				alt28=1;
				}
				break;
			case COMMENT:
			case QUOTED:
			case LT:
			case GT:
			case SYMBOLS:
			case CSHARP_BASE:
			case CSHARP_TYPES:
			case CSHARP_FLOW:
			case CSHARP_SPECIAL:
			case HTML_BASE:
				{
				alt28=2;
				}
				break;
			case WS:
				{
				alt28=3;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 28, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(28); }
			switch (alt28)
			{
			case 1:
				DebugEnterAlt(1);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:48:15: alwaysText
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(48, 15);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._alwaysText_in_simpleText600);
				alwaysText47=alwaysText();
				PopFollow();

				adaptor.AddChild(root_0, alwaysText47.Tree);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:49:15: txt= ( HTML_BASE | COMMENT | QUOTED | SYMBOLS | LT | GT | CSHARP_BASE | CSHARP_FLOW | CSHARP_SPECIAL | CSHARP_TYPES )
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(49, 18);
				_last = (CommonTree)input.LT(1);
				txt=(CommonTree)input.LT(1);
				if ((input.LA(1)>=COMMENT && input.LA(1)<=QUOTED)||input.LA(1)==LT||input.LA(1)==GT||(input.LA(1)>=SYMBOLS && input.LA(1)<=HTML_BASE))
				{
					input.Consume();

					txt_tree = (CommonTree)adaptor.DupNode(txt);

					adaptor.AddChild(root_0, txt_tree);

					state.errorRecovery=false;
				}
				else
				{
					MismatchedSetException mse = new MismatchedSetException(null,input);
					DebugRecognitionException(mse);
					throw mse;
				}

				DebugLocation(51, 16);
				 Append(txt); 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:52:15: whs= WS
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(52, 18);
				_last = (CommonTree)input.LT(1);
				whs=(CommonTree)Match(input,WS,Follow._WS_in_simpleText718); 
				whs_tree = (CommonTree)adaptor.DupNode(whs);

				adaptor.AddChild(root_0, whs_tree);

				DebugLocation(52, 28);
				 Append(" "); 

				}
				break;

			}
			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("simpleText", 20);
			LeaveRule("simpleText", 20);
			Leave_simpleText();
		}
		DebugLocation(53, 0);
		} finally { DebugExitRule(GrammarFileName, "simpleText"); }
		return retval;

	}
	// $ANTLR end "simpleText"

	public class pureText_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>
	{
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } } object IAstRuleReturnScope.Tree { get { return Tree; } }
	}

	partial void Enter_pureText();
	partial void Leave_pureText();

	// $ANTLR start "pureText"
	// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:54:1: pureText : ( alwaysText | txt= ( HTML_BASE | COMMENT | QUOTED | SYMBOLS | LT | GT | COLON | ASTERIX | UNDER | CSHARP_BASE | CSHARP_FLOW | CSHARP_SPECIAL | CSHARP_TYPES ) | whs= WS );
	[GrammarRule("pureText")]
	private WikiTree.pureText_return pureText()
	{
		Enter_pureText();
		EnterRule("pureText", 21);
		TraceIn("pureText", 21);
		WikiTree.pureText_return retval = new WikiTree.pureText_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = null;

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree txt=null;
		CommonTree whs=null;
		WikiTree.alwaysText_return alwaysText48 = default(WikiTree.alwaysText_return);

		CommonTree txt_tree=null;
		CommonTree whs_tree=null;

		try { DebugEnterRule(GrammarFileName, "pureText");
		DebugLocation(54, 0);
		try
		{
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:54:13: ( alwaysText | txt= ( HTML_BASE | COMMENT | QUOTED | SYMBOLS | LT | GT | COLON | ASTERIX | UNDER | CSHARP_BASE | CSHARP_FLOW | CSHARP_SPECIAL | CSHARP_TYPES ) | whs= WS )
			int alt29=3;
			try { DebugEnterDecision(29, decisionCanBacktrack[29]);
			switch (input.LA(1))
			{
			case NEWLINE:
			case ESCAPE:
			case STYLES:
			case COLORS:
			case NOCONTROL:
			case ATTR_TEXT:
			case ATTR_HEIGHT:
			case ATTR_WIDTH:
			case ATTR_FLOAT:
			case ASTERIX:
			case COLON:
			case UNDER:
			case WORD:
			case BREAK:
				{
				alt29=1;
				}
				break;
			case COMMENT:
			case QUOTED:
			case LT:
			case GT:
			case SYMBOLS:
			case CSHARP_BASE:
			case CSHARP_TYPES:
			case CSHARP_FLOW:
			case CSHARP_SPECIAL:
			case HTML_BASE:
				{
				alt29=2;
				}
				break;
			case WS:
				{
				alt29=3;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 29, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(29); }
			switch (alt29)
			{
			case 1:
				DebugEnterAlt(1);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:54:15: alwaysText
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(54, 15);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._alwaysText_in_pureText737);
				alwaysText48=alwaysText();
				PopFollow();

				adaptor.AddChild(root_0, alwaysText48.Tree);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:55:15: txt= ( HTML_BASE | COMMENT | QUOTED | SYMBOLS | LT | GT | COLON | ASTERIX | UNDER | CSHARP_BASE | CSHARP_FLOW | CSHARP_SPECIAL | CSHARP_TYPES )
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(55, 18);
				_last = (CommonTree)input.LT(1);
				txt=(CommonTree)input.LT(1);
				if ((input.LA(1)>=COMMENT && input.LA(1)<=QUOTED)||input.LA(1)==LT||input.LA(1)==GT||input.LA(1)==ASTERIX||input.LA(1)==COLON||input.LA(1)==UNDER||(input.LA(1)>=SYMBOLS && input.LA(1)<=HTML_BASE))
				{
					input.Consume();

					txt_tree = (CommonTree)adaptor.DupNode(txt);

					adaptor.AddChild(root_0, txt_tree);

					state.errorRecovery=false;
				}
				else
				{
					MismatchedSetException mse = new MismatchedSetException(null,input);
					DebugRecognitionException(mse);
					throw mse;
				}

				DebugLocation(58, 16);
				 Append(txt); 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:59:15: whs= WS
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(59, 18);
				_last = (CommonTree)input.LT(1);
				whs=(CommonTree)Match(input,WS,Follow._WS_in_pureText867); 
				whs_tree = (CommonTree)adaptor.DupNode(whs);

				adaptor.AddChild(root_0, whs_tree);


				}
				break;

			}
			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("pureText", 21);
			LeaveRule("pureText", 21);
			Leave_pureText();
		}
		DebugLocation(60, 0);
		} finally { DebugExitRule(GrammarFileName, "pureText"); }
		return retval;

	}
	// $ANTLR end "pureText"

	public class codeText_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>
	{
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } } object IAstRuleReturnScope.Tree { get { return Tree; } }
	}

	partial void Enter_codeText();
	partial void Leave_codeText();

	// $ANTLR start "codeText"
	// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:61:1: codeText : ( alwaysText | hb= HTML_BASE | cmt= COMMENT | qtd= QUOTED | s= ( SYMBOLS | LT | GT ) | csb= CSHARP_BASE | csf= CSHARP_FLOW | css= CSHARP_SPECIAL | cst= CSHARP_TYPES | whs= WS );
	[GrammarRule("codeText")]
	private WikiTree.codeText_return codeText()
	{
		Enter_codeText();
		EnterRule("codeText", 22);
		TraceIn("codeText", 22);
		WikiTree.codeText_return retval = new WikiTree.codeText_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = null;

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree hb=null;
		CommonTree cmt=null;
		CommonTree qtd=null;
		CommonTree s=null;
		CommonTree csb=null;
		CommonTree csf=null;
		CommonTree css=null;
		CommonTree cst=null;
		CommonTree whs=null;
		WikiTree.alwaysText_return alwaysText49 = default(WikiTree.alwaysText_return);

		CommonTree hb_tree=null;
		CommonTree cmt_tree=null;
		CommonTree qtd_tree=null;
		CommonTree s_tree=null;
		CommonTree csb_tree=null;
		CommonTree csf_tree=null;
		CommonTree css_tree=null;
		CommonTree cst_tree=null;
		CommonTree whs_tree=null;

		try { DebugEnterRule(GrammarFileName, "codeText");
		DebugLocation(61, 0);
		try
		{
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:61:13: ( alwaysText | hb= HTML_BASE | cmt= COMMENT | qtd= QUOTED | s= ( SYMBOLS | LT | GT ) | csb= CSHARP_BASE | csf= CSHARP_FLOW | css= CSHARP_SPECIAL | cst= CSHARP_TYPES | whs= WS )
			int alt30=10;
			try { DebugEnterDecision(30, decisionCanBacktrack[30]);
			switch (input.LA(1))
			{
			case NEWLINE:
			case ESCAPE:
			case STYLES:
			case COLORS:
			case NOCONTROL:
			case ATTR_TEXT:
			case ATTR_HEIGHT:
			case ATTR_WIDTH:
			case ATTR_FLOAT:
			case ASTERIX:
			case COLON:
			case UNDER:
			case WORD:
			case BREAK:
				{
				alt30=1;
				}
				break;
			case HTML_BASE:
				{
				alt30=2;
				}
				break;
			case COMMENT:
				{
				alt30=3;
				}
				break;
			case QUOTED:
				{
				alt30=4;
				}
				break;
			case LT:
			case GT:
			case SYMBOLS:
				{
				alt30=5;
				}
				break;
			case CSHARP_BASE:
				{
				alt30=6;
				}
				break;
			case CSHARP_FLOW:
				{
				alt30=7;
				}
				break;
			case CSHARP_SPECIAL:
				{
				alt30=8;
				}
				break;
			case CSHARP_TYPES:
				{
				alt30=9;
				}
				break;
			case WS:
				{
				alt30=10;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 30, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(30); }
			switch (alt30)
			{
			case 1:
				DebugEnterAlt(1);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:61:15: alwaysText
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(61, 15);
				_last = (CommonTree)input.LT(1);
				PushFollow(Follow._alwaysText_in_codeText878);
				alwaysText49=alwaysText();
				PopFollow();

				adaptor.AddChild(root_0, alwaysText49.Tree);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:62:16: hb= HTML_BASE
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(62, 18);
				_last = (CommonTree)input.LT(1);
				hb=(CommonTree)Match(input,HTML_BASE,Follow._HTML_BASE_in_codeText897); 
				hb_tree = (CommonTree)adaptor.DupNode(hb);

				adaptor.AddChild(root_0, hb_tree);

				DebugLocation(62, 33);
				 SpanClassTag(hb.Text , "html");

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:63:15: cmt= COMMENT
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(63, 18);
				_last = (CommonTree)input.LT(1);
				cmt=(CommonTree)Match(input,COMMENT,Follow._COMMENT_in_codeText921); 
				cmt_tree = (CommonTree)adaptor.DupNode(cmt);

				adaptor.AddChild(root_0, cmt_tree);

				DebugLocation(63, 33);
				 SpanClassTag(cmt.Text, "cmmnt");

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:64:15: qtd= QUOTED
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(64, 18);
				_last = (CommonTree)input.LT(1);
				qtd=(CommonTree)Match(input,QUOTED,Follow._QUOTED_in_codeText947); 
				qtd_tree = (CommonTree)adaptor.DupNode(qtd);

				adaptor.AddChild(root_0, qtd_tree);

				DebugLocation(64, 33);
				 SpanClassTag(qtd.Text, "qtd");  

				}
				break;
			case 5:
				DebugEnterAlt(5);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:65:17: s= ( SYMBOLS | LT | GT )
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(65, 18);
				_last = (CommonTree)input.LT(1);
				s=(CommonTree)input.LT(1);
				if (input.LA(1)==LT||input.LA(1)==GT||input.LA(1)==SYMBOLS)
				{
					input.Consume();

					s_tree = (CommonTree)adaptor.DupNode(s);

					adaptor.AddChild(root_0, s_tree);

					state.errorRecovery=false;
				}
				else
				{
					MismatchedSetException mse = new MismatchedSetException(null,input);
					DebugRecognitionException(mse);
					throw mse;
				}

				DebugLocation(65, 39);
				 SpanClassTag(s.Text, "smbl"); 

				}
				break;
			case 6:
				DebugEnterAlt(6);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:66:15: csb= CSHARP_BASE
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(66, 18);
				_last = (CommonTree)input.LT(1);
				csb=(CommonTree)Match(input,CSHARP_BASE,Follow._CSHARP_BASE_in_codeText1006); 
				csb_tree = (CommonTree)adaptor.DupNode(csb);

				adaptor.AddChild(root_0, csb_tree);

				DebugLocation(66, 33);
				 SpanClassTag(csb.Text, "base"); 

				}
				break;
			case 7:
				DebugEnterAlt(7);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:67:15: csf= CSHARP_FLOW
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(67, 18);
				_last = (CommonTree)input.LT(1);
				csf=(CommonTree)Match(input,CSHARP_FLOW,Follow._CSHARP_FLOW_in_codeText1028); 
				csf_tree = (CommonTree)adaptor.DupNode(csf);

				adaptor.AddChild(root_0, csf_tree);

				DebugLocation(67, 33);
				 SpanClassTag(csf.Text, "flw"); 

				}
				break;
			case 8:
				DebugEnterAlt(8);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:68:15: css= CSHARP_SPECIAL
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(68, 18);
				_last = (CommonTree)input.LT(1);
				css=(CommonTree)Match(input,CSHARP_SPECIAL,Follow._CSHARP_SPECIAL_in_codeText1050); 
				css_tree = (CommonTree)adaptor.DupNode(css);

				adaptor.AddChild(root_0, css_tree);

				DebugLocation(68, 33);
				 SpanClassTag(css.Text, "spcl"); 

				}
				break;
			case 9:
				DebugEnterAlt(9);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:69:15: cst= CSHARP_TYPES
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(69, 18);
				_last = (CommonTree)input.LT(1);
				cst=(CommonTree)Match(input,CSHARP_TYPES,Follow._CSHARP_TYPES_in_codeText1069); 
				cst_tree = (CommonTree)adaptor.DupNode(cst);

				adaptor.AddChild(root_0, cst_tree);

				DebugLocation(69, 33);
				 SpanClassTag(cst.Text, "type"); 

				}
				break;
			case 10:
				DebugEnterAlt(10);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:70:15: whs= WS
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(70, 18);
				_last = (CommonTree)input.LT(1);
				whs=(CommonTree)Match(input,WS,Follow._WS_in_codeText1090); 
				whs_tree = (CommonTree)adaptor.DupNode(whs);

				adaptor.AddChild(root_0, whs_tree);

				DebugLocation(70, 28);
				 Append(WhiteSpaceText(whs.Text)); 

				}
				break;

			}
			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("codeText", 22);
			LeaveRule("codeText", 22);
			Leave_codeText();
		}
		DebugLocation(71, 0);
		} finally { DebugExitRule(GrammarFileName, "codeText"); }
		return retval;

	}
	// $ANTLR end "codeText"

	public class alwaysText_return : TreeRuleReturnScope<CommonTree>, IAstRuleReturnScope<CommonTree>
	{
		private CommonTree _tree;
		public CommonTree Tree { get { return _tree; } set { _tree = value; } } object IAstRuleReturnScope.Tree { get { return Tree; } }
	}

	partial void Enter_alwaysText();
	partial void Leave_alwaysText();

	// $ANTLR start "alwaysText"
	// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:72:1: alwaysText : (txt= ( WORD | NOCONTROL | COLORS | STYLES | ATTR_TEXT | ATTR_HEIGHT | ATTR_WIDTH | ATTR_FLOAT | ASTERIX | UNDER | COLON ) | esc= ESCAPE | ^( BREAK ) | NEWLINE ->);
	[GrammarRule("alwaysText")]
	private WikiTree.alwaysText_return alwaysText()
	{
		Enter_alwaysText();
		EnterRule("alwaysText", 23);
		TraceIn("alwaysText", 23);
		WikiTree.alwaysText_return retval = new WikiTree.alwaysText_return();
		retval.Start = (CommonTree)input.LT(1);

		CommonTree root_0 = null;

		CommonTree _first_0 = null;
		CommonTree _last = null;

		CommonTree txt=null;
		CommonTree esc=null;
		CommonTree BREAK50=null;
		CommonTree NEWLINE51=null;

		CommonTree txt_tree=null;
		CommonTree esc_tree=null;
		CommonTree BREAK50_tree=null;
		CommonTree NEWLINE51_tree=null;
		RewriteRuleNodeStream stream_NEWLINE=new RewriteRuleNodeStream(adaptor,"token NEWLINE");

		try { DebugEnterRule(GrammarFileName, "alwaysText");
		DebugLocation(72, 0);
		try
		{
			// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:72:14: (txt= ( WORD | NOCONTROL | COLORS | STYLES | ATTR_TEXT | ATTR_HEIGHT | ATTR_WIDTH | ATTR_FLOAT | ASTERIX | UNDER | COLON ) | esc= ESCAPE | ^( BREAK ) | NEWLINE ->)
			int alt31=4;
			try { DebugEnterDecision(31, decisionCanBacktrack[31]);
			switch (input.LA(1))
			{
			case STYLES:
			case COLORS:
			case NOCONTROL:
			case ATTR_TEXT:
			case ATTR_HEIGHT:
			case ATTR_WIDTH:
			case ATTR_FLOAT:
			case ASTERIX:
			case COLON:
			case UNDER:
			case WORD:
				{
				alt31=1;
				}
				break;
			case ESCAPE:
				{
				alt31=2;
				}
				break;
			case BREAK:
				{
				alt31=3;
				}
				break;
			case NEWLINE:
				{
				alt31=4;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 31, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(31); }
			switch (alt31)
			{
			case 1:
				DebugEnterAlt(1);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:72:17: txt= ( WORD | NOCONTROL | COLORS | STYLES | ATTR_TEXT | ATTR_HEIGHT | ATTR_WIDTH | ATTR_FLOAT | ASTERIX | UNDER | COLON )
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(72, 20);
				_last = (CommonTree)input.LT(1);
				txt=(CommonTree)input.LT(1);
				if ((input.LA(1)>=STYLES && input.LA(1)<=COLORS)||input.LA(1)==NOCONTROL||(input.LA(1)>=ATTR_TEXT && input.LA(1)<=ATTR_FLOAT)||input.LA(1)==ASTERIX||input.LA(1)==COLON||input.LA(1)==UNDER||input.LA(1)==WORD)
				{
					input.Consume();

					txt_tree = (CommonTree)adaptor.DupNode(txt);

					adaptor.AddChild(root_0, txt_tree);

					state.errorRecovery=false;
				}
				else
				{
					MismatchedSetException mse = new MismatchedSetException(null,input);
					DebugRecognitionException(mse);
					throw mse;
				}

				DebugLocation(75, 20);
				 Append(txt); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:76:16: esc= ESCAPE
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(76, 19);
				_last = (CommonTree)input.LT(1);
				esc=(CommonTree)Match(input,ESCAPE,Follow._ESCAPE_in_alwaysText1205); 
				esc_tree = (CommonTree)adaptor.DupNode(esc);

				adaptor.AddChild(root_0, esc_tree);

				DebugLocation(76, 29);
				 Append(EscapedText(esc.Text)); 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:77:16: ^( BREAK )
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(77, 16);
				_last = (CommonTree)input.LT(1);
				{
				CommonTree _save_last_1 = _last;
				CommonTree _first_1 = null;
				CommonTree root_1 = (CommonTree)adaptor.Nil();DebugLocation(77, 18);
				_last = (CommonTree)input.LT(1);
				BREAK50=(CommonTree)Match(input,BREAK,Follow._BREAK_in_alwaysText1227); 
				BREAK50_tree = (CommonTree)adaptor.DupNode(BREAK50);

				root_1 = (CommonTree)adaptor.BecomeRoot(BREAK50_tree, root_1);


				DebugLocation(77, 24);
				 Append("\r\n<br />"); 

				if ( input.LA(1)==TokenTypes.Down ) {
				    Match(input, TokenTypes.Down, null); 
				    Match(input, TokenTypes.Up, null); 
				}adaptor.AddChild(root_0, root_1);_last = _save_last_1;
				}


				}
				break;
			case 4:
				DebugEnterAlt(4);
				// catarsa.com\\ProjectBase.Tools\\Wiki\\WikiTree.g:78:16: NEWLINE
				{
				DebugLocation(78, 16);
				_last = (CommonTree)input.LT(1);
				NEWLINE51=(CommonTree)Match(input,NEWLINE,Follow._NEWLINE_in_alwaysText1247);  
				stream_NEWLINE.Add(NEWLINE51);



				{
				// AST REWRITE
				// elements: 
				// token labels: 
				// rule labels: retval
				// token list labels: 
				// rule list labels: 
				// wildcard labels: 
				retval.Tree = root_0;
				RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

				root_0 = (CommonTree)adaptor.Nil();
				// 78:24: ->
				{
					DebugLocation(79, 1);
					root_0 = null;
				}

				retval.Tree = root_0;}

				}
				break;

			}
			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("alwaysText", 23);
			LeaveRule("alwaysText", 23);
			Leave_alwaysText();
		}
		DebugLocation(79, 0);
		} finally { DebugExitRule(GrammarFileName, "alwaysText"); }
		return retval;

	}
	// $ANTLR end "alwaysText"
	#endregion Rules


	#region Follow sets
	private static class Follow
	{
		public static readonly BitSet _statement_in_execute55 = new BitSet(new ulong[]{0x10001000002UL,0xC010000UL});
		public static readonly BitSet _table_in_statement65 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _block_in_statement69 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _lists_in_statement73 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _NEWLINE_in_statement77 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _block_in_element91 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _lists_in_element95 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _atom_in_element99 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _codeText_in_element103 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _tag_in_element107 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _atom_in_inlineElement115 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _codeText_in_inlineElement119 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _tag_in_inlineElement123 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _inline_in_atom137 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _anchor_in_atom141 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _name_in_atom145 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _image_in_atom149 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _TABLE_in_table165 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _tableHead_in_table170 = new BitSet(new ulong[]{0x8UL,0x500000UL});
		public static readonly BitSet _tableRow_in_table189 = new BitSet(new ulong[]{0x8UL,0x100000UL});
		public static readonly BitSet _TH_in_tableHead207 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _tableCell_in_tableHead216 = new BitSet(new ulong[]{0x8UL,0x200000UL});
		public static readonly BitSet _TROW_in_tableRow234 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _tableCell_in_tableRow246 = new BitSet(new ulong[]{0x8UL,0x200000UL});
		public static readonly BitSet _TCELL_in_tableCell263 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _inlineElement_in_tableCell274 = new BitSet(new ulong[]{0x2281E4634F000008UL,0x30EDF80UL});
		public static readonly BitSet _LIST_in_lists296 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _NEWLINE_in_lists303 = new BitSet(new ulong[]{0x1000008UL,0x10000000UL});
		public static readonly BitSet _li_in_lists307 = new BitSet(new ulong[]{0x1000008UL,0x10000000UL});
		public static readonly BitSet _NEWLINE_in_lists311 = new BitSet(new ulong[]{0x1000008UL});
		public static readonly BitSet _NUMERIC_in_lists332 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _NEWLINE_in_lists336 = new BitSet(new ulong[]{0x1000008UL,0x10000000UL});
		public static readonly BitSet _li_in_lists340 = new BitSet(new ulong[]{0x1000008UL,0x10000000UL});
		public static readonly BitSet _NEWLINE_in_lists344 = new BitSet(new ulong[]{0x1000008UL});
		public static readonly BitSet _LISTITEM_in_li362 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _inlineElement_in_li370 = new BitSet(new ulong[]{0x2281E4634F000008UL,0xF0EDF80UL});
		public static readonly BitSet _lists_in_li373 = new BitSet(new ulong[]{0x8UL,0xC000000UL});
		public static readonly BitSet _ELEMENT_in_block396 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _element_in_block401 = new BitSet(new ulong[]{0x2281E4634F000008UL,0xF0FDF80UL});
		public static readonly BitSet _INLINE_in_inline422 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _inlineElement_in_inline427 = new BitSet(new ulong[]{0x2281E4634F000008UL,0x30EDF80UL});
		public static readonly BitSet _TAG_in_tag456 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _codeText_in_tag468 = new BitSet(new ulong[]{0x2281E4634F000008UL,0xDF80UL});
		public static readonly BitSet _A_ELEMENT_in_anchor483 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _pureText_in_anchor491 = new BitSet(new ulong[]{0x2281E4634F000000UL,0x80DF80UL});
		public static readonly BitSet _attrText_in_anchor497 = new BitSet(new ulong[]{0x8UL});
		public static readonly BitSet _NAME_ELEMENT_in_name513 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _pureText_in_name516 = new BitSet(new ulong[]{0x2281E4634F000008UL,0x80DF80UL});
		public static readonly BitSet _IMG_ELEMENT_in_image536 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _pureText_in_image541 = new BitSet(new ulong[]{0x2281E4634F000008UL,0x80DF80UL});
		public static readonly BitSet _imageAttrs_in_image547 = new BitSet(new ulong[]{0x8UL,0x800000UL});
		public static readonly BitSet _ATTR_in_imageAttrs561 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _WORD_in_imageAttrs565 = new BitSet(new ulong[]{0x8UL});
		public static readonly BitSet _ATTR_in_attrText578 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _simpleText_in_attrText581 = new BitSet(new ulong[]{0x2281E4634F000008UL,0x10EDF80UL});
		public static readonly BitSet _image_in_attrText585 = new BitSet(new ulong[]{0x2281E4634F000008UL,0x10EDF80UL});
		public static readonly BitSet _alwaysText_in_simpleText600 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _set_in_simpleText618 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _WS_in_simpleText718 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _alwaysText_in_pureText737 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _set_in_pureText755 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _WS_in_pureText867 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _alwaysText_in_codeText878 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _HTML_BASE_in_codeText897 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _COMMENT_in_codeText921 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _QUOTED_in_codeText947 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _set_in_codeText976 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _CSHARP_BASE_in_codeText1006 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _CSHARP_FLOW_in_codeText1028 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _CSHARP_SPECIAL_in_codeText1050 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _CSHARP_TYPES_in_codeText1069 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _WS_in_codeText1090 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _set_in_alwaysText1111 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _ESCAPE_in_alwaysText1205 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _BREAK_in_alwaysText1227 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _NEWLINE_in_alwaysText1247 = new BitSet(new ulong[]{0x2UL});

	}
	#endregion Follow sets
}

} // namespace  ProjectBase.Tools.Wiki

