import { useState } from 'react';
import { StyleSheet, Text, View, TouchableOpacity } from 'react-native';

function ButtonSet(props) {
    const [buttonOneColor, setButtonOneColor] = useState('white');
    const [buttonTwoColor, setButtonTwoColor] = useState('white');
    const [buttonThreeColor, setButtonThreeColor] = useState('white');
    const [buttonFourColor, setButtonFourColor] = useState('white');
    const [buttonFiveColor, setButtonFiveColor] = useState('white');
    const [buttonSixColor, setButtonSixColor] = useState('white');
    const [buttonSevenColor, setButtonSevenColor] = useState('white');
    const [buttonEightColor, setButtonEightColor] = useState('white');
    const [buttonNineColor, setButtonNineColor] = useState('white');

    function getRightButtonSetter(rightLetter, color) {
        switch (rightLetter) {
            case props.letters[0].english:
                setButtonOneColor(color);
                break;
            case props.letters[1].english:
                setButtonTwoColor(color);
                break;
            case props.letters[2].english:
                setButtonThreeColor(color);
                break;
            case props.letters[3].english:
                setButtonFourColor(color);
                break;
            case props.letters[4].english:
                setButtonFiveColor(color);
                break;
            case props.letters[5].english:
                setButtonSixColor(color);
                break;
            case props.letters[6].english:
                setButtonSevenColor(color);
                break;
            case props.letters[7].english:
                setButtonEightColor(color);
                break;
            case props.letters[8].english:
                setButtonNineColor(color);
                break;
            default:
                break;
        }
    }

    switch (props.level) {
        case 1:
            return (
                <View style={styles.setContainer}>
                    <View style={styles.innerContainer}>
                        <TouchableOpacity style={{backgroundColor : buttonOneColor, width : props.letters[0].english.length > 1 ? 70 : 45, alignItems : 'center'}} onPress={() => props.onAnswer(props.letters[0].english, setButtonOneColor, getRightButtonSetter)}>
                            <Text style={{ fontSize: 40 }}>{props.letters[0].english}</Text>
                        </TouchableOpacity>
                        <TouchableOpacity  style={{backgroundColor : buttonTwoColor, width : props.letters[1].english.length > 1 ? 70 : 45, alignItems : 'center'}} onPress={() => props.onAnswer(props.letters[1].english, setButtonTwoColor, getRightButtonSetter)}>
                            <Text style={{ fontSize: 40 }}>{props.letters[1].english}</Text>
                        </TouchableOpacity>
                        <TouchableOpacity  style={{backgroundColor : buttonThreeColor, width : props.letters[2].english.length > 1 ? 70 : 45, alignItems : 'center'}} onPress={() => props.onAnswer(props.letters[2].english, setButtonThreeColor, getRightButtonSetter)}>
                            <Text style={{ fontSize: 40 }}>{props.letters[2].english}</Text>
                        </TouchableOpacity>
                    </View>
                </View>);                
        case 2:
            return (
                <View style={styles.setContainer}>
                    <View style={styles.innerContainer}>
                        <TouchableOpacity  style={{backgroundColor : buttonOneColor, width : props.letters[0].english.length > 1 ? 70 : 45, alignItems : 'center'}} onPress={() => props.onAnswer(props.letters[0].english, setButtonOneColor, () => getRightButtonSetter())}>
                            <Text style={{ fontSize: 40 }}>{props.letters[0].english }</Text>
                        </TouchableOpacity>
                        <TouchableOpacity  style={{backgroundColor : buttonTwoColor, width : props.letters[1].english.length > 1 ? 70 : 45, alignItems : 'center'}} onPress={() => props.onAnswer(props.letters[1].english, setButtonTwoColor, () => getRightButtonSetter())}>
                            <Text style={{ fontSize: 40 }}>{props.letters[1].english}</Text>
                        </TouchableOpacity>
                        <TouchableOpacity  style={{backgroundColor : buttonThreeColor, width : props.letters[3].english.length > 1 ? 70 : 45, alignItems : 'center'}} onPress={() => props.onAnswer(props.letters[2].english, setButtonThreeColor, () => getRightButtonSetter())}>
                            <Text style={{ fontSize: 40 }}>{props.letters[2].english}</Text>
                        </TouchableOpacity>
                    </View>
                        <View style={styles.innerContainer}>
                        <TouchableOpacity  style={{backgroundColor : buttonFourColor, width : props.letters[4].english.length > 1 ? 70 : 45, alignItems : 'center'}} onPress={() => props.onAnswer(props.letters[3].english, setButtonFourColor, () => getRightButtonSetter())}>
                            <Text style={{ fontSize: 40 }}>{props.letters[3].english}</Text>
                        </TouchableOpacity>
                        <TouchableOpacity  style={{backgroundColor : buttonFiveColor, width : props.letters[5].english.length > 1 ? 70 : 45, alignItems : 'center'}} onPress={() => props.onAnswer(props.letters[4].english, setButtonFiveColor, () => getRightButtonSetter())}>
                            <Text style={{ fontSize: 40 }}>{props.letters[4].english}</Text>
                        </TouchableOpacity>
                        <TouchableOpacity  style={{backgroundColor : buttonSixColor, width : props.letters[6].english.length > 1 ? 70 : 45, alignItems : 'center'}} onPress={() => props.onAnswer(props.letters[5].english, setButtonSixColor, () => getRightButtonSetter())}>
                            <Text style={{ fontSize: 40 }}>{props.letters[5].english}</Text>
                        </TouchableOpacity>
                    </View>
                </View>);
        case 3:
            return (
                <View style={styles.setContainer}>
                    <View style={styles.innerContainer}>
                        <TouchableOpacity  style={{backgroundColor : buttonOneColor, width : props.letters[0].english.length > 1 ? 70 : 45, alignItems : 'center'}} onPress={() => props.onAnswer(props.letters[0].english, setButtonOneColor, () => getRightButtonSetter())}>
                            <Text style={{ fontSize: 40 }}>{props.letters[0].english}</Text>
                        </TouchableOpacity>
                        <TouchableOpacity  style={{backgroundColor : buttonTwoColor, width : props.letters[1].english.length > 1 ? 70 : 45, alignItems : 'center'}} onPress={() => props.onAnswer(props.letters[1].english, setButtonTwoColor, () => getRightButtonSetter())}>
                            <Text style={{ fontSize: 40 }}>{props.letters[1].english}</Text>
                        </TouchableOpacity>
                        <TouchableOpacity  style={{backgroundColor : buttonThreeColor, width : props.letters[2].english.length > 1 ? 70 : 45, alignItems : 'center'}} onPress={() => props.onAnswer(props.letters[2].english, setButtonThreeColor, () => getRightButtonSetter())}>
                            <Text style={{ fontSize: 40 }}>{props.letters[2].english}</Text>
                        </TouchableOpacity>
                    </View>
                    <View style={styles.innerContainer}>
                        <TouchableOpacity  style={{backgroundColor : buttonFourColor, width : props.letters[3].english.length > 1 ? 70 : 45, alignItems : 'center'}} onPress={() => props.onAnswer(props.letters[3].english, setButtonFourColor, () => getRightButtonSetter())}>
                            <Text style={{ fontSize: 40 }}>{props.letters[3].english}</Text>
                        </TouchableOpacity>
                        <TouchableOpacity  style={{backgroundColor : buttonFiveColor, width : props.letters[4].english.length > 1 ? 70 : 45, alignItems : 'center'}} onPress={() => props.onAnswer(props.letters[4].english, setButtonFiveColor, () => getRightButtonSetter())}>
                            <Text style={{ fontSize: 40 }}>{props.letters[4].english}</Text>
                        </TouchableOpacity>
                        <TouchableOpacity  style={{backgroundColor : buttonSixColor, width : props.letters[5].english.length > 1 ? 70 : 45, alignItems : 'center'}} onPress={() => props.onAnswer(props.letters[5].english, setButtonSixColor, () => getRightButtonSetter())}>
                            <Text style={{ fontSize: 40 }}>{props.letters[5].english}</Text>
                        </TouchableOpacity>
                    </View>
                    <View style={styles.innerContainer}>
                        <TouchableOpacity  style={{backgroundColor : buttonSevenColor, width : props.letters[6].english.length > 1 ? 70 : 45, alignItems : 'center'}} onPress={() => props.onAnswer(props.letters[6].english, setButtonSevenColor, () => getRightButtonSetter())}> 
                            <Text style={{ fontSize: 40 }}>{props.letters[6].english}</Text>
                        </TouchableOpacity>
                        <TouchableOpacity  style={{backgroundColor : buttonEightColor, width : props.letters[7].english.length > 1 ? 70 : 45, alignItems : 'center'}} onPress={() => props.onAnswer(props.letters[7].english, setButtonEightColor, () => getRightButtonSetter())}>
                            <Text style={{ fontSize: 40 }}>{props.letters[7].english}</Text>
                        </TouchableOpacity>
                        <TouchableOpacity  style={{backgroundColor : buttonNineColor, width : props.letters[8].english.length > 1 ? 70 : 45, alignItems : 'center'}} onPress={() => props.onAnswer(props.letters[8].english, setButtonNineColor, () => getRightButtonSetter())}>
                            <Text style={{ fontSize: 40 }}>{props.letters[8].english}</Text>
                        </TouchableOpacity>
                    </View>
                </View>);
        default:
            break;
    }
}

const styles = StyleSheet.create({
    setContainer: {
        gap : 40
    },
    innerContainer: {
        flexDirection: 'row',
        gap : 50,  
    },
    buttonContainer : {
        width : 45,
        alignItems : 'center'
    }
});
export default ButtonSet;
