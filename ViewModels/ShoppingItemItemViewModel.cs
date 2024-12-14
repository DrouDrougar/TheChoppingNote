using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheChoppingNote.Models;

namespace TheChoppingNote.ViewModels
{
    public class ShoppingItemItemViewModel : BaseViewModel
    {
        private readonly ShoppingItem shoppingItem;

        public ShoppingItemItemViewModel(ShoppingItem shoppingItem)
        {
            this.shoppingItem = shoppingItem;
        }

        public string Name
        {
            get { return shoppingItem.Name; }
            set
            {
                shoppingItem.Name = value;
                OnPropertyChanged();
            }
        }
        public string? Description
        {
            get { return shoppingItem.Description; }
            set
            {
                shoppingItem.Description = value;
                OnPropertyChanged();
            }
        }
        public int? Price
        {
            get { return shoppingItem.Price; }
            set
            {
                shoppingItem.Price = value;
                OnPropertyChanged();
            }
        }
        public int? IsInHowManyRecipies
        {
            get { return shoppingItem.IsInHowManyRecipies; }
            set
            {
                shoppingItem.IsInHowManyRecipies = value;
                OnPropertyChanged();
            }
        }

    }
}