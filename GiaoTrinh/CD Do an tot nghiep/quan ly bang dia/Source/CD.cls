VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "CD"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
'local variable(s) to hold property value(s)
Private mvarTenCD As String 'local copy
Private mvarNgayNhap As Date 'local copy
Private mvarNamSX As Long 'local copy
Private mvarMaBD As String 'local copy
Private mvarMaTL As String 'local copy
Private mvarDienGiai As String 'local copy
Private clsDB_CD As New DB_CD
'local variable(s) to hold property value(s)
Private mvarMaCD As String 'local copy
Public Property Let MaCD(ByVal vData As String)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.MaCD = 5
    mvarMaCD = vData
End Property


Public Property Get MaCD() As String
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.MaCD
    MaCD = mvarMaCD
End Property



Public Property Let DienGiai(ByVal vData As String)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.DienGiai = 5
    mvarDienGiai = vData
End Property


Public Property Get DienGiai() As String
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.DienGiai
    DienGiai = mvarDienGiai
End Property



Public Property Let MaTL(ByVal vData As String)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.MaTL = 5
    mvarMaTL = vData
End Property


Public Property Get MaTL() As String
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.MaTL
    MaTL = mvarMaTL
End Property



Public Property Let MaBD(ByVal vData As String)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.MaBD = 5
    mvarMaBD = vData
End Property


Public Property Get MaBD() As String
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.MaBD
    MaBD = mvarMaBD
End Property



Public Property Let NamSX(ByVal vData As Long)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.NamSX = 5
    mvarNamSX = vData
End Property


Public Property Get NamSX() As Long
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.NamSX
    NamSX = mvarNamSX
End Property



Public Property Let NgayNhap(ByVal vData As Date)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.NgayNhap = 5
    mvarNgayNhap = vData
End Property


Public Property Get NgayNhap() As Date
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.NgayNhap
    NgayNhap = mvarNgayNhap
End Property



Public Property Let TenCD(ByVal vData As String)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.TenCD = 5
    mvarTenCD = vData
End Property


Public Property Get TenCD() As String
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.TenCD
    TenCD = mvarTenCD
End Property

Public Function Them1CD() As Boolean
On Error GoTo ThemCD_Err
    clsDB_CD.LuuCD mvarMaCD, mvarTenCD, mvarNgayNhap, mvarNamSX, mvarMaBD, mvarMaTL, mvarDienGiai
    Them1CD = True
Exit Function
ThemCD_Err:
    Them1CD = False
End Function

Public Sub XuatDanhSachCD(ByRef grdDSCD As VSFlexGrid)
Dim rs As ADODB.Recordset
Dim DB As New DB_CD
Dim DB_BD As New DB_Device

Set rs = DB.LayDS_CD

i = 0
While (Not rs.EOF)
    With grdDSCD
        i = i + 1
        .AddItem ""
        .TextMatrix(i, 0) = i
        .TextMatrix(i, 1) = rs.Fields("Ma_CD")
        If rs.Fields("Ten_CD") <> "" Then .TextMatrix(i, 2) = rs.Fields("Ten_CD")
        .TextMatrix(i, 3) = DB_BD.LayTenBD(rs.Fields("MA_BD"))
        .TextMatrix(i, 4) = rs.Fields("NGAY_NHAP")
        .TextMatrix(i, 5) = rs.Fields("NAM_SX")
    rs.MoveNext
    End With
Wend

Set rs = Nothing
Set DB = Nothing
End Sub
