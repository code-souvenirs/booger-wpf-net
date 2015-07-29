#region Copyright Jsinh Booger WPF .NET
// ************************************************************************************
// <copyright file="InverseBooleanConverter.cs" company="Jaspalsinh Chauhan">
// Copyright © Jaspalsinh Chauhan 2015. All right reserved.
// </copyright>
// ************************************************************************************
// <author>Jaspalsinh Chauhan</author>
// <url>http://jsinh.in</url>
// <url>https://github.com/jsinh/booger-wpf-net</url>
// ************************************************************************************
#endregion

namespace Jsinh.BoogerWpf
{
    #region Namespace

    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    #endregion

    /// <summary>
    /// Represents booger converter to inverse boolean value.
    /// <para>
    /// Example: <strong>true</strong> input will be emitted as <strong>false</strong> and like wise.
    /// </para>
    /// </summary>
    [ValueConversion(typeof(bool), typeof(bool))]
    public sealed class InverseBooleanConverter : IValueConverter
    {
        /// <summary>
        /// Convert from source to destination desired value.
        /// </summary>
        /// <param name="value">Input source value.</param>
        /// <param name="targetType">Instance of target type.</param>
        /// <param name="parameter">Convert parameter to use.</param>
        /// <param name="culture">Culture to be used during conversion</param>
        /// <returns>Returns inversed boolean value.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return this.InverseBoolean(value);
        }

        /// <summary>
        /// Convert destination value back to source expected value.
        /// </summary>
        /// <param name="value">Input destination value.</param>
        /// <param name="targetType">Instance of target type.</param>
        /// <param name="parameter">Convert parameter to use.</param>
        /// <param name="culture">Culture to be used during conversion</param>
        /// <returns>Returns inversed boolean value.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return this.InverseBoolean(value);
        }

        /// <summary>
        /// Inverse input boolean value.
        /// </summary>
        /// <param name="inputValue">Input value.</param>
        /// <returns>Return boolean inverse.</returns>
        private object InverseBoolean(object inputValue)
        {
            try
            {
                var parsedValue = System.Convert.ToBoolean(inputValue);
                return !parsedValue;
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
    }
}
