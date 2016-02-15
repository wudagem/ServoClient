using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;

namespace ServoClient
{
    public partial class ServoClient : Form
    {
        const int EXPECTED_PACKET_SIZE = 24;
        private bool PerfDataStarted = false;
        private bool StepStarted = false;

        SerialPort sp = new SerialPort();
        String SelectedCommPort;
        byte[] buffer = new byte[4096];
        int offset = 0;
        int count = 0;

        Queue<int> step_data = new Queue<int>(1000);
        Queue<int> quad_data = new Queue<int>(1000);
        Queue<int> error_data = new Queue<int>(1000);
        Queue<int> x_points = new Queue<int>(1000);
        
        ChartArea ca = new ChartArea();
        Series step = new Series();
        Series quad = new Series();
        Series error = new Series();

        UInt16 LastQuadCount, LastStepCount, QuadCount, StepCount;
        Int16 Error, LastError, Kp, Ki, Kd, Integral_Term, ErrorMax;
        UInt16 PWMPeriod, IntMax;
        Int32 PIDValue;

        public ServoClient()
        {
            InitializeComponent();
            connectToolStripMenuItem.Enabled = false;
            CommPortRefreshList(null, null);
            Chart1.ChartAreas.Add(ca);
            step.Name = "Step";
            quad.Name = "Encoder";
            error.Name = "Error";
            step.ChartType = SeriesChartType.FastLine;
            quad.ChartType = SeriesChartType.FastLine;
            error.ChartType = SeriesChartType.FastLine;
            step.Points.DataBindXY(step_data, x_points);
            quad.Points.DataBindXY(quad_data, x_points);
            error.Points.DataBindXY(error_data, x_points);            
            Chart1.Series.Add(error);
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connectToolStripMenuItem.Text == "Connect")
            {
                if (SerialPort.GetPortNames().Contains(SelectedCommPort))
                {
                    try
                    {
                        sp.PortName = SelectedCommPort;
                        sp.BaudRate = 115200;
                        sp.Open();
                        sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
                        connectToolStripMenuItem.Text = "Disconnect";
                        btnGetConfig.Enabled = true;
                        btnSetConfig.Enabled = true;
                        btnStartData.Enabled = true;
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                sp.Close();
                connectToolStripMenuItem.Text = "Connect";
            }
            
        }

        delegate void UpdateGraphCallback();

        void UpdateGraph()
        {
            try
            {

                if (this.Chart1.InvokeRequired)
                    this.Invoke(new UpdateGraphCallback(UpdateGraph));
                else
                {
                    step_data.Enqueue(StepCount);
                    quad_data.Enqueue(QuadCount);
                    error_data.Enqueue(Error);
                    x_points.Enqueue(count);
                    // keep the size of the data to 1000 points
                    while (step_data.Count() > 1000)
                    {
                        step_data.Dequeue();
                        quad_data.Dequeue();
                        error_data.Dequeue();
                        x_points.Dequeue();
                    }                    
                    count++;
                }
            } catch (Exception ex) {
                return;
            }
        }

        delegate void UpdateConfigCallback();

        void UpdateConfig()
        {
            try
            {
                if (this.TxtBoxKp.InvokeRequired)
                    this.Invoke(new UpdateConfigCallback(UpdateConfig));
                else
                {
                    TxtBoxKp.Text = Kp.ToString();
                    TxtBoxKi.Text = Ki.ToString();
                    TxtBoxKd.Text = Kd.ToString();
                    TxtBoxErrorMax.Text = ErrorMax.ToString();
                    TxtBoxPWMPeriod.Text = PWMPeriod.ToString();
                    TxtBoxIntMax.Text = IntMax.ToString();

                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int num_read = sp.Read(buffer, offset, sp.BytesToRead);
            offset += num_read;
            
            while (buffer[0] <= offset) // first byte in the buffer should be a packet size.
            {
                int packet_size = 0;
                // Handle a packet
                switch (buffer[1])
                {
                    case Constants.PACKET_TYPE_PERF_DATA:
                        packet_size = Constants.PACKET_SIZE_PERF_DATA;
                        LastQuadCount = (UInt16)((buffer[3] << 8) + buffer[2]);
                        LastStepCount = (UInt16)((buffer[5] << 8) + buffer[4]);
                        Error = (Int16)((buffer[7] << 8) + buffer[6]);
                        LastError = (Int16)((buffer[9] << 8) + buffer[8]);
                        Integral_Term = (Int16)((buffer[11] << 8) + buffer[10]);
                        QuadCount = (UInt16)((buffer[13] << 8) + buffer[12]);
                        StepCount = (UInt16)((buffer[15] << 8) + buffer[14]);
                        PIDValue = (Int32)((buffer[19] << 24) + (buffer[18] << 16) + (buffer[17] << 8) + buffer[16]);

                        UpdateGraph();
                        break;
                    case Constants.PACKET_TYPE_CONFIG:
                        packet_size = Constants.PACKET_SIZE_CONFIG;
                        Kp = (Int16)((buffer[3] << 8) + buffer[2]);
                        Ki = (Int16)((buffer[5] << 8) + buffer[4]);
                        Kd = (Int16)((buffer[7] << 8) + buffer[6]);
                        ErrorMax = (Int16)((buffer[9] << 8) + buffer[8]);
                        PWMPeriod = (UInt16)((buffer[11] << 8) + buffer[10]);
                        IntMax = (UInt16)((buffer[13] << 8) + buffer[12]);

                        UpdateConfig();
                        break;
                    default:
                        break;
                }

                offset -= packet_size;
                // Shift the contents of the array forward
                for (int i = 0; i < (offset); i++ ) {
                    buffer[i] = buffer[i + packet_size];
                }
                
            }
        }

        void CommPortRefreshList(object sender, EventArgs e)
        {
            commPortToolStripMenuItem.DropDownItems.Clear();
            foreach (string s in SerialPort.GetPortNames())
            {
                ToolStripMenuItem a = new ToolStripMenuItem(s);
                a.Click += CommPortSelector_Click;
                commPortToolStripMenuItem.DropDownItems.Add(a);
            }
            ToolStripMenuItem b = new ToolStripMenuItem("Refresh Ports");
            b.Click += CommPortRefreshList;
            commPortToolStripMenuItem.DropDownItems.Add(b);
            SelectedCommPort = "";
            connectToolStripMenuItem.Enabled = false;
        }

        void CommPortSelector_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem i in commPortToolStripMenuItem.DropDownItems)
            {
                i.Checked = false;
            }
            ((ToolStripMenuItem)sender).Checked = true;
            SelectedCommPort = ((ToolStripMenuItem)sender).Text;
            connectToolStripMenuItem.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sp.IsOpen)
            {
                sp.Close();    
            }
        }

        private void btnGetConfig_Click(object sender, EventArgs e)
        {
            if (sp.IsOpen) {
                byte[] packet = new byte[Constants.PACKET_SIZE_GET_CONFIG];
                packet[0] = Constants.PACKET_SIZE_GET_CONFIG;
                packet[1] = Constants.PACKET_TYPE_GET_CONFIG;
                sp.Write(packet, 0, Constants.PACKET_SIZE_GET_CONFIG);
            }
        }

        private void btnSetConfig_Click(object sender, EventArgs e)
        {
            if (sp.IsOpen)
            {
                byte[] packet = new byte[Constants.PACKET_SIZE_SET_CONFIG];
                packet[0] = Constants.PACKET_SIZE_SET_CONFIG;
                packet[1] = Constants.PACKET_TYPE_SET_CONFIG;
                short _Kp, _Ki, _Kd, _ErrorMax, _PWMPeriod, _IntMax;
                if (Int16.TryParse(TxtBoxKp.Text, out _Kp))
                {
                    packet[3] = (byte)(_Kp >> 8);
                    packet[2] = (byte)(_Kp & 0xFF);
                    if (Int16.TryParse(TxtBoxKi.Text, out _Ki))
                    {
                        packet[5] = (byte)(_Ki >> 8);
                        packet[4] = (byte)(_Ki & 0xFF);
                        if (Int16.TryParse(TxtBoxKd.Text, out _Kd))
                        {
                            packet[7] = (byte)(_Kd >> 8);
                            packet[6] = (byte)(_Kd & 0xFF);
                            if (Int16.TryParse(TxtBoxErrorMax.Text, out _ErrorMax))
                            {
                                packet[9] = (byte)(_ErrorMax >> 8);
                                packet[8] = (byte)(_ErrorMax & 0xFF);
                                if (Int16.TryParse(TxtBoxPWMPeriod.Text, out _PWMPeriod))
                                {
                                    packet[11] = (byte)(_PWMPeriod >> 8);
                                    packet[10] = (byte)(_PWMPeriod & 0xFF);
                                    if (Int16.TryParse(TxtBoxIntMax.Text, out _IntMax))
                                    {
                                        packet[13] = (byte)(_IntMax >> 8);
                                        packet[12] = (byte)(_IntMax & 0xFF);
                                        sp.Write(packet, 0, Constants.PACKET_SIZE_SET_CONFIG);
                                    }
                                }
                            }
                        }
                    }
                }
                
                
            }
        }

        private void btnStartData_Click(object sender, EventArgs e)
        {
            if (PerfDataStarted == false)
            {
                if (sp.IsOpen)
                {
                    byte[] packet = new byte[Constants.PACKET_SIZE_START_PERF_DATA];
                    packet[0] = Constants.PACKET_SIZE_START_PERF_DATA;
                    packet[1] = Constants.PACKET_TYPE_START_PERF_DATA;
                    sp.Write(packet, 0, Constants.PACKET_SIZE_START_PERF_DATA);
                    btnStartData.Text = "Stop Data";
                    PerfDataStarted = true;
                    ChartRefreshTimer.Enabled = true;
                }
            }
            else
            {
                if (sp.IsOpen)
                {
                    byte[] packet = new byte[Constants.PACKET_SIZE_STOP_PERF_DATA];
                    packet[0] = Constants.PACKET_SIZE_STOP_PERF_DATA;
                    packet[1] = Constants.PACKET_TYPE_STOP_PERF_DATA;
                    sp.Write(packet, 0, Constants.PACKET_SIZE_STOP_PERF_DATA);
                    btnStartData.Text = "Start Data";
                    PerfDataStarted = false;
                    ChartRefreshTimer.Enabled = false;
                }
            }
        }

        private void cbQuad_CheckedChanged(object sender, EventArgs e)
        {
            if (cbQuad.Checked)
            {
                Chart1.Series.Add(quad);
            }
            else
            {
                Chart1.Series.Remove(quad);
            }
            
        }

        private void cbStep_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStep.Checked)
            {
                Chart1.Series.Add(step);
            }
            else
            {
                Chart1.Series.Remove(step);
            }
        }

        private void cbError_CheckedChanged(object sender, EventArgs e)
        {
            if (cbError.Checked)
            {
                Chart1.Series.Add(error);
            }
            else
            {
                Chart1.Series.Remove(error);
            }
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            step_data.Clear();
            quad_data.Clear();
            error_data.Clear();
            x_points.Clear();
            step.Points.DataBindXY(x_points, step_data);
            quad.Points.DataBindXY(x_points, quad_data);
            error.Points.DataBindXY(x_points, error_data);            
            count = 0;
        }

        private void ChartRefreshTimer_Tick(object sender, EventArgs e)
        {
            step.Points.DataBindXY(x_points, step_data);
            quad.Points.DataBindXY(x_points, quad_data);
            error.Points.DataBindXY(x_points, error_data);            
        }
    }
}
