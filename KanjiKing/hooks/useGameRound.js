import { useState, useCallback } from 'react';
import getRoundData from '../domain/GameDataHandler';

export const useGameRound = (gameType, onGameOver) => {
  const [roundData, setRoundData] = useState({
    roundLetter: { english: "", jap: "" },
    letterGroup: Array(9).fill({ english: "", jap: "" }),
    lettersPlayed: []
  });

  const updateRoundData = useCallback(() => {
    const newRoundData = getRoundData(gameType, roundData.lettersPlayed, 3);
    
    if (newRoundData) {
      setRoundData(newRoundData);
    } else {
      onGameOver();
    }
  }, [gameType, roundData.lettersPlayed, onGameOver]);

  const handleAnswer = useCallback((
    answer, 
    correctAnswer, 
    { 
      onCorrect, 
      onIncorrect, 
      setButtonColor, 
      setRightButtonColor, 
      onComplete 
    }
  ) => {
    const isCorrect = answer === correctAnswer;

    if (isCorrect) {
      setButtonColor('lawngreen');
      onCorrect();
      
      setTimeout(() => {
        setButtonColor('#0082ff');
        onComplete();
      }, 900);
    } else {
      setButtonColor('red');
      setRightButtonColor(correctAnswer, 'lawngreen');
      onIncorrect();
      
      setTimeout(() => {
        setButtonColor('#0082ff');
        setRightButtonColor(correctAnswer, '#0082ff');
        onComplete();
      }, 1200);
    }
  }, []);

  return {
    roundData,
    updateRoundData,
    handleAnswer
  };
};