/*
   Turbo Prolog 2.0 Reference Guide Chapter 2,  Example Program 1
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
constants
  egagraphic = 1
/* Note that ifdef must start in column 1; don't indent it. */
ifdef egagraphic                    /* if egagrphic is defined, use this goal */

goal
  graphics(5, 1, 1),
  write("\nEga Graphics"),
  readchar(_).
/* Note that elsedef must also setart in column 1; don't indent it. */
elsedef                                        /* otherwise, use the next goal */

goal
  graphics(1, 1, 3),
  write("\nCga Graphics"),
  readchar(_).
/* Note that enddef must start in column 1 too; don't indent it */

enddef