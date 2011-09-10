VERSION 5.00
Object = "{D76D7128-4A96-11D3-BD95-D296DC2DD072}#1.0#0"; "vsflex7.ocx"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "TABCTL32.OCX"
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCTL.OCX"
Object = "{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}#2.0#0"; "MSCOMCT2.OCX"
Begin VB.Form frmImport 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Import new CD"
   ClientHeight    =   8265
   ClientLeft      =   3345
   ClientTop       =   1395
   ClientWidth     =   7770
   Icon            =   "frmImport.frx":0000
   LinkTopic       =   "Form2"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   8265
   ScaleWidth      =   7770
   Begin TabDlg.SSTab Tab1 
      Height          =   7455
      Left            =   0
      TabIndex        =   2
      Top             =   720
      Width           =   7695
      _ExtentX        =   13573
      _ExtentY        =   13150
      _Version        =   393216
      Style           =   1
      Tabs            =   2
      TabsPerRow      =   2
      TabHeight       =   520
      ForeColor       =   -2147483646
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      TabCaption(0)   =   "Import"
      TabPicture(0)   =   "frmImport.frx":5C12
      Tab(0).ControlEnabled=   -1  'True
      Tab(0).Control(0)=   "lblDrive"
      Tab(0).Control(0).Enabled=   0   'False
      Tab(0).Control(1)=   "Label3"
      Tab(0).Control(1).Enabled=   0   'False
      Tab(0).Control(2)=   "Label5"
      Tab(0).Control(2).Enabled=   0   'False
      Tab(0).Control(3)=   "Label6"
      Tab(0).Control(3).Enabled=   0   'False
      Tab(0).Control(4)=   "Label7"
      Tab(0).Control(4).Enabled=   0   'False
      Tab(0).Control(5)=   "Label8"
      Tab(0).Control(5).Enabled=   0   'False
      Tab(0).Control(6)=   "Label9"
      Tab(0).Control(6).Enabled=   0   'False
      Tab(0).Control(7)=   "lbl1"
      Tab(0).Control(7).Enabled=   0   'False
      Tab(0).Control(8)=   "lbl2"
      Tab(0).Control(8).Enabled=   0   'False
      Tab(0).Control(9)=   "lblGenre"
      Tab(0).Control(9).Enabled=   0   'False
      Tab(0).Control(10)=   "lblWait"
      Tab(0).Control(10).Enabled=   0   'False
      Tab(0).Control(11)=   "Dir1"
      Tab(0).Control(11).Enabled=   0   'False
      Tab(0).Control(12)=   "grdList"
      Tab(0).Control(12).Enabled=   0   'False
      Tab(0).Control(13)=   "optDir"
      Tab(0).Control(13).Enabled=   0   'False
      Tab(0).Control(14)=   "sb2"
      Tab(0).Control(14).Enabled=   0   'False
      Tab(0).Control(15)=   "sb1"
      Tab(0).Control(15).Enabled=   0   'False
      Tab(0).Control(16)=   "dpProductYear"
      Tab(0).Control(16).Enabled=   0   'False
      Tab(0).Control(17)=   "dpImportDate"
      Tab(0).Control(17).Enabled=   0   'False
      Tab(0).Control(18)=   "lvNhom"
      Tab(0).Control(18).Enabled=   0   'False
      Tab(0).Control(19)=   "cmbDrv"
      Tab(0).Control(19).Enabled=   0   'False
      Tab(0).Control(20)=   "cmbBD"
      Tab(0).Control(20).Enabled=   0   'False
      Tab(0).Control(21)=   "cmdRefresh"
      Tab(0).Control(21).Enabled=   0   'False
      Tab(0).Control(22)=   "optEntire"
      Tab(0).Control(22).Enabled=   0   'False
      Tab(0).Control(23)=   "cmdExit"
      Tab(0).Control(23).Enabled=   0   'False
      Tab(0).Control(24)=   "cmdImport"
      Tab(0).Control(24).Enabled=   0   'False
      Tab(0).Control(25)=   "txtID"
      Tab(0).Control(25).Enabled=   0   'False
      Tab(0).Control(26)=   "txtTitle"
      Tab(0).Control(26).Enabled=   0   'False
      Tab(0).Control(27)=   "txtDes"
      Tab(0).Control(27).Enabled=   0   'False
      Tab(0).Control(28)=   "cmbGenre"
      Tab(0).Control(28).Enabled=   0   'False
      Tab(0).ControlCount=   29
      TabCaption(1)   =   "Result"
      TabPicture(1)   =   "frmImport.frx":5C2E
      Tab(1).ControlEnabled=   0   'False
      Tab(1).Control(0)=   "grdResult"
      Tab(1).Control(1)=   "cmdPrev"
      Tab(1).ControlCount=   2
      Begin VB.ComboBox cmbGenre 
         Height          =   315
         Left            =   4920
         Style           =   2  'Dropdown List
         TabIndex        =   31
         Top             =   1080
         Width           =   1815
      End
      Begin VSFlex7Ctl.VSFlexGrid grdResult 
         Height          =   6375
         Left            =   -74880
         TabIndex        =   30
         Top             =   480
         Width           =   7335
         _cx             =   12938
         _cy             =   11245
         _ConvInfo       =   1
         Appearance      =   1
         BorderStyle     =   1
         Enabled         =   -1  'True
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         MousePointer    =   0
         BackColor       =   -2147483643
         ForeColor       =   -2147483640
         BackColorFixed  =   -2147483633
         ForeColorFixed  =   -2147483630
         BackColorSel    =   -2147483635
         ForeColorSel    =   -2147483634
         BackColorBkg    =   -2147483636
         BackColorAlternate=   -2147483643
         GridColor       =   -2147483633
         GridColorFixed  =   -2147483632
         TreeColor       =   -2147483632
         FloodColor      =   192
         SheetBorder     =   -2147483642
         FocusRect       =   1
         HighLight       =   1
         AllowSelection  =   -1  'True
         AllowBigSelection=   -1  'True
         AllowUserResizing=   1
         SelectionMode   =   0
         GridLines       =   1
         GridLinesFixed  =   2
         GridLineWidth   =   1
         Rows            =   50
         Cols            =   10
         FixedRows       =   1
         FixedCols       =   1
         RowHeightMin    =   0
         RowHeightMax    =   0
         ColWidthMin     =   0
         ColWidthMax     =   0
         ExtendLastCol   =   -1  'True
         FormatString    =   ""
         ScrollTrack     =   0   'False
         ScrollBars      =   3
         ScrollTips      =   0   'False
         MergeCells      =   0
         MergeCompare    =   0
         AutoResize      =   -1  'True
         AutoSizeMode    =   0
         AutoSearch      =   0
         AutoSearchDelay =   2
         MultiTotals     =   -1  'True
         SubtotalPosition=   1
         OutlineBar      =   0
         OutlineCol      =   0
         Ellipsis        =   0
         ExplorerBar     =   1
         PicturesOver    =   0   'False
         FillStyle       =   0
         RightToLeft     =   0   'False
         PictureType     =   0
         TabBehavior     =   0
         OwnerDraw       =   0
         Editable        =   0
         ShowComboButton =   1
         WordWrap        =   0   'False
         TextStyle       =   0
         TextStyleFixed  =   0
         OleDragMode     =   0
         OleDropMode     =   0
         DataMode        =   0
         VirtualData     =   -1  'True
         DataMember      =   ""
         ComboSearch     =   3
         AutoSizeMouse   =   -1  'True
         FrozenRows      =   0
         FrozenCols      =   0
         AllowUserFreezing=   0
         BackColorFrozen =   0
         ForeColorFrozen =   0
         WallPaperAlignment=   9
      End
      Begin VB.TextBox txtDes 
         BackColor       =   &H00FFFFFF&
         Height          =   375
         Left            =   1680
         TabIndex        =   17
         Top             =   6120
         Width           =   5775
      End
      Begin VB.TextBox txtTitle 
         BackColor       =   &H00FFFFFF&
         Height          =   375
         Left            =   1680
         TabIndex        =   16
         Top             =   5640
         Width           =   2655
      End
      Begin VB.TextBox txtID 
         BackColor       =   &H00E0E0E0&
         Height          =   375
         Left            =   1680
         Locked          =   -1  'True
         TabIndex        =   15
         Top             =   5160
         Width           =   2655
      End
      Begin VB.CommandButton cmdImport 
         Caption         =   "I&mport"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   5400
         TabIndex        =   14
         Top             =   6600
         Width           =   975
      End
      Begin VB.CommandButton cmdExit 
         Caption         =   "E&xit"
         Height          =   375
         Left            =   6480
         TabIndex        =   13
         Top             =   6600
         Width           =   975
      End
      Begin VB.OptionButton optEntire 
         Caption         =   "Entire content."
         Height          =   255
         Left            =   5760
         TabIndex        =   10
         Top             =   1680
         Visible         =   0   'False
         Width           =   1335
      End
      Begin VB.CommandButton cmdRefresh 
         Caption         =   "Refresh"
         Height          =   810
         Left            =   2640
         TabIndex        =   5
         Top             =   1080
         Width           =   855
      End
      Begin VB.ComboBox cmbBD 
         Height          =   315
         Left            =   720
         Style           =   2  'Dropdown List
         TabIndex        =   4
         Top             =   1560
         Width           =   1815
      End
      Begin VB.CommandButton cmdPrev 
         Caption         =   "<<   Previous"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   -68880
         TabIndex        =   3
         Top             =   6960
         Width           =   1455
      End
      Begin MSComctlLib.ImageCombo cmbDrv 
         Height          =   330
         Left            =   720
         TabIndex        =   6
         Top             =   1080
         Width           =   1815
         _ExtentX        =   3201
         _ExtentY        =   582
         _Version        =   393216
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         Enabled         =   0   'False
         Locked          =   -1  'True
         ImageList       =   "ImageList1"
      End
      Begin MSComctlLib.ListView lvNhom 
         Height          =   2100
         Left            =   120
         TabIndex        =   8
         Top             =   2160
         Width           =   3375
         _ExtentX        =   5953
         _ExtentY        =   3704
         View            =   3
         LabelEdit       =   1
         LabelWrap       =   -1  'True
         HideSelection   =   -1  'True
         Checkboxes      =   -1  'True
         FullRowSelect   =   -1  'True
         GridLines       =   -1  'True
         _Version        =   393217
         ForeColor       =   -2147483640
         BackColor       =   -2147483643
         BorderStyle     =   1
         Appearance      =   1
         NumItems        =   3
         BeginProperty ColumnHeader(1) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Text            =   "Check"
            Object.Width           =   1235
         EndProperty
         BeginProperty ColumnHeader(2) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            Alignment       =   2
            SubItemIndex    =   1
            Text            =   "ID"
            Object.Width           =   1235
         EndProperty
         BeginProperty ColumnHeader(3) {BDD1F052-858B-11D1-B16A-00C0F0283628} 
            SubItemIndex    =   2
            Text            =   "Category 's name"
            Object.Width           =   2540
         EndProperty
      End
      Begin MSComCtl2.DTPicker dpImportDate 
         Height          =   375
         Left            =   6000
         TabIndex        =   18
         Top             =   5160
         Width           =   1455
         _ExtentX        =   2566
         _ExtentY        =   661
         _Version        =   393216
         Format          =   19595265
         UpDown          =   -1  'True
         CurrentDate     =   38163
      End
      Begin MSComCtl2.DTPicker dpProductYear 
         Height          =   375
         Left            =   6000
         TabIndex        =   19
         Top             =   5640
         Width           =   1455
         _ExtentX        =   2566
         _ExtentY        =   661
         _Version        =   393216
         CustomFormat    =   "yyyy"
         Format          =   19595267
         UpDown          =   -1  'True
         CurrentDate     =   38163
      End
      Begin MSComctlLib.StatusBar sb1 
         Height          =   255
         Left            =   120
         TabIndex        =   27
         Top             =   7080
         Width           =   7335
         _ExtentX        =   12938
         _ExtentY        =   450
         _Version        =   393216
         BeginProperty Panels {8E3867A5-8586-11D1-B16A-00C0F0283628} 
            NumPanels       =   1
            BeginProperty Panel1 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
               AutoSize        =   1
               Bevel           =   0
               Object.Width           =   12885
               Text            =   "..."
               TextSave        =   "..."
            EndProperty
         EndProperty
      End
      Begin MSComctlLib.StatusBar sb2 
         Height          =   255
         Left            =   120
         TabIndex        =   28
         Top             =   6720
         Width           =   3015
         _ExtentX        =   5318
         _ExtentY        =   450
         _Version        =   393216
         BeginProperty Panels {8E3867A5-8586-11D1-B16A-00C0F0283628} 
            NumPanels       =   2
            BeginProperty Panel1 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
               AutoSize        =   1
               Bevel           =   0
               Object.Width           =   2699
            EndProperty
            BeginProperty Panel2 {8E3867AB-8586-11D1-B16A-00C0F0283628} 
            EndProperty
         EndProperty
      End
      Begin VB.OptionButton optDir 
         Caption         =   "Directory only."
         Height          =   255
         Left            =   4320
         TabIndex        =   9
         Top             =   1680
         Value           =   -1  'True
         Visible         =   0   'False
         Width           =   1455
      End
      Begin VSFlex7Ctl.VSFlexGrid grdList 
         Height          =   2100
         Left            =   3720
         TabIndex        =   29
         Top             =   2160
         Width           =   3855
         _cx             =   6800
         _cy             =   3704
         _ConvInfo       =   1
         Appearance      =   1
         BorderStyle     =   1
         Enabled         =   -1  'True
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         MousePointer    =   0
         BackColor       =   -2147483643
         ForeColor       =   -2147483640
         BackColorFixed  =   -2147483633
         ForeColorFixed  =   -2147483630
         BackColorSel    =   -2147483635
         ForeColorSel    =   -2147483634
         BackColorBkg    =   -2147483636
         BackColorAlternate=   -2147483643
         GridColor       =   -2147483633
         GridColorFixed  =   -2147483632
         TreeColor       =   -2147483632
         FloodColor      =   192
         SheetBorder     =   -2147483642
         FocusRect       =   1
         HighLight       =   1
         AllowSelection  =   -1  'True
         AllowBigSelection=   -1  'True
         AllowUserResizing=   1
         SelectionMode   =   0
         GridLines       =   1
         GridLinesFixed  =   2
         GridLineWidth   =   1
         Rows            =   50
         Cols            =   10
         FixedRows       =   1
         FixedCols       =   1
         RowHeightMin    =   0
         RowHeightMax    =   0
         ColWidthMin     =   0
         ColWidthMax     =   0
         ExtendLastCol   =   -1  'True
         FormatString    =   ""
         ScrollTrack     =   0   'False
         ScrollBars      =   3
         ScrollTips      =   0   'False
         MergeCells      =   0
         MergeCompare    =   0
         AutoResize      =   -1  'True
         AutoSizeMode    =   0
         AutoSearch      =   0
         AutoSearchDelay =   2
         MultiTotals     =   -1  'True
         SubtotalPosition=   1
         OutlineBar      =   0
         OutlineCol      =   0
         Ellipsis        =   0
         ExplorerBar     =   0
         PicturesOver    =   0   'False
         FillStyle       =   0
         RightToLeft     =   0   'False
         PictureType     =   0
         TabBehavior     =   0
         OwnerDraw       =   0
         Editable        =   2
         ShowComboButton =   1
         WordWrap        =   0   'False
         TextStyle       =   0
         TextStyleFixed  =   0
         OleDragMode     =   0
         OleDropMode     =   0
         DataMode        =   0
         VirtualData     =   -1  'True
         DataMember      =   ""
         ComboSearch     =   3
         AutoSizeMouse   =   -1  'True
         FrozenRows      =   0
         FrozenCols      =   0
         AllowUserFreezing=   0
         BackColorFrozen =   0
         ForeColorFrozen =   0
         WallPaperAlignment=   9
      End
      Begin VB.DirListBox Dir1 
         Height          =   2115
         Left            =   3720
         TabIndex        =   7
         Top             =   2160
         Visible         =   0   'False
         Width           =   3855
      End
      Begin VB.Label lblWait 
         BackColor       =   &H00C0E0FF&
         BorderStyle     =   1  'Fixed Single
         Caption         =   " Importing ...                     Please waiting ."
         Height          =   495
         Left            =   2520
         TabIndex        =   33
         Top             =   4440
         Visible         =   0   'False
         Width           =   1815
      End
      Begin VB.Label lblGenre 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "Genre"
         Height          =   195
         Left            =   4320
         TabIndex        =   32
         Top             =   1140
         Width           =   435
      End
      Begin VB.Label lbl2 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "Step 2 : Enter detail information ."
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   9.75
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   240
         Left            =   120
         TabIndex        =   26
         Top             =   4680
         Width           =   3360
      End
      Begin VB.Label lbl1 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "Step 1 : Select source to import ."
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   9.75
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   240
         Left            =   240
         TabIndex        =   25
         Top             =   600
         Width           =   3360
      End
      Begin VB.Label Label9 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "Description :"
         Height          =   195
         Left            =   600
         TabIndex        =   24
         Top             =   6210
         Width           =   885
      End
      Begin VB.Label Label8 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "Import date :"
         Height          =   195
         Left            =   4905
         TabIndex        =   23
         Top             =   5250
         Width           =   885
      End
      Begin VB.Label Label7 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "Product year :"
         Height          =   195
         Left            =   4800
         TabIndex        =   22
         Top             =   5730
         Width           =   990
      End
      Begin VB.Label Label6 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "CD's Title :"
         Height          =   195
         Left            =   720
         TabIndex        =   21
         Top             =   5730
         Width           =   765
      End
      Begin VB.Label Label5 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "ID :"
         Height          =   195
         Left            =   1230
         TabIndex        =   20
         Top             =   5250
         Width           =   255
      End
      Begin VB.Label Label3 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "Type :"
         Height          =   195
         Left            =   135
         TabIndex        =   12
         Top             =   1635
         Width           =   450
      End
      Begin VB.Label lblDrive 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "Drive :"
         Height          =   195
         Left            =   120
         TabIndex        =   11
         Top             =   1155
         Width           =   465
      End
   End
   Begin VB.FileListBox File1 
      Height          =   480
      Left            =   4800
      TabIndex        =   1
      Top             =   120
      Visible         =   0   'False
      Width           =   1815
   End
   Begin MSComctlLib.ImageList ImageList1 
      Left            =   6600
      Top             =   120
      _ExtentX        =   1005
      _ExtentY        =   1005
      BackColor       =   -2147483643
      ImageWidth      =   16
      ImageHeight     =   16
      MaskColor       =   12632256
      _Version        =   393216
      BeginProperty Images {2C247F25-8591-11D1-B16A-00C0F0283628} 
         NumListImages   =   1
         BeginProperty ListImage1 {2C247F27-8591-11D1-B16A-00C0F0283628} 
            Picture         =   "frmImport.frx":5C4A
            Key             =   ""
         EndProperty
      EndProperty
   End
   Begin VB.Label Label2 
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
      Caption         =   "The CD's content to be loaded"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H8000000D&
      Height          =   300
      Left            =   1890
      TabIndex        =   0
      Top             =   120
      Width           =   3675
   End
End
Attribute VB_Name = "frmImport"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
'Dim clsLoai As New LOAI
'Dim clsNhom As New NHOM
Private str As String
Private rst As ADODB.Recordset
Private itm As ListItem
Dim clsDB_BD As New DB_Device
Dim clsBD As New Device
Dim clsGenre As New Genre
Dim clsDB_GROUP As New DB_Group
Dim i As Long
Dim strPath As String

Private Sub cmbDrv_Click()
CheckTypeOfCD
End Sub

Private Sub cmbDrv_GotFocus()
lbl1.ForeColor = &H8000000D
End Sub

Private Sub cmbDrv_LostFocus()
lbl1.ForeColor = &H80000012
End Sub

Private Sub cmbBD_Click()
CheckCategory
If cmbBD.Text = "Tape" Or cmbBD.Text = "Video" Then
    cmbDrv.Enabled = False
    optDir.Visible = False
    optEntire.Visible = False
    Dir1.Visible = False
Else
    cmbDrv.Enabled = True
    optDir.Visible = True
    optEntire.Visible = True
    Dir1.Visible = True
    cmbDrv_Click
End If
End Sub

Private Sub cmdExit_Click()
Me.Hide
frmMain.RefreshMain
End Sub

Private Sub cmdImport_Click()
' Kiem tra rang buoc
If cmbBD.Enabled = False Then
    MsgBox "CD is not ready to Import !"
    Exit Sub
End If
If CheckCategoryChecked = False Then
    MsgBox "Category is not checked ! Please check at least one row !"
    lvNhom.SetFocus
    Exit Sub
End If
If txtTitle.Text = "" Then
    MsgBox "CD must have a title !"
    txtTitle.SetFocus
    Exit Sub
End If
'''''''''''''''''''''''''''''''''
InitGridResult
sb1.Panels(1).Text = ""
sb2.Panels(1).Text = ""
sb2.Panels(2).Text = ""
lblWait.Visible = True
DoEvents
'''''''''''''''''''''''''''''''''
    If cmbBD.Text = "Data CD" Or cmbBD.Text = "Data DVD" Then
        LuuDataCD_DVD
        tab1.Tab = 1
        Exit Sub
    End If
    ' Audio & Video CD
    If cmbBD.Text = "Audio CD" Or cmbBD.Text = "Video CD" Or cmbBD.Text = "Video DVD" Then
        LuuAudioVideoCD_DVD
        Exit Sub
    End If
'''''''''''''''''''''''''''''''''
lblWait.Visible = False
End Sub

Private Sub cmdPrev_Click()
InitGridResult
tab1.Tab = 0
txtID = ""
txtTitle = ""
txtDes = ""
lblWait.Visible = False
End Sub

Private Sub cmdRefresh_Click()
DetectCDRom cmbDrv
CheckTypeOfCD
End Sub

Private Sub Command1_Click()
MsgBox Dir1.List(-1)
End Sub

Private Sub Dir1_GotFocus()
lbl1.ForeColor = &H8000000D
End Sub

Private Sub Dir1_LostFocus()
lbl1.ForeColor = &H80000012
End Sub

Private Sub dpImportDate_GotFocus()
lbl2.ForeColor = &H8000000D
End Sub

Private Sub dpImportDate_LostFocus()
lbl2.ForeColor = &H80000012
End Sub

Private Sub dpProductYear_GotFocus()
lbl2.ForeColor = &H8000000D
End Sub

Private Sub dpProductYear_LostFocus()
lbl2.ForeColor = &H80000012
End Sub

Private Sub Form_Load()
DetectCDRom cmbDrv
'''''''''''''''''''''''
clsBD.XuatDS_DeviceRaCombo cmbBD
clsGenre.XuatDS_GenreRaComboBox cmbGenre
'''''''''''''''''''''''
dpImportDate.Value = Date
dpProductYear = Date
InitGridResult
InitGridList
''''''''''''''''''''''''''
CheckTypeOfCD
'cmbDrv_Click
cmbBD_Click
End Sub

Private Sub grdList_GotFocus()
lbl1.ForeColor = &H8000000D
End Sub

Private Sub grdList_LostFocus()
lbl1.ForeColor = &H80000012
End Sub

Private Sub lvNhom_GotFocus()
lbl1.ForeColor = &H8000000D
End Sub

Private Sub lvNhom_LostFocus()
lbl1.ForeColor = &H80000012
End Sub

Private Sub optDir_Click()
Dir1.Visible = True
End Sub

Private Sub optDir_GotFocus()
lbl1.ForeColor = &H8000000D
End Sub

Private Sub optDir_LostFocus()
lbl1.ForeColor = &H80000012
End Sub

Private Sub optEntire_Click()
Dir1.Visible = False
End Sub

Private Sub optEntire_GotFocus()
lbl1.ForeColor = &H8000000D
End Sub

Private Sub optEntire_LostFocus()
lbl1.ForeColor = &H80000012
End Sub

Private Sub txtDes_GotFocus()
lbl2.ForeColor = &H8000000D
End Sub

Private Sub txtDes_LostFocus()
lbl2.ForeColor = &H80000012
End Sub

Private Sub txtID_GotFocus()
lbl2.ForeColor = &H8000000D
End Sub

Private Sub txtID_LostFocus()
lbl2.ForeColor = &H80000012
End Sub

Private Sub txtTitle_GotFocus()
lbl2.ForeColor = &H8000000D
End Sub

Private Sub txtTitle_LostFocus()
lbl2.ForeColor = &H80000012
End Sub

Private Sub CheckTypeOfCD()
On Error GoTo DataCD
Dim fso As New FileSystemObject
Dim drvs As Drives
Dim drv As Drive

Set drvs = fso.Drives

' Check CD is not ready
For Each drv In drvs
    If drv.DriveLetter = cmbDrv.SelectedItem.Key Then
        If drv.IsReady = False Then
            cmbBD.Enabled = False
            Dir1.Visible = False
            optEntire.Visible = False
            optDir.Visible = False
            lvNhom.Visible = False
            grdList.Visible = False
            lblGenre.Visible = False
            cmbGenre.Visible = False
            Exit Sub
        End If
    End If
Next
' Audio CD
For Each drv In drvs
    If drv.DriveLetter = cmbDrv.SelectedItem.Key Then
        If drv.VolumeName = "Audio CD" Then
            Dir1.Visible = False
            optDir.Visible = False
            optEntire.Visible = False
            cmbBD.Enabled = True
            cmbBD.ListIndex = 2
            InitGridList
            grdList.Visible = True
            lblGenre.Visible = True
            cmbGenre.Visible = True
            lvNhom.Visible = True
            CreateTrackList drv.DriveLetter & ":\", grdList
            Exit Sub
        End If
    End If
Next

Dir1.Refresh
' DVD
    Dir1.Path = cmbDrv.SelectedItem.Key & ":\"
    If Dir1.List(0) = Dir1.Path & "AUDIO_TS" And Dir1.List(1) = Dir1.Path & "VIDEO_TS" Then
        Dir1.Visible = False
        optDir.Visible = False
        optEntire.Visible = False
        cmbBD.Enabled = True
        cmbBD.ListIndex = 5
        InitGridList
        grdList.Visible = True
        lvNhom.Visible = True
        lblGenre.Visible = True
        cmbGenre.Visible = True
        Exit Sub
    End If

Dir1.Refresh
' Video CD
Dir1.Path = cmbDrv.SelectedItem.Key & ":\MPEGAV\"
File1.Path = Dir1.Path
If InStr(1, ".DAT", File1.List(0)) = 0 Then
    Dir1.Visible = False
    optDir.Visible = False
    optEntire.Visible = False
    cmbBD.Enabled = True
    cmbBD.ListIndex = 3
    InitGridList
    lvNhom.Visible = True
    grdList.Visible = True
    lblGenre.Visible = True
    cmbGenre.Visible = True
    CreateTrackList cmbDrv.SelectedItem.Key & ":\MPEGAV\", grdList
    Exit Sub
End If

DataCD:
' Data CD
Dir1.Path = cmbDrv.SelectedItem.Key & ":\"
File1.Path = cmbDrv.SelectedItem.Key & ":\"
Dir1.Visible = True
optDir.Visible = True
optEntire.Visible = True
cmbBD.Enabled = True
cmbBD.ListIndex = 4
lvNhom.Visible = True
grdList.Visible = False
lblGenre.Visible = False
cmbGenre.Visible = False
End Sub

Private Sub CheckCategory()
lvNhom.ListItems.Clear
str = clsDB_BD.LayMaBD(cmbBD.Text)
    Set rst = Mo_truy_van("Select * from CT_BANG_DIA where Ma_BD like '" & str & "'")
    While (Not rst.EOF)
        '''''''''''''''''''''''''
        Set itm = lvNhom.ListItems.Add(, , "")
            itm.SubItems(1) = rst!MA_NHOM
            itm.SubItems(2) = clsDB_GROUP.LayTenNhom(rst!MA_NHOM)
        '''''''''''''''''''''''''
        rst.MoveNext
    Wend
str = ""
End Sub

Private Function CheckCategoryChecked() As Boolean
With lvNhom
    For i = 1 To .ListItems.Count
        If .ListItems.Item(i).Checked = True Then
            CheckCategoryChecked = True
            Exit Function
        End If
    Next i
End With
CheckCategoryChecked = False
End Function

Private Sub InitGridResult()
With grdResult
     .Clear
     .Cols = 4
     .Rows = 2
     .FixedCols = 1
     .FixedRows = 1
     
     .TextMatrix(0, 0) = "No"
     .TextMatrix(0, 1) = "Name"
     .TextMatrix(0, 2) = "Type"
     .TextMatrix(0, 3) = "Path"
End With
End Sub

Private Sub InitGridList()
With grdList
     .Clear
     .Cols = 3
     .Rows = 2
     .FixedCols = 1
     .FixedRows = 1
     .ColWidth(0) = .Width / 8
     .ColWidth(1) = .Width / 3
     
     .TextMatrix(0, 0) = "No"
     .TextMatrix(0, 1) = "Song"
     .TextMatrix(0, 2) = "Artist"
End With
End Sub

Private Sub LuuDataCD_DVD()
Dim clsCD As New CD
Dim clsDB_DEV As New DB_Device
Dim clsDB_CD_GROUP As New DB_CD_GROUP
Dim clsND As New NOIDUNG
Dim CD_Code As String
'''''''''''''''''''''''''''''''''
    'Luu CD
    CD_Code = GenerateCode("", 3, "CD", "MA_CD")
    txtID = CD_Code
    With clsCD
        .DienGiai = txtDes
        .MaBD = clsDB_DEV.LayMaBD(cmbBD.Text)
        .MaCD = CD_Code
        .NamSX = Year(Date)
        .NgayNhap = Date
        .TenCD = txtTitle
        If .Them1CD = False Then
            MsgBox "Can't save this CD !"
            Exit Sub
        End If
    End With
    'Luu Nhom cua CD
    With lvNhom
        For i = 1 To .ListItems.Count
            If .ListItems.Item(i).Checked = True Then
                clsDB_CD_GROUP.LuuCD_GROUP .ListItems.Item(i).SubItems(1), CD_Code
            End If
        Next i
    End With
    ' Luu Chi tiet CD
    Dim Index As Long
    Dim Number As Long
    Index = 0
    Number = CLng(CD_Code)
    
    If optEntire.Value = True Then
        strPath = cmbDrv.SelectedItem.Key & ":\"
    Else
        strPath = Dir1.Path
    End If
    If BrowseCD(strPath, grdResult, sb1, sb2) = False Then
        MsgBox "Can't read from CD-ROM !"
    End If
    With grdResult
        If .TextMatrix(.Rows - 1, 1) = "" Then .RemoveItem .Rows - 1
        For i = 1 To .Rows - 1
            If .TextMatrix(i, 2) = "Folder" Then
                clsND.LaThuMuc = True
            Else
                clsND.LaThuMuc = False
            End If
           Index = Index + 1
            clsND.MaFile = CStr(Number) & CStr(Index)
            clsND.MaCD = CD_Code
            clsND.TenFile = .TextMatrix(i, 1)
            clsND.ThuMuc = .TextMatrix(i, 3)
            clsND.ThemND
        Next i
    End With
    sb1.Panels(1).Text = "Done."
End Sub

Private Sub LuuAudioVideoCD_DVD()
Dim clsCD As New CD
Dim clsDB_DEV As New DB_Device
Dim clsDB_CD_GROUP As New DB_CD_GROUP
Dim clsND As New NOIDUNG
Dim clsDB_Genre As New DB_Genre
Dim CD_Code As String
'''''''''''''''''''''''''''''''''
    'Luu CD
    CD_Code = GenerateCode("", 3, "CD", "MA_CD")
    txtID = CD_Code
    With clsCD
        .DienGiai = txtDes
        .MaBD = clsDB_DEV.LayMaBD(cmbBD.Text)
        .MaCD = CD_Code
        .NamSX = Year(Date)
        .NgayNhap = Date
        .TenCD = txtTitle
        .MaTL = clsDB_Genre.LayMaGenre(cmbGenre.Text)
        If .Them1CD = False Then
            MsgBox "Can't save this CD !"
            Exit Sub
        End If
    End With
    'Luu Nhom cua CD
    With lvNhom
        For i = 1 To .ListItems.Count
            If .ListItems.Item(i).Checked = True Then
                clsDB_CD_GROUP.LuuCD_GROUP .ListItems.Item(i).SubItems(1), CD_Code
            End If
        Next i
    End With
    ' Luu Chi tiet CD
    Dim Index As Long
    Dim Number As Long
    Index = 0
    Number = CLng(CD_Code)
    
    If optEntire.Value = True Then
        strPath = cmbDrv.SelectedItem.Key & ":\"
    Else
        strPath = Dir1.Path
    End If
    
    With grdList
        If .TextMatrix(.Rows - 1, 1) = "" Then .RemoveItem .Rows - 1
        For i = 1 To .Rows - 1
            Index = Index + 1
            clsND.MaFile = CStr(Number) & CStr(Index)
            clsND.MaCD = CD_Code
            clsND.TenFile = .TextMatrix(i, 1)
            clsND.CaSi = .TextMatrix(i, 2)
            clsND.ThemND
        Next i
    End With
    sb1.Panels(1).Text = "Done."
cmdPrev_Click
End Sub

