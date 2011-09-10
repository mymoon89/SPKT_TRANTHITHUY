/**********************************************************************

     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.

			Parser generator

			Invariants
			==========

About names
  Production names are always in upper case.
  Functors are in lowercase

**********************************************************************/

nobreak
code=3500
project "parser"
include "parser.def"

include "tpreds.pro"
include "lineinp.pro"
include "filename.pro"
include "status.pro"
include "pulldown.pro"

/************************************************************************
			Check parser
************************************************************************/

PREDICATES
  new_error(STRING,CURSOR)
  check_parser
  check_domains
  check_graml(GRAMTOKL)
  check_gramtok(GRAMTOK)
  check_term(TERM)
  check_prod(CURSOR,PRODNAME)
  check_doml(CURSOR,PRODNAMES)
  check_groups(PRODNAME,PRODGROUPS)
  none_selfref(PRODNAME,PRIORGROUP)
  check_priorgroup(PRODNAME,PRIORGROUP)
  check_assoc(PRODNAME,ASSOC,GRAMTOKL)
  check_terms
  check_compatterml(PRODNAME,TERML)
  check_compatrestlist(TERM,TERML)
  check_compatterm(TERM,TERM)
  check_equalsize(CURSOR,GRAMTOKL,TERM)
  gettermdoml(TERM,PRODNAMES)
  check_equallength(CURSOR,PRODNAMES,PRODNAMES)
  check_reserved(STRING,CURSOR)
  reserved_word(STRING)
  check_tok(TOKK)
  check_sepp(SEPARATOR,CURSOR)

CLAUSES
  check_parser:-retract(error(_,_)),fail.
  check_parser:-
	check_domains,
	check_terms.

  check_domains:-
	p(_,list(PROD1,CURSOR,_,SEPARATOR)),
	check_sepp(SEPARATOR,CURSOR),
	not(check_prod(CURSOR,PROD1)),
	!,fail.
  check_domains:-
	p(PRODNAME,groups(GROUPS)),
	not(check_groups(PRODNAME,GROUPS)),
	!,fail.
  check_domains.

  check_groups(_,[]).
  check_groups(PRODNAME,[PRODUCTIONS]):-!,
	check_priorgroup(PRODNAME,PRODUCTIONS),
	none_selfref(PRODNAME,PRODUCTIONS).
  check_groups(PRODNAME,[H|T]):-
	check_priorgroup(PRODNAME,H),
	check_groups(PRODNAME,T).

  none_selfref(_,[]).
  none_selfref(PRODNAME,[prod(_,[prodname(PRODNAME,CURSOR)|_],_,_)|_]):-!,
	new_error("Split up in priority groups !",CURSOR),fail.
  none_selfref(PRODNAME,[_|T]):-
	none_selfref(PRODNAME,T).

  check_priorgroup(_,[]).
  check_priorgroup(PRODNAME,[prod(ASSOC,GRAML,CURSOR,TERM)|T]):-
	check_assoc(PRODNAME,ASSOC,GRAML),
	check_graml(GRAML),
	check_term(TERM),
	check_equalsize(CURSOR,GRAML,TERM),
	check_priorgroup(PRODNAME,T).

  check_assoc(_,left,_):-!.
  check_assoc(_,_,[prodname(_,_)|_]):-!.
  check_assoc(_,right(CURSOR),_):-
	new_error("rightassoc not alloved here",CURSOR),fail.

  check_graml([]).
  check_graml([GRAMTOK|T]):-
	check_gramtok(GRAMTOK),
	check_graml(T).

  check_gramtok(prodname(PROD1,CURSOR)):-check_prod(CURSOR,PROD1).
  check_gramtok(tok(name(NAME,CURSOR),_)):-
	check_tok(name(NAME,CURSOR)).
  check_gramtok(tok(cmp(NAME,CURSOR,DOML),_)):-
	check_tok(cmp(NAME,CURSOR,DOML)),
	check_doml(CURSOR,DOML).

  check_tok(name(NAME,CURSOR)):-
	check_reserved(NAME,CURSOR),
	decltok(NAME,name(NAME,_)),!.
  check_tok(name(NAME,CURSOR)):-
	not(decltok(NAME,_)),!,
	assert(decltok(NAME,name(NAME,CURSOR))).
  check_tok(cmp(NAME,CURSOR,DOML)):-
	check_reserved(NAME,CURSOR),
	decltok(NAME,cmp(NAME,_,DOML)),!.
  check_tok(cmp(NAME,CURSOR,DOML)):-
	not(decltok(NAME,_)),!,
	assert(decltok(NAME,cmp(NAME,CURSOR,DOML))).
  check_tok(cmp(_,CURSOR,_)):-
	new_error("Token not compatible with old use of same name",CURSOR),fail.
  check_tok(name(_,CURSOR)):-
	new_error("Token not compatible with old use of same name",CURSOR),fail.

  check_sepp(sep(NAME),CURSOR):-!,check_tok(name(NAME,CURSOR)).
  check_sepp(_,_).

  check_doml(_,[]).
  check_doml(CURSOR,[H|T]):-
	check_prod(CURSOR,H),
	check_doml(CURSOR,T).

  check_term(dom(PROD1,CURSOR)):-!,check_prod(CURSOR,PROD1).
  check_term(term(_,CURSOR,DOML)):-!,check_doml(CURSOR,DOML).
  check_term(_).

  check_equalsize(CURSOR,GRAML,TERM):-
	getdoml(GRAML,9999,DOML1),
	gettermdoml(TERM,DOML2),
	check_equallength(CURSOR,DOML1,DOML2).

  gettermdoml(term(_,_,DOML),DOML):-!.
  gettermdoml(dom(DOM,_),[DOM]):-!.
  gettermdoml(_,[]).

  check_equallength(_,[],[]):-!.
  check_equallength(CURSOR,[_|T1],[_|T2]):-!,
	check_equallength(CURSOR,T1,T2).
  check_equallength(CURSOR,_,_):-
	new_error("There are not the same number of domain names on both sides",CURSOR),fail.

  check_prod(_,PROD):-prodname(PROD),!.
  check_prod(_,"CURSOR"):-!.
  check_prod(_,"STRING"):-!.
  check_prod(_,"REAL"):-!.
  check_prod(_,"INTEGER"):-!.
  check_prod(_,"CHAR"):-!.
  check_prod(_,"SYMBOL"):-!.
  check_prod(_,PROD):-userprod(PROD),!.
  check_prod(_,PROD):-userdom(PROD),!.
  check_prod(CURSOR,PROD):-
	concat("Unknown production name: ",PROD,MSG),
	new_error(MSG,CURSOR),fail.

  check_terms:-
	p(PRODNAME,_),
	findall(TERMS,terms(PRODNAME,TERMS),TERML),
	not(check_compatterml(PRODNAME,TERML)),
	!,fail.
  check_terms.

  check_compatterml(_,[]).
  check_compatterml(PRODNAME,[dom(PROD1,CURSOR)|_]):-
	not(PROD1=PRODNAME),!,
	new_error("A reference to a new domain is not allowed",CURSOR),
	fail.
  check_compatterml(PRODNAME,[H|T]):-
	check_compatrestlist(H,T),
	check_compatterml(PRODNAME,T).

  check_compatrestlist(_,[]).
  check_compatrestlist(TERM,[H|T]):-
	check_compatterm(TERM,H),
	check_compatrestlist(TERM,T).

  check_compatterm(name(ID,_),term(ID,CURSOR,_)):-!,
	new_error("Same functor twice with different parameters",CURSOR),fail.
  check_compatterm(term(ID,_,_),name(ID,CURSOR)):-!,
	new_error("Same functor twice with different parameters",CURSOR),fail.
  check_compatterm(term(ID,_,DOML1),term(ID,CURSOR,DOML2)):-not(DOML1=DOML2),!,
	new_error("Same functor twice with different parameters",CURSOR),fail.
  check_compatterm(_,_).

  check_reserved(NAME,CURSOR):-
	reserved_word(NAME),!,
	new_error("Reserved words in the prolog system can not be used",CURSOR),fail.
  check_reserved(_,_).

  reserved_word("assert").
  reserved_word("asserta").
  reserved_word("assertz").
  reserved_word("database").
  reserved_word("domains").
  reserved_word("or").
  reserved_word("bound").
  reserved_word("free").
  reserved_word("findall").
  reserved_word("fail").
  reserved_word("global").
  reserved_word("if").
  reserved_word("not").
  reserved_word("include").
  reserved_word("clauses").
  reserved_word("readterm").
  reserved_word("goal").
  reserved_word("and").
  reserved_word("predicates").
  reserved_word("retract").
  reserved_word("write").
  reserved_word("writef").
  reserved_word("constants").

/************************************************************************
		TRANSFORMING THE TREE TO CLAUSES
************************************************************************/

PREDICATES
  assertproductions(PRODUCTIONS)
  assertsection(SECTION)
  assertparser(PARSER)
  nondeterm member(PRODNAME,PRODNAMES)

CLAUSES
  assertparser([]).
  assertparser([H|T]):-assertsection(H),assertparser(T).
  
  assertsection(productions_(PRODUCTIONS)):-!,assertproductions(PRODUCTIONS).
  assertsection(userprods_(PRODUCTIONS)):-
	member(PROD,PRODUCTIONS),
	assert(userprod(PROD)),
	fail.
  assertsection(userdoms_(PRODUCTIONS)):-
	member(PROD,PRODUCTIONS),
	assert(userdom(PROD)),
	fail.
  assertsection(_).

  assertproductions([]).
  assertproductions([p(PRODNAME,_,PRODBODY)|T]):-
	not(prodname(PRODNAME)),!,
	assert(prodname(PRODNAME)),
	assert(p(PRODNAME,PRODBODY)),
	assertproductions(T).
  assertproductions([p(_,CURSOR,_)|_]):-
	new_error("Production already defined",CURSOR),fail.

  member(X,[X|_]).
  member(X,[_|L]):-member(X,L).


/************************************************************************
		USER INTERFACE
************************************************************************/

PREDICATES
  scan_error(STRING,CURSOR)

include "parser.sca"

PREDICATES
  ed(STRING,CURSOR)
  chksure(INTEGER,STRING)
  change(DBASEDOM)
  nondeterm repparse
  better_error(CURSOR)
  refreshsource
  parse
  clear

PREDICATES
  expect(CURSORTOK,TOKL,TOKL)
  syntax_error(STRING,TOKL)
  checkempty(TOKL)

include "parser.par"

CLAUSES
  better_error(CURSOR):-
	error(_,OLDCURSOR),OLDCURSOR>=CURSOR,!,fail.
  better_error(_).

  new_error(_,_):-retract(error(_,_)),fail.
  new_error(MSG,CURSOR):-assert(error(MSG,CURSOR)).

  expect(TOK,[TOK|L],L):-!.
  expect(t(TOK,_),[t(_,CURSOR)|_],_):-
	better_error(CURSOR),
	str_tok(STR,TOK),
	concat(STR," expected",MSG),
	new_error(MSG,CURSOR),fail.

  syntax_error(PROD,[t(_,CURSOR)|_]):-
	better_error(CURSOR),
	concat("Syntax error in ",PROD,MSG),
	new_error(MSG,CURSOR),fail.

  scan_error(MSG,CURSOR):-ed(MSG,CURSOR),fail.

  checkempty([]):-!.
  checkempty([t(_,CURSOR)|_]):-
	better_error(CURSOR),
	new_error("Syntax error",CURSOR).

  chksure(_,STR):-source(STR),!,fail.
  chksure(0,_):-!.
  chksure(1,_):-
	lineinput(5,70,40,66,66,"Skip the changes (y/n) ? ","",ANS),
	upper_lower(ANS,ANS1),
	ANS1="y",!,
	refreshsource,
	fail.
  chksure(_,_).

  ed(MSG,CURSOR):-
	source(TXT),
	shiftwindow(OLD),
	shiftwindow(1),
	editmsg(TXT,TXT1,"","",MSG,CURSOR,"",RET),
	shiftwindow(OLD),
	chksure(RET,TXT1),!,
	change(source(TXT1)).

  change(source(_)):-retract(source(_)),fail.
  change(filename(_)):-retract(filename(_)),fail.
  change(X):-assert(X).

  repparse.
  repparse:-error(MSG,CURSOR),ed(MSG,CURSOR),!,repparse.

  refreshsource:-
	source(SOURCE),!,
	shiftwindow(OLDW),
	shiftwindow(1),
	window_str(SOURCE),
	shiftwindow(OLDW).

  clear:-retract(p(_,_)),fail.
  clear:-retract(prodname(_)),fail.
  clear:-retract(error(_,_)),fail.
  clear:-retract(userdom(_)),fail.
  clear:-retract(userprod(_)),fail.
  clear:-retract(pred_second(_,_,_,_,_,_)),fail.
  clear:-retract(pred_first(_,_,_,_)),fail.
  clear:-retract(suffix(_)),fail.
  clear:-retract(difflist(_)),fail.
  clear:-retract(clausevar(_,_)),fail.
  clear:-retract(outptermvar(_,_)),fail.
  clear:-retract(decl(_,_)),fail.
  clear:-retract(decltok(_,_)),fail.
  clear:-retract(exist_prior(_,_)),fail.
  clear:-retract(catchallflag),fail.
  clear.

  parse:-
	filename(FILENAME),
	repparse,
	clear,
	source(STR1),
	write("\nScan"),
	tokl(0,STR1,L),
	write("\nParse"),
	s_parser(L,L1,X),
	checkempty(L1),
	write("\nAssert"),
	assertparser(X),
	write("\nCheck"),
	check_parser,!,
	write("\nGenerate domain definitions"),
	newext(FILENAME,dom,DOMFILENAME),
	openwrite(outfile,DOMFILENAME),
	writedevice(outfile),
	gendomaindef,
	closefile(outfile),
	write("\nGenerate parse predicates"),
	newext(FILENAME,par,PREDFILENAME),
	openwrite(outfile,PREDFILENAME),
	writedevice(outfile),
	genparser,
	closefile(outfile),
	write("\nParser generated."),
	clear.
  parse:-
	beep,
	write("\n>> Parsing aborted"),
	clear.

  pdwaction(1,0):-
	shiftwindow(OLD),shiftwindow(3),
	parse,
	shiftwindow(OLD),
	refreshstatus.
  pdwaction(2,0):-
	filename(FILE),
	newext(FILE,par,NEWNAME),
	file_str(NEWNAME,TXT),!,
	makewindow(1,7,0,"",0,0,25,80),
	editmsg(TXT,_,"Generated parser",NEWNAME,"",0,"",_),
	removewindow,
	refreshstatus.
  pdwaction(2,0):-refreshstatus.
  pdwaction(3,0):-
	shiftwindow(OLD),shiftwindow(1),
	source(TXT),
	editmsg(TXT,TXT1,"","","",0,"",RET),
	shiftwindow(OLD),
	refreshstatus,
	chksure(RET,TXT1),!,
	change(source(TXT1)),
	refreshsource.
  pdwaction(3,0):-refreshstatus.
  pdwaction(4,1):-
	readfilename(5,40,66,66,grm,"",NEW),
	change(filename(NEW)),
	file_str(NEW,NEWSOURCE),!,
	change(source(NEWSOURCE)),
	refreshsource,
	refreshstatus.
  pdwaction(4,1).
  pdwaction(4,2):-
	source(SOURCE),
	filename(OLD),
	readfilename(5,40,66,66,grm,OLD,NEW),
	change(filename(NEW)),
	file_str(NEW,SOURCE),
	refreshstatus,!.
  pdwaction(4,2).
  pdwaction(4,3):-setdir(5,40,66,66).
  pdwaction(4,4):-system("").
  pdwaction(5,0):-
	lineinput(5,70,40,66,66,"Are you sure (y/n) ? ","",ANS),!,
	upper_lower(ANS,ANS1),
	ANS1><"y".
  pdwaction(5,0).


GOAL
/*
          1         2         3         4         5         6         7
01234567890123456789012345678901234567890123456789012345678901234567890123456789
  Generate parser      Display parser      Edit grammar     Files     Quit
*/
  makewindow(3,116,116,"Messages",14,0,10,40),
  makewindow(1,23,23,"Edit",3,0,21,80),
  makestatus(112," Select with arrows or use first upper case letter"),
  pulldown(66,
	  [ curtain(2,"Generate parser",[]),
	    curtain(23,"Display parser",[]),
	    curtain(43,"Edit grammar",[]),
	    curtain(61,"Files",["Load","Save","Dir"]),
            curtain(71,"Quit",[])
          ],_,_),
  removestatus,removewindow,removewindow.

/* Initial values in the database */

CLAUSES
  filename("work.grm").
  source("").
  insmode.
