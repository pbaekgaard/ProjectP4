grammar Grammar;

options {
    tokenVocab = GLexer;
}

program: declaration* EOF;
declaration:
	ifstmt 
	| whilestmt
	| assignment
	| sortingexpression;

assignment: types VAR ASSIGN conditionalexpression #assignnew
	| VAR ASSIGN conditionalexpression #assigndec;

ifstmt:
	IF conditionalexpression THEN block ELSE block ENDIF #ifelse
	| IF conditionalexpression THEN declaration* ENDIF #ifthen;

whilestmt: WHILE conditionalexpression DO declaration* ENDWHILE;

block: declaration*;

sortingexpression: 
	sort #sortexpression;

expression: 
	sum #sumexpression
	| average #averageexpression
  | vlookup #vlookupexpression
	| min #minexpression
	| max #maxexpression
	| count #countexpression
	| vlookup #vlookupexpression
	| VAR #varexpression
	| count #countexpression
	| countif #countexpression
	| constant #constantexpression;

conditionalexpression: 
  conditionalexpression op=(LESSTHAN | GREATERTHAN | GREATEREQUAL | LESSEQUAL) conditionalexpression #relatExpr
  | conditionalexpression op=(COMPEQUAL | NOTEQUAL) conditionalexpression #equaExpr
  | conditionalexpression op=(PLUS | MINUS | MULTIPLICATION | DIVISION | MODULO) conditionalexpression #arithExpr
  | conditionalexpression op=AND conditionalexpression #andExpr
  | conditionalexpression op=OR conditionalexpression #orExpr
  | expression #Expr;


sum: SUM LPARENTHESIS VAR COLON VAR RPARENTHESIS;
average: AVERAGE LPARENTHESIS VAR COLON VAR RPARENTHESIS;
min: MIN LPARENTHESIS VAR COLON VAR RPARENTHESIS;
max: MAX LPARENTHESIS VAR COLON VAR RPARENTHESIS;
count: COUNT LPARENTHESIS VAR COLON VAR RPARENTHESIS;
countif: COUNT LPARENTHESIS VAR COLON VAR COMMA specific=(INTEGER | FLOAT) RPARENTHESIS;
vlookup: VLOOKUP LPARENTHESIS constant COMMA VAR COLON VAR COMMA INTEGER COMMA BOOL RPARENTHESIS;
sort: SORT LPARENTHESIS VAR COLON VAR COMMA VAR COMMA BOOL RPARENTHESIS;

constant: INTEGER | FLOAT | BOOL | STRING | NULL;
types: NUMBERDCL | BOOLDCL | TEXTDCL;

