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
	IF conditionalexpression THEN block ELSE block ENDIF #ifelse
	| IF conditionalexpression THEN block ENDIF #ifthen;

whilestmt: WHILE conditionalexpression DO declaration ENDWHILE;

block: declaration*;

expression: 
	sum #sumexpression
	| average #averageexpression
	| min #minexpression
	| max #maxexpression
	| sort #sortexpression
	| expression operator expression #operatorexpression
  | expression op=LESSTHAN expression #booleanexpression
  | expression op=GREATERTHAN expression #booleanexpression
  | expression op=COMPEQUAL expression #booleanexpression
  | expression op=LESSEQUAL expression #booleanexpression
  | expression op=GREATEREQUAL expression #booleanexpression
  | expression op=NOTEQUAL expression #booleanexpression
  | expression op=AND expression #booleanexpression
  | expression op=OR expression #booleanexpression
	| count #countexpression
	| constant #constantexpression
  | VAR #varexpression;

conditionalexpression:
  expression booleanoperator expression #condexpression;

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
	| MODULO;

booleanoperator:
  LESSTHAN
	| GREATERTHAN
	| COMPEQUAL
	| LESSEQUAL
	| GREATEREQUAL
	| NOTEQUAL
  | AND
  | OR;

boolexpression:
  expression LESSTHAN expression
  | expression GREATERTHAN expression
  | expression COMPEQUAL expression
  | expression LESSEQUAL expression
  | expression GREATEREQUAL expression
  | expression NOTEQUAL expression
  | expression AND expression
  | expression OR expression;
