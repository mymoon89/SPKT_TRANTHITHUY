clauses
sl_ht(X,Y) :- sl_ht1(X,Y).

sl_ht(DE,dongngu(X,N,FS1)) :-
     sukien(DE,dongngu(X,N,FS2)),thuoc(FS1,FS2).

sl_ht(DE,dongngu(ptruoc(X),N,FS1)) :-
     ss(X),sukien(DE,dongngu(ptruoc(Y),N,FS2)),ss(Y),X<>Y,thuoc(FS1,FS2).

sl_ht(DE,dongngu(ptruoc(X),N,FS)) :-
     fd(X),sukien(DE,dongngu(ptruoc(Y),N,FS)),fd(Y),X<>Y.

sl_ht(DE,dongngu(ptruoc(X),N,FS1)) :-
     ss(X),sukien(DE,dongngu(ptruoc(Y),N,FS2)),md_tg(Y),thuoc(FS1,FS2).

sl_ht(DE,dongngu(none,N,FS1)) :-
     sukien(DE,dongngu(ptruoc(Y),N,FS2)),md_tg(Y),thuoc(FS1,FS2).

sl_ht(DE,dongngu(none,N,FS1)) :-
     sukien(DE,dongngu(ptruoc(Y),N,FS2)),ss(Y),thuoc(FS1,FS2).

sl_ht(DE,dongngu(ptruoc(X),N,FS1)) :-
     ss(X),sukien(DE,dongngu(none,N,FS2)),thuoc(FS1,FS2).

sl_ht(danhngu(none,none,none,DTR,"",none,""),dongngu(X,N,FS1)) :-
     nguoi(DTR,S),giong(S,X1),sukien(danhngu(none,none,none,X1,"",X2,X3),dongngu(X,N,FS2)),
     chdi(X2,X3),thuoc(FS1,FS2).

sl_ht(danhngu(none,none,none,DTR,"",none,""),dongngu(ptruoc(X),N,FS1)) :-
     nguoi(DTR,S),giong(S,X1),ss(X),sukien(danhngu(none,none,none,X1,"",X2,X3),dongngu(ptruoc(Y),N,FS2)),
     chdi(X2,X3),ss(Y),X<>Y,thuoc(FS1,FS2).

sl_ht(danhngu(none,none,none,DTR,"",none,""),dongngu(ptruoc(X),N,FS)) :-
     nguoi(DTR,S),giong(S,X1),fd(X),sukien(danhngu(none,none,none,X1,"",X2,X3),dongngu(ptruoc(Y),N,FS)),
     chdi(X2,X3),fd(Y),X<>Y.

sl_ht(danhngu(none,none,none,DTR,"",none,""),dongngu(ptruoc(X),N,FS1)) :-
     nguoi(DTR,S),giong(S,X1),ss(X),sukien(danhngu(none,none,none,X1,"",X2,X3),dongngu(ptruoc(Y),N,FS2)),
     chdi(X2,X3),md_tg(Y),thuoc(FS1,FS2).

sl_ht(danhngu(none,none,none,DTR,"",none,""),dongngu(none,N,FS1)) :-
     nguoi(DTR,S),giong(S,X1),sukien(danhngu(none,none,none,X1,"",X2,X3),dongngu(ptruoc(Y),N,FS2)),
     chdi(X2,X3),md_tg(Y),thuoc(FS1,FS2).

sl_ht(danhngu(none,none,none,DTR,"",none,""),dongngu(none,N,FS1)) :-
    nguoi(DTR,S),giong(S,X1),sukien(danhngu(none,none,none,X1,"",X2,X3),dongngu(ptruoc(Y),N,FS2)),
     chdi(X2,X3),ss(Y),thuoc(FS1,FS2).

sl_ht(danhngu(none,none,none,DTR,"",none,""),dongngu(ptruoc(X),N,FS1)) :-
     nguoi(DTR,S),giong(S,X1),ss(X),sukien(danhngu(none,none,none,X1,"",X2,X3),dongngu(none,N,FS2)),
     chdi(X2,X3),thuoc(FS1,FS2).

sl_ht(DE,tinhngu(ptruoc(X),T,FS)) :- ss(X),sukien(DE,tinhngu(ptruoc(Y),T,FS)),ss(Y).

sl_ht(DE,tinhngu(ptruoc(X),T,FS)) :- fd(X),sukien(DE,tinhngu(ptruoc(Y),T,FS)),fd(Y).

sl_ht(DE,tinhngu(ptruoc(X),T,none)) :- ss(X),sukien(DE,tinhngu(ptruoc(Y),T,none)),md1(Y).

sl_ht(DE,tinhngu(none,T,none)) :- sukien(DE,tinhngu(ptruoc(X),T,none)),md1(X).

sl_ht(DE,tinhngu(none,T,FS)) :- sukien(DE,tinhngu(ptruoc(X),T,FS)),ss(X).

sl_ht(DE,tinhngu(ptruoc(X),T,FS)) :- ss(X),sukien(DE,tinhngu(none,T,FS)).

sl_ht(danhngu(none,none,none,DTR,"",none,""),tinhngu(ptruoc(X),T,FS)) :-
     nguoi(DTR,S),giong(S,X1),ss(X),sukien(danhngu(none,none,none,X1,"",X2,X3),tinhngu(ptruoc(Y),T,FS)),
     chdi(X2,X3),ss(Y).

sl_ht(danhngu(none,none,none,DTR,"",none,""),tinhngu(ptruoc(X),T,FS)) :-
     nguoi(DTR,S),giong(S,X1),fd(X),sukien(danhngu(none,none,none,X1,"",X2,X3),tinhngu(ptruoc(Y),T,FS)),
     chdi(X2,X3),fd(Y).

sl_ht(danhngu(none,none,none,DTR,"",none,""),tinhngu(ptruoc(X),T,none)) :-
     nguoi(DTR,S),giong(S,X1),ss(X),sukien(danhngu(none,none,none,X1,"",X2,X3),tinhngu(ptruoc(Y),T,none)),
     chdi(X2,X3),md1(Y).

sl_ht(danhngu(none,none,none,DTR,"",none,""),tinhngu(none,T,none)) :-
     nguoi(DTR,S),giong(S,X1),sukien(danhngu(none,none,none,X1,"",X2,X3),tinhngu(ptruoc(X),T,none)),
     chdi(X2,X3),md1(X).

sl_ht(danhngu(none,none,none,DTR,"",none,""),tinhngu(none,T,FS)) :-
     nguoi(DTR,S),giong(S,X1),sukien(danhngu(none,none,none,X1,"",X2,X3),tinhngu(ptruoc(X),T,FS)),
     chdi(X2,X3),ss(X).

sl_ht(danhngu(none,none,none,DTR,"",none,""),tinhngu(ptruoc(X),T,FS)) :-
     nguoi(DTR,S),giong(S,X1),ss(X),sukien(danhngu(none,none,none,X1,"",X2,X3),tinhngu(none,T,FS)),
     chdi(X2,X3).

sl_ht(DE,dongngu(none,N,FS1)) :-
     sukien(DE,dongngu(tam1(ptruoc(Y),ptruoc(Y1)),N,FS2)),
     fd(Y),fd(Y1),thuoc(FS1,FS2).

sl_ht(DE,dongngu(ptruoc(X),N,FS1)) :-
     ss(X),sukien(DE,dongngu(tam1(ptruoc(Y),ptruoc(Y1)),N,FS2)),
     fd(Y),fd(Y1),thuoc(FS1,FS2).

sl_ht(danhngu(none,none,none,DTR,"",none,""),dongngu(none,N,FS1)) :-
     nguoi(DTR,S),giong(S,X1),sukien(danhngu(none,none,none,X1,"",X2,X3),dongngu(tam1(ptruoc(Y),ptruoc(Y1)),N,FS2)),
     chdi(X2,X3),fd(Y),fd(Y1),thuoc(FS1,FS2).

sl_ht(danhngu(none,none,none,DTR,"",none,""),dongngu(ptruoc(X),N,FS1)) :-
     nguoi(DTR,S),giong(S,X1),ss(X),sukien(danhngu(none,none,none,X1,"",X2,X3),dongngu(tam1(ptruoc(Y),ptruoc(Y1)),N,FS2)),
     chdi(X2,X3),fd(Y),fd(Y1),thuoc(FS1,FS2).

sl_ht(DE,tinhngu(none,T,FS)) :-
     sukien(DE,tinhngu(tam1(ptruoc(Y),ptruoc(Y1)),T,FS)),fd(Y),fd(Y1).

sl_ht(DE,tinhngu(ptruoc(X),T,FS)) :-
     ss(X),sukien(DE,tinhngu(tam1(ptruoc(Y),ptruoc(Y1)),T,FS)),fd(Y),fd(Y1).

sl_ht(danhngu(none,none,none,DTR,"",none,""),tinhngu(none,T,FS)) :-
     nguoi(DTR,S),giong(S,X1),sukien(danhngu(none,none,none,X1,"",X2,X3),tinhngu(tam1(ptruoc(Y),ptruoc(Y1)),T,FS)),
     chdi(X2,X3),fd(Y),fd(Y1).

sl_ht(danhngu(none,none,none,DTR,"",none,""),tinhngu(ptruoc(X),T,FS)) :-
     nguoi(DTR,S),giong(S,X1),ss(X),sukien(danhngu(none,none,none,X1,"",X2,X3),tinhngu(tam1(ptruoc(Y),ptruoc(Y1)),T,FS)),
     chdi(X2,X3),fd(Y),fd(Y1).
