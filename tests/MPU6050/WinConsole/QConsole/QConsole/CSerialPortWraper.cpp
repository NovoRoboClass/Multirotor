// CSerialPortWraper.cpp

#include "stdafx.h"
#include <stdint.h>
#include "CSerialPortWraper.h"

CSerialPortWraper& InstanceSerialPortWraper()
{
  static CSerialPortWraper wraper;
  return wraper;
}

CSerialPortWraper::CSerialPortWraper() : m_b_initOk(FALSE), m_b_overlapped(FALSE)
{
}

BOOL CSerialPortWraper::Init(int32_t i32_PortNum, uint32_t u32_comPortBitrate)
{
  
  
  COMMTIMEOUTS timeouts  = { 0 };
  m_b_initOk = serialPort.Open(i32_PortNum, u32_comPortBitrate);

  if (m_b_overlapped)
  {
    memset ((char *)&m_h_OverLapped, 0, sizeof(OVERLAPPED));
    m_h_OverLapped.hEvent = CreateEvent (NULL, TRUE, FALSE, 0);
  }
  
  if (!m_b_initOk)
    return FALSE;

  m_b_initOk &= serialPort.GetTimeouts(timeouts);
  timeouts.ReadIntervalTimeout         = 100; // in milliseconds
  timeouts.ReadTotalTimeoutConstant    = 100; // in milliseconds
  timeouts.ReadTotalTimeoutMultiplier  = 100; // in milliseconds
  timeouts.WriteTotalTimeoutConstant   = 50; // in milliseconds
  timeouts.WriteTotalTimeoutMultiplier = 10; // in milliseconds
  m_b_initOk &= serialPort.SetTimeouts(timeouts);
  
  if (!m_b_initOk)
    return FALSE;

  m_b_initOk &= serialPort.SetMask(EV_RXCHAR);

  return m_b_initOk;
}

BOOL CSerialPortWraper::SetMask(DWORD dw_mask)
{
  return serialPort.SetMask(dw_mask);
}


BOOL CSerialPortWraper::WaitEvent(DWORD& dwMask)
{
  if (!m_b_initOk)
    return FALSE;

  if (m_b_overlapped)
    return serialPort.WaitEvent(dwMask, m_h_OverLapped);

  return serialPort.WaitEvent(dwMask);
}

BOOL CSerialPortWraper::Read(void* lpBuffer, DWORD dwNumberOfBytesToRead, OVERLAPPED* overlapped, DWORD* lpNumberOfBytesRead)
{
  if (!m_b_initOk)
    return FALSE;

  return serialPort.Read(lpBuffer, dwNumberOfBytesToRead, overlapped, lpNumberOfBytesRead);
}

void CSerialPortWraper::Write()
{
  if (!m_b_initOk)
    return;


}


BOOL CSerialPortWraper::ResetEvent()
{
  return ::ResetEvent(m_h_OverLapped.hEvent);
}

BOOL CSerialPortWraper::SetEvent()
{
  return ::SetEvent(m_h_OverLapped.hEvent);
}



