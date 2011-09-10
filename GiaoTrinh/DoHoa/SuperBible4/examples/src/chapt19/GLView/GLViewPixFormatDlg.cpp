// GLViewPixFormatDlg.cpp : implementation file
//

#include "stdafx.h"
#include "GLView.h"
#include "GLViewPixFormatDlg.h"
#include ".\glviewpixformatdlg.h"


// GLViewPixFormatDlg dialog

IMPLEMENT_DYNAMIC(GLViewPixFormatDlg, CDialog)
GLViewPixFormatDlg::GLViewPixFormatDlg(CWnd* pParent /*=NULL*/)
	: CDialog(GLViewPixFormatDlg::IDD, pParent)
{
}

GLViewPixFormatDlg::~GLViewPixFormatDlg()
{
}

void GLViewPixFormatDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}


BEGIN_MESSAGE_MAP(GLViewPixFormatDlg, CDialog)
END_MESSAGE_MAP()


// GLViewPixFormatDlg message handlers

BOOL GLViewPixFormatDlg::OnInitDialog()
{
    CDialog::OnInitDialog();
    CString str;

    // TODO:  Add extra initialization here
	CDialog::OnInitDialog();
//	CDHtmlDialog::OnInitDialog();
    CString sTemp;

    // Crack the data in the format descriptor
    SetDlgItemInt(IDC_ED_FORMAT,         iFormatNumber        ,        0);
    SetDlgItemInt(IDC_ED_SIZE,           pFormatDesc->nSize   ,        0);
    SetDlgItemInt(IDC_ED_VERSION,        pFormatDesc->nVersion,        0);

    SetDlgItemInt(IDC_ED_COLORBITS,      pFormatDesc->cColorBits,      0);
    SetDlgItemInt(IDC_ED_REDBITS,        pFormatDesc->cRedBits,        0);
    SetDlgItemInt(IDC_ED_GREENBITS,      pFormatDesc->cGreenBits,      0);
    SetDlgItemInt(IDC_ED_BLUEBITS,       pFormatDesc->cBlueBits,       0);
    SetDlgItemInt(IDC_ED_ALPHABITS,      pFormatDesc->cAlphaBits,      0);
    SetDlgItemInt(IDC_ED_REDSHIFT,       pFormatDesc->cRedShift,       0);
    SetDlgItemInt(IDC_ED_GREENSHIFT,     pFormatDesc->cGreenShift,     0);
    SetDlgItemInt(IDC_ED_BLUESHIFT,      pFormatDesc->cBlueShift,      0);
    SetDlgItemInt(IDC_ED_ALPHASHIFT,     pFormatDesc->cAlphaShift,     0);

    SetDlgItemInt(IDC_ED_ACCUMBITS,      pFormatDesc->cAccumBits,      0);
    SetDlgItemInt(IDC_ED_ACCUMREDBITS,   pFormatDesc->cAccumRedBits,   0);
    SetDlgItemInt(IDC_ED_ACCUMGREENBITS, pFormatDesc->cAccumGreenBits, 0);
    SetDlgItemInt(IDC_ED_ACCUMBLUEBITS,  pFormatDesc->cAccumBlueBits,  0);
    SetDlgItemInt(IDC_ED_ACCUMALPHABITS, pFormatDesc->cAccumAlphaBits, 0);

    SetDlgItemInt(IDC_ED_DEPTHBITS,      pFormatDesc->cDepthBits,      0);
    SetDlgItemInt(IDC_ED_STENCILBITS,    pFormatDesc->cStencilBits,    0);
    SetDlgItemInt(IDC_ED_AUXBUFFERS,     pFormatDesc->cAuxBuffers,     0);
    SetDlgItemInt(IDC_ED_VISIBLEMASK,    pFormatDesc->dwVisibleMask,   0);

    SetDlgItemInt(IDC_ED_PIXELTYPE,      pFormatDesc->iLayerType,      0);
    SetDlgItemInt(IDC_ED_RESERVED,       pFormatDesc->bReserved,       0);

    SetDlgItemInt(IDC_ED_DAMAGEMASK,     pFormatDesc->dwDamageMask,    0);
    SetDlgItemInt(IDC_ED_LAYERTYPE,      pFormatDesc->iLayerType,      0);
    SetDlgItemInt(IDC_ED_LAYERMASK,      pFormatDesc->dwLayerMask,     0);

    // Flags field

    str.Format("%08X", pFormatDesc->dwFlags);
    SetDlgItemText(IDC_ED_FLAGS, str);

    ((CButton*)GetDlgItem(IDC_CH_DOUBLEBUFFER       ))->SetCheck(pFormatDesc->dwFlags&PFD_DOUBLEBUFFER       );
    ((CButton*)GetDlgItem(IDC_CH_STEREO             ))->SetCheck(pFormatDesc->dwFlags&PFD_STEREO             );
    ((CButton*)GetDlgItem(IDC_CH_DRAW_TO_WINDOW     ))->SetCheck(pFormatDesc->dwFlags&PFD_DRAW_TO_WINDOW     );
    ((CButton*)GetDlgItem(IDC_CH_DRAW_TO_BITMAP     ))->SetCheck(pFormatDesc->dwFlags&PFD_DRAW_TO_BITMAP     );
    ((CButton*)GetDlgItem(IDC_CH_SUPPORT_GDI        ))->SetCheck(pFormatDesc->dwFlags&PFD_SUPPORT_GDI        );
    ((CButton*)GetDlgItem(IDC_CH_SUPPORT_OPENGL     ))->SetCheck(pFormatDesc->dwFlags&PFD_SUPPORT_OPENGL     );
    ((CButton*)GetDlgItem(IDC_CH_GENERIC_FORMAT     ))->SetCheck(pFormatDesc->dwFlags&PFD_GENERIC_FORMAT     );
    ((CButton*)GetDlgItem(IDC_CH_NEED_PALETTE       ))->SetCheck(pFormatDesc->dwFlags&PFD_NEED_PALETTE       );
    ((CButton*)GetDlgItem(IDC_CH_NEED_SYSTEM_PALETTE))->SetCheck(pFormatDesc->dwFlags&PFD_NEED_SYSTEM_PALETTE);
    ((CButton*)GetDlgItem(IDC_CH_SWAP_EXCHANGE      ))->SetCheck(pFormatDesc->dwFlags&PFD_SWAP_EXCHANGE      );
    ((CButton*)GetDlgItem(IDC_CH_SWAP_COPY          ))->SetCheck(pFormatDesc->dwFlags&PFD_SWAP_COPY          );
    ((CButton*)GetDlgItem(IDC_CH_SWAP_LAYER_BUFFERS ))->SetCheck(pFormatDesc->dwFlags&PFD_SWAP_LAYER_BUFFERS );
    ((CButton*)GetDlgItem(IDC_CH_GENERIC_ACCELERATED))->SetCheck(pFormatDesc->dwFlags&PFD_GENERIC_ACCELERATED);
    ((CButton*)GetDlgItem(IDC_CH_SUPPORT_DIRECTDRAW ))->SetCheck(pFormatDesc->dwFlags&PFD_SUPPORT_DIRECTDRAW );

    ((CButton*)GetDlgItem(IDC_CH_INVALID_BITS))->SetCheck(pFormatDesc->dwFlags&0xffffc000L);

    //SetDlgItemInt(IDC_ED_FLAGS,      pFormatDesc->iLayerType,      0);

    // Display the pixel type field
    if (pFormatDesc->iPixelType == PFD_TYPE_RGBA)
        SetDlgItemText(IDC_ED_PIXELTYPETEXT, "PFD_TYPE_RGBA");
    else if (pFormatDesc->iPixelType == PFD_TYPE_COLORINDEX)
        SetDlgItemText(IDC_ED_PIXELTYPETEXT, "PFD_TYPE_COLORINDEX");
    else
        SetDlgItemText(IDC_ED_PIXELTYPETEXT, "!INVALID TYPE!");

    str.Format("%d overlay, %d underlay", pFormatDesc->bReserved&0x0f, pFormatDesc->bReserved>>4);
    SetDlgItemText(IDC_ED_RESERVEDTEXT, str);

    return TRUE;  // return TRUE unless you set the focus to a control
    // EXCEPTION: OCX Property Pages should return FALSE
}
