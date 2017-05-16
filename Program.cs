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

	static class GradingStudents
	{
		static int failingGradeValue = 40;
		static int roundingCushionValue = 3;
		static int roundingIntervalValue = 5;

		/// <summary>
		/// Round every grade if the difference between it and the next interval of 5 is less than 3 
		/// AND would then still be a passing grade. Otherwise, keep the grade the same.
		/// </summary>
		/// <param name="grades">Grades to round.</param>
		/// <returns></returns>
		internal static int[] RoundGrades(this int[] grades)
		{
			int[] roundedGrades = Array.CreateInstance(typeof(int), grades.Count()) as int[];
			int gradeIndex = 0;

			foreach (int grade in grades)
			{
				bool isInPassingRange = grade > failingGradeValue - roundingCushionValue;
				int newGrade = grade;

				if (isInPassingRange)
				{
					int nextRoundingInterval = grade.NextRoundingInterval();

					bool canRoundUp = nextRoundingInterval - grade < roundingCushionValue;

					if (canRoundUp)
						newGrade = nextRoundingInterval;
				}

				roundedGrades.SetValue(newGrade, gradeIndex);
				gradeIndex++;
			}

			return roundedGrades;
		}

		static List<int> roundingIntervals = Enumerable.Range(0, 101)
			.Where(gradeVal => gradeVal % roundingIntervalValue == 0)
			.ToList();

		/// <summary>
		/// Return next rounding interval, if exists, defaulting to the supplied grade when it does not.
		/// </summary>
		/// <param name="grade"></param>
		/// <returns></returns>
		static int NextRoundingInterval(this int grade)
		{
			bool hasHigherInterval = roundingIntervals
				.OrderByDescending(interval => interval)
				.First() 
				> grade;

			return hasHigherInterval
				? roundingIntervals
					.First(interval => interval > grade)
				: grade;
		}
	}
}