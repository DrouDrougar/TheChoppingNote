using TheChoppingNote.ViewModels;

namespace TheChoppingNote;

public partial class RecipieDetailsPage : ContentPage
{
	public RecipieDetailsPage( RecipieDetailsViewModel detailsVm)
	{
		InitializeComponent();
        BindingContext = detailsVm;
        detailsVm.Title = "Recipie details";
    }
}