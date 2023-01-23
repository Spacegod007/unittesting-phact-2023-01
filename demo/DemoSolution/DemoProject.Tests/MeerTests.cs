using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Tests
{
	public class MeerTests
	{
		[Fact]
		[Trait("type", "perf")]
		public async Task HierEersteTest()
		{
			//await Task.Delay(3000);
		}

		[Fact]
		public void HierTweedeTest()
		{

		}



		[Fact]
		[Trait("type", "perf")]
		public async Task HierVierdeTest()
		{
			//await Task.Delay(2000);
			Assert.Fail("want");
		}

		[Fact]
		public void HierVijfdeTest()
		{

		}

		[Fact]
		public void HierZesdeTest()
		{

		}
	}
}
