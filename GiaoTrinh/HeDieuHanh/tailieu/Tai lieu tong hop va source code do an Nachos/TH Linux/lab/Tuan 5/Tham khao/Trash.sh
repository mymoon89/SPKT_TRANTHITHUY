# kiem tra thu muc trash co ton tai trong HOME. Neu khong co thi
# tao ra thu muc trash
if [ ! -e ~/trash ] ; then
   mkdir ~/trash
fi

# kiem tra so tham so nhap vao co bang 0 hay khong
# Neu bang 0 thi hien giup do
if [ $# -eq 0 ] ; then
   echo "Hay nhap vao tap tin hoac thu muc can xoa"
   exit 0
fi

# Kiem tra tham so option (tham so thu nhat) neu bang -e
# thi remove tat ca cac file trong thu muc trash
if [ "$1" = "-e" ] && [ $# -eq 1 ]; then
   set $(ls ~/trash)
   for file in $* ; do
       rm -f "$file"
   done
   exit 0
fi

# Neu tham so option la -u thi phuc hoi tat ca cac file trong
# thu muc trash vao thu muc hien hanh
if [ "$1" = "-u" ] && [ $# -eq 1 ]; then
   set $(ls ~/trash)
   if [ $# -ge 1 ]; then
      for file in $* ; do
         if [ -e "~/trash/$file" ] ; then
	    mv ~/trash/$file ~
	 fi
      done
      exit 0
   fi
fi
# Neu trong so tham so dong lenh la > 1. Thi kiem tra va di chuyen
# cac file vao thu muc trash
let "count=0"
for file in $* ; do
    if [ -e "$file" ] && [ -f "$file" ] ; then
         mv $file ~/trash
	 echo "$file da duoc di chuyen vao thu muc trash"
	 let "count=$count+1"
    fi
done
echo "Tong so file duoc di chuyen : $count"
exit 0