VERSION 5.00
Begin VB.Form frmConnect 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Connect"
   ClientHeight    =   4050
   ClientLeft      =   45
   ClientTop       =   435
   ClientWidth     =   7440
   Icon            =   "frmConnect.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   4050
   ScaleWidth      =   7440
   StartUpPosition =   2  'CenterScreen
   Begin VB.CommandButton cmdConnect 
      Caption         =   "&Connect"
      Height          =   375
      Left            =   4680
      TabIndex        =   6
      Top             =   3360
      Width           =   1215
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "&Exit"
      Height          =   375
      Left            =   6120
      TabIndex        =   7
      Top             =   3360
      Width           =   1215
   End
   Begin VB.TextBox txtPass 
      Height          =   375
      IMEMode         =   3  'DISABLE
      Left            =   3840
      PasswordChar    =   "*"
      TabIndex        =   5
      Text            =   "TUNG"
      Top             =   2160
      Width           =   2655
   End
   Begin VB.TextBox txtUser 
      Height          =   375
      Left            =   3840
      TabIndex        =   4
      Text            =   "TUNG"
      Top             =   1560
      Width           =   2655
   End
   Begin VB.TextBox txtDatabase 
      Height          =   375
      Left            =   3840
      TabIndex        =   3
      Text            =   "ORA"
      Top             =   600
      Width           =   2655
   End
   Begin VB.Label Label3 
      AutoSize        =   -1  'True
      Caption         =   "Username :"
      Height          =   195
      Left            =   2760
      TabIndex        =   2
      Top             =   1680
      Width           =   810
   End
   Begin VB.Label Label2 
      AutoSize        =   -1  'True
      Caption         =   "Password :"
      Height          =   195
      Left            =   2760
      TabIndex        =   1
      Top             =   2160
      Width           =   780
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      Caption         =   "Database :"
      Height          =   195
      Left            =   2760
      TabIndex        =   0
      Top             =   720
      Width           =   780
   End
   Begin VB.Image Image1 
      Height          =   4065
      Left            =   0
      Picture         =   "frmConnect.frx":5C12
      Top             =   0
      Width           =   2460
   End
End
Attribute VB_Name = "frmConnect"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub cmdConnect_Click()
DB = txtDatabase.Text
USR = txtUser.Text
PASS = txtPass.Text

If ConnectToDatabase = True Then
    MsgBox "Connected sucessful"
    
    Load frmMain
    frmMain.Show
    
    Load frmImport
    frmImport.Hide
    Load frmOption
    frmOption.Hide
    Load frmSearch
    frmSearch.Hide
    
    Unload Me
Else
    MsgBox " Connected not sucessful"
    MsgBox ErrorLog
    End
End If
End Sub

Private Sub cmdExit_Click()
End
End Sub

