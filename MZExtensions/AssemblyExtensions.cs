using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MZExtensions
{
	public static class AssemblyExtensions
	{
		/// <summary>
		/// Gets the implementing classes for a given interface or abstract class (or any type for that matter).
		/// </summary>
		public static IEnumerable<Type> GetTypesImplementing<T>(this Assembly assembly)
		{
			var classes = assembly.GetClassTypes();
			var implementingClasses = classes.Where(typeof(T).IsAssignableFrom);
			return implementingClasses;
		}

		/// <summary>
		/// Returns any types that have the attribute T decorated on the type.
		/// </summary>
		public static IEnumerable<Type> GetTypesWithAttribute<T>(this Assembly assembly) where T : Attribute
		{
			return assembly.GetTypes().Where(type => type.GetCustomAttributes(typeof(T), true).Length > 0);
		}

		/// <summary>
		/// Returns the classes of an Assembly. It will not return IsAbtract, IsInterface or IsGenericTypeDefinition.
		/// </summary>
		/// <see cref="http://stackoverflow.com/questions/80247/implementations-of-interface-through-reflection"/>
		public static IEnumerable<Type> GetClassTypes(this Assembly assembly)
		{
			return assembly.GetTypes().Where(m => !m.IsAbstract && !m.IsInterface && !m.IsGenericTypeDefinition);
		}

		/// <summary>
		/// Returns the Interfaces of an Assembly.
		/// </summary>
		public static IEnumerable<Type> GetInterfaceTypes(this Assembly assembly)
		{
			return assembly.GetTypes().Where(m => m.IsInterface);
		}
	}
}