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
	IF expression THEN block ELSE block ENDIF #ifelse
	| IF expression THEN block ENDIF #ifthen;

whilestmt: WHILE expression DO declaration ENDWHILE;

block: declaration*;

expression: 
	sum #sumexpression
	| average #averageexpression
	| min #minexpression
	| max #maxexpression
	| count #countexpression
	| sort #sortexpression
	| VAR #varexpression
	| expression operator expression #operatorexpression
	| constant #constantexpression;

sum: SUM LPARENTHESIS VAR COLON VAR RPARENTHESIS;
average: AVERAGE LPARENTHESIS VAR COLON VAR RPARENTHESIS;
min: MIN LPARENTHESIS VAR COLON VAR RPARENTHESIS;
max: MAX LPARENTHESIS VAR COLON VAR RPARENTHESIS;
count: COUNT LPARENTHESIS VAR COLON VAR RPARENTHESIS;
sort: SORT LPARENTHESIS VAR COLON VAR COMMA VAR RPARENTHESIS;

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

