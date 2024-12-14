using System.Collections.ObjectModel;
using TheChoppingNote.Logic;
using TheChoppingNote.Models;

namespace TheChoppingNote.ViewModels
{
    public class RecipieListViewModel : BaseViewModel
    {
        private ObservableCollection<RecipieListItemViewModel> recipies = new();

        public ObservableCollection<RecipieListItemViewModel> Recipies
        {
            get { return recipies; }
            set
            {
                recipies = value;
                OnPropertyChanged();
            }
        }

        private RecipieListItemViewModel selectedRecipieList;
        public RecipieListItemViewModel SelectedRecipieList
        {
            get { return selectedRecipieList; }
            set
            {
                selectedRecipieList = value;
                OnPropertyChanged();
            }
        }

        public CommandDeligate AddCommand { get; }
        public CommandDeligate RemoveCommand { get; }

        public RecipieListViewModel()
        {
            AddCommand = new CommandDeligate(AddRecipieList);
            RemoveCommand = new CommandDeligate(RemoveRecipieList, CanRemove);
        }
        private void AddRecipieList(object? parameter)
        {
            Recipie recipie = new Recipie() { Name = "" };
            var recipiesVm = new RecipieListItemViewModel(recipie);
            Recipies.Add(recipiesVm);
            SelectedRecipieList = recipiesVm;
        }
        private bool? CanRemove(object? parameter) => SelectedRecipieList is not null;

        public void RemoveRecipieList(object? parameter)
        {
            if (SelectedRecipieList is not null)
            {
                Recipies.Remove(SelectedRecipieList);
            }
            SelectedRecipieList = null;
        }
    }
}
