using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TheChoppingNote.Logic;
using TheChoppingNote.Models;

namespace TheChoppingNote.ViewModels
{
    public partial class RecipieListViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<Recipie> recipiesListsSaved = new ObservableCollection<Recipie>();

        [ObservableProperty]
        string? addShoppingItem;

        [ObservableProperty]
        bool? removeShoppingItem;

        [RelayCommand]
        void Add()
        {
            recipiesListsSaved.Add(new Recipie() { Name = "New List" });
        }

        [RelayCommand]
        void Delete(Recipie shoppingItem)
        {
            recipiesListsSaved.Remove(shoppingItem);
        }
        [RelayCommand]
        async Task GoToDetails(Recipie recipie)
        {
            if (recipie is null) return;

            await Shell.Current.GoToAsync($"{nameof(RecipieDetailsPage)}", true, new Dictionary<string, object> { { "Recipie", recipie } });
        }
        //[RelayCommand]
        //void Sort()
        //{
        //    var sort = recipiesListsSaved.OrderBy(c => c.Name).ToList();
        //    recipiesListsSaved.Clear();
        //    foreach (var item in sort)
        //    {
        //        recipiesListsSaved.Add(item);
        //    }
        //}
    }
}
