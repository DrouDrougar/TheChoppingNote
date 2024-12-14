using TheChoppingNote.Models;
using TheChoppingNote.ViewModels;

namespace TheChoppingNote
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
            vm.Title = "The ChoppingBlock";
   
        }
    }
}
