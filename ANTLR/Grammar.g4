grammar Grammar;

options {
    tokenVocab = GLexer;
}

program: declaration* EOF;
declaration:
	ifstmt 
	| whilestmt
	| assignment;

assignment: types VAR ASSIGN expression #assignnew
	| VAR ASSIGN expression #assigndec;

ifstmt:
	IF expression THEN declaration ELSE declaration ENDIF #ifelse
	| IF expression THEN declaration ENDIF #ifthen;

whilestmt: WHILE expression DO declaration ENDWHILE;

expression: 
	constant #constantexpression
	| sum #sumexpression
	| VAR #varexpression
	| expression operator expression #operatorexpression;

sum: SUM LPARENTHESIS VAR COLON VAR RPARENTHESIS;

constant: INTEGER | FLOAT | BOOL | STRING | NULL;
types: NUMBERDCL | BOOLDCL | TEXTDCL;
operator:
	ASSIGN
	| PLUS
	| MINUS
	| MULTIPLICATION
	| DIVISON
	| LESSTHAN
	| GREATERTHAN
	| COMPEQUAL
	| LESSEQUAL
	| GREATEREQUAL
	| NOTEQUAL
	| MODULO
	| AND
	| OR;

