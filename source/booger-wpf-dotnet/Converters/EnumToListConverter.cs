#region Copyright Jsinh Booger WPF .NET
// ************************************************************************************
// <copyright file="EnumToListConverter.cs" company="Jaspalsinh Chauhan">
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
    using System.Collections;
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    using System.Windows.Data;

    #endregion

    /// <summary>
    /// Represents booger for conversion of enumeration type and its members to bind-able list.
    /// </summary>
    [ValueConversion(typeof(Enum), typeof(IList))]
    public sealed class EnumToListConverter : DependencyObject, IValueConverter
    {
        #region Dependency properties

        /// <summary>
        /// Instance of dependency property that indicates the type of input enumeration.
        /// </summary>
        public static readonly DependencyProperty EnumTypeDependency = DependencyProperty.Register("EnumType", typeof(object), typeof(EnumToListConverter));

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets enumeration type.
        /// </summary>
        public Type EnumType
        {
            get
            {
                return (Type)this.GetValue(EnumTypeDependency);
            }

            set
            {
                this.SetValue(EnumTypeDependency, value);
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
            if (!this.EnumType.IsEnum)
            {
                return DependencyProperty.UnsetValue;
            }

            try
            {
                var enumerationValues = Enum.GetValues(this.EnumType);
                return (from object item in enumerationValues select item.ToString()).ToList();
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
        /// <returns>Returns boolean value for input visibility state.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //// You cannot add new values to a ENUM defination at runtime so this would be useless.
            return value;
        }

        #endregion
    }
}