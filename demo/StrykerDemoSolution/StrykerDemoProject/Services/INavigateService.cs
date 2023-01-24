using StrykerDemoProject.Entities;

namespace StrykerDemoProject.Services
{
	public interface INavigateService
	{
		void Next<T>(List<NavigableItem<T>> data);

		//string Bla();

		//Task<string> GetAsync();
	}
}