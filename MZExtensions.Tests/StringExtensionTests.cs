using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MZExtensions.Tests
{
	[TestClass]
	public class StringExtensionTests
	{
		/// <summary>
		/// Will test a bunch of strings and will assert that they are valid. These email address should all be acceptable.
		/// I know that multiple assertions in a single test is considered bad form.
		/// </summary>
		[TestMethod]
		public void Email_Addresses_Should_Be_Valid()
		{
			const bool expected = true;
			var items = new List<string>()
			            	{
			            		"geek@janison.com",
			            		"nerd@janison.com.au",
			            		"b.en@janison.com",
			            		"b.e-n@janison.com",
			            		"ben@jani-son.com",
			            		"natasha@janison.co.uk",
								"crystal@server.department.janison.com",
								"linda@site.name",
								"harrison+unicorns@starwars.com"
			            	};
			items.ForEach(item => Assert.AreEqual(expected, item.IsValidEmailAddress()));
		}

		/// <summary>
		/// Some symbols are actually valid in emails. Especially the "+" symbol
		/// </summary>
		/// <see cref="http://blog.sinjakli.co.uk/2011/02/13/email-address-validation-please-stop/"/>
		[TestMethod]
		public void Email_Address_Validation_Should_Allow_Some_Symbols()
		{
			const bool expected = true;
			const string item = "ben.!$&*–=^`|~#%‘+/?_{}@gmail.com";
			Assert.AreEqual(expected, item.IsValidEmailAddress());
		}

		/// <summary>
		/// Will test a bunch of strings and will assert that they are actually invalid. These email address should NOT be acceptable.
		/// I know that multiple assertions in a single test is considered bad form.
		/// </summary>
		[TestMethod]
		public void Email_Addresses_Should_Not_Be_Valid()
		{
			const bool expected = false;
			var items = new List<string>()
			            	{
			            		"ben@janison",
								"b@b",
								"ben"
			            	};
			items.ForEach(item => Assert.AreEqual(expected, item.IsValidEmailAddress()));
		}

		[TestMethod]
		public void String_Truncate_Should_Truncate_To_3_Chars()
		{
			const string expected = "The";
			const string input = "The cat sat on the mat";
			var output = input.Truncate(3);
			Assert.AreEqual(expected, output);
		}

		[TestMethod]
		public void HtmlEncode_Should_Encode()
		{
			var expected = "&lt;div ID=&quot;ctrl1&quot; runat=&quot;server&quot;/&gt;";
			var text = "<div ID=\"ctrl1\" runat=\"server\"/>";

			var actual = text.HtmlEncode();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void HtmlDecode_Should_Decode()
		{
			var expected = "<div ID=\"ctrl1\" runat=\"server\"/>";
			var text = "&lt;div ID=&quot;ctrl1&quot; runat=&quot;server&quot;/&gt;";

			var actual = text.HtmlDecode();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Truncate_Should_Truncate_Long_String_To_11()
		{
			var expected = "The Owl and";
			var text = new StringBuilder();
				text.Append("The Owl and the Pussy-cat went to sea ");
				text.Append("In a beautiful pea green boat, ");
				text.Append("They took some honey, and plenty of money, ");
				text.Append("Wrapped up in a five pound note.");

			var actual = text.ToString().Truncate(11);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Truncate_Should_Not_Truncate_Long_String_If_Value_Larger_Than_String()
		{
			var expected = new StringBuilder();
			expected.Append("The Owl and the Pussy-cat went to sea ");
			expected.Append("In a beautiful pea green boat, ");
			expected.Append("They took some honey, and plenty of money, ");
			expected.Append("Wrapped up in a five pound note.");

			var text = new StringBuilder();
			text.Append("The Owl and the Pussy-cat went to sea ");
			text.Append("In a beautiful pea green boat, ");
			text.Append("They took some honey, and plenty of money, ");
			text.Append("Wrapped up in a five pound note.");

			var actual = text.ToString().Truncate(1111);

			Assert.AreEqual(expected.ToString(), actual);
		}

		[TestMethod]
		public void RemoveFrom_Should_RemoveFrom_Particular_String()
		{
			var expected = "This is a sample ";
			var text = "This is a sample ^^ message, that will be truncated from a particular string";

			var actual = text.RemoveFrom("^");

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void RemoveFrom_WithNoMatch_Should_MakeNoChange()
		{
			var expected = "This is a sample ^^ message, that will be truncated from a particular string";
			var text = "This is a sample ^^ message, that will be truncated from a particular string";

			var actual = text.RemoveFrom("%");

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Append_Should_Append_Strings()
		{
			var expected = "join strings together";

			var actual = "join strings".Append(" together");

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void IsNumeric_Int_String_Should_Evaluate_True()
		{
			var expected = true;
			var text = "123456789";

			var actual = text.IsNumeric();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void IsNumeric_Decimal_String_Should_Evaluate_True()
		{
			var expected = true;
			var text = "1.23456789";

			var actual = text.IsNumeric();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void IsNumeric_Not_Numeric_String_Should_Evaluate_False()
		{
			var expected = false;
			var text = "123456789rabbits";

			var actual = text.IsNumeric();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Remove_Should_Remove_String_with_Empty_String()
		{
			var expected = "Lin";
			var text = "Linda";

			var actual = text.Remove("da");

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void String_ToFile_Should_Create_File()
		{
			var expected = true;
			var text = "Linda";

			var appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			var filePath = appPath.Append("\\String_ToFile_Should_Create_File.txt");
			var file = new FileInfo(filePath);
			if (File.Exists(file.FullName)) file.Delete();

			text.ToFile(new FileInfo(filePath));

			Assert.AreEqual(expected, File.Exists(filePath));
		}
	}
}
