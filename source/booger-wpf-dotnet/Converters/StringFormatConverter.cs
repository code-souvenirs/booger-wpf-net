#region Copyright Jsinh Booger WPF .NET
// ************************************************************************************
// <copyright file="StringFormatConverter.cs" company="Jaspalsinh Chauhan">
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
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    #endregion

    /// <summary>
    /// Represents booger for conversion to format a string with input string formatter.
    /// </summary>
    [ValueConversion(typeof(string), typeof(string))]
    public class StringFormatConverter : DependencyObject, IValueConverter
    {
        #region Dependency properties

        /// <summary>
        /// Instance of dependency property that indicates the format to be used for input string to apply.
        /// </summary>
        public static readonly DependencyProperty FormatDependency = DependencyProperty.Register("Format", typeof(string), typeof(StringFormatConverter));

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets format to be used for input string to apply.
        /// </summary>
        public string Format
        {
            get
            {
                return this.GetValue(FormatDependency) as string;
            }

            set
            {
                this.SetValue(FormatDependency, value);
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
        /// <returns>Returns formatted string value.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (null == value)
            {
                return DependencyProperty.UnsetValue;
            }

            try
            {
                return string.Format(culture ?? new CultureInfo("en-US", false), this.Format, value);
            }
            catch (Exception)
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
        /// <returns>Returns formatted string value.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //// Nothing to be done for convert back in this converter.
            return value;
        }

        #endregion
    }
}