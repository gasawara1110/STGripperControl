using StbController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KomazawaGripperControllerVer1
{
    public partial class Form1 : Form
    {
        //int handPos;
        public void InitTrackBar(TrackBar trackBar, int min, int max, int initVal)
        {
            trackBar.Minimum = min;
            trackBar.Maximum = max;
            trackBar.Value = initVal;
        }
        public Form1()
        {
            InitializeComponent();
            //InitTrackBar(TbHandPos, 0, 9600, 0);
            //txtbDesiredPos.Text = TbHandPos.Value.ToString();
            timer1.Interval = 100;
            InitTrackBar(TbTorque, 0, 100, 50);
            InitTrackBar(TbSpeed, 0, 100, 50);
            txtbTorqueRatio.Text = TbTorque.Value.ToString();
            txtbSpeedRatio.Text = TbSpeed.Value.ToString();
        }

        private void BtReloadCom_Click(object sender, EventArgs e)
        {
            CmbSelectCom.Refresh();
            CmbSelectCom.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (string portName in ports)
            {
                CmbSelectCom.Items.Add(portName);
            }
            CmbSelectCom.SelectedIndex = 0;
        }

        private void BtConnectCom_Click(object sender, EventArgs e)
        {
            if (CStboxIf.isConnect())
            {
                LbConnectState.Text = "未接続";
                BtConnectCom.Text = "接続";
                LbConnectState.ForeColor = Color.Red;
                CStboxIf.Disconncect();
                timer1.Stop();
                
            }
            else
            {
                LbConnectState.Text = "接続済";
                BtConnectCom.Text = "切断";
                LbConnectState.ForeColor = Color.Green;
                CStboxIf.Conncect(1, CmbSelectCom.SelectedItem.ToString(), 57600.ToString(), Constants.PROT_MODBUS_ASCII);
                int result1 = CStboxIf.setInPositionZone(100);
                //int result = CStboxIf.
                //int result2 = CStboxIf.setPushDownMode();
                timer1.Start();
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            int position = 0;
            UInt16 torqueStatus = 0;
            if(CStboxIf.isConnect())
            {
                //CStboxIf.ActPositionModeAbs((Int32)TbHandPos.Value, (UInt16)50);
                //CStboxIf.ActPressMode(0, 50, 50);
                //CStboxIf.getTorqueLimitStatus(ref status);
                CStboxIf.getTorqueLimitStatus(ref torqueStatus);
                CStboxIf.getCurrentPosition(ref position);

                txtbCurrentPos.Text = position.ToString();

                if (torqueStatus == 1)
                {
                    CbTorqueLimit.Checked = true;
                    //CbInPosition.Checked = true;
                }
                else
                {
                    CbTorqueLimit.Checked = false;
                    //CbInPosition.Checked = false;
                }


            }
        }

        private void BtOpen_Click(object sender, EventArgs e)
        {
            if (CStboxIf.isConnect())
            {
                CStboxIf.ActTorqueMode(0, (UInt16)TbSpeed.Value, (UInt16)TbTorque.Value);
            }
        }

        private void BtClose_Click(object sender, EventArgs e)
        {
            if (CStboxIf.isConnect())
            {
                CStboxIf.ActTorqueMode(1, (UInt16)TbSpeed.Value, (UInt16)TbTorque.Value);
            }
        }

        private void TbTorque_Scroll(object sender, EventArgs e)
        {
            txtbTorqueRatio.Text = TbTorque.Value.ToString();
        }

        private void TbSpeed_Scroll(object sender, EventArgs e)
        {
            txtbSpeedRatio.Text = TbSpeed.Value.ToString();
        }
    }
}
