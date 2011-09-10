/****************************************************************

     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.

		PIECHART UTILITY
****************************************************************/

DOMAINS
  percent=real
  PieSegment=slice(percent,string,color,color);space
  PieSegmentList=PieSegment*
  Radius=integer
  Angle=real /*in radians*/

PREDICATES
  PieChart(vrow,vcol,vradius,pieSegmentList)
  countslices(pieSegmentList,percent)
  scaleslices(pieSegmentList,real,pieSegmentList)
  drawSliceList(vrow,vcol,vradius,PieSegmentList,degrees)
  drawSlice(vrow,vcol,vradius,degrees,degrees,string,integer,color,color)
  wLabel(vrow,vcol,vradius,angle,string,integer,color)
  changeLblCol(string,real,integer)
  add_lbl_percent(string,percent,string)
  determ_connectline(string,integer,string)

CLAUSES
  countslices([],0):-!.
  countslices([slice(P,_,_,_)|Rest],Total):-!,
  	countSlices(Rest,TotalR),
  	Total=abs(P)+TotalR.
  countslices([_|Rest],Total):-!,
  	countSlices(Rest,TotalR),
  	Total=1+TotalR.	/*1 degree extrace spacing between slices*/

  scaleslices([],_,[]).
  scaleslices([slice(P,L,C1,C2)|Rest],F,[slice(P1,L,C1,C2)|SRest]):-!,
  	P1=F*P,
  	scaleslices(Rest,F,SRest).
  scaleslices([space|Rest],F,[space|SRest]):-!,
  	scaleslices(Rest,F,SRest).
  
  PieChart(Row,Col,Radius,SliceL):-
	countSlices(SliceL,Total),
	F=100/Total,
	scaleslices(SliceL,F,SliceL100),
	DrawSliceList(Row,Col,Radius,SliceL100,0).

  drawSliceList(Row,Col,Radius,[space|RestSlices],StartAngle):-!,
	NextStart=StartAngle+5,
	drawSliceList(Row,Col,Radius,RestSlices,NextStart).

  drawSliceList(Row,Col,Radius,[slice(Percent,Label,Color,FillColor)|RestSlices],StartAngle):-
	Percent>=0,!,
	/*Normal slice*/
	EndAngle=Percent*3.6+StartAngle,
	add_lbl_percent(Label,Percent,Label2),
	determ_connectline(Label2,ConLine,Label3),
	DrawSlice(Row,Col,Radius,StartAngle,EndAngle,Label3,Conline,Color,FillColor),
	DrawSliceList(Row,Col,Radius,RestSlices,EndAngle).

  DrawSliceList(Row,Col,Radius,[slice(Percent,Label,Color,FillColor)|RestSlices],StartAngle):-
	/*Outdented slice*/
	EndAngle=-Percent*3.6+StartAngle,
	Middle=(EndAngle+StartAngle)*0.00872664639,/*(A1+A2)/2 * Phi/180*/
	NewRow=Row-sin(Middle)*Radius*0.2,
	NewCol=Col+cos(Middle)*Radius*0.2,
	add_lbl_percent(Label,Percent,Label2),
	determ_connectline(Label2,ConLine,Label3),
	DrawSlice(NewRow,NewCol,Radius,StartAngle,EndAngle,Label3,ConLine,Color,FillColor),
	DrawSliceList(Row,Col,Radius,RestSlices,EndAngle).
  DrawSLiceList(_,_,_,[],_).

  DrawSlice(Row,Col,Radius,StartAngle,EndAngle,Label,Conline,Color,FillColor):-
	Middle_rad=(EndAngle+StartAngle)*0.00872664639,/*(A1+A2)/2 * Phi/180*/
	Fill=FillColor,
	sector(Row,Col,Radius,1,StartAngle,EndAngle,Color,FillColor,Fill),
	R1=Row,C1=Col,
	wLabel(R1,C1,Radius,Middle_rad,Label,ConLine,Color).

  wLabel(VRow,VCol,Radius,Ang,Label,ConLine,Color):-
	virtual_text(OneR,OneC,1,1),
	SinA=sin(Ang),
	CosA=cos(Ang),
	sign(SinA,SS),
	LblRow=VRow-round(SinA*Radius)-SS*(0.5+abs(SinA))*OneR,
	LblCol=VCol+round(CosA*Radius)-CosA*OneC*1.5,
	virtual_text(LblRow,LblCol,Row,Col),
	changeLblCol(Label,CosA,Delta),
	Col1=Col-Delta,
	max(0,Col1,Col2),
	gwrite(Row,Col2,Label,Color,0),
	Conline>0,!,
	R2=VRow-Radius*SinA,
	C2=VCol+Radius*CosA*0.6,
	line(LblRow,LblCol,R2,C2,Color).
  wLabel(_,_,_,_,_,_,_).

  changeLblCol(Label,CosA,D):-
	CosA<0,!,
	str_len(Label,L),
	LL=L-1,
	D=abs(round(CosA*LL)).
  changeLblCol(_,_,0).

  add_lbl_percent(Label,Percent,Label2):-
  	str_len(Label,L),L1=L-1,
  	frontstr(L1,Label,_,S),S="=",!,
	Real=abs(Percent),
  	format_string(Real,d,4,String),
  	concat(Label,String,Label2).
  add_lbl_percent(Label,_,Label).

  determ_connectline(Label2,1,Label3):-frontchar(Label2,'-',Label3),!.
  determ_connectline(Label,0,Label).
