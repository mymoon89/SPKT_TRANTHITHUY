-- ============================================================
--   Database name:  ORA                                 
--   DBMS name:      ORACLE Version 8.x                        
--   Created on:     6/20/2005  11:39 PM                       
-- ============================================================

--******************************************************************************
-- Create Tables
-- ============================================================
--   Table: LOI                                                
-- ============================================================
create table LOI
(
    MA_LOI         INTEGER                null    ,
    TEN_LOI        VARCHAR2(100)          null    ,
    THOI_GIAN_LOI  DATE                   null    
)
/

-- ============================================================
--   Table: BANG_DIA                                           
-- ============================================================
create table BANG_DIA
(
    MA_BD          VARCHAR2(5)            not null,
    TEN_BD         VARCHAR2(50)           null    ,
    constraint PK_BANG_DIA primary key (MA_BD)
)
/

-- ============================================================
--   Table: NHOM                                               
-- ============================================================
create table NHOM
(
    MA_NHOM        VARCHAR2(5)            not null,
    TEN_NHOM       VARCHAR2(50)           null    ,
    constraint PK_NHOM primary key (MA_NHOM)
)
/

-- ============================================================
--   Table: THELOAI                                            
-- ============================================================
create table THELOAI
(
    MA_THE_LOAI    VARCHAR2(10)           not null,
    TEN_THE_LOAI   VARCHAR2(50)           null    ,
    constraint PK_THELOAI primary key (MA_THE_LOAI)
)
/

-- ============================================================
--   Table: CD                                                 
-- ============================================================
create table CD
(
    MA_CD          VARCHAR2(10)           not null,
    MA_BD          VARCHAR2(5)            not null,
    MA_THE_LOAI    VARCHAR2(10)           null    ,
    TEN_CD         VARCHAR2(50)           null    ,
    NGAY_NHAP      DATE                   null    ,
    NAM_SX         INTEGER                null    ,
    DIEN_GIAI      VARCHAR2(100)          null    ,
    constraint PK_CD primary key (MA_CD)
)
/

-- ============================================================
--   Index: BANGDIA_CD_FK                                      
-- ============================================================
create index BANGDIA_CD_FK on CD (MA_BD asc)
/

-- ============================================================
--   Index: THELOAI_CD_FK                                      
-- ============================================================
create index THELOAI_CD_FK on CD (MA_THE_LOAI asc)
/

-- ============================================================
--   Table: NOIDUNG                                            
-- ============================================================
create table NOIDUNG
(
    MA_CD          VARCHAR2(10)           not null,
    MA_FILE        VARCHAR2(10)           not null,
    TEN_FILE       VARCHAR2(100)          null    ,
    THU_MUC        VARCHAR2(500)          null    ,
    LA_THU_MUC     NUMBER(1)              null    ,
    CA_SI          VARCHAR2(100)          null    ,
    constraint PK_NOIDUNG primary key (MA_CD, MA_FILE)
)
/

-- ============================================================
--   Index: CD_FILE_FK                                         
-- ============================================================
create index CD_FILE_FK on NOIDUNG (MA_CD asc)
/

-- ============================================================
--   Table: CD_NHOM                                            
-- ============================================================
create table CD_NHOM
(
    MA_NHOM        VARCHAR2(5)            not null,
    MA_CD          VARCHAR2(10)           not null,
    constraint PK_CD_NHOM primary key (MA_NHOM, MA_CD)
)
/

-- ============================================================
--   Index: CD_NHOM_FK                                         
-- ============================================================
create index CD_NHOM_FK on CD_NHOM (MA_CD asc)
/

-- ============================================================
--   Index: NHOM_CD_FK                                         
-- ============================================================
create index NHOM_CD_FK on CD_NHOM (MA_NHOM asc)
/

-- ============================================================
--   Table: CT_BANG_DIA                                        
-- ============================================================
create table CT_BANG_DIA
(
    MA_BD          VARCHAR2(5)            not null,
    MA_NHOM        VARCHAR2(5)            not null,
    constraint PK_CT_BANG_DIA primary key (MA_BD, MA_NHOM)
)
/

-- ============================================================
--   Index: BD_CTBD_FK                                         
-- ============================================================
create index BD_CTBD_FK on CT_BANG_DIA (MA_BD asc)
/

-- ============================================================
--   Index: NHOM_CTBD_FK                                       
-- ============================================================
create index NHOM_CTBD_FK on CT_BANG_DIA (MA_NHOM asc)
/

alter table CD
    add constraint FK_CD_BANGDIA_C_BANG_DIA foreign key  (MA_BD)
       references BANG_DIA (MA_BD)
/

alter table CD
    add constraint FK_CD_THELOAI_C_THELOAI foreign key  (MA_THE_LOAI)
       references THELOAI (MA_THE_LOAI)
/

alter table NOIDUNG
    add constraint FK_NOIDUNG_CD_FILE_CD foreign key  (MA_CD)
       references CD (MA_CD)
/

alter table CD_NHOM
    add constraint FK_CD_NHOM_CD_NHOM_CD foreign key  (MA_CD)
       references CD (MA_CD)
/

alter table CD_NHOM
    add constraint FK_CD_NHOM_NHOM_CD_NHOM foreign key  (MA_NHOM)
       references NHOM (MA_NHOM)
/

alter table CT_BANG_DIA
    add constraint FK_CT_BANG__BD_CTBD_BANG_DIA foreign key  (MA_BD)
       references BANG_DIA (MA_BD)
/

alter table CT_BANG_DIA
    add constraint FK_CT_BANG__NHOM_CTBD_NHOM foreign key  (MA_NHOM)
       references NHOM (MA_NHOM)
/

--******************************************************************************
-- Insert data to Database
-- Table "BANG_DIA"
Insert into BANG_DIA(Ma_BD,Ten_BD) values ('BD001','Tape');
Insert into BANG_DIA(Ma_BD,Ten_BD) values ('BD002','Video');
Insert into BANG_DIA(Ma_BD,Ten_BD) values ('BD003','Audio CD');
Insert into BANG_DIA(Ma_BD,Ten_BD) values ('BD004','Video CD');
Insert into BANG_DIA(Ma_BD,Ten_BD) values ('BD005','Data CD');
Insert into BANG_DIA(Ma_BD,Ten_BD) values ('BD006','Video DVD');
Insert into BANG_DIA(Ma_BD,Ten_BD) values ('BD007','Data DVD');
-- Table "NHOM"
Insert into Nhom(Ma_Nhom,Ten_Nhom) values ('N0001','Music');
Insert into Nhom(Ma_Nhom,Ten_Nhom) values ('N0002','Film');
Insert into Nhom(Ma_Nhom,Ten_Nhom) values ('N0003','Graphic');
Insert into Nhom(Ma_Nhom,Ten_Nhom) values ('N0004','Utility');
Insert into Nhom(Ma_Nhom,Ten_Nhom) values ('N0005','Study');
Insert into Nhom(Ma_Nhom,Ten_Nhom) values ('N0006','Games');
-- Table CT_BANG_DIA
Insert into CT_BANG_DIA(Ma_BD,Ma_Nhom) values ('BD001','N0001');
Insert into CT_BANG_DIA(Ma_BD,Ma_Nhom) values ('BD002','N0001');
Insert into CT_BANG_DIA(Ma_BD,Ma_Nhom) values ('BD002','N0002');
Insert into CT_BANG_DIA(Ma_BD,Ma_Nhom) values ('BD003','N0001');
Insert into CT_BANG_DIA(Ma_BD,Ma_Nhom) values ('BD004','N0001');
Insert into CT_BANG_DIA(Ma_BD,Ma_Nhom) values ('BD004','N0002');
Insert into CT_BANG_DIA(Ma_BD,Ma_Nhom) values ('BD005','N0003');
Insert into CT_BANG_DIA(Ma_BD,Ma_Nhom) values ('BD005','N0004');
Insert into CT_BANG_DIA(Ma_BD,Ma_Nhom) values ('BD005','N0005');
Insert into CT_BANG_DIA(Ma_BD,Ma_Nhom) values ('BD005','N0006');
Insert into CT_BANG_DIA(Ma_BD,Ma_Nhom) values ('BD006','N0001');
Insert into CT_BANG_DIA(Ma_BD,Ma_Nhom) values ('BD006','N0002');
Insert into CT_BANG_DIA(Ma_BD,Ma_Nhom) values ('BD007','N0003');
Insert into CT_BANG_DIA(Ma_BD,Ma_Nhom) values ('BD007','N0004');
Insert into CT_BANG_DIA(Ma_BD,Ma_Nhom) values ('BD007','N0005');
Insert into CT_BANG_DIA(Ma_BD,Ma_Nhom) values ('BD007','N0006');

-- Table "THELOAI"
Insert into TheLoai(Ma_The_Loai,Ten_The_Loai) values ('TL001','Pop');
Insert into TheLoai(Ma_The_Loai,Ten_The_Loai) values ('TL002','Rock');
Insert into TheLoai(Ma_The_Loai,Ten_The_Loai) values ('TL003','Blue');
Insert into TheLoai(Ma_The_Loai,Ten_The_Loai) values ('TL004','Country');
Insert into TheLoai(Ma_The_Loai,Ten_The_Loai) values ('TL005','Rap');
Insert into TheLoai(Ma_The_Loai,Ten_The_Loai) values ('TL006','Cai luong');
Insert into TheLoai(Ma_The_Loai,Ten_The_Loai) values ('TL007','Ca co');
Insert into TheLoai(Ma_The_Loai,Ten_The_Loai) values ('TL008','Cheo');
Commit;
--**********************************************************************
-- Create Stored Procedure
Create Procedure SP_THEM_CD
(MaCD CD.Ma_CD%Type,DienGiai CD.Dien_Giai%Type,MaBD CD.Ma_BD%Type,MaTL CD.Ma_The_loai%Type,TenCD CD.Ten_CD%Type,NgayNhap CD.Ngay_nhap%Type,NamSX CD.Nam_SX%Type)
as
Begin
  insert into CD(Ma_CD,Ten_CD,Ngay_nhap,Nam_SX,Ma_BD,Ma_The_loai,Dien_Giai)
  values (MaCD,TenCD,NgayNhap,NamSX,MaBD,MaTL,DienGiai);
End;

/

Create Procedure SP_THEM_ND
(
MaCD NOIDUNG.Ma_CD%Type,
MaFile NOIDUNG.Ma_File%Type,
TenFile NOIDUNG.Ten_File%Type,
ThuMuc NOIDUNG.Thu_Muc%Type,
LaThuMuc NOIDUNG.La_thu_muc%Type,
CaSi NOIDUNG.Ca_si%Type
)
As
Begin
  insert into NOIDUNG(Ma_CD,Ma_File,Ten_File,Thu_Muc,La_thu_muc,Ca_Si)
  values
              (MaCD,MaFile,TenFile,ThuMuc,LaThuMuc,CaSi);
End;

/

Create Procedure SP_THEM_CD_NHOM
(
MaCD CD.Ma_CD%Type,
MaNhom Nhom.Ma_Nhom%Type
)
As
Begin
  Insert into CD_NHOM(Ma_CD,Ma_Nhom) 
  values  (MaCD,MaNhom);
          
End;
/
--**************************
--Yen
Create Procedure SP_THEMBD
(MaBD BANG_DIA.Ma_BD%Type,GiaTri BANG_DIA.TEN_BD%Type)
As
Begin
  insert into BANG_DIA(MA_BD,TEN_BD) 
  values (MaBD,GiaTri);
End;
/

Create Procedure SP_THEMNHOM
(MaNhom NHOM.Ma_Nhom%Type,GiaTri NHOM.TEN_NHOM%Type)
As
Begin
  insert into NHOM(MA_NHOM,TEN_NHOM) 
  values (MaNhom,GiaTri);
End;
/

Create Procedure SP_THEMTL
(MaTL THELOAI.Ma_The_Loai%Type,GiaTri THELOAI.TEN_THE_LOAI%Type)
As
Begin
  insert into THELOAI(MA_THE_LOAI,TEN_THE_LOAI) 
  values (MaTL,GiaTri);
End;
/

Create Procedure SP_CAPNHATBD
(Ma BANG_DIA.MA_BD%Type,GiaTri BANG_DIA.TEN_BD%Type)
As
Begin
  Update BANG_DIA
  Set   BANG_DIA.TEN_BD = GiaTri
  Where BANG_DIA.MA_BD = Ma;
End;
/

Create Procedure SP_CAPNHATNHOM
(Ma NHOM.MA_NHOM%Type,GiaTri NHOM.TEN_NHOM%Type)
As
Begin
  Update NHOM
  Set   NHOM.TEN_NHOM = GiaTri
  Where NHOM.MA_NHOM = Ma;
End;
/

Create Procedure SP_CAPNHATTL
(Ma THELOAI.MA_THE_LOAI%Type,GiaTri THELOAI.TEN_THE_LOAI%Type)
As
Begin
  Update THELOAI
  Set   THELOAI.TEN_THE_LOAI = GiaTri
  Where THELOAI.MA_THE_LOAI = Ma;
End;
/