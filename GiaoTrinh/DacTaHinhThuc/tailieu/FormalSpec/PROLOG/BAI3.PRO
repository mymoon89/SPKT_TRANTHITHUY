domains
	ilist = integer *
	
predicates
	initlist(ilist)
	insert(integer,ilist,ilist)
	inputlist(ilist,integer)
	printlist(ilist)
	tong(ilist,integer)
	tongchan(ilist,integer)
	snt(integer)
	for(integer,integer,integer)
	demnt(ilist,integer)
	kiemtrax(ilist,integer)
	sosanh(integer,integer,integer)
	max(ilist,integer,integer)
	
clauses
	/*----Bai: Nhap phan tu vao danh sach-----*/
	initlist(L):-L=[].
	insert(X,L,[X|L]).
	inputlist(L,N):-N=0,initlist(L).
	inputlist(L,N):-
		N>0,
		write("Nhap phan tu: "),
		readint(X),
		N1=N-1,
		inputlist(L1,N1),
		insert(X,L1,L).
	/*----Bai: In phan tu tu danh sach--------*/
	printlist([]).
	printlist([H|T]):-
		writef("%  ",H),
		printlist(T).
		
	/*----Bai: Tinh tong cac phan tu trong list--*/
	tong([],0).
	tong([H|T],Tong):-tong(T,Tong1),Tong=H+Tong1.
	tong([_|T],Tong):-tong(T,Tong).
	
	/*----Bai: Tinh tong cac phan tu chan-----*/
	tongchan([],0).
	tongchan([H|T],Sum):-tongchan(T,Sum1),
				Sum=((H+1)mod 2)*H+Sum1.
	tongchan([_|T],Sum):-tongchan(T,Sum).
	
	/*----Bai: Dem nguyen to trong DS---------*/
	for(I,N,Kq):-I=N,Kq=1.
	for(I,N,Kq):-I<N,N mod I=0,Kq=0,!.
	for(I,N,Kq):-
		I<N,
		N mod I <>0,
		J=I+1,
		for(J,N,Kq).
	snt(N):-N>=2,for(2,N,Kq),Kq=1.
	demnt([],0).
	demnt([H|T],Dem):-snt(H),demnt(T,Dem1),Dem=1+Dem1.
	demnt([_|T],Dem):-demnt(T,Dem).
	
	/*----Bai: Kiem tra X co trong DS ?-------*/
	kiemtrax([],0).
	kiemtrax([H|_],X):-X=H,write(X," Co trong DS "),!.
	kiemtrax([H|T],X):-X<>H,kiemtrax(T,X).
	kiemtrax([_|_],X):-write(X," Khong co trong DS ").
	
	/*----Bai: Tim phan tu MAX trong DS-------*/
	sosanh(A,B,M):-A>B,M=A.
	sosanh(A,B,M):-A<=B,M=B.
	max([],M,Max):-Max=M.
	max([H|T],M,Max):-sosanh(H,M,M1),max(T,M1,Max1),Max=Max1.
	max([H|T],M,Max):-max(T,M,Max).
goal
	clearwindow,
	write("Nhap so phan tu : "),readint(N),
	inputlist(L,N), nl,write("Danh sach gom: "),nl,
        printlist(L),nl,
        
        tong(L,Tong),
        write("Tong cac phan tu DS : ",Tong),nl,
        
        tongchan(L,Sum),
        write("Tong phan tu chan :",Sum),nl,
        
        demnt(L,Dem),
        write("So luong SNT trong DS: ",Dem),nl,
        
        write("Nhap gia tri X: "), readint(X),nl,
        kiemtrax(L,X),nl,
        
        max(L,0,Max),
        write("Phan tu MAX trong DS: ",Max),nl