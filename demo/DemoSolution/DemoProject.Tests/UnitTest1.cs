namespace DemoProject.Tests
{
	public class UnitTest1
	{

		[Fact]
		public void AddTest()
		{
			// Arrange
			var sut = new Calculator(); // system under test

			// Act
			sut.Add(4);
			sut.Add(8);
			sut.Add(15);
			sut.Add(16);
			sut.Add(23);
			sut.Add(42);

			// Assert
			Assert.Equal(108, sut.Result);
			Assert.Equal("bla", "bla");
		}

		[Fact]
		public void Test1()
		{
			Assert.Equal(4, 4);
			Assert.Equal("hoi", "hqqqoi");
			Assert.NotEqual("hoi", "doei");
		}

		[Fact]
		[Trait("type", "perf")]
		public async Task HierDerdeTest()
		{
			//await Task.Delay(5000);

		}
	}
}