import { StatusBar } from 'expo-status-bar';
import { Button, StyleSheet, Switch, Text, View, Modal } from 'react-native';
import { useState } from 'react';
import GameWindow from './components/gameWindow';
import SettingsWindow from './components/settingsWindow';
import TitleWindow from './components/titleWindow';

export default function App() {

  const [gameStarted, setGameStarted] = useState(false);
  const [gameType, setGameType] = useState("hiragana");
  const [score, setScore] = useState(0);
  const [round, setRound] = useState(0);

  function switchMainWindow(value, gameType) {
    setGameType(gameType);
    setGameStarted(value);
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

  return (
    <View style={styles.appContainer}>
      <StatusBar style="auto" />
      <TitleWindow score={score} round={round} />
      {gameStarted ? <GameWindow endGame={switchMainWindow} gameType={gameType} updateScore={updateScore}  updateRound={updateRound} resetScore={resetScore}  resetRound={resetRound}/> 
                   : <SettingsWindow startGame={switchMainWindow} />}
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
