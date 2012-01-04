using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Serialization;

namespace MZExtensions
{
	public static class StringExtensions
	{
		/// <summary>
		/// Determines whether the specified string is numeric.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns>
		///   <c>true</c> if the specified input is numeric; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsNumeric(this string input)
		{
			double value;
			return double.TryParse(input, out value);
		}

		/// <summary>
		/// Given an existing string, append a string. "a".append("z") returns "az"
		/// </summary>
		/// <param name="input">original string</param>
		/// <param name="value">string to be appended to the end of the original string</param>
		/// <returns>Concatenated string</returns>
		/// <remarks></remarks>
		public static string Append(this string input, string value)
		{
			return string.Concat(input, value);
		}

		/// <summary>
		/// Will remove a part of a string from the first occurrence of the value string.
		/// </summary>
		/// <example>
		/// Implementation: "Sample".RemoveFrom("m");
		/// Output: "Sa"
		/// </example>
		/// <param name="input"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		/// <remarks></remarks>
		public static string RemoveFrom(this string input, string value)
		{
			int indexOfValue = input.IndexOf(value);
			if (indexOfValue <= -1)
			{
				return input;
			}
			return input.Remove(indexOfValue);
		}

		/// <summary>
		/// Will find all occurrences of removeValue and remove them.
		/// </summary>
		/// <example>
		/// Implementation: "catt".Remove("t");
		/// Output: "ca"
		/// </example>
		/// <param name="input">The string to manipulate.</param>
		/// <param name="removeValue">The string value to be removed</param>
		/// <returns></returns>
		public static string Remove(this string input, string removeValue)
		{
			return input.Replace(removeValue, String.Empty);
		}

		/// <summary>
		/// Uses a RegularExpression to pattern match that the supplied string is a valid email address.
		/// </summary>
		/// <remarks>Also see http://www.regular-expressions.info/email.html for information on email address validation with regex.</remarks>
		/// <see cref="http://blog.sinjakli.co.uk/2011/02/13/email-address-validation-please-stop/"/>
		/// <seealso cref="http://www.regular-expressions.info/email.html"/>
		/// <param name="input"></param>
		/// <returns></returns>
		public static bool IsValidEmailAddress(this string input)
		{
			const string pattern = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
			var regex = new Regex(pattern, RegexOptions.IgnoreCase);
			return regex.IsMatch(input);
		}

		/// <summary>
		/// Get a substring of the first N characters.
		/// </summary>
		/// <example>
		/// Implementation: "cat".Truncate(1);
		/// Output: "c"
		/// </example>
		public static string Truncate(this string source, int length)
		{
			return source.Length <= length ? source : source.Substring(0, length);
		}

		/// <summary>
		/// Write a string to a file. (UTF8 encoded)
		/// </summary>
		/// <param name="s">The string to write.</param>
		/// <param name="file">Full Path of the file to write to.</param>
		public static void ToFile(this string s, FileInfo file)
		{
			File.WriteAllText(file.FullName, s, Encoding.UTF8);
		}

		/// <summary>
		/// HTML decode.
		/// </summary>
		/// <example>
		/// Input: "&lt;div ID=&quot;ctrl1&quot; runat=&quot;server&quot;/&gt;".HtmlDecode
		/// Output: "<div ID=\"ctrl1\" runat=\"server\"/>"
		/// </example>
		/// <param name="target">The string to HTML decode.</param>
		/// <returns></returns>
		public static string HtmlDecode(this string target)
		{
			return HttpUtility.HtmlDecode(target);
		}

		/// <summary>
		/// HTML encode.
		/// </summary>
		/// <example>
		/// Input: "<div ID=\"ctrl1\" runat=\"server\"/>".HtmlEncode
		/// Output: "&lt;div ID=&quot;ctrl1&quot; runat=&quot;server&quot;/&gt;"
		/// </example>
		/// <param name="target">The target.</param>
		/// <returns></returns>
		public static string HtmlEncode(this string target)
		{
			return HttpUtility.HtmlEncode(target);
		}
	}
}
