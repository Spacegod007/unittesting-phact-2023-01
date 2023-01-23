using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Collections;

namespace BlazorDemo4.Shared
{
	public partial class Autocompleter<T> : ComponentBase
	{
		[Parameter] public List<T> Data { get; set; }

		public string Query { get; set; }

		public List<NavigableItem> Suggestions { get; set; }

		public void HandleKeyUp(KeyboardEventArgs args)
		{
			if (args.Key.StartsWith("Arrow"))
			{
				Next();
			}
			else
			{
				Autocomplete();
			}
		}

		public void Autocomplete()
		{
			Suggestions = new List<NavigableItem>();

			foreach (var item in Data)
			{
				var props = item.GetType().GetProperties().Where(x => x.PropertyType == typeof(string)); ;
				foreach (var prop in props)
				{
					var value = prop.GetValue(item) as string;
					if (value.Contains(Query, StringComparison.InvariantCultureIgnoreCase))
					{
						Suggestions.Add(new NavigableItem
						{
							Item = item
						});
						break;
					}
				}
			}
		}

		public void Next()
		{
			for (int i = 0; i < Suggestions.Count; i++)
			{
				if (Suggestions[i].IsHighlighted)
				{
					Suggestions[i].IsHighlighted = false;
					Suggestions[(i + 1) % Suggestions.Count].IsHighlighted = true;
					return;
				}
			}

			Suggestions[0].IsHighlighted = true;
		}

		public class NavigableItem
		{
			public T Item { get; set; }

			public bool IsHighlighted { get; set; }
		}
	}
}
