using Microsoft.QualityTools.Testing.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Tests
{
	public class HedenTests
	{
		[Fact]
		public void HedenTest()
		{
			using (ShimsContext.Create())
			{
				System.Fakes.ShimDateTime.NowGet = () =>
				{
					return new DateTime(2010, 9, 5, 10, 15, 23);
				};

				var sut = new Heden();
				var result = sut.GeefHeden();

				Assert.Equal("10:15", result);
			}
		}
	}
}
