using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MZExtensions.Tests
{
    [TestClass]
    public class HashSetLinqAccessTests
    {

        [TestMethod]
        public void HashSetLinqAccessShouldReturnHashSetForIEnumerable()
        {
            //Arrange
            IEnumerable<string> input = new List<string> {"1", "2", "3"};
            //Act
            var result = input.ToHashSet();
            //Assert
            Assert.IsInstanceOfType(result,typeof(HashSet<string>));
        }

		[TestMethod]
		public void HashSetLinqAccess_ShouldUse_EqualityComparer_T__Default()
		{
			//Arrange
			IEnumerable<string> input = new List<string> { "1", "2", "3" };
			
			//Act
			var result = input.ToHashSet(null);
			
			//Assert
			Assert.IsInstanceOfType(result, typeof(HashSet<string>));
		}
    }
}
