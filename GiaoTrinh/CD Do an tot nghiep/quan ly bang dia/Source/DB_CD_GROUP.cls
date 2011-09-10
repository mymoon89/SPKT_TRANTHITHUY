VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "DB_CD_GROUP"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
Public Sub LuuCD_GROUP(ByVal MaNhom As String, MaCD As String)
CallProcedure "SP_THEM_CD_NHOM", "MaCD", MaCD, "MaNhom", MaNhom
End Sub

Public Function LayDS_CD_GROUP(ByVal MaCD) As ADODB.Recordset
    Set LayDS_CD_GROUP = Mo_truy_van("Select * from CD_NHOM where MA_CD like '" & MaCD & "'")
End Function

