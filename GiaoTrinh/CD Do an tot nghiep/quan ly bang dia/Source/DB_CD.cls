VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "DB_CD"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
Public Sub LuuCD(ByVal MaCD As String, _
                    ByVal TenCD As String, _
                    ByVal NgayNhap As Date, _
                    ByVal NamSX As Long, _
                    ByVal MaBD As String, _
                    ByVal MaTL As String, _
                    ByVal DienGiai As String)
                    
Dim cmd As New ADODB.Command
Dim prm As ADODB.Parameter

'Define a command object for a stored procedure
cmd.ActiveConnection = cn
cmd.CommandText = "SP_Them_CD"
cmd.CommandType = adCmdStoredProc
cmd.CommandTimeout = 15

'Set up a new parameter for the  stored procedure
Set prm = cmd.CreateParameter("MaCD", adVarChar, adParamInput, 10, MaCD)
cmd.Parameters.Append prm
Set prm = cmd.CreateParameter("DienGiai", adVarChar, adParamInput, 100, DienGiai)
cmd.Parameters.Append prm
Set prm = cmd.CreateParameter("MaBD", adVarChar, adParamInput, 5, MaBD)
cmd.Parameters.Append prm
Set prm = cmd.CreateParameter("MaTL", adVarChar, adParamInput, 10, MaTL)
cmd.Parameters.Append prm
Set prm = cmd.CreateParameter("TenCD", adVarChar, adParamInput, 50, TenCD)
cmd.Parameters.Append prm
Set prm = cmd.CreateParameter("NgayNhap", adDate, adParamInput, , NgayNhap)
cmd.Parameters.Append prm
Set prm = cmd.CreateParameter("NamSX", adNumeric, adParamInput, , NamSX)
cmd.Parameters.Append prm

'Create a reccordset by executing the command
cmd.Execute

End Sub

Public Function LayDS_CD() As ADODB.Recordset
Set LayDS_CD = Mo_bang("CD")
End Function

Public Function TimGenre(ByVal MaCD As String) As String
On Error GoTo TimGenreErr
    Dim rst As ADODB.Recordset
    Dim str As String
    
    str = ""
    Set rst = Mo_truy_van("Select * from CD where Ma_CD like '" & MaCD & "'")
    str = rst!Ma_THE_LOAI
    Set rst = Mo_truy_van("Select * from THELOAI where Ma_the_loai like '" & str & "'")
    TimGenre = rst!TEN_THE_LOAI
    
    Set rst = Nothing
Exit Function
TimGenreErr:
    TimGenre = ""
End Function

Public Function TimCD(ByVal dkSQL As String) As ADODB.Recordset

    Set TimCD = Mo_truy_van(dkSQL)
    
End Function
