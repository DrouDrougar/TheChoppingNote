using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TheChoppingNote.Models;

namespace TheChoppingNote.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<ShoppingItem> currentShoppingList = new ObservableCollection<ShoppingItem>();

        [ObservableProperty]
        string? addShoppingItem;
        [ObservableProperty]
        bool? removeShoppingItem;

        [RelayCommand]
        void Add()
        {
            if (addShoppingItem is not null && addShoppingItem != "")
            {
                currentShoppingList.Add(new ShoppingItem() { Name = addShoppingItem, CheckedOf = false });
            }
        }

        [RelayCommand]
        void Delete(ShoppingItem shoppingItem)
        {
            CurrentShoppingList.Remove(shoppingItem);
        }
        [RelayCommand]
        void Clear()
        {
            CurrentShoppingList.Clear() ;
        }

        [RelayCommand]
        void Sort()
        {

            var sort = CurrentShoppingList.OrderBy(c => c.CheckedOf).ToList();
            CurrentShoppingList.Clear();
            foreach (var item in sort)
            {
                CurrentShoppingList.Add(item);
            }
        }


    }
}
