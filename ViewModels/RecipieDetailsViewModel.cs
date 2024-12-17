using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TheChoppingNote.Logic;
using TheChoppingNote.Models;


namespace TheChoppingNote.ViewModels
{
    [QueryProperty("Recipie", "Recipie")]
    public partial class RecipieDetailsViewModel : BaseViewModel
    {
        [ObservableProperty]
        Recipie recipieDetails;

        [ObservableProperty]
        ObservableCollection<ShoppingItem> shoppingItemsInRecipie = new ObservableCollection<ShoppingItem>();

        [ObservableProperty]
        string? addShoppingItem;        
        
        [ObservableProperty]
        string? editDescription;

        [ObservableProperty]
        string? editName;

        [ObservableProperty]
        bool? removeShoppingItem;


        public void GetRecipieListItems()
        {
            shoppingItemsInRecipie = recipieDetails.RecipieCollection;
        }

        [RelayCommand]
        void Add()
        {
            if (addShoppingItem is not null && addShoppingItem != "")
            {
                shoppingItemsInRecipie.Add(new ShoppingItem() { Name = addShoppingItem, CheckedOf = false });
            }
        }

        [RelayCommand]
        void Edit()
        {
            if (editName is not null && editName != "")
            {
                recipieDetails.Name = editName;
            }
            if (editDescription is not null && editDescription != "")
            {
                recipieDetails.Description = editDescription;
            }
        }

        [RelayCommand]
        void Delete(ShoppingItem shoppingItem)
        {
            shoppingItemsInRecipie.Remove(shoppingItem);
        }

    }
}
