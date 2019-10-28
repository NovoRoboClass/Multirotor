// DlgSendMsg.cpp: файл реализации
//

#include "stdafx.h"
#include "QConsole.h"
#include "DlgSendMsg.h"
#include "afxdialogex.h"
#include <stdint.h>
#include <vector>
#include "CSerialPortWraper.h"


// диалоговое окно CDlgSendMsg

IMPLEMENT_DYNAMIC(CDlgSendMsg, CDialogEx)

CDlgSendMsg::CDlgSendMsg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CDlgSendMsg::IDD, pParent)
{

  m_strCmd = _T("");
  m_strData = _T("");
}

CDlgSendMsg::~CDlgSendMsg()
{
}

void CDlgSendMsg::DoDataExchange(CDataExchange* pDX)
{
  CDialogEx::DoDataExchange(pDX);
  DDX_Text(pDX, IDC_CMD, m_strCmd);
  DDX_Text(pDX, IDC_DATA, m_strData);
}


BEGIN_MESSAGE_MAP(CDlgSendMsg, CDialogEx)
  ON_BN_CLICKED(IDC_SEND, &CDlgSendMsg::OnBnClickedSend)
END_MESSAGE_MAP()


// обработчики сообщений CDlgSendMsg


void CDlgSendMsg::OnBnClickedSend()
{
  // TODO: добавьте свой код обработчика уведомлений

  //byte c = 0;
  //              byte[] o;
  //              o = new byte[10];
  //              // with checksum 
  //              o[0] = (byte)'$';
  //              o[1] = (byte)'M';
  //              o[2] = (byte)'<';
  //              o[3] = (byte)0; c ^= o[3];       //no payload 
  //              o[4] = (byte)MSP_EEPROM_WRITE; c ^= o[4];
  //              o[5] = (byte)c;
  //              serialport.Write(o, 0, 6);

  UpdateData( TRUE );

  if (m_strCmd.GetLength() != 2)
  {
    MessageBox(_TEXT("неправильный размер введеных данных поля команда"), _TEXT("Временное окно"), MB_OK);
    return;
  }

  if (m_strData.GetLength() & 1)
  {
    MessageBox(_TEXT("неправильный размер введеных данных поля данные"), _TEXT("Временное окно"), MB_OK);
    return;
  }

  std::vector<uint8_t> vMsg;
  uint32_t u32_tmp;
  int32_t  i32_rv;
  i32_rv = sscanf_s(m_strCmd, "%X", &u32_tmp);
  if (i32_rv == 0)
  {
    MessageBox(_TEXT("невозможно преобразовать введеные данные поля команда"), _TEXT("Временное окно"), MB_OK);
    return;
  }
  vMsg.push_back('$');
  vMsg.push_back('M');
  vMsg.push_back('<');
  

  if (m_strData.GetLength() > 0)
  {
    uint32_t u32_len = m_strData.GetLength() >> 1;
    
    vMsg.push_back(u32_len);
    vMsg.push_back(u32_tmp);

    
    char  u8_buf[3];
    memset(u8_buf, sizeof(u8_buf), 0);
    for (uint32_t i = 0; i < u32_len; i++)
    {
      u8_buf[0] = m_strData[(i << 1)];
      u8_buf[1] = m_strData[(i << 1) + 1];
      i32_rv = sscanf_s(u8_buf, "%X", &u32_tmp);
      if (i32_rv == 0)
      {
        MessageBox(_TEXT("невозможно преобразовать введеные данные поля данные"), _TEXT("Временное окно"), MB_OK);
        return;
      }
      else
      {
        vMsg.push_back(u32_tmp);
      }
    }
  }
  else
  {
    vMsg.push_back(0);
    vMsg.push_back(u32_tmp);
  }

  uint8_t u8_crc = 0;
  for (uint32_t i = 3; i < vMsg.size(); i++)
  {
    u8_crc^= vMsg[i];
  }
  vMsg.push_back(u8_crc);

  CString strTmp = m_strCmd + m_strData;
  MessageBox(strTmp, _TEXT("Временное окно"), MB_OK);

  //MessageBox(_TEXT("888"), _TEXT("Временное окно"), MB_OK);
}
