using System;

namespace ArduinoMonitoringWPFApp.Base
{
    public class SensorData
    {
        public DateTime Date { get; set; }
        public ushort Value { get; set; }

        public SensorData(DateTime date, ushort value) //생성자
        {
            Date = date;
            Value = value;
        }
    }
}
