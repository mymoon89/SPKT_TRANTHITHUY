DOSSEG
.model  small
.code
        org    100h
main    proc
        mov    dx,offset message
        mov    ah,9
        int    21h
        mov    ah,8
        int    21h
        mov    ax,4c00h
        int    21h
main    endp
;
message db      'Chao ban ! Ban da dich thanh cong chuong trinh .COM.',13,10,'$'
;
        end    main
