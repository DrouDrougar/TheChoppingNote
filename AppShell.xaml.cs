namespace TheChoppingNote
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RecipiesPage), typeof(RecipiesPage));
            Routing.RegisterRoute(nameof(RecipieDetailsPage), typeof(RecipieDetailsPage));
        }
    }
}
