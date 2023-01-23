using BlazorDemo4.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace BlazorDemo4.Tests
{
	[TestClass]
	public class AutocompleterTests
	{
		List<Car> _data;
		Autocompleter<Car> _sut;

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
			_sut.Data = _data;
		}

		[TestMethod]
		public void Autocomplete_BasicQuery_GiveSuggestions()
		{
			_sut.Query = "e";
			_sut.Autocomplete();

			var expected = new List<Car>
			{
				_data[0],
				_data[1],
				_data[4],
				_data[7]
			};
			CollectionAssert.AreEquivalent(expected, _sut.Suggestions.Select(x => x.Item).ToList());
		}

		[TestMethod]
		public void Autocomplete_QueryThatMatchesMultipleProperties_GiveSuggestions()
		{
			_sut.Query = "o";
			_sut.Autocomplete();

			var expected = new List<Car>
			{
				_data[0],
				_data[1],
				_data[2],
				_data[4]
			};
			CollectionAssert.AreEquivalent(expected, _sut.Suggestions.Select(x => x.Item).ToList());
		}

		[TestMethod]
		public void Autocomplete_CapitalizedQuery_GiveSuggestionsCaseInsensitively()
		{
			_sut.Query = "R";
			_sut.Autocomplete();

			var expected = new List<Car>
			{
				_data[0],
				_data[1],
				_data[4]
			};
			CollectionAssert.AreEquivalent(expected, _sut.Suggestions.Select(x => x.Item).ToList());
		}

		[TestMethod]
		public void Next_WithNothingHighlighted_HighlightedFirstSuggestion()
		{
			_sut.Query = "e";
			_sut.Autocomplete();

			_sut.Next();

			Assert.IsTrue(_sut.Suggestions[0].IsHighlighted);
			Assert.AreEqual(1, _sut.Suggestions.Count(x => x.IsHighlighted));
		}

		[TestMethod]
		public void Next_WithFirstSuggestionHighlighted_HighlightedSecondSuggestion()
		{
			_sut.Query = "e";
			_sut.Autocomplete();
			_sut.Suggestions[0].IsHighlighted = true;
			
			_sut.Next();

			Assert.IsTrue(_sut.Suggestions[1].IsHighlighted);
			Assert.AreEqual(1, _sut.Suggestions.Count(x => x.IsHighlighted));
		}

		[TestMethod]
		public void Next_WithLastSuggestionHighlighted_HighlightedFirstSuggestion()
		{
			_sut.Query = "e";
			_sut.Autocomplete();
			_sut.Suggestions.Last().IsHighlighted = true;

			_sut.Next();

			Assert.IsTrue(_sut.Suggestions[0].IsHighlighted);
			Assert.AreEqual(1, _sut.Suggestions.Count(x => x.IsHighlighted));
		}
	}
}