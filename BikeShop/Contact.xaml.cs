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
    /// ContextPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ContextPage : Page
    {
        public ContextPage()
        {
            InitializeComponent();
        }

        public void TestMethod()
        {
            Human h = new Human();
            h.FirstName = "JongHun";
            h.HasDrivingLicense = true;

            Car car = new Car();
            car.Speed = 30.0d;
            car.Color = Colors.Blue;
            car.Driver = h;
        }
    }
}
