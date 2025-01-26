import { Button, Modal, StyleSheet, Text, View } from 'react-native';
import getRoundData from '../domain/GameDataHandler';
import ButtonSet from './buttonSet';
import { useState, useEffect } from 'react';

function GameWindow(props) {
    const [roundData, setRoundData] = useState({
      roundLetter: {
        english : "",
        jap : ""
      },
      letterGroup : [{
        english : "",
        jap : ""
      },{
        english : "",
        jap : ""
      },{
        english : "",
        jap : ""
      },{
        english : "",
        jap : ""
      },{
        english : "",
        jap : ""
      },{
        english : "",
        jap : ""
      },{
        english : "",
        jap : ""
      },{
        english : "",
        jap : ""
      },{
        english : "",
        jap : ""
      },],
      lettersPlayed : []
    });
    const [gameStarted, setGameStarted] = useState(false); 

    function updateRoundData() {
      setGameStarted(true);
      var newRoundData = getRoundData(props.gameType, roundData.lettersPlayed, 3);
      if(newRoundData !== null) {
        setRoundData(
          newRoundData
        );
      } else {
        console.log("game over");
        GameOver();
      }
    }

    useEffect(() => {
      if(!gameStarted) {
        updateRoundData();
        props.resetRound();
        props.resetScore();
      }
    }, []);

    function handleBackToMenu() {
      props.endGame(false, "");
    }

    function CheckAnswer(answer, buttonColorSetter, rightButtonColorSetter) {
      if(answer === roundData.roundLetter.english) {
        setTimeout(() => {
          buttonColorSetter('white');
          updateRoundData();
        }, 900);
        buttonColorSetter('lawngreen');
        // play success sound
        props.updateScore();
        props.updateRound();
      }
      else {
        setTimeout(() => {
          buttonColorSetter('white');
          rightButtonColorSetter(roundData.roundLetter.english, 'white');
          updateRoundData();
        }, 1200);
        buttonColorSetter('red');
        rightButtonColorSetter(roundData.roundLetter.english, 'lawngreen');
        // play unsuccess sound
        props.updateRound();
      }
    }

    function GameOver() {
      // setTimeout(() => {
         props.endGame(false, "");
    //   }, 2000);
    }

    if (!roundData) {
      return null;
    }

    return (
          <View style={styles.mainContainer}>
            <Text style={{fontSize : 50}}>{roundData.roundLetter.jap}</Text>
            <ButtonSet letters={roundData.letterGroup} level={1} rightLetter={roundData.roundLetter.english} onAnswer={CheckAnswer} />
            <View style={styles.exitContainer}>
              <Button title='Main Menu' onPress={handleBackToMenu} />
            </View>
        </View>
    );
}

const styles = StyleSheet.create({
  mainContainer: {
    height: '70%',
    width: '95%',
    backgroundColor: 'green',
    alignItems: 'center',
    justifyContent: 'center',
    gap: 80,
    paddingBottom: 10,
  }
});

export default GameWindow;