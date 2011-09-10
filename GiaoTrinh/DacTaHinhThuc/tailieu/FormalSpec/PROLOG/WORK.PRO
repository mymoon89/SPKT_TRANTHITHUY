
trace
domains
human,mortal=symbol
predicates
is(symbol,symbol)
clauses
is(X,mortal):-is(X,human).
is("Socrates",human).
goal
is(X,Y),
	write(X," is ",Y)