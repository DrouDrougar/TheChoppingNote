using CommunityToolkit.Mvvm.ComponentModel;

namespace TheChoppingNote.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? title;

    }
}
