using BlazorDemo4.Shared;

namespace BlazorDemo4.Services
{
	public class NavigateService : INavigateService
	{
		public void Next<T>(List<NavigableItem<T>> data)
		{
			for (int i = 0; i < data.Count; i++)
			{
				if (data[i].IsHighlighted)
				{
					data[i].IsHighlighted = false;
					data[(i + 1) % data.Count].IsHighlighted = true;
					return;
				}
			}

			data[0].IsHighlighted = true;
		}
	}
}
