NUMBERDCL: 'number';
BOOLDCL: 'bool';
TEXTDCL: 'text';

STRING: '"' .*? '"';
INTEGER: [0-9]+;
FLOAT: [0-9]+ '.' [0-9]+;
BOOL: 'true' | 'false';
NULL: 'null';

VAR: [A-Z]+[1-9][0-9]*;
WS: [ \t\r\n]+ -> skip;

IF: 'if';
THEN: 'then';
ELSE: 'else';
ENDIF: 'endif';
WHILE: 'while';
ENDWHILE: 'endwhile';
DO: 'do';
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
