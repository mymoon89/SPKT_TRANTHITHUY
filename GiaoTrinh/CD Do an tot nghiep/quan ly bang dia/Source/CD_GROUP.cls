VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "CD_GROUP"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
'local variable(s) to hold property value(s)
Private mvarMaNhom As String 'local copy
Private mvarMaCD As String 'local copy
Dim clsDB_CD_GROUP As New DB_CD_GROUP
Dim clsDB_GROUP As New DB_Group

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



Public Property Let MaNhom(ByVal vData As String)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.MaNhom = 5
    mvarMaNhom = vData
End Property


Public Property Get MaNhom() As String
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.MaNhom
    MaNhom = mvarMaNhom
End Property

Public Sub XuatCD_GROUP(ByVal MaCD As String, lst As ListBox)
    Dim rst As ADODB.Recordset
    
    Set rst = clsDB_CD_GROUP.LayDS_CD_GROUP(MaCD)
    
    lst.Clear
    While (Not rst.EOF)
        lst.AddItem clsDB_GROUP.LayTenNhom(rst!MA_NHOM)
        rst.MoveNext
    Wend
End Sub
