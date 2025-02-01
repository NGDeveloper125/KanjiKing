import { Button, ImageBackground, StyleSheet, Text, View } from 'react-native';
import ButtonSet from './buttonSet';
import { useEffect, useCallback } from 'react';
import { useGameState } from '../hooks/useGameState';
import { useGameRound } from '../hooks/useGameRound';

const GameWindow = ({endGame, gameType, gameLevel, updateScore, updateRound, resetScore, resetRound}) => {

  const { gameState, startGame, endGameSession } = useGameState();

  const onGameOver = useCallback(() => {
    endGameSession();
    endGame("end", "");
  }, [endGame, endGameSession]);

  const { roundData, updateRoundData, handleAnswer } = useGameRound(gameType, gameLevel, onGameOver);

  useEffect(() => {
    if (!gameState.isStarted) {
      initializeGame();
    }
  }, []);

  const initializeGame = useCallback(() => {
    startGame();
    resetRound();
    resetScore();
    updateRoundData();
  }, [startGame, resetRound, resetScore, updateRoundData]);

  const handleBackToMenu = useCallback(() => {
    endGameSession();
    endGame("settings", "");
  }, [endGame, endGameSession]);

  const checkAnswer = useCallback((answer, buttonColorSetter, rightButtonColorSetter) => {
    handleAnswer(
      answer, 
      roundData.roundLetter.jap,
      {
        onCorrect: () => {
          updateScore();
          updateRound();
        },
        onIncorrect: () => {
          updateRound();
        },
        setButtonColor: buttonColorSetter,
        setRightButtonColor: rightButtonColorSetter,
        onComplete: updateRoundData
      }
    );
  }, [roundData, updateScore, updateRound, handleAnswer, updateRoundData]);

  if (!roundData || !roundData.letterGroup) {
    return <LoadingView />;
  }

  return (
    <View style={styles.mainContainer}>
      <ImageBackground 
        style={styles.backImageContainer} 
        source={require('../assets/images/mainpic.jpg')}
      >
        <View style={styles.roundLetterContainer}>
          <Text style={{fontSize: 50, color: 'white', padding: 5}}>
            {roundData.roundLetter.jap}
          </Text>
        </View>
        {roundData.letterGroup.length > 0 && (
          
        <ButtonSet 
          letters={roundData.letterGroup}
          level={gameLevel}
          onAnswer={checkAnswer}
        />
        )}
      </ImageBackground>
      
      <View style={styles.exitContainer}>
        <Button 
          title='Main Menu' 
          onPress={handleBackToMenu}
        />
      </View>
    </View>
  );
};

const LoadingView = () => (
  <View style={styles.loadingContainer}>
    <Text>Loading...</Text>
  </View>
);

const styles = StyleSheet.create({
  mainContainer: {
    height: '70%',
    width: '95%',
    backgroundColor: 'transparent',
    alignItems: 'center',
    justifyContent: 'center',
    gap: 80,
    paddingBottom: 10,
  },
  backImageContainer: {
    flex: 1,
    width: 345,
    alignItems: 'center',
    paddingTop: 50,
    justifyContent: 'flex-start',
    gap: 50
  },
  roundLetterContainer : {
    backgroundColor: 'black'
  },
  loadingContainer: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center'
  },
  exitContainer: {
    marginTop: 20
  }
});

export default GameWindow;