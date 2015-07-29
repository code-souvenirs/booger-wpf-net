namespace Jsinh.BoogerWpf
{
    #region Namespace

    using System.Windows;

    #endregion

    /// <summary>
    /// Represents chromeless window settings.
    /// </summary>
    public sealed class ChromelessSettings : DependencyObject
    {
        #region Dependency properties

        /// <summary>
        /// Set chromeless window header / system caption height.
        /// <para>
        /// This can be used to provide drag window option - double click maximize / restore for chromeless window.
        /// </para>
        /// </summary>
        public static readonly DependencyProperty ResizeThicknessProperty = DependencyProperty.Register("ResizeThickness", typeof(Thickness), typeof(ChromelessSettings));

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets chromeless header height.
        /// <para>
        /// This can be used to provide drag window option - double click maximize / restore for chromeless window.
        /// </para>
        /// </summary>
        public Thickness ResizeThickness
        {
            get
            {
                return (Thickness)this.GetValue(ResizeThicknessProperty);
            }

            set
            {
                this.SetValue(ResizeThicknessProperty, value);
            }
        }

        #endregion
    }
}