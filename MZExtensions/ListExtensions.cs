using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MZExtensions
{
	///<summary>
	/// Extension methods for the .NET List type.
	///</summary>
	public static class ListExtensions
	{
		///<summary>
		/// Will duplicate a list into a new list and will not share the same list reference.
		///</summary>
		///<see cref="http://stackoverflow.com/questions/222598/how-do-i-clone-a-generic-list-in-c"/>
		public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
		{
			return listToClone.Select(item => (T)item.Clone()).ToList();
		}
	}
}
