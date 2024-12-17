
using System.Collections.ObjectModel;

namespace TheChoppingNote.Models
{
    public class Recipie
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ObservableCollection<ShoppingItem?> RecipieCollection { get; set; } = new ObservableCollection<ShoppingItem?>();
    }
}
