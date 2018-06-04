/* MultiWii SimpleGUI by KKUSA  based on.....
 * MultiWii Windows GUI by Andras Schaffer (EOSBandi)
 * December  2012     V1.0 Beta
 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   any later version. see <http://www.gnu.org/licenses/>
 *  
 * Instrument controls are based on AvionicsInstrument Controls written by Guillaume CHOUTEAU http://www.codeproject.com/Articles/27411/C-Avionic-Instrument-Controls 
 * Graphs are using ZedGraph control http://sourceforge.net/projects/zedgraph/
 * 
*/

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using MultiWiiGUIControls;
using ZedGraph;
using System.Globalization;
using System.Reflection;

namespace MultiWiiSimpleGUI
{

    public partial class mainGUI : Form
    {

        #region Common variables (properties)

        const string sVersion = "2.1";
        const string sVersionUrl = "http://mw-wingui.googlecode.com/svn/trunk/WinGui2/version.xml";
        
        static string sOptionsConfigFilename = "optionsconfig";
        const string sGuiSettingsFilename = "gui_settings.xml";
        enum CopterType { Tri = 1, QuadP, QuadX, BI, Gimbal, Y6, Hex6, FlyWing, Y4, Hex6X, Octo8Coax, Octo8P, Octo8X };

        string[] sSerialSpeeds = { "115200", "57600", "38400", "19200", "9600" };
        string[] sRefreshSpeeds = { "20 Hz", "10 Hz", "5 Hz", "2 Hz", "1 Hz" };
        int[] iRefreshIntervals = { 50, 100, 200, 500, 1000 };
        const int rcLow = 1300;
        const int rcMid = 1700;

        const string sRelName = "2.1";

        //PID values
        static PID[] Pid;


        static SerialPort serialPort;
        static bool isConnected = false;                        //is port connected or not ?
        static bool bSerialError = false;
        static bool isPaused = false;

        static int iRefreshDivider = 20;                         //This used to force slower refresh for certain parameters


        static int iSelectedTabIndex = 0;                          //Contains the actually selected tab
        static double xTimeStamp = 0;
        static byte[] bSerialBuffer;

        static int iCheckBoxItems = 0;                          //number of checkboxItems (readed from optionsconfig.xml
        static int iPidItems = 0;                                //number if Pid items (const definition)
        static mw_data_gui mw_gui;
        static mw_settings mw_params;
        static GUI_settings gui_settings;
        static bool bOptions_needs_refresh = true;
        

        static string[] option_names;
        static string[] option_indicators;
        static string[] option_desc;

        static LineItem curve_acc_roll, curve_acc_pitch, curve_acc_z;
        static LineItem curve_gyro_roll, curve_gyro_pitch, curve_gyro_yaw;
        static LineItem curve_mag_roll, curve_mag_pitch, curve_mag_yaw;
        static LineItem curve_alt, curve_head;
        


        static RollingPointPairList list_acc_roll, list_acc_pitch, list_acc_z;
        static RollingPointPairList list_gyro_roll, list_gyro_pitch, list_gyro_yaw;
        static RollingPointPairList list_mag_roll, list_mag_pitch, list_mag_yaw;
        static RollingPointPairList list_alt, list_head;
        

        static Scale xScale;

        CheckBoxEx[, ,] aux;
        indicator_lamp[] indicators;

        System.Windows.Forms.Label[] cb_labels;
        System.Windows.Forms.Label[] aux_labels;
        System.Windows.Forms.Label[,] lmh_labels;
        
        CultureInfo culture = new CultureInfo("en-US");


        XmlTextReader reader;
        int z;

        //Commands
         const int MSP_IDENT                =100;
         const int MSP_STATUS               =101;
         const int MSP_RAW_IMU              =102;
         const int MSP_SERVO                =103;
         const int MSP_MOTOR                =104;
         const int MSP_RC                   =105;
         const int MSP_RAW_GPS              =106;
         const int MSP_COMP_GPS             =107;
         const int MSP_ATTITUDE             =108;
         const int MSP_ALTITUDE             =109;
         const int MSP_BAT                  =110;
         const int MSP_RC_TUNING            =111;
         const int MSP_PID                  =112;
         const int MSP_BOX                  =113;
         const int MSP_MISC                 =114;
         const int MSP_MOTOR_PINS           =115;
         const int MSP_BOXNAMES             =116;
         const int MSP_PIDNAMES             =117;
         const int MSP_WP                   =118;


         const int MSP_SET_RAW_RC           =200;
         const int MSP_SET_RAW_GPS          =201;
         const int MSP_SET_PID              =202;
         const int MSP_SET_BOX              =203;
         const int MSP_SET_RC_TUNING        =204;
         const int MSP_ACC_CALIBRATION      =205;
         const int MSP_MAG_CALIBRATION      =206;
         const int MSP_SET_MISC             =207;
         const int MSP_RESET_CONF           =208;
         const int MSP_SET_WP               =209;

         const int MSP_EEPROM_WRITE         =250;
         const int MSP_DEBUG                =254;



          const byte IDLE                   =0;
          const byte HEADER_START           =1;
          const byte HEADER_M               =2;
          const byte HEADER_ARROW           =3;
          const byte HEADER_SIZE            =4;
          const byte HEADER_CMD             =5;
          const byte HEADER_ERR             =6;

         static byte[] inBuf;


         static byte c_state = IDLE;
         static Boolean err_rcvd = false;
         static byte offset = 0;
         static byte dataSize = 0;
         static byte checksum = 0;
         static byte cmd;
         static int serial_error_count = 0;
         static int serial_packet_count = 0;


        #endregion

        public mainGUI()
        {
            //AppDomain section loads DLL's from embedded resources rather than having them as separate files in output directory.
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                string resource = Array.Find(this.GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
            InitializeComponent();
        }

        private void mainGUI_Load(object sender, EventArgs e)
        {
            //First step, check it gui_settings file is exists or not, if not then start settings wizard
            //if (!File.Exists(sGuiSettingsFilename))
            //{
            //    setup_wizard panelSetupWizard = new setup_wizard();
            //    panelSetupWizard.ShowDialog();

            //}

            //Now there must be a valid settings file, so we can continue with normal execution
            //Start with Settings file read, and parse exit if unsuccessfull
            gui_settings = new GUI_settings();
            //if (!gui_settings.read_from_xml(sGuiSettingsFilename))
            //{
            //    Environment.Exit(-1);
           // }

            sOptionsConfigFilename = sOptionsConfigFilename + gui_settings.iSoftwareVersion + ".xml";
            read_options_config();                  //read and parse optionsconfig.xml file. sets iCheckBoxItems

            mw_gui = new mw_data_gui(iPidItems, iCheckBoxItems, gui_settings.iSoftwareVersion);
            mw_params = new mw_settings(iPidItems, iCheckBoxItems, gui_settings.iSoftwareVersion);

            //Quick hack to get pid names to mw_params untill redo the structures
            for (int i = 0; i < iPidItems; i++)
            {
                mw_params.pidnames[i] = Pid[i].name;
            }

            bSerialBuffer = new byte[65];
            inBuf = new byte[300];   //init input buffer

            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;

            //rcOptions1 = new byte[iCheckBoxItems];
            //rcOptions2 = new byte[iCheckBoxItems];

            //Fill out settings tab
            //l_Settings_folder.Text = gui_settings.sSettingsFolder;

            #region Indicator_Struct
            //Build indicator lamps array
            indicators = new indicator_lamp[iCheckBoxItems];
            int row = 0; int col = 0;
            int startx = 468; int starty = 269;
            for (int i = 0; i < iCheckBoxItems; i++)
            {
                indicators[i] = new indicator_lamp();
                indicators[i].Location = new Point(startx + col * 52, starty + row * 19);
                indicators[i].Visible = true;
                indicators[i].Text = option_indicators[i];
                indicators[i].indicator_color = 1;
                indicators[i].Anchor = AnchorStyles.Right;
                this.splitContainer1.Panel2.Controls.Add(indicators[i]);
                //this.panel1.Controls.Add(indicators[i]);
                col++;
                if (col == 2) { col = 0; row++; }
            } 
            #endregion


            #region AUX_Checkbox_Struct
            //Build the RC control checkboxes structure


            aux = new CheckBoxEx[4, 4, iCheckBoxItems];

            startx = 80;
            starty = 60;

            int a, b, c;
            for (c = 0; c < 4; c++)
            {
                for (a = 0; a < 3; a++)
                {
                    for (b = 0; b < iCheckBoxItems; b++)
                    {
                        aux[c, a, b] = new CheckBoxEx();
                        aux[c, a, b].Location = new Point(startx + a * 18 + c * 70, starty + b * 25);
                        aux[c, a, b].Visible = true;
                        aux[c, a, b].Text = "";
                        aux[c, a, b].AutoSize = true;
                        aux[c, a, b].Size = new Size(16, 16);
                        aux[c, a, b].UseVisualStyleBackColor = true;
                        aux[c, a, b].CheckedChanged += new System.EventHandler(this.aux_checked_changed_event);
                        //Set info on the given checkbox position
                        aux[c, a, b].aux = c;           //Which aux channel
                        aux[c, a, b].rclevel = a;       //which rc level
                        aux[c, a, b].item = b;          //Which item
                        this.groupBox5.Controls.Add(aux[c, a, b]);

                    }
                }
            }

            aux_labels = new System.Windows.Forms.Label[4];
            lmh_labels = new System.Windows.Forms.Label[4, 3];          // aux1-4, L,M,H
            string strlmh = "LMH";
            for (a = 0; a < 4; a++)
            {
                aux_labels[a] = new System.Windows.Forms.Label();
                aux_labels[a].Text = "AUX" + String.Format("{0:0}", a + 1);
                aux_labels[a].Location = new Point(startx + a * 70 + 8, starty - 35);
                aux_labels[a].AutoSize = true;
                aux_labels[a].ForeColor = Color.Black;
                this.groupBox5.Controls.Add(aux_labels[a]);
                for (b = 0; b < 3; b++)
                {
                    lmh_labels[a, b] = new System.Windows.Forms.Label();
                    lmh_labels[a, b].Text = strlmh.Substring(b, 1); ;
                    lmh_labels[a, b].Location = new Point(startx + a * 70 + b * 18, starty - 20);
                    lmh_labels[a, b].AutoSize = true;
                    lmh_labels[a, b].ForeColor = Color.Black;
                    this.groupBox5.Controls.Add(lmh_labels[a, b]);
                }

            }

            cb_labels = new System.Windows.Forms.Label[20];

            for (z = 0; z < iCheckBoxItems; z++)
            {
                cb_labels[z] = new System.Windows.Forms.Label();
                cb_labels[z].Text = option_names[z];
                cb_labels[z].Location = new Point(10, starty + z * 25);
                cb_labels[z].Visible = true;
                cb_labels[z].AutoSize = true;
                cb_labels[z].ForeColor = Color.Black;
                cb_labels[z].TextAlign = ContentAlignment.MiddleRight;
                toolTip1.SetToolTip(cb_labels[z], option_desc[z]);
                this.groupBox5.Controls.Add(cb_labels[z]);
            } 
            #endregion

            //Build PID control structure based on the Pid structure.
            #region PID_Struct
            const int iLineSpace = 36;
            const int iRow1 = 25;
            const int iRow2 = 125;
            const int iRow3 = 220;
            const int iTopY = 30;
            Font fontField = new Font("Arial", 9, FontStyle.Regular);
            Size fieldSize = new Size(70, 25);


            for (int i = 0; i < iPidItems; i++)
            {
                Pid[i].pidLabel = new System.Windows.Forms.Label();
                Pid[i].pidLabel.Text = Pid[i].name;
                Pid[i].pidLabel.Location = new Point(iRow1, 15 + i * iLineSpace);
                Pid[i].pidLabel.Visible = true;
                Pid[i].pidLabel.AutoSize = true;
                Pid[i].pidLabel.ForeColor = Color.Black;
                Pid[i].pidLabel.TextAlign = ContentAlignment.MiddleRight;
                toolTip1.SetToolTip(Pid[i].pidLabel, Pid[i].description);
                this.groupBox4.Controls.Add(Pid[i].pidLabel);

                if (Pid[i].Pshown)
                {
                    Pid[i].Pfield = new System.Windows.Forms.NumericUpDown();
                    Pid[i].Pfield.ValueChanged += new EventHandler(pfield_valuechange);
                    Pid[i].Pfield.Location = new Point(iRow1, iTopY + i * iLineSpace);
                    Pid[i].Pfield.Size = fieldSize;
                    Pid[i].Pfield.Font = fontField;
                    Pid[i].Pfield.BorderStyle = BorderStyle.FixedSingle;
                    Pid[i].Pfield.TextAlign = HorizontalAlignment.Center;
                    Pid[i].Pfield.Maximum = Pid[i].Pmax;
                    Pid[i].Pfield.Minimum = Pid[i].Pmin;
                    Pid[i].Pfield.DecimalPlaces = decimals(Pid[i].Pprec);
                    Pid[i].Pfield.Increment = 1 / (decimal)Pid[i].Pprec;
                    this.groupBox4.Controls.Add(Pid[i].Pfield);

                    Pid[i].Plabel = new System.Windows.Forms.Label();
                    Pid[i].Plabel.Text = "P";
                    Pid[i].Plabel.Font = fontField;
                    Pid[i].Plabel.ForeColor = Color.Black;
                    Pid[i].Plabel.Location = new Point(iRow1 - 20, iTopY + i * iLineSpace);
                    this.groupBox4.Controls.Add(Pid[i].Plabel);



                }
                if (Pid[i].Ishown)
                {
                    Pid[i].Ifield = new System.Windows.Forms.NumericUpDown();
                    Pid[i].Ifield.ValueChanged += new EventHandler(ifield_valuechange);
                    Pid[i].Ifield.Location = new Point(iRow2, iTopY + i * iLineSpace);
                    Pid[i].Ifield.Size = fieldSize;
                    Pid[i].Ifield.Font = fontField;
                    Pid[i].Ifield.BorderStyle = BorderStyle.FixedSingle;
                    Pid[i].Ifield.TextAlign = HorizontalAlignment.Center;
                    Pid[i].Ifield.Maximum = Pid[i].Imax;
                    Pid[i].Ifield.Minimum = Pid[i].Imin;
                    Pid[i].Ifield.DecimalPlaces = decimals(Pid[i].Iprec);
                    Pid[i].Ifield.Increment = 1 / (decimal)Pid[i].Iprec;
                    this.groupBox4.Controls.Add(Pid[i].Ifield);

                    Pid[i].Ilabel = new System.Windows.Forms.Label();
                    Pid[i].Ilabel.Text = "I";
                    Pid[i].Ilabel.Font = fontField;
                    Pid[i].Ilabel.ForeColor = Color.Black;
                    Pid[i].Ilabel.Location = new Point(iRow2 - 20, iTopY + i * iLineSpace);
                    this.groupBox4.Controls.Add(Pid[i].Ilabel);



                }
                if (Pid[i].Dshown)
                {
                    Pid[i].Dfield = new System.Windows.Forms.NumericUpDown();
                    Pid[i].Dfield.ValueChanged += new EventHandler(dfield_valuechange);
                    Pid[i].Dfield.Location = new Point(iRow3, iTopY + i * iLineSpace);
                    Pid[i].Dfield.Size = fieldSize;
                    Pid[i].Dfield.Font = fontField;
                    Pid[i].Dfield.BorderStyle = BorderStyle.FixedSingle;
                    Pid[i].Dfield.TextAlign = HorizontalAlignment.Center;
                    Pid[i].Dfield.Maximum = Pid[i].Dmax;
                    Pid[i].Dfield.Minimum = Pid[i].Dmin;
                    Pid[i].Dfield.DecimalPlaces = decimals(Pid[i].Dprec);
                    Pid[i].Dfield.Increment = 1 / (decimal)Pid[i].Dprec;
                    this.groupBox4.Controls.Add(Pid[i].Dfield);

                    Pid[i].Dlabel = new System.Windows.Forms.Label();
                    Pid[i].Dlabel.Text = "D";
                    Pid[i].Dlabel.Font = fontField;
                    Pid[i].Dlabel.ForeColor = Color.Black;
                    Pid[i].Dlabel.Location = new Point(iRow3 - 18, iTopY + i * iLineSpace);
                    this.groupBox4.Controls.Add(Pid[i].Dlabel);

                }


            } 
            #endregion


            this.Refresh();

            serial_ports_enumerate();
            foreach (string speed in sSerialSpeeds)
            {
                cb_serial_speed.Items.Add(speed);
            }
            cb_serial_speed.SelectedItem = "115200";

            if (cb_serial_port.Items.Count == 0)
            {
                b_connect.Enabled = false;          //Nos serial port, disable connect
            }

            //Init serial port object
            serialPort = new SerialPort();
            //Set up serial port parameters (at least the ones what we know upfront
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.Handshake = Handshake.None;
            serialPort.DtrEnable = false;               //??

            serialPort.ReadBufferSize = 4096;            //4K byte of read buffer
            serialPort.ReadTimeout = 500;               // 500msec timeout;

            //Init Realtime Monitor panel controls
            foreach (string rate in sRefreshSpeeds)
            {
                cb_monitor_rate.Items.Add(rate);
            }
            cb_monitor_rate.SelectedIndex = 0;              //20Hz is the default
            //cb_serial_speed.SelectedItem = "115200";

            //Setup timers
            timer_realtime.Tick += new EventHandler(timer_realtime_Tick);
            timer_realtime.Interval = iRefreshIntervals[cb_monitor_rate.SelectedIndex];
            timer_realtime.Enabled = true;
            timer_realtime.Stop();


            //Set up zgMonitor control for real time monitoring
            GraphPane myPane = zgMonitor.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = "";
            myPane.XAxis.Title.Text = "";
            myPane.YAxis.Title.Text = "";

            #region Zed_Points_Curves
            //Set up pointlists and curves
            list_acc_roll = new RollingPointPairList(300);
            curve_acc_roll = myPane.AddCurve("acc_roll", list_acc_roll, Color.Red, SymbolType.None);

            list_acc_pitch = new RollingPointPairList(300);
            curve_acc_pitch = myPane.AddCurve("acc_pitch", list_acc_pitch, Color.Green, SymbolType.None);

            list_acc_z = new RollingPointPairList(300);
            curve_acc_z = myPane.AddCurve("acc_z", list_acc_z, Color.Blue, SymbolType.None);

            list_gyro_roll = new RollingPointPairList(300);
            curve_gyro_roll = myPane.AddCurve("gyro_roll", list_gyro_roll, Color.Gold, SymbolType.None);

            list_gyro_pitch = new RollingPointPairList(300);
            curve_gyro_pitch = myPane.AddCurve("gyro_pitch", list_gyro_pitch, Color.DarkCyan, SymbolType.None);

            list_gyro_yaw = new RollingPointPairList(300);
            curve_gyro_yaw = myPane.AddCurve("gyro_yaw", list_gyro_yaw, Color.Magenta, SymbolType.None);

            list_mag_roll = new RollingPointPairList(300);
            curve_mag_roll = myPane.AddCurve("mag_roll", list_mag_roll, Color.CadetBlue, SymbolType.None);

            list_mag_pitch = new RollingPointPairList(300);
            curve_mag_pitch = myPane.AddCurve("mag_pitch", list_mag_pitch, Color.MediumPurple, SymbolType.None);

            list_mag_yaw = new RollingPointPairList(300);
            curve_mag_yaw = myPane.AddCurve("mag_yaw", list_mag_yaw, Color.DarkGoldenrod, SymbolType.None);

            list_alt = new RollingPointPairList(300);
            curve_alt = myPane.AddCurve("alt", list_alt, Color.Maroon, SymbolType.None);

            list_head = new RollingPointPairList(300);
            curve_head = myPane.AddCurve("head", list_head, Color.Orange, SymbolType.None);

            // Show the x axis grid
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;
            

            // Make the Y axis scale red
            myPane.YAxis.Scale.FontSpec.FontColor = Color.Black;
            myPane.YAxis.Title.FontSpec.FontColor = Color.Black;

            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.IsOpposite = false;

            // Don't display the Y zero line
            myPane.YAxis.MajorGrid.IsZeroLine = true;

            // Align the Y axis labels so they are flush to the axis
            myPane.YAxis.Scale.Align = AlignP.Inside;
            myPane.YAxis.Scale.IsVisible = false;

            // Manually set the axis range
            myPane.YAxis.Scale.Min = -150;
            myPane.YAxis.Scale.Max = 150;

            myPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(123, 194, 205), 45.0f);
            myPane.Fill = new Fill(Color.White, Color.White, 45.0f);
            myPane.Legend.IsVisible = false;

            myPane.Border.IsVisible = false;

            myPane.XAxis.Scale.IsVisible = false;
            myPane.YAxis.Scale.IsVisible = true;

            myPane.XAxis.Scale.MagAuto = true;
            myPane.YAxis.Scale.MagAuto = false;

            zgMonitor.IsEnableHPan = true;
            zgMonitor.IsEnableHZoom = true;

            foreach (ZedGraph.LineItem li in myPane.CurveList)
            {
                li.Line.Width = 1;
            }


            myPane.YAxis.Title.FontSpec.FontColor = Color.Black;
            myPane.XAxis.Title.FontSpec.FontColor = Color.Black;

            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 300;
            myPane.XAxis.Type = AxisType.Linear;

            zgMonitor.ScrollGrace = 0;
            xScale = zgMonitor.GraphPane.XAxis.Scale;
            zgMonitor.AxisChange(); 
            #endregion


            //Disable buttons that are not working till connected
            b_reset.Enabled = false;
            b_cal_acc.Enabled = false;
            b_cal_mag.Enabled = false;
            b_read_settings.Enabled = false;
            b_write_settings.Enabled = false;

        }

        private void timer_realtime_Tick(object sender, EventArgs e)
        {

            
            if (serialPort.BytesToRead == 0)
            {

                if ((iRefreshDivider % gui_settings.MSP_STATUS_rate_divider) == 0) MSPquery(MSP_STATUS);
                if ((iRefreshDivider % gui_settings.MSP_RAW_IMU_rate_divider) == 0) MSPquery(MSP_RAW_IMU);
                if ((iRefreshDivider % gui_settings.MSP_SERVO_rate_divider) == 0) MSPquery(MSP_SERVO);
                if ((iRefreshDivider % gui_settings.MSP_MOTOR_rate_divider) == 0) MSPquery(MSP_MOTOR);
                if ((iRefreshDivider % gui_settings.MSP_RAW_GPS_rate_divider) == 0) MSPquery(MSP_RAW_GPS);
                if ((iRefreshDivider % gui_settings.MSP_COMP_GPS_rate_divider) == 0) MSPquery(MSP_COMP_GPS);
                if ((iRefreshDivider % gui_settings.MSP_ATTITUDE_rate_divider) == 0) MSPquery(MSP_ATTITUDE);
                if ((iRefreshDivider % gui_settings.MSP_ALTITUDE_rate_divider) == 0) MSPquery(MSP_ALTITUDE);
                if ((iRefreshDivider % gui_settings.MSP_BAT_rate_divider) == 0) MSPquery(MSP_BAT);
                if ((iRefreshDivider % gui_settings.MSP_RC_rate_divider) == 0) MSPquery(MSP_RC);
                if ((iRefreshDivider % gui_settings.MSP_MISC_rate_divider) == 0) MSPquery(MSP_MISC);
                if ((iRefreshDivider % gui_settings.MSP_DEBUG_rate_divider) == 0) MSPquery(MSP_DEBUG);

                if ((mw_gui.mode & (1 << 5)) > 0)
                {                         //armed
                    if ((iRefreshDivider % 20) == 0) MSPqueryWP(0);         //get home position
                }
                else { mw_gui.GPS_home_lon = 0; mw_gui.GPS_home_lat = 0;}
                
                if ((mw_gui.mode & (1 << 7)) > 0)
                {                         //poshold
                    if ((iRefreshDivider % 20) == 0) MSPqueryWP(16);         //get hold position
                }
                else { mw_gui.GPS_poshold_lon = 0; mw_gui.GPS_poshold_lat = 0;}

            }
            update_gui();
            iRefreshDivider--;
            if (iRefreshDivider == 0) iRefreshDivider = 20;      //reset

        }

        private void b_connect_Click(object sender, EventArgs e)
        {
            //go to first screen when connect
            if (tabMain.SelectedIndex == 4) { tabMain.SelectedIndex = 0; }

            if (serialPort.IsOpen)              //Disconnect
            {
                b_connect.Text = "Connect";
                b_connect.Image = Properties.Resources.connect;
                isConnected = false;
                timer_realtime.Stop();                       //Stop timer(s), whatever it takes
                //timer_rc.Stop();
                bkgWorker.CancelAsync();
                System.Threading.Thread.Sleep(500);         //Wait bkworker to finish
                serialPort.Close();

                //Disable buttons that are not working here
                b_reset.Enabled = false;
                b_cal_acc.Enabled = false;
                b_cal_mag.Enabled = false;
                b_read_settings.Enabled = false;
                b_write_settings.Enabled = false;



            }
            else                               //Connect
            {

                if (cb_serial_port.Text == "") { return; }  //if no port selected then do nothin' at connect
                //Assume that the selection in the combobox for port is still valid
                serialPort.PortName = cb_serial_port.Text;
                serialPort.BaudRate = int.Parse(cb_serial_speed.Text);
                try
                {
                    serialPort.Open();
                }
                catch
                {
                    //WRONG, it seems that the combobox selection pointed to a port which is no longer available
                    MessageBoxEx.Show(this, "Please check that your USB cable is still connected.\r\nAfter you press OK, Serial ports will be re-enumerated", "Error opening COM port", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    serial_ports_enumerate();
                    return; //Exit without connecting;
                }
                //Set button text and status
                b_connect.Text = "Disconnect";
                b_connect.Image = Properties.Resources.disconnect;
                isConnected = true;

                serial_packet_count = 0;
                serial_error_count = 0;

                //Enable buttons that are not working here
                b_reset.Enabled = true;
                b_cal_acc.Enabled = true;
                b_cal_mag.Enabled = true;
                b_read_settings.Enabled = true;
                b_write_settings.Enabled = true;



                //We have to do it for a couple of times to ensure that we will have parameters loaded 
                for (int i=0;i<10;i++) {

                MSPquery(MSP_PID);
                MSPquery(MSP_RC_TUNING);
                MSPquery(MSP_IDENT);
                MSPquery(MSP_BOX);
                MSPquery(MSP_MISC);
                }

                               
                //Run BackgroundWorker
                if (!bkgWorker.IsBusy) { bkgWorker.RunWorkerAsync(); }

                timer_realtime.Start();

                System.Threading.Thread.Sleep(1000);

                bOptions_needs_refresh = true;
                update_gui();

             
            }
        }

        private void cb_monitor_rate_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Change refresh rate
            timer_realtime.Interval = iRefreshIntervals[cb_monitor_rate.SelectedIndex];
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (tabMain.SelectedIndex)
            {
                case 2:
                    iSelectedTabIndex = tabMain.SelectedIndex;
                    break;
                case 1:
                    iSelectedTabIndex = tabMain.SelectedIndex;
                    break;
                default:
                    iSelectedTabIndex = tabMain.SelectedIndex;
                    break;
            }


        }

        private void l_ports_label_DoubleClick(object sender, EventArgs e)
        {
            serial_ports_enumerate();
        }

        private void serial_ports_enumerate()
        {
            //Enumerate all serial ports
            b_connect.Enabled = true;           //Enable the connect button

            string[] ports = SerialPort.GetPortNames();
            cb_serial_port.Items.Clear();
            foreach (string port in ports)
            {
                cb_serial_port.Items.Add(port);
            }
            
            //if prefered port is not available then select the first one 
            if (cb_serial_port.Text == "")
            {
                if (cb_serial_port.Items.Count > 0) { cb_serial_port.SelectedIndex = 0; }
            }

            //Disable connect button if there is no selected com port
            if (cb_serial_port.Items.Count == 0) { b_connect.Enabled = false; }
        }

        private void read_options_config()
        {

            option_names = new string[20];
            option_indicators = new string[20];
            option_desc = new string[100];


            int iPidID = 0;

            Pid = new PID[20];          //Max 20 PID values if we have more then we will ignore it

            iCheckBoxItems = 0;
            iPidItems = 0;

            if (File.Exists(sOptionsConfigFilename))
            {
                reader = new XmlTextReader(sOptionsConfigFilename);
            }
            else
            {
                MessageBoxEx.Show(this, "Options file " + sOptionsConfigFilename + " not found", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Environment.Exit(-1);
            }
            try
            {
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:

                            if (String.Compare(reader.Name, "aux_option", true) == 0 && reader.HasAttributes)
                            {
                                for (int i = 0; i < reader.AttributeCount; i++)
                                {
                                    reader.MoveToAttribute(i);
                                    if (String.Compare(reader.Name, "name", true) == 0)
                                    {
                                        option_names[iCheckBoxItems] = reader.Value;
                                    }
                                    if (String.Compare(reader.Name, "desc", true) == 0)
                                    {
                                        option_desc[iCheckBoxItems] = reader.Value;
                                    }
                                    if (String.Compare(reader.Name, "ind", true) == 0)
                                    {
                                        option_indicators[iCheckBoxItems] = reader.Value;
                                    }

                                }
                                iCheckBoxItems++;
                            }




                            if (String.Compare(reader.Name, "pid", true) == 0 && reader.HasAttributes)
                            {
                                reader.MoveToAttribute("id");
                                iPidID = Convert.ToInt16(reader.GetAttribute("id"));
                                Pid[iPidID] = new PID();
                                reader.MoveToAttribute("name");
                                Pid[iPidID].name = reader.GetAttribute("name");
                                reader.MoveToAttribute("desc");
                                Pid[iPidID].description = reader.GetAttribute("desc");
                                iPidItems++;
                            }
                            if (String.Compare(reader.Name, "p", true) == 0 && reader.HasAttributes)
                            {
                                reader.MoveToAttribute("id");
                                iPidID = Convert.ToInt16(reader.GetAttribute("id"));
                                reader.MoveToAttribute("shown");
                                Pid[iPidID].Pshown = Convert.ToBoolean(reader.GetAttribute("shown"));
                                reader.MoveToAttribute("min");
                                Pid[iPidID].Pmin = Convert.ToDecimal(reader.GetAttribute("min"),culture);
                                reader.MoveToAttribute("max");
                                Pid[iPidID].Pmax = Convert.ToDecimal(reader.GetAttribute("max"),culture);
                                reader.MoveToAttribute("prec");
                                Pid[iPidID].Pprec = Convert.ToInt16(reader.GetAttribute("prec"));
                            }
                            if (String.Compare(reader.Name, "i", true) == 0 && reader.HasAttributes)
                            {
                                reader.MoveToAttribute("id");
                                iPidID = Convert.ToInt16(reader.GetAttribute("id"));
                                reader.MoveToAttribute("shown");
                                Pid[iPidID].Ishown = Convert.ToBoolean(reader.GetAttribute("shown"));
                                reader.MoveToAttribute("min");
                                Pid[iPidID].Imin = Convert.ToDecimal(reader.GetAttribute("min"),culture);
                                reader.MoveToAttribute("max");
                                Pid[iPidID].Imax = Convert.ToDecimal(reader.GetAttribute("max"),culture);
                                reader.MoveToAttribute("prec");
                                Pid[iPidID].Iprec = Convert.ToInt16(reader.GetAttribute("prec"));
                            }
                            if (String.Compare(reader.Name, "d", true) == 0 && reader.HasAttributes)
                            {
                                reader.MoveToAttribute("id");
                                iPidID = Convert.ToInt16(reader.GetAttribute("id"));
                                reader.MoveToAttribute("shown");
                                Pid[iPidID].Dshown = Convert.ToBoolean(reader.GetAttribute("shown"));
                                reader.MoveToAttribute("min");
                                Pid[iPidID].Dmin = Convert.ToDecimal(reader.GetAttribute("min"),culture);
                                reader.MoveToAttribute("max");
                                Pid[iPidID].Dmax = Convert.ToDecimal(reader.GetAttribute("max"),culture);
                                reader.MoveToAttribute("prec");
                                Pid[iPidID].Dprec = Convert.ToInt16(reader.GetAttribute("prec"));
                            }


                            
                            
                            break;

                    }
                }
            }
            catch
            {
                MessageBoxEx.Show(this, "Options file contains invalid data around Line : " + reader.LineNumber, "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Environment.Exit(-1);
            }

            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        private void b_pause_Click(object sender, EventArgs e)
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                b_pause.ForeColor = Color.Red;
                b_pause.Text = "Paused";
                timer_realtime.Stop();
            }
            else
            {
                b_pause.ForeColor = Color.Black;
                b_pause.Text = "Pause";
                if (isConnected) { timer_realtime.Start(); }
            }

        }

        private byte read8(SerialPort s)
        {

            return ((byte)s.ReadByte());
        }

        private int read16(SerialPort s)
        {
            byte[] buffer = {0,0};
            int retval;

            buffer[0] = (byte)s.ReadByte();
            buffer[1] = (byte)s.ReadByte();

            retval = BitConverter.ToInt16(buffer,0);

            return (retval);
        }

        private void evaluate_command(byte cmd)
        {

            byte ptr; 

            switch (cmd)
            {
                case MSP_IDENT:
                    ptr = 0;
                    mw_gui.version = (byte)inBuf[ptr++];
                    mw_gui.multiType = (byte)inBuf[ptr];
                    mw_gui.protocol_version = (byte)inBuf[ptr++];
                    mw_gui.capability = BitConverter.ToInt32(inBuf, ptr); ptr += 4;
                    break;
                case MSP_STATUS:
                    ptr = 0;
                    mw_gui.cycleTime = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.i2cErrors = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.present = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.mode = BitConverter.ToUInt32(inBuf, ptr); ptr += 4;
                    break;
                case MSP_RAW_IMU:
                    ptr = 0;
                    mw_gui.ax = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.ay = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.az = BitConverter.ToInt16(inBuf, ptr); ptr += 2;

                    mw_gui.gx = BitConverter.ToInt16(inBuf, ptr) / 8; ptr += 2;
                    mw_gui.gy = BitConverter.ToInt16(inBuf, ptr) / 8; ptr += 2;
                    mw_gui.gz = BitConverter.ToInt16(inBuf, ptr) / 8; ptr += 2;

                    mw_gui.magx = BitConverter.ToInt16(inBuf, ptr) / 3; ptr += 2;
                    mw_gui.magy = BitConverter.ToInt16(inBuf, ptr) / 3; ptr += 2;
                    mw_gui.magz = BitConverter.ToInt16(inBuf, ptr) / 3; ptr += 2;
                    break;
                case MSP_SERVO:
                    ptr = 0;
                    for (int i = 0; i < 8; i++)
                    {
                        mw_gui.servos[i] = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    }
                    break;
                case MSP_MOTOR:
                    ptr = 0;
                    for (int i = 0; i < 8; i++)
                    {
                        mw_gui.motors[i] = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    }
                    break;
                case MSP_RC:
                    ptr = 0;
                    mw_gui.rcRoll = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.rcPitch = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.rcYaw = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.rcThrottle = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.rcAux1 = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.rcAux2 = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.rcAux3 = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.rcAux4 = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    break;
                case MSP_RAW_GPS:
                    ptr = 0;
                    mw_gui.GPS_fix = (byte)inBuf[ptr++];
                    mw_gui.GPS_numSat = (byte)inBuf[ptr++];
                    mw_gui.GPS_latitude = BitConverter.ToInt32(inBuf, ptr); ptr += 4;
                    mw_gui.GPS_longitude = BitConverter.ToInt32(inBuf, ptr); ptr += 4;
                    mw_gui.GPS_altitude = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.GPS_speed = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    break;
                case MSP_COMP_GPS:
                    ptr = 0;
                    mw_gui.GPS_distanceToHome = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.GPS_directionToHome = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.GPS_update = (byte)inBuf[ptr++];
                    break;
                case MSP_ATTITUDE:
                    ptr = 0;
                    mw_gui.angx = BitConverter.ToInt16(inBuf, ptr) / 10; ptr += 2;
                    mw_gui.angy = BitConverter.ToInt16(inBuf, ptr) / 10; ptr += 2;
                    mw_gui.heading = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    break;
                case MSP_ALTITUDE:
                    ptr = 0;
                    mw_gui.baro = BitConverter.ToInt32(inBuf, ptr); ptr += 4;
                    break;
                case MSP_BAT:
                    ptr = 0;
                    mw_gui.vBat = (byte)inBuf[ptr++];
                    mw_gui.pMeterSum = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    break;
                case MSP_RC_TUNING:
                    ptr = 0;
                    mw_gui.rcRate = (byte)inBuf[ptr++];
                    mw_gui.rcExpo = (byte)inBuf[ptr++];
                    mw_gui.RollPitchRate = (byte)inBuf[ptr++];
                    mw_gui.YawRate = (byte)inBuf[ptr++];
                    mw_gui.DynThrPID = (byte)inBuf[ptr++];
                    mw_gui.ThrottleMID = (byte)inBuf[ptr++];
                    mw_gui.ThrottleEXPO = (byte)inBuf[ptr++];
                    break;
                case MSP_PID:
                    ptr = 0;
                    for (int i = 0; i < iPidItems; i++)
                    {
                        mw_gui.pidP[i] = (byte)inBuf[ptr++];
                        mw_gui.pidI[i] = (byte)inBuf[ptr++];
                        mw_gui.pidD[i] = (byte)inBuf[ptr++];
                    }
                    bOptions_needs_refresh = true;
                    break;
                case MSP_BOX:
                    ptr = 0;
                    for (int i = 0; i < iCheckBoxItems; i++)
                    {
                        mw_gui.activation[i] = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    }
                    break;
                case MSP_MISC:
                    ptr = 0;
                    mw_gui.powerTrigger = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    break;
                case MSP_DEBUG:
                    ptr = 0;
                    mw_gui.debug1 = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.debug2 = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.debug3 = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    mw_gui.debug4 = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    break;
                case MSP_WP:
                    ptr = 0;
                    byte wp_no = (byte)inBuf[ptr++];
                    if (wp_no == 0)
                    {
                        mw_gui.GPS_home_lat = BitConverter.ToInt32(inBuf, ptr); ptr += 4;
                        mw_gui.GPS_home_lon = BitConverter.ToInt32(inBuf, ptr); ptr += 4;
                        mw_gui.GPS_home_alt = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                        //flag comes here but not care
                    }
                    if (wp_no == 16)
                    {
                        mw_gui.GPS_poshold_lat = BitConverter.ToInt32(inBuf, ptr); ptr += 4;
                        mw_gui.GPS_poshold_lon = BitConverter.ToInt32(inBuf, ptr); ptr += 4;
                        mw_gui.GPS_poshold_alt = BitConverter.ToInt16(inBuf, ptr); ptr += 2;
                    }
                    break;


            }
        }

        private void bkgWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            byte c;

            // Do not access the form's BackgroundWorker reference directly.
            // Instead, use the reference provided by the sender parameter.
            BackgroundWorker bw = sender as BackgroundWorker;
            
            try
            {
                bool bIsPortOpen = serialPort.IsOpen;
            }
            catch
            {
                //Hmm, if this throws an exception it should mean that we have an issue here
                bSerialError = true;
                return;
            }

            bSerialError = false;

            while (!bw.CancellationPending)                // backgroundworker runs continously
            {

                if (serialPort.IsOpen)
                {
                    //Just process what is received.
                    while (serialPort.BytesToRead > 0)
                    {
                        c = (byte)serialPort.ReadByte();


                        switch (c_state)
                        {
                            case IDLE:
                                c_state = (c == '$') ? HEADER_START : IDLE;
                                break;
                            case HEADER_START:
                                c_state = (c == 'M') ? HEADER_M : IDLE;
                                break;

                            case HEADER_M:
                                if (c == '>')
                                {
                                    c_state = HEADER_ARROW;
                                }
                                else if (c == '!')
                                {
                                    c_state = HEADER_ERR;
                                }
                                else
                                {
                                    c_state = IDLE;
                                }
                                break;

                            case HEADER_ARROW:
                            case HEADER_ERR:
                                /* is this an error message? */
                                err_rcvd = (c_state == HEADER_ERR);        /* now we are expecting the payload size */
                                dataSize = c;
                                /* reset index variables */
                                offset = 0;
                                checksum = 0;
                                checksum ^= c;
                                c_state = HEADER_SIZE;
                                if (dataSize > 100) { c_state = IDLE; }

                                break;
                            case HEADER_SIZE:
                                cmd = c;
                                checksum ^= c;
                                c_state = HEADER_CMD;
                                break;
                            case HEADER_CMD:
                                if (offset < dataSize)
                                {
                                    checksum ^= c;
                                    inBuf[offset++] = c;
                                }
                                else
                                {

                                    /* compare calculated and transferred checksum */
                                    if (checksum == c)
                                    {
                                        if (err_rcvd)
                                        {
                                            // Console.WriteLine("Copter did not understand request type " + err_rcvd);
                                        }
                                        else
                                        {
                                            /* we got a valid response packet, evaluate it */
                                            serial_packet_count++;
                                            evaluate_command(cmd);
                                        }
                                    }
                                    else
                                    {
 
                                        serial_error_count++;

                                    }
                                    c_state = IDLE;
                                }
                                break;
                        }
                    }
                    
                }
                else   //port not opened, (it could happen when U disconnect the usb cable while connected
                {
                    //bSerialError = true; //do nothing
                    //return;
                }

            }// while

            e.Cancel = true;

        }

        private void update_gui()
        {


            if (bSerialError)
            {
                //Background worker returned error, disconnect serial port
                b_connect.Text = "Connect";
                isConnected = false;
                timer_realtime.Stop();                       //Stop timer(s), whatever it takes
                System.Threading.Thread.Sleep(iRefreshIntervals[cb_monitor_rate.SelectedIndex]);         //Wait for 1 cycle to let backgroundworker finish it's last job.
                try
                {
                    serialPort.Close();
                }
                catch
                {
                    MessageBoxEx.Show(this, "An error condition detected on the Serial port, check that your USB cable is connected", "Comm Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                bSerialError = false;
                return;
            }


            if (tabMain.SelectedIndex == 0 | tabMain.SelectedIndex == 1)        //Common tasks for both panel
            {

                throttle_expo_control1.SetRCExpoParameters((double)nTMID.Value, (double)nTEXPO.Value, mw_gui.rcThrottle);
                if (bOptions_needs_refresh)
                {
                    update_pid_panel();
                    update_aux_panel();
                    bOptions_needs_refresh = false;
                    
                }
            }


            // TAB RCControl
            if (tabMain.SelectedIndex == 1)
            {
                //update RC control values
                rci_Control_settings.SetRCInputParameters(mw_gui.rcThrottle, mw_gui.rcPitch, mw_gui.rcRoll, mw_gui.rcYaw, mw_gui.rcAux1, mw_gui.rcAux2, mw_gui.rcAux3, mw_gui.rcAux4);
                motorsIndicator1.SetMotorsIndicatorParameters(mw_gui.motors, mw_gui.servos, mw_gui.multiType);
                //Show LMH postions above switches
                lmh_labels[0, 0].BackColor = (mw_gui.rcAux1 < rcLow) ? Color.FromArgb(123, 194, 205) : Color.Transparent;
                lmh_labels[0, 1].BackColor = (mw_gui.rcAux1 > rcLow && mw_gui.rcAux1 < rcMid) ? Color.FromArgb(123, 194, 205) : Color.Transparent;
                lmh_labels[0, 2].BackColor = (mw_gui.rcAux1 > rcMid) ? Color.FromArgb(123, 194, 205) : Color.Transparent;

                lmh_labels[1, 0].BackColor = (mw_gui.rcAux2 < rcLow) ? Color.FromArgb(123, 194, 205) : Color.Transparent;
                lmh_labels[1, 1].BackColor = (mw_gui.rcAux2 > rcLow && mw_gui.rcAux2 < rcMid) ? Color.FromArgb(123, 194, 205) : Color.Transparent;
                lmh_labels[1, 2].BackColor = (mw_gui.rcAux2 > rcMid) ? Color.FromArgb(123, 194, 205) : Color.Transparent;

                lmh_labels[2, 0].BackColor = (mw_gui.rcAux3 < rcLow) ? Color.FromArgb(123, 194, 205) : Color.Transparent;
                lmh_labels[2, 1].BackColor = (mw_gui.rcAux3 > rcLow && mw_gui.rcAux3 < rcMid) ? Color.FromArgb(123, 194, 205) : Color.Transparent;
                lmh_labels[2, 2].BackColor = (mw_gui.rcAux3 > rcMid) ? Color.FromArgb(123, 194, 205) : Color.Transparent;

                lmh_labels[3, 0].BackColor = (mw_gui.rcAux4 < rcLow) ? Color.FromArgb(123, 194, 205) : Color.Transparent;
                lmh_labels[3, 1].BackColor = (mw_gui.rcAux4 > rcLow && mw_gui.rcAux4 < rcMid) ? Color.FromArgb(123, 194, 205) : Color.Transparent;
                lmh_labels[3, 2].BackColor = (mw_gui.rcAux4 > rcMid) ? Color.FromArgb(123, 194, 205) : Color.Transparent;

                //evaluate rc_options and recolor mode which supposed to be ON at the current rc values
                byte act1, act2, opt1, opt2;

                //Construct options switch mask based on rcAux input
                opt1 = (byte)(Convert.ToByte(mw_gui.rcAux1 < 1300) + Convert.ToByte(1300 < mw_gui.rcAux1 && mw_gui.rcAux1 < 1700) * 2 + Convert.ToByte(mw_gui.rcAux1 > 1700) * 4 + Convert.ToByte(mw_gui.rcAux2 < 1300) * 8 + Convert.ToByte(1300 < mw_gui.rcAux2 && mw_gui.rcAux2 < 1700) * 16 + Convert.ToByte(mw_gui.rcAux2 > 1700) * 32);
                opt2 = (byte)(Convert.ToByte(mw_gui.rcAux3 < 1300) + Convert.ToByte(1300 < mw_gui.rcAux3 && mw_gui.rcAux3 < 1700) * 2 + Convert.ToByte(mw_gui.rcAux3 > 1700) * 4 + Convert.ToByte(mw_gui.rcAux4 < 1300) * 8 + Convert.ToByte(1300 < mw_gui.rcAux4 && mw_gui.rcAux4 < 1700) * 16 + Convert.ToByte(mw_gui.rcAux4 > 1700) * 32);

                //Compare with switchbox settings
                for (int b = 0; b < iCheckBoxItems; b++)
                {
                    act1 = 0; act2 = 0;
                    for (byte a = 0; a < 3; a++)
                    {
                        if (aux[0, a, b].Checked) act1 += (byte)(1 << a);
                        if (aux[1, a, b].Checked) act1 += (byte)(1 << (3 + a));
                        if (aux[2, a, b].Checked) act2 += (byte)(1 << a);
                        if (aux[3, a, b].Checked) act2 += (byte)(1 << (3 + a));
                    }
                    //Highlight active function name
                    if ((opt1 & act1) != 0 || (opt2 & act2) != 0) { cb_labels[b].BackColor = Color.FromArgb(123, 194, 205); cb_labels[b].ForeColor = Color.Black; cb_labels[b].BorderStyle = BorderStyle.FixedSingle; } else { cb_labels[b].BackColor = Color.Transparent; cb_labels[b].ForeColor = Color.Black; cb_labels[b].BorderStyle = BorderStyle.None; }
                }
            }

            // TAB realtime
            if (tabMain.SelectedIndex == 2)
            {

                if (cb_acc_roll.Checked) { list_acc_roll.Add((double)xTimeStamp, mw_gui.ax); }
                l_acc_roll.Text = "" + mw_gui.ax;

                if (cb_acc_pitch.Checked) { list_acc_pitch.Add((double)xTimeStamp, mw_gui.ay); }
                l_acc_pitch.Text = "" + mw_gui.ay;

                if (cb_acc_z.Checked) { list_acc_z.Add((double)xTimeStamp, mw_gui.az); }
                l_acc_z.Text = "" + mw_gui.az;

                if (cb_gyro_roll.Checked) { list_gyro_roll.Add((double)xTimeStamp, mw_gui.gx); }
                l_gyro_roll.Text = "" + mw_gui.gx;

                if (cb_gyro_pitch.Checked) { list_gyro_pitch.Add((double)xTimeStamp, mw_gui.gy); }
                l_gyro_pitch.Text = "" + mw_gui.gy;

                if (cb_gyro_yaw.Checked) { list_gyro_yaw.Add((double)xTimeStamp, mw_gui.gz); }
                l_gyro_yaw.Text = "" + mw_gui.gz;

                if (cb_mag_roll.Checked) { list_mag_roll.Add((double)xTimeStamp, mw_gui.magx); }
                l_mag_roll.Text = "" + mw_gui.magx;

                if (cb_mag_pitch.Checked) { list_mag_pitch.Add((double)xTimeStamp, mw_gui.magy); }
                l_mag_pitch.Text = "" + mw_gui.magy;

                if (cb_mag_yaw.Checked) { list_mag_yaw.Add((double)xTimeStamp, mw_gui.magz); }
                l_mag_yaw.Text = "" + mw_gui.magz;

                if (cb_alt.Checked) { list_alt.Add((double)xTimeStamp, mw_gui.baro/100); }
                l_alt.Text = "" + (double)mw_gui.baro/100;

                if (cb_head.Checked) { list_head.Add((double)xTimeStamp, mw_gui.heading); }
                l_head.Text = "" + mw_gui.heading;


                xTimeStamp = xTimeStamp + 1;

                if (xTimeStamp > xScale.Max)
                {
                    double range = xScale.Max - xScale.Min;
                    xScale.Max = xScale.Max + 1;
                    xScale.Min = xScale.Max - range;
                }
                zgMonitor.AxisChange();
                zgMonitor.Invalidate();

                curve_acc_roll.IsVisible = cb_acc_roll.Checked;
                curve_acc_pitch.IsVisible = cb_acc_pitch.Checked;
                curve_acc_z.IsVisible = cb_acc_z.Checked;
                curve_gyro_roll.IsVisible = cb_gyro_roll.Checked;
                curve_gyro_pitch.IsVisible = cb_gyro_pitch.Checked;
                curve_gyro_yaw.IsVisible = cb_gyro_yaw.Checked;
                curve_mag_roll.IsVisible = cb_mag_roll.Checked;
                curve_mag_pitch.IsVisible = cb_mag_pitch.Checked;
                curve_mag_yaw.IsVisible = cb_mag_yaw.Checked;
                curve_alt.IsVisible = cb_alt.Checked;
                curve_head.IsVisible = cb_head.Checked;


                headingIndicatorInstrumentControl1.SetHeadingIndicatorParameters(mw_gui.heading);
                attitudeIndicatorInstrumentControl1.SetArtificalHorizon(-mw_gui.angy, -mw_gui.angx);
                gpsIndicator.SetGPSIndicatorParameters(mw_gui.GPS_directionToHome, mw_gui.GPS_distanceToHome, mw_gui.GPS_numSat, Convert.ToBoolean(mw_gui.GPS_fix), true, Convert.ToBoolean(mw_gui.GPS_update));

                

                //update indicator lamps
                indACC.SetStatus((mw_gui.present & 1) != 0);
                indBARO.SetStatus((mw_gui.present & 2) != 0);
                indMAG.SetStatus((mw_gui.present & 4) != 0);
                indGPS.SetStatus((mw_gui.present & 8) != 0);
                indSONAR.SetStatus((mw_gui.present & 16) != 0);



                for (int i = 0; i < iCheckBoxItems; i++)
                {
                    if ((mw_gui.mode & (1 << i)) > 0) indicators[i].SetStatus(true);
                    else indicators[i].SetStatus(false);
                }


                l_cycletime.Text = String.Format("{0:0000} µs", mw_gui.cycleTime);
                l_vbatt.Text = String.Format("{0:0.0} volts", (double)mw_gui.vBat / 10);
                l_powersum.Text = String.Format("{0:0}", mw_gui.pMeterSum);
                l_i2cerrors.Text = String.Format("{0:0}",mw_gui.i2cErrors);

            } //end if tab=realtime;
        }

        private void b_reread_rc_options_Click(object sender, EventArgs e)
        {
            MSPquery(MSP_BOX);
            bOptions_needs_refresh = true;
        }

        private void aux_checked_changed_event(object sender, EventArgs e)
        {
            CheckBoxEx cb = ((CheckBoxEx)(sender));

            cb.IsHighlighted = cb.Checked == ((byte)(mw_gui.activation[cb.item] & (1 << cb.aux * 3 + cb.rclevel)) == 0) ? true : false; 

        }

        private void b_cal_acc_Click(object sender, EventArgs e)
        {


            if (!isConnected)
            {
                MessageBoxEx.Show(this, "Please Connect Flight Controller first!", "FC Not connected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBoxEx.Show(this, "Make sure that your copter is level!\r\nPress OK when ready, then keep copter steady for 5 seconds.", "Calibrating Accelerometer", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                MSPquery(MSP_ACC_CALIBRATION);
            }

        }

        private void b_cal_mag_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                MessageBoxEx.Show(this, "Please Connect Flight Controller first!", "FC Not connected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBoxEx.Show(this, "After pressing OK please rotate your copter around all three axes\r\n at least a full 360° turn for each axes. You will have 1 minute to finish", "Calibrating Magnetometer", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {

                MSPquery(MSP_MAG_CALIBRATION);

            }
        }

        private void b_read_settings_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                MSPquery(MSP_PID);
                MSPquery(MSP_RC_TUNING);
                MSPquery(MSP_IDENT);
                MSPquery(MSP_BOX);
                MSPquery(MSP_MISC);
                System.Threading.Thread.Sleep(500); 
                bOptions_needs_refresh = true;
                update_gui();
            }
        }

        private void update_params()
        {
            //Get parameters from GUI

            for (int i = 0; i < iPidItems; i++)
            {
                if (Pid[i].Pshown) { mw_gui.pidP[i] = (byte)(Pid[i].Pfield.Value * Pid[i].Pprec); }
                if (Pid[i].Ishown) { mw_gui.pidI[i] = (byte)(Pid[i].Ifield.Value * Pid[i].Iprec); }
                if (Pid[i].Dshown) { mw_gui.pidD[i] = (byte)(Pid[i].Dfield.Value * Pid[i].Dprec); }

                mw_params.pidP[i] = mw_gui.pidP[i];
                mw_params.pidI[i] = mw_gui.pidI[i];
                mw_params.pidD[i] = mw_gui.pidD[i];
            }

            mw_params.RollPitchRate = (byte)(nRATE_rp.Value * 100);
            mw_params.YawRate = (byte)(nRATE_yaw.Value * 100);
            mw_params.DynThrPID = (byte)(nRATE_tpid.Value * 100);

            mw_params.rcExpo = (byte)(nRCExpo.Value * 100);
            mw_params.rcRate = (byte)(nRCRate.Value * 100);
            mw_params.ThrottleMID = (byte)(nTMID.Value * 100);
            mw_params.ThrottleEXPO = (byte)(nTEXPO.Value * 100);

            mw_params.PowerTrigger = (int)nPAlarm.Value;

            for (int b = 0; b < iCheckBoxItems; b++)
            {
                mw_params.activation[b] = 0;
                for (byte a = 0; a < 3; a++)
                {
                    if (aux[0, a, b].Checked) mw_params.activation[b] += (short)(1 << a);
                    if (aux[1, a, b].Checked) mw_params.activation[b] += (short)(1 << (3 + a));
                    if (aux[2, a, b].Checked) mw_params.activation[b] += (short)(1 << (6 + a));
                    if (aux[3, a, b].Checked) mw_params.activation[b] += (short)(1 << (9 + a));

                }
            }

        }

        private void write_parameters()
        {

            //Stop all timers
            timer_realtime.Stop();
            update_params();                            //update parameters object from GUI controls.

            mw_params.write_settings(serialPort);
            System.Threading.Thread.Sleep(1000);

            MSPquery(MSP_PID);
            MSPquery(MSP_RC_TUNING);
            MSPquery(MSP_IDENT);
            MSPquery(MSP_BOX);
            MSPquery(MSP_MISC);
            //Invalidate gui parameters and reread those values

            timer_realtime.Start();
            System.Threading.Thread.Sleep(500);
            bOptions_needs_refresh = true;
            update_gui();           


        }

        private void b_write_settings_Click(object sender, EventArgs e)
        {

            write_parameters();

        }

        private void update_aux_panel()
        {

            for (int i = 0; i < iCheckBoxItems; i++)
            {
                aux[0, 0, i].Checked = (mw_gui.activation[i] & (1 << 0)) == 0 ? false : true;
                aux[0, 1, i].Checked = (mw_gui.activation[i] & (1 << 1)) == 0 ? false : true;
                aux[0, 2, i].Checked = (mw_gui.activation[i] & (1 << 2)) == 0 ? false : true;
                aux[1, 0, i].Checked = (mw_gui.activation[i] & (1 << 3)) == 0 ? false : true;
                aux[1, 1, i].Checked = (mw_gui.activation[i] & (1 << 4)) == 0 ? false : true;
                aux[1, 2, i].Checked = (mw_gui.activation[i] & (1 << 5)) == 0 ? false : true;
                aux[2, 0, i].Checked = (mw_gui.activation[i] & (1 << 6)) == 0 ? false : true;
                aux[2, 1, i].Checked = (mw_gui.activation[i] & (1 << 7)) == 0 ? false : true;
                aux[2, 2, i].Checked = (mw_gui.activation[i] & (1 << 8)) == 0 ? false : true;
                aux[3, 0, i].Checked = (mw_gui.activation[i] & (1 << 9)) == 0 ? false : true;
                aux[3, 1, i].Checked = (mw_gui.activation[i] & (1 << 10)) == 0 ? false : true;
                aux[3, 2, i].Checked = (mw_gui.activation[i] & (1 << 11)) == 0 ? false : true;
            }

            for (int i = 0; i < iCheckBoxItems; i++)
            {

                aux[0, 0, i].IsHighlighted = (aux[0, 0, i].Checked == ((mw_gui.activation[i] & (1 << 0)) == 0)) ? true : false;
                aux[0, 1, i].IsHighlighted = (aux[0, 1, i].Checked == ((mw_gui.activation[i] & (1 << 1)) == 0)) ? true : false;
                aux[0, 2, i].IsHighlighted = (aux[0, 2, i].Checked == ((mw_gui.activation[i] & (1 << 2)) == 0)) ? true : false;
                aux[1, 0, i].IsHighlighted = (aux[1, 0, i].Checked == ((mw_gui.activation[i] & (1 << 3)) == 0)) ? true : false;
                aux[1, 1, i].IsHighlighted = (aux[1, 1, i].Checked == ((mw_gui.activation[i] & (1 << 4)) == 0)) ? true : false;
                aux[1, 2, i].IsHighlighted = (aux[1, 2, i].Checked == ((mw_gui.activation[i] & (1 << 5)) == 0)) ? true : false;
                aux[2, 0, i].IsHighlighted = (aux[2, 0, i].Checked == ((mw_gui.activation[i] & (1 << 6)) == 0)) ? true : false;
                aux[2, 1, i].IsHighlighted = (aux[2, 1, i].Checked == ((mw_gui.activation[i] & (1 << 7)) == 0)) ? true : false;
                aux[2, 2, i].IsHighlighted = (aux[2, 2, i].Checked == ((mw_gui.activation[i] & (1 << 8)) == 0)) ? true : false;
                aux[3, 0, i].IsHighlighted = (aux[3, 0, i].Checked == ((mw_gui.activation[i] & (1 << 9)) == 0)) ? true : false;
                aux[3, 1, i].IsHighlighted = (aux[3, 1, i].Checked == ((mw_gui.activation[i] & (1 << 10)) == 0)) ? true : false;
                aux[3, 2, i].IsHighlighted = (aux[3, 2, i].Checked == ((mw_gui.activation[i] & (1 << 11)) == 0)) ? true : false;
            }


        }

        private void update_pid_panel()
        {
            //fill out PID values from mw_gui. structure

            for (int i = 0; i < iPidItems; i++)
            {
                if (Pid[i].Pshown) { Pid[i].Pfield.Value = (decimal)mw_gui.pidP[i] / Pid[i].Pprec; Pid[i].Pfield.BackColor = Color.White; }
                if (Pid[i].Ishown) { Pid[i].Ifield.Value = (decimal)mw_gui.pidI[i] / Pid[i].Iprec; Pid[i].Ifield.BackColor = Color.White; }
                if (Pid[i].Dshown) { Pid[i].Dfield.Value = (decimal)mw_gui.pidD[i] / Pid[i].Dprec; Pid[i].Dfield.BackColor = Color.White; }

            }

            nRATE_rp.Value = (decimal)mw_gui.RollPitchRate / 100;
            nRATE_rp.BackColor = Color.White;
            nRATE_yaw.Value = (decimal)mw_gui.YawRate / 100;
            nRATE_yaw.BackColor = Color.White;
            nRATE_tpid.Value = (decimal)mw_gui.DynThrPID / 100;
            nRATE_tpid.BackColor = Color.White;

            trackbar_RC_Expo.Value = mw_gui.rcExpo;
            nRCExpo.Value = (decimal)mw_gui.rcExpo / 100;
            nRCExpo.BackColor = Color.White;
            trackbar_RC_Rate.Value = mw_gui.rcRate;
            nRCRate.Value = (decimal)mw_gui.rcRate / 100;
            nRCRate.BackColor = Color.White;

            rc_expo_control1.SetRCExpoParameters((double)mw_gui.rcRate / 100, (double)mw_gui.rcExpo / 100);

            nTEXPO.Value = (decimal)mw_gui.ThrottleEXPO / 100;
            nTEXPO.BackColor = Color.White;
            trackBar_T_EXPO.Value = mw_gui.ThrottleEXPO;
            nTMID.Value = (decimal)mw_gui.ThrottleMID / 100;
            nTMID.BackColor = Color.White;
            trackBar_T_MID.Value = mw_gui.ThrottleMID;
            throttle_expo_control1.SetRCExpoParameters((double)mw_gui.ThrottleMID/100, (double)mw_gui.ThrottleEXPO / 100,mw_gui.rcThrottle);

            nPAlarm.Value = mw_gui.powerTrigger;
            nPAlarm.BackColor = Color.White;



        }

        private void update_gui_from_params()
        {
            for (int i = 0; i < iCheckBoxItems; i++)
            {
                aux[0, 0, i].Checked = (mw_params.activation[i] & (1 << 0)) == 0 ? false : true;
                aux[0, 1, i].Checked = (mw_params.activation[i] & (1 << 1)) == 0 ? false : true;
                aux[0, 2, i].Checked = (mw_params.activation[i] & (1 << 2)) == 0 ? false : true;
                aux[1, 0, i].Checked = (mw_params.activation[i] & (1 << 3)) == 0 ? false : true;
                aux[1, 1, i].Checked = (mw_params.activation[i] & (1 << 4)) == 0 ? false : true;
                aux[1, 2, i].Checked = (mw_params.activation[i] & (1 << 5)) == 0 ? false : true;
                aux[2, 0, i].Checked = (mw_params.activation[i] & (1 << 6)) == 0 ? false : true;
                aux[2, 1, i].Checked = (mw_params.activation[i] & (1 << 7)) == 0 ? false : true;
                aux[2, 2, i].Checked = (mw_params.activation[i] & (1 << 8)) == 0 ? false : true;
                aux[3, 0, i].Checked = (mw_params.activation[i] & (1 << 9)) == 0 ? false : true;
                aux[3, 1, i].Checked = (mw_params.activation[i] & (1 << 10)) == 0 ? false : true;
                aux[3, 2, i].Checked = (mw_params.activation[i] & (1 << 11)) == 0 ? false : true;
            }
            //fill out PID values from mw_gui. structure

            for (int i = 0; i < iPidItems; i++)
            {
                if (Pid[i].Pshown) { Pid[i].Pfield.Value = (decimal)mw_params.pidP[i] / Pid[i].Pprec; }
                if (Pid[i].Ishown) { Pid[i].Ifield.Value = (decimal)mw_params.pidI[i] / Pid[i].Iprec; }
                if (Pid[i].Dshown) { Pid[i].Dfield.Value = (decimal)mw_params.pidD[i] / Pid[i].Dprec; }

            }
            
            nRATE_rp.Value = (decimal)mw_params.RollPitchRate / 100;
            nRATE_yaw.Value = (decimal)mw_params.YawRate / 100;
            nRATE_tpid.Value = (decimal)mw_params.DynThrPID / 100;

            trackbar_RC_Expo.Value = mw_params.rcExpo;
            nRCExpo.Value = (decimal)mw_params.rcExpo / 100;
            trackbar_RC_Rate.Value = mw_params.rcRate;
            nRCRate.Value = (decimal)mw_params.rcRate / 100;
            rc_expo_control1.SetRCExpoParameters((double)mw_params.rcRate / 100, (double)mw_params.rcExpo / 100);

            nTEXPO.Value = (decimal)mw_params.ThrottleEXPO / 100;
            trackBar_T_EXPO.Value = mw_params.ThrottleEXPO;
            nTMID.Value = (decimal)mw_params.ThrottleMID / 100;
            trackBar_T_MID.Value = mw_params.ThrottleMID;
            throttle_expo_control1.SetRCExpoParameters((double)mw_params.ThrottleMID / 100, (double)mw_params.ThrottleEXPO / 100,mw_gui.rcThrottle);

            nPAlarm.Value = mw_params.PowerTrigger;

        }

        private void mainGUI_FormClosing(object sender, FormClosingEventArgs e)
        {

            timer_realtime.Stop();                       //Stop timer(s), whatever it takes
            bkgWorker.CancelAsync();
            System.Threading.Thread.Sleep(500);         //Wait for 1 cycle to let backgroundworker finish it's last job.
            if (isConnected) { serialPort.Close(); }

        }

        private void b_about_Click(object sender, EventArgs e)
        {
            frmAbout aboutform = new frmAbout();
            aboutform.sVersionLabel = sVersion;
            aboutform.sFcVersionLabel = "MultiWii version " + sRelName;
            aboutform.ShowDialog();
        }

        private void attitudeIndicatorInstrumentControl1_Click(object sender, EventArgs e)
        {
            Point c = System.Windows.Forms.Cursor.Position;
            Point p = attitudeIndicatorInstrumentControl1.PointToClient(c);

            attitudeIndicatorInstrumentControl1.ToggleArtificalHorizonType();

        }

        private void MSPquery(int command)
        {
            byte c = 0;
            byte[] o;
            o = new byte[10];
            // with checksum 
            o[0] = (byte)'$';
            o[1] = (byte)'M';
            o[2] = (byte)'<';
            o[3] = (byte)0; c ^= o[3];       //no payload 
            o[4] = (byte)command; c ^= o[4];
            o[5] = (byte)c;
            serialPort.Write(o, 0, 6);
            

        }

        private void MSPqueryWP(int wp)
        {
            byte c = 0;
            byte[] o;
            o = new byte[10];
            // with checksum 
            o[0] = (byte)'$';
            o[1] = (byte)'M';
            o[2] = (byte)'<';
            o[3] = (byte)1; c ^= o[3];       //one byte payload
            o[4] = (byte)MSP_WP; c ^= o[4];
            o[5] = (byte)wp; c ^= o[5];
            o[6] = (byte)c;
            serialPort.Write(o, 0, 7);
        }

        private int decimals(int prec)
        {
            if (prec == 1) return (0);
            if (prec == 10) return (1);
            if (prec == 100) return (2);
            if (prec == 1000) return (3);

            return (0);
        }

        private void trackBar_T_MID_Scroll(object sender, EventArgs e)
        {
            nTMID.Value = (decimal)trackBar_T_MID.Value / 100;
            throttle_expo_control1.SetRCExpoParameters((double)nTMID.Value, (double)nTEXPO.Value,mw_gui.rcThrottle);
        }

        private void trackBar_T_EXPO_Scroll(object sender, EventArgs e)
        {
            nTEXPO.Value = (decimal)trackBar_T_EXPO.Value / 100;
            throttle_expo_control1.SetRCExpoParameters((double)nTMID.Value, (double)nTEXPO.Value, mw_gui.rcThrottle);
        }

        private void nTMID_ValueChanged(object sender, EventArgs e)
        {
            trackBar_T_MID.Value = (int)(nTMID.Value * 100);
            throttle_expo_control1.SetRCExpoParameters((double)nTMID.Value, (double)nTEXPO.Value, mw_gui.rcThrottle);
            if ((int)(nTMID.Value * 100) != mw_gui.ThrottleMID)
            {
                nTMID.BackColor = Color.FromArgb(123, 194, 205);
            }
            else
            {
                nTMID.BackColor = Color.White;
            }

        }

        private void nTEXPO_ValueChanged(object sender, EventArgs e)
        {
            trackBar_T_EXPO.Value = (int)(nTEXPO.Value * 100);
            throttle_expo_control1.SetRCExpoParameters((double)nTMID.Value, (double)nTEXPO.Value, mw_gui.rcThrottle);
            if ((int)(nTEXPO.Value * 100) != mw_gui.ThrottleEXPO)
            {
                nTEXPO.BackColor = Color.FromArgb(123, 194, 205);
            }
            else
            {
                nTEXPO.BackColor = Color.White;
            }

        }     

        #region ValueChangedEvents

        private void pfield_valuechange(object sender, EventArgs e)
        {
            for (int i = 0; i < iPidItems; i++)
            {
                if (Pid[i].Pshown)
                {
                    if (Pid[i].Pfield.Value != (decimal)mw_gui.pidP[i] / Pid[i].Pprec)
                    {
                        Pid[i].Pfield.BackColor = Color.FromArgb(123, 194, 205);
                    }
                    else
                    {
                        Pid[i].Pfield.BackColor = Color.White;
                    }
                }
            }
        
        }

        private void ifield_valuechange(object sender, EventArgs e)
        {
            for (int i = 0; i < iPidItems; i++)
            {
                if (Pid[i].Ishown)
                {

                    if (Pid[i].Ifield.Value != (decimal)mw_gui.pidI[i] / Pid[i].Iprec)
                    {
                        Pid[i].Ifield.BackColor = Color.FromArgb(123, 194, 205);
                    }
                    else
                    {
                        Pid[i].Ifield.BackColor = Color.White;
                    }
                }
            }
        }

        private void dfield_valuechange(object sender, EventArgs e)
        {
            for (int i = 0; i < iPidItems; i++)
            {
                if (Pid[i].Dshown)
                {
                    if (Pid[i].Dfield.Value != (decimal)mw_gui.pidD[i] / Pid[i].Dprec)
                    {
                        Pid[i].Dfield.BackColor = Color.FromArgb(123, 194, 205);
                    }
                    else
                    {
                        Pid[i].Dfield.BackColor = Color.White;
                    }
                }
            }
        }

        private void nRATE_rp_ValueChanged(object sender, EventArgs e)
        {
            if (nRATE_rp.Value != (decimal)mw_gui.RollPitchRate / 100) { nRATE_rp.BackColor = Color.FromArgb(123, 194, 205); }
            else { nRATE_rp.BackColor = Color.White; }
        }

        private void nRATE_yaw_ValueChanged(object sender, EventArgs e)
        {
            if (nRATE_yaw.Value != (decimal)mw_gui.YawRate / 100) { nRATE_yaw.BackColor = Color.FromArgb(123, 194, 205); }
            else { nRATE_yaw.BackColor = Color.White; }
        }

        private void nRATE_tpid_ValueChanged(object sender, EventArgs e)
        {
            if (nRATE_tpid.Value != (decimal)mw_gui.DynThrPID / 100) { nRATE_tpid.BackColor = Color.FromArgb(123, 194, 205); }
            else { nRATE_tpid.BackColor = Color.White; }
        }

        private void nPAlarm_ValueChanged(object sender, EventArgs e)
        {
            if (nPAlarm.Value != (decimal)mw_gui.powerTrigger) { nPAlarm.BackColor = Color.FromArgb(123, 194, 205); }
            else { nPAlarm.BackColor = Color.White; }
        }

        private void trackbar_RC_Expo_Scroll(object sender, EventArgs e)
        {
            nRCExpo.Value = (decimal)trackbar_RC_Expo.Value / 100;
            rc_expo_control1.SetRCExpoParameters((double)nRCRate.Value, (double)nRCExpo.Value);
        }

        private void nRCExpo_ValueChanged(object sender, EventArgs e)
        {
            trackbar_RC_Expo.Value = (int)(nRCExpo.Value * 100);
            rc_expo_control1.SetRCExpoParameters((double)nRCRate.Value, (double)nRCExpo.Value);

            if ((int)(nRCExpo.Value * 100) != mw_gui.rcExpo)
            {
                nRCExpo.BackColor = Color.FromArgb(123, 194, 205);
            }
            else
            {
                nRCExpo.BackColor = Color.White;
            }


        }

        private void trackbar_RC_Rate_Scroll(object sender, EventArgs e)
        {
            nRCRate.Value = (decimal)trackbar_RC_Rate.Value / 100;
            rc_expo_control1.SetRCExpoParameters((double)nRCRate.Value, (double)nRCExpo.Value);

        }

        private void nRCRate_ValueChanged(object sender, EventArgs e)
        {
            trackbar_RC_Rate.Value = (int)(nRCRate.Value * 100);
            rc_expo_control1.SetRCExpoParameters((double)nRCRate.Value, (double)nRCExpo.Value);
            if ((int)(nRCRate.Value * 100) != mw_gui.rcRate)
            {
                nRCRate.BackColor = Color.FromArgb(123, 194, 205);
            }
            else
            {
                nRCRate.BackColor = Color.White;
            }

        }

        #endregion

    }

}
