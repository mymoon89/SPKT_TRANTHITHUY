#include "util.h"
#include "copyright.h"
int
main()
{  
  char a[2];
  print("\nThis is help program.\n~");

  print("\nint CreateFile(char *filename): create a file with the input filename~");
  print("\n\t Return 0 for success, -1 for fail~");

  print("\n\nOpenFileID Open(char *name,int type): open a file with name and type inputed~");  
  print("\n\tReturn OpenFileID for successful. Otherwise return -1~");

  print("\n\nint Read(char *buffer,int charcount,OpenFileID): read a file with the input FileID and charcount~");  
  print("\n\tReturn number of bytes read = charcount bytes or less than if it reach to the end of file. Buffer contain the content of file. If read fail return -1~");

  print("\n\nint Write(char *buffer,int bufsize,OpenFileID): write buffer to a file with the input FileID, buffer and size of buffer~");
  print("\n\tReturn number of bytes wrote. If write fail return -1~");
  
  print("\n\nint Close(OpenFileID): close a file with the input FileID~");
  print("\n\tReturn 0 success, -1 - fail~");

  print("\n\nint Seek(int offset,OpenFileID): seek to the offset of the input FileID ~");
  print("\n\tReturn current offset. If seek fail return -1 ~");

  print("\n Press Enter to exit...~");

  Read(a,1,0);
  Halt();
}
