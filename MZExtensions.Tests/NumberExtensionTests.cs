using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MZExtensions.Tests
{
	[TestClass]
	public class NumberExtensionTests
	{
		[TestMethod]
		public void Int_Is_Between_Not_Inclusive()
		{
			var expected = true;
			var actual = 2.Between(1, 10);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Int_Is_Not_Between_Not_Inclusive()
		{
			var expected = false;
			var actual = 1.Between(1, 10);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Int_Is_Between_Inclusive()
		{
			var expected = true;
			var actual = 1.Between(1, 10, true);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Int_Is_Not_Between_Inclusive()
		{
			var expected = false;
			var actual = 0.Between(1, 10, true);
			Assert.AreEqual(expected, actual);
		}
	}
}
