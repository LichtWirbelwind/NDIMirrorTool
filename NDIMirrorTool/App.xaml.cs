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
        // コンソールにヘルプを表示するために追加
        [System.Runtime.InteropServices.DllImport("Kernel32.dll")]
        public static extern bool AttachConsole(int processId);
        [System.Runtime.InteropServices.DllImport("Kernel32.dll")]
        public static extern bool FreeConsole();

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
                    case "--name":
                    case "/t":
                    case "-t":
                    case "--title":
                        name_flag = true;
                        break;
                    case "-h":
                    case "--help":
                    case "/?":
                    case "-?":
                        if (AttachConsole(-1) == false)
                        {
                            return;
                        }

                        Console.WriteLine("usage: NDIMirrorTool [OPTIONS] [TITLE]");
                        Console.WriteLine("");
                        Console.WriteLine("General options:");
                        Console.WriteLine("  -h, --help, -?, /?");
                        Console.WriteLine("    Show this help message and exit.");
                        Console.WriteLine("  -t, --title, /t, -n, --name, /n");
                        Console.WriteLine("    Change runner name(title).");

                        FreeConsole();

                        Application.Current.Shutdown();
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
