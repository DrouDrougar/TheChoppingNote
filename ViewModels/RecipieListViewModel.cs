using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
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

        //private string _saveFile = FileSystem.AppDataDirectory + "/TheChoppingBoard-Recipies.Json";
        //public async Task SaveToJson()
        //{
        //    var arrayCounter = 0;
        //    foreach (var item in recipiesListsSaved)
        //    {
        //        arrayCounter++;
        //    }
        //    Recipie[] recipiesArray = new Recipie[arrayCounter];

        //    var SaveObject = new Recipie()
        //    {
        //        Name = recipiesListsSaved.First().Name,
        //        Description = recipiesListsSaved.First().Description,
        //        RecipieCollection = recipiesArray.ToList()
        //    };
        //    var jsonSaveObjects = JsonSerializer.Serialize(recipiesListsSaved);
        //    var jsonSaveObject = JsonSerializer.Serialize(recipiesListsSaved);
        //    File.WriteAllText(_saveFile, jsonSaveObject);
        //}

        //public async Task LoadSaveFile()
        //{
        //    ObservableCollection<Recipie> readSaveFile = new ObservableCollection<Recipie>();
        //    if (File.Exists(_saveFile) == false) return;
        //    var rawData = File.ReadAllTextAsync(_saveFile).Result;

        //    List<Recipie> jObjects = JsonConvert.DeserializeObject<List<Recipie>>(rawData);
        //    foreach (var item in jObjects)
        //    {
        //        readSaveFile.Add(item);
        //    }
        //    recipiesListsSaved = readSaveFile;
        //}

        [RelayCommand]
        void Add()
        {
            recipiesListsSaved.Add(new Recipie() { Name = "New List", Description="A Recipie"});
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




    }
}
