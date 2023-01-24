using BlazorDemo4.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Collections;

namespace BlazorDemo4.Shared
{
	public partial class Autocompleter<T> : ComponentBase
	{
		[Parameter] public List<T> Data { get; set; }
		[Inject] public INavigateService NavigateService { get; set; }

		public string Query { get; set; }

		public List<NavigableItem<T>> Suggestions { get; set; }

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
			Suggestions = new List<NavigableItem<T>>();

			foreach (var item in Data)
			{
				var props = item.GetType().GetProperties().Where(x => x.PropertyType == typeof(string)); ;
				foreach (var prop in props)
				{
					var value = prop.GetValue(item) as string;
					if (value.Contains(Query, StringComparison.InvariantCultureIgnoreCase))
					{
						Suggestions.Add(new NavigableItem<T>
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
			NavigateService.Next(Suggestions);
		}
	}
}
