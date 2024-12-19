using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Collections.ObjectModel;
using System.Text.Json;
using TheChoppingNote.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TheChoppingNote.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<ShoppingItem> currentShoppingList = new ObservableCollection<ShoppingItem>();

        [ObservableProperty]
        string? addShoppingItem;
        [ObservableProperty]
        bool? removeShoppingItem;

        private string _saveFile = FileSystem.AppDataDirectory + "/TheChoppingBoard.Json";
        public async Task SaveToJson()
        {
            var jsonSaveObject = JsonSerializer.Serialize(currentShoppingList);
            File.WriteAllText(_saveFile, jsonSaveObject);
        }

        public async Task LoadSaveFile()
        {
            ObservableCollection<ShoppingItem> readSaveFile = new ObservableCollection<ShoppingItem>();
            if (File.Exists(_saveFile) == false) return;
            var rawData = File.ReadAllTextAsync(_saveFile).Result;

            List<ShoppingItem> jObjects = JsonConvert.DeserializeObject<List<ShoppingItem>>(rawData);
            foreach (var item in jObjects)
            {
                readSaveFile.Add(item);
            }
            currentShoppingList = readSaveFile;
        }

        [RelayCommand]
        void Add()
        {
            if (addShoppingItem is not null && addShoppingItem != "")
            {
                currentShoppingList.Add(new ShoppingItem() { Name = addShoppingItem, CheckedOf = false });
            }
            SaveToJson();
        }
        [RelayCommand]
        void GetAll()
        {
            LoadSaveFile();
        }
        [RelayCommand]
        void Delete(ShoppingItem shoppingItem)
        {
            CurrentShoppingList.Remove(shoppingItem);
        }
        [RelayCommand]
        void Clear()
        {
            CurrentShoppingList.Clear();
            SaveToJson();
        }

        [RelayCommand]
        void Sort()
        {
            var sort = CurrentShoppingList.OrderBy(c => c.CheckedOf).ToList();
            CurrentShoppingList.Clear();
            foreach (var item in sort)
            {
                CurrentShoppingList.Add(item);
            }
            SaveToJson();
        }

        [RelayCommand]
        async Task GoToRecipies()
        {
            SaveToJson();
            await Shell.Current.GoToAsync($"{nameof(RecipiesPage)}", true);
        }
    }
}
