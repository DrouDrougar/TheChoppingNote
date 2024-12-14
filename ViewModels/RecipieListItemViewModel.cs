using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheChoppingNote.Models;

namespace TheChoppingNote.ViewModels
{
    public class RecipieListItemViewModel : BaseViewModel
    {
        private readonly Recipie _recipie;
        public RecipieListItemViewModel(Recipie recipie)
        {
            this._recipie = recipie;
        }

        public string Name
        {
            get { return _recipie.Name; }
            set
            {
                _recipie.Name = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Recipie?> RecipieCollection
        {
            get { return RecipieCollection; }
            set
            {
                RecipieCollection = value;
                OnPropertyChanged();
            }
        }

    }
}
