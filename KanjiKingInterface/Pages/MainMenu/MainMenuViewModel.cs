using KanjiKingDomain.Models;
using KanjiKingInterface.Pages.Game;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Navigation;

namespace KanjiKingInterface.Pages.MainMenu
{
    public class MainMenuViewModel : INotifyPropertyChanged
    {
        private readonly MainMenuModel _mainMenuModel;
        private NavigationService _navigationService;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<string> GameTypes { get; }
        public ObservableCollection<string> GameLevels { get; }

        public string SelectedGameType
        {
            get => _mainMenuModel.GameTypeInput;
            set
            {
                if (_mainMenuModel.GameTypeInput != value)
                {
                    _mainMenuModel.GameTypeInput = value;
                    OnPropertyChanged();
                }
            }
        }

        public string SelectedGameLevel
        {
            get => _mainMenuModel.GameLevelInput;
            set
            {
                if (_mainMenuModel.GameLevelInput != value)
                {
                    _mainMenuModel.GameLevelInput = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand StartGameCommand { get; }

        public MainMenuViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
            _mainMenuModel = new MainMenuModel();

            GameTypes = new ObservableCollection<string> { "Radicals", "Single Kanjis", "Kanji Words" };
            GameLevels = new ObservableCollection<string> { "Easy", "Normal", "Hard" };

            // Set default selections
            SelectedGameType = GameTypes[0];
            SelectedGameLevel = GameLevels[0];

            StartGameCommand = new RelayCommand(StartGame, CanStartGame);
        }

        private void StartGame()
        {
            GameType gameType = _mainMenuModel.GameType;
            GameLevel gameLevel = _mainMenuModel.GameLevel;

            var gamePage = new GameView { DataContext = new GameViewModel(_navigationService, gameType, gameLevel) };

            _navigationService.Navigate(gamePage);
        }

        private bool CanStartGame() => !string.IsNullOrEmpty(SelectedGameType) && !string.IsNullOrEmpty(SelectedGameLevel);

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
