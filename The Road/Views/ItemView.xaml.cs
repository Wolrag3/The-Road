using The_Road.ViewModels;
namespace The_Road.Views;

public partial class ItemView : ContentPage
{
    public ItemView(ItemViewModel viewModel)
    {
        InitializeComponent();
        viewModel.Navigation = Navigation;
        BindingContext = viewModel;
    }
}