DOSSEG
.model  small
.code
main    proc
        mov    ax,@data
        mov    ds,ax
        mov    dx,offset message
        mov    ah,9
        int    21h
        mov    ah,8
        int    21h
        mov    ax,4c00h
        int    21h
main    endp
.data
message db      'Chao ban !',13,10,'$'
.stack  100h
        end    main
