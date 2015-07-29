#region Copyright Jsinh Booger WPF .NET
// ************************************************************************************
// <copyright file="IsNullBooleanConverter.cs" company="Jaspalsinh Chauhan">
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
    using System;
    using System.Globalization;
    #region Namespace

    using System.Windows;
    using System.Windows.Data;

    #endregion

    /// <summary>
    /// Represents booger for any object <strong>IsNull</strong> check. Yeilds true if <see cref="ApplyInverse"/> is false and false if <see cref="ApplyInverse"/> true.
    /// </summary>
    [ValueConversion(typeof(object), typeof(bool))]
    public sealed class IsNullBooleanConverter : DependencyObject, IValueConverter
    {
        #region Dependency properties

        /// <summary>
        /// Instance of dependency property that indicates whether to inverse comparison for null check result.
        /// <para>If <strong>true</strong> and input value is <strong>null</strong> will yeild <strong>false</strong>.</para>
        /// <para>If <strong>false</strong> which is default value for this property and input value is <strong>null</strong> will yield <strong>true</strong>.</para>
        /// </summary>
        public static readonly DependencyProperty ApplyInverseDependency = DependencyProperty.Register("ApplyInverse", typeof(bool), typeof(IsNullBooleanConverter), new PropertyMetadata(false));

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
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (null == value && this.ApplyInverse)
            {
                return true;
            }
            else if (null == value && !this.ApplyInverse)
            {
                return false;
            }
            else if (null != value && this.ApplyInverse)
            {
                return false;
            }
            else
            {
                return true;
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
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}