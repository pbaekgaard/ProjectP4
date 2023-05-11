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

assignment: types VAR ASSIGN expression #assignnew
            | VAR ASSIGN expression #assigndec;

ifstmt:
	IF conditionalexpression THEN block ELSE block ENDIF #ifelse
	| IF conditionalexpression THEN block ENDIF #ifthen;

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
  | countif #countexpression
	| constant #constantexpression
  | VAR #varexpression;

conditionalexpression: 
  expression op=LESSTHAN expression #condexpression
  | expression op=GREATERTHAN expression #condexpression
  | expression op=COMPEQUAL expression #condexpression
  | expression op=LESSEQUAL expression #condexpression
  | expression op=GREATEREQUAL expression #condexpression
  | expression op=NOTEQUAL expression #condexpression
  | expression op=AND expression #condexpression
  | expression op=OR expression #condexpression;

sum: SUM LPARENTHESIS VAR COLON VAR RPARENTHESIS;
average: AVERAGE LPARENTHESIS VAR COLON VAR RPARENTHESIS;
min: MIN LPARENTHESIS VAR COLON VAR RPARENTHESIS;
max: MAX LPARENTHESIS VAR COLON VAR RPARENTHESIS;
count: COUNT LPARENTHESIS VAR COLON VAR RPARENTHESIS;
vlookup: VLOOKUP LPARENTHESIS STRING COMMA VAR COLON VAR COMMA INTEGER COMMA BOOL RPARENTHESIS;
countif: COUNT LPARENTHESIS VAR COLON VAR COMMA specific=(INTEGER | FLOAT) RPARENTHESIS;
sort: SORT LPARENTHESIS VAR COLON VAR COMMA VAR COMMA BOOL RPARENTHESIS;

constant: INTEGER | FLOAT | BOOL | STRING | NULL;
types: NUMBERDCL | BOOLDCL | TEXTDCL;
operator:
  ASSIGN
  | PLUS
	| MINUS
	| MULTIPLICATION
	| DIVISON
	| MODULO;
