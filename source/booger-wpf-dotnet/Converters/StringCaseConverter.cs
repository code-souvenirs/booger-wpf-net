#region Copyright Jsinh Booger WPF .NET
// ************************************************************************************
// <copyright file="StringCaseConverter.cs" company="Jaspalsinh Chauhan">
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
    using System.Windows.Data;
    
    #endregion

    /// <summary>
    /// Represents booger for conversion between different case types for string values.
    /// </summary>
    [ValueConversion(typeof(string), typeof(string))]
    public sealed class StringCaseConverter : IValueConverter
    {
        #region Methods

        /// <summary>
        /// Convert from source to destination desired value.
        /// </summary>
        /// <param name="value">Input source value.</param>
        /// <param name="targetType">Instance of target type.</param>
        /// <param name="parameter">Convert parameter to use.</param>
        /// <param name="culture">Culture to be used during conversion</param>
        /// <returns>Returns case changed value.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Empty;
        }

        /// <summary>
        /// Convert destination value back to source expected value.
        /// </summary>
        /// <param name="value">Input destination value.</param>
        /// <param name="targetType">Instance of target type.</param>
        /// <param name="parameter">Convert parameter to use.</param>
        /// <param name="culture">Culture to be used during conversion</param>
        /// <returns>Returns case changed value..</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Empty;
        }

        #endregion
    }
}