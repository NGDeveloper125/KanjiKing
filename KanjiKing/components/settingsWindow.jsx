import { Button, Modal, StyleSheet, Text, View } from 'react-native';
import BouncyCheckbox from "react-native-bouncy-checkbox";
import { useState } from 'react';

function SettingsWindow(props) {
    const [hiraganaIsChecked, setHiraganaIsChecked] = useState(true);
    const [katakanaIsChecked, setKatakanaIsChecked] = useState(false);
    const [kanjiIsChecked, setIsKanjiChecked] = useState(false);
    const [gameType, setGameType] = useState("hiragana"); 
    const [easyIsChecked, setEasyIsChecked] = useState(true);
    const [normalIsChecked, setNormalIsChecked] = useState(false);
    const [hardIsChecked, setIsHardChecked] = useState(false);
    const [gameLevel, setGameLevel] = useState(1); 
    
    function handleOnGameTypeCheck(value, id) {
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

    function handleOnGameLevelCheck(value, id) {
        switch (id) {
            case "easy":
            if(value) {
                setEasyIsChecked(true);
                setNormalIsChecked(false);
                setIsHardChecked(false);
                setGameLevel(1);
                break;
            }
            break;
            case "normal":
                if(value) {  
                setEasyIsChecked(false);
                setNormalIsChecked(true);
                setIsHardChecked(false);
                setGameLevel(2);
                break;
                }
            case "hard":
                if(value) {
                setEasyIsChecked(false);
                setNormalIsChecked(false);
                setIsHardChecked(true);
                setGameLevel(3);
                break;
                }
            default:
            break;
        }
    }

    function handleOnStartGame() {
        props.startGame("play", gameType, gameLevel);
    }

    return (
        <View style={styles.mainContainer}>
            <View style={styles.selectionContainer}>
                <Text style={{fontSize : 30, color : 'white', fontFamily : 'monospace'}}>Select Game Settings</Text>
                <View style={styles.settingsRowsContainer}>
                    <View style={styles.settingsWrapperContainer} >
                        <View style={styles.settingsContainer}>
                            <BouncyCheckbox
                            nativeID='hiragana'
                            isChecked={hiraganaIsChecked}
                            onPress={(newValue) => handleOnGameTypeCheck(newValue, "hiragana")}
                            />
                            <Text style={{fontSize : 25, color : 'white', fontFamily : 'monospace'}}>Hiragana</Text>
                        </View>
                        <View style={styles.settingsContainer}>
                            <BouncyCheckbox
                            nativeID='katakana'
                            isChecked={katakanaIsChecked}
                            onPress={(newValue) => handleOnGameTypeCheck(newValue, "katakana")}
                            />
                            <Text style={{fontSize : 25, color : 'white', fontFamily : 'monospace'}}>Katakana</Text>
                        </View>
                        <View style={styles.settingsContainer}>
                            <BouncyCheckbox
                            nativeID='kanji'
                            isChecked={kanjiIsChecked}
                            onPress={(newValue) => handleOnGameTypeCheck(newValue, "kanji")}
                            />
                            <Text style={{fontSize : 25, color : 'white', fontFamily : 'monospace'}}>Kanji</Text>
                        </View>
                    </View>
                    <View style={styles.settingsWrapperContainer} >
                        <View style={styles.settingsContainer}>
                            <BouncyCheckbox
                            nativeID='easy'
                            isChecked={easyIsChecked}
                            onPress={(newValue) => handleOnGameLevelCheck(newValue, "easy")}
                            />
                            <Text style={{fontSize : 25, color : 'white', fontFamily : 'monospace'}}>Easy</Text>
                        </View>
                        <View style={styles.settingsContainer}>
                            <BouncyCheckbox
                            nativeID='normal'
                            isChecked={normalIsChecked}
                            onPress={(newValue) => handleOnGameLevelCheck(newValue, "normal")}
                            />
                            <Text style={{fontSize : 25, color : 'white', fontFamily : 'monospace'}}>Normal</Text>
                        </View>
                        <View style={styles.settingsContainer}>
                            <BouncyCheckbox
                            nativeID='hard'
                            isChecked={hardIsChecked}
                            onPress={(newValue) => handleOnGameLevelCheck(newValue, "hard")}
                            />
                            <Text style={{fontSize : 25, color : 'white', fontFamily : 'monospace'}}>Hard</Text>
                        </View>
                    </View>
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
        backgroundColor: 'transparent',
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
      settingsRowsContainer: {
        flexDirection: 'row',
        gap: 70,
      },
      settingsWrapperContainer: {
        paddingTop: 20,
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