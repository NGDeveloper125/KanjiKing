using KanjiKingDomain.Models;
using KanjiKingInterface.Pages.Game;
using KanjiKingInterface.Pages.MainMenu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace KanjiKingInterface.Pages.EndGame
{
    public class EndGameViewModel
    {
        private EndGameModel endGameModel { get; init; }
        private GameType gameType { get; init; }
        private GameLevel gameLevel { get; init; }
        private NavigationService navigationService;
        public string UserKanjiResult {
            get => userKanjiResult;
            set 
            {
                userKanjiResult = value;
                OnPropertyChanged();
            }
        }

        private string userKanjiResult;

        public ICommand CheckCommand { get; }

        public EndGameViewModel(NavigationService navigationService, GameType gameType, GameLevel gameLevel, string successfullKanjis, string totalKanjis, bool completed, string mistakesMade)
        {
            this.endGameModel = new EndGameModel(successfullKanjis, totalKanjis, completed, mistakesMade);
            this.gameType = gameType;
            this.gameLevel = gameLevel;
            this.navigationService = navigationService;

            PlayAgainCommand = new RelayCommand(() => PlayAgain());
            GoToMainMenuCommand = new RelayCommand(() => GoToMainMenu());
            UserKanjiResult = this.endGameModel.Completed ? 
                                  $"Congratulations! {Environment.NewLine}" +
                                  $"You recognise all {this.endGameModel.TotalKanjis} kanjis{Environment.NewLine}" +
                                  $"With {this.endGameModel.MistakesMade} mistakes!"
                                  :
                                  $"Not bad! {Environment.NewLine}" +
                                  $"You recognise {this.endGameModel.SuccessfullKanjis} kanjis{Environment.NewLine}" +
                                  $"Out of {this.endGameModel.TotalKanjis} kanjis!";
        }

        public ICommand PlayAgainCommand { get; }
        private void PlayAgain()
        {
            var gamePage = new GameView { DataContext = new GameViewModel(navigationService, gameType, gameLevel) };
            navigationService.Navigate(gamePage);
        }

        public ICommand GoToMainMenuCommand { get; }
        private void GoToMainMenu()
        {
            var mainMenuPage = new MainMenuView { DataContext = new MainMenuViewModel(navigationService) };
            navigationService.Navigate(mainMenuPage);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

