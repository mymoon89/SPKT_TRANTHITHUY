        title   Chuong trinh . . .
code    segment para public 'code'
        assume  cs:code,ds:code,ss:code
        org     100h
start:  jmp     main
; vung khai bao du lieu
bien    db      0
; vung khai bao chuong trinh con
ctc1    proc
        ret
ctc1    endp
; . . .
;
; Chuong trinh chinh
main    proc
        call    ctc1
        ;
        ; ket thuc thi hanh chuong trinh chinh va tro ve DOS
        mov     ax,4c00h
        int     21h
main    endp
        ; ket thuc khai bao doan code
code    ends
        ; ket thuc khai bao chuong trinh
        end     start
        
