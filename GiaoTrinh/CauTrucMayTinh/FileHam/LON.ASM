DOSSEG
.model  small
.code
main    proc
        mov    ax,@data
        mov    ds,ax
        mov    dx,offset message1
        mov    ah,9
        int    21h
        mov    ah,1
        int    21h
        mov    bl,20h
        not    bl
        and    al,bl
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
.data
char     db      ?
message1 db      'Ban hay nhap vao mot ky tu nho : $'
message2 db      'Ky tu da duoc doi ra chu lon   : $'
crlf     db      13,10,'$'
.stack  100h
        end    main
