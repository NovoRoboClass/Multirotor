#include "Arduino.h"
#include "config.h"
#include "def.h"
#include "MultiWii.h"
#include "Serial.h"

static volatile uint8_t serialHeadRX[UART_NUMBER],serialTailRX[UART_NUMBER];
static volatile uint8_t serialHeadTX[UART_NUMBER],serialTailTX[UART_NUMBER];

static uint8_t serialBufferRX[RX_BUFFER_SIZE][UART_NUMBER];
static uint8_t serialBufferTX[TX_BUFFER_SIZE][UART_NUMBER];


// *******************************************************
// For Teensy 2.0, these function emulate the API used for ProMicro
// it cant have the same name as in the arduino API because it wont compile for the promini (eaven if it will be not compiled)
// *******************************************************
unsigned char T_USB_Available(uint8_t port)
{
  int n ;
  switch (port)
  {
    case 0: n= Serial.available(); break;
    case 1: n= Serial1.available(); break;
    case 2: n= Serial2.available(); break;
    case 3: n= Serial3.available(); break;
  }
  if (n > 255) n = 255;
  return n;
}
  
unsigned char T_USB_Write(uint8_t port, uint8_t uc_data)
{
  int n;
  switch (port)
  {
    case 0: n= Serial.write(uc_data); break;
    case 1: n= Serial1.write(uc_data); break;
    case 2: n= Serial2.write(uc_data); break;
    case 3: n= Serial3.write(uc_data); break;
  }
  return n;
}

// *******************************************************
// Interrupt driven UART transmitter - using a ring buffer
// *******************************************************
void UartSendData(uint8_t port) 
{
  while(serialHeadTX[port] != serialTailTX[port]) 
  {
    if (++serialTailTX[port] >= TX_BUFFER_SIZE) 
      serialTailTX[port] = 0;
    T_USB_Write (port,serialBufferTX[serialTailTX[port]][port]);
  }    
}



void SerialOpen(uint8_t port, uint32_t baud) 
{
  uint8_t h = ((F_CPU  / 4 / baud -1) / 2) >> 8;
  uint8_t l = ((F_CPU  / 4 / baud -1) / 2);
  
  switch (port) 
  {
    case 0: Serial.begin(baud);  break;
    case 1: Serial1.begin(baud); break;
    case 2: Serial2.begin(baud); break;
    case 3: Serial3.begin(baud); break;    
  }
}

void SerialEnd(uint8_t port) 
{
  switch (port) 
  {  
    case 0: Serial.end(); break;
    case 1: Serial1.end(); break;
    case 2: Serial2.end(); break;
    case 3: Serial3.end(); break;   
  }
}

// we don't care about ring buffer overflow (head->tail) to avoid a test condition : data is lost anyway if it happens 
void store_uart_in_buf(uint8_t data, uint8_t portnum) 
{
  uint8_t h = serialHeadRX[portnum];
  serialBufferRX[h++][portnum] = data;
  if (h >= RX_BUFFER_SIZE) 
    h = 0;
  serialHeadRX[portnum] = h;
}


uint8_t SerialRead(uint8_t port)
{
  switch (port)
  {
    case 0: return Serial.read();
    case 1: return Serial1.read();
    case 2: return Serial2.read();
    case 3: return Serial3.read();
  }
  return 0; // as long as port is correct this line should never be reached.

//  uint8_t t = serialTailRX[port];
//  uint8_t c = serialBufferRX[t][port];
//  if (serialHeadRX[port] != t) 
//  {
//    if (++t >= RX_BUFFER_SIZE) 
//      t = 0;
//    serialTailRX[port] = t;
//  }
//  return c;
}



uint8_t SerialAvailable(uint8_t port) 
{
  return T_USB_Available(port); 
//  return ((uint8_t)(serialHeadRX[port] - serialTailRX[port]))%RX_BUFFER_SIZE;
}

uint8_t SerialUsedTXBuff(uint8_t port) 
{
  return ((uint8_t)(serialHeadTX[port] - serialTailTX[port]))%TX_BUFFER_SIZE;
}

void SerialSerialize(uint8_t port,uint8_t a)
{
  uint8_t t = serialHeadTX[port];
  if (++t >= TX_BUFFER_SIZE)
    t = 0;
  serialBufferTX[t][port] = a;
  serialHeadTX[port] = t;
}

void SerialWrite(uint8_t port,uint8_t c)
{
  SerialSerialize(port,c);
  UartSendData(port); 
}
