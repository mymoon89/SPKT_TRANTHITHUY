/*giai phuong trinh bac nhat*/
predicates
	
	nhap(real,real)
	
clauses
	nhap(A,B):-
		write("Phuong trinh co nghiem:"),
		X=-B/A,write(X).
	