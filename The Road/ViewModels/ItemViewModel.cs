using The_Road.Repositories;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using The_Road.Models;

namespace The_Road.ViewModels
{
    public partial class ItemViewModel : ViewModel
    {
        private readonly ITheRoadItemRepository repository;

        [ObservableProperty]
        TheRoadItem item;

        
        public ItemViewModel(ITheRoadItemRepository repository)
        {
            this.repository = repository;
            Item = new TheRoadItem() { Due = DateTime.Now.AddDays(1) };
        }
        [RelayCommand]
        public async Task SaveAsync()
        {
            await repository.AddOrUpdateAsync(Item);
            await Navigation.PopAsync();
        }
    }
}
