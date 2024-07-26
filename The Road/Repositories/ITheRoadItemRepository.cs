using The_Road.Models;

namespace The_Road.Repositories
{
    public interface ITheRoadItemRepository
    {
        event EventHandler<TheRoadItem> OnItemAdded;
        event EventHandler<TheRoadItem> OnItemUpdated;
        Task<List<TheRoadItem>> GetItemsAsync();
        Task AddItemAsync(TheRoadItem item);
        Task UpdateItemAsync(TheRoadItem item);
        Task AddOrUpdateAsync(TheRoadItem item);
        Task RemoveAsync(TheRoadItem item);
    }
}
