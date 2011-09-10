#!/bin/bash

set $(date)
thu=$1
ngay=$3
thang=$2
nam=$6
gio=$4

case $thu in
	"Mon") myDay="Thu Hai" ;;
	"Tue") myDay="Thu Ba" ;;
	"Wed") myDay="Thu Tu" ;;
	"Thu") myDay="Thu Nam" ;;
	"Fri") myDay="Thu Sau" ;;
	"Sat") myDay="Thu Bay" ;;
	*) myDay="Chu Nhat";;
esac

case $thang in
	"Jan") myMonth="1" ;;
	"Feb") myMonth="2" ;;
	"Mar") myMonth="3" ;;
	"Apr") myMonth="4" ;;
	"May") myMonth="5" ;;
	"Jun") myMonth="6" ;;
	"Jul") myMonth="7" ;;
	"Aug") myMonth="8" ;;
	"Sep") myMonth="9" ;;
	"Oct") myMonth="10" ;;
	"Nov") myMonth="11" ;;
	"Dec") myMonth="12" ;;
esac

myhour=${gio:0:2}

if [ $myhour -lt 12 ]; then
	buoi="sang"
else 
	if [ $myhour -ge 12 ]&&[ $myhour -lt 18 ]; then
		buoi="chieu"
	else
		buoi="toi"
	fi
fi
if [ $myhour -ge 13 ]; then
	let "myhour1=$myhour-12"
else
	myhour1=$myhour
fi

echo $myDay, ngay $ngay thang $myMonth nam $nam
echo Bay gio la: $myhour1 gio ${gio:3:2} phut ${gio:6:2} giay $buoi
exit 0
