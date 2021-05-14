using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NDI_Mirror_Tool
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            bool name_flag = false;
            this.Properties["RunnerName"] = "走者名";

            foreach (string arg in e.Args)
            {
                switch (arg)
                {
                    case "/n":
                    case "-n":
                    case "--n":
                    case "/t":
                    case "-t":
                    case "--t":
                        name_flag = true;
                        break;
                    default:
                        if (name_flag == true)
                        {
                            name_flag = false;
                            //this.Properties["RunnerName"] = arg + " 0.9.0.0";
                            this.Properties["RunnerName"] = arg;
                        }
                        break;
                }
            }
        }
    }
}
