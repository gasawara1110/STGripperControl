using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StbController
{
	static class Constants
	{
		// Copyright
		public const string strCopyright = "Copyright(C) 2018 MinebeaMitsumi Inc. Ltd. All rights reserved.";

		// 画面番号
		public enum ScrnNo
		{
			SCRN_STARTUP = 0,
			SCRN_POSITION_MODE,
			SCRN_SPEED_MODE,
			SCRN_TORQUE_MODE,
			SCRN_CYLINDER,
		}

		// エラーメッセージ
		public enum ErrMes {
			CANT_CONNECT = 0,
			DISCONNECT,
			NO_CONNECT
		}

		// 通信レスポンスコード
		public const Int32 E_OK = 0;
		public const Int32 E_ILLEGAL_PORT = 1;
		public const Int32 E_ALREADY_OPENED = 2;
		public const Int32 E_TIMEOUT = 3;
		public const Int32 E_NAK = 4;
		public const Int32 E_NOCONNECTION = 9;
		public const Int32 E_ERROR = 99;

		// Modbus Protocol
		public const Int32 PROT_MODBUS_ASCII = 0;
		public const Int32 PROT_MODBUS_RTU = 1;
		public const Byte MODBUS_ASCII_STX = (Byte)':';
		public const Byte MODBUS_FUNC_READ_WORD = 0x03;
		public const Byte MODBUS_FUNC_WRITE_WORD = 0x06;
		public const Byte MODBUS_FUNC_WRITE_WORDS = 0x10;
		public const Byte ASCII_CR = 0x0d;
		public const Byte ASCII_LF = 0x0a;

		// 受信ステータス
		public enum MODBUS_STATUS_ASCII
		{
			COMMST_STX = 0,
			COMMST_NADR,
			COMMST_FUNC,
			COMMST_LENGTH,
			COMMST_DATA,
			COMMST_LRC,
			COMMST_CR,
			COMMST_LF
		}

		// MODBUSデータアドレス（バンガード基板）
		public const UInt16 ADR_DigiVref		 = 0x204;
		public const UInt16 ADR_ModeSwitch		 = 0x503;
		public const UInt16 ADR_LowSpeed		 = 0x800;
		public const UInt16 ADR_HighSpeed		 = 0x802;
		public const UInt16 ADR_Status			= 0x1000;
		public const UInt16 ADR_CUR_POSITION	= 0x1008;
		public const UInt16 ADR_ENC_POSITION	= 0x100A;
		public const UInt16 ADR_REL_POS_DATA	= 0x2000;
		public const UInt16 ADR_ABS_POS_DATA	= 0x2002;
		public const UInt16 ADR_SERVO_CTRL		= 0x2011;
		public const UInt16 ADR_POS_MODE_SPEED	= 0x2014;
		public const UInt16 ADR_SPD_MODE_SPEED	= 0x2015;
		public const UInt16 ADR_PRG_NUMBER		= 0x2017;
		public const UInt16 ADR_ACT_MOTOR		= 0x201E;
		public const UInt16 ADR_PRG_DATA		= 0x9000;
		public const UInt16 ADR_PARAM_SAVE		= 0x9999;

        //ヴァンガード基板小笠原追加
        public const UInt16 ADR_IN_P0SITION_ZONE = 0x10A;         //インポジションゾーンカウント値
        public const UInt16 ADR_IN_POSITION_STATUS = 0x3028;      //インポジションステータス
        public const UInt16 ADR_TRQ_LIMIT_STATUS = 0x302B;  //トルクリミットステータス 0:未到達　1:到達



        // MODBUSデータアドレス（NMB基板）
        public const UInt16 ADR_SPCRMT_MOVE		= 0x3000;
		public const UInt16 ADR_SPCRMT_SPEED	= 0x3010;
		public const UInt16 ADR_SPCRMT_TORQUE	= 0x3012;
		public const UInt16 ADR_SPCRMT_STATUS	= 0x3020;
		public const UInt16 ADR_SPCRMT_CONFIG	= 0x3030;

        //NMB基板小笠原追加
        public const UInt16 ADR_SPCRMT_ENCOER_POS = 0x3026;

		// サーボON/OFF(2011h)
		public const UInt16 VAL_SERVO_ON	= 0;
		public const UInt16 VAL_SERVO_OFF	= 1;

		// 起動動作コマンドデータ(201Eh)
		public const UInt16 VAL_ACT_MOVE_RELATIVE	= 0;    // 相対移動
		public const UInt16 VAL_ACT_MOVE_ABSOLUTE	= 1;    // 絶対移動
		public const UInt16 VAL_ACT_MOVE_CONTINUOUS	= 2;    // 速度、トルク制御
		public const UInt16 VAL_ACT_ORIGIN			= 4;    // 原点復帰
		public const UInt16 VAL_ACT_STOP_NORMAL		= 9;    // 減速停止
		public const UInt16 VAL_ACT_STOP_EMERGENT	= 10;    // 非常停止
		public const UInt16 VAL_ACT_EXEC_PROGRAM	= 14;    // プログラム実行

		// 起動動作コマンドデータ(3000h)
		public const UInt16 SPCRMT_MOVE_CMD_STOP			= 0;
		public const UInt16 SPCRMT_MOVE_CMD_JOG				= 1;
		public const UInt16 SPCRMT_MOVE_CMD_SPD				= 2;
		public const UInt16 SPCRMT_MOVE_CMD_TRQ				= 3;
		public const UInt16 SPCRMT_MOVE_CMD_PRESS			= 4;
		public const UInt16 SPCRMT_MOVE_CMD_SGNL_SRCH		= 5;
		public const UInt16 SPCRMT_MOVE_CMD_RELATIVE_POS	= 6;
		public const UInt16 SPCRMT_MOVE_CMD_ABSOLUTE_POS	= 7;
		public const UInt16 SPCRMT_MOVE_CMD_ORG_SRCH		= 8;
		public const UInt16 SPCRMT_MOVE_CMD_PROG			= 9;

		// ST-Box動作状態(1000h)
		public const UInt16 DRV_STATUS_STOP		= 0;    // 停止
		public const UInt16 DRV_STATUS_DRIVE	= 1;    // 動作中
		public const UInt16 DRV_STATUS_ERROR	= 2;    // 異常停止

		// パラメータセーブ・コマンド(9999h)
		public const UInt16 PRMSV_SAVE			= 0;    // 現在のパラメータ
		public const UInt16 PRMSV_DEFAULT		= 1;    // デフォルトデータ
		public const UInt16 PRMSV_SW_RESET		= 2;    // コマンドによるリスタート
		public const UInt16 PRMSV_HW_RESET		= 3;    // リセット信号

		// プログラムデータ
		public const UInt16 MAX_PROG_NUM = 64;
	}
}
