import { Button, Modal, StyleSheet, Text, View } from 'react-native';
import BouncyCheckbox from "react-native-bouncy-checkbox";
import { useState } from 'react';

function SettingsWindow(props) {
    const [hiraganaIsChecked, setHiraganaIsChecked] = useState(true);
    const [katakanaIsChecked, setKatakanaIsChecked] = useState(false);
    const [kanjiIsChecked, setIsKanjiChecked] = useState(false);
    const [gameType, setGameType] = useState("hiragana"); 
    
    function handleOnCheck(value, id) {
        switch (id) {
            case "hiragana":
            if(value) {
                setHiraganaIsChecked(true);
                setKatakanaIsChecked(false);
                setIsKanjiChecked(false);
                setGameType("hiragana");
                break;
            }
            break;
            case "katakana":
                if(value) {  
                setHiraganaIsChecked(false);
                setKatakanaIsChecked(true);
                setIsKanjiChecked(false);
                setGameType("katakana");
                break;
                }
            case "kanji":
                if(value) {
                setHiraganaIsChecked(false);
                setKatakanaIsChecked(false);
                setIsKanjiChecked(true);
                setGameType("kanji");
                break;
                }
            default:
            break;
        }
    }

    function handleOnStartGame() {
        props.startGame("play", gameType);
    }

    return (
        <View style={styles.mainContainer}>
                <View style={styles.selectionContainer}>
                <Text style={{fontSize : 30}}>Select Game</Text>
                <View style={styles.settingsContainer}>
                    <BouncyCheckbox
                    nativeID='hiragana'
                    isChecked={hiraganaIsChecked}
                    onPress={(newValue) => handleOnCheck(newValue, "hiragana")}
                    />
                    <Text style={{fontSize : 25}}>Hiragana</Text>
                </View>
                <View style={styles.settingsContainer}>
                    <BouncyCheckbox
                    nativeID='katakana'
                    isChecked={katakanaIsChecked}
                    onPress={(newValue) => handleOnCheck(newValue, "katakana")}
                    />
                    <Text style={{fontSize : 25}}>Katakana</Text>
                </View>
                <View style={styles.settingsContainer}>
                    <BouncyCheckbox
                    nativeID='kanji'
                    isChecked={kanjiIsChecked}
                    onPress={(newValue) => handleOnCheck(newValue, "kanji")}
                    />
                    <Text style={{fontSize : 25}}>Kanji</Text>
                </View>
                </View>
                <View style={styles.startButtonContainer}>
                <Button title="Start" onPress={handleOnStartGame}/>
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
        paddingBottom: 150,
      },
      selectionContainer: {
        flex: 1,
        justifyContent: 'flex-start',
        paddingTop: 150,
        alignItems: 'center',
        gap: 20,
      },
      settingsContainer: {
        flexDirection: 'row',
        width: 140,
      },
      startButtonContainer: {
        width: 150
      }
});

export default SettingsWindow;