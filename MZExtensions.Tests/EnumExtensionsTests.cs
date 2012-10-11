using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;

namespace MZExtensions.Tests
{
	/// <summary>
	/// These Enum tests are not attempting to test Linq or Data Annotations. I am simply asserting that the code will walk the enumerations
	/// correctly and use the EnumExtension extension method correctly.
	/// These tests may also function as Samples for others to implement in their code.
	/// </summary>
	[TestClass]
	public class EnumExtensionsTests
	{
		[TestMethod]
		public void EnumDescription_ToList()
		{
			var items = new List<string>();
			items.AddRange(
				Enum.GetValues(typeof(EnumExtensionsModel.ETestItems))
					.Cast<EnumExtensionsModel.ETestItems>()
					.Select(val => val.ToDescriptionString())
				);
			Assert.AreEqual(5, items.Count);
			Assert.AreEqual("Cat Description", items[0]);
		}

		[TestMethod]
		public void EnumDescription_ToList_WithSort()
		{
			var items = new List<string>();
			items.AddRange(
				Enum.GetValues(typeof(EnumExtensionsModel.ETestItems))
					.Cast<EnumExtensionsModel.ETestItems>()
					.Select(val => val.ToDescriptionString())
					.OrderBy(c => c)
				);
			Assert.AreEqual(5, items.Count);
			Assert.AreEqual("Dog Description", items[1]);
		}
	}

    public class EnumExtensionsModel
    {
        public enum ETestItems
        {
            [System.ComponentModel.Description("Cat Description")]
            Cat,
            [System.ComponentModel.Description("Dog Description")]
            Dog,
            [System.ComponentModel.Description("Turtle Description")]
            Turtle,
            [System.ComponentModel.Description("Rabbit Description")]
            Rabbit,
            Fishcake
        }
    }
}
