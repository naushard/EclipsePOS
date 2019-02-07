using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace EclipsePOS.WPF.PosWorkBench
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            PosWorkBenchBootstrapper bootStrapper = new PosWorkBenchBootstrapper();
            bootStrapper.Run();
        }


    }
}
