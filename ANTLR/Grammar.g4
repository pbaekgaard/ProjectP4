grammar Grammar;
program: declaration* EOF;
declaration:
	ifstmt 
	| whilestmt
	| assignment;

assignment: types VAR '=' expression ;

ifstmt:
	'if' expression 'then' declaration 'else' declaration 'endif'
	| 'if' expression 'then' declaration 'endif';

whilestmt: 'while' expression 'do' declaration 'endwhile';

expression: 
	constant #constantexpression
	| expression operator expression #operatorexpression;

constant: INTEGER | FLOAT | BOOL | STRING | NULL;
types: NUMBERDCL | BOOLDCL | TEXTDCL;
operator:
	'+'
	| '-'
	| '*'
	| '/'
	| '<'
	| '>'
	| '<='
	| '>='
	| '='
	| '!=';

NUMBERDCL: 'number';
BOOLDCL: 'bool';
TEXTDCL: 'text';

STRING: '"' [a-zA-Z0-9]* '"';
INTEGER : [0-9]+;
FLOAT : [0-9]+ '.' [0-9]+;
BOOL: 'true' | 'false';
NULL: 'null';

VAR: [A-Z]+[1-9][0-9]*;
WS: [ \t\r\n]+ -> skip;
