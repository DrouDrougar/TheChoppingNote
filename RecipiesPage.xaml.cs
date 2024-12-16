using TheChoppingNote.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TheChoppingNote.Models;


namespace TheChoppingNote;

public partial class RecipiesPage : ContentPage
{
	public RecipiesPage(RecipieListViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
        vm.Title = "Recipies";
    }
}