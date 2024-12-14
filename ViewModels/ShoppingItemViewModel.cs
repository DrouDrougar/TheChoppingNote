using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheChoppingNote.Logic;
using TheChoppingNote.Models;

namespace TheChoppingNote.ViewModels
{
    public partial class ShoppingItemViewModel : BaseViewModel
    {

        private ObservableCollection<ShoppingItemItemViewModel> shoppingItemItem = new();
        //        [ObservableProperty]
        //ObservableCollection<ShoppingItem> currentShoppingList = new ObservableCollection<ShoppingItem>();

        //[ObservableProperty]
        //string? addShoppingItem;

        public ObservableCollection<ShoppingItemItemViewModel> ShoppingItemItem
        {
            get { return shoppingItemItem; }
            set
            {
                shoppingItemItem = value;
                OnPropertyChanged();
            }
        }

        private ShoppingItemItemViewModel _selectedShoppingItem;
        public ShoppingItemItemViewModel SelectedShoppingItem
        {
            get { return _selectedShoppingItem; }
            set
            {
                _selectedShoppingItem = value;
                OnPropertyChanged();
                RemoveCommand.RaiseCanExicuteChanged();
            }
        }

        public CommandDeligate AddCommand { get; }
        public CommandDeligate RemoveCommand { get; }

        public ShoppingItemViewModel()
        {
            AddCommand = new CommandDeligate(AddShoppingItem);
            RemoveCommand = new CommandDeligate(RemoveShoppingItem, CanRemove);
        }

       
        private void AddShoppingItem(object? parameter)
        {
            ShoppingItem shoppingItem = new ShoppingItem() { Name = "New", Description = "", Price = 0, IsInHowManyRecipies = 0 };
            var shoppingItemVm = new ShoppingItemItemViewModel(shoppingItem);
            ShoppingItemItem.Add(shoppingItemVm);
            SelectedShoppingItem = shoppingItemVm;
        }

        private bool? CanRemove(object? paramter) => SelectedShoppingItem is not null;
        
        public void RemoveShoppingItem(object? parameter)
        {
            if (SelectedShoppingItem is not null)
            {
                ShoppingItemItem.Remove(SelectedShoppingItem);
            }
            SelectedShoppingItem = null;
        }

    }
}

