//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.12.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from GLexer.g4 by ANTLR 4.12.0

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.12.0")]
[System.CLSCompliant(false)]
public partial class GLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		NUMBERDCL=1, BOOLDCL=2, TEXTDCL=3, STRING=4, INTEGER=5, FLOAT=6, BOOL=7, 
		NULL=8, IF=9, THEN=10, ELSE=11, ENDIF=12, WHILE=13, ENDWHILE=14, DO=15, 
		AND=16, SUM=17, AVERAGE=18, MIN=19, MAX=20, SORT=21, COUNT=22, OR=23, 
		ASSIGN=24, LESSTHAN=25, GREATERTHAN=26, COMPEQUAL=27, LESSEQUAL=28, GREATEREQUAL=29, 
		NOTEQUAL=30, PLUS=31, MINUS=32, MULTIPLICATION=33, DIVISON=34, MODULO=35, 
		LPARENTHESIS=36, RPARENTHESIS=37, LSQUAREP=38, RSQUAREP=39, LBRACKET=40, 
		RBRACKET=41, COLON=42, COMMA=43, COMMENT=44, VAR=45, WS=46;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"NUMBERDCL", "BOOLDCL", "TEXTDCL", "STRING", "INTEGER", "FLOAT", "BOOL", 
		"NULL", "IF", "THEN", "ELSE", "ENDIF", "WHILE", "ENDWHILE", "DO", "AND", 
		"SUM", "AVERAGE", "MIN", "MAX", "SORT", "COUNT", "OR", "ASSIGN", "LESSTHAN", 
		"GREATERTHAN", "COMPEQUAL", "LESSEQUAL", "GREATEREQUAL", "NOTEQUAL", "PLUS", 
		"MINUS", "MULTIPLICATION", "DIVISON", "MODULO", "LPARENTHESIS", "RPARENTHESIS", 
		"LSQUAREP", "RSQUAREP", "LBRACKET", "RBRACKET", "COLON", "COMMA", "COMMENT", 
		"VAR", "WS"
	};


	public GLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public GLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'number'", "'bool'", "'text'", null, null, null, null, "'null'", 
		"'if'", "'then'", "'else'", "'endif'", "'while'", "'endwhile'", "'do'", 
		"'AND'", "'SUM'", "'AVERAGE'", "'MIN'", "'MAX'", "'SORT'", "'COUNT'", 
		"'OR'", "'='", "'<'", "'>'", "'=='", "'<='", "'>='", "'!='", "'+'", "'-'", 
		"'*'", "'/'", "'%'", "'('", "')'", "'['", "']'", "'{'", "'}'", "':'", 
		"','"
	};
	private static readonly string[] _SymbolicNames = {
		null, "NUMBERDCL", "BOOLDCL", "TEXTDCL", "STRING", "INTEGER", "FLOAT", 
		"BOOL", "NULL", "IF", "THEN", "ELSE", "ENDIF", "WHILE", "ENDWHILE", "DO", 
		"AND", "SUM", "AVERAGE", "MIN", "MAX", "SORT", "COUNT", "OR", "ASSIGN", 
		"LESSTHAN", "GREATERTHAN", "COMPEQUAL", "LESSEQUAL", "GREATEREQUAL", "NOTEQUAL", 
		"PLUS", "MINUS", "MULTIPLICATION", "DIVISON", "MODULO", "LPARENTHESIS", 
		"RPARENTHESIS", "LSQUAREP", "RSQUAREP", "LBRACKET", "RBRACKET", "COLON", 
		"COMMA", "COMMENT", "VAR", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "GLexer.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static GLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,46,301,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,2,27,7,27,2,28,
		7,28,2,29,7,29,2,30,7,30,2,31,7,31,2,32,7,32,2,33,7,33,2,34,7,34,2,35,
		7,35,2,36,7,36,2,37,7,37,2,38,7,38,2,39,7,39,2,40,7,40,2,41,7,41,2,42,
		7,42,2,43,7,43,2,44,7,44,2,45,7,45,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,1,1,1,
		1,1,1,1,1,1,1,2,1,2,1,2,1,2,1,2,1,3,1,3,5,3,113,8,3,10,3,12,3,116,9,3,
		1,3,1,3,1,4,4,4,121,8,4,11,4,12,4,122,1,5,4,5,126,8,5,11,5,12,5,127,1,
		5,1,5,4,5,132,8,5,11,5,12,5,133,1,6,1,6,1,6,1,6,1,6,1,6,1,6,1,6,1,6,3,
		6,145,8,6,1,7,1,7,1,7,1,7,1,7,1,8,1,8,1,8,1,9,1,9,1,9,1,9,1,9,1,10,1,10,
		1,10,1,10,1,10,1,11,1,11,1,11,1,11,1,11,1,11,1,12,1,12,1,12,1,12,1,12,
		1,12,1,13,1,13,1,13,1,13,1,13,1,13,1,13,1,13,1,13,1,14,1,14,1,14,1,15,
		1,15,1,15,1,15,1,16,1,16,1,16,1,16,1,17,1,17,1,17,1,17,1,17,1,17,1,17,
		1,17,1,18,1,18,1,18,1,18,1,19,1,19,1,19,1,19,1,20,1,20,1,20,1,20,1,20,
		1,21,1,21,1,21,1,21,1,21,1,21,1,22,1,22,1,22,1,23,1,23,1,24,1,24,1,25,
		1,25,1,26,1,26,1,26,1,27,1,27,1,27,1,28,1,28,1,28,1,29,1,29,1,29,1,30,
		1,30,1,31,1,31,1,32,1,32,1,33,1,33,1,34,1,34,1,35,1,35,1,36,1,36,1,37,
		1,37,1,38,1,38,1,39,1,39,1,40,1,40,1,41,1,41,1,42,1,42,1,43,1,43,1,43,
		1,43,5,43,275,8,43,10,43,12,43,278,9,43,1,43,1,43,1,43,1,44,4,44,284,8,
		44,11,44,12,44,285,1,44,1,44,5,44,290,8,44,10,44,12,44,293,9,44,1,45,4,
		45,296,8,45,11,45,12,45,297,1,45,1,45,2,114,276,0,46,1,1,3,2,5,3,7,4,9,
		5,11,6,13,7,15,8,17,9,19,10,21,11,23,12,25,13,27,14,29,15,31,16,33,17,
		35,18,37,19,39,20,41,21,43,22,45,23,47,24,49,25,51,26,53,27,55,28,57,29,
		59,30,61,31,63,32,65,33,67,34,69,35,71,36,73,37,75,38,77,39,79,40,81,41,
		83,42,85,43,87,44,89,45,91,46,1,0,4,1,0,48,57,1,0,65,90,1,0,49,57,3,0,
		9,10,13,13,32,32,309,0,1,1,0,0,0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,
		9,1,0,0,0,0,11,1,0,0,0,0,13,1,0,0,0,0,15,1,0,0,0,0,17,1,0,0,0,0,19,1,0,
		0,0,0,21,1,0,0,0,0,23,1,0,0,0,0,25,1,0,0,0,0,27,1,0,0,0,0,29,1,0,0,0,0,
		31,1,0,0,0,0,33,1,0,0,0,0,35,1,0,0,0,0,37,1,0,0,0,0,39,1,0,0,0,0,41,1,
		0,0,0,0,43,1,0,0,0,0,45,1,0,0,0,0,47,1,0,0,0,0,49,1,0,0,0,0,51,1,0,0,0,
		0,53,1,0,0,0,0,55,1,0,0,0,0,57,1,0,0,0,0,59,1,0,0,0,0,61,1,0,0,0,0,63,
		1,0,0,0,0,65,1,0,0,0,0,67,1,0,0,0,0,69,1,0,0,0,0,71,1,0,0,0,0,73,1,0,0,
		0,0,75,1,0,0,0,0,77,1,0,0,0,0,79,1,0,0,0,0,81,1,0,0,0,0,83,1,0,0,0,0,85,
		1,0,0,0,0,87,1,0,0,0,0,89,1,0,0,0,0,91,1,0,0,0,1,93,1,0,0,0,3,100,1,0,
		0,0,5,105,1,0,0,0,7,110,1,0,0,0,9,120,1,0,0,0,11,125,1,0,0,0,13,144,1,
		0,0,0,15,146,1,0,0,0,17,151,1,0,0,0,19,154,1,0,0,0,21,159,1,0,0,0,23,164,
		1,0,0,0,25,170,1,0,0,0,27,176,1,0,0,0,29,185,1,0,0,0,31,188,1,0,0,0,33,
		192,1,0,0,0,35,196,1,0,0,0,37,204,1,0,0,0,39,208,1,0,0,0,41,212,1,0,0,
		0,43,217,1,0,0,0,45,223,1,0,0,0,47,226,1,0,0,0,49,228,1,0,0,0,51,230,1,
		0,0,0,53,232,1,0,0,0,55,235,1,0,0,0,57,238,1,0,0,0,59,241,1,0,0,0,61,244,
		1,0,0,0,63,246,1,0,0,0,65,248,1,0,0,0,67,250,1,0,0,0,69,252,1,0,0,0,71,
		254,1,0,0,0,73,256,1,0,0,0,75,258,1,0,0,0,77,260,1,0,0,0,79,262,1,0,0,
		0,81,264,1,0,0,0,83,266,1,0,0,0,85,268,1,0,0,0,87,270,1,0,0,0,89,283,1,
		0,0,0,91,295,1,0,0,0,93,94,5,110,0,0,94,95,5,117,0,0,95,96,5,109,0,0,96,
		97,5,98,0,0,97,98,5,101,0,0,98,99,5,114,0,0,99,2,1,0,0,0,100,101,5,98,
		0,0,101,102,5,111,0,0,102,103,5,111,0,0,103,104,5,108,0,0,104,4,1,0,0,
		0,105,106,5,116,0,0,106,107,5,101,0,0,107,108,5,120,0,0,108,109,5,116,
		0,0,109,6,1,0,0,0,110,114,5,34,0,0,111,113,9,0,0,0,112,111,1,0,0,0,113,
		116,1,0,0,0,114,115,1,0,0,0,114,112,1,0,0,0,115,117,1,0,0,0,116,114,1,
		0,0,0,117,118,5,34,0,0,118,8,1,0,0,0,119,121,7,0,0,0,120,119,1,0,0,0,121,
		122,1,0,0,0,122,120,1,0,0,0,122,123,1,0,0,0,123,10,1,0,0,0,124,126,7,0,
		0,0,125,124,1,0,0,0,126,127,1,0,0,0,127,125,1,0,0,0,127,128,1,0,0,0,128,
		129,1,0,0,0,129,131,5,46,0,0,130,132,7,0,0,0,131,130,1,0,0,0,132,133,1,
		0,0,0,133,131,1,0,0,0,133,134,1,0,0,0,134,12,1,0,0,0,135,136,5,116,0,0,
		136,137,5,114,0,0,137,138,5,117,0,0,138,145,5,101,0,0,139,140,5,102,0,
		0,140,141,5,97,0,0,141,142,5,108,0,0,142,143,5,115,0,0,143,145,5,101,0,
		0,144,135,1,0,0,0,144,139,1,0,0,0,145,14,1,0,0,0,146,147,5,110,0,0,147,
		148,5,117,0,0,148,149,5,108,0,0,149,150,5,108,0,0,150,16,1,0,0,0,151,152,
		5,105,0,0,152,153,5,102,0,0,153,18,1,0,0,0,154,155,5,116,0,0,155,156,5,
		104,0,0,156,157,5,101,0,0,157,158,5,110,0,0,158,20,1,0,0,0,159,160,5,101,
		0,0,160,161,5,108,0,0,161,162,5,115,0,0,162,163,5,101,0,0,163,22,1,0,0,
		0,164,165,5,101,0,0,165,166,5,110,0,0,166,167,5,100,0,0,167,168,5,105,
		0,0,168,169,5,102,0,0,169,24,1,0,0,0,170,171,5,119,0,0,171,172,5,104,0,
		0,172,173,5,105,0,0,173,174,5,108,0,0,174,175,5,101,0,0,175,26,1,0,0,0,
		176,177,5,101,0,0,177,178,5,110,0,0,178,179,5,100,0,0,179,180,5,119,0,
		0,180,181,5,104,0,0,181,182,5,105,0,0,182,183,5,108,0,0,183,184,5,101,
		0,0,184,28,1,0,0,0,185,186,5,100,0,0,186,187,5,111,0,0,187,30,1,0,0,0,
		188,189,5,65,0,0,189,190,5,78,0,0,190,191,5,68,0,0,191,32,1,0,0,0,192,
		193,5,83,0,0,193,194,5,85,0,0,194,195,5,77,0,0,195,34,1,0,0,0,196,197,
		5,65,0,0,197,198,5,86,0,0,198,199,5,69,0,0,199,200,5,82,0,0,200,201,5,
		65,0,0,201,202,5,71,0,0,202,203,5,69,0,0,203,36,1,0,0,0,204,205,5,77,0,
		0,205,206,5,73,0,0,206,207,5,78,0,0,207,38,1,0,0,0,208,209,5,77,0,0,209,
		210,5,65,0,0,210,211,5,88,0,0,211,40,1,0,0,0,212,213,5,83,0,0,213,214,
		5,79,0,0,214,215,5,82,0,0,215,216,5,84,0,0,216,42,1,0,0,0,217,218,5,67,
		0,0,218,219,5,79,0,0,219,220,5,85,0,0,220,221,5,78,0,0,221,222,5,84,0,
		0,222,44,1,0,0,0,223,224,5,79,0,0,224,225,5,82,0,0,225,46,1,0,0,0,226,
		227,5,61,0,0,227,48,1,0,0,0,228,229,5,60,0,0,229,50,1,0,0,0,230,231,5,
		62,0,0,231,52,1,0,0,0,232,233,5,61,0,0,233,234,5,61,0,0,234,54,1,0,0,0,
		235,236,5,60,0,0,236,237,5,61,0,0,237,56,1,0,0,0,238,239,5,62,0,0,239,
		240,5,61,0,0,240,58,1,0,0,0,241,242,5,33,0,0,242,243,5,61,0,0,243,60,1,
		0,0,0,244,245,5,43,0,0,245,62,1,0,0,0,246,247,5,45,0,0,247,64,1,0,0,0,
		248,249,5,42,0,0,249,66,1,0,0,0,250,251,5,47,0,0,251,68,1,0,0,0,252,253,
		5,37,0,0,253,70,1,0,0,0,254,255,5,40,0,0,255,72,1,0,0,0,256,257,5,41,0,
		0,257,74,1,0,0,0,258,259,5,91,0,0,259,76,1,0,0,0,260,261,5,93,0,0,261,
		78,1,0,0,0,262,263,5,123,0,0,263,80,1,0,0,0,264,265,5,125,0,0,265,82,1,
		0,0,0,266,267,5,58,0,0,267,84,1,0,0,0,268,269,5,44,0,0,269,86,1,0,0,0,
		270,271,5,47,0,0,271,272,5,42,0,0,272,276,1,0,0,0,273,275,9,0,0,0,274,
		273,1,0,0,0,275,278,1,0,0,0,276,277,1,0,0,0,276,274,1,0,0,0,277,279,1,
		0,0,0,278,276,1,0,0,0,279,280,5,42,0,0,280,281,5,47,0,0,281,88,1,0,0,0,
		282,284,7,1,0,0,283,282,1,0,0,0,284,285,1,0,0,0,285,283,1,0,0,0,285,286,
		1,0,0,0,286,287,1,0,0,0,287,291,7,2,0,0,288,290,7,0,0,0,289,288,1,0,0,
		0,290,293,1,0,0,0,291,289,1,0,0,0,291,292,1,0,0,0,292,90,1,0,0,0,293,291,
		1,0,0,0,294,296,7,3,0,0,295,294,1,0,0,0,296,297,1,0,0,0,297,295,1,0,0,
		0,297,298,1,0,0,0,298,299,1,0,0,0,299,300,6,45,0,0,300,92,1,0,0,0,10,0,
		114,122,127,133,144,276,285,291,297,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
