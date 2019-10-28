// CSerialPort.cpp

#include "stdafx.h"
#include <windows.h>
#include <stdio.h>

#include "CSerialPort.h"


CSerialPort::CSerialPort() :m_hComm(INVALID_HANDLE_VALUE)
{

}

CSerialPort::~CSerialPort()
{
  Close();
}

BOOL CSerialPort::Open(DWORD dwPort, DWORD dwBaud, Parity parity, BYTE DataBits,
          StopBits stopBits, FlowControl fc, BOOL bOverlapped)
{
  char pszPort[32];
  sprintf(pszPort, "\\\\.\\COM%d", dwPort);
  m_hComm = CreateFile(pszPort
                      , GENERIC_READ | GENERIC_WRITE 
                      , 0, nullptr, OPEN_EXISTING
                      , FILE_ATTRIBUTE_NORMAL | (bOverlapped ? FILE_FLAG_OVERLAPPED : 0)
                      , nullptr);
  if (m_hComm == INVALID_HANDLE_VALUE)
    return FALSE;

  


  //Get the current state prior to changing it
  DCB dcb;
  dcb.DCBlength = sizeof(DCB);
  if (!GetCommState(m_hComm, &dcb))
  {   
    const DWORD dwLastError = GetLastError();
    Close();
    SetLastError(dwLastError);
    return FALSE;
  }

  //Setup the baud rate
  dcb.BaudRate = dwBaud;

  //Setup the Parity
  switch (parity)
  {
    case EvenParity:
    {
      dcb.Parity = EVENPARITY;
      break;
    }
    case MarkParity:
    {
      dcb.Parity = MARKPARITY;
      break;
    }
    case NoParity:
    {
      dcb.Parity = NOPARITY;
      break;
    }
    case OddParity:
    {
      dcb.Parity = ODDPARITY;
      break;
    }
    case SpaceParity:
    {
      dcb.Parity = SPACEPARITY;
      break;
    }
   
  }

  //Setup the data bits
  dcb.ByteSize = DataBits;

  //Setup the stop bits
  switch (stopBits)
  {
    case OneStopBit:
    {
      dcb.StopBits = ONESTOPBIT;
      break;
    }
    case OnePointFiveStopBits:
    {
      dcb.StopBits = ONE5STOPBITS;
      break;
    }
    case TwoStopBits:
    {
      dcb.StopBits = TWOSTOPBITS;
      break;
    }
  }

  //Setup the flow control
  dcb.fDsrSensitivity = FALSE;
  switch (fc)
  {
    case NoFlowControl:
    {
      dcb.fOutxCtsFlow = FALSE;
      dcb.fOutxDsrFlow = FALSE;
      dcb.fOutX = FALSE;
      dcb.fInX = FALSE;
      break;
    }
    case CtsRtsFlowControl:
    {
      dcb.fOutxCtsFlow = TRUE;
      dcb.fOutxDsrFlow = FALSE;
      dcb.fRtsControl = RTS_CONTROL_HANDSHAKE;
      dcb.fOutX = FALSE;
      dcb.fInX = FALSE;
      break;
    }
    case CtsDtrFlowControl:
    {
      dcb.fOutxCtsFlow = TRUE;
      dcb.fOutxDsrFlow = FALSE;
      dcb.fDtrControl = DTR_CONTROL_HANDSHAKE;
      dcb.fOutX = FALSE;
      dcb.fInX = FALSE;
      break;
    }
    case DsrRtsFlowControl:
    {
      dcb.fOutxCtsFlow = FALSE;
      dcb.fOutxDsrFlow = TRUE;
      dcb.fRtsControl = RTS_CONTROL_HANDSHAKE;
      dcb.fOutX = FALSE;
      dcb.fInX = FALSE;
      break;
    }
    case DsrDtrFlowControl:
    {
      dcb.fOutxCtsFlow = FALSE;
      dcb.fOutxDsrFlow = TRUE;
      dcb.fDtrControl = DTR_CONTROL_HANDSHAKE;
      dcb.fOutX = FALSE;
      dcb.fInX = FALSE;
      break;
    }
    case XonXoffFlowControl:
    {
      dcb.fOutxCtsFlow = FALSE;
      dcb.fOutxDsrFlow = FALSE;
      dcb.fOutX = TRUE;
      dcb.fInX = TRUE;
      dcb.XonChar = 0x11;
      dcb.XoffChar = 0x13;
      dcb.XoffLim = 100;
      dcb.XonLim = 100;
      break;
    }
  }

  //Now that we have all the settings in place, make the changes
  if (!SetCommState(m_hComm, &dcb))
  {
    const DWORD dwLastError = GetLastError();
    Close();
    SetLastError(dwLastError);
    return FALSE;
  }

  return TRUE;
}

void CSerialPort::Close()
{
  if (IsOpen())
  {
    //Close down the comms port
    CloseHandle(m_hComm);
    m_hComm = INVALID_HANDLE_VALUE;
  }
}

BOOL CSerialPort::IsOpen() const
{
  return m_hComm != INVALID_HANDLE_VALUE;
}


//Timeouts
BOOL CSerialPort::SetTimeouts(COMMTIMEOUTS& timeouts)
{
  BOOL rv = FALSE;

  if (IsOpen())
    rv = SetCommTimeouts(m_hComm, &timeouts);

  return rv;
}

BOOL CSerialPort::GetTimeouts(COMMTIMEOUTS& timeouts)
{
  BOOL rv = FALSE;

  if (IsOpen())
    rv = GetCommTimeouts(m_hComm, &timeouts);

  return rv;
}
 
BOOL CSerialPort::Set0Timeout()
{
  COMMTIMEOUTS Timeouts;
  memset(&Timeouts, 0, sizeof(Timeouts));
  Timeouts.ReadIntervalTimeout = MAXDWORD;
  return SetTimeouts(Timeouts);
}

BOOL CSerialPort::Set0WriteTimeout()
{
  COMMTIMEOUTS Timeouts;
  GetTimeouts(Timeouts);
  Timeouts.WriteTotalTimeoutMultiplier = 0;
  Timeouts.WriteTotalTimeoutConstant = 0;
  return SetTimeouts(Timeouts);
}

BOOL CSerialPort::Set0ReadTimeout()
{
  COMMTIMEOUTS Timeouts;
  GetTimeouts(Timeouts);
  Timeouts.ReadIntervalTimeout = MAXDWORD;
  Timeouts.ReadTotalTimeoutMultiplier = 0;
  Timeouts.ReadTotalTimeoutConstant = 0;
  return SetTimeouts(Timeouts);
}


//Event Methods
BOOL CSerialPort::SetMask(DWORD dwMask) 
{
  BOOL rv = FALSE;

  if (IsOpen())
    rv = SetCommMask(m_hComm, dwMask);

  return rv;
}

BOOL CSerialPort::GetMask(DWORD& dwMask)
{
  BOOL rv = FALSE;

  if (IsOpen())
    rv = GetCommMask(m_hComm, &dwMask);

  return rv;
}

BOOL CSerialPort::WaitEvent(DWORD& dwMask)
{
  BOOL rv = FALSE;

  if (IsOpen())
    rv = WaitCommEvent(m_hComm, &dwMask, nullptr);

  return rv;
}

BOOL CSerialPort::WaitEvent(DWORD& dwMask, OVERLAPPED& overlapped)
{
  BOOL rv = FALSE;

  if (IsOpen() && overlapped.hEvent != nullptr)
    rv = WaitCommEvent(m_hComm, &dwMask, &overlapped);

  return rv;
}

//Queue Methods
BOOL CSerialPort::Flush()
{
  BOOL rv = FALSE;

  if (IsOpen())
    rv = FlushFileBuffers(m_hComm);

  return rv;
}


BOOL CSerialPort::Purge(_In_ DWORD dwFlags)
{
  BOOL rv = FALSE;

  if (IsOpen())
    rv = PurgeComm(m_hComm, dwFlags);

  return rv;
}

BOOL CSerialPort::TerminateOutstandingWrites()
{
  return Purge(PURGE_TXABORT);
}

BOOL CSerialPort::TerminateOutstandingReads()
{
  return Purge(PURGE_RXABORT);
}

BOOL CSerialPort::ClearWriteBuffer()
{
  return Purge(PURGE_TXCLEAR);
}

BOOL CSerialPort::ClearReadBuffer()
{
  return Purge(PURGE_RXCLEAR);
}

BOOL CSerialPort::Setup(DWORD dwInQueue, DWORD dwOutQueue)
{
  BOOL rv = FALSE;

  if (IsOpen())
    rv = SetupComm(m_hComm, dwInQueue, dwOutQueue);

  return rv;
}



BOOL CSerialPort::Escape(DWORD dwFunc)
{
  BOOL rv = FALSE;

  if (IsOpen())
    rv = EscapeCommFunction(m_hComm, dwFunc);

  return rv;
}

BOOL CSerialPort::ClearDTR()
{
  return Escape(CLRDTR);
}

BOOL CSerialPort::ClearRTS()
{
  return Escape(CLRRTS);
}

BOOL CSerialPort::SetDTR() 
{
  return Escape(SETDTR);
}

BOOL CSerialPort::SetRTS()
{
  return Escape(SETRTS);
}

BOOL CSerialPort::SetXOFF()
{
  return Escape(SETXOFF);
}

BOOL CSerialPort::SetXON()
{
  return Escape(SETXON);
}

BOOL CSerialPort::GetProperties(COMMPROP& properties)
{
  BOOL rv = FALSE;

  if (IsOpen())
    rv = GetCommProperties(m_hComm, &properties);

  return rv;
}

BOOL CSerialPort::GetModemStatus(DWORD& dwModemStatus)
{
  BOOL rv = FALSE;

  if (IsOpen())
    rv = GetCommModemStatus(m_hComm, &dwModemStatus);

  return rv;
}





BOOL CSerialPort::Read(void* lpBuffer, DWORD dwNumberOfBytesToRead, OVERLAPPED* overlapped, DWORD* lpNumberOfBytesRead)
{
  BOOL rv = FALSE;

  if (IsOpen())
    rv = ReadFile(m_hComm, lpBuffer, dwNumberOfBytesToRead, lpNumberOfBytesRead, overlapped);

  return rv;
}

BOOL CSerialPort::ReadEx(LPVOID lpBuffer, DWORD dwNumberOfBytesToRead, LPOVERLAPPED lpOverlapped, LPOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine)
{
  BOOL rv = FALSE;

  if (IsOpen())
    rv = ReadFileEx(m_hComm, lpBuffer, dwNumberOfBytesToRead, lpOverlapped, lpCompletionRoutine);

  return rv;
}

BOOL CSerialPort::Write(const void* lpBuffer, DWORD dwNumberOfBytesToWrite, OVERLAPPED& overlapped, DWORD* lpNumberOfBytesWritten)
{
  BOOL rv = FALSE;

  if (IsOpen())
    rv = WriteFile(m_hComm, lpBuffer, dwNumberOfBytesToWrite, lpNumberOfBytesWritten, &overlapped);

  return rv;
}

BOOL CSerialPort::WriteEx( LPCVOID lpBuffer, DWORD dwNumberOfBytesToWrite, LPOVERLAPPED lpOverlapped, LPOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine)
{
  BOOL rv = FALSE;

  if (IsOpen())
    rv = WriteFileEx(m_hComm, lpBuffer, dwNumberOfBytesToWrite, lpOverlapped, lpCompletionRoutine);

  return rv;
}

BOOL CSerialPort::TransmitChar(char cChar)
{
  BOOL rv = FALSE;

  if (IsOpen())
    rv = TransmitCommChar(m_hComm, cChar);

  return rv;
}



BOOL CSerialPort::GetOverlappedResult(OVERLAPPED& overlapped, DWORD& dwBytesTransferred, BOOL bWait)
{
  BOOL rv = FALSE;

  if (IsOpen())
    rv = ::GetOverlappedResult(m_hComm, &overlapped, &dwBytesTransferred, bWait);

  return rv;
}

//BOOL CSerialPort::GetOverlappedResultEx(OVERLAPPED& overlapped, DWORD& dwBytesTransferred, DWORD dwMilliseconds, BOOL bAlertable) 
//{
//  BOOL rv = FALSE;
//
//  if (IsOpen())
//    rv = ::GetOverlappedResultEx(m_hComm, &overlapped, &dwBytesTransferred, dwMilliseconds, bAlertable);
//
//  return rv;
//}

BOOL CSerialPort::CancelIo()
{
  BOOL rv = FALSE;

  if (IsOpen())
    rv = ::CancelIo(m_hComm);

  return rv;
}

BOOL CSerialPort::CancelIoEx(LPOVERLAPPED lpOverlapped)
{
  BOOL rv = FALSE;

  if (IsOpen())
    rv = ::CancelIoEx(m_hComm, lpOverlapped);

  return rv;
}

BOOL CSerialPort::BytesWaiting(DWORD& dwBytesWaiting)
{
  if (!IsOpen())
    return FALSE;

  //Check to see how many characters are unread
  dwBytesWaiting = 0;
  COMSTAT stat;
  if (!GetStatus(stat))
    return FALSE;
  dwBytesWaiting = stat.cbInQue;
  return TRUE;
}

BOOL CSerialPort::GetConfig(COMMCONFIG& config)
{
  if (!IsOpen())
    return FALSE;
  DWORD dwSize = sizeof(COMMCONFIG);

  return GetCommConfig(m_hComm, &config, &dwSize);
}

BOOL CSerialPort::GetDefaultConfig(COMMCONFIG& config, int nPort)
{
  char pszPort[32];
  sprintf(pszPort, "COM%d", nPort);

  return GetDefaultConfig(pszPort, config);
}

BOOL CSerialPort::GetDefaultConfig(char* pszPort, COMMCONFIG& config)
{
  DWORD dwSize = sizeof(COMMCONFIG);
  return GetDefaultCommConfig(pszPort, &config, &dwSize);
}

BOOL CSerialPort::SetConfig(COMMCONFIG& config)
{
  if (!IsOpen())
    return FALSE;
  
  const DWORD dwSize = sizeof(COMMCONFIG);
  return SetCommConfig(m_hComm, &config, dwSize);
}

BOOL CSerialPort::SetDefaultConfig(int nPort, COMMCONFIG& config)
{
  char pszPort[32];
  sprintf(pszPort, "COM%d", nPort);   
    
  return SetDefaultConfig(pszPort, config);
}

BOOL CSerialPort::SetDefaultConfig(LPCTSTR pszPort, COMMCONFIG& config)
{    
  const DWORD dwSize = sizeof(COMMCONFIG);
  return SetDefaultCommConfig(pszPort, &config, dwSize);
}

BOOL CSerialPort::GetStatus(COMSTAT& stat)
{
  if (!IsOpen())
    return FALSE;
  
  DWORD dwErrors = 0;
  return ClearCommError(m_hComm, &dwErrors, &stat);
}


//Misc RS232 Methods
BOOL CSerialPort::ClearBreak()
{
  if (!IsOpen())
    return FALSE;

  return ClearCommBreak(m_hComm);
}

BOOL CSerialPort::SetBreak()
{
  if (!IsOpen())
    return FALSE;

  return SetCommBreak(m_hComm);
}

BOOL CSerialPort::ClearError(DWORD& dwErrors) 
{
  if (!IsOpen())
    return FALSE;

  return ClearCommError(m_hComm, &dwErrors, nullptr);
}

BOOL CSerialPort::GetState(DCB& dcb)
{
  if (!IsOpen())
    return FALSE;
   
  return GetCommState(m_hComm, &dcb);
}

BOOL CSerialPort::SetState(DCB& dcb) 
{
  if (!IsOpen())
    return FALSE;
      
  return SetCommState(m_hComm, &dcb);
}

