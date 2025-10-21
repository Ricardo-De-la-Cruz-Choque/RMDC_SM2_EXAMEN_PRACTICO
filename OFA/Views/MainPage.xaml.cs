using Microsoft.Maui.Controls;
using ShoppingListApp.Models;
using ShoppingListApp.ViewModels;


namespace OFA
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sender is CheckBox cb && cb.BindingContext is ShoppingItem it)
            {
                await App.Database.UpdateItemAsync(it);
                await ((ItemsViewModel)BindingContext).RefreshCommand.ExecuteAsync(null);
            }
        }

        private async void OnSwipeDelete(object sender, EventArgs e)
        {
            if (sender is SwipeItem si && si.BindingContext is ShoppingItem item)
            {
                await App.Database.DeleteItemAsync(item);
                await ((ItemsViewModel)BindingContext).RefreshCommand.ExecuteAsync(null);
            }
        }
    }

}
