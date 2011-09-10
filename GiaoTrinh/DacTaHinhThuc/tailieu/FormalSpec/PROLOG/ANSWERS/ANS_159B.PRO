/*
   Turbo Prolog 2.0, Answer to second Exercise on page 159.
   
   Copyright (c) 1986, 88 by Borland International, Inc
*/

Domains
  file = infile; outfile
  
Predicates
  nondeterm repeat
  run
  copy_file
  exist_original ( string )
  exist_copy ( string )
  process_ans ( char, string )
  get_filename ( string, string )
  
Clauses
  repeat.  repeat :- repeat.      
  
  run :-
    	makewindow(1,2,3," Copy File ",0,0,25,80) ,
    	repeat ,
    	  cursor(2,2) ,
    	  write("Enter the name of the file you wish to copy: ") ,
    	  readln(File_in) ,
    	exist_original(File_in) ,
    	repeat ,
    	  cursor(4,2) ,
    	  write("Enter the name of the file you wish to copy to: ") ,
    	  readln(File_out) ,
     	exist_copy(File_out) ,
    	openread(infile, File_in) ,
    	openwrite(outfile, File_out) ,
    	readdevice(infile) ,
    	write("\n  File being copied...\n") ,
    	writedevice(outfile) ,
    	copy_file ,
    	closefile(infile) ,
    	closefile(outfile) ,
    	readdevice(keyboard) ,
    	writedevice(screen) ,
    	write("\n  The eagle has landed...\n" ,
    	      "  File successfully copied (press a key).\n\n") ,
    	readchar(_).

/*
 * Be sure the file to copy exists.
 */    	
  exist_original(File) :-
  	existfile(File), !.
  exist_original(_) :-
  	beep ,
  	write("\n  The file you wish to copy does not exist!\n" ,
  	      "  Do you wish to continue? (Y/N): ") ,
  	readchar(Ans) ,
  	write(Ans), nl ,
  	clearwindow,
  	upper_lower(Ans,'n') ,
  	exit.
  	
/*
 * Be sure the file to copy to does not exist.
 */
  exist_copy(File) :-
  	not( existfile(File) ), !.
  exist_copy(File) :-
  	beep ,
  	write("  The file you wish to copy to already exists.\n") ,
  	repeat ,
  	write("  Do you wish to Erase it or Copy it to a .BAK file?\n" ,
  	      "   (E\\C) : ") ,
  	readchar(Ans) , 
  	upper_lower(Ans1, Ans) ,
  	write(Ans1), nl ,
  	process_ans(Ans1, File).
  	
  process_ans('E', File) :-
  	deletefile(File),!.
  process_ans('C', File) :-
  	get_filename(File, Filename) ,
  	concat(Filename, ".BAK", Filename1) ,
  	renamefile(File, Filename1), !.
  process_ans(_, _) :- 
  	write("  Not a valid response!\n\n"), fail.

/*
 * Parse filename from path and file extension.
 */   	  	
  get_filename(File, File) :-
  	fronttoken(File, _, ""), !.
  get_filename(File, Filename) :-
  	fronttoken(File, FileName, Rest) ,
  	fronttoken(Rest, ".", _), !.
  get_filename(File, Filename) :-
  	fronttoken(File, _, F1) ,
  	get_filename(F1, Filename).

/*
 * Once the proper files are opened for reading 
 *  and writing, copying the files is made easy.
 */  	
  copy_file :-
  	repeat ,
  	readchar(C) ,
  	write(C) ,
  	eof(infile).	% This is a failing condition that
  			%  succeeds when the task is done.

GOAL
  run.  	
  