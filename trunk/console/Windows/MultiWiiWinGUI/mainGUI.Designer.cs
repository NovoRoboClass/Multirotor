namespace MultiWiiSimpleGUI
{
    partial class mainGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainGUI));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPagePID = new System.Windows.Forms.TabPage();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.nPAlarm = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label_sok = new System.Windows.Forms.Label();
            this.nTEXPO = new System.Windows.Forms.NumericUpDown();
            this.label60 = new System.Windows.Forms.Label();
            this.nTMID = new System.Windows.Forms.NumericUpDown();
            this.nRATE_tpid = new System.Windows.Forms.NumericUpDown();
            this.trackBar_T_EXPO = new System.Windows.Forms.TrackBar();
            this.nRATE_yaw = new System.Windows.Forms.NumericUpDown();
            this.trackBar_T_MID = new System.Windows.Forms.TrackBar();
            this.nRATE_rp = new System.Windows.Forms.NumericUpDown();
            this.trackbar_RC_Rate = new System.Windows.Forms.TrackBar();
            this.label66 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.nRCExpo = new System.Windows.Forms.NumericUpDown();
            this.trackbar_RC_Expo = new System.Windows.Forms.TrackBar();
            this.nRCRate = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPageRC = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPageRealtime = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cb_monitor_rate = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.b_pause = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.b_cal_acc = new System.Windows.Forms.Button();
            this.b_cal_mag = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.l_alt = new System.Windows.Forms.Label();
            this.cb_head = new System.Windows.Forms.CheckBox();
            this.l_head = new System.Windows.Forms.Label();
            this.cb_alt = new System.Windows.Forms.CheckBox();
            this.l_i2cerrors = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.l_gyro_yaw = new System.Windows.Forms.Label();
            this.l_gyro_pitch = new System.Windows.Forms.Label();
            this.l_gyro_roll = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.cb_gyro_yaw = new System.Windows.Forms.CheckBox();
            this.label30 = new System.Windows.Forms.Label();
            this.cb_gyro_pitch = new System.Windows.Forms.CheckBox();
            this.label31 = new System.Windows.Forms.Label();
            this.cb_gyro_roll = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.l_cycletime = new System.Windows.Forms.Label();
            this.l_vbatt = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.l_powersum = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.l_acc_z = new System.Windows.Forms.Label();
            this.l_acc_pitch = new System.Windows.Forms.Label();
            this.l_acc_roll = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cb_acc_z = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cb_acc_pitch = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cb_acc_roll = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.l_mag_yaw = new System.Windows.Forms.Label();
            this.l_mag_pitch = new System.Windows.Forms.Label();
            this.l_mag_roll = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.cb_mag_yaw = new System.Windows.Forms.CheckBox();
            this.label36 = new System.Windows.Forms.Label();
            this.cb_mag_pitch = new System.Windows.Forms.CheckBox();
            this.label37 = new System.Windows.Forms.Label();
            this.cb_mag_roll = new System.Windows.Forms.CheckBox();
            this.zgMonitor = new ZedGraph.ZedGraphControl();
            this.timer_realtime = new System.Windows.Forms.Timer(this.components);
            this.bkgWorker = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cb_serial_port = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cb_serial_speed = new System.Windows.Forms.ToolStripComboBox();
            this.b_connect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.b_read_settings = new System.Windows.Forms.ToolStripButton();
            this.b_write_settings = new System.Windows.Forms.ToolStripButton();
            this.b_reset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MWC_Button = new System.Windows.Forms.ToolStripButton();
            this.b_about = new System.Windows.Forms.ToolStripButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabMain.SuspendLayout();
            this.tabPagePID.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nPAlarm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTEXPO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTMID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRATE_tpid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_T_EXPO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRATE_yaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_T_MID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRATE_rp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbar_RC_Rate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRCExpo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbar_RC_Expo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRCRate)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tabPageRC.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPageRealtime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPagePID);
            this.tabMain.Controls.Add(this.tabPageRC);
            this.tabMain.Controls.Add(this.tabPageRealtime);
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 54);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(595, 477);
            this.tabMain.TabIndex = 9;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // tabPagePID
            // 
            this.tabPagePID.BackColor = System.Drawing.Color.White;
            this.tabPagePID.Controls.Add(this.groupBox12);
            this.tabPagePID.Controls.Add(this.groupBox4);
            this.tabPagePID.Location = new System.Drawing.Point(4, 22);
            this.tabPagePID.Name = "tabPagePID";
            this.tabPagePID.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePID.Size = new System.Drawing.Size(587, 451);
            this.tabPagePID.TabIndex = 1;
            this.tabPagePID.Text = "Parameters";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.label2);
            this.groupBox12.Controls.Add(this.label8);
            this.groupBox12.Controls.Add(this.label50);
            this.groupBox12.Controls.Add(this.nPAlarm);
            this.groupBox12.Controls.Add(this.label1);
            this.groupBox12.Controls.Add(this.label_sok);
            this.groupBox12.Controls.Add(this.nTEXPO);
            this.groupBox12.Controls.Add(this.label60);
            this.groupBox12.Controls.Add(this.nTMID);
            this.groupBox12.Controls.Add(this.nRATE_tpid);
            this.groupBox12.Controls.Add(this.trackBar_T_EXPO);
            this.groupBox12.Controls.Add(this.nRATE_yaw);
            this.groupBox12.Controls.Add(this.trackBar_T_MID);
            this.groupBox12.Controls.Add(this.nRATE_rp);
            this.groupBox12.Controls.Add(this.trackbar_RC_Rate);
            this.groupBox12.Controls.Add(this.label66);
            this.groupBox12.Controls.Add(this.label65);
            this.groupBox12.Controls.Add(this.nRCExpo);
            this.groupBox12.Controls.Add(this.trackbar_RC_Expo);
            this.groupBox12.Controls.Add(this.nRCRate);
            this.groupBox12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox12.ForeColor = System.Drawing.Color.Black;
            this.groupBox12.Location = new System.Drawing.Point(334, 7);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(247, 436);
            this.groupBox12.TabIndex = 8;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Rates/Expo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(11, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Thr. EXPO";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(19, 400);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Power Meter Alarm";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.Color.Black;
            this.label50.Location = new System.Drawing.Point(19, 375);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(120, 13);
            this.label50.TabIndex = 5;
            this.label50.Text = "Throttle PID attenuation";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nPAlarm
            // 
            this.nPAlarm.BackColor = System.Drawing.Color.White;
            this.nPAlarm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nPAlarm.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nPAlarm.Location = new System.Drawing.Point(164, 399);
            this.nPAlarm.Maximum = new decimal(new int[] {
            64000,
            0,
            0,
            0});
            this.nPAlarm.Name = "nPAlarm";
            this.nPAlarm.Size = new System.Drawing.Size(68, 21);
            this.nPAlarm.TabIndex = 6;
            this.nPAlarm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nPAlarm.ValueChanged += new System.EventHandler(this.nPAlarm_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(11, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Thr. MID";
            // 
            // label_sok
            // 
            this.label_sok.AutoSize = true;
            this.label_sok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_sok.ForeColor = System.Drawing.Color.Black;
            this.label_sok.Location = new System.Drawing.Point(19, 349);
            this.label_sok.Name = "label_sok";
            this.label_sok.Size = new System.Drawing.Size(60, 13);
            this.label_sok.TabIndex = 4;
            this.label_sok.Text = "Yaw RATE";
            this.label_sok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nTEXPO
            // 
            this.nTEXPO.BackColor = System.Drawing.Color.White;
            this.nTEXPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nTEXPO.DecimalPlaces = 2;
            this.nTEXPO.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nTEXPO.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nTEXPO.Location = new System.Drawing.Point(19, 239);
            this.nTEXPO.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nTEXPO.Name = "nTEXPO";
            this.nTEXPO.Size = new System.Drawing.Size(55, 21);
            this.nTEXPO.TabIndex = 29;
            this.nTEXPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nTEXPO.ValueChanged += new System.EventHandler(this.nTEXPO_ValueChanged);
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.ForeColor = System.Drawing.Color.Black;
            this.label60.Location = new System.Drawing.Point(19, 323);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(86, 13);
            this.label60.TabIndex = 3;
            this.label60.Text = "Roll/Pitch RATE";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nTMID
            // 
            this.nTMID.BackColor = System.Drawing.Color.White;
            this.nTMID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nTMID.DecimalPlaces = 2;
            this.nTMID.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nTMID.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nTMID.Location = new System.Drawing.Point(19, 193);
            this.nTMID.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nTMID.Name = "nTMID";
            this.nTMID.Size = new System.Drawing.Size(55, 21);
            this.nTMID.TabIndex = 28;
            this.nTMID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nTMID.ValueChanged += new System.EventHandler(this.nTMID_ValueChanged);
            // 
            // nRATE_tpid
            // 
            this.nRATE_tpid.BackColor = System.Drawing.Color.White;
            this.nRATE_tpid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nRATE_tpid.DecimalPlaces = 2;
            this.nRATE_tpid.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nRATE_tpid.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nRATE_tpid.Location = new System.Drawing.Point(164, 373);
            this.nRATE_tpid.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nRATE_tpid.Name = "nRATE_tpid";
            this.nRATE_tpid.Size = new System.Drawing.Size(68, 21);
            this.nRATE_tpid.TabIndex = 2;
            this.nRATE_tpid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nRATE_tpid.ValueChanged += new System.EventHandler(this.nRATE_tpid_ValueChanged);
            // 
            // trackBar_T_EXPO
            // 
            this.trackBar_T_EXPO.AutoSize = false;
            this.trackBar_T_EXPO.LargeChange = 1;
            this.trackBar_T_EXPO.Location = new System.Drawing.Point(14, 294);
            this.trackBar_T_EXPO.Maximum = 100;
            this.trackBar_T_EXPO.Name = "trackBar_T_EXPO";
            this.trackBar_T_EXPO.Size = new System.Drawing.Size(224, 20);
            this.trackBar_T_EXPO.TabIndex = 27;
            this.trackBar_T_EXPO.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_T_EXPO.Value = 100;
            this.trackBar_T_EXPO.Scroll += new System.EventHandler(this.trackBar_T_EXPO_Scroll);
            // 
            // nRATE_yaw
            // 
            this.nRATE_yaw.BackColor = System.Drawing.Color.White;
            this.nRATE_yaw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nRATE_yaw.DecimalPlaces = 2;
            this.nRATE_yaw.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nRATE_yaw.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nRATE_yaw.Location = new System.Drawing.Point(164, 347);
            this.nRATE_yaw.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nRATE_yaw.Name = "nRATE_yaw";
            this.nRATE_yaw.Size = new System.Drawing.Size(68, 21);
            this.nRATE_yaw.TabIndex = 1;
            this.nRATE_yaw.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nRATE_yaw.ValueChanged += new System.EventHandler(this.nRATE_yaw_ValueChanged);
            // 
            // trackBar_T_MID
            // 
            this.trackBar_T_MID.AutoSize = false;
            this.trackBar_T_MID.Location = new System.Drawing.Point(14, 277);
            this.trackBar_T_MID.Maximum = 100;
            this.trackBar_T_MID.Name = "trackBar_T_MID";
            this.trackBar_T_MID.Size = new System.Drawing.Size(224, 20);
            this.trackBar_T_MID.TabIndex = 26;
            this.trackBar_T_MID.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_T_MID.Value = 80;
            this.trackBar_T_MID.Scroll += new System.EventHandler(this.trackBar_T_MID_Scroll);
            // 
            // nRATE_rp
            // 
            this.nRATE_rp.BackColor = System.Drawing.Color.White;
            this.nRATE_rp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nRATE_rp.DecimalPlaces = 2;
            this.nRATE_rp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nRATE_rp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nRATE_rp.Location = new System.Drawing.Point(164, 321);
            this.nRATE_rp.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nRATE_rp.Name = "nRATE_rp";
            this.nRATE_rp.Size = new System.Drawing.Size(68, 21);
            this.nRATE_rp.TabIndex = 0;
            this.nRATE_rp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nRATE_rp.ValueChanged += new System.EventHandler(this.nRATE_rp_ValueChanged);
            // 
            // trackbar_RC_Rate
            // 
            this.trackbar_RC_Rate.AutoSize = false;
            this.trackbar_RC_Rate.LargeChange = 1;
            this.trackbar_RC_Rate.Location = new System.Drawing.Point(12, 142);
            this.trackbar_RC_Rate.Maximum = 250;
            this.trackbar_RC_Rate.Name = "trackbar_RC_Rate";
            this.trackbar_RC_Rate.Size = new System.Drawing.Size(224, 20);
            this.trackbar_RC_Rate.TabIndex = 17;
            this.trackbar_RC_Rate.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackbar_RC_Rate.Value = 100;
            this.trackbar_RC_Rate.Scroll += new System.EventHandler(this.trackbar_RC_Rate_Scroll);
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.ForeColor = System.Drawing.Color.Black;
            this.label66.Location = new System.Drawing.Point(16, 24);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(49, 13);
            this.label66.TabIndex = 19;
            this.label66.Text = "RC Expo";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.ForeColor = System.Drawing.Color.Black;
            this.label65.Location = new System.Drawing.Point(16, 74);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(48, 13);
            this.label65.TabIndex = 18;
            this.label65.Text = "RC Rate";
            // 
            // nRCExpo
            // 
            this.nRCExpo.BackColor = System.Drawing.Color.White;
            this.nRCExpo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nRCExpo.DecimalPlaces = 2;
            this.nRCExpo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nRCExpo.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nRCExpo.Location = new System.Drawing.Point(19, 40);
            this.nRCExpo.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nRCExpo.Name = "nRCExpo";
            this.nRCExpo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nRCExpo.Size = new System.Drawing.Size(55, 21);
            this.nRCExpo.TabIndex = 21;
            this.nRCExpo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nRCExpo.ValueChanged += new System.EventHandler(this.nRCExpo_ValueChanged);
            // 
            // trackbar_RC_Expo
            // 
            this.trackbar_RC_Expo.AutoSize = false;
            this.trackbar_RC_Expo.BackColor = System.Drawing.Color.White;
            this.trackbar_RC_Expo.Location = new System.Drawing.Point(12, 125);
            this.trackbar_RC_Expo.Maximum = 100;
            this.trackbar_RC_Expo.Name = "trackbar_RC_Expo";
            this.trackbar_RC_Expo.Size = new System.Drawing.Size(224, 20);
            this.trackbar_RC_Expo.TabIndex = 16;
            this.trackbar_RC_Expo.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackbar_RC_Expo.Value = 80;
            this.trackbar_RC_Expo.Scroll += new System.EventHandler(this.trackbar_RC_Expo_Scroll);
            // 
            // nRCRate
            // 
            this.nRCRate.BackColor = System.Drawing.Color.White;
            this.nRCRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nRCRate.DecimalPlaces = 2;
            this.nRCRate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nRCRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nRCRate.Location = new System.Drawing.Point(19, 91);
            this.nRCRate.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nRCRate.Name = "nRCRate";
            this.nRCRate.Size = new System.Drawing.Size(55, 21);
            this.nRCRate.TabIndex = 20;
            this.nRCRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nRCRate.ValueChanged += new System.EventHandler(this.nRCRate_ValueChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(3, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(325, 436);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Gains/PID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 407);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(260, 26);
            this.label5.TabIndex = 0;
            this.label5.Text = "Aqua color box indicates setting was changed in GUI,\r\nbut not written to flight c" +
    "ontroller.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabPageRC
            // 
            this.tabPageRC.BackColor = System.Drawing.Color.White;
            this.tabPageRC.Controls.Add(this.groupBox6);
            this.tabPageRC.Controls.Add(this.groupBox5);
            this.tabPageRC.Location = new System.Drawing.Point(4, 22);
            this.tabPageRC.Name = "tabPageRC";
            this.tabPageRC.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRC.Size = new System.Drawing.Size(587, 452);
            this.tabPageRC.TabIndex = 0;
            this.tabPageRC.Text = "RC Control Settings";
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(362, 7);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(219, 436);
            this.groupBox6.TabIndex = 78;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Channel I/O";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Location = new System.Drawing.Point(6, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(350, 436);
            this.groupBox5.TabIndex = 77;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "AUX Channel Function Assignment";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(10, 418);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(328, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Red border indicates, that setting was changed but not written to FC";
            // 
            // tabPageRealtime
            // 
            this.tabPageRealtime.BackColor = System.Drawing.Color.White;
            this.tabPageRealtime.Controls.Add(this.splitContainer1);
            this.tabPageRealtime.ForeColor = System.Drawing.Color.Black;
            this.tabPageRealtime.Location = new System.Drawing.Point(4, 22);
            this.tabPageRealtime.Name = "tabPageRealtime";
            this.tabPageRealtime.Size = new System.Drawing.Size(587, 452);
            this.tabPageRealtime.TabIndex = 2;
            this.tabPageRealtime.Text = "Avionics Data";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.cb_monitor_rate);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.b_pause);
            this.splitContainer1.Panel1.ForeColor = System.Drawing.Color.Black;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox8);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox7);
            this.splitContainer1.Panel2.Controls.Add(this.l_i2cerrors);
            this.splitContainer1.Panel2.Controls.Add(this.label21);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.l_cycletime);
            this.splitContainer1.Panel2.Controls.Add(this.l_vbatt);
            this.splitContainer1.Panel2.Controls.Add(this.label11);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.l_powersum);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.zgMonitor);
            this.splitContainer1.Size = new System.Drawing.Size(982, 452);
            this.splitContainer1.SplitterDistance = 32;
            this.splitContainer1.TabIndex = 108;
            // 
            // cb_monitor_rate
            // 
            this.cb_monitor_rate.BackColor = System.Drawing.Color.White;
            this.cb_monitor_rate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cb_monitor_rate.ForeColor = System.Drawing.Color.Black;
            this.cb_monitor_rate.FormattingEnabled = true;
            this.cb_monitor_rate.Location = new System.Drawing.Point(451, 6);
            this.cb_monitor_rate.Name = "cb_monitor_rate";
            this.cb_monitor_rate.Size = new System.Drawing.Size(57, 21);
            this.cb_monitor_rate.TabIndex = 3;
            this.cb_monitor_rate.SelectedIndexChanged += new System.EventHandler(this.cb_monitor_rate_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(375, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Refresh Rate";
            // 
            // b_pause
            // 
            this.b_pause.ForeColor = System.Drawing.Color.Black;
            this.b_pause.Location = new System.Drawing.Point(514, 5);
            this.b_pause.Name = "b_pause";
            this.b_pause.Size = new System.Drawing.Size(69, 21);
            this.b_pause.TabIndex = 77;
            this.b_pause.Text = "Pause";
            this.b_pause.UseVisualStyleBackColor = true;
            this.b_pause.Click += new System.EventHandler(this.b_pause_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.Color.Transparent;
            this.groupBox8.Controls.Add(this.b_cal_acc);
            this.groupBox8.Controls.Add(this.b_cal_mag);
            this.groupBox8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox8.ForeColor = System.Drawing.Color.Black;
            this.groupBox8.Location = new System.Drawing.Point(383, 192);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(77, 69);
            this.groupBox8.TabIndex = 105;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Calibrate";
            // 
            // b_cal_acc
            // 
            this.b_cal_acc.ForeColor = System.Drawing.Color.Black;
            this.b_cal_acc.Location = new System.Drawing.Point(6, 15);
            this.b_cal_acc.Name = "b_cal_acc";
            this.b_cal_acc.Size = new System.Drawing.Size(65, 21);
            this.b_cal_acc.TabIndex = 78;
            this.b_cal_acc.Text = "ACC";
            this.b_cal_acc.UseVisualStyleBackColor = true;
            this.b_cal_acc.Click += new System.EventHandler(this.b_cal_acc_Click);
            // 
            // b_cal_mag
            // 
            this.b_cal_mag.ForeColor = System.Drawing.Color.Black;
            this.b_cal_mag.Location = new System.Drawing.Point(6, 40);
            this.b_cal_mag.Name = "b_cal_mag";
            this.b_cal_mag.Size = new System.Drawing.Size(65, 21);
            this.b_cal_mag.TabIndex = 79;
            this.b_cal_mag.Text = "MAG";
            this.b_cal_mag.UseVisualStyleBackColor = true;
            this.b_cal_mag.Click += new System.EventHandler(this.b_cal_mag_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.Transparent;
            this.groupBox7.Controls.Add(this.label22);
            this.groupBox7.Controls.Add(this.label26);
            this.groupBox7.Controls.Add(this.l_alt);
            this.groupBox7.Controls.Add(this.cb_head);
            this.groupBox7.Controls.Add(this.l_head);
            this.groupBox7.Controls.Add(this.cb_alt);
            this.groupBox7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox7.ForeColor = System.Drawing.Color.Black;
            this.groupBox7.Location = new System.Drawing.Point(289, 192);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(89, 69);
            this.groupBox7.TabIndex = 104;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Alt/Heading";
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Gainsboro;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(21, 16);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 14);
            this.label22.TabIndex = 54;
            this.label22.Text = "ALT";
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Orange;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(21, 30);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(41, 14);
            this.label26.TabIndex = 57;
            this.label26.Text = "HEAD";
            // 
            // l_alt
            // 
            this.l_alt.AutoSize = true;
            this.l_alt.ForeColor = System.Drawing.Color.Black;
            this.l_alt.Location = new System.Drawing.Point(68, 16);
            this.l_alt.Name = "l_alt";
            this.l_alt.Size = new System.Drawing.Size(13, 13);
            this.l_alt.TabIndex = 55;
            this.l_alt.Text = "0";
            // 
            // cb_head
            // 
            this.cb_head.AutoSize = true;
            this.cb_head.Location = new System.Drawing.Point(8, 30);
            this.cb_head.Name = "cb_head";
            this.cb_head.Size = new System.Drawing.Size(15, 14);
            this.cb_head.TabIndex = 56;
            this.cb_head.UseVisualStyleBackColor = true;
            // 
            // l_head
            // 
            this.l_head.AutoSize = true;
            this.l_head.ForeColor = System.Drawing.Color.Black;
            this.l_head.Location = new System.Drawing.Point(68, 30);
            this.l_head.Name = "l_head";
            this.l_head.Size = new System.Drawing.Size(13, 13);
            this.l_head.TabIndex = 58;
            this.l_head.Text = "0";
            // 
            // cb_alt
            // 
            this.cb_alt.AutoSize = true;
            this.cb_alt.Location = new System.Drawing.Point(8, 16);
            this.cb_alt.Name = "cb_alt";
            this.cb_alt.Size = new System.Drawing.Size(15, 14);
            this.cb_alt.TabIndex = 53;
            this.cb_alt.UseVisualStyleBackColor = true;
            // 
            // l_i2cerrors
            // 
            this.l_i2cerrors.AutoSize = true;
            this.l_i2cerrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_i2cerrors.ForeColor = System.Drawing.Color.Black;
            this.l_i2cerrors.Location = new System.Drawing.Point(530, 242);
            this.l_i2cerrors.Name = "l_i2cerrors";
            this.l_i2cerrors.Size = new System.Drawing.Size(35, 15);
            this.l_i2cerrors.TabIndex = 102;
            this.l_i2cerrors.Text = "0000";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(466, 242);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(55, 15);
            this.label21.TabIndex = 101;
            this.label21.Text = "I²C Error:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.l_gyro_yaw);
            this.groupBox2.Controls.Add(this.l_gyro_pitch);
            this.groupBox2.Controls.Add(this.l_gyro_roll);
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.cb_gyro_yaw);
            this.groupBox2.Controls.Add(this.label30);
            this.groupBox2.Controls.Add(this.cb_gyro_pitch);
            this.groupBox2.Controls.Add(this.label31);
            this.groupBox2.Controls.Add(this.cb_gyro_roll);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(194, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(89, 69);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gyroscope";
            // 
            // l_gyro_yaw
            // 
            this.l_gyro_yaw.AutoSize = true;
            this.l_gyro_yaw.Location = new System.Drawing.Point(66, 45);
            this.l_gyro_yaw.Name = "l_gyro_yaw";
            this.l_gyro_yaw.Size = new System.Drawing.Size(13, 13);
            this.l_gyro_yaw.TabIndex = 52;
            this.l_gyro_yaw.Text = "0";
            // 
            // l_gyro_pitch
            // 
            this.l_gyro_pitch.AutoSize = true;
            this.l_gyro_pitch.Location = new System.Drawing.Point(66, 30);
            this.l_gyro_pitch.Name = "l_gyro_pitch";
            this.l_gyro_pitch.Size = new System.Drawing.Size(13, 13);
            this.l_gyro_pitch.TabIndex = 51;
            this.l_gyro_pitch.Text = "0";
            // 
            // l_gyro_roll
            // 
            this.l_gyro_roll.AutoSize = true;
            this.l_gyro_roll.Location = new System.Drawing.Point(66, 16);
            this.l_gyro_roll.Name = "l_gyro_roll";
            this.l_gyro_roll.Size = new System.Drawing.Size(13, 13);
            this.l_gyro_roll.TabIndex = 50;
            this.l_gyro_roll.Text = "0";
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.Magenta;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(22, 44);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(41, 14);
            this.label29.TabIndex = 49;
            this.label29.Text = "YAW";
            // 
            // cb_gyro_yaw
            // 
            this.cb_gyro_yaw.AutoSize = true;
            this.cb_gyro_yaw.Checked = true;
            this.cb_gyro_yaw.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_gyro_yaw.Location = new System.Drawing.Point(9, 44);
            this.cb_gyro_yaw.Name = "cb_gyro_yaw";
            this.cb_gyro_yaw.Size = new System.Drawing.Size(15, 14);
            this.cb_gyro_yaw.TabIndex = 48;
            this.cb_gyro_yaw.UseVisualStyleBackColor = true;
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.Cyan;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(22, 30);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(41, 14);
            this.label30.TabIndex = 47;
            this.label30.Text = "PITCH";
            // 
            // cb_gyro_pitch
            // 
            this.cb_gyro_pitch.AutoSize = true;
            this.cb_gyro_pitch.Checked = true;
            this.cb_gyro_pitch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_gyro_pitch.Location = new System.Drawing.Point(9, 30);
            this.cb_gyro_pitch.Name = "cb_gyro_pitch";
            this.cb_gyro_pitch.Size = new System.Drawing.Size(15, 14);
            this.cb_gyro_pitch.TabIndex = 46;
            this.cb_gyro_pitch.UseVisualStyleBackColor = true;
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.Khaki;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(22, 16);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(41, 14);
            this.label31.TabIndex = 45;
            this.label31.Text = "ROLL";
            // 
            // cb_gyro_roll
            // 
            this.cb_gyro_roll.AutoSize = true;
            this.cb_gyro_roll.Checked = true;
            this.cb_gyro_roll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_gyro_roll.Location = new System.Drawing.Point(9, 16);
            this.cb_gyro_roll.Name = "cb_gyro_roll";
            this.cb_gyro_roll.Size = new System.Drawing.Size(15, 14);
            this.cb_gyro_roll.TabIndex = 44;
            this.cb_gyro_roll.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(466, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 15);
            this.label6.TabIndex = 94;
            this.label6.Text = "Batt:";
            // 
            // l_cycletime
            // 
            this.l_cycletime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.l_cycletime.AutoSize = true;
            this.l_cycletime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_cycletime.ForeColor = System.Drawing.Color.Black;
            this.l_cycletime.Location = new System.Drawing.Point(530, 197);
            this.l_cycletime.Name = "l_cycletime";
            this.l_cycletime.Size = new System.Drawing.Size(55, 15);
            this.l_cycletime.TabIndex = 98;
            this.l_cycletime.Text = "0000 ms";
            // 
            // l_vbatt
            // 
            this.l_vbatt.AutoSize = true;
            this.l_vbatt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_vbatt.ForeColor = System.Drawing.Color.Black;
            this.l_vbatt.Location = new System.Drawing.Point(530, 212);
            this.l_vbatt.Name = "l_vbatt";
            this.l_vbatt.Size = new System.Drawing.Size(51, 15);
            this.l_vbatt.TabIndex = 97;
            this.l_vbatt.Text = "0.0 volts";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(465, 197);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 15);
            this.label11.TabIndex = 99;
            this.label11.Text = "Cycle Time:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(466, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 95;
            this.label7.Text = "Power:";
            // 
            // l_powersum
            // 
            this.l_powersum.AutoSize = true;
            this.l_powersum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_powersum.ForeColor = System.Drawing.Color.Black;
            this.l_powersum.Location = new System.Drawing.Point(530, 227);
            this.l_powersum.Name = "l_powersum";
            this.l_powersum.Size = new System.Drawing.Size(35, 15);
            this.l_powersum.TabIndex = 96;
            this.l_powersum.Text = "0000";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.l_acc_z);
            this.groupBox1.Controls.Add(this.l_acc_pitch);
            this.groupBox1.Controls.Add(this.l_acc_roll);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.cb_acc_z);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.cb_acc_pitch);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cb_acc_roll);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(4, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(89, 69);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Accelerometer";
            // 
            // l_acc_z
            // 
            this.l_acc_z.AutoSize = true;
            this.l_acc_z.Location = new System.Drawing.Point(66, 45);
            this.l_acc_z.Name = "l_acc_z";
            this.l_acc_z.Size = new System.Drawing.Size(13, 13);
            this.l_acc_z.TabIndex = 52;
            this.l_acc_z.Text = "0";
            // 
            // l_acc_pitch
            // 
            this.l_acc_pitch.AutoSize = true;
            this.l_acc_pitch.Location = new System.Drawing.Point(66, 30);
            this.l_acc_pitch.Name = "l_acc_pitch";
            this.l_acc_pitch.Size = new System.Drawing.Size(13, 13);
            this.l_acc_pitch.TabIndex = 51;
            this.l_acc_pitch.Text = "0";
            // 
            // l_acc_roll
            // 
            this.l_acc_roll.AutoSize = true;
            this.l_acc_roll.Location = new System.Drawing.Point(66, 16);
            this.l_acc_roll.Name = "l_acc_roll";
            this.l_acc_roll.Size = new System.Drawing.Size(13, 13);
            this.l_acc_roll.TabIndex = 50;
            this.l_acc_roll.Text = "0";
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Blue;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(22, 44);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 14);
            this.label18.TabIndex = 49;
            this.label18.Text = "Z";
            // 
            // cb_acc_z
            // 
            this.cb_acc_z.AutoSize = true;
            this.cb_acc_z.Checked = true;
            this.cb_acc_z.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_acc_z.Location = new System.Drawing.Point(9, 44);
            this.cb_acc_z.Name = "cb_acc_z";
            this.cb_acc_z.Size = new System.Drawing.Size(15, 14);
            this.cb_acc_z.TabIndex = 48;
            this.cb_acc_z.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Green;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(22, 30);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 14);
            this.label16.TabIndex = 47;
            this.label16.Text = "PITCH";
            // 
            // cb_acc_pitch
            // 
            this.cb_acc_pitch.AutoSize = true;
            this.cb_acc_pitch.Checked = true;
            this.cb_acc_pitch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_acc_pitch.Location = new System.Drawing.Point(9, 30);
            this.cb_acc_pitch.Name = "cb_acc_pitch";
            this.cb_acc_pitch.Size = new System.Drawing.Size(15, 14);
            this.cb_acc_pitch.TabIndex = 46;
            this.cb_acc_pitch.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Red;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(22, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 14);
            this.label14.TabIndex = 45;
            this.label14.Text = "ROLL";
            // 
            // cb_acc_roll
            // 
            this.cb_acc_roll.AutoSize = true;
            this.cb_acc_roll.Checked = true;
            this.cb_acc_roll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_acc_roll.Location = new System.Drawing.Point(9, 16);
            this.cb_acc_roll.Name = "cb_acc_roll";
            this.cb_acc_roll.Size = new System.Drawing.Size(15, 14);
            this.cb_acc_roll.TabIndex = 44;
            this.cb_acc_roll.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.l_mag_yaw);
            this.groupBox3.Controls.Add(this.l_mag_pitch);
            this.groupBox3.Controls.Add(this.l_mag_roll);
            this.groupBox3.Controls.Add(this.label35);
            this.groupBox3.Controls.Add(this.cb_mag_yaw);
            this.groupBox3.Controls.Add(this.label36);
            this.groupBox3.Controls.Add(this.cb_mag_pitch);
            this.groupBox3.Controls.Add(this.label37);
            this.groupBox3.Controls.Add(this.cb_mag_roll);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(99, 192);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(89, 69);
            this.groupBox3.TabIndex = 55;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Magnetometer";
            // 
            // l_mag_yaw
            // 
            this.l_mag_yaw.AutoSize = true;
            this.l_mag_yaw.Location = new System.Drawing.Point(66, 45);
            this.l_mag_yaw.Name = "l_mag_yaw";
            this.l_mag_yaw.Size = new System.Drawing.Size(13, 13);
            this.l_mag_yaw.TabIndex = 52;
            this.l_mag_yaw.Text = "0";
            // 
            // l_mag_pitch
            // 
            this.l_mag_pitch.AutoSize = true;
            this.l_mag_pitch.Location = new System.Drawing.Point(66, 30);
            this.l_mag_pitch.Name = "l_mag_pitch";
            this.l_mag_pitch.Size = new System.Drawing.Size(13, 13);
            this.l_mag_pitch.TabIndex = 51;
            this.l_mag_pitch.Text = "0";
            // 
            // l_mag_roll
            // 
            this.l_mag_roll.AutoSize = true;
            this.l_mag_roll.Location = new System.Drawing.Point(66, 16);
            this.l_mag_roll.Name = "l_mag_roll";
            this.l_mag_roll.Size = new System.Drawing.Size(13, 13);
            this.l_mag_roll.TabIndex = 50;
            this.l_mag_roll.Text = "0";
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(22, 44);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(41, 14);
            this.label35.TabIndex = 49;
            this.label35.Text = "YAW";
            // 
            // cb_mag_yaw
            // 
            this.cb_mag_yaw.AutoSize = true;
            this.cb_mag_yaw.Location = new System.Drawing.Point(9, 44);
            this.cb_mag_yaw.Name = "cb_mag_yaw";
            this.cb_mag_yaw.Size = new System.Drawing.Size(15, 14);
            this.cb_mag_yaw.TabIndex = 48;
            this.cb_mag_yaw.UseVisualStyleBackColor = true;
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.Color.MediumPurple;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(22, 30);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(41, 14);
            this.label36.TabIndex = 47;
            this.label36.Text = "PITCH";
            // 
            // cb_mag_pitch
            // 
            this.cb_mag_pitch.AutoSize = true;
            this.cb_mag_pitch.Location = new System.Drawing.Point(9, 30);
            this.cb_mag_pitch.Name = "cb_mag_pitch";
            this.cb_mag_pitch.Size = new System.Drawing.Size(15, 14);
            this.cb_mag_pitch.TabIndex = 46;
            this.cb_mag_pitch.UseVisualStyleBackColor = true;
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.Color.CadetBlue;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(22, 16);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(41, 14);
            this.label37.TabIndex = 45;
            this.label37.Text = "ROLL";
            // 
            // cb_mag_roll
            // 
            this.cb_mag_roll.AutoSize = true;
            this.cb_mag_roll.Location = new System.Drawing.Point(9, 16);
            this.cb_mag_roll.Name = "cb_mag_roll";
            this.cb_mag_roll.Size = new System.Drawing.Size(15, 14);
            this.cb_mag_roll.TabIndex = 44;
            this.cb_mag_roll.UseVisualStyleBackColor = true;
            // 
            // zgMonitor
            // 
            this.zgMonitor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.zgMonitor.Location = new System.Drawing.Point(4, 3);
            this.zgMonitor.Name = "zgMonitor";
            this.zgMonitor.ScrollGrace = 0D;
            this.zgMonitor.ScrollMaxX = 0D;
            this.zgMonitor.ScrollMaxY = 0D;
            this.zgMonitor.ScrollMaxY2 = 0D;
            this.zgMonitor.ScrollMinX = 0D;
            this.zgMonitor.ScrollMinY = 0D;
            this.zgMonitor.ScrollMinY2 = 0D;
            this.zgMonitor.Size = new System.Drawing.Size(580, 188);
            this.zgMonitor.TabIndex = 5;
            // 
            // timer_realtime
            // 
            this.timer_realtime.Tick += new System.EventHandler(this.timer_realtime_Tick);
            // 
            // bkgWorker
            // 
            this.bkgWorker.WorkerSupportsCancellation = true;
            this.bkgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bkgWorker_DoWork);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cb_serial_port,
            this.toolStripLabel2,
            this.cb_serial_speed,
            this.b_connect,
            this.toolStripSeparator1,
            this.b_read_settings,
            this.b_write_settings,
            this.b_reset,
            this.toolStripSeparator2,
            this.MWC_Button,
            this.b_about});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(595, 54);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(29, 51);
            this.toolStripLabel1.Text = "Port";
            // 
            // cb_serial_port
            // 
            this.cb_serial_port.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cb_serial_port.Name = "cb_serial_port";
            this.cb_serial_port.Size = new System.Drawing.Size(75, 54);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(34, 51);
            this.toolStripLabel2.Text = "Baud";
            // 
            // cb_serial_speed
            // 
            this.cb_serial_speed.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cb_serial_speed.Name = "cb_serial_speed";
            this.cb_serial_speed.Size = new System.Drawing.Size(75, 54);
            // 
            // b_connect
            // 
            this.b_connect.Image = global::MultiWiiSimpleGUI.Properties.Resources.connect;
            this.b_connect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_connect.Name = "b_connect";
            this.b_connect.Size = new System.Drawing.Size(56, 51);
            this.b_connect.Text = "Connect";
            this.b_connect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.b_connect.Click += new System.EventHandler(this.b_connect_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
            // 
            // b_read_settings
            // 
            this.b_read_settings.Image = global::MultiWiiSimpleGUI.Properties.Resources.read_settings;
            this.b_read_settings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_read_settings.Name = "b_read_settings";
            this.b_read_settings.Size = new System.Drawing.Size(37, 51);
            this.b_read_settings.Text = "Read";
            this.b_read_settings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.b_read_settings.Click += new System.EventHandler(this.b_read_settings_Click);
            // 
            // b_write_settings
            // 
            this.b_write_settings.Image = global::MultiWiiSimpleGUI.Properties.Resources.write_settings;
            this.b_write_settings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_write_settings.Name = "b_write_settings";
            this.b_write_settings.Size = new System.Drawing.Size(39, 51);
            this.b_write_settings.Text = "Write";
            this.b_write_settings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.b_write_settings.Click += new System.EventHandler(this.b_write_settings_Click);
            // 
            // b_reset
            // 
            this.b_reset.Image = global::MultiWiiSimpleGUI.Properties.Resources.reset;
            this.b_reset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_reset.Name = "b_reset";
            this.b_reset.Size = new System.Drawing.Size(39, 51);
            this.b_reset.Text = "Reset";
            this.b_reset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.ForeColor = System.Drawing.Color.Black;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 54);
            // 
            // MWC_Button
            // 
            this.MWC_Button.BackColor = System.Drawing.Color.White;
            this.MWC_Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MWC_Button.Enabled = false;
            this.MWC_Button.Image = global::MultiWiiSimpleGUI.Properties.Resources.logo;
            this.MWC_Button.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MWC_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MWC_Button.Name = "MWC_Button";
            this.MWC_Button.Size = new System.Drawing.Size(123, 51);
            this.MWC_Button.Text = "MWC";
            // 
            // b_about
            // 
            this.b_about.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.b_about.Image = global::MultiWiiSimpleGUI.Properties.Resources.about;
            this.b_about.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.b_about.Name = "b_about";
            this.b_about.Size = new System.Drawing.Size(44, 51);
            this.b_about.Text = "About";
            this.b_about.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.b_about.Click += new System.EventHandler(this.b_about_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.trackBar1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(587, 451);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(117, 256);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(246, 45);
            this.trackBar1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(38, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // mainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(595, 531);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(611, 570);
            this.MinimumSize = new System.Drawing.Size(611, 570);
            this.Name = "mainGUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MWC SimpleGUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainGUI_FormClosing);
            this.Load += new System.EventHandler(this.mainGUI_Load);
            this.tabMain.ResumeLayout(false);
            this.tabPagePID.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nPAlarm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTEXPO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTMID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRATE_tpid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_T_EXPO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRATE_yaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_T_MID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRATE_rp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbar_RC_Rate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRCExpo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbar_RC_Expo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nRCRate)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPageRC.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPageRealtime.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPageRC;
        private System.Windows.Forms.TabPage tabPagePID;
        private System.Windows.Forms.TabPage tabPageRealtime;
        private System.Windows.Forms.Timer timer_realtime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_monitor_rate;
        private ZedGraph.ZedGraphControl zgMonitor;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox cb_acc_roll;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox cb_acc_z;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox cb_acc_pitch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label l_acc_z;
        private System.Windows.Forms.Label l_acc_pitch;
        private System.Windows.Forms.Label l_acc_roll;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label l_mag_yaw;
        private System.Windows.Forms.Label l_mag_pitch;
        private System.Windows.Forms.Label l_mag_roll;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.CheckBox cb_mag_yaw;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.CheckBox cb_mag_pitch;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.CheckBox cb_mag_roll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label l_gyro_yaw;
        private System.Windows.Forms.Label l_gyro_pitch;
        private System.Windows.Forms.Label l_gyro_roll;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.CheckBox cb_gyro_yaw;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.CheckBox cb_gyro_pitch;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.CheckBox cb_gyro_roll;
        private System.Windows.Forms.Label l_head;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.CheckBox cb_head;
        private System.Windows.Forms.Label l_alt;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox cb_alt;
        private MultiWiiGUIControls.artifical_horizon attitudeIndicatorInstrumentControl1;
        private MultiWiiGUIControls.heading_indicator headingIndicatorInstrumentControl1;
        private MultiWiiGUIControls.GpsIndicatorInstrumentControl gpsIndicator;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label_sok;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.NumericUpDown nRATE_tpid;
        private System.Windows.Forms.NumericUpDown nRATE_yaw;
        private System.Windows.Forms.NumericUpDown nRATE_rp;
        private System.Windows.Forms.Button b_pause;
        private MultiWiiGUIControls.rc_input_control rci_Control_settings;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.TrackBar trackbar_RC_Rate;
        private System.Windows.Forms.TrackBar trackbar_RC_Expo;
        private MultiWiiGUIControls.rc_expo_control rc_expo_control1;
        private System.ComponentModel.BackgroundWorker bkgWorker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nRCExpo;
        private System.Windows.Forms.NumericUpDown nRCRate;
        private System.Windows.Forms.Button b_cal_acc;
        private System.Windows.Forms.Button b_cal_mag;
        private MultiWiiGUIControls.indicator_lamp indGPS;
        private MultiWiiGUIControls.indicator_lamp indSONAR;
        private MultiWiiGUIControls.indicator_lamp indMAG;
        private MultiWiiGUIControls.indicator_lamp indBARO;
        private MultiWiiGUIControls.indicator_lamp indACC;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label l_cycletime;
        private System.Windows.Forms.Label l_vbatt;
        private System.Windows.Forms.Label l_powersum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nPAlarm;
        private System.Windows.Forms.Label l_i2cerrors;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TrackBar trackBar_T_EXPO;
        private System.Windows.Forms.TrackBar trackBar_T_MID;
        private MultiWiiGUIControls.throttle_expo_control throttle_expo_control1;
        private System.Windows.Forms.NumericUpDown nTEXPO;
        private System.Windows.Forms.NumericUpDown nTMID;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox cb_serial_port;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox cb_serial_speed;
        private System.Windows.Forms.ToolStripButton b_connect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton b_read_settings;
        private System.Windows.Forms.ToolStripButton b_write_settings;
        private System.Windows.Forms.ToolStripButton b_about;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MultiWiiGUIControls.indicator_lamp indOPTIC;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton b_reset;
        private MultiWiiGUIControls.MWGUIMotors motorsIndicator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripButton MWC_Button;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

