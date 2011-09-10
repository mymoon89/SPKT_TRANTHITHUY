/********************************************************************/
/*                                                                  */
/*             Turbo Prolog 2.0 example program                     */
/*								    */
/*   Copyright (c) 1986, 88 by Borland International, Inc.          */
/*                                                                  */
/*			 SENTENCE ANALYSIS			    */
/* This sample shows how sentence analysing can be done in TURBO    */
/* PROLOG.							    */
/* The structure of sentences is nicely modelled in the typesystem, */
/* and the resulting parse-tree illustrates how easily these things */
/* can be doen in Turbo Prolog					    */
/*								    */
/* As an example the following sentence can be recognized:	    */
/*  - every man that lives loves a woman			    */
/*								    */
/********************************************************************/

include "tdoms.pro"
include "tpreds.pro" 
DATABASE   /* words which can be recognized */
  det( STRING )
  noun( STRING )
  rel( STRING )
  verb( STRING )

include "MENU2.PRO"

DOMAINS
  DETERM   = none ; determ( STRING )
  NOUNP    = nounp( DETERM, STRING, RELCL)
  RELCL    = none ; relcl( STRING, VERBP )
  SENTENCE = sent( NOUNP, VERBP )
  TOKL     = STRING*
  VERBP    = verb( STRING ) ; verbp( STRING, NOUNP )

/*
  Domains for the tree with positions
*/
  d_SENTENCE = sent( d_NOUNP, d_VERBP )
  d_NOUNP    = nounp( d_DETERM, COL, d_RELCL)
  d_DETERM   = none ; determ( COL )
  d_RELCL    = none ; relcl( COL, d_VERBP )
  d_VERBP    = verb( COL ) ; verbp( COL, d_NOUNP )

  COLL = COL*

PREDICATES
/*
  Recognition of words in different forms
*/
  is_det( STRING )
  is_noun( STRING )
  is_rel( STRING )
  is_verb( STRING )

/*
  Parser
*/
  s_determ(   TOKL, TOKL, COLL, COLL, DETERM, d_DETERM )
  s_nounp(    TOKL, TOKL, COLL, COLL, NOUNP, d_NOUNP )
  s_relcl(    TOKL, TOKL, COLL, COLL, RELCL, d_RELCL )
  s_sentence( TOKL, TOKL, COLL, COLL, SENTENCE, d_SENTENCE )
  s_verbp(    TOKL, TOKL, COLL, COLL, VERBP, d_VERBP )

/*
  draw a sentence tree
*/
  draw_nounp( ROW, ROW, d_NOUNP, NOUNP, COL )
  draw_relcl( ROW, ROW, d_RELCL, RELCL, COL )
  draw_sentence( ROW, ROW, d_SENTENCE, SENTENCE )
  draw_verbp( ROW, ROW, d_VERBP, VERBP, COL )

/*
  Miscellaneous drawing predicates
*/
  lin(ROW,COL,ROW,COL)
  line_hor(COL,COL,ROW)
  line_ver(ROW,ROW,COL)
  mark(ROW,COL,STRING,ATTR)
  mark2(ROW,COL,STRING,ATTR)
  markfinal(ROW,COL,STRING,STRING)
  mk_ulin(STRING,STRING)
  scr_tegn(ROW,COL,CHAR)
  writetext(ROW,COL,STRING,ATTR)

/*
  scanner
*/
  check(STRING)
  tokl( COL, COLL, STRING, TOKL )
  tom(TOKL).

/*
  Main predicates
*/
  analyze
  key
  process(INTEGER)
  run1
  run2(STRING)
  sen_an

/*
  Update database predicates
*/
  read(STRING,STRING)
  updatdba
  updatdba1(INTEGER)

GOAL
    makewindow(1,6,0,"",0,0,25,80),
%      makewindow(1,6,2," Sentence Analyzer ",0,0,25,80),
%      Makes a nicer display, but can't analyze long sentences!
    sen_an.

CLAUSES

key:-
    write("\n\n>> Press any key: "),
    readkey(_).

/* * * * * * *
  Main menu
* * * * * * */  
sen_an:-repeat,
  menu(5,27,7,7,
      [ "Analyze a sentence",
        "Load database from file",
        "Erase current database",
        "",
        "Show/update the language",
        "Save database to file",
        "",
        "Edit database file",
        "",
        "Tutorial",
        "",
        "Operating system",
        "eXit"] ,"Sentence Analyser",2,
  CHOICE) ,
  process(CHOICE),
  CHOICE=0,!.

process(0):-
    write("\nAre you sure ? (y/n): "),
    readchar(T),
    T='y'.
process(1) :- analyze.
process(2):-consult("sen_an.san"),!.
process(2):-write(">> Can't read sen_an.san\n").
process(3):- retractall(_).
process(5):-updatdba.
process(6):-
    existfile("sen_an.bak"),!,
    deletefile("sen_an.bak"),
    renamefile("sen_an.san","sen_an.bak"),
    save("sen_an.san");
    renamefile("sen_an.san","sen_an.bak"),
    save("sen_an.san").
    
process(8):-
    file_str("sen_an.san",DB),
    edit(DB,DBNEW),
    clearwindow,
    not(DB = DBNEW),
    write("Do you wish to save the changes? (y/n) "),
    readchar(Ans), str_char(Ans1,Ans),
    upper_lower(Ans1,Ans2), clearwindow ,
    Ans2 = "y",
    file_str("sen_an.san",DBNEW),
    retractall(_),
    process(2).
process(10):-
    file_str("sen_an.hlp",TXT),
    display(TXT),
    clearwindow,!.
process(10):-write(">> Can't read sen_an.hlp\n"),
             readchar(_),clearwindow.
process(12):-
    makewindow(2,2,0," DOS ", 10,10,10,60) ,
    system(""),!,
    removewindow.
process(12):-
    write(">> command.com not accesible. press any"),
    readchar(_),
    removewindow.
process(13) :- exit.

/* * * * * * * * * * *
  Analyze a sentence
* * * * * * * * * * */  
analyze:-
    clearwindow, cursor(21,1),
    write("Try: every man that lives loves a woman"),
    cursor(0,1) ,
    run1 ; clearwindow.

run1:-
    write("\n Write a sentence:\n    "),
    readln(LIN), LIN >< "" ,
    run2(LIN), !,
    run1.

run2(LIN):-
    clearwindow,
    tokl(5,POSL,LIN,TOKL),
    s_sentence( TOKL, _, POSL, _, SENT, POS ),
    draw_sentence( 4, 0, POS, SENT ), 
    cursor(21,1),
%    write("SENTENCE=",LIN),nl,nl,
    write("PROLOG OBJECT=",SENT," "),
    readchar(_),clearwindow,!.
run2(_).

tokl(POS,[POS1|POSL],STR,[TOK|TOKL]) :-
    fronttoken(STR,TOK,STR1),
    check(TOK),!,
    str_len(TOK,LEN),
    POS1=POS+(LEN+1) div 2,
    POS2=POS+5+LEN,
    tokl(POS2,POSL,STR1,TOKL).
tokl(_,[],_,[]).

s_sentence(TOKL,TOKL2,COLL,COLL2,sent(NOUNP,VERBP),
 sent(D_NOUNP,D_VERBP)):-
    s_nounp(TOKL,TOKL1,COLL,COLL1,NOUNP,D_NOUNP),
    s_verbp(TOKL1,TOKL2,COLL1,COLL2,VERBP,D_VERBP),
    tom(TOKL2),!.
s_sentence(_,_,_,_,_,_):-
    write(">> Sentence not recognized (Use F8 to get the old line)\n"),fail.

tom([]).

s_nounp(TOKL,TOKL2,COLL,COLL2,nounp(DETERM,NOUN,RELCL),
 nounp(D_DETERM,COL,D_RELCL)):-
    s_determ(TOKL,[NOUN|TOKL1],COLL,[COL|COLL1],DETERM,D_DETERM),
    is_noun(NOUN),
    s_relcl(TOKL1,TOKL2,COLL1,COLL2,RELCL,D_RELCL).

s_determ([DETERM|TOKL],TOKL,[COL|COLL],COLL,determ(DETERM),
 determ(COL)):-
    is_det(DETERM).
s_determ(TOKL,TOKL,COLL,COLL,none,none).

s_relcl([REL|TOKL],TOKL1,[COL|COLL],COLL1,relcl(REL,VERBP),
 relcl(COL,D_VERBP) ):-
    is_rel(REL),
    s_verbp(TOKL,TOKL1,COLL,COLL1,VERBP,D_VERBP).
s_relcl(TOKL,TOKL,COLL,COLL,none,none).

s_verbp([VERB|TOKL],TOKL1,[COL|COLL],COLL1,verbp(VERB,NOUNP),
 verbp(COL,D_NOUNP)):-
    is_verb(VERB),
    s_nounp(TOKL,TOKL1,COLL,COLL1,NOUNP,D_NOUNP).
s_verbp([VERB|TOKL],TOKL,[COL|COLL],COLL,verb(VERB),verb(COL)):-
    is_verb(VERB).

check(WORD):-is_noun(WORD),!.
check(WORD):-is_det(WORD),!.
check(WORD):-is_rel(WORD),!.
check(WORD):-is_verb(WORD),!.
check(WORD):- write(">> Unknown word: ",WORD),
              nl, readchar(_).

is_noun(X):-noun(X),!.
is_noun(X):-noun(Y),concat(Y,"s",X).

is_det(X):-det(X).

is_rel(X):-rel(X).

is_verb(X):-verb(X),!.
is_verb(X):-verb(Y),concat(Y,"s",X),!.
is_verb(X):-verb(Y),concat(Y,"ed",X),!.
is_verb(X):-verb(Y),concat(Y,"es",X),!.
is_verb(X):-verb(Y),concat(Y,"ing",X).

/* * * * * * * * * * * *
   Draw the sentence
* * * * * * * * * * * */   
draw_sentence(STEP,DEPT,sent(D_NOUNP,D_VERBP),sent(NOUNP,VERBP)):-
    DEPT1=DEPT+STEP,
    draw_nounp(STEP,DEPT1,D_NOUNP,NOUNP,COL1),
    draw_verbp(STEP,DEPT1,D_VERBP,VERBP,COL2),
    COL=(COL1+COL2) div 2,
    lin(DEPT,COL,DEPT1,COL1),
    lin(DEPT,COL,DEPT1,COL2),
    mark(DEPT,COL,"SENTENCE",33).

draw_nounp(STEP,DEPT,nounp(none,COL,none),nounp(_,NOUN,_),COL):-
    DEPT1=DEPT+STEP div 2,
    lin(DEPT1,COL,DEPT,COL),
    markfinal(DEPT1,COL,"NOUN",NOUN),
    mark(DEPT,COL,"NOUNP",33).
draw_nounp(STEP,DEPT,nounp(determ(COL1),COL2,none),
 nounp(determ(DET),NOUN,_),COL):-
    DEPT1=DEPT+STEP,
    COL=(COL1+COL2) div 2,
    lin(DEPT1,COL1,DEPT,COL),
    lin(DEPT1,COL2,DEPT,COL),
    markfinal(DEPT1,COL1,"DETERM",DET),
    markfinal(DEPT1,COL2,"NOUN",NOUN),
    mark(DEPT,COl,"NOUNP",33).
draw_nounp(STEP,DEPT,nounp(none,COL1,relcl(REL,VERBP)),
 nounp(none,NOUN,RELCL),COL):-
    DEPT1=DEPT+STEP,
    draw_relcl(STEP,DEPT1,relcl(REL,VERBP),RELCL,COL2),
    COL=(COL1+COL2) div 2,
    lin(DEPT1,COL1,DEPT,COL),
    lin(DEPT1,COL2,DEPT,COL),
    markfinal(DEPT1,COL1,"NOUN",NOUN),
    mark(DEPT,COL,"NOUNP",33).
draw_nounp(STEP,DEPT,nounp(determ(COL1),COL2,relcl(REL,VERBP)),
 nounp(determ(DET),NOUN,RELCL),COL):-
    DEPT1=DEPT+STEP,
    draw_relcl(STEP,DEPT1,relcl(REL,VERBP),RELCL,COL3),
    COL=(COL1+COL2+COL3) div 3,
    lin(DEPT1,COL1,DEPT,COL),
    lin(DEPT1,COL2,DEPT,COL),
    lin(DEPT1,COL3,DEPT,COL),
    markfinal(DEPT1,COL1,"DETERM",DET),
    markfinal(DEPT1,COL2,"NOUN",NOUN),
    mark(DEPT,COL,"NOUNP",33).

draw_verbp(STEP,DEPT,verb(COL),verb(VERB),COL):-
    DEPT1=DEPT+STEP div 2,
    lin(DEPT1,COL,DEPT,COL),
    markfinal(DEPT1,COL,"VERB",VERB),
    mark(DEPT,COL,"VERBP",33).
draw_verbp(STEP,DEPT,verbp(COL1,D_NOUNP),verbp(VERB,NOUNP),COL):-
    DEPT1=DEPT+STEP,
    draw_nounp(STEP,DEPT1,D_NOUNP,NOUNP,COL2),
    COL=(COL1+COL2) div 2,
    lin(DEPT1,COL1,DEPT,COL),
    lin(DEPT1,COL2,DEPT,COL),
    markfinal(DEPT1,COL1,"VERB",VERB),
    mark(DEPT,COL,"VERBP",33).

draw_relcl(STEP,DEPT,relcl(COL1,D_VERBP),relcl(REL,VERBP),COL):-
    DEPT1=DEPT+STEP,
    draw_verbp(STEP,DEPT1,D_VERBP,VERBP,COL2),
    COL=(COL1+COL2) div 2,
    lin(DEPT1,COL1,DEPT,COL),
    lin(DEPT1,COL2,DEPT,COL),
    markfinal(DEPT1,COL1,"REL",REL),
    mark(DEPT,COL,"RELCL",33).

lin(R1,C,R2,C):-!,
    line_ver(R1,R2,C).
lin(R1,C1,R2,C2):-
    RM=(R1+R2) div 2,
    line_ver(R1,RM,C1),
    line_hor(C1,C2,RM),
    line_ver(RM,R2,C2),
    scr_tegn(RM,C1,'+'),
    scr_tegn(RM,C2,'+').

line_ver(R,R,_):-!.
line_ver(R1,R2,C):-
    R2>R1,!,
    scr_tegn(R1,C,'|'),
    R=R1+1,
    line_ver(R,R2,C).
line_ver(R2,R1,C):-
    scr_tegn(R1,C,'|'),
    R=R1+1,
    line_ver(R,R2,C).

line_hor(C,C,_):-!.
line_hor(C1,C2,R):-
    C2>C1,!,
    scr_tegn(R,C1,'-'),
    C=C1+1,
    line_hor(C,C2,R).
line_hor(C2,C1,R):-
    scr_tegn(R,C1,'-'),
    C=C1+1,
    line_hor(C,C2,R).

mark(ROW,COL,TEXT,ATTR):-
    str_len(TEXT,LEN),
    C=COL-(LEN-1) div 2,
    writetext(ROW,C,TEXT,ATTR).

mark2(ROW,COL,TEXT,ATTR):-
    str_len(TEXT,LEN),
    C=COL-LEN div 2,
    writetext(ROW,C,TEXT,ATTR).

markfinal(ROW,COL,TEXT1,TEXT2):-
    str_len(TEXT1,L1),
    str_len(TEXT2,L2),
    L2>L1,!,
    R1=ROW+1, R2=ROW+2,
    mk_ulin(TEXT1,ULINE),
    mark2(ROW,COL,TEXT1,33),
    mark2(R1,COL,ULINE,7),
    mark(R2,COL,TEXT2,112).

markfinal(ROW,COL,TEXT1,TEXT2):-
    str_len(TEXT1,L),
    str_len(TEXT2,L),!,
    R1=ROW+1,
    R2=ROW+2,
    mk_ulin(TEXT1,ULINE),
    mark(ROW,COL,TEXT1,33),
    mark(R1,COL,ULINE,7),
    mark(R2,COL,TEXT2,112).

markfinal(ROW,COL,TEXT1,TEXT2):-
    R1=ROW+1,
    R2=ROW+2,
    mk_ulin(TEXT1,ULINE),
    mark(ROW,COL,TEXT1,33),
    mark(R1,COL,ULINE,7),
    mark2(R2,COL,TEXT2,112).

mk_ulin(STR1,STR2):-
    frontchar(STR1,_,REST),!,
    mk_ulin(REST,ULI1),
    concat(ULI1,"-",STR2).
mk_ulin("","").

scr_tegn(R,C,CH):-
    R<25,
    C<80,!,
    scr_char(R,C,CH).
scr_tegn(_,_,_).

writetext(ROW,COL,TEXT,ATTR):-
    ROW<25,
    COL<80,
    frontchar(TEXT,CH,REST),!,
    scr_char(ROW,COL,CH),
    scr_attr(ROW,COL,ATTR),
    COL1=COL+1,
    writetext(ROW,COL1,REST,ATTR).
writetext(_,_,_,_).

/* * * * * * * * * * * *
  Update/Show database
* * * * * * * * * * * */
updatdba:-
    repeat,
    menu(10,20,7,7,
     ["Show verbs", 
      "Show nouns",
      "Show relatives", 
      "Show determiners",
      "",
      "Add a verb", 
      "Add a noun",
      "Add a relative", 
      "Add a determiner"],"Update/Show database",
      5,CHOICE),
    updatdba1(CHOICE),
    CHOICE=0,!.

updatdba1(0).
updatdba1(1):-
    write("\n\nVerbs:\n******\n"),
    verb(X), write(X,' '), fail.
updatdba1(1):-nl,key,clearwindow.
updatdba1(2):-
    write("\n\nNouns:\n******\n"),
    noun(X), write(X,' '), fail.
updatdba1(2):-nl,key,clearwindow.
updatdba1(3):-
    write("\n\nRelatives:\n**********\n"),
    rel(X), write(X,' '), fail.
updatdba1(3):-nl,key,clearwindow.
updatdba1(4):-
    write("\n\nDeterminers:\n************\n"),
    det(X), write(X,' '), fail.
updatdba1(4):-nl,key,clearwindow.
updatdba1(6):-
    read("New verb",X),
    assert(verb(X)).
updatdba1(7):-
    read("New noun",X),
    assert(noun(X)).
updatdba1(8):-
    read("New relative",X),
    assert(rel(X)).
updatdba1(9):-
    read("New determiner",X),
    assert(det(X)).

read(TXT,ANS):-nl,
    write(TXT,": "),
    readln(ANS),clearwindow,ANS><"".
