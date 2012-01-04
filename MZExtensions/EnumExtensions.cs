using System;
using System.ComponentModel;

namespace MZExtensions
{
	/// <summary>
	/// Enum Extensions for general use.
	/// </summary>
	public static class EnumExtensions
	{
		/// <summary>
		/// Will look for the [Description] attribute on an enum. Also see Utils.Tests.Exensions.EnumExtensionsTests for implementation samples.
		/// </summary>
		/// <returns>
		///	A string value of the enum based on it's [Description] attribute decoration.
		/// </returns>
		/// <example>
		/// var items = new List<string> { "--All Status--" };
		///	items.AddRange(
		///		Enum.GetValues(typeof(User.EnCurrentStatus))
		///			.Cast<User.EnCurrentStatus>()
		///			.Select(val => val.ToDescriptionString())
		///			.OrderBy(c => c)
		///		);
		///	return items;
		/// </example>
		public static string ToDescriptionString(this Enum val)
		{
			DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
			return attributes.Length > 0 ? attributes[0].Description : val.ToString();
		}
	}
}
