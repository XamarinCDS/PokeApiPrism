using GalaSoft.MvvmLight.Command;
using PokeApiPrism.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PokeApiPrism.ViewModels
{
    public class InfoPageViewModel:BaseViewModel
    {
        private static pkmn pokemon;
        private InfoPageViewModel instance;
        public InfoPageViewModel current
        {
            get
            {
                if (instance == null)
                {
                    instance = new InfoPageViewModel();
                }
                return instance;
            }
        }
        public pkmn Pokemon
        {
            get
            {
                return pokemon;
            }
            set
            {
                pokemon = value; OnPropertyChanged("Pokemon");
            }
        }
        public InfoPageViewModel()
        {
            LoadPokemon();
        }
        public void LoadPokemon()
        {
            Pokemon = InfoPageViewModel.pokemon;
        }
        public ICommand executeThis
        {
            get
            {
                return new RelayCommand(LoadPokemon);
            }
        }
        public static void SetPokemon(pkmn pokemon)
        {
            InfoPageViewModel.pokemon = pokemon;
        }
    }
}
