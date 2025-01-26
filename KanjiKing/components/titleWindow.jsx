import { useState } from 'react';
import { StyleSheet, Text, View, } from 'react-native';

function TitleWindow(props) {


    return (
        <View style={styles.TitleContainer}>
        <View style={styles.topContainer}>
          <Text style={{fontSize : 20}}>Score</Text>
          <Text style={{fontSize : 20}}>Hiragana</Text>
          <Text style={{fontSize : 20}}>Round</Text>
        </View>
        <View style={styles.midContainer}>
          <Text style={{fontSize : 20}}>{props.score}</Text>
          <Text style={{fontSize : 20}}>{props.round}</Text>
        </View>
        <View style={styles.botContainer}>
          <Text style={{fontSize : 40}}>Kanji King</Text>
        </View>
      </View>
    );
}

export default TitleWindow;

const styles = StyleSheet.create({
    TitleContainer: {
        height: '20%',
        width: '95%',
        backgroundColor: 'blue'
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