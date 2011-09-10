/*
   Turbo Prolog 2.0 Chapter 14, Example Program 6
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
goal
   dir("", "*.*", FileName),
   file_str(FileName, TextStr),
   str_len(TextStr, Len),
   str_int(LenStr, Len),
   concat("Size ", LenStr, StrSize),
   InitPos = 3,
   makewindow(1, 7, 7, "Edit Example", 3, 3, 20, 70),
   edit(TextStr, OutStringArg, StrSize, FileName,
       "After editing, press F10 or Esc to exit this editor",
        InitPos, "prolog.err", 1, 1, 1, 1, RetPos, RetStatus),
        
   writef("edited text:\n\n%\n", OutStringarg),
   writef("\ncursor position at exit = %", RetPos),
   writef("\nexit with (1 or 0): % \n", RetStatus),
   write("\n1 = Esc"),
   write("\n0 = F10").
