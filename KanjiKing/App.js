import { StatusBar } from 'expo-status-bar';
import { StyleSheet, ImageBackground } from 'react-native';
import { useEffect, useState } from 'react';
import { useUpdateCheck } from './hooks/useUpdateCheck';
import GameWindow from './components/gameWindow';
import SettingsWindow from './components/settingsWindow';
import TitleWindow from './components/titleWindow';
import EndGameWindow from './components/endGameWindow';

export default function App() {

  const [gameStage, setGameStage] = useState("settings");
  const [gameType, setGameType] = useState("hiragana");
  const [gameLevel, setGameLevel] = useState(1);
  const [score, setScore] = useState(0);
  const [round, setRound] = useState(0);
  const { checkForUpdates, isChecking } = useUpdateCheck();

  useEffect(() => {
      checkForUpdates();
  }, []);

  function switchMainWindow(value, gameType, level) {
    setGameType(gameType);
    setGameLevel(level);
    setGameStage(value);
  }

  function updateScore() {
    setScore(score + 1);
  } 

  function resetScore() {
    setScore(0);
  } 
  
  function updateRound() {
    setRound(round + 1);
  } 

  function resetRound() {
    setRound(0);
  }

  function switchWindow(gameStage) {
    switch (gameStage) {
      case "settings":
        return (<SettingsWindow startGame={switchMainWindow} />);
      case "play":
        return (<GameWindow endGame={switchMainWindow} gameType={gameType} gameLevel={gameLevel} updateScore={updateScore}  
          updateRound={updateRound} resetScore={resetScore}  resetRound={resetRound}/>); 
      case "end":
        return (<EndGameWindow  backToMenu={switchMainWindow} score={score} round={round}/>);
      default:
        break;
    }
  }

  return (
    <ImageBackground 
    source={require('./assets/images/background.jpg')}
    style={styles.appContainer}>
      <StatusBar style="auto" />
      <TitleWindow score={score} round={round} />
      {switchWindow(gameStage)}
    </ImageBackground>
  );
}

const styles = StyleSheet.create({
  appContainer: {
    flex: 1,
    backgroundColor: '#fff',
    alignItems: 'center',
    justifyContent: 'center',
  }
});
