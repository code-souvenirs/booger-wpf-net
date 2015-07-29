namespace Jsinh.BoogerWpf
{
    #region Namespace

    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    #endregion

    /// <summary>
    /// Represents chromeless window - application buttons panel.
    /// </summary>
    public partial class ChromelessAppButtons
    {
        #region Variable declaration and dependency properties

        /// <summary>
        /// Instance of parent window.
        /// </summary>
        private Window parentWindow;

        /// <summary>
        /// Chromeless window application buttons control margin when windows state is maximize.
        /// </summary>
        public static readonly DependencyProperty MarginOnMaximizeProperty = DependencyProperty.Register("MarginOnMaximize", typeof(Thickness), typeof(ChromelessAppButtons));

        /// <summary>
        /// Chromeless window application button inter button margin.
        /// </summary>
        public static readonly DependencyProperty AppButtonInterMarginProperty = DependencyProperty.Register("AppButtonInterMargin", typeof(Thickness), typeof(ChromelessAppButtons));

        /// <summary>
        /// Chromeless window application minimize and maximize / restore button content padding.
        /// </summary>
        public static readonly DependencyProperty AppButtonPaddingProperty = DependencyProperty.Register("AppButtonPadding", typeof(Thickness), typeof(ChromelessAppButtons));

        /// <summary>
        /// Chromeless window application exit button content padding.
        /// </summary>
        public static readonly DependencyProperty AppExitButtonPaddingProperty = DependencyProperty.Register("AppExitButtonPadding", typeof(Thickness), typeof(ChromelessAppButtons));

        /// <summary>
        /// Chromeless window application button background color for Minimize and Maximize / Restore button.
        /// </summary>
        public static readonly DependencyProperty ExceptExitBackgroundColorProperty = DependencyProperty.Register("ExceptExitBackgroundColor", typeof(Brush), typeof(ChromelessAppButtons), new PropertyMetadata(Brushes.Transparent));

        /// <summary>
        /// Chromeless window application button background color on hover for Minimize and Maximize / Restore button.
        /// </summary>
        public static readonly DependencyProperty ExceptExitHoverBackgroundColorProperty = DependencyProperty.Register("ExceptExitHoverBackgroundColor", typeof(Brush), typeof(ChromelessAppButtons), new PropertyMetadata(Brushes.Transparent));

        /// <summary>
        /// Chromeless window application button background color for exit button.
        /// </summary>
        public static readonly DependencyProperty ExitBackgroundColorProperty = DependencyProperty.Register("ExitBackgroundColor", typeof(Brush), typeof(ChromelessAppButtons), new PropertyMetadata(Brushes.Transparent));

        /// <summary>
        /// Chromeless window application button background color on hover for exit button.
        /// </summary>
        public static readonly DependencyProperty ExitHoverBackgroundColorProperty = DependencyProperty.Register("ExitHoverBackgroundColor", typeof(Brush), typeof(ChromelessAppButtons), new PropertyMetadata(Brushes.Transparent));

        /// <summary>
        /// Chromeless window application button option.
        /// </summary>
        public static readonly DependencyProperty AppButtonOptionProperty = DependencyProperty.Register("AppButtonOption", typeof(ChromelessAppButtonOption), typeof(UserControl), new PropertyMetadata(ChromelessAppButtonOption.ShowAll));

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new of the <see cref="ChromelessAppButtons"/> class.
        /// </summary>
        public ChromelessAppButtons()
        {
            InitializeComponent();
            this.Loaded += this.ChromelessWindowAppButtonLoaded;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets or sets chromeless window application buttons control margin when windows state is maximize.
        /// </summary>
        public Thickness MarginOnMaximize
        {
            get
            {
                return (Thickness)GetValue(MarginOnMaximizeProperty);
            }

            set
            {
                base.SetValue(MarginOnMaximizeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets chromeless window application button margin between those buttons - minimize - maximize / restore - exit.
        /// </summary>
        public Thickness AppButtonInterMargin
        {
            get
            {
                return (Thickness)GetValue(AppButtonInterMarginProperty);
            }

            set
            {
                base.SetValue(AppButtonInterMarginProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets chromeless window application minimize and maximize / restore button content padding.
        /// </summary>
        public Thickness AppButtonPadding
        {
            get
            {
                return (Thickness)GetValue(AppButtonPaddingProperty);
            }

            set
            {
                base.SetValue(AppButtonPaddingProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets chromeless window application exit button content padding.
        /// </summary>
        public Thickness AppExitButtonPadding
        {
            get
            {
                return (Thickness)GetValue(AppExitButtonPaddingProperty);
            }

            set
            {
                base.SetValue(AppExitButtonPaddingProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets chromeless window application button background color for minimize and maximize / restore button.
        /// </summary>
        public Brush ExceptExitBackgroundColor
        {
            get
            {
                return GetValue(ExceptExitBackgroundColorProperty) as Brush;
            }

            set
            {
                base.SetValue(ExceptExitBackgroundColorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets chromeless window application button background color for exit button.
        /// </summary>
        public Brush ExitBackgroundColor
        {
            get
            {
                return GetValue(ExitBackgroundColorProperty) as Brush;
            }

            set
            {
                base.SetValue(ExitBackgroundColorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets chromeless window application button background color for minimize and maximize / restore button.
        /// </summary>
        public Brush ExceptExitHoverBackgroundColor
        {
            get
            {
                return GetValue(ExceptExitHoverBackgroundColorProperty) as Brush;
            }

            set
            {
                base.SetValue(ExceptExitHoverBackgroundColorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets chromeless window application button background color for exit button.
        /// </summary>
        public Brush ExitHoverBackgroundColor
        {
            get
            {
                return GetValue(ExitHoverBackgroundColorProperty) as Brush;
            }

            set
            {
                base.SetValue(ExitHoverBackgroundColorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets chromeless window application button option.
        /// </summary>
        public ChromelessAppButtonOption AppButtonOption
        {
            get
            {
                return (ChromelessAppButtonOption)GetValue(AppButtonOptionProperty);
            }

            set
            {
                base.SetValue(AppButtonOptionProperty, value);
            }
        }

        /// <summary>
        /// Chromeless window application button user control on loaded event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="eventArgs">Event arguments.</param>
        private void ChromelessWindowAppButtonLoaded(object sender, RoutedEventArgs eventArgs)
        {
            this.parentWindow = GetTopParent();
        }

        /// <summary>
        /// Event handler for chromeless window minimize application button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="eventArgs">Event arguments.</param>
        private void MinimizeButtonClick(object sender, RoutedEventArgs eventArgs)
        {
            this.parentWindow.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Event handler for chromeless window maximize / restore application button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="eventArgs">Event arguments.</param>
        private void RestoreButtonClick(object sender, RoutedEventArgs eventArgs)
        {
            this.parentWindow.WindowState = this.parentWindow.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        /// <summary>
        /// Event handler for chromeless window close application button click event.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="eventArgs">Event arguments.</param>
        private void CloseButtonClick(object sender, RoutedEventArgs eventArgs)
        {
            this.parentWindow.Close();
        }

        /// <summary>
        /// Get top parent window.
        /// </summary>
        /// <returns>Returns parent <seealso cref="Window"/> instance.</returns>
        private Window GetTopParent()
        {
            return Window.GetWindow(this);
        }

        #endregion
    }
}