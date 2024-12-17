using TheChoppingNote.Models;
using TheChoppingNote.ViewModels;

namespace TheChoppingNote
{
    public partial class MainPage : ContentPage
    {
        private string _saveFile = FileSystem.AppDataDirectory + "/TheChoppingBoard.Json";
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();

            vm.LoadSaveFile();
            BindingContext = vm;
            vm.Title = "The ChoppingBlock";
   
        }
    }
}
