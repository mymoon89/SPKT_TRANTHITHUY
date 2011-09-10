/*
   Turbo Prolog 2.0 Reference Guide Chapter 3, Example Program 8
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
#define	alloc_gstack walloc
#define	listfno  1
#define	nilfno   2

void *alloc_gstack(unsigned);

typedef struct ilist {
   char Functor;
   int Value;
   struct ilist *Next;
} IntList;

int ListToArray(IntList *List,int **ResultArray)
{   /* Convert a list to an array placed on the global stack */
   IntList *SaveList = List;
   int *Array;
   int  i = 0;
  
 /* Count the number of elements in the list */
   for(i=0; List->Functor==listfno; List=List->Next)
      i++;
 
   Array = alloc_gstack(i*sizeof(int));  /* Allocate the needed
memory */
   List = SaveList; /* Transfer the elements from the list to the
array */

   for(i=0; List->Functor==listfno; List=List->Next)
      Array[i++]=List->Value;

   *ResultArray=Array;
   return(i);
}

ArrayToList(int Array[],int n,IntList **List) /* Convert an array
to a list */
{
   int i;

   for (i=0; i<n; i++)  /* Allocate a record for each element */
   {
      IntList *p=*List=alloc_gstack(sizeof(IntList));
      p->Functor=listfno;
      p->Value=Array[i];
      List=&(*List)->Next;
   }

   {  /* Allocate the last record in the list */
      IntList *p=*List=alloc_gstack(sizeof(char));
      p->Functor=nilfno;
   }
}

inclist_0(IntList *InList,IntList **OutList)
{  /* Increment all values in a list */
   int i, n, *Array;
   n=ListToArray(InList,&Array);
   for(i=0; i<n; i++) Array[i]++;
   ArrayToList(Array,n,OutList);
}
