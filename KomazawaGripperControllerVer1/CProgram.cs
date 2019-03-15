using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StbController
{
	class CProgram
	{
		public const UInt16 PROGRAM_MAX_NO = 64;    // プログラム数

		public class programItem
		{
			public UInt16 Mode;
			public Int32 Position;
			public UInt16 Speed;
			public UInt16 TorqueLimit;
			public UInt16 WaitTime;
			public Int16 NextStep;

			public programItem()
			{
				Mode = 0;
				Position = 0;
				Speed = 100;
				TorqueLimit = 1000;
				WaitTime = 0;
				NextStep = -1;
			}

			public programItem(UInt16 mode, Int32 pos, UInt16 spd, UInt16 trq, UInt16 wait, Int16 next)
			{
				Mode = mode;
				Position = pos;
				Speed = spd;
				TorqueLimit = trq;
				WaitTime = wait;
				NextStep = next;
			}
		}

		public UInt16	Mode;
		public Int32	Position;
		public UInt16	Speed;
		public UInt16	TorqueLimit;
		public UInt16	WaitTime;
		public Int16	NextStep;

		public CProgram()
		{
			Mode = 0;
			Position = 0;
			Speed = 100;
			TorqueLimit = 1000;
			WaitTime = 0;
			NextStep = -1;
        }

		public CProgram(UInt16 mode, Int32 pos ,UInt16 spd, UInt16 trq, UInt16 wait, Int16 next)
		{
			Mode = mode;
			Position = pos;
			Speed = spd;
			TorqueLimit = trq;
			WaitTime = wait;
			NextStep = next;
		}
	}
}
