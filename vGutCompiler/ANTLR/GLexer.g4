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
SUM: 'SUM';
AVERAGE: 'AVERAGE';
VLOOKUP: 'VLOOKUP';
MIN: 'MIN';
MAX: 'MAX';
SORT : 'SORT';
COUNT: 'COUNT';
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
DIVISION: '/';
MODULO: '%';
LPARENTHESIS: '(';
RPARENTHESIS: ')';
LSQUAREP: '['; 
RSQUAREP: ']'; 
LBRACKET: '{'; 
RBRACKET: '}';
COLON: ':';
COMMA: ',';
COMMENT: '/*' .*? '*/';


VAR: [A-Z]+[1-9][0-9]*;
WS: [ \t\r\n]+ -> skip;
