clauses
 sl_ht1(DE,dongngu(X,N,FS1)) :-
   sukien(danhngu(tongthe(Y),S,D,DT,K,
   handinh(danhngu1(none,none,none,H,"","","")),C),dongngu(X,N,FS2)),
   tt1(Y),assertz(sl(S)),assertz(dv(D)),thuoc(FS1,FS2),
   sukien(DE,dongngu(none,nhan("la",doituong(danhngu1(none,S1,D1,DT,K,H,C))),[])),
   sl(S1),dv(D1),retract(sl(S)),retract(dv(D)).
   
sl_ht1(DE,dongngu(X,N,FS1)) :-
   sukien(danhngu(tongthe(Y),S,D,DT,K,none,C),dongngu(X,N,FS2)),
   tt1(Y),assertz(sl(S)),assertz(dv(D)),thuoc(FS1,FS2),
   sukien(DE,dongngu(none,nhan("la",doituong(danhngu1(none,S1,D1,DT,K,"",C))),[])),
   sl(S1),dv(D1),retract(sl(S)),retract(dv(D)).   

 sl_ht1(DE,dongngu(ptruoc(X),N,FS1)) :-
   fd(X),sukien(danhngu(tongthe(Y),S,D,DT,K,
   handinh(danhngu1(none,none,none,H,"","","")),C),dongngu(ptruoc(X0),N,FS2)),
   fd(X0),X<>X0,tt1(Y),assertz(sl(S)),assertz(dv(D)),thuoc(FS1,FS2),
   sukien(DE,dongngu(none,nhan("la",doituong(danhngu1(none,S1,D1,DT,K,H,C))),[])),
   sl(S1),dv(D1),retract(sl(S)),retract(dv(D)).
   
 sl_ht1(DE,dongngu(ptruoc(X),N,FS1)) :-
   fd(X),sukien(danhngu(tongthe(Y),S,D,DT,K,none,C),dongngu(ptruoc(X0),N,FS2)),
   fd(X0),X<>X0,tt1(Y),assertz(sl(S)),assertz(dv(D)),thuoc(FS1,FS2),
   sukien(DE,dongngu(none,nhan("la",doituong(danhngu1(none,S1,D1,DT,K,"",C))),[])),
   sl(S1),dv(D1),retract(sl(S)),retract(dv(D)).   

 sl_ht1(DE,dongngu(ptruoc(X),N,FS1)) :-
   ss(X),sukien(danhngu(tongthe(Y),S,D,DT,K,
   handinh(danhngu1(none,none,none,H,"","","")),C),dongngu(ptruoc(X0),N,FS2)),
   ss(X0),X<>X0,tt1(Y),assertz(sl(S)),assertz(dv(D)),thuoc(FS1,FS2),
   sukien(DE,dongngu(none,nhan("la",doituong(danhngu1(none,S1,D1,DT,K,H,C))),[])),
   sl(S1),dv(D1),retract(sl(S)),retract(dv(D)).
   
 sl_ht1(DE,dongngu(ptruoc(X),N,FS1)) :-
   ss(X),sukien(danhngu(tongthe(Y),S,D,DT,K,none,C),dongngu(ptruoc(X0),N,FS2)),
   ss(X0),X<>X0,tt1(Y),assertz(sl(S)),assertz(dv(D)),thuoc(FS1,FS2),
   sukien(DE,dongngu(none,nhan("la",doituong(danhngu1(none,S1,D1,DT,K,"",C))),[])),
   sl(S1),dv(D1),retract(sl(S)),retract(dv(D)).  

 sl_ht1(DE,dongngu(ptruoc(X),N,FS1)) :-
   ss(X),sukien(danhngu(tongthe(Y),S,D,DT,K,
   handinh(danhngu1(none,none,none,H,"","","")),C),dongngu(ptruoc(X0),N,FS2)),
   md_tg(X0),tt1(Y),assertz(sl(S)),assertz(dv(D)),thuoc(FS1,FS2),
   sukien(DE,dongngu(none,nhan("la",doituong(danhngu1(none,S1,D1,DT,K,H,C))),[])),
   sl(S1),dv(D1),retract(sl(S)),retract(dv(D)).
   
sl_ht1(DE,dongngu(ptruoc(X),N,FS1)) :-
   ss(X),sukien(danhngu(tongthe(Y),S,D,DT,K,none,C),dongngu(ptruoc(X0),N,FS2)),
   md_tg(X0),tt1(Y),assertz(sl(S)),assertz(dv(D)),thuoc(FS1,FS2),
   sukien(DE,dongngu(none,nhan("la",doituong(danhngu1(none,S1,D1,DT,K,"",C))),[])),
   sl(S1),dv(D1),retract(sl(S)),retract(dv(D)).   

 sl_ht1(DE,dongngu(none,N,FS1)) :-
   sukien(danhngu(tongthe(Y),S,D,DT,K,
   handinh(danhngu1(none,none,none,H,"","","")),C),dongngu(ptruoc(X0),N,FS2)),
   md_tg(X0),tt1(Y),assertz(sl(S)),assertz(dv(D)),thuoc(FS1,FS2),
   sukien(DE,dongngu(none,nhan("la",doituong(danhngu1(none,S1,D1,DT,K,H,C))),[])),
   sl(S1),dv(D1),retract(sl(S)),retract(dv(D)).
   
sl_ht1(DE,dongngu(none,N,FS1)) :-
   sukien(danhngu(tongthe(Y),S,D,DT,K,none,C),dongngu(ptruoc(X0),N,FS2)),
   md_tg(X0),tt1(Y),assertz(sl(S)),assertz(dv(D)),thuoc(FS1,FS2),
   sukien(DE,dongngu(none,nhan("la",doituong(danhngu1(none,S1,D1,DT,K,"",C))),[])),
   sl(S1),dv(D1),retract(sl(S)),retract(dv(D)).   

sl_ht1(DE,dongngu(none,N,FS1)) :-
   sukien(danhngu(tongthe(Y),S,D,DT,K,
   handinh(danhngu1(none,none,none,H,"","","")),C),dongngu(ptruoc(X0),N,FS2)),
   ss(X0),tt1(Y),assertz(sl(S)),assertz(dv(D)),thuoc(FS1,FS2),
   sukien(DE,dongngu(none,nhan("la",doituong(danhngu1(none,S1,D1,DT,K,H,C))),[])),
   sl(S1),dv(D1),retract(sl(S)),retract(dv(D)).
   
sl_ht1(DE,dongngu(none,N,FS1)) :-
   sukien(danhngu(tongthe(Y),S,D,DT,K,none,C),dongngu(ptruoc(X0),N,FS2)),
   ss(X0),tt1(Y),assertz(sl(S)),assertz(dv(D)),thuoc(FS1,FS2),
   sukien(DE,dongngu(none,nhan("la",doituong(danhngu1(none,S1,D1,DT,K,"",C))),[])),
   sl(S1),dv(D1),retract(sl(S)),retract(dv(D)).   

   sl_ht1(DE,dongngu(ptruoc(X),N,FS1)) :-
   ss(X),sukien(danhngu(tongthe(Y),S,D,DT,K,
   handinh(danhngu1(none,none,none,H,"","","")),C),dongngu(none,N,FS2)),
   tt1(Y),assertz(sl(S)),assertz(dv(D)),thuoc(FS1,FS2),
   sukien(DE,dongngu(none,nhan("la",doituong(danhngu1(none,S1,D1,DT,K,H,C))),[])),
   sl(S1),dv(D1),retract(sl(S)),retract(dv(D)).
   
sl_ht1(DE,dongngu(ptruoc(X),N,FS1)) :-
   ss(X),sukien(danhngu(tongthe(Y),S,D,DT,K,none,C),dongngu(none,N,FS2)),
   tt1(Y),assertz(sl(S)),assertz(dv(D)),thuoc(FS1,FS2),
   sukien(DE,dongngu(none,nhan("la",doituong(danhngu1(none,S1,D1,DT,K,"",C))),[])),
   sl(S1),dv(D1),retract(sl(S)),retract(dv(D)).   
