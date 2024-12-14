using System.Collections.ObjectModel;

namespace TheChoppingNote.Models
{
    public class ShoppingList
    {
        //This class is for making lists in which you then place the actual items. So the collection is for shopping items to be placed. The Recipie List should work the same way.
        //name of the make a place holder something like (Sunday shopping list) 
      public string Name { get; set; }
        //collection for holding shoppingItems inside of can be empty at creation
      public ObservableCollection<ShoppingItem?> Items { get; set; } = new ObservableCollection<ShoppingItem?>();
    }
}
