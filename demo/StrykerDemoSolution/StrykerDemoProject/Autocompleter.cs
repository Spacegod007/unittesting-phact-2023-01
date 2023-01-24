using StrykerDemoProject.Entities;
using StrykerDemoProject.Services;

namespace StrykerDemoProject
{
	public class Autocompleter<T>
	{
		public List<T> Data { get; set; }
		public INavigateService NavigateService { get; set; }

		public string Query { get; set; }

		public List<NavigableItem<T>> Suggestions { get; set; }

		public void HandleKeyUp(string key)
		{
			if (key.StartsWith("Arrow"))
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