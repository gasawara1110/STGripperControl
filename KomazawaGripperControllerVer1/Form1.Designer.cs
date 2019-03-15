namespace KomazawaGripperControllerVer1
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LbConnectState = new System.Windows.Forms.Label();
            this.BtConnectCom = new System.Windows.Forms.Button();
            this.BtReloadCom = new System.Windows.Forms.Button();
            this.CmbSelectCom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TbSpeed = new System.Windows.Forms.TrackBar();
            this.txtbSpeedRatio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TbTorque = new System.Windows.Forms.TrackBar();
            this.BtOpen = new System.Windows.Forms.Button();
            this.BtClose = new System.Windows.Forms.Button();
            this.CbTorqueLimit = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbCurrentPos = new System.Windows.Forms.TextBox();
            this.txtbTorqueRatio = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TbTorque)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LbConnectState);
            this.groupBox1.Controls.Add(this.BtConnectCom);
            this.groupBox1.Controls.Add(this.BtReloadCom);
            this.groupBox1.Controls.Add(this.CmbSelectCom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "シリアルポート設定";
            // 
            // LbConnectState
            // 
            this.LbConnectState.AutoSize = true;
            this.LbConnectState.BackColor = System.Drawing.Color.Black;
            this.LbConnectState.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LbConnectState.ForeColor = System.Drawing.Color.Red;
            this.LbConnectState.Location = new System.Drawing.Point(173, 26);
            this.LbConnectState.Name = "LbConnectState";
            this.LbConnectState.Size = new System.Drawing.Size(111, 33);
            this.LbConnectState.TabIndex = 4;
            this.LbConnectState.Text = "未接続";
            // 
            // BtConnectCom
            // 
            this.BtConnectCom.Location = new System.Drawing.Point(88, 45);
            this.BtConnectCom.Name = "BtConnectCom";
            this.BtConnectCom.Size = new System.Drawing.Size(75, 23);
            this.BtConnectCom.TabIndex = 3;
            this.BtConnectCom.Text = "接続";
            this.BtConnectCom.UseVisualStyleBackColor = true;
            this.BtConnectCom.Click += new System.EventHandler(this.BtConnectCom_Click);
            // 
            // BtReloadCom
            // 
            this.BtReloadCom.Location = new System.Drawing.Point(7, 45);
            this.BtReloadCom.Name = "BtReloadCom";
            this.BtReloadCom.Size = new System.Drawing.Size(75, 23);
            this.BtReloadCom.TabIndex = 2;
            this.BtReloadCom.Text = "更新";
            this.BtReloadCom.UseVisualStyleBackColor = true;
            this.BtReloadCom.Click += new System.EventHandler(this.BtReloadCom_Click);
            // 
            // CmbSelectCom
            // 
            this.CmbSelectCom.FormattingEnabled = true;
            this.CmbSelectCom.Location = new System.Drawing.Point(88, 19);
            this.CmbSelectCom.Name = "CmbSelectCom";
            this.CmbSelectCom.Size = new System.Drawing.Size(75, 20);
            this.CmbSelectCom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ポート番号";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.TbSpeed);
            this.groupBox2.Controls.Add(this.txtbSpeedRatio);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.TbTorque);
            this.groupBox2.Controls.Add(this.BtOpen);
            this.groupBox2.Controls.Add(this.BtClose);
            this.groupBox2.Controls.Add(this.CbTorqueLimit);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtbCurrentPos);
            this.groupBox2.Controls.Add(this.txtbTorqueRatio);
            this.groupBox2.Location = new System.Drawing.Point(13, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(445, 163);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "グリッパー操作";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(396, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "[pulse]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "スピード";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(239, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "[%]";
            // 
            // TbSpeed
            // 
            this.TbSpeed.Location = new System.Drawing.Point(53, 111);
            this.TbSpeed.Name = "TbSpeed";
            this.TbSpeed.Size = new System.Drawing.Size(129, 45);
            this.TbSpeed.TabIndex = 15;
            this.TbSpeed.Scroll += new System.EventHandler(this.TbSpeed_Scroll);
            // 
            // txtbSpeedRatio
            // 
            this.txtbSpeedRatio.Location = new System.Drawing.Point(188, 112);
            this.txtbSpeedRatio.Name = "txtbSpeedRatio";
            this.txtbSpeedRatio.Size = new System.Drawing.Size(45, 19);
            this.txtbSpeedRatio.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "トルク";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "[%]";
            // 
            // TbTorque
            // 
            this.TbTorque.Location = new System.Drawing.Point(53, 71);
            this.TbTorque.Name = "TbTorque";
            this.TbTorque.Size = new System.Drawing.Size(129, 45);
            this.TbTorque.TabIndex = 11;
            this.TbTorque.Scroll += new System.EventHandler(this.TbTorque_Scroll);
            // 
            // BtOpen
            // 
            this.BtOpen.Location = new System.Drawing.Point(99, 28);
            this.BtOpen.Name = "BtOpen";
            this.BtOpen.Size = new System.Drawing.Size(75, 23);
            this.BtOpen.TabIndex = 10;
            this.BtOpen.Text = "open";
            this.BtOpen.UseVisualStyleBackColor = true;
            this.BtOpen.Click += new System.EventHandler(this.BtOpen_Click);
            // 
            // BtClose
            // 
            this.BtClose.Location = new System.Drawing.Point(18, 28);
            this.BtClose.Name = "BtClose";
            this.BtClose.Size = new System.Drawing.Size(75, 23);
            this.BtClose.TabIndex = 9;
            this.BtClose.Text = "close";
            this.BtClose.UseVisualStyleBackColor = true;
            this.BtClose.Click += new System.EventHandler(this.BtClose_Click);
            // 
            // CbTorqueLimit
            // 
            this.CbTorqueLimit.AutoSize = true;
            this.CbTorqueLimit.Location = new System.Drawing.Point(332, 77);
            this.CbTorqueLimit.Name = "CbTorqueLimit";
            this.CbTorqueLimit.Size = new System.Drawing.Size(103, 16);
            this.CbTorqueLimit.TabIndex = 7;
            this.CbTorqueLimit.Text = "トルクリミット到達";
            this.CbTorqueLimit.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "現在位置";
            // 
            // txtbCurrentPos
            // 
            this.txtbCurrentPos.Location = new System.Drawing.Point(332, 111);
            this.txtbCurrentPos.Name = "txtbCurrentPos";
            this.txtbCurrentPos.Size = new System.Drawing.Size(58, 19);
            this.txtbCurrentPos.TabIndex = 3;
            // 
            // txtbTorqueRatio
            // 
            this.txtbTorqueRatio.Location = new System.Drawing.Point(188, 75);
            this.txtbTorqueRatio.Name = "txtbTorqueRatio";
            this.txtbTorqueRatio.Size = new System.Drawing.Size(45, 19);
            this.txtbTorqueRatio.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 277);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TbTorque)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LbConnectState;
        private System.Windows.Forms.Button BtConnectCom;
        private System.Windows.Forms.Button BtReloadCom;
        private System.Windows.Forms.ComboBox CmbSelectCom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbCurrentPos;
        private System.Windows.Forms.TextBox txtbTorqueRatio;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox CbTorqueLimit;
        private System.Windows.Forms.Button BtOpen;
        private System.Windows.Forms.Button BtClose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar TbSpeed;
        private System.Windows.Forms.TextBox txtbSpeedRatio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar TbTorque;
    }
}

