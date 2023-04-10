grammar Grammar;
program: declaration* EOF;
declaration:
	ifstmt 
	| whilestmt
	| assignment;

assignment: NUMBERDCL VAR '=' expression;

ifstmt:
	'if' expression 'then' declaration 'else' declaration 'endif'
	| 'if' expression 'then' declaration 'endif';

whilestmt: 'while' expression 'do' declaration 'endwhile';

expression: 
	constant
	| expression operator expression;

constant: INTEGER | FLOAT | BOOL | NULL;

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

INTEGER : [0-9]+;
FLOAT : [0-9]+ '.' [0-9]+;
BOOL: 'true' | 'false';
NULL: 'null';

VAR: [A-Z]+[1-9][0-9]*;
WS: [ \t\r\n]+ -> skip;
