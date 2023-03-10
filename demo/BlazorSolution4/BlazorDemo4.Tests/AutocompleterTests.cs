using BlazorDemo4.Services;
using BlazorDemo4.Shared;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json.Serialization;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace BlazorDemo4.Tests
{
	[TestClass]
	public class AutocompleterTests
	{
		List<Car> _data;
		Autocompleter<Car> _sut;
		Mock<INavigateService> _mockNavigateService;

		[TestInitialize]
		public void Init()
		{
			_data = new List<Car>
			{
				new() { Make = "Opel", Model = "Corsa" },
				new() { Make = "Renault", Model = "Twingo" },
				new() { Make = "Toyota", Model = "Aygo" },
				new() { Make = "Fiat", Model = "Multipla" },
				new() { Make = "Citroen", Model = "DX-3" },
				new() { Make = "Hyuandai", Model = "H100" },
				new() { Make = "Mazda", Model = "CX-5" },
				new() { Make = "Suzuki", Model = "Cube" }
			};
			_sut = new Autocompleter<Car>();
			_mockNavigateService = new Mock<INavigateService>();

			//_mockNavigateService.SetupSequence(x => x.Bla())
			//	.Returns("hoi")
			//	.Returns("Bla");

			//_mockNavigateService.Setup(x => x.GetAsync()).ReturnsAsync("hoooi");

			//_mockNavigateService.Setup(x => x.Bla()).Throws


			_sut.NavigateService = _mockNavigateService.Object;
			_sut.Data = _data;
		}

		[TestMethod]
		public void Autocomplete_BasicQuery_GiveSuggestions()
		{
			_sut.Query = "e";
			_sut.Autocomplete();

			_sut.Suggestions.Select(x => x.Item).Should().ContainInOrder(new Car[]
			{
				_data[0],
				_data[1],
				_data[4],
				_data[7]
			});
		}

		[TestMethod]
		public void Autocomplete_QueryThatMatchesMultipleProperties_GiveSuggestions()
		{
			_sut.Query = "o";
			_sut.Autocomplete();

			_sut.Suggestions.Select(x => x.Item).Should().ContainInOrder(new Car[]
			{
				_data[0],
				_data[1],
				_data[2],
				_data[4]
			});
		}

		[TestMethod]
		public void Autocomplete_CapitalizedQuery_GiveSuggestionsCaseInsensitively()
		{
			_sut.Query = "R";
			_sut.Autocomplete();

			_sut.Suggestions.Select(x => x.Item).Should().ContainInOrder(new Car[]
			{
				_data[0],
				_data[1],
				_data[4]
			});
		}

		[TestMethod]
		public void Next_DoesNotMatter_UseNavigateService()
		{
			_sut.Query = "e";
			_sut.Autocomplete();

			_sut.Next();

			_mockNavigateService.Verify(x => x.Next(It.IsAny<List<NavigableItem<Car>>>()));
			//_mockNavigateService.Invocations[0].
		}
	}
}