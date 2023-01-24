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
	public class NavigateServiceTests
	{
		List<Car> _data;
		List<NavigableItem<Car>> _navigableData;
		NavigateService _sut;

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
			_navigableData = _data.Select(item => new NavigableItem<Car> { Item = item }).ToList();
			_sut = new NavigateService();
		}

		[TestMethod]
		public void Next_WithNothingHighlighted_HighlightedFirstSuggestion()
		{
			_sut.Next(_navigableData);

			_navigableData.First().IsHighlighted.Should().Be(true);
			_navigableData.Should().ContainSingle(x => x.IsHighlighted);
		}

		[TestMethod]
		public void Next_WithFirstSuggestionHighlighted_HighlightedSecondSuggestion()
		{
			_navigableData[0].IsHighlighted = true;

			_sut.Next(_navigableData);

			_navigableData[1].IsHighlighted.Should().Be(true);
			_navigableData.Should().ContainSingle(x => x.IsHighlighted);
		}

		[TestMethod]
		public void Next_WithLastSuggestionHighlighted_HighlightedFirstSuggestion()
		{
			_sut.Next(_navigableData);

			_navigableData.First().IsHighlighted.Should().Be(true);
			_navigableData.Should().ContainSingle(x => x.IsHighlighted);
		}
	}
}