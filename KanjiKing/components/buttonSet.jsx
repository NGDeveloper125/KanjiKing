import React, { useCallback, useMemo, useState } from 'react';
import { StyleSheet, View, TouchableOpacity, Text } from 'react-native';

const ButtonSet = ({ letters, level, onAnswer }) => {
    const [buttonColors, setButtonColors] = useState(new Array(9).fill('#0082ff'));

    const updateButtonColor = useCallback((index, color) => {
        setButtonColors(prev => {
            const newColors = [...prev];
            newColors[index] = color;
            return newColors;
        });
    }, []);

    const handleAnswer = useCallback((letter, index) => {
        onAnswer(letter, (color) => updateButtonColor(index, color), 
                         (rightLetter,color) => {
                            const rightIndex = letters.findIndex(letter => letter.jap === rightLetter);
                            if (rightIndex !== -1) {
                                updateButtonColor(rightIndex, color);
                            }
                         }
                    );
    }, [letters, onAnswer, updateButtonColor]);

    const renderButton = useCallback((letter, index) => (
        <TouchableOpacity key={`${letter.jap}-${index}`} style={[
            styles.button,
            {
                backgroundColor : buttonColors[index],
                width : 80,
            }
        ]}
        onPress={() => handleAnswer(letter.jap, index)}>
        <Text style={styles.buttonText}>{letter.english}</Text>
        </TouchableOpacity>
    ), [buttonColors, handleAnswer]);

    const buttonRows = useMemo(() => {
        const rows = [];
        const rowCount = level === 1 ? 1 : level === 2 ? 2 : 3;
        
        for (let i = 0; i < rowCount; i++) {
            const rowButtons = letters.slice(i * 3, (i + 1) * 3);
            rows.push(
                <View key={`row-${i}`} style={styles.innerContainer}>
                    {rowButtons.map((letter, j) => renderButton(letter, i * 3 + j))}
                </View>
            );
        }
        return rows;
    }, [level, letters, renderButton]);

    return (
        <View style={styles.setContainer}>
            {buttonRows}
        </View>
    );
};

const styles = StyleSheet.create({
    setContainer: {
        gap : 40
    },
    innerContainer: {
        flexDirection: 'row',
        gap : 30,  
    },
    button: {
        alignItems: 'center',
        justifyContent: 'center',
        borderRadius: 8,
        padding: 8,
      },
      buttonText: {
        fontSize: 40
      }
    });

export default React.memo(ButtonSet);