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
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Data;

    #endregion

    /// <summary>
    /// Represents booger for conversion between different case types for string values.
    /// </summary>
    [ValueConversion(typeof(string), typeof(string))]
    public sealed class StringCaseConverter : DependencyObject, IValueConverter
    {
        #region Dependency properties

        /// <summary>
        /// Instance of dependency property that indicates case converter style to apply.
        /// </summary>
        public static readonly DependencyProperty StyleDependency = DependencyProperty.Register("Style", typeof(CaseStyle), typeof(StringCaseConverter));

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets case converter style to apply.
        /// </summary>
        public CaseStyle Style
        {
            get
            {
                CaseStyle enumValue;
                if (Enum.TryParse(this.GetValue(StyleDependency).ToString(), true, out enumValue))
                {
                    return enumValue;
                }

                return CaseStyle.None;
            }

            set
            {
                this.SetValue(StyleDependency, value);
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
        /// <returns>Returns case changed value.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null == value ? DependencyProperty.UnsetValue : this.ConvertCase(value.ToString(), culture);
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
            return null == value ? DependencyProperty.UnsetValue : this.ConvertCase(value.ToString(), culture);
        }

        /// <summary>
        /// Convert input string to camel case.
        /// </summary>
        /// <param name="input">Input string to convert.</param>
        /// <returns>Returns converted camel case string.</returns>
        private static string ConvertToCamelCase(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length < 2)
            {
                return input;
            }

            var words = input.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
            var output = new StringBuilder();
            output.Append(words[0].ToLower());
            output.Append(input.Substring(words.Length - 1, input.Length - (words.Length - 1)));
            return output.ToString();
        }

        /// <summary>
        /// Convert input string to sentence case.
        /// </summary>
        /// <param name="input">Input string to convert.</param>
        /// <param name="culture">Culture to be used during conversion</param>
        /// <returns>Returns converted sentence case string.</returns>
        private static string ConvertToSentenceCase(string input, CultureInfo culture)
        {
            var outputLower = input.ToLower(culture ?? new CultureInfo("en-US", false));
            var caseConverterRegex = new Regex(@"(^[a-z])|\.\s+(.)", RegexOptions.ExplicitCapture);
            return caseConverterRegex.Replace(outputLower, item => item.Value.ToUpper(culture ?? new CultureInfo("en-US", false)));
        }

        /// <summary>
        /// Convert case based on input provided.
        /// </summary>
        /// <param name="input">Input string to convert.</param>
        /// <param name="culture">Culture to be used during conversion</param>
        /// <returns>Returns case changed value..</returns>
        private string ConvertCase(string input, CultureInfo culture)
        {
            switch (this.Style)
            {
                case CaseStyle.AllCaps:
                    return input.ToUpper(culture);
                case CaseStyle.AllLower:
                    return input.ToLower(culture);
                case CaseStyle.CamelCase:
                    return ConvertToCamelCase(input);
                case CaseStyle.SentenceCase:
                    return ConvertToSentenceCase(input, culture);
                case CaseStyle.TitleCase:
                    var textInfo = null == culture ? new CultureInfo("en-US", false).TextInfo : culture.TextInfo;
                    return textInfo.ToTitleCase(input);
                default:
                    return input;
            }
        }

        #endregion
    }
}