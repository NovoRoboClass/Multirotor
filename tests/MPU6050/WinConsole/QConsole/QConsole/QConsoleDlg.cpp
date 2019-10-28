
// QConsoleDlg.cpp : implementation file
//

#include "stdafx.h"
#include "QConsole.h"
#include "QConsoleDlg.h"
#include "afxdialogex.h"

#include <stdint.h>
#include "ComPortDefines.h"
#include "SerialPort.h"
#include "CSerialPort.h"
#include "ConsoleLogger.h"
#include "DlgSendMsg.h"
#include "CSerialPortWraper.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif




CQConsoleDlg::CQConsoleDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CQConsoleDlg::IDD, pParent)
{
  m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
  m_i32Bitrate = 8;
  m_b_run = true;
  m_h_serialPortRxThread = 0;
}

void CQConsoleDlg::DoDataExchange(CDataExchange* pDX)
{
  CDialogEx::DoDataExchange(pDX);
  //  DDX_Control(pDX, IDC_COMBO_COM_PORT, m_ComPortCombo);
  DDX_Control(pDX, IDC_COMBO_COM_PORT, m_ComPortBox);
  //  DDX_CBIndex(pDX, IDC_COMBO_COM_BITRATE, m_i32Bitrate);
  //  DDV_MinMaxInt(pDX, m_i32Bitrate, 300, 115200);
  DDX_CBIndex(pDX, IDC_COMBO_COM_BITRATE, m_i32Bitrate);
	DDV_MinMaxInt(pDX, m_i32Bitrate, 0, 8);
}

BEGIN_MESSAGE_MAP(CQConsoleDlg, CDialogEx)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
  ON_CBN_SELCHANGE(IDC_COMBO_COM_PORT, &CQConsoleDlg::OnCbnSelchangeComboComPort)
  ON_BN_CLICKED(IDC_BUTTON_RUN, &CQConsoleDlg::OnBnClickedButtonRun)
  ON_BN_CLICKED(IDC_SEND_MSG, &CQConsoleDlg::OnBnClickedSendMsg)
  ON_WM_CLOSE()
  ON_BN_CLICKED(IDCANCEL, &CQConsoleDlg::OnBnClickedCancel)
  ON_BN_CLICKED(IDOK, &CQConsoleDlg::OnBnClickedOk)
END_MESSAGE_MAP()


// CQConsoleDlg message handlers

BOOL CQConsoleDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

  m_ComPortBox.InitList(3);
  
  //m_i32Bitrate = 8;  
  //UpdateData( TRUE );

	// TODO: Add extra initialization here

	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CQConsoleDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CQConsoleDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}



void CQConsoleDlg::OnCbnSelchangeComboComPort()
{
  // TODO: добавьте свой код обработчика уведомлений
}


//-------------------------------------------------------
UINT SerialPortProc(LPVOID Param);
typedef struct {
 HWND     hwnd; 
 CONFIG   config;
 int32_t  i32_PortNum;
 uint32_t u32_comPortBitrate;
 CQConsoleDlg* mainDlg;
} SERPORT_ARG, *LPSERPORT_ARG;

SERPORT_ARG SerPortArg;

//-------------------------------------------------------

void CQConsoleDlg::OnBnClickedButtonRun()
{
  // TODO: добавьте свой код обработчика уведомлений
  UpdateData( TRUE );

  int int32_PortNum = m_ComPortBox.GetPortNum();
  TCHAR buf[100];
  sprintf(buf, "m_i32Bitrate %s   int32_PortNum: %d", tz_ComPortBitrate[m_i32Bitrate],  int32_PortNum);
  


  //this->GetSafeHwnd();
  SerPortArg.hwnd = (HWND) this;
  SerPortArg.config.mask = SPCF_PORTNAME;
  sprintf(buf, "%d", int32_PortNum);
  SerPortArg.config.pszPortName = buf;
  SerPortArg.i32_PortNum = int32_PortNum;
  SerPortArg.u32_comPortBitrate = u32_ComPortBitrate[m_i32Bitrate];
  SerPortArg.mainDlg = this;
  



  m_h_serialPortRxThread = AfxBeginThread( SerialPortProc, &SerPortArg);
    


  //MessageBox(buf, "Test", MB_OK);


}



UINT SerialPortProc(LPVOID Param)
{
//  MessageBox(NULL, "Thread", "Test", MB_OK);

  LPSERPORT_ARG p_arg = (LPSERPORT_ARG) Param;
  COMMCONFIG config;
  //CSerialPort serialPort;  
  //COMMTIMEOUTS timeouts  = { 0 };
  DWORD dwReciveMask;
  OVERLAPPED overlapped;
  uint8_t u8_reciveBuffer[16];

  CConsoleLoggerEx coloured_console;
	coloured_console.Create("This is the coloured console");
  coloured_console.printf("\n  1223\n");

  

  p_arg->i32_PortNum;
  p_arg->u32_comPortBitrate;
  //BOOL isOk = serialPort.Open(p_arg->i32_PortNum, p_arg->u32_comPortBitrate);
  
  CSerialPortWraper& port = InstanceSerialPortWraper();
  port.Init(p_arg->i32_PortNum, p_arg->u32_comPortBitrate);
  
  //serialPort.GetTimeouts(timeouts);
  //timeouts.ReadIntervalTimeout         = 50; // in milliseconds
  //timeouts.ReadTotalTimeoutConstant    = 50; // in milliseconds
  //timeouts.ReadTotalTimeoutMultiplier  = 10; // in milliseconds
  //timeouts.WriteTotalTimeoutConstant   = 50; // in milliseconds
  //timeouts.WriteTotalTimeoutMultiplier = 10; // in milliseconds
  //serialPort.SetTimeouts(timeouts);
  //
  //serialPort.SetMask(EV_RXCHAR);  
  //serialPort.WaitEvent(dwReciveMask);

  //port.WaitEvent(dwReciveMask);
  
  
  memset(u8_reciveBuffer, 0, sizeof(u8_reciveBuffer));

  
  char TempChar; //Temporary character used for reading
  char SerialBuffer[256];//Buffer for storing Rxed Data
  DWORD NoBytesRead;
  int i = 0, cnt = 0, hbcnt = 0;

  do
 {
   char consoleBuf[32];
   memset(consoleBuf, 0, sizeof(consoleBuf));


   //serialPort.Read(&u8_reciveBuffer, sizeof(u8_reciveBuffer), NULL, &NoBytesRead);
   port.Read(&u8_reciveBuffer, sizeof(u8_reciveBuffer), NULL, &NoBytesRead);


   
   //SerialBuffer[i] = TempChar;// Store Tempchar into buffer
   i++;

   memmove(consoleBuf, u8_reciveBuffer,  NoBytesRead);
   //coloured_console.printf(" %s->%d ", consoleBuf, NoBytesRead);
   if (NoBytesRead)
     coloured_console.printf("%s", consoleBuf);
   //coloured_console.printf("->%d ", NoBytesRead);



    //if (!port.WaitEvent(dwReciveMask))
    //{
    //  cnt++;
    //  port.ResetEvent();
    //}

    //hbcnt++;

    //if (0 == cnt % 10)
    //  coloured_console.printf("-->\n");
    //
    //if (0 == hbcnt % 50)
    //  coloured_console.printf("~~~\n");
    
    //if (i > 250) break;

 } while (p_arg->mainDlg->IsRunning()); //(true); //(NoBytesRead > 0);

 coloured_console.printf("\nEND\n");

 //coloured_console.printf(SerialBuffer);
   
   //m_h_serialPortRxThread = 0;
   return TRUE;
}


void CQConsoleDlg::OnBnClickedSendMsg()
{
  // TODO: добавьте свой код обработчика уведомлений
  CDlgSendMsg dlg;
	INT_PTR nResponse = dlg.DoModal();
}


void CQConsoleDlg::OnClose()
{
  // TODO: добавьте свой код обработчика сообщений или вызов стандартного
  MessageBox("OnClose", "Qconsole", MB_OK);
  CDialogEx::OnClose();
}


void CQConsoleDlg::OnBnClickedCancel()
{
  // TODO: добавьте свой код обработчика уведомлений
  DoOnExit();
  MessageBox("OnBnClickedCancel", "Qconsole", MB_OK);
  
  CDialogEx::OnCancel();
}


void CQConsoleDlg::OnBnClickedOk()
{
  // TODO: добавьте свой код обработчика уведомлений
  DoOnExit();
  MessageBox("OnBnClickedOk", "Qconsole", MB_OK);
  
  CDialogEx::OnOK();
}

void CQConsoleDlg::DoOnExit()
{
  //if (m_h_serialPortRxThread)
  //{ 
  //  ::TerminateThread(m_h_serialPortRxThread->m_hThread, 0);
  //  CloseHandle(m_h_serialPortRxThread->m_hThread);
  //}

  
  m_b_run = false;
  CSerialPortWraper& port = InstanceSerialPortWraper();
  port.SetEvent();
  BOOL rv = port.SetMask(0);
  if (m_h_serialPortRxThread)
    WaitForSingleObject(m_h_serialPortRxThread->m_hThread, INFINITE);
  m_b_run = false;
  
  

}



//linux - use select time out check.
//
//win32 - use overlapped method. 
//
//Open Serial Port Option by Overlapped.
//
//HANDLE SPortHandle=
//CreateFile (.. .. FILE_FLAG_OVERLAPPED | FILE_ATTRIBUTE_NORMAL,NULL);
//
////
//// check serial port data
////
//int isindataserialport(Cport , msec )
//{
//    int ret=1; // true , false;
//    DWORD fdwCommMask;
//    SetCommMask (Cport,/*EV_CTS | EV_DSR| */ EV_RXCHAR);
//    #ifdef _WIN32_WCE
//        WaitCommEvent (Cport, &fdwCommMask, 0);
//    #else
//        OVERLAPPED OverLapped;
//        memset ((char *)&OverLapped, 0, sizeof(OVERLAPPED));
//        OverLapped.hEvent = CreateEvent (NULL, TRUE, TRUE, 0);
//        if (!WaitCommEvent (Cport, &fdwCommMask, &OverLapped))
//       {
//            if (GetLastError() == ERROR_IO_PENDING)
//            {
//                if(WaitForSingleObject (OverLapped.hEvent,(DWORD) msec) != WAIT_OBJECT_0)
//                {
//                     ret=0;
//                }
//            }
//        }
//        CloseHandle(OverLapped.hEvent);
//    #endif
//
//    if((fdwCommMask & EV_RXCHAR) != EV_RXCHAR)
//   {
//        ret=0;
//    }
//    return ret;
//}




