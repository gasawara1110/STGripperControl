using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace StbController
{
	class CStboxIf
	{
		static Byte nodeAddress;
		static string comPort;
		static Int32 comSpeed;
		static Parity parity = Parity.None;
		static Int32 dataBits = 8;
		static StopBits stopBits = StopBits.One;

		static ModbusIf2.CModbusIf myModbusIf = null;

		/// <summary>
		/// 通信仕様設定
		/// </summary>
		public static void Conncect(Byte address, string port, string baud, Int32 protocol)
		{
			nodeAddress = address;
			comPort = port;
			comSpeed = Int32.Parse(baud);

			if ( Constants.PROT_MODBUS_ASCII == protocol )
			{
				myModbusIf = new ModbusIf2.CModbusIfAscii();
			}
			else
			{
				myModbusIf = new ModbusIf2.CModbusIfRtu();
			}

			return;
		}

		public static void Disconncect()
		{
			myModbusIf = null;

			return;
        }

		public static bool isConnect()
		{
			return !( null == myModbusIf );
        }

		private static Int32 getOneWordParam(UInt16 address, ref UInt16 value)
		{
			Int32 retVal;
			bool lockTaken = false;

			if (null == myModbusIf)
			{
				return Constants.E_NOCONNECTION;
			}

			try
			{
				Monitor.Enter(myModbusIf, ref lockTaken); // ロック取得

				retVal = myModbusIf.Open(comPort, comSpeed, parity, dataBits, stopBits);
				if (retVal == Constants.E_OK)
				{
					UInt16[] val = new UInt16[2];

					retVal = myModbusIf.ReadHoldingRegister(nodeAddress, address, 1, val);
					value = val[0];

					myModbusIf.Close();
				}
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(myModbusIf); // ロック解放
				}
			}

			return retVal;
		}

		public static Int32 setOneWordParam(UInt16 address, UInt16 value)
		{
			Int32 retVal;
			bool lockTaken = false;

			if (null == myModbusIf)
			{
				return Constants.E_NOCONNECTION;
			}

			try
			{
				Monitor.Enter(myModbusIf, ref lockTaken); // ロック取得

				retVal = myModbusIf.Open(comPort, comSpeed, parity, dataBits, stopBits);
				if (retVal == Constants.E_OK)
				{
					retVal = myModbusIf.PresetSingleRegister(nodeAddress, address, value);

					myModbusIf.Close();
				}
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(myModbusIf); // ロック解放
				}
			}

			return retVal;
		}

		private static Int32 getMultiWordParam(UInt16 address, UInt16 length, UInt16[] value)
		{
			Int32 retVal;
			bool lockTaken = false;

			if (null == myModbusIf)
			{
				return Constants.E_NOCONNECTION;
			}

			try
			{
				Monitor.Enter(myModbusIf, ref lockTaken); // ロック取得

				retVal = myModbusIf.Open(comPort, comSpeed, parity, dataBits, stopBits);
				if (retVal == Constants.E_OK)
				{
					retVal = myModbusIf.ReadHoldingRegister(nodeAddress, address, length, value);

					myModbusIf.Close();
				}
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(myModbusIf); // ロック解放
				}
			}

			return retVal;
		}

		public static Int32 setMultiWordParam(UInt16 address, UInt16 length, UInt16[] value)
		{
			Int32 retVal;
			bool lockTaken = false;

			if (null == myModbusIf)
			{
				return Constants.E_NOCONNECTION;
			}

			try
			{
				Monitor.Enter(myModbusIf, ref lockTaken); // ロック取得

				retVal = myModbusIf.Open(comPort, comSpeed, parity, dataBits, stopBits);
				if (retVal == Constants.E_OK)
				{
					retVal = myModbusIf.PresetMultipleRegisters(nodeAddress, address, length, value);

					myModbusIf.Close();
				}
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(myModbusIf); // ロック解放
				}
			}

			return retVal;
		}

		public static Int32 getMaxSpeedPos(ref UInt32 speed)
		{
			UInt16[] val = new UInt16[2];

			Int32 retVal = getMultiWordParam(Constants.ADR_HighSpeed, 2, val);
			if (retVal == Constants.E_OK)
			{
				speed = (UInt32)((val[0] << 16) + val[1]);
			}

			return retVal;
		}

		public static Int32 setMaxSpeedPos(UInt32 speed)
		{
			UInt16[] val = new UInt16[2];

			val[0] = (UInt16)((speed >> 16) & 0x0000ffff);
			val[1] = (UInt16)(speed & 0x0000ffff);
			return setMultiWordParam(Constants.ADR_HighSpeed, 2, val);
		}

		public static Int32 getCurrentSpeedPos(ref UInt16 speed)
		{
			return getOneWordParam(Constants.ADR_POS_MODE_SPEED, ref speed);

 		}

		public static Int32 setCurrentSpeedPos(UInt16 speed)
		{
			return setOneWordParam(Constants.ADR_POS_MODE_SPEED, speed);
		}

		public static Int32 getMaxSpeedSpd(ref UInt16 speed)
		{
			return getOneWordParam(Constants.ADR_DigiVref, ref speed);

		}

		public static Int32 setMaxSpeedSpd(UInt16 speed)
		{
			return setOneWordParam(Constants.ADR_DigiVref, speed);
		}

		public static Int32 getCurrentSpeedSpd(ref UInt16 speed)
		{
			return getOneWordParam(Constants.ADR_SPD_MODE_SPEED, ref speed);

		}

		public static Int32 setCurrentSpeedSpd(UInt16 speed)
		{
			return setOneWordParam(Constants.ADR_SPD_MODE_SPEED, speed);
		}

		/// <summary>
		/// 状態取得
		/// </summary>
		public static Int32 getDrvStatus(UInt16[] dvrStatus)
		{
			return getMultiWordParam(Constants.ADR_SPCRMT_STATUS, 8, dvrStatus);
		}

		public static Int32 getParamData(UInt16 address, UInt16 len, ref Int32 ParamData)
		{
			UInt16[] val = new UInt16[len];

			Int32 retVal = getMultiWordParam(address, len, val);
			if (retVal == Constants.E_OK)
			{
				if (1 == len)
				{
					ParamData = val[0];
				}
				else if (2 == len)
				{
					ParamData = (Int32)((val[0] << 16) + val[1]);
				}
			}

			return retVal;
		}

		public static Int32 setParamData(UInt16 address, UInt16 len, Int32 ParamData)
		{
			if (1 == len)
			{
				return setOneWordParam(address, (UInt16)ParamData);
			}
			else if (2 == len)
			{
				UInt16[] val = new UInt16[2];
				val[0] = (UInt16)(((UInt32)ParamData >> 16) & 0x0000ffff);
				val[1] = (UInt16)(ParamData & 0x0000ffff);
				return setMultiWordParam(address, 2, val);
			}
			else
			{
				//
			}

			return Constants.E_ERROR;
		}

		public static Int32 getProgData(int index, ref CProgram.programItem prgData)
		{
			UInt16[] val = new UInt16[12];

			Int32 retVal = getMultiWordParam((UInt16)(Constants.ADR_PRG_DATA + index * 16), 12, val);
			if (retVal == Constants.E_OK)
			{
				prgData.Mode = val[0];
				prgData.Position = (Int32)((val[1] << 16) + val[2]);
				prgData.Speed = val[3];
				prgData.TorqueLimit = val[4];
				prgData.WaitTime = val[10];
				prgData.NextStep = (Int16)val[11];
			}

			return retVal;
		}

		public static Int32 setProgData(int index, string strProgRecord)
		{
			UInt16[] val = new UInt16[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

			string[] separator = new string[] { "," };
			string[] items = strProgRecord.Split(separator, StringSplitOptions.RemoveEmptyEntries);

			val[0] = UInt16.Parse(items[0]);                        // Mode
			Int32 i32 = Int32.Parse(items[1]);                      // Position
			val[1] = (UInt16)(((UInt32)i32 >> 16) & 0x0000ffff);
			val[2] = (UInt16)((UInt32)i32 & 0x0000ffff);
			val[3] = UInt16.Parse(items[2]);                        // Speed
			val[4] = UInt16.Parse(items[3]);                        // TorqueLimit
			val[10] = UInt16.Parse(items[7]);                       // WaitTime
			val[11] = (UInt16)(Int16.Parse(items[8]));              // NextStep

			return setMultiWordParam((UInt16)(Constants.ADR_PRG_DATA + index * 16), 12, val);
		}

		public static Int32 setParamSave(UInt16 command)
		{
			return setOneWordParam(Constants.ADR_PARAM_SAVE, command);
		}

		public static Int32 getVersion(ref string strVersion)
		{
			Int32 retVal;
			bool lockTaken = false;

			if (null == myModbusIf)
			{
				return Constants.E_NOCONNECTION;
			}

			try
			{
				Monitor.Enter(myModbusIf, ref lockTaken); // ロック取得

				retVal = myModbusIf.Open(comPort, comSpeed, parity, dataBits, stopBits);
				if (retVal == Constants.E_OK)
				{
					Byte[] val = new Byte[256];
					int len = 256;

					retVal = myModbusIf.SendString("get version\r\n");
					if ( Constants.E_OK == retVal )
					{
						retVal = myModbusIf.ReceiveBytes(val, ref len);
						strVersion = System.Text.Encoding.ASCII.GetString(val);
					}

					myModbusIf.Close();
				}
			}
			finally
			{
				if (lockTaken)
				{
					Monitor.Exit(myModbusIf); // ロック解放
				}
			}

			return retVal;
		}

		public static Int32 ActPositionModeAbs(Int32 position, UInt16 speed)
		{
			UInt16[] val = new UInt16[8];

			val[0] = Constants.SPCRMT_MOVE_CMD_ABSOLUTE_POS;
			val[1] = 0xffff;
			val[2] = speed;
			val[3] = 0xffff;
			val[4] = 0;
			val[5] = 0xffff;
			val[6] = (UInt16)((UInt32)position >> 16);
			val[7] = (UInt16)((UInt32)position & 0x0000ffff);

			return setMultiWordParam(Constants.ADR_SPCRMT_MOVE, 8, val);
		}

		public static Int32 ActPositionModeRel(Int32 position, UInt16 speed)
		{
			UInt16[] val = new UInt16[8];

			val[0] = Constants.SPCRMT_MOVE_CMD_RELATIVE_POS;
			if ( position < 0 )
			{
				val[1] = 0;
				position *= (-1);
			}
			else
			{
				val[1] = 1;
			}
			val[2] = speed;
			val[3] = 0xffff;
			val[4] = 0;
			val[5] = 0xffff;
			val[6] = (UInt16)((UInt32)position >> 16);
			val[7] = (UInt16)((UInt32)position & 0x0000ffff);

			return setMultiWordParam(Constants.ADR_SPCRMT_MOVE, 8, val);
		}

		public static Int32 ActSpeedMode(UInt16 direction, UInt16 speed)
		{
			UInt16[] val = new UInt16[8];

			val[0] = Constants.SPCRMT_MOVE_CMD_SPD;
			val[1] = direction;
			val[2] = speed;
			val[3] = 0xffff;
			val[4] = 0;
			val[5] = 0xffff;
			val[6] = 0xffff;
			val[7] = 0xffff;

			return setMultiWordParam(Constants.ADR_SPCRMT_MOVE, 8, val);
		}

		public static Int32 ActStop()
		{
			UInt16[] val = new UInt16[8];

			val[0] = Constants.SPCRMT_MOVE_CMD_STOP;
			val[1] = 0xffff;
			val[2] = 0xffff;
			val[3] = 0xffff;
			val[4] = 0xffff;
			val[5] = 0xffff;
			val[6] = 0xffff;
			val[7] = 0xffff;

			return setMultiWordParam(Constants.ADR_SPCRMT_MOVE, 8, val);
		}

		public static Int32 setCurrentSpeed(UInt16 speed)
		{
			return setOneWordParam(Constants.ADR_SPCRMT_SPEED, speed);
		}


        /** 位置制御モード時のin position zone 設定(2018/8/31小笠原追加)
         * @param[in] zonePulse in positionの範囲(0～1000)
         * @return エラー情報
         */
        public static Int32 setInPositionZone(UInt16 zonePulse)
        {
            return setOneWordParam(Constants.ADR_IN_P0SITION_ZONE, (UInt16)zonePulse);
        }

        /** in position情報の取得(2018/8/31小笠原追加)
         * @param[in] status 0:目標値付近未到達 1:目標値付近到達
         * @return エラー情報
         */
        public static Int32 getInPositionStatus(ref UInt16 status)
        {
            return getOneWordParam(Constants.ADR_IN_POSITION_STATUS, ref status);
        }

        /** 押し当て制御モード移行(2018/8/31小笠原追加)
         * @param[in] 方向(0:CCW、1:CW)
         * @param[in] 
         * @param[in]
         * @return エラー情報
         */
        public static Int32 ActPressMode(UInt16 direction,UInt16 speed,UInt16 torque)
        {
            UInt16[] val = new UInt16[8];

            val[0] = Constants.SPCRMT_MOVE_CMD_PRESS;   //運転指定
            val[1] = direction;     //方向指定
            val[2] = speed; //速度指定
            val[3] = torque;    //トルク指定
            val[4] = 0;         //N/A
            val[5] = 0xffff;    //運転番号、N/A
            val[6] = 0xffff;
            val[7] = 0xffff;
            return setMultiWordParam(Constants.ADR_SPCRMT_MOVE, 8, val);
        }

        public static Int32 ActTorqueMode(UInt16 direction,UInt16 speed,UInt16 torque)
        {
            UInt16[] val = new UInt16[8];

            val[0] = Constants.SPCRMT_MOVE_CMD_TRQ;   //運転指定
            val[1] = direction;     //方向指定
            val[2] = speed; //速度指定
            val[3] = torque;    //トルク指定
            val[4] = 0;         //N/A
            val[5] = 0xffff;    //運転番号、N/A
            val[6] = 0xffff;
            val[7] = 0xffff;
            return setMultiWordParam(Constants.ADR_SPCRMT_MOVE, 8, val);

        }
        /** トルクリミット情報情報の取得(2018/8/31小笠原追加)
         * @param[in] status 0:目標値付近未到達 1:目標値付近到達
         * @return エラー情報
         */
        public static Int32 getTorqueLimitStatus(ref UInt16 status)
        {
            return getOneWordParam(Constants.ADR_TRQ_LIMIT_STATUS, ref status);
        }

        public static Int32 getCurrentPosition(ref Int32 position)
        {
            UInt16[] val = new UInt16[2];
            return getParamData(Constants.ADR_SPCRMT_ENCOER_POS, 2,ref position);
            //getMultiWordParam(Constants.ADR_SPCRMT_ENCOER_POS,2,val)
        }
	}
}
