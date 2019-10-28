
// QConsoleDlg.h : header file
//

#pragma once
#include "afxwin.h"

#include "ComPortCombo.h"

// CQConsoleDlg dialog
class CQConsoleDlg : public CDialogEx
{
// Construction
public:
	CQConsoleDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_QCONSOLE_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
private:
  void DoOnExit();
  bool m_b_run;
  CWinThread* m_h_serialPortRxThread;

public:
//  CComboBox m_ComPortCombo;
  afx_msg void OnCbnSelchangeComboComPort();
  CComPortCombo m_ComPortBox;
  afx_msg void OnBnClickedButtonRun();
//  int m_i32Bitrate;
  int m_i32Bitrate;
  afx_msg void OnBnClickedSendMsg();
  afx_msg void OnClose();
  afx_msg void OnBnClickedCancel();
  afx_msg void OnBnClickedOk();
  bool IsRunning() const { return m_b_run;}
};
