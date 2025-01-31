
const createHiraganaStore = () => {
    const store = new Map();
    const data = [
        {english: 'a', jap: 'あ'},
        {english: 'i', jap: 'い'},
        {english: 'u', jap: 'う'},
        {english: 'e', jap: 'え'},
        {english: 'o', jap: 'お'},
        {english: 'ka', jap: 'か'},
        {english: 'ki', jap: 'き'},
        {english: 'ku', jap: 'く'},
        {english: 'ke', jap: 'け'},
        {english: 'ko', jap: 'こ'},
        {english: 'sa', jap: 'さ'},
        {english: 'shi', jap: 'し'},
        // {english: 'su', jap: 'す'},
        // {english: 'se', jap: 'せ'},
        // {english: 'so', jap: 'そ'},
        // {english: 'ta', jap: 'た'},
        // {english: 'chi', jap: 'ち'},
        // {english: 'tsu', jap: 'つ'},
        // {english: 'te', jap: 'て'},
        // {english: 'to', jap: 'と'},
        // {english: 'na', jap: 'な'},
        // {english: 'ni', jap: 'に'},
        // {english: 'nu', jap: 'ぬ'},
        // {english: 'ne', jap: 'ね'},
        // {english: 'no', jap: 'の'},
        // {english: 'ha', jap: 'は'},
        // {english: 'hi', jap: 'ひ'},
        // {english: 'fu', jap: 'ふ'},
        // {english: 'he', jap: 'へ'},
        // {english: 'ho', jap: 'ほ'},
        // {english: 'ma', jap: 'ま'},
        // {english: 'mi', jap: 'み'},
        // {english: 'mu', jap: 'む'},
        // {english: 'me', jap: 'め'},
        // {english: 'mo', jap: 'も'},
        // {english: 'ya', jap: 'や'},
        // {english: 'yu', jap: 'ゆ'},
        // {english: 'yo', jap: 'よ'},
        // {english: 'ra', jap: 'ら'},
        // {english: 'ri', jap: 'り'},
        // {english: 'ru', jap: 'る'},
        // {english: 're', jap: 'れ'},
        // {english: 'ro', jap: 'ろ'},
        // {english: 'wa', jap: 'わ'},
        // {english: 'o', jap: 'を'},
    ];

    data.forEach(item => {
        if (!store.has(item.jap)) {
            store.set(item.english, item.jap);
        } else {
            console.warn(`Duplicate entry found for ${item.jap}`);
        }
    });

    return Array.from(store).map(([english, jap]) => ({ english, jap }));
};

export default createHiraganaStore;