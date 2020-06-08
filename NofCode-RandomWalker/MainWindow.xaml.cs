using System;
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
using System.Windows.Threading;

namespace NofCode_RandomWalker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const short FrameRateMilliSec = 10;
        const short WalkerRadius = 20;
        private ulong _frameCounter = 0;
        private RandomWalker walker;

        public MainWindow()
        {
            InitializeComponent();

            //Initialize Window and Walker position
            this.SizeChanged += WindowSizeChanged;
            this.WindowState = WindowState.Maximized;

            Setup();

            DispatcherTimer dpTimer = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 0, 0, FrameRateMilliSec)
            };
            dpTimer.Tick += DpTimer_Tick;
            dpTimer.Start();
        }

        private void WindowSizeChanged(object sender, SizeChangedEventArgs e) {
            this.walker.PosX = e.NewSize.Width / 2;
            this.walker.PosY = e.NewSize.Height / 2;
            this._frameCounter = 0;
        }

        private void DpTimer_Tick(object sender, EventArgs e)
        {
            this._frameCounter++;
            FrameCounterValue.Text = $"Frame #{this._frameCounter}";
            Draw();
        }

        private void Setup()
        {
            this.walker = new RandomWalker(this.SketchCanvas,WalkerRadius);
        }

        private void Draw()
        {
            this.walker.PosX = this.ActualWidth / 2;
            this.walker.PosY = this.ActualHeight / 2;
            this.walker.Display();
        }
    }
}
