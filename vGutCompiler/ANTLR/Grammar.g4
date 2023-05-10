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
  conditionalexpression op=LESSTHAN conditionalexpression #condexpression
  | conditionalexpression op=GREATERTHAN conditionalexpression #condexpression
  | conditionalexpression op=COMPEQUAL conditionalexpression #condexpression
  | conditionalexpression op=LESSEQUAL conditionalexpression #condexpression
  | conditionalexpression op=GREATEREQUAL conditionalexpression #condexpression
  | conditionalexpression op=NOTEQUAL conditionalexpression #condexpression
  | conditionalexpression op=AND conditionalexpression #condexpression
  | conditionalexpression op=OR conditionalexpression #condexpression
  | expression #condexpression;

sum: SUM LPARENTHESIS VAR COLON VAR RPARENTHESIS;
average: AVERAGE LPARENTHESIS VAR COLON VAR RPARENTHESIS;
min: MIN LPARENTHESIS VAR COLON VAR RPARENTHESIS;
max: MAX LPARENTHESIS VAR COLON VAR RPARENTHESIS;
count: COUNT LPARENTHESIS VAR COLON VAR RPARENTHESIS;
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
