/************************************************************************
            Turbo Prolog Toolbox
            (C) Copyright 1987 Borland International.
            
			GRAPHIC-MODULE					
		    Interface to PC PAINT V1.0				
									
************************************************************************/


#define	CHAR	char
#define	INT	int

/* Action to do when a file does not exist */
#define	nomess	1

/* Open mode for disk file */
#define	read_f		0
#define	write_f		1


extern	INT	background;	/* Background color in graphics mode */
extern	INT	palette;	/* Palette in graphic mode            */

extern	CHAR	*alloc();	/* Allocate from GSTACK */
	CHAR	*ptr();


/************************************************************************/
/*	Load PIC File							*/
/* PC-PAINT V1.0 FILE to screen (mode supported is 320*200, 4 colors)	*/
/************************************************************************/
/*	Range for ROWS		: 0-200
	Range for COLUMNS	: 0-320
*/

loadpic_0(fname,row_origin,col_origin, startrow,startcol,noofrow,noofcol)
CHAR *fname;
{ INT fp;
  unsigned seg,off,i;
  CHAR *bufptr,*screenptr;
  INT  bytes_row= noofcol/4;
  INT  file_off, scr_off;
  
  if ((fp=openfile(fname,read_f,nomess))==-1) fail_cc();
  bufptr	= alloc(20000);	/* Allocate on GSTACK */
  readbin(fp,bufptr,19999);		/* Read binary */
  zclose(fp);				/* Close file */
  
  set_PalBackgr(*(bufptr+8020),*(bufptr+8019)); /* Palette and background */
  seg		= *(bufptr+1) + (*(bufptr+2)<<8);
  off		= *(bufptr+3) + (*(bufptr+4)<<8);
  screenptr	= ptr(off,seg);

  for (i=startrow; i<(startrow+noofrow); i++)
    { file_off	= get_fileoff(row_origin + i-startrow,col_origin);
      scr_off	= get_scroff(i,startcol);
      movmem(bufptr+file_off, screenptr+scr_off, bytes_row);
    }
  release(bufptr);			/* Release GSTACK */
}




static get_fileoff(file_row, file_col)
{ if (file_row&1) return(8199+(file_row/2)*80 + file_col/4);
  else return(7+file_row*40 + file_col/4);
}

static get_scroff(scr_row,scr_col)
{ if (scr_row&1) return(0x2000 + (scr_row/2)*80 + scr_col/4);
  else return(scr_row*40 + scr_col/4);
}


static CHAR *ptr(p)
CHAR *p;
{ return(p); }



/************************************************************************/
/*	Save Pic File							*/
/* PC-PAINT V1.0 screen to FILE (mode supported is 320*200, 4 colors)	*/
/************************************************************************/

savepic_0(fname)
CHAR *fname;
{ INT fp;
  unsigned i;
  CHAR *bufptr,*screenptr;
  
  bufptr	= alloc(20000);
  
  *bufptr	= 0xFD;
  *(bufptr+1)	= 0;		/* segment low part */
  *(bufptr+2)	= 0xB8;		/* segment high part*/
  *(bufptr+3)	=		/* offset	    */
  *(bufptr+4)	= 0;
  *(bufptr+5)	= 0;		/* bufsize low part */
  *(bufptr+6)	= 0x40;		/* bufsize high part */
  *(bufptr+8020)= background;
  *(bufptr+8019)= palette;
  screenptr	= ptr(0,0xB800);

  for (i=0; i<100; i++) movmem(screenptr+80*i, bufptr+7+80*i, 80);

  for (i=0; i<100; i++)
    movmem(screenptr+0x2000+80*i, bufptr+8199+80*i, 80);

  if ((fp=openfile(fname,write_f,nomess))==-1) fail_cc(); /* open file */
  writebin(fp,bufptr,8200+80*101);			  /* write binary */
  zclose(fp);
  release(bufptr);
}


