#region Copyright Jsinh Booger WPF .NET
// ************************************************************************************
// <copyright file="BooleanToVisibilityExConverter.cs" company="Jaspalsinh Chauhan">
// Copyright © Jaspalsinh Chauhan 2015. All right reserved.
// </copyright>
// ************************************************************************************
// <author>Jaspalsinh Chauhan</author>
// <url>http://jsinh.in</url>
// <url>https://github.com/jsinh/booger-wpf-net</url>
// ************************************************************************************
#endregion

// ReSharper disable CheckNamespace
namespace Jsinh.BoogerWpf
// ReSharper restore CheckNamespace
{
    #region Namespace

    using System;
    using System.Windows;
    using System.Windows.Data;

    #endregion

    /// <summary>
    /// Represents booger for conversion of boolean to visibility state (Extended version).
    /// </summary>
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public sealed class BooleanToVisibilityExConverter : DependencyObject, IValueConverter
    {
        #region Dependency properties

        /// <summary>
        /// Instance of dependency property that indicates whether to inverse convert boolean to Visibility state.
        /// If <strong>true</strong> then, input value <strong>true</strong> will convert to <strong>Visibility.Hidden</strong> or <strong>Visibility.Collapsed</strong> and input value <strong>false</strong> will yield <strong>Visibility.Visible</strong>.
        /// </summary>
        public static readonly DependencyProperty ApplyInverseDependency = DependencyProperty.Register("ApplyInverse", typeof(bool), typeof(BooleanToVisibilityExConverter));

        /// <summary>
        /// Instance of dependency property that indicates whether to use <strong>Visibility.Collapsed</strong> or <strong>Visibility.Hidden</strong>. Default is <strong>false</strong> - <strong>Visibility.Collapsed</strong>.
        /// </summary>
        public static readonly DependencyProperty UseVisibilityHiddenDependency = DependencyProperty.Register("UseVisibilityHidden", typeof(bool), typeof(BooleanToVisibilityExConverter));

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether to inverse convert boolean to Visibility state. If true then, input value "true" will convert to Visibility.Hidden or Visibility.Collapsed and input value "false" will yield Visibility.Visible.
        /// </summary>
        public bool ApplyInverse
        {
            get
            {
                return System.Convert.ToBoolean(this.GetValue(ApplyInverseDependency));
            }

            set
            {
                this.SetValue(ApplyInverseDependency, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use Visibility.Hidden instead of Visibility.Collapsed.
        /// </summary>
        public bool UseVisibilityHidden
        {
            get
            {
                return System.Convert.ToBoolean(this.GetValue(UseVisibilityHiddenDependency));
            }

            set
            {
                this.SetValue(UseVisibilityHiddenDependency, value);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Convert from source to destination desired value.
        /// </summary>
        /// <param name="value">Input source value.</param>
        /// <param name="targetType">Instance of target type.</param>
        /// <param name="parameter">Convert parameter to use.</param>
        /// <param name="culture">Culture to be used during conversion</param>
        /// <returns>Returns converted visibility state from boolean value.</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                var parsedValue = System.Convert.ToBoolean(value);
                if (this.ApplyInverse)
                {
                    parsedValue = !parsedValue;
                }

                if (!parsedValue)
                {
                    return this.UseVisibilityHidden ? Visibility.Hidden : Visibility.Collapsed;
                }

                return Visibility.Visible;
            }
            catch (FormatException)
            {
                return DependencyProperty.UnsetValue;
            }
            catch (InvalidCastException)
            {
                return DependencyProperty.UnsetValue;
            }
        }

        /// <summary>
        /// Convert destination value back to source expected value.
        /// </summary>
        /// <param name="value">Input destination value.</param>
        /// <param name="targetType">Instance of target type.</param>
        /// <param name="parameter">Convert parameter to use.</param>
        /// <param name="culture">Culture to be used during conversion</param>
        /// <returns>Returns boolean value for input visibility state.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var result = false;
            if (value.GetType() != typeof(Visibility))
            {
                return false;
            }

            var visibilityState = (Visibility)value;
            switch (visibilityState)
            {
                case Visibility.Visible:
                    result = !this.ApplyInverse;
                    break;

                case Visibility.Hidden:
                case Visibility.Collapsed:
                    result = this.ApplyInverse;
                    break;
            }

            return result;
        }

        #endregion
    }
}