using System;
using System.Linq;

namespace SQLSaturday.Data
{
	public static class Extensions
	{
		public static T ThrowIfNull<T>(this T argument, string argumentName) where T : class
		{
			if (argument == null) {
				throw new ArgumentNullException (argumentName);
			}

			return argument;
		}

		public static string GetLastName(this string fullName) 
		{
			if (string.IsNullOrWhiteSpace (fullName) || fullName.Length == 0) {
				return "?";
			}

			var nameParts = fullName.Trim().Split (' ');

			string[] suffixes = { "jr", "sr", "i", "ii", "iii", "iv", "v", "vi", "vii", "viii", "ix", "x", "xi", "xii", "xiii", "xiv", "xv" };
			string normalizedPart = nameParts[nameParts.Length - 1].Replace(".", "").Replace(",", "").Trim().ToLower();
			if (suffixes.Contains (normalizedPart)) {
				return nameParts [nameParts.Length - 2] ?? "?";
			} else {
				return nameParts [nameParts.Length - 1];
			}
		}
	}
}

