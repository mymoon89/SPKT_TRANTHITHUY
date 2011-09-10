VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "DB_Device"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
Public Function LayDS_Device() As ADODB.Recordset
Set LayDS_Device = Mo_bang("BANG_DIA")
End Function
Public Sub LuuDevice(ByVal MA_BD As String, ByVal TEN_BD As String)
    CallProcedure "SP_THEMBD", "MaBD", MA_BD, "GiaTri", TEN_BD
End Sub
Public Sub CapNhatDeviceDB(ByVal MA_BD As String, _
                          ByVal TEN_BD As String)
    CallProcedure "SP_CAPNHATBD", "Ma", MA_BD, "GiaTri", TEN_BD
End Sub

Public Function XoaDevice(ByVal MA_BD As String) As Boolean
'On Error GoTo XoaDEErr

    Thuc_thi_truy_van "Delete from BANG_DIA where MA_BD like '" & MA_BD & "'"
    cn.Execute "Commit"
    
XoaDevice = True
Exit Function
XoaDEErr:
    XoaDevice = False
End Function

Public Function LayMaBD(ByVal TenBD As String) As String
Dim rst As ADODB.Recordset

    Set rst = Mo_truy_van("Select * from BANG_DIA where Ten_BD like '" & TenBD & "'")
    LayMaBD = rst!MA_BD
    
Set rst = Nothing
End Function

Public Function LayTenBD(ByVal MaBD As String) As String
Dim rst As ADODB.Recordset

    Set rst = Mo_truy_van("Select * from BANG_DIA where MA_BD like '" & MaBD & "'")
    LayTenBD = rst!TEN_BD
    
Set rst = Nothing
End Function
