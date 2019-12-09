using GalaSoft.MvvmLight.Command;
using PokeApiPrism.Model;
using PokeApiPrism.Service;
using PokeApiPrism.Views;
using Prism.Mvvm;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace PokeApiPrism.ViewModels
{
    class MainPageViewModel:BindableBase, INotifyPropertyChanged
    {
        private ObservableCollection<pkmn> pokes;
        private ApiService api;
        private pkmn pokemon;
        private bool isRefreshing;
        public pkmn Pokemon
        {
            get
            {
                return pokemon;
            }
            set
            {
                pokemon = value; RaisePropertyChanged("Pokemon");/*OnPropertyChanged("Pokemon");*/
            }
        }
        public bool IsRefreshing
        {
            get
            {
                return isRefreshing;
            }
            set
            {
                isRefreshing = value; RaisePropertyChanged("IsRefreshing"); /*OnPropertyChanged("IsRefreshing");*/
            }
        }
        public ObservableCollection<pkmn> Pokes
        {
            get
            {
                return pokes;
            }
            set
            {
                pokes = value; RaisePropertyChanged("Pokes"); /*OnPropertyChanged("Pokes");*/
            }
        }
        public MainPageViewModel()
        {
            api = new ApiService();
            LoadData();
        }
        public async void LoadData()
        {
            IsRefreshing = true;
            Pokes = await api.GetPkmns();
            IsRefreshing = false;
        }
        public ICommand RefreshingCommand
        {
            get
            {
                return new RelayCommand(LoadData);
            }
        }
        public ICommand itemTappedCommand
        {
            get
            {
                return new RelayCommand(OpenMenu);
            }
        }
        public void OpenMenu()
        {
            //var md = (MasterDetailPage)Application.Current.MainPage;
            //var menu = ref (MasterP)md.Master;
            //menu.loadPokemon();
            //Application.Current.MainPage = md;

            InfoPageViewModel.SetPokemon(Pokemon);
            PopupNavigation.PushAsync(new InfoPage());
        }
    }
}
