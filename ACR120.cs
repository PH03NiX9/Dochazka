using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Dochazka
{
    class ACR120
    {
       	//=============================== Error Code ===============================

		public const int ERR_ACR120_INTERNAL_UNEXPECTED = -1000;
		public const int ERR_ACR120_PORT_INVALID = -2000;
		public const int ERR_ACR120_PORT_OCCUPIED = -2010;
		public const int ERR_ACR120_HANDLE_INVALID = -2020;
		public const int ERR_ACR120_INCORRECT_PARAM = -2030;
		public const int ERR_ACR120_READER_NO_TAG = -3000;
		public const int ERR_ACR120_READER_READ_FAIL_AFTER_OP = -3010;
		public const int ERR_ACR120_READER_NO_VALUE_BLOCK = -3020;
		public const int ERR_ACR120_READER_OP_FAILURE = -3030;
		public const int ERR_ACR120_READER_UNKNOWN = -3040;
		public const int ERR_ACR120_READER_LOGIN_INVALID_STORED_KEY_FORMAT = -4010;
		public const int ERR_ACR120_READER_WRITE_READ_AFTER_WRITE_ERROR = -4020;
		public const int ERR_ACR120_READER_DEC_FAILURE_EMPTY = -4030;

		//======================= Reader Port for AC_Open ==========================

		public const int ACR120_COM1 = 1;
		public const int ACR120_COM2 = 2;
		public const int ACR120_COM3 = 3;
		public const int ACR120_COM4 = 4;
		public const int ACR120_COM5 = 5;
		public const int ACR120_COM6 = 6;
		public const int ACR120_COM7 = 7;
		public const int ACR120_COM8 = 8;

		//========================= Baud Rate Supported ============================

		public const int ACR120_COM_BAUDRATE_9600 = 0;
		public const int ACR120_COM_BAUDRATE_19200 = 1;
		public const int ACR120_COM_BAUDRATE_38400 = 2;
		public const int ACR120_COM_BAUDRATE_57600 = 3;
		public const int ACR120_COM_BAUDRATE_115200 = 4;

		//======================== Key Type for AC_Login ===========================
    
		public const int ACR120_LOGIN_KEYTYPE_AA = 0;
		public const int ACR120_LOGIN_KEYTYPE_BB = (ACR120_LOGIN_KEYTYPE_AA + 1);
		public const int ACR120_LOGIN_KEYTYPE_FF = (ACR120_LOGIN_KEYTYPE_BB + 1);
		public const int ACR120_LOGIN_KEYTYPE_STORED_A = (ACR120_LOGIN_KEYTYPE_FF + 1);
		public const int ACR120_LOGIN_KEYTYPE_STORED_B = (ACR120_LOGIN_KEYTYPE_STORED_A + 1);

		//------------------------------------------------------------------------------------------
		//Prototype section
		//------------------------------------------------------------------------------------------

		[DllImport("ACR120.dll")]
		public static extern int ACR120_Open(int ReaderPort, int BaudRate);

		[DllImport("ACR120.dll")]
		public static extern int ACR120_Close(int hReader);
                                                 
		[DllImport("ACR120.dll")]
		public static extern int ACR120_Reset(int hReader, byte stationID);
                                                   
		[DllImport("ACR120.dll")]
		public static extern int ACR120_Select(int hReader, byte stationID, ref bool pHaveTag,
											   ref byte pTag, ref byte pSN);
                                              
		[DllImport("ACR120.dll")]
		public static extern int ACR120_Login(int hReader, byte stationID, byte sector, int keyType,
											  int storedNo, ref byte pKey);

		[DllImport("ACR120.dll")]
		public static extern int ACR120_Read(int hReader, byte stationID, byte block, ref byte pBlockData);

		[DllImport("ACR120.dll")]
		public static extern int ACR120_ReadValue(int hReader, byte stationID, byte block, ref int pValueData);

		[DllImport("ACR120.dll")]
		public static extern int ACR120_ReadEEPROM(int hReader, byte stationID, byte reg, ref byte pEEPROMData);

		[DllImport("ACR120.dll")]
		public static extern int ACR120_ReadLowLevelRegister(int hReader, byte stationID, byte reg, ref byte pRegData);

		[DllImport("ACR120.dll")]
		public static extern int ACR120_RequestVersionInfo(int hReader, byte stationID, ref byte pVersionInfoLen,
														   ref byte pVersionInfo);

		[DllImport("ACR120.dll")]
		public static extern int ACR120_RequestDLLVersion(ref byte pVersionInfoLen, ref byte pVersionInfo);

		[DllImport("ACR120.dll")]
		public static extern int ACR120_Write(int hReader, byte stationID, byte block, ref byte pBlockData);

		[DllImport("ACR120.dll")]
		public static extern int ACR120_WriteValue(int hReader, byte stationID, byte block, int pValueData);

		[DllImport("ACR120.dll")]
		public static extern int ACR120_WriteEEPROM(int hReader, byte stationID, byte reg, byte eePROMData);

		[DllImport("ACR120.dll")]
		public static extern int ACR120_WriteMasterKey(int hReader, byte stationID, byte keyNo, ref byte pKey);

		[DllImport("ACR120.dll")]
		public static extern int ACR120_WriteLowLevelRegister(int hReader, byte stationID, byte reg, byte registerData);

		[DllImport("ACR120.dll")]
		public static extern int ACR120_Inc(int hReader, byte stationID, byte block,
											int lvalue, ref int pNewValue);

		[DllImport("ACR120.dll")]
		public static extern int ACR120_Dec(int hReader, byte stationID, byte block,
											int lvalue, ref int pNewValue);

		[DllImport("ACR120.dll")]
		public static extern int ACR120_Copy(int hReader, byte stationID, byte srcBlock,
											 byte desBlock, ref int pNewValue);

		[DllImport("ACR120.dll")]
		public static extern int ACR120_Power(int hReader, byte stationID, bool bOn);
                                              
		[DllImport("ACR120.dll")]
		public static extern int ACR120_ReadUserPort(int hReader, byte stationID, ref byte pUserPortState);

		[DllImport("ACR120.dll")]
		public static extern int ACR120_WriteUserPort(int hReader, byte stationID, byte userPortState);

		[DllImport("ACR120.dll")]
		public static extern int ACR120_GetID(int hReader, ref byte pNumID, ref byte pStationID);

		[DllImport("ACR120.dll")]
		public static extern int ACR120_MultiTagSelect(int hReader, byte stationID, ref byte pSN,
													   ref bool pHaveTag, ref byte pTag, ref byte pResultSN);

		[DllImport("ACR120.dll")]
		public static extern int ACR120_ListTag(int hReader, byte stationID, ref byte pNumTagFound,
												ref bool pHaveTag, ref byte pTag, ref byte pSN);

		[DllImport("ACR120.dll")]
		public static extern int ACR120_TxDataTelegram(int hReader, byte stationID, byte length,
													   bool bParity, bool bOddParity, bool bCRCGen,
													   bool bCRCCheck, bool bCryptoInactive, byte bitFrame,
													   ref byte data, ref byte pRecvLen, ref byte recvData);

		public static string GetErrMsg(int code)
		{
			switch(code)
			{
                case -1000:
					return("Unexpected Internal Library Error : -1000");

                case -2000: 
					return("Invalid Port : -2000");

                case -2010: 
					return("Port Occupied by Another Application : -2010");

                case -2020: 
					return("Invalid Handle : -2020");
                
                case -2030: 
					return("Incorrect Parameter : -2030");
                
                case -3000: 
					return("No TAG Selected or in Reachable Range : -3000");
                                
                case -3010: 
					return("Read Failed after Operation : -3010");

                case -3020: 
					return("Block doesn't contain value : -3020");

                case -3030: 
					return("Operation Failed : -3030");
                
                case -3040: 
					return("Unknown Reader Error : -3040");
                
                case -4010: 
					return("Invalid stored key format in login process : -4010");

                case -4020: 
					return("Reader can't read after write operation : -4020");
                
                case -4030: 
					return("Decrement Failure (Empty) : -4030");

			}
			return ("Error is not documented.");
		}

		public ACR120()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	
    }
}
