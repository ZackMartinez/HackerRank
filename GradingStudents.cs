using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
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
