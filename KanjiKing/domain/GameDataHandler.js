import createHiraganaStore from "../storage/hiraganaStore";

function getGameLetters(gameType) {
    var letters = [];
    switch (gameType) {
        case "hiragana":
            letters = createHiraganaStore();
            break;
        case "katakana":
            //letters = KatakanaStore();
            break;
        case "kanji":
            //letters = KanjiStore();
            break;
        default:
            break;
    }
    return letters;
}

function generateRoundLetter(letters, playedLetters) {
    var filteredLetters = letters.filter((letter) => {
        return !playedLetters.some(playedLetter => playedLetter.jap === letter.jap);
    });

    if(filteredLetters.length === 0)
    {
        return null;
    }
    return filteredLetters[Math.floor(Math.random() * filteredLetters.length)];
}

function generateRoundFakeLetters(letters, roundLetter, level) {
    var filteredLetters = letters.filter((letter) => 
        letter.jap !== roundLetter.jap
    );

    var pickedLetters = [];
    while(pickedLetters.length < (level - 1)) {
        let randomLetter = filteredLetters[Math.floor(Math.random() * filteredLetters.length)];
        
        // Check if randomLetter is defined and not already picked
        if (randomLetter && !pickedLetters.some(letter => letter.jap === randomLetter.jap)) {
            pickedLetters.push(randomLetter);
        }
    }

    return mixLetters([...pickedLetters, roundLetter]);
}

function mixLetters(lettersToMix) {
    let currentIndex = lettersToMix.length;

    while(currentIndex != 0) {
        let randomIndex = Math.floor(Math.random() * currentIndex);
        currentIndex--;

        [lettersToMix[currentIndex], lettersToMix[randomIndex]] = [lettersToMix[randomIndex], lettersToMix[currentIndex]];
    }

    return lettersToMix;
}


function getRoundData(gameType, playedLetters, level) {
    const letters = getGameLetters(gameType);
    
    if(playedLetters.length === letters.length) {
        return null;
    }

    const roundLetter = generateRoundLetter(letters, playedLetters);
    if(!roundLetter){
        return null;
    }

    console.log("round letter: " + roundLetter.english + " " + roundLetter.jap);
    const roundFakeLetters = generateRoundFakeLetters(letters, roundLetter, level);
    roundFakeLetters.map((letter => {
        console.log("fake letter: " + letter.english + " " + letter.jap);
    }))
    return ({
        roundLetter: roundLetter,
        letterGroup : roundFakeLetters,
        lettersPlayed : [...playedLetters, roundLetter]
      });
}

export default getRoundData;