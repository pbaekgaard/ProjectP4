grammar Grammar;

options {
    tokenVocab = GLexer;
}

program: declaration* EOF;
declaration:
	ifstmt 
	| whilestmt
	| assignment;

assignment: types VAR ASSIGN expression ;

ifstmt:
	IF expression THEN declaration ELSE declaration ENDIF
	| IF expression THEN declaration ENDIF;

whilestmt: WHILE expression DO declaration ENDWHILE;

expression: 
	constant #constantexpression
	| expression operator expression #operatorexpression
	| VAR operator VAR #varexpression;

constant: INTEGER | FLOAT | BOOL | STRING | NULL;
types: NUMBERDCL | BOOLDCL | TEXTDCL;
operator:
	ASSIGN
	| PLUS
	| MINUS
	| MULTIPLICATION
	| DIVISON
	| LESSTHAN
	| GREATERTHAN
	| COMPEQUAL
	| LESSEQUAL
	| GREATEREQUAL
	| NOTEQUAL
	| MODULO
	| AND
	| OR;

