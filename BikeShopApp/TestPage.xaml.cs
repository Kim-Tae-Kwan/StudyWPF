using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using BusinessLogic;
namespace BikeShopApp
{
    /// <summary>
    /// TestPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TestPage : Page
    {
        public TestPage()
        {
            InitializeComponent();
            InitListBox();
        }

        private void InitListBox()
        {

            Random rand = new Random();
            string[] names = { "태관", "승재", "상근", "정윤", "유진", "명건" };

            List<Car> lists = new List<Car>();

            for (int i = 0; i < 10; i++)
            {   
                byte red = (byte)(i % 3 == 0 ? 255 : (i * 5) % 255);
                byte green = 0;
                byte blue = (byte)(i % 3 == 0 ? (i * 5) % 255 : 255);

                int index = rand.Next(names.Length); // 랜덤인덱스

                lists.Add(new Car()
                {
                    Speed = i * 30,
                    Color = Color.FromRgb(red, green, blue),
                    Driver = new Human { Name = names[index], HasDrivingLicense = true }
                });
            }
            //LstCar.DataContext = CboCar.DataContext = lists;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Car car = new Car();
            car.Speed = 100;
            car.Color = Colors.Blue;
            car.Driver = new Human { Name = "Ted", HasDrivingLicense = true };

            //this.DataContext = car;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello Wolrd");
        }
    }
}
