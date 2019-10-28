// CSerialPort.h

#ifndef CSERIALPORT_H
#define CSERIALPORT_H

class CSerialPort {

public:
  enum FlowControl
  {
    NoFlowControl,
    CtsRtsFlowControl,
    CtsDtrFlowControl,
    DsrRtsFlowControl,
    DsrDtrFlowControl,
    XonXoffFlowControl
  };

  enum Parity
  {
    NoParity = 0,
    OddParity = 1,
    EvenParity = 2,
    MarkParity = 3,
    SpaceParity = 4
  };

  enum StopBits
  {
    OneStopBit,
    OnePointFiveStopBits,
    TwoStopBits
  };


public:
  CSerialPort();
  ~CSerialPort();
  BOOL Open(DWORD dwPort, DWORD dwBaud = 9600, Parity parity = NoParity, BYTE DataBits = 8,
            StopBits stopBits = OneStopBit, FlowControl fc = NoFlowControl, 
            BOOL bOverlapped = FALSE);
  void Close();
  BOOL IsOpen() const;

  BOOL SetTimeouts(COMMTIMEOUTS& timeouts);
  BOOL GetTimeouts(COMMTIMEOUTS& timeouts);
  BOOL Set0Timeout();
  BOOL Set0WriteTimeout();
  BOOL Set0ReadTimeout();

  BOOL SetMask(DWORD dwMask);
  BOOL GetMask(DWORD& dwMask);

  BOOL WaitEvent(DWORD& dwMask);
  BOOL WaitEvent(DWORD& dwMask, OVERLAPPED& overlapped);

  BOOL Flush();
  BOOL Purge(_In_ DWORD dwFlags);
  BOOL TerminateOutstandingWrites();
  BOOL TerminateOutstandingReads();
  BOOL ClearWriteBuffer();
  BOOL ClearReadBuffer();
  BOOL Setup(DWORD dwInQueue, DWORD dwOutQueue);

  BOOL Escape(DWORD dwFunc);
  BOOL ClearDTR();
  BOOL ClearRTS();
  BOOL SetDTR();
  BOOL SetRTS();
  BOOL SetXOFF();
  BOOL SetXON();

  BOOL GetProperties(COMMPROP& properties);

  BOOL GetModemStatus(DWORD& dwModemStatus);

  BOOL Read(void* lpBuffer, DWORD dwNumberOfBytesToRead, 
            OVERLAPPED* overlapped, DWORD* lpNumberOfBytesRead = nullptr);
  BOOL ReadEx(LPVOID lpBuffer, DWORD dwNumberOfBytesToRead, LPOVERLAPPED lpOverlapped, 
              LPOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine);
  BOOL Write(const void* lpBuffer, DWORD dwNumberOfBytesToWrite, 
             OVERLAPPED& overlapped, DWORD* lpNumberOfBytesWritten = nullptr);
  BOOL WriteEx(LPCVOID lpBuffer, DWORD dwNumberOfBytesToWrite, LPOVERLAPPED lpOverlapped, 
               LPOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine);
  BOOL TransmitChar(char cChar);

  BOOL GetOverlappedResult(OVERLAPPED& overlapped, DWORD& dwBytesTransferred, BOOL bWait);
  //BOOL GetOverlappedResultEx(OVERLAPPED& overlapped, DWORD& dwBytesTransferred, DWORD dwMilliseconds, BOOL bAlertable);

  BOOL CancelIo();
  BOOL CancelIoEx(LPOVERLAPPED lpOverlapped = nullptr);

  BOOL BytesWaiting(DWORD& dwBytesWaiting);
  BOOL GetConfig(COMMCONFIG& config);
  static BOOL GetDefaultConfig(int nPort, COMMCONFIG& config);

  BOOL GetStatus(COMSTAT& stat);
  BOOL GetDefaultConfig(COMMCONFIG& config, int nPort);
  BOOL GetDefaultConfig(char* pszPort, COMMCONFIG& config);
  BOOL SetConfig(COMMCONFIG& config);
  BOOL SetDefaultConfig(int nPort, COMMCONFIG& config);
  BOOL SetDefaultConfig(LPCTSTR pszPort, COMMCONFIG& config);

  BOOL ClearBreak();
  BOOL SetBreak();
  BOOL ClearError(DWORD& dwErrors);

  BOOL GetState(DCB& dcb);
  BOOL SetState(DCB& dcb);

private:
  HANDLE m_hComm;

};

#endif
