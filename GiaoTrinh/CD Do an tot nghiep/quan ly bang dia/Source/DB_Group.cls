VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "DB_Group"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
Public Function LayDS_Group() As ADODB.Recordset
Set LayDS_Group = Mo_bang("NHOM")
End Function
Public Sub LuuGroup(ByVal MA_NHOM As String, ByVal TEN_NHOM As String)
    CallProcedure "SP_THEMNHOM", "MaNhom", MA_NHOM, "GiaTri", TEN_NHOM
End Sub
Public Sub CapNhatGroupDB(ByVal MA_NHOM As String, _
                          ByVal TEN_NHOM As String)
    CallProcedure "SP_CAPNHATNHOM", "Ma", MA_NHOM, "GiaTri", TEN_NHOM
End Sub

Public Function XoaGroup(ByVal MA_NHOM As String) As Boolean
'On Error GoTo XoaGRErr

    Thuc_thi_truy_van "Delete from NHOM where MA_NHOM like '" & MA_NHOM & "'"
    cn.Execute "Commit"
    
XoaGroup = True
Exit Function
XoaGRErr:
    XoaGroup = False
End Function

Public Function LayTenNhom(ByVal MaNhom As String) As String
Dim rst As ADODB.Recordset

    Set rst = Mo_truy_van("Select * from NHOM where Ma_Nhom like '" & MaNhom & "'")
    LayTenNhom = rst!TEN_NHOM
    
Set rst = Nothing
End Function

Public Function LayMaNhom(ByVal TenNhom As String) As String
Dim rst As ADODB.Recordset

    Set rst = Mo_truy_van("Select * from NHOM where Ten_Nhom like '" & TenNhom & "'")
    LayMaNhom = rst!MA_NHOM
    
Set rst = Nothing
End Function

