VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "DB_Genre"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
Public Function LayDS_Genre() As ADODB.Recordset
Set LayDS_Genre = Mo_bang("THELOAI")
End Function
Public Sub LuuGenre(ByVal MA_TL As String, ByVal TEN_THE_LOAI As String)
    CallProcedure "SP_THEMTL", "MaTL", MA_TL, "GiaTri", TEN_THE_LOAI
End Sub
Public Sub CapNhatGenreDB(ByVal Ma_THE_LOAI As String, _
                          ByVal TEN_THE_LOAI As String)
    CallProcedure "SP_CAPNHATTL", "Ma", Ma_THE_LOAI, "GiaTri", TEN_THE_LOAI
End Sub

Public Function XoaGenre(ByVal Ma_THE_LOAI As String) As Boolean
'On Error GoTo XoaGEErr

    Thuc_thi_truy_van "Delete from THELOAI where MA_THE_LOAI like '" & Ma_THE_LOAI & "'"
    cn.Execute "Commit"
    
XoaGenre = True
Exit Function
XoaGErr:
    XoaGenre = False
End Function

Public Function LayMaGenre(ByVal TenGenre As String) As String
Dim rst As ADODB.Recordset

    Set rst = Mo_truy_van("Select * from THELOAI where Ten_The_Loai like '" & TenGenre & "'")
    LayMaGenre = rst!Ma_THE_LOAI
    
Set rst = Nothing
End Function
