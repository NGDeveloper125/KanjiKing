import { useState, useCallback } from 'react';

export const useGameState = () => {
  const [gameState, setGameState] = useState({
    isStarted: false,
    isOver: false
  });

  const startGame = useCallback(() => {
    setGameState({
      isStarted: true,
      isOver: false
    });
  }, []);

  const endGameSession = useCallback(() => {
    setGameState({
      isStarted: false,
      isOver: true
    });
  }, []);

  return {
    gameState,
    startGame,
    endGameSession
  };
};
