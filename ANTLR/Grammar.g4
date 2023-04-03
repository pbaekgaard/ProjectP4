grammar Grammar;
program: declarations;
declarations: declaration declarations | <EOF> ;
declaration:
	controlstructure
	| NUMBERDCL var ASSIGN num
	| TEXTDCL var ASSIGN string
	| BOOLEANDCL var ASSIGN bool
	| expression
	| sum
	| average
	| min
	| max
	| count;
NUMBERDCL: 'number';
TEXTDCL: 'text';
BOOLEANDCL: 'bool';
expression: var | expression operator expression;
sum: 'sum' '(' var ':' var ')';
average: 'average' '(' var ':' var ')';
min: 'min' '(' var ':' var ')';
max: 'max' '(' var ':' var ')';
count: 'count' '(' var ':' var ')';
controlstructure: ifstmt | whilestmt;
ifstmt:
	'if' expression 'then' declaration 'else' declaration 'endif'
	| 'if' expression 'then' declaration 'endif';
whilestmt: 'while' expression 'do' declaration 'endwhile';
var:
	upperCaseLetters numberswithoutzero
	| upperCaseLetters numberswithoutzero num
	| upperCaseLetters var;
num: numbers | numbers num;
string: '"' text '"';
text:
 	(upperCaseLetters|lowercaseLetters|num)*
	| .*?
;
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
ASSIGN:
	'=';
bool:
	'false'
	|'true';
upperCaseLetters:
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
lowercaseLetters:
	'a'
	| 'b'
	| 'c'
	| 'd'
	| 'e'
	| 'f'
	| 'g'
	| 'h'
	| 'i'
	| 'j'
	| 'k'
	| 'l'
	| 'm'
	| 'n'
	| 'o'
	| 'p'
	| 'q'
	| 'r'
	| 's'
	| 't'
	| 'u'
	| 'v'
	| 'w'
	| 'x'
	| 'y'
	| 'z';
Comment: '/*' .*? '*/' -> channel(HIDDEN);
WS: [ \t\r\n]+ -> skip;