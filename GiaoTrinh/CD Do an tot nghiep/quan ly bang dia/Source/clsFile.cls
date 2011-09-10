VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "clsFile"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Attribute VB_Ext_KEY = "SavedWithClassBuilder6" ,"Yes"
Attribute VB_Ext_KEY = "Top_Level" ,"Yes"
'local variable(s) to hold property value(s)
Private mvarFilename As String 'local copy
Private mvarPath As String 'local copy
Private mvarIsFolder As String 'local copy
Public Property Let IsFolder(ByVal vData As String)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.IsFolder = 5
    mvarIsFolder = vData
End Property


Public Property Get IsFolder() As String
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.IsFolder
    IsFolder = mvarIsFolder
End Property



Public Property Let Path(ByVal vData As String)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.Path = 5
    mvarPath = vData
End Property


Public Property Get Path() As String
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.Path
    Path = mvarPath
End Property



Public Property Let Filename(ByVal vData As String)
'used when assigning a value to the property, on the left side of an assignment.
'Syntax: X.Filename = 5
    mvarFilename = vData
End Property


Public Property Get Filename() As String
'used when retrieving value of a property, on the right side of an assignment.
'Syntax: Debug.Print X.Filename
    Filename = mvarFilename
End Property



