# ProjectP4

# How to use ANTLR to generate the parse tree

0. Download antlr-4.12.0-complete.jar https://www.antlr.org/download.html

1. SET CLASSPATH=.;C:\Users\krist\Desktop\antlrjar\antlr-4.12.0-complete.jar;%CLASSPATH%

2. Add til path to bat filer: a => antlr4.bat og b => grun.bat

- a:

	- java org.antlr.v4.Tool %*

- b:

	- @ECHO OFF

	- SET TEST_CURRENT_DIR=%CLASSPATH:.;=%

	- if "%TEST_CURRENT_DIR%" == "%CLASSPATH%" ( SET CLASSPATH=.;%CLASSPATH% )

	- @ECHO ON

	- java org.antlr.v4.gui.TestRig %*

  

3. (optional): test installationen: java org.antlr.v4.Tool

  

4. cd til mappen med projektfiler

5. antlr4 Grammar.g4

6. javac Grammar*.java

7. grun Grammar <grammar  del  der  skal  testes  -  ellers  bare  kør  declarations> -gui

- Hvis man vil have et træ skrevet ud i konsolen (som kan bruges til videre faser i compileren) => grun Grammar declarations -tree

- Input her virker: if A2 + A3 then A3 + A4

- Dernæst tryk CTRL Z for windows (CTRL D for Unix) => Tryk enter og den burde lave magi