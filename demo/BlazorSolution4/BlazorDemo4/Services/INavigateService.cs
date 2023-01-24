using BlazorDemo4.Shared;

namespace BlazorDemo4.Services
{
    public interface INavigateService
    {
        void Next<T>(List<NavigableItem<T>> data);

        string Bla();

        Task<string> GetAsync();
    }
}