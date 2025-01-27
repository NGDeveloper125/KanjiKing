import { StatusBar } from 'expo-status-bar';
import { StyleSheet, View } from 'react-native';
import { useState } from 'react';
import GameWindow from './components/gameWindow';
import SettingsWindow from './components/settingsWindow';
import TitleWindow from './components/titleWindow';
import EndGameWindow from './components/endGameWindow';

export default function App() {

  const [gameStage, setGameStage] = useState("settings");
  const [gameType, setGameType] = useState("hiragana");
  const [score, setScore] = useState(0);
  const [round, setRound] = useState(0);

  function switchMainWindow(value, gameType) {
    setGameType(gameType);
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
        return (<GameWindow endGame={switchMainWindow} gameType={gameType} updateScore={updateScore}  
          updateRound={updateRound} resetScore={resetScore}  resetRound={resetRound}/>); 
      case "end":
        return (<EndGameWindow  backToMenu={switchMainWindow} score={score} round={round}/>);
      default:
        break;
    }
  }

  return (
    <View style={styles.appContainer}>
      <StatusBar style="auto" />
      <TitleWindow score={score} round={round} />
      {switchWindow(gameStage)}
    </View>
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
