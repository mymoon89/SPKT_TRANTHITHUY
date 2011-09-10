VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "DB_NOIDUNG"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
Public Sub LuuNoiDung(ByVal MaCD As String, _
                    ByVal MaFile As String, _
                    ByVal TenFile As String, _
                    ByVal ThuMuc As String, _
                    ByVal LaThuMuc As Boolean, _
                    ByVal CaSi As String)
                    
Dim cmd As New ADODB.Command
Dim prm As ADODB.Parameter

'Define a command object for a stored procedure
cmd.ActiveConnection = cn
cmd.CommandText = "SP_Them_ND"
cmd.CommandType = adCmdStoredProc
cmd.CommandTimeout = 15

'Set up a new parameter for the  stored procedure
Set prm = cmd.CreateParameter("MaCD", adVarChar, adParamInput, 10, MaCD)
cmd.Parameters.Append prm
Set prm = cmd.CreateParameter("MaFile", adVarChar, adParamInput, 10, MaFile)
cmd.Parameters.Append prm
Set prm = cmd.CreateParameter("TenFile", adVarChar, adParamInput, 100, TenFile)
cmd.Parameters.Append prm
Set prm = cmd.CreateParameter("ThuMuc", adVarChar, adParamInput, 500, ThuMuc)
cmd.Parameters.Append prm
Set prm = cmd.CreateParameter("LaThuMuc", adBoolean, adParamInput, 1, LaThuMuc)
cmd.Parameters.Append prm
Set prm = cmd.CreateParameter("CaSi", adVarChar, adParamInput, 100, CaSi)
cmd.Parameters.Append prm

'Create a reccordset by executing the command
cmd.Execute

End Sub

Public Function LayDS_NOIDUNG(ByVal MaCD) As ADODB.Recordset
    Set LayDS_NOIDUNG = Mo_truy_van("Select * from NOIDUNG where MA_CD like '" & MaCD & "'")
End Function

