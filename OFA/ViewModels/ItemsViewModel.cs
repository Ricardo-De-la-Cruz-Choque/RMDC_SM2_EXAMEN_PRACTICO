using OFA.Models;
using OFA.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OFA.ViewModels
{
    public class ItemsViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _database;

        public ObservableCollection<ShoppingItem> Items { get; } = new ObservableCollection<ShoppingItem>();

        private string newItemName;
        public string NewItemName
        {
            get => newItemName;
            set { newItemName = value; OnPropertyChanged(); }
        }

        private int newItemQuantity = 1;
        public int NewItemQuantity
        {
            get => newItemQuantity;
            set { newItemQuantity = value; OnPropertyChanged(); }
        }

        private string filterText;
        public string FilterText
        {
            get => filterText;
            set { filterText = value; OnPropertyChanged(); FilterItems(); }
        }

        public ICommand AddItemCommand { get; }
        public ICommand ToggleBoughtCommand { get; }
        public ICommand DeleteItemCommand { get; }
        public ICommand RefreshCommand { get; }

        public ItemsViewModel(DatabaseService database)
        {
            _database = database;

            AddItemCommand = new Command(async () => await AddItem());
            ToggleBoughtCommand = new Command<ShoppingItem>(async (i) => await ToggleBought(i));
            DeleteItemCommand = new Command<ShoppingItem>(async (i) => await DeleteItem(i));
            RefreshCommand = new Command(async () => await LoadItems());

            Task.Run(async () => await LoadItems()).Wait();
        }

        private async Task LoadItems()
        {
            var items = await _database.GetItemsAsync();
            Items.Clear();
            foreach (var it in items) Items.Add(it);
            FilterItems(); // aplica filtro si hay
        }

        private void FilterItems()
        {
            if (string.IsNullOrWhiteSpace(FilterText))
            {
                // si no hay filtro, mantener orden actual: recarga desde DB para simplicidad
                Task.Run(async () => await LoadItems()).Wait();
                return;
            }

            var f = FilterText.ToLowerInvariant();
            var filtered = Items.Where(i => (i.Name ?? "").ToLowerInvariant().Contains(f) ||
                                            (i.Category ?? "").ToLowerInvariant().Contains(f)).ToList();
            Items.Clear();
            foreach (var it in filtered) Items.Add(it);
        }

        private async Task AddItem()
        {
            if (string.IsNullOrWhiteSpace(NewItemName)) return;

            var item = new ShoppingItem
            {
                Name = NewItemName.Trim(),
                Quantity = Math.Max(1, NewItemQuantity),
                Category = null,
                IsBought = false
            };

            await _database.AddItemAsync(item);
            NewItemName = string.Empty;
            NewItemQuantity = 1;
            await LoadItems();
        }

        private async Task ToggleBought(ShoppingItem item)
        {
            if (item == null) return;
            item.IsBought = !item.IsBought;
            await _database.UpdateItemAsync(item);
            await LoadItems();
        }

        private async Task DeleteItem(ShoppingItem item)
        {
            if (item == null) return;
            await _database.DeleteItemAsync(item);
            await LoadItems();
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion
    }
}
