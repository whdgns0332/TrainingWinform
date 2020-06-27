﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BikeShop
{
    /// <summary>
    /// TestPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TestPage : Page
    {
        public TestPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
        }

        private void Init()
        {
            List<Car> cars = new List<Car>();
            for (int i = 0; i < 10; i++)
            {
                /*
                Car car = new Car();
                car.Speed = i * 10;
                cars.Add(car);
                */

                cars.Add(new Car()
                {
                    Speed = i * 10,
                    Color = Color.FromRgb((byte)(255/(i+1)), (byte)(255 / (i + 1)), (byte)(255 / (i + 1)))
                });
            }
            this.DataContext = cars;
        }
    }
}
