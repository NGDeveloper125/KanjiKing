import { useState } from 'react';
import { StyleSheet, Text, View, } from 'react-native';

function TitleWindow(props) {


    return (
        <View style={styles.TitleContainer}>
        <View style={styles.topContainer}>
          <Text style={{fontSize : 20, color: 'white', fontFamily : 'monospace'}}>Score</Text>
          <Text style={{fontSize : 20, color: 'white', fontFamily : 'monospace'}}>Hiragana</Text>
          <Text style={{fontSize : 20, color: 'white', fontFamily : 'monospace'}}>Round</Text>
        </View>
        <View style={styles.midContainer}>
          <Text style={{fontSize : 20, color: 'white', fontFamily : 'monospace'}}>{props.score}</Text>
          <Text style={{fontSize : 20, color: 'white', fontFamily : 'monospace'}}>{props.round}</Text>
        </View>
        <View style={styles.botContainer}>
          <Text style={{fontSize : 40, color: 'white', fontFamily : 'cursive'}}>Kanji King</Text>
        </View>
      </View>
    );
}

export default TitleWindow;

const styles = StyleSheet.create({
    TitleContainer: {
        height: '20%',
        width: '95%',
        backgroundColor: 'transparent'
      },
      topContainer: {
        flexDirection: 'row',
        justifyContent: 'center',
        gap: 80,
        paddingTop: 10,
      },
      midContainer: {
        flexDirection: 'row',
        justifyContent: 'center',
        gap: 280,
      },
      botContainer: {
        flexDirection: 'row',
        justifyContent: 'center',
        paddingTop: 10,
      }
})