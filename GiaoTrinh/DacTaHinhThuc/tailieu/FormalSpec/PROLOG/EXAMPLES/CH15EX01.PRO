/*
   Turbo Prolog 2.0 Chapter 15, Example Program 1
   
   Copyright (c) 1986, 88 by Borland International, Inc
   
*/
   
domains
   db_selector = dba1 ; dba2
   customers = customer(customer_name, address)
   parts = part(part_name, ID, customer_name)
   customer_name, part_name = symbol
   ID = integer
   address = string

predicates
   access

goal
   % create the databases dba1 and dba2
   db_create(dba1, "dd1", in_memory),
   db_create(dba2, "dd1.bin", in_file),

   % insert customer facts into chain1 in dba1
   chain_insertz(dba1, chain1, customers,
   	   customer("Joe Fraser","123 West Side"), _),
   chain_insertz(dba1, chain1, customers,
	   customer("John Smith","31 East Side"), _),
   chain_insertz(dba1, chain1, customers,
	   customer("Diver Dan","1 Water Way"), _),
   chain_insertz(dba1, chain1, customers,
	   customer("Dave Devine","123 Heaven Street"), _),

   % insert parts facts into chain2 in dba2
   chain_insertz(dba2, chain2, parts, part("wrench", 231, "John Smith"), _),
   chain_insertz(dba2, chain2, parts, part("knife", 331, "Diver Dan"), _),
   access,
   db_close(dba1), db_close(dba2),
   db_delete("dd1", in_memory),
   db_delete("dd1.bin", in_file).

clauses
   access:-
      chain_terms(dba1, chain1, customers, customer(Name, ADDR), _),
      chain_terms(dba2, chain2, parts, part(Part, Id, Name), _),
      write("send ", Part, " part num ", Id, " to ", Addr), nl,
      fail.
   access. 
