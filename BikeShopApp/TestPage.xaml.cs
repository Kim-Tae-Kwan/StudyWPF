using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
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
            List<Car> lists = new List<Car>();
            for (int i = 0; i < 10; i++)
            {
                lists.Add(new Car()
                {
                    Speed = i * 30
                });
            }
            LstCar.DataContext = lists;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Car car = new Car();
            car.Speed = 100;
            car.Color = Colors.Blue;
            car.Driver = new Human { Name = "Ted", HasDrivingLicense = true };

            //this.DataContext = car;
        }
    }
}
