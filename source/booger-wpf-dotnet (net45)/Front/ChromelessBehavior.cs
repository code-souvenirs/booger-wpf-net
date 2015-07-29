namespace Jsinh.BoogerWpf
{
    #region Namespace

    using System.Windows;
    using System.Windows.Shell;

    #endregion

    /// <summary>
    /// Attach chromeless window - resizable / borderless behavior to <seealso cref="Window"/> control.
    /// </summary>
    public class ChromelessBehavior
    {
        #region Dependency property

        /// <summary>
        /// Apply chromeless window behavior.
        /// </summary>
        public static readonly DependencyProperty ApplyProperty = DependencyProperty.RegisterAttached("Apply", typeof(ChromelessSettings), typeof(ChromelessBehavior), new PropertyMetadata(null, OnChromelessBehaviorApplied));

        #endregion

        #region Methods

        /// <summary>
        /// Get chromeless window behavior apply state.
        /// </summary>
        /// <param name="dependencyObject">Instance of dependency object.</param>
        /// <returns>Returns instance of chromeless window settings.</returns>
        public static ChromelessSettings GetApply(DependencyObject dependencyObject)
        {
            return (ChromelessSettings)dependencyObject.GetValue(ApplyProperty);
        }

        /// <summary>
        /// Set chromeless window behavior apply state.
        /// </summary>
        /// <param name="dependencyObject">Instance of dependency object.</param>
        /// <param name="value">Instance of chromeless window settings.</param>
        public static void SetApply(DependencyObject dependencyObject, ChromelessSettings value)
        {
            dependencyObject.SetValue(ApplyProperty, value);
        }

        /// <summary>
        /// Event handler for chromeless window behavior apply value changes.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="eventArgs">Event arguments.</param>
        private static void OnChromelessBehaviorApplied(object sender, DependencyPropertyChangedEventArgs eventArgs)
        {
            var window = sender as Window;
            var chromeSettings = eventArgs.NewValue as ChromelessSettings;
            if (null != window)
            {
                WindowChrome.SetWindowChrome(window, new WindowChrome
                {
                    CaptionHeight = 0,
                    ResizeBorderThickness = new Thickness(3),
                    GlassFrameThickness = new Thickness(1),
                    UseAeroCaptionButtons = false,
                    NonClientFrameEdges = NonClientFrameEdges.None
                });
            }
        }

        #endregion
    }
}