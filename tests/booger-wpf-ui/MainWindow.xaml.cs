namespace Jsinh.BoogerWpf.Test
{
    using System.Windows;
    using System.Windows.Input;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void WindowOnMouseDown(object sender, MouseButtonEventArgs eventArgs)
        {
            if (eventArgs.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}