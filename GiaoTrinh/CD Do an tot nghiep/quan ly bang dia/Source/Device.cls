VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Device"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
'local variable(s) to hold property value(s)
Private mvarMA_BD As String 'local copy
Private mvarTEN_BD As String 'local copy

Public rst As ADODB.Recordset
Dim DB_DE As New DB_Device
'local variable(s) to hold property value(s)
Public Property Let MA_BD(ByVal vData As String)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.Fax = 5
    mvarMA_BD = vData
End Property


Public Property Get MA_BD() As String
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.Fax
    BANG_DIA = mvarMA_BD
End Property
Public Property Let TEN_BD(ByVal vData As String)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.Fax = 5
    mvarTEN_BD = vData
End Property


Public Property Get TEN_BD() As String
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.Fax
    TEN_BD = mvarTEN_BD
End Property
Public Sub XuatDS_Device(grd As VSFlexGrid)

Set rst = DB_DE.LayDS_Device
With grd
    .Cols = 2
    .Rows = 1
    .FixedCols = 1
    .FixedRows = 1
    Set .DataSource = rst
    For i = 1 To .Rows - 1
        .TextMatrix(i, 1) = Trim$(.TextMatrix(i, 1))
        .TextMatrix(i, 2) = Trim$(.TextMatrix(i, 2))
    Next i
End With

End Sub
Public Function ThemDevice() As Boolean
On Error GoTo ThemDEErr
    DB_DE.LuuDevice mvarMA_BD, mvarTEN_BD
ThemDevice = True
Exit Function
ThemDEErr:
    ThemDevice = False
End Function
Public Function CapNhatDevice() As Boolean
On Error GoTo CapNhatDEErr
    DB_DE.CapNhatDeviceDB mvarMA_BD, mvarTEN_BD
CapNhatDevice = True
Exit Function
CapNhatDEErr:
    CapNhatDevice = False
End Function

Public Sub XuatDS_DeviceRaCombo(cmb As ComboBox)
'On Error GoTo XuatDSDeviceErr
Dim DB_BD As New DB_Device
Dim rst As ADODB.Recordset

Set rst = DB_BD.LayDS_Device

If rst.RecordCount = 0 Then Exit Sub
While (Not rst.EOF)
    cmb.AddItem rst!TEN_BD
    rst.MoveNext
Wend

cmb.ListIndex = 4
Exit Sub
XuatDSDeviceErr:
End Sub

