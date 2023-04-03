//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.12.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Grammar.g4 by ANTLR 4.12.0

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="GrammarParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.12.0")]
[System.CLSCompliant(false)]
public interface IGrammarVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProgram([NotNull] GrammarParser.ProgramContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.declarations"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclarations([NotNull] GrammarParser.DeclarationsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclaration([NotNull] GrammarParser.DeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression([NotNull] GrammarParser.ExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.sum"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSum([NotNull] GrammarParser.SumContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.average"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAverage([NotNull] GrammarParser.AverageContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.min"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMin([NotNull] GrammarParser.MinContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.max"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMax([NotNull] GrammarParser.MaxContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.count"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCount([NotNull] GrammarParser.CountContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.controlstructure"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitControlstructure([NotNull] GrammarParser.ControlstructureContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.ifstmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfstmt([NotNull] GrammarParser.IfstmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.whilestmt"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhilestmt([NotNull] GrammarParser.WhilestmtContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.var"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVar([NotNull] GrammarParser.VarContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.num"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNum([NotNull] GrammarParser.NumContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.string"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitString([NotNull] GrammarParser.StringContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.text"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitText([NotNull] GrammarParser.TextContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.numbers"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumbers([NotNull] GrammarParser.NumbersContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.numberswithoutzero"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumberswithoutzero([NotNull] GrammarParser.NumberswithoutzeroContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.operator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOperator([NotNull] GrammarParser.OperatorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.bool"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBool([NotNull] GrammarParser.BoolContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.upperCaseLetters"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUpperCaseLetters([NotNull] GrammarParser.UpperCaseLettersContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="GrammarParser.lowercaseLetters"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLowercaseLetters([NotNull] GrammarParser.LowercaseLettersContext context);
}
