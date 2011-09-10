code    segment para public 'code'
        assume  cs:code,ds:code,ss:code
        org     100h
main    proc
        mov     al,char
        and     al,0Fh
        mov     bx,offset h_table
        xlat
        mov     ah,2
        mov     dl,al
        int     21h
        int     20h
main    endp
;
        org     140h
char    db      ?
        org     180h
h_table db      '0123456798ABCDEF'
;
code    ends
        end     main
