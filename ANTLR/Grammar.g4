grammar Grammar;
program: declarations;
declarations: declaration declarations | <EOF> ;
declaration:
	controlstructure
	| expression
	| sum
	| average
	| min
	| max
	| count;
expression: var | expression operator expression;
sum: 'sum' '(' 'var' ':' 'var' ')';
average: 'average' '(' 'var' ':' 'var' ')';
min: 'min' '(' 'var' ':' 'var' ')';
max: 'max' '(' 'var' ':' 'var' ')';
count: 'count' '(' 'var' ':' 'var' ')';
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
controlstructure: ifstmt | whilestmt;
ifstmt:
	'if' expression 'then' declaration 'else' declaration
	| 'if' expression 'then' declaration;
whilestmt: 'while' expression 'do' declaration;
var:
	letters numberswithoutzero
	| letters numberswithoutzero num
	| letters var;
numbers:
	'0'
	| '1'
	| '2'
	| '3'
	| '4'
	| '5'
	| '6'
	| '7'
	| '8'
	| '9';
numberswithoutzero:
	'1'
	| '2'
	| '3'
	| '4'
	| '5'
	| '6'
	| '7'
	| '8'
	| '9';
num: numbers | numbers num;
letters:
	'A'
	| 'B'
	| 'C'
	| 'D'
	| 'E'
	| 'F'
	| 'G'
	| 'H'
	| 'I'
	| 'J'
	| 'K'
	| 'L'
	| 'M'
	| 'N'
	| 'O'
	| 'P'
	| 'Q'
	| 'R'
	| 'S'
	| 'T'
	| 'U'
	| 'V'
	| 'W'
	| 'X'
	| 'Y'
	| 'Z';
WS: [ \t\r\n]+ -> skip;