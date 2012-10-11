using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MZExtensions;

namespace Janison.Utils.Tests.Extensions
{
	[TestClass]
	public class ListExtensionsTests
	{
		[TestMethod]
		public void Cloned_List_Should_Not_Share_Reference()
		{
			var orgininal = new List<string>() {"cat", "dog"};
			var cloned = orgininal.Clone();
			var isSharedReference = Object.ReferenceEquals(orgininal, cloned);
			Assert.AreEqual(false, isSharedReference);
		}
	}
}
