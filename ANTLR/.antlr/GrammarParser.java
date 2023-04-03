// Generated from c:\Tidligere_skrivebord\UNI_SOFTWARE\4. Semester\P4\ProjectP4\ANTLR\Grammar.g4 by ANTLR 4.9.2
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class GrammarParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.9.2", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, T__18=19, T__19=20, T__20=21, T__21=22, T__22=23, T__23=24, 
		T__24=25, T__25=26, T__26=27, T__27=28, T__28=29, T__29=30, T__30=31, 
		T__31=32, T__32=33, T__33=34, T__34=35, T__35=36, T__36=37, T__37=38, 
		T__38=39, T__39=40, T__40=41, T__41=42, T__42=43, T__43=44, T__44=45, 
		T__45=46, T__46=47, T__47=48, T__48=49, T__49=50, T__50=51, T__51=52, 
		T__52=53, T__53=54, T__54=55, T__55=56, T__56=57, T__57=58, T__58=59, 
		T__59=60, T__60=61, T__61=62, T__62=63, T__63=64, T__64=65, T__65=66, 
		T__66=67, T__67=68, T__68=69, T__69=70, T__70=71, T__71=72, T__72=73, 
		T__73=74, T__74=75, T__75=76, T__76=77, T__77=78, T__78=79, T__79=80, 
		T__80=81, T__81=82, T__82=83, T__83=84, T__84=85, T__85=86, T__86=87, 
		T__87=88, T__88=89, NUMBERDCL=90, TEXTDCL=91, BOOLEANDCL=92, ASSIGN=93, 
		Comment=94, WS=95;
	public static final int
		RULE_program = 0, RULE_declarations = 1, RULE_declaration = 2, RULE_expression = 3, 
		RULE_sum = 4, RULE_average = 5, RULE_min = 6, RULE_max = 7, RULE_count = 8, 
		RULE_controlstructure = 9, RULE_ifstmt = 10, RULE_whilestmt = 11, RULE_var = 12, 
		RULE_num = 13, RULE_string = 14, RULE_text = 15, RULE_numbers = 16, RULE_numberswithoutzero = 17, 
		RULE_operator = 18, RULE_bool = 19, RULE_upperCaseLetters = 20, RULE_lowercaseLetters = 21;
	private static String[] makeRuleNames() {
		return new String[] {
			"program", "declarations", "declaration", "expression", "sum", "average", 
			"min", "max", "count", "controlstructure", "ifstmt", "whilestmt", "var", 
			"num", "string", "text", "numbers", "numberswithoutzero", "operator", 
			"bool", "upperCaseLetters", "lowercaseLetters"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'sum'", "'('", "':'", "')'", "'average'", "'min'", "'max'", "'count'", 
			"'if'", "'then'", "'else'", "'endif'", "'while'", "'do'", "'endwhile'", 
			"'\"'", "'0'", "'1'", "'2'", "'3'", "'4'", "'5'", "'6'", "'7'", "'8'", 
			"'9'", "'+'", "'-'", "'*'", "'/'", "'<'", "'>'", "'<='", "'>='", "'!='", 
			"'false'", "'true'", "'A'", "'B'", "'C'", "'D'", "'E'", "'F'", "'G'", 
			"'H'", "'I'", "'J'", "'K'", "'L'", "'M'", "'N'", "'O'", "'P'", "'Q'", 
			"'R'", "'S'", "'T'", "'U'", "'V'", "'W'", "'X'", "'Y'", "'Z'", "'a'", 
			"'b'", "'c'", "'d'", "'e'", "'f'", "'g'", "'h'", "'i'", "'j'", "'k'", 
			"'l'", "'m'", "'n'", "'o'", "'p'", "'q'", "'r'", "'s'", "'t'", "'u'", 
			"'v'", "'w'", "'x'", "'y'", "'z'", "'number'", "'text'", "'bool'", "'='"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, null, null, null, null, null, null, 
			null, null, null, null, null, null, "NUMBERDCL", "TEXTDCL", "BOOLEANDCL", 
			"ASSIGN", "Comment", "WS"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "Grammar.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public GrammarParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	public static class ProgramContext extends ParserRuleContext {
		public DeclarationsContext declarations() {
			return getRuleContext(DeclarationsContext.class,0);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_program; }
	}

	public final ProgramContext program() throws RecognitionException {
		ProgramContext _localctx = new ProgramContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_program);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(44);
			declarations();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class DeclarationsContext extends ParserRuleContext {
		public DeclarationContext declaration() {
			return getRuleContext(DeclarationContext.class,0);
		}
		public DeclarationsContext declarations() {
			return getRuleContext(DeclarationsContext.class,0);
		}
		public DeclarationsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_declarations; }
	}

	public final DeclarationsContext declarations() throws RecognitionException {
		DeclarationsContext _localctx = new DeclarationsContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_declarations);
		try {
			setState(50);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__0:
			case T__4:
			case T__5:
			case T__6:
			case T__7:
			case T__8:
			case T__12:
			case T__37:
			case T__38:
			case T__39:
			case T__40:
			case T__41:
			case T__42:
			case T__43:
			case T__44:
			case T__45:
			case T__46:
			case T__47:
			case T__48:
			case T__49:
			case T__50:
			case T__51:
			case T__52:
			case T__53:
			case T__54:
			case T__55:
			case T__56:
			case T__57:
			case T__58:
			case T__59:
			case T__60:
			case T__61:
			case T__62:
			case NUMBERDCL:
			case TEXTDCL:
			case BOOLEANDCL:
				enterOuterAlt(_localctx, 1);
				{
				setState(46);
				declaration();
				setState(47);
				declarations();
				}
				break;
			case EOF:
				enterOuterAlt(_localctx, 2);
				{
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class DeclarationContext extends ParserRuleContext {
		public ControlstructureContext controlstructure() {
			return getRuleContext(ControlstructureContext.class,0);
		}
		public TerminalNode NUMBERDCL() { return getToken(GrammarParser.NUMBERDCL, 0); }
		public VarContext var() {
			return getRuleContext(VarContext.class,0);
		}
		public TerminalNode ASSIGN() { return getToken(GrammarParser.ASSIGN, 0); }
		public NumContext num() {
			return getRuleContext(NumContext.class,0);
		}
		public TerminalNode TEXTDCL() { return getToken(GrammarParser.TEXTDCL, 0); }
		public StringContext string() {
			return getRuleContext(StringContext.class,0);
		}
		public TerminalNode BOOLEANDCL() { return getToken(GrammarParser.BOOLEANDCL, 0); }
		public BoolContext bool() {
			return getRuleContext(BoolContext.class,0);
		}
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public SumContext sum() {
			return getRuleContext(SumContext.class,0);
		}
		public AverageContext average() {
			return getRuleContext(AverageContext.class,0);
		}
		public MinContext min() {
			return getRuleContext(MinContext.class,0);
		}
		public MaxContext max() {
			return getRuleContext(MaxContext.class,0);
		}
		public CountContext count() {
			return getRuleContext(CountContext.class,0);
		}
		public DeclarationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_declaration; }
	}

	public final DeclarationContext declaration() throws RecognitionException {
		DeclarationContext _localctx = new DeclarationContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_declaration);
		try {
			setState(74);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__8:
			case T__12:
				enterOuterAlt(_localctx, 1);
				{
				setState(52);
				controlstructure();
				}
				break;
			case NUMBERDCL:
				enterOuterAlt(_localctx, 2);
				{
				setState(53);
				match(NUMBERDCL);
				setState(54);
				var();
				setState(55);
				match(ASSIGN);
				setState(56);
				num();
				}
				break;
			case TEXTDCL:
				enterOuterAlt(_localctx, 3);
				{
				setState(58);
				match(TEXTDCL);
				setState(59);
				var();
				setState(60);
				match(ASSIGN);
				setState(61);
				string();
				}
				break;
			case BOOLEANDCL:
				enterOuterAlt(_localctx, 4);
				{
				setState(63);
				match(BOOLEANDCL);
				setState(64);
				var();
				setState(65);
				match(ASSIGN);
				setState(66);
				bool();
				}
				break;
			case T__37:
			case T__38:
			case T__39:
			case T__40:
			case T__41:
			case T__42:
			case T__43:
			case T__44:
			case T__45:
			case T__46:
			case T__47:
			case T__48:
			case T__49:
			case T__50:
			case T__51:
			case T__52:
			case T__53:
			case T__54:
			case T__55:
			case T__56:
			case T__57:
			case T__58:
			case T__59:
			case T__60:
			case T__61:
			case T__62:
				enterOuterAlt(_localctx, 5);
				{
				setState(68);
				expression(0);
				}
				break;
			case T__0:
				enterOuterAlt(_localctx, 6);
				{
				setState(69);
				sum();
				}
				break;
			case T__4:
				enterOuterAlt(_localctx, 7);
				{
				setState(70);
				average();
				}
				break;
			case T__5:
				enterOuterAlt(_localctx, 8);
				{
				setState(71);
				min();
				}
				break;
			case T__6:
				enterOuterAlt(_localctx, 9);
				{
				setState(72);
				max();
				}
				break;
			case T__7:
				enterOuterAlt(_localctx, 10);
				{
				setState(73);
				count();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ExpressionContext extends ParserRuleContext {
		public VarContext var() {
			return getRuleContext(VarContext.class,0);
		}
		public List<ExpressionContext> expression() {
			return getRuleContexts(ExpressionContext.class);
		}
		public ExpressionContext expression(int i) {
			return getRuleContext(ExpressionContext.class,i);
		}
		public OperatorContext operator() {
			return getRuleContext(OperatorContext.class,0);
		}
		public ExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expression; }
	}

	public final ExpressionContext expression() throws RecognitionException {
		return expression(0);
	}

	private ExpressionContext expression(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		ExpressionContext _localctx = new ExpressionContext(_ctx, _parentState);
		ExpressionContext _prevctx = _localctx;
		int _startState = 6;
		enterRecursionRule(_localctx, 6, RULE_expression, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			{
			setState(77);
			var();
			}
			_ctx.stop = _input.LT(-1);
			setState(85);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,2,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new ExpressionContext(_parentctx, _parentState);
					pushNewRecursionContext(_localctx, _startState, RULE_expression);
					setState(79);
					if (!(precpred(_ctx, 1))) throw new FailedPredicateException(this, "precpred(_ctx, 1)");
					setState(80);
					operator();
					setState(81);
					expression(2);
					}
					} 
				}
				setState(87);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,2,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public static class SumContext extends ParserRuleContext {
		public List<VarContext> var() {
			return getRuleContexts(VarContext.class);
		}
		public VarContext var(int i) {
			return getRuleContext(VarContext.class,i);
		}
		public SumContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_sum; }
	}

	public final SumContext sum() throws RecognitionException {
		SumContext _localctx = new SumContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_sum);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(88);
			match(T__0);
			setState(89);
			match(T__1);
			setState(90);
			var();
			setState(91);
			match(T__2);
			setState(92);
			var();
			setState(93);
			match(T__3);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class AverageContext extends ParserRuleContext {
		public List<VarContext> var() {
			return getRuleContexts(VarContext.class);
		}
		public VarContext var(int i) {
			return getRuleContext(VarContext.class,i);
		}
		public AverageContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_average; }
	}

	public final AverageContext average() throws RecognitionException {
		AverageContext _localctx = new AverageContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_average);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(95);
			match(T__4);
			setState(96);
			match(T__1);
			setState(97);
			var();
			setState(98);
			match(T__2);
			setState(99);
			var();
			setState(100);
			match(T__3);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class MinContext extends ParserRuleContext {
		public List<VarContext> var() {
			return getRuleContexts(VarContext.class);
		}
		public VarContext var(int i) {
			return getRuleContext(VarContext.class,i);
		}
		public MinContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_min; }
	}

	public final MinContext min() throws RecognitionException {
		MinContext _localctx = new MinContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_min);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(102);
			match(T__5);
			setState(103);
			match(T__1);
			setState(104);
			var();
			setState(105);
			match(T__2);
			setState(106);
			var();
			setState(107);
			match(T__3);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class MaxContext extends ParserRuleContext {
		public List<VarContext> var() {
			return getRuleContexts(VarContext.class);
		}
		public VarContext var(int i) {
			return getRuleContext(VarContext.class,i);
		}
		public MaxContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_max; }
	}

	public final MaxContext max() throws RecognitionException {
		MaxContext _localctx = new MaxContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_max);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(109);
			match(T__6);
			setState(110);
			match(T__1);
			setState(111);
			var();
			setState(112);
			match(T__2);
			setState(113);
			var();
			setState(114);
			match(T__3);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class CountContext extends ParserRuleContext {
		public List<VarContext> var() {
			return getRuleContexts(VarContext.class);
		}
		public VarContext var(int i) {
			return getRuleContext(VarContext.class,i);
		}
		public CountContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_count; }
	}

	public final CountContext count() throws RecognitionException {
		CountContext _localctx = new CountContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_count);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(116);
			match(T__7);
			setState(117);
			match(T__1);
			setState(118);
			var();
			setState(119);
			match(T__2);
			setState(120);
			var();
			setState(121);
			match(T__3);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ControlstructureContext extends ParserRuleContext {
		public IfstmtContext ifstmt() {
			return getRuleContext(IfstmtContext.class,0);
		}
		public WhilestmtContext whilestmt() {
			return getRuleContext(WhilestmtContext.class,0);
		}
		public ControlstructureContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_controlstructure; }
	}

	public final ControlstructureContext controlstructure() throws RecognitionException {
		ControlstructureContext _localctx = new ControlstructureContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_controlstructure);
		try {
			setState(125);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__8:
				enterOuterAlt(_localctx, 1);
				{
				setState(123);
				ifstmt();
				}
				break;
			case T__12:
				enterOuterAlt(_localctx, 2);
				{
				setState(124);
				whilestmt();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class IfstmtContext extends ParserRuleContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public List<DeclarationContext> declaration() {
			return getRuleContexts(DeclarationContext.class);
		}
		public DeclarationContext declaration(int i) {
			return getRuleContext(DeclarationContext.class,i);
		}
		public IfstmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_ifstmt; }
	}

	public final IfstmtContext ifstmt() throws RecognitionException {
		IfstmtContext _localctx = new IfstmtContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_ifstmt);
		try {
			setState(141);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,4,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(127);
				match(T__8);
				setState(128);
				expression(0);
				setState(129);
				match(T__9);
				setState(130);
				declaration();
				setState(131);
				match(T__10);
				setState(132);
				declaration();
				setState(133);
				match(T__11);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(135);
				match(T__8);
				setState(136);
				expression(0);
				setState(137);
				match(T__9);
				setState(138);
				declaration();
				setState(139);
				match(T__11);
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class WhilestmtContext extends ParserRuleContext {
		public ExpressionContext expression() {
			return getRuleContext(ExpressionContext.class,0);
		}
		public DeclarationContext declaration() {
			return getRuleContext(DeclarationContext.class,0);
		}
		public WhilestmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_whilestmt; }
	}

	public final WhilestmtContext whilestmt() throws RecognitionException {
		WhilestmtContext _localctx = new WhilestmtContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_whilestmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(143);
			match(T__12);
			setState(144);
			expression(0);
			setState(145);
			match(T__13);
			setState(146);
			declaration();
			setState(147);
			match(T__14);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class VarContext extends ParserRuleContext {
		public UpperCaseLettersContext upperCaseLetters() {
			return getRuleContext(UpperCaseLettersContext.class,0);
		}
		public NumberswithoutzeroContext numberswithoutzero() {
			return getRuleContext(NumberswithoutzeroContext.class,0);
		}
		public NumContext num() {
			return getRuleContext(NumContext.class,0);
		}
		public VarContext var() {
			return getRuleContext(VarContext.class,0);
		}
		public VarContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_var; }
	}

	public final VarContext var() throws RecognitionException {
		VarContext _localctx = new VarContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_var);
		try {
			setState(159);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,5,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(149);
				upperCaseLetters();
				setState(150);
				numberswithoutzero();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(152);
				upperCaseLetters();
				setState(153);
				numberswithoutzero();
				setState(154);
				num();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(156);
				upperCaseLetters();
				setState(157);
				var();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class NumContext extends ParserRuleContext {
		public NumbersContext numbers() {
			return getRuleContext(NumbersContext.class,0);
		}
		public NumContext num() {
			return getRuleContext(NumContext.class,0);
		}
		public NumContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_num; }
	}

	public final NumContext num() throws RecognitionException {
		NumContext _localctx = new NumContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_num);
		try {
			setState(165);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,6,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(161);
				numbers();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(162);
				numbers();
				setState(163);
				num();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StringContext extends ParserRuleContext {
		public TextContext text() {
			return getRuleContext(TextContext.class,0);
		}
		public StringContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_string; }
	}

	public final StringContext string() throws RecognitionException {
		StringContext _localctx = new StringContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_string);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(167);
			match(T__15);
			setState(168);
			text();
			setState(169);
			match(T__15);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class TextContext extends ParserRuleContext {
		public List<UpperCaseLettersContext> upperCaseLetters() {
			return getRuleContexts(UpperCaseLettersContext.class);
		}
		public UpperCaseLettersContext upperCaseLetters(int i) {
			return getRuleContext(UpperCaseLettersContext.class,i);
		}
		public List<LowercaseLettersContext> lowercaseLetters() {
			return getRuleContexts(LowercaseLettersContext.class);
		}
		public LowercaseLettersContext lowercaseLetters(int i) {
			return getRuleContext(LowercaseLettersContext.class,i);
		}
		public List<NumContext> num() {
			return getRuleContexts(NumContext.class);
		}
		public NumContext num(int i) {
			return getRuleContext(NumContext.class,i);
		}
		public TextContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_text; }
	}

	public final TextContext text() throws RecognitionException {
		TextContext _localctx = new TextContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_text);
		int _la;
		try {
			int _alt;
			setState(185);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,10,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(176);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__16) | (1L << T__17) | (1L << T__18) | (1L << T__19) | (1L << T__20) | (1L << T__21) | (1L << T__22) | (1L << T__23) | (1L << T__24) | (1L << T__25) | (1L << T__37) | (1L << T__38) | (1L << T__39) | (1L << T__40) | (1L << T__41) | (1L << T__42) | (1L << T__43) | (1L << T__44) | (1L << T__45) | (1L << T__46) | (1L << T__47) | (1L << T__48) | (1L << T__49) | (1L << T__50) | (1L << T__51) | (1L << T__52) | (1L << T__53) | (1L << T__54) | (1L << T__55) | (1L << T__56) | (1L << T__57) | (1L << T__58) | (1L << T__59) | (1L << T__60) | (1L << T__61) | (1L << T__62))) != 0) || ((((_la - 64)) & ~0x3f) == 0 && ((1L << (_la - 64)) & ((1L << (T__63 - 64)) | (1L << (T__64 - 64)) | (1L << (T__65 - 64)) | (1L << (T__66 - 64)) | (1L << (T__67 - 64)) | (1L << (T__68 - 64)) | (1L << (T__69 - 64)) | (1L << (T__70 - 64)) | (1L << (T__71 - 64)) | (1L << (T__72 - 64)) | (1L << (T__73 - 64)) | (1L << (T__74 - 64)) | (1L << (T__75 - 64)) | (1L << (T__76 - 64)) | (1L << (T__77 - 64)) | (1L << (T__78 - 64)) | (1L << (T__79 - 64)) | (1L << (T__80 - 64)) | (1L << (T__81 - 64)) | (1L << (T__82 - 64)) | (1L << (T__83 - 64)) | (1L << (T__84 - 64)) | (1L << (T__85 - 64)) | (1L << (T__86 - 64)) | (1L << (T__87 - 64)) | (1L << (T__88 - 64)))) != 0)) {
					{
					setState(174);
					_errHandler.sync(this);
					switch (_input.LA(1)) {
					case T__37:
					case T__38:
					case T__39:
					case T__40:
					case T__41:
					case T__42:
					case T__43:
					case T__44:
					case T__45:
					case T__46:
					case T__47:
					case T__48:
					case T__49:
					case T__50:
					case T__51:
					case T__52:
					case T__53:
					case T__54:
					case T__55:
					case T__56:
					case T__57:
					case T__58:
					case T__59:
					case T__60:
					case T__61:
					case T__62:
						{
						setState(171);
						upperCaseLetters();
						}
						break;
					case T__63:
					case T__64:
					case T__65:
					case T__66:
					case T__67:
					case T__68:
					case T__69:
					case T__70:
					case T__71:
					case T__72:
					case T__73:
					case T__74:
					case T__75:
					case T__76:
					case T__77:
					case T__78:
					case T__79:
					case T__80:
					case T__81:
					case T__82:
					case T__83:
					case T__84:
					case T__85:
					case T__86:
					case T__87:
					case T__88:
						{
						setState(172);
						lowercaseLetters();
						}
						break;
					case T__16:
					case T__17:
					case T__18:
					case T__19:
					case T__20:
					case T__21:
					case T__22:
					case T__23:
					case T__24:
					case T__25:
						{
						setState(173);
						num();
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					}
					setState(178);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(182);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,9,_ctx);
				while ( _alt!=1 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
					if ( _alt==1+1 ) {
						{
						{
						setState(179);
						matchWildcard();
						}
						} 
					}
					setState(184);
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,9,_ctx);
				}
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class NumbersContext extends ParserRuleContext {
		public NumbersContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_numbers; }
	}

	public final NumbersContext numbers() throws RecognitionException {
		NumbersContext _localctx = new NumbersContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_numbers);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(187);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__16) | (1L << T__17) | (1L << T__18) | (1L << T__19) | (1L << T__20) | (1L << T__21) | (1L << T__22) | (1L << T__23) | (1L << T__24) | (1L << T__25))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class NumberswithoutzeroContext extends ParserRuleContext {
		public NumberswithoutzeroContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_numberswithoutzero; }
	}

	public final NumberswithoutzeroContext numberswithoutzero() throws RecognitionException {
		NumberswithoutzeroContext _localctx = new NumberswithoutzeroContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_numberswithoutzero);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(189);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__17) | (1L << T__18) | (1L << T__19) | (1L << T__20) | (1L << T__21) | (1L << T__22) | (1L << T__23) | (1L << T__24) | (1L << T__25))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class OperatorContext extends ParserRuleContext {
		public TerminalNode ASSIGN() { return getToken(GrammarParser.ASSIGN, 0); }
		public OperatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_operator; }
	}

	public final OperatorContext operator() throws RecognitionException {
		OperatorContext _localctx = new OperatorContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_operator);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(191);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__26) | (1L << T__27) | (1L << T__28) | (1L << T__29) | (1L << T__30) | (1L << T__31) | (1L << T__32) | (1L << T__33) | (1L << T__34))) != 0) || _la==ASSIGN) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class BoolContext extends ParserRuleContext {
		public BoolContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_bool; }
	}

	public final BoolContext bool() throws RecognitionException {
		BoolContext _localctx = new BoolContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_bool);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(193);
			_la = _input.LA(1);
			if ( !(_la==T__35 || _la==T__36) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class UpperCaseLettersContext extends ParserRuleContext {
		public UpperCaseLettersContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_upperCaseLetters; }
	}

	public final UpperCaseLettersContext upperCaseLetters() throws RecognitionException {
		UpperCaseLettersContext _localctx = new UpperCaseLettersContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_upperCaseLetters);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(195);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__37) | (1L << T__38) | (1L << T__39) | (1L << T__40) | (1L << T__41) | (1L << T__42) | (1L << T__43) | (1L << T__44) | (1L << T__45) | (1L << T__46) | (1L << T__47) | (1L << T__48) | (1L << T__49) | (1L << T__50) | (1L << T__51) | (1L << T__52) | (1L << T__53) | (1L << T__54) | (1L << T__55) | (1L << T__56) | (1L << T__57) | (1L << T__58) | (1L << T__59) | (1L << T__60) | (1L << T__61) | (1L << T__62))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class LowercaseLettersContext extends ParserRuleContext {
		public LowercaseLettersContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_lowercaseLetters; }
	}

	public final LowercaseLettersContext lowercaseLetters() throws RecognitionException {
		LowercaseLettersContext _localctx = new LowercaseLettersContext(_ctx, getState());
		enterRule(_localctx, 42, RULE_lowercaseLetters);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(197);
			_la = _input.LA(1);
			if ( !(((((_la - 64)) & ~0x3f) == 0 && ((1L << (_la - 64)) & ((1L << (T__63 - 64)) | (1L << (T__64 - 64)) | (1L << (T__65 - 64)) | (1L << (T__66 - 64)) | (1L << (T__67 - 64)) | (1L << (T__68 - 64)) | (1L << (T__69 - 64)) | (1L << (T__70 - 64)) | (1L << (T__71 - 64)) | (1L << (T__72 - 64)) | (1L << (T__73 - 64)) | (1L << (T__74 - 64)) | (1L << (T__75 - 64)) | (1L << (T__76 - 64)) | (1L << (T__77 - 64)) | (1L << (T__78 - 64)) | (1L << (T__79 - 64)) | (1L << (T__80 - 64)) | (1L << (T__81 - 64)) | (1L << (T__82 - 64)) | (1L << (T__83 - 64)) | (1L << (T__84 - 64)) | (1L << (T__85 - 64)) | (1L << (T__86 - 64)) | (1L << (T__87 - 64)) | (1L << (T__88 - 64)))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 3:
			return expression_sempred((ExpressionContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean expression_sempred(ExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 1);
		}
		return true;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3a\u00ca\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\3\2\3\2\3\3\3\3\3\3"+
		"\3\3\5\3\65\n\3\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3"+
		"\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\5\4M\n\4\3\5\3\5\3\5\3\5\3\5\3\5\3"+
		"\5\7\5V\n\5\f\5\16\5Y\13\5\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\7\3\7\3\7\3\7"+
		"\3\7\3\7\3\7\3\b\3\b\3\b\3\b\3\b\3\b\3\b\3\t\3\t\3\t\3\t\3\t\3\t\3\t\3"+
		"\n\3\n\3\n\3\n\3\n\3\n\3\n\3\13\3\13\5\13\u0080\n\13\3\f\3\f\3\f\3\f\3"+
		"\f\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\f\3\f\5\f\u0090\n\f\3\r\3\r\3\r\3\r\3"+
		"\r\3\r\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\3\16\5\16\u00a2\n"+
		"\16\3\17\3\17\3\17\3\17\5\17\u00a8\n\17\3\20\3\20\3\20\3\20\3\21\3\21"+
		"\3\21\7\21\u00b1\n\21\f\21\16\21\u00b4\13\21\3\21\7\21\u00b7\n\21\f\21"+
		"\16\21\u00ba\13\21\5\21\u00bc\n\21\3\22\3\22\3\23\3\23\3\24\3\24\3\25"+
		"\3\25\3\26\3\26\3\27\3\27\3\27\3\u00b8\3\b\30\2\4\6\b\n\f\16\20\22\24"+
		"\26\30\32\34\36 \"$&(*,\2\b\3\2\23\34\3\2\24\34\4\2\35%__\3\2&\'\3\2("+
		"A\3\2B[\2\u00c8\2.\3\2\2\2\4\64\3\2\2\2\6L\3\2\2\2\bN\3\2\2\2\nZ\3\2\2"+
		"\2\fa\3\2\2\2\16h\3\2\2\2\20o\3\2\2\2\22v\3\2\2\2\24\177\3\2\2\2\26\u008f"+
		"\3\2\2\2\30\u0091\3\2\2\2\32\u00a1\3\2\2\2\34\u00a7\3\2\2\2\36\u00a9\3"+
		"\2\2\2 \u00bb\3\2\2\2\"\u00bd\3\2\2\2$\u00bf\3\2\2\2&\u00c1\3\2\2\2(\u00c3"+
		"\3\2\2\2*\u00c5\3\2\2\2,\u00c7\3\2\2\2./\5\4\3\2/\3\3\2\2\2\60\61\5\6"+
		"\4\2\61\62\5\4\3\2\62\65\3\2\2\2\63\65\3\2\2\2\64\60\3\2\2\2\64\63\3\2"+
		"\2\2\65\5\3\2\2\2\66M\5\24\13\2\678\7\\\2\289\5\32\16\29:\7_\2\2:;\5\34"+
		"\17\2;M\3\2\2\2<=\7]\2\2=>\5\32\16\2>?\7_\2\2?@\5\36\20\2@M\3\2\2\2AB"+
		"\7^\2\2BC\5\32\16\2CD\7_\2\2DE\5(\25\2EM\3\2\2\2FM\5\b\5\2GM\5\n\6\2H"+
		"M\5\f\7\2IM\5\16\b\2JM\5\20\t\2KM\5\22\n\2L\66\3\2\2\2L\67\3\2\2\2L<\3"+
		"\2\2\2LA\3\2\2\2LF\3\2\2\2LG\3\2\2\2LH\3\2\2\2LI\3\2\2\2LJ\3\2\2\2LK\3"+
		"\2\2\2M\7\3\2\2\2NO\b\5\1\2OP\5\32\16\2PW\3\2\2\2QR\f\3\2\2RS\5&\24\2"+
		"ST\5\b\5\4TV\3\2\2\2UQ\3\2\2\2VY\3\2\2\2WU\3\2\2\2WX\3\2\2\2X\t\3\2\2"+
		"\2YW\3\2\2\2Z[\7\3\2\2[\\\7\4\2\2\\]\5\32\16\2]^\7\5\2\2^_\5\32\16\2_"+
		"`\7\6\2\2`\13\3\2\2\2ab\7\7\2\2bc\7\4\2\2cd\5\32\16\2de\7\5\2\2ef\5\32"+
		"\16\2fg\7\6\2\2g\r\3\2\2\2hi\7\b\2\2ij\7\4\2\2jk\5\32\16\2kl\7\5\2\2l"+
		"m\5\32\16\2mn\7\6\2\2n\17\3\2\2\2op\7\t\2\2pq\7\4\2\2qr\5\32\16\2rs\7"+
		"\5\2\2st\5\32\16\2tu\7\6\2\2u\21\3\2\2\2vw\7\n\2\2wx\7\4\2\2xy\5\32\16"+
		"\2yz\7\5\2\2z{\5\32\16\2{|\7\6\2\2|\23\3\2\2\2}\u0080\5\26\f\2~\u0080"+
		"\5\30\r\2\177}\3\2\2\2\177~\3\2\2\2\u0080\25\3\2\2\2\u0081\u0082\7\13"+
		"\2\2\u0082\u0083\5\b\5\2\u0083\u0084\7\f\2\2\u0084\u0085\5\6\4\2\u0085"+
		"\u0086\7\r\2\2\u0086\u0087\5\6\4\2\u0087\u0088\7\16\2\2\u0088\u0090\3"+
		"\2\2\2\u0089\u008a\7\13\2\2\u008a\u008b\5\b\5\2\u008b\u008c\7\f\2\2\u008c"+
		"\u008d\5\6\4\2\u008d\u008e\7\16\2\2\u008e\u0090\3\2\2\2\u008f\u0081\3"+
		"\2\2\2\u008f\u0089\3\2\2\2\u0090\27\3\2\2\2\u0091\u0092\7\17\2\2\u0092"+
		"\u0093\5\b\5\2\u0093\u0094\7\20\2\2\u0094\u0095\5\6\4\2\u0095\u0096\7"+
		"\21\2\2\u0096\31\3\2\2\2\u0097\u0098\5*\26\2\u0098\u0099\5$\23\2\u0099"+
		"\u00a2\3\2\2\2\u009a\u009b\5*\26\2\u009b\u009c\5$\23\2\u009c\u009d\5\34"+
		"\17\2\u009d\u00a2\3\2\2\2\u009e\u009f\5*\26\2\u009f\u00a0\5\32\16\2\u00a0"+
		"\u00a2\3\2\2\2\u00a1\u0097\3\2\2\2\u00a1\u009a\3\2\2\2\u00a1\u009e\3\2"+
		"\2\2\u00a2\33\3\2\2\2\u00a3\u00a8\5\"\22\2\u00a4\u00a5\5\"\22\2\u00a5"+
		"\u00a6\5\34\17\2\u00a6\u00a8\3\2\2\2\u00a7\u00a3\3\2\2\2\u00a7\u00a4\3"+
		"\2\2\2\u00a8\35\3\2\2\2\u00a9\u00aa\7\22\2\2\u00aa\u00ab\5 \21\2\u00ab"+
		"\u00ac\7\22\2\2\u00ac\37\3\2\2\2\u00ad\u00b1\5*\26\2\u00ae\u00b1\5,\27"+
		"\2\u00af\u00b1\5\34\17\2\u00b0\u00ad\3\2\2\2\u00b0\u00ae\3\2\2\2\u00b0"+
		"\u00af\3\2\2\2\u00b1\u00b4\3\2\2\2\u00b2\u00b0\3\2\2\2\u00b2\u00b3\3\2"+
		"\2\2\u00b3\u00bc\3\2\2\2\u00b4\u00b2\3\2\2\2\u00b5\u00b7\13\2\2\2\u00b6"+
		"\u00b5\3\2\2\2\u00b7\u00ba\3\2\2\2\u00b8\u00b9\3\2\2\2\u00b8\u00b6\3\2"+
		"\2\2\u00b9\u00bc\3\2\2\2\u00ba\u00b8\3\2\2\2\u00bb\u00b2\3\2\2\2\u00bb"+
		"\u00b8\3\2\2\2\u00bc!\3\2\2\2\u00bd\u00be\t\2\2\2\u00be#\3\2\2\2\u00bf"+
		"\u00c0\t\3\2\2\u00c0%\3\2\2\2\u00c1\u00c2\t\4\2\2\u00c2\'\3\2\2\2\u00c3"+
		"\u00c4\t\5\2\2\u00c4)\3\2\2\2\u00c5\u00c6\t\6\2\2\u00c6+\3\2\2\2\u00c7"+
		"\u00c8\t\7\2\2\u00c8-\3\2\2\2\r\64LW\177\u008f\u00a1\u00a7\u00b0\u00b2"+
		"\u00b8\u00bb";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}