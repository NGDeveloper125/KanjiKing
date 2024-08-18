using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using KanjiKingDomain.Models;
using KanjiKingDomain.Services;
using KanjiKingInterface.DatabaseLayer;
using KanjiKingInterface.Pages.EndGame;
using LanguageExt.Common;

namespace KanjiKingInterface.Pages.Game
{
    public class GameViewModel : INotifyPropertyChanged
    {
        private NavigationService navigationService;
        private readonly GameModel gameModel;
        private Round currentRound;
        private List<Round> rounds;
        private int totalRounds;
        private bool waitingForHiragana;
        private int mistakesDone;
        private GameLevel gameLevel;
        private AudioPlayer audioPlayer;

        public GameViewModel(NavigationService navigationService, GameType gameType, GameLevel gameLevel)
        {
            this.navigationService = navigationService;
            this.gameLevel = gameLevel;
            CheckCommand = new RelayCommand(async () => await CheckAnswerAsync(), CanCheckAnswer);

            gameModel = new GameModel(gameType, gameLevel);
            
            audioPlayer = new AudioPlayer();
            IDatabaseService databaseService = new JsonDatabaseService(gameModel.Game.GameType, "KanjiKingDatabase.json");
            rounds = databaseService.GetGameRounds();
            totalRounds = rounds.Count;
            StartNewGameAsync().Wait();    
        }

        private async Task StartNewGameAsync()
        {
            await LoadNewRoundAsync();
            waitingForHiragana = true;
            OnPropertyChanged(nameof(InputLabel));
        }

        private async Task LoadNewRoundAsync()
        {
            // Call your service to get a new round
            kanjiFontSize = 100;
            kanjiBackGroundColor = new SolidColorBrush(Colors.AliceBlue);
            Result<Round> roundResult = RoundService.GetNewRound(gameModel.Game, rounds);
            roundResult.Match(
                        r => currentRound = r,
                        error => throw new Exception(error.Message));
            Kanji = currentRound.Kanji;
            RoundOutOfTotalRounds = $"Round - {gameModel.Game.RoundsPlayed.Count + 1} / {totalRounds}";
            MistakesAllowed = $"Mistakes Left - {gameModel.Game.MistakesAllowed - mistakesDone}";
            UserInput = string.Empty;
            OnPropertyChanged(nameof(KanjiFontSize));
            OnPropertyChanged(nameof(Kanji));
            OnPropertyChanged(nameof(UserInput));
            OnPropertyChanged(nameof(RoundOutOfTotalRounds));
            OnPropertyChanged(nameof(MistakesAllowed));
            OnPropertyChanged(nameof(KanjiBackGroundLabel));
        }

        public string Kanji { get; private set; }
        public string RoundOutOfTotalRounds { get; private set; }
        public string MistakesAllowed { get; private set; }

        private int kanjiFontSize = 100;
        
        public int KanjiFontSize
        {
            get => kanjiFontSize;
            set
            {
                kanjiFontSize = value;
                OnPropertyChanged();
                ((RelayCommand)CheckCommand).RaiseCanExecuteChanged();
            }
        }
        public SolidColorBrush KanjiBackGroundLabel
        {
            get => kanjiBackGroundColor;
            set
            {
                kanjiBackGroundColor = value;
                OnPropertyChanged();
                ((RelayCommand)CheckCommand).RaiseCanExecuteChanged();
            }
        }
        private SolidColorBrush kanjiBackGroundColor = new SolidColorBrush(Colors.AliceBlue);
        
        
        public string UserInput
        {
            get => _userInput;
            set
            {
                _userInput = value;
                OnPropertyChanged();
                ((RelayCommand)CheckCommand).RaiseCanExecuteChanged(); // Ensure the command re-evaluates
            }
        }
        private string _userInput;


        public string InputLabel => waitingForHiragana ? "Hiragana -" : "English -";

        public ICommand CheckCommand { get; }

        private async Task CheckAnswerAsync()
        {
            if (waitingForHiragana)
            {
                if (UserInput == currentRound.Hiragana)
                {
                    waitingForHiragana = false;
                    UserInput = string.Empty;
                    OnPropertyChanged(nameof(InputLabel));
                    OnPropertyChanged(nameof(UserInput));

                    string audioPath = Path.GetFullPath($"..\\..\\Audios\\{currentRound.Sound}.mp3");
                    if (Debugger.IsAttached)
                    {
                        audioPath = Path.GetFullPath($"..\\..\\..\\Audios\\{currentRound.Sound}.mp3");
                    }

                    audioPlayer.PlayAudio(audioPath);
                }
                else
                {
                    await HandleIncorrectAnswerAsync();
                }
            }
            else
            {
                if (UserInput == currentRound.English)
                {
                    await HandleCorrectAnswerAsync();
                }
                else
                {
                    await HandleIncorrectAnswerAsync();
                }
            }
        }

        private bool CanCheckAnswer() => !string.IsNullOrEmpty(UserInput);

        private async Task HandleCorrectAnswerAsync()
        {
            kanjiBackGroundColor = new SolidColorBrush(Colors.Lime);
            OnPropertyChanged(nameof(KanjiBackGroundLabel));
            await Task.Delay(1500);
            gameModel.Game.RoundsPlayed.Add(currentRound.Id);
            if (rounds.Count > gameModel.Game.RoundsPlayed.Count)
            {
                await LoadNewRoundAsync();
                waitingForHiragana = true;
                OnPropertyChanged(nameof(InputLabel));
            }
            else
            {
                HandleEndGame(true);
            }
        }

        private async Task HandleIncorrectAnswerAsync()
        {
            mistakesDone++;
            if (waitingForHiragana)
            {
                Kanji = $"{Kanji} - {currentRound.Hiragana}";
            }
            else
            {
                Kanji = $"{Kanji} - {currentRound.English}";
            }
            kanjiFontSize = 40;
            kanjiBackGroundColor = new SolidColorBrush(Colors.Red);
            OnPropertyChanged(nameof(KanjiBackGroundLabel));
            OnPropertyChanged(nameof(Kanji));
            OnPropertyChanged(nameof(KanjiFontSize));

            string audioPath = Path.GetFullPath($"..\\..\\Audios\\{currentRound.Sound}.mp3");
            if (Debugger.IsAttached)
            {
                audioPath = Path.GetFullPath($"..\\..\\..\\Audios\\{currentRound.Sound}.mp3");
            }
            
            audioPlayer.PlayAudio(audioPath);

            await Task.Delay(1500);
            if (mistakesDone < gameModel.Game.MistakesAllowed)
            {
                await LoadNewRoundAsync();
                waitingForHiragana = true;
                OnPropertyChanged(nameof(InputLabel));
            }
            else
            {
                HandleEndGame(false);
            }
        }

        private void HandleEndGame(bool completed)
        {
            var endGameView = new EndGameView { DataContext = new EndGameViewModel(navigationService,
                                                                                   gameModel.Game.GameType,
                                                                                   gameLevel,
                                                                                   gameModel.Game.RoundsPlayed.Count.ToString(), 
                                                                                   rounds.Count.ToString(), 
                                                                                   completed, 
                                                                                   mistakesDone.ToString()) };

            navigationService.Navigate(endGameView);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
