#pragma once


// ���������� ���� CDlgSendMsg

class CDlgSendMsg : public CDialogEx
{
	DECLARE_DYNAMIC(CDlgSendMsg)

public:
	CDlgSendMsg(CWnd* pParent = NULL);   // ����������� �����������
	virtual ~CDlgSendMsg();

// ������ ����������� ����
	enum { IDD = IDD_SEND_MSG };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // ��������� DDX/DDV

	DECLARE_MESSAGE_MAP()
public:
  afx_msg void OnBnClickedSend();
  CString m_strCmd;
  CString m_strData;
};
