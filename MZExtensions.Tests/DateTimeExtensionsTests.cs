using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MZExtensions.Tests
{
	[TestClass]
	public class DateTimeExtensionsTests
	{
		[TestMethod]
		public void RelativeDateTime_ForFuture1minute()
		{
			const string expected = "about a minute from now";
			var pastDateTime = DateTime.Now.Add(TimeSpan.FromMinutes(1));

			var actual = pastDateTime.ToTimeAgo();

			Assert.AreEqual(expected, actual);			
		}

		[TestMethod]
		public void RelativeDateTime_For30SecondsAgo()
		{
			const string expected = "less than a minute ago";
			var pastDateTime = DateTime.Now.Subtract(TimeSpan.FromSeconds(30));

			var actual = pastDateTime.ToTimeAgo();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void RelativeDateTime_For1MinuteAgo()
		{
			const string expected = "about a minute ago";
			var pastDateTime = DateTime.Now.Subtract(TimeSpan.FromMinutes(1));

			var actual = pastDateTime.ToTimeAgo();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void RelativeDateTime_For3MinuteAgo()
		{
			const string expected = "3 minutes ago";
			var pastDateTime = DateTime.Now.Subtract(TimeSpan.FromMinutes(3));

			var actual = pastDateTime.ToTimeAgo();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void RelativeDateTime_For1HourAgo()
		{
			const string expected = "about an hour ago";
			var pastDateTime = DateTime.Now.Subtract(TimeSpan.FromHours(1));

			var actual = pastDateTime.ToTimeAgo();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void RelativeDateTime_For3HourAgo()
		{
			const string expected = "about 3 hours ago";
			var pastDateTime = DateTime.Now.Subtract(TimeSpan.FromHours(3));

			var actual = pastDateTime.ToTimeAgo();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void RelativeDateTime_For1DayAgo()
		{
			const string expected = "a day ago";
			var pastDateTime = DateTime.Now.Subtract(TimeSpan.FromDays(1));

			var actual = pastDateTime.ToTimeAgo();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void RelativeDateTime_For3DayAgo()
		{
			const string expected = "3 days ago";
			var pastDateTime = DateTime.Now.Subtract(TimeSpan.FromDays(3));

			var actual = pastDateTime.ToTimeAgo();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void RelativeDateTime_For1MonthsAgo()
		{
			const string expected = "about a month ago";
			var pastDateTime = DateTime.Now.Subtract(TimeSpan.FromDays(30));

			var actual = pastDateTime.ToTimeAgo();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void RelativeDateTime_For2MonthsAgo()
		{
			const string expected = "2 months ago";
			var pastDateTime = DateTime.Now.Subtract(TimeSpan.FromDays(60));

			var actual = pastDateTime.ToTimeAgo();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void RelativeDateTime_For1YearAgo()
		{
			const string expected = "about a year ago";
			var pastDateTime = DateTime.Now.Subtract(TimeSpan.FromDays(365));

			var actual = pastDateTime.ToTimeAgo();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void RelativeDateTime_For2YearAgo()
		{
			const string expected = "2 years ago";
			var pastDateTime = DateTime.Now.Subtract(TimeSpan.FromDays(365 * 2));

			var actual = pastDateTime.ToTimeAgo();

			Assert.AreEqual(expected, actual);
		}
	}
}
