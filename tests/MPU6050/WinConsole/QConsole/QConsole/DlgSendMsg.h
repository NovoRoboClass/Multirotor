#pragma once


// диалоговое окно CDlgSendMsg

class CDlgSendMsg : public CDialogEx
{
	DECLARE_DYNAMIC(CDlgSendMsg)

public:
	CDlgSendMsg(CWnd* pParent = NULL);   // стандартный конструктор
	virtual ~CDlgSendMsg();

// Данные диалогового окна
	enum { IDD = IDD_SEND_MSG };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // поддержка DDX/DDV

	DECLARE_MESSAGE_MAP()
public:
  afx_msg void OnBnClickedSend();
  CString m_strCmd;
  CString m_strData;
};
