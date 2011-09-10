#pragma once


// GLViewPixFormatDlg dialog

class GLViewPixFormatDlg : public CDialog
{
	DECLARE_DYNAMIC(GLViewPixFormatDlg)

// Pixel format specific data
    int 
        iFormatNumber;

    PPIXELFORMATDESCRIPTOR
        pFormatDesc;

public:
	GLViewPixFormatDlg(CWnd* pParent = NULL);   // standard constructor
	virtual ~GLViewPixFormatDlg();

// Dialog Data
	enum { IDD = IDD_GLVIEW_PFORMAT };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support

	DECLARE_MESSAGE_MAP()
public:
    virtual BOOL OnInitDialog();
};
