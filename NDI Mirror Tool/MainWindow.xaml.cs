using NewTek;
using NewTek.NDI;
using System;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace NDI_Mirror_Tool
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Title = Application.Current.Properties["RunnerName"].ToString();

            // Not required, but "correct". (see the SDK documentation)
            if (!NDIlib.initialize())
            {
                // Cannot run NDI. Most likely because the CPU is not sufficient (see SDK documentation).
                // you can check this directly with a call to NDIlib.is_supported_CPU()
                if (!NDIlib.is_supported_CPU())
                {
                    MessageBox.Show("CPU unsupported.");
                }
                else
                {
                    // not sure why, but it's not going to run
                    MessageBox.Show("Cannot run NDI.");
                }

                // we can't go on
                Close();
            }

            if (ReceiveViewer != null)
            {
                ReceiveViewer.IsVideoEnabled = true;
                ReceiveViewer.IsAudioEnabled = false;
            }
            // 起動時に入力しないよう変更
            //InputBox.Visibility = Visibility.Visible;
            // ListBoxの一番上を選択しておく
            //if (SourcesSelector.Items.Count > 0)
            //{
            //    SourcesSelector.SelectedItem = SourcesSelector.Items[0];
            //}
        }

        // properly dispose of the unmanaged objects
        protected override void OnClosed(EventArgs e)
        {
            if (_routerInstance != null)
                _routerInstance.Dispose();

            if (ReceiveViewer != null)
                ReceiveViewer.Dispose();

            if (_findInstance != null)
                _findInstance.Dispose();

            base.OnClosed(e);
        }

        // This will find NDI sources on the network.
        // Continually updated as new sources arrive.
        // Note that this example does see local sources (new Finder(true))
        // This is for ease of testing, but normally is not needed in released products.
        public Finder FindInstance
        {
            get { return _findInstance; }
        }
        private readonly Finder _findInstance = new Finder(true);

        private void Preview_Checked(object sender, RoutedEventArgs e)
        {
            if (ReceiveViewer != null)
            {
                ReceiveViewer.IsVideoEnabled = true;
            }
        }

        private void Preview_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ReceiveViewer != null)
            {
                ReceiveViewer.IsVideoEnabled = false;
            }
        }

        // we need a router instance
        public Router RouterInstance
        {
            get { return _routerInstance; }
        }

        // we give our router a name here, but it can be changed later if needed
        private Router _routerInstance = new Router(Application.Current.Properties["RunnerName"].ToString());

        private void ChangeNameButton_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Visibility = Visibility.Visible;
            InputTextBox.Focus();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (InputTextBox.Text == "")
            {
                return;
            }

            SetRunnerName();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            InputTextBox.Text = "";
            InputBox.Visibility = Visibility.Collapsed;
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    if (InputTextBox.Text == "")
                    {
                        return;
                    }
                    SetRunnerName();
                    break;
                case Key.Escape:
                    InputTextBox.Text = "";
                    InputBox.Visibility = Visibility.Collapsed;
                    break;
                default:
                    break;
            }
        }

        private void SetRunnerName()
        {
            // 空白を取り除く
            string title = InputTextBox.Text.Trim();
            InputBox.Visibility = Visibility.Collapsed;
            InputTextBox.Text = "";

            // もし文字列が空なら、この時点でなにもしない
            if (title == "")
            {
                return;
            }

            this.Title = title;
            // Routingを実行する
            _routerInstance.RoutingName = title;
            _routerInstance.UpdateRouting();
        }
    }
}
