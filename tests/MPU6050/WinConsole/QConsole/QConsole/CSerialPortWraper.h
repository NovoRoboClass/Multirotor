// CSerialPortWraper.h

#ifndef CSERIALPORTWRAPER_H
#define CSERIALPORTWRAPER_H

#include "CSerialPort.h"




class CSerialPortWraper {

public:

  BOOL Init(int32_t i32_PortNum, uint32_t u32_comPortBitrate);
  BOOL WaitEvent(DWORD& dwMask);
  BOOL Read(void* lpBuffer, DWORD dwNumberOfBytesToRead, OVERLAPPED* overlapped, DWORD* lpNumberOfBytesRead);
  void Write();
  BOOL SetMask(DWORD);
  BOOL ResetEvent();
  BOOL SetEvent();

private:
  CSerialPortWraper();

  BOOL        m_b_initOk;
  BOOL        m_b_overlapped;
  CSerialPort serialPort;
  OVERLAPPED  m_h_OverLapped;

  friend CSerialPortWraper& InstanceSerialPortWraper();

};


CSerialPortWraper& InstanceSerialPortWraper();

#endif
