namespace MZExtensions
{
	/// <summary>
	/// A series if Extension Methods for Integers
	/// </summary>
	public static class NumberExtensions
	{
		/// <summary>
		/// Determines if the Int input is between two values. 
		/// By default the lower and upper are NOT inclusive.
		/// An optional Inclusive bool is supplied if you would like the lower and upper bounds to be included in the test.
		/// </summary>
		public static bool Between(this int input, int lower, int upper, bool inclusive = false)
		{
			if (inclusive)
			{
				lower--;
				upper++;
			}
			return (input > lower && input < upper);
		}
	}
}
