import { Button, ImageBackground, StyleSheet, Text, View } from 'react-native';

function endGameWindow(props) {

    function goToMainMenu() {
        props.backToMenu("settings", "");
    }
    
    return (
        <View style={styles.windowContainer}>
            <ImageBackground source={require('../assets/images/end_game_image.jpg')} style={styles.topTitleContainer}>
                <Text style={{fontSize : 40,color: 'black', fontStyle: 'italic', fontWeight : 'bold'}}>Game Over!</Text>
            </ImageBackground>
            <View style={styles.midTitleContainer}>
                <Text style={{fontSize : 30, color: 'white'}}>You scored {props.score} points</Text>
                <Text style={{fontSize : 30, color: 'white'}}>In {props.round} rounds!</Text>
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
        flex : 1,
        width : 300,
        height : 300,
        justifyContent: 'center',
        alignItems: 'center'
    },
    midTitleContainer : {
        alignItems: 'center'
    },
    buttonContainer : {
        
    }
});

export default endGameWindow;