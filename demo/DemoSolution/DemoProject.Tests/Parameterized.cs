using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Tests
{
	public class Parameterized
	{
		[Theory] // MSTest [DataRow], NUnit [TestCase]
		[InlineData(27, 4, 8, 15)]
		[InlineData(-23, - 4, -8, -15, 2, 2)]
		[InlineData(11, 4, -8, 15)]
		public void AddTest(int expected, params int[] inputs)
		{
			// Arrange
			var sut = new Calculator();

			// Act
			foreach (var input in inputs)
			{
				sut.Add(input);
			}

			// Assert
			Assert.Equal(expected, sut.Result);
		}

	}
}
