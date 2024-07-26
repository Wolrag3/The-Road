
/* Unmerged change from project 'The Road (net8.0-maccatalyst)'
Before:
using System;
After:
using CommunityToolkit.Mvvm.ComponentModel;
using System;
*/

/* Unmerged change from project 'The Road (net8.0-ios)'
Before:
using System;
After:
using CommunityToolkit.Mvvm.ComponentModel;
using System;
*/

/* Unmerged change from project 'The Road (net8.0-android)'
Before:
using System;
After:
using CommunityToolkit.Mvvm.ComponentModel;
using System;
*/
/* Unmerged change from project 'The Road (net8.0-maccatalyst)'
Before:
using CommunityToolkit.Mvvm.ComponentModel;
using The_Road.Repositories;
After:
using The_Road.Repositories;
*/

/* Unmerged change from project 'The Road (net8.0-ios)'
Before:
using CommunityToolkit.Mvvm.ComponentModel;
using The_Road.Repositories;
After:
using The_Road.Repositories;
*/

/* Unmerged change from project 'The Road (net8.0-android)'
Before:
using CommunityToolkit.Mvvm.ComponentModel;
using The_Road.Repositories;
After:
using The_Road.Repositories;
*/
using The_Road.Views;
using The_Road.Repositories;
using CommunityToolkit.Mvvm.Input;
using The_Road.ViewModels;
using The_Road.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace The_Road.ViewModels
{
    public partial class MainViewModel : ViewModel
    {
        private readonly ITheRoadItemRepository repository;
        private readonly IServiceProvider services;

        [ObservableProperty]
        ObservableCollection<TheRoadItemViewModel> items;

        [ObservableProperty]
        TheRoadItemViewModel selectedItem;
        partial void
        OnSelectedItemChanging(TheRoadItemViewModel
        value)
        {
            if (value == null)
            {
                return;
            }
            MainThread.BeginInvokeOnMainThread(async
            () => {
                await NavigateToItemAsync(value);
            });
        }
        private async Task
        NavigateToItemAsync(TheRoadItemViewModel item)
        {
            var itemView =
            services.GetRequiredService<ItemView>();
            var vm = itemView.BindingContext as
            ItemViewModel;
            vm.Item = item.Item;
            itemView.Title = "Edit todo item";
            await Navigation.PushAsync(itemView);
        }




        [RelayCommand]
        public async Task AdditemAsync() => await Navigation.PushAsync(services.GetService<ItemView>());
        public MainViewModel(ITheRoadItemRepository repository, IServiceProvider services)
        {
            repository.OnItemAdded += (sender, item) => items.Add(CreateTodoItemViewModel(item));
            repository.OnItemUpdated += (sender, item) => Task.Run(async () => await LoadDataAsync());
            this.repository = repository;
            this.services = services;
            Task.Run(async () => await LoadDataAsync());
            this.services = services;
        }
        private async Task LoadDataAsync()
        {
            var items = await
            repository.GetItemsAsync();
            if (!ShowAll)
            {
                items = items.Where(x => x.Completed
                == false).ToList();
            }

            var itemViewModels = items.Select(i =>
            CreateTodoItemViewModel(i));
            Items = new
            ObservableCollection<TheRoadItemViewModel>
            (itemViewModels);
        }

        [RelayCommand]
        private async Task ToggleFilterAsync()
        {
            ShowAll = !ShowAll;
            await LoadDataAsync();
        }

        private TheRoadItemViewModel CreateTodoItemViewModel(TheRoadItem item)
        {
            var itemViewModel = new
            TheRoadItemViewModel(item);
            itemViewModel.ItemStatusChanged +=
            ItemStatusChanged;
            return itemViewModel;
        }
        private void ItemStatusChanged(object sender,
        EventArgs e)
        {
            if (sender is TheRoadItemViewModel item)
            {
                if (!ShowAll && item.Item.Completed)
                {
                    Items.Remove(item);
                }
                Task.Run(async () => await
                repository.UpdateItemAsync(item.Item));
            }
        }
        [ObservableProperty]
        bool showAll;



    }
}
