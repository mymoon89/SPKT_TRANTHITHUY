        Title   chuong trinh . . . . .
; doan du lieu
data    segment para public 'data'
        ; cac chi thi khai bao du lieu (hang, bien, cau truc,mau tin)
bien    db      0
data    ends
; doan chong
stack   segment stack 'stack'
        db      100h DUP (0)
stack   ends
; doan chuong trinh
code    segment para public 'code'
        assume  cs:code,ds:data,ss:stack
        ; Khai bao cac chuong trinh con
ctc1    proc
        ret
ctc1    endp
        ; . . .
        ;
; Chuong trinh chinh
main    proc
        call    ctc1
        ;
        ; ket thuc thi hanh chuong trinh va tro ve DOS
        mov     ax,4c00h
        int     21h
main    endp
        ; dong doan code
code    ends
        ; ket thuc khai bao chuong trinh
        end     main
