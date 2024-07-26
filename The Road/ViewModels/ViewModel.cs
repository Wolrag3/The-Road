using CommunityToolkit.Mvvm.ComponentModel;

namespace The_Road.ViewModels
{
    [ObservableObject]
    public abstract partial class ViewModel
    {
        public INavigation Navigation { get; set; }
    }
}
