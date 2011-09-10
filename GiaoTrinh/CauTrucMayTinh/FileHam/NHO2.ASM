DOSSEG
.model  small
.code
        org    100h
start:  jmp    main
;
char     db      ?
message1 db      'Ban hay nhap vao mot ky tu lon : $'
message2 db      'Ky tu da duoc doi ra chu nho   : $'
crlf     db      13,10,'$'
;
main    proc
        mov    dx,offset message1
        mov    ah,9
        int    21h
        mov    ah,1
        int    21h
        mov    bl,20h
        or     al,bl
        mov    char,al
        mov    dx,offset crlf
        mov    ah,9
        int    21h
        mov    dx,offset message2
        mov    ah,9
        int    21h
        mov    dl,char
        mov    ah,2
        int    21h
        mov    dx,offset crlf
        mov    ah,9
        int    21h
        mov    ax,4c00h
        int    21h
main    endp
        end    start
