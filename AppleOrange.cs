using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
	static class AppleOrange
	{
		internal static int NumberWithinHouseValues(this int[] fruitFallValues, int fruitTreeCenter, int[] houseBeginningAndEnd)
		{
			int fruitFallingOnHouse = fruitFallValues
				.Where
				(fruitFallValue =>
					fruitTreeCenter + fruitFallValue >= houseBeginningAndEnd[0]
				 && fruitTreeCenter + fruitFallValue <= houseBeginningAndEnd[1]
				).Count();

			return fruitFallingOnHouse;
		}
	}
}
