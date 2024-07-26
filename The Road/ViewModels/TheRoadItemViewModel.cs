
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
using
/* Unmerged change from project 'The Road (net8.0-maccatalyst)'
Before:
using CommunityToolkit.Mvvm.ComponentModel;
using The_Road.Models;
After:
using The_Road.Models;
*/

/* Unmerged change from project 'The Road (net8.0-ios)'
Before:
using CommunityToolkit.Mvvm.ComponentModel;
using The_Road.Models;
After:
using The_Road.Models;
*/

/* Unmerged change from project 'The Road (net8.0-android)'
Before:
using CommunityToolkit.Mvvm.ComponentModel;
using The_Road.Models;
After:
using The_Road.Models;
*/
CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using The_Road.Models;

namespace The_Road.ViewModels
{
    public partial class TheRoadItemViewModel : ViewModel
    {
        public TheRoadItemViewModel(TheRoadItem item) => item = item;
        public event EventHandler ItemStatusChanged;

        [RelayCommand]
        void ToggleCompleted()
        {
            Item.Completed = !Item.Completed;
            ItemStatusChanged?.Invoke(this, new
            EventArgs());
        }

        [ObservableProperty]
        TheRoadItem item;
        public string StatusText => item.Completed? "Reactivated" : "Completed";
    }
}
