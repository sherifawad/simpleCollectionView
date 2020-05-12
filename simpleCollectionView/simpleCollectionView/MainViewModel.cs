using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace simpleCollectionView
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public bool IsFav { get; set; }
        public Color IsFavColor { get; set; }
        public ObservableCollection<Model> Items { get; set; }

        public Command FavoriteCommand => new Command(async (parameter) => await FavoriteAsync(parameter));

        public event PropertyChangedEventHandler PropertyChanged = (s,e) => { };

        private Task FavoriteAsync(object parameter)
        {
            IsFav = !IsFav;
            IsFavColor = IsFav ? Color.LightGreen : Color.Black;
            return Task.FromResult(true);
        }

        public MainViewModel()
        {
            Items = new ObservableCollection<Model>() {
                new Model { ImageUrl = "", Title = "First Title", Description = "First Description" },
                new Model { ImageUrl = "", Title = "Second Title", Description = "Second Description" },
                new Model { ImageUrl = "", Title = "Third Title", Description = "Third Description" }
                };

        }
    }
}
