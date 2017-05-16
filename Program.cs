using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HackerRank
{
	class Solution
	{
		/// <summary>
		/// The provided function to complete to resolve problem!
		/// </summary>
		/// <param name="grades"></param>
		/// <returns></returns>
		static int[] solve(int[] grades)
		{
			// Complete this function
			return grades.RoundGrades();
		}

		/// <summary>
		/// Provided Main method for problem.
		/// </summary>
		/// <param name="args"></param>
		static void Main(String[] args)
		{
			args = new string[] { "4", "73", "67", "38", "33" };

			int n = Convert.ToInt32(args[0]);
			int[] grades = new int[n];
			for (int grades_i = 0; grades_i < n; grades_i++)
			{
				grades[grades_i] = Convert.ToInt32(args[grades_i + 1]);
			}
			int[] result = solve(grades);
			Console.WriteLine(String.Join("\n", result));

			Console.ReadKey();
		}
	}
}