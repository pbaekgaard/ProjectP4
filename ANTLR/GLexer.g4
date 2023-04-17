lexer grammar GLexer;

NUMBERDCL: 'number';
BOOLDCL: 'bool';
TEXTDCL: 'text';

STRING: '"' .*? '"';
INTEGER: [0-9]+;
FLOAT: [0-9]+ '.' [0-9]+;
BOOL: 'true' | 'false';
NULL: 'null';


IF: 'if';
THEN: 'then';
ELSE: 'else';
ENDIF: 'endif';
WHILE: 'while';
ENDWHILE: 'endwhile';
DO: 'do';
AND: 'AND';
OR: 'OR';
ASSIGN: '=';
LESSTHAN: '<';
GREATERTHAN: '>';
COMPEQUAL: '==';
LESSEQUAL: '<=';
GREATEREQUAL: '>=';
NOTEQUAL: '!=';
PLUS: '+';
MINUS: '-';
MULTIPLICATION: '*';
DIVISON: '/';
MODULO: '%';
LPARENTHESIS: '(';
RPARENTHESIS: ')';
LSQUAREP: '['; 
RSQUAREP: ']'; 
LBRACKET: '{'; 
RBRACKET: '}';
COMMENT: '/*' .*? '*/';


VAR: [A-Z]+[1-9][0-9]*;
WS: [ \t\r\n]+ -> skip;
