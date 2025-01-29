import { Button, StyleSheet, Text, View } from 'react-native';

function endGameWindow(props) {

    function goToMainMenu() {
        props.backToMenu("settings", "");
    }
    
    return (
        <View style={styles.windowContainer}>
            <View style={styles.topTitleContainer}>
                <Text style={{fontSize : 40}}>Game Over!</Text>
            </View>
            <View style={styles.midTitleContainer}>
                <Text style={{fontSize : 30}}>You scored {props.score} points</Text>
                <Text style={{fontSize : 30}}>In {props.round} rounds!</Text>
            </View>
            <View style={styles.buttonContainer}>
                <Button title='Main Menu' onPress={goToMainMenu}/>
            </View>
        </View>
         );
}

const styles = StyleSheet.create({
    windowContainer: {
        height: '70%',
        width: '95%',
        backgroundColor: 'transparent',
        alignItems: 'center',
        justifyContent: 'flex-start',
        gap: 150,
        paddingTop: 80,
        paddingBottom: 10,
    },
    topTitleContainer : {
        
    },
    midTitleContainer : {
        alignItems: 'center'
    },
    buttonContainer : {
        
    }
});

export default endGameWindow;