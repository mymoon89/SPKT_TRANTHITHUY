DOSSEG
.model     small
.code
         org    100h
main     proc
         mov    ax,600h
         mov    bh,7
         mov    ch,0
         mov    cl,0
         mov    dh,24
         mov    dl,79
         int    10h
         mov    ah,2
         mov    dh,0
         mov    dl,0
         mov    bh,0
         int    10h
         int    20h
main     endp
;
         end    main