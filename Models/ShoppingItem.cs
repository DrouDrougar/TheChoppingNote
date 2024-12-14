namespace TheChoppingNote.Models
{
    public class ShoppingItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public int? IsInHowManyRecipies { get; set; }
        public bool CheckedOf { get; set; } = false;

    }
}
