using Caliburn.Micro;
using System;
using System.Threading;
using System.IO.Ports;
using System.Windows;
using ArduinoMonitoringWPFApp.Base;
using System.Collections.Generic;
using System.Windows.Media.Animation;
using LiveCharts;
using MySql.Data.MySqlClient;
using MvvmDialogs;



/*
 3. 그래프 줌 버튼
 */


namespace ArduinoMonitoringWPFApp.ViewModels
{
    public class MainViewModel : Conductor<object>
    {
        #region 속성 영역
        readonly IWindowManager windowManager; //팝업창
        readonly IDialogService dialogService;

        string strConnString = "Data Source=localhost;Port=3306;Database=iot_sensordata;uid=root;password=mysql_p@ssw0rd";

        string strQuery = "INSERT INTO sensordatatbl " +
                    " (Date, Value) " +
                    " VALUES " +
                    " (@Date, @Value) ";

        public bool IsSimulation { get; set; }
        SerialPort serial;
        private short maxPhotoVal = 1023;
        List<SensorData> photoDatas = new List<SensorData>();

        bool isConn;
        public bool IsConn
        {
            get => isConn;
            set
            {
                isConn = value;
                NotifyOfPropertyChange(() => CanBtnConnect);
                NotifyOfPropertyChange(() => CanBtnDisconnect);
            }
        }

        Timer timer { get; set; }
        Random rand = new Random();
        public BindableCollection<string> CboSerialPort { get; set; }

        string connTime;
        public string ConnTime
        {
            get => connTime;
            set
            {
                connTime = value;
                NotifyOfPropertyChange(() => ConnTime);
            }

        }

        string sensorCount;
        public string SensorCount
        {
            get => sensorCount;
            set
            {
                sensorCount = value;
                NotifyOfPropertyChange(() => SensorCount);
            }
        }

        int pgbPhotoRegistor;
        public int PgbPhotoRegistor
        {
            get => pgbPhotoRegistor;
            set
            {
                pgbPhotoRegistor = value;
                NotifyOfPropertyChange(() => PgbPhotoRegistor);
            }
        }

        string lblPhotoRegistor;
        public string LblPhotoRegistor
        {
            get => lblPhotoRegistor;
            set
            {
                lblPhotoRegistor = value;
                NotifyOfPropertyChange(() => LblPhotoRegistor);
            }
        }

        string rtbLog;
        public string RtbLog
        {
            get => rtbLog;
            set
            {
                rtbLog = value;
                NotifyOfPropertyChange(() => RtbLog);
            }
        }

        string btnPortValue;
        public string BtnPortValue
        {
            get => btnPortValue;
            set
            {
                btnPortValue = value;
                NotifyOfPropertyChange(() => BtnPortValue);
            }
        }

        string selectedPort;
        public string SelectedPort
        {
            get => selectedPort;
            set
            {
                
                selectedPort = value;
                NotifyOfPropertyChange(() => SelectedPort);
                NotifyOfPropertyChange(() => CanBtnConnect);
            }
        }

        ChartValues<double> lineValues;
        public ChartValues<double> LineValues
        {
            get => lineValues;
            set
            {
                lineValues = value;
                NotifyOfPropertyChange(() => LineValues);
            }
        }

        
        #endregion

        #region 생성자 영역

        public MainViewModel(IWindowManager windowManager, IDialogService dialogService)
        {
            this.windowManager = windowManager;
            this.dialogService = dialogService;
            InitComboBox();
            ConnTime = "연결시간 :";
            LineValues = new ChartValues<double>();
            SelectedPort = "선택";
            BtnPortValue = "PORT";
        }

        private void InitComboBox()
        {
            CboSerialPort = new BindableCollection<string>();
            foreach (var item in SerialPort.GetPortNames())
            {
                CboSerialPort.Add(item);
            }
        }
        #endregion

        public void ProgramExit()
        {
            Environment.Exit(0);
        }
        

        private void DisplayValue(string sVal)
        {
            try
            {
                ushort v = ushort.Parse(sVal);
                if (v < 0 || v > maxPhotoVal)
                    return;

                SensorData data = new SensorData(DateTime.Now, v);
                photoDatas.Add(data);

                SensorCount = photoDatas.Count.ToString();
                PgbPhotoRegistor = v;
                LblPhotoRegistor = v.ToString();
                string item = $"{photoDatas.Count} {DateTime.Now.ToString("yy-MM-dd hh:mm:ss")}\t{v}";
                RtbLog+=$"{item}\n";

                
                LineValues.Add(v);



                if (IsSimulation == false)
                {
                    BtnPortValue = $"{serial.PortName}\n{sVal}";
                    InsertDataToDB(data);
                }
                else
                    BtnPortValue = $"{sVal}";


            }
            catch (Exception ex)
            {
                RtbLog+=($"Error : {ex.Message}\n");
            }
        }

        private void InsertDataToDB(SensorData data)
        {
            using (MySqlConnection conn = new MySqlConnection(strConnString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlParameter paramDate = new MySqlParameter("@Date", MySqlDbType.DateTime)
                {
                    Value = data.Date
                };
                cmd.Parameters.Add(paramDate);
                MySqlParameter paramValue = new MySqlParameter("@Value", MySqlDbType.Int32)
                {
                    Value = data.Value
                };
                cmd.Parameters.Add(paramValue);
                cmd.ExecuteNonQuery();
            }
        } //DB 데이터 입력


        public bool CanBtnConnect
        {
            get =>!((SelectedPort != "선택") && (IsConn==true));
            set
            {
                NotifyOfPropertyChange(() => CanBtnDisconnect);
            }
        }

        public void BtnConnect()
        {
            if (IsSimulation)
            {
                MessageBox.Show("시뮬레이션을 중지하세요.");
                return;
            }
            else if (string.IsNullOrEmpty(SelectedPort) || SelectedPort == "선택")
            {
                MessageBox.Show("포트를 선택하세요.");
                return;
            }
            else 
            {
                IsConn = true;
                string portNum = SelectedPort;
                serial = new SerialPort(portNum);
                serial.DataReceived += Serial_DataReceived;
                serial.Open();

                ConnTime = $"연결시간 : {DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}";
                //BtnConnect.IsEnabled = false;
                //BtnDisconnect.IsEnabled = true;
            }
        }

        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string sVal = serial.ReadLine();
            DisplayValue(sVal);
        }

        public bool CanBtnDisconnect
        {
            get=> !CanBtnConnect;
        }

        public void BtnDisconnect()
        {
            if (serial != null)
            {
                IsConn = false;
                serial.Close();
                SelectedPort = CboSerialPort[0];
            }
            else
                MessageBox.Show("포트를 연결하세요.");
        }

        public void SimStart()
        {
            IsSimulation = true;
            timer = new Timer(TickCallBack);
            timer.Change(1000, 1000);
        }

        private void TickCallBack(object state)
        {
            ushort value = (ushort)rand.Next(1, 1024);
            DisplayValue(value.ToString());
        }

        public void SimStop()
        {
            timer.Dispose();
            IsSimulation = false;
        }

        public void Info()
        {
            InfoViewModel dialogVM = new InfoViewModel();
            bool? success = windowManager.ShowDialog(dialogVM);
        }
    }
}
