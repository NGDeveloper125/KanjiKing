# KanjiKing

KanjiKing is a Japanese language learning app focused on memorizing Hiragana, Katakana, and (in future updates) Kanji through engaging memory games. This project is being developed as a learning journey into JavaScript, React Native, and frontend development.

## Project Overview

This is an open-source project aimed at helping users learn Japanese characters through interactive gameplay. Feel free to fork and modify the project for your own use or contribute to its development.

### Current Features (Hiragana & Katakana Game)

The first phase of the app focuses on learning Hiragana and Katakana through a memory matching game:
- Users are presented with Japanese characters (Hiragana/Katakana)
- Multiple English translations appear as choices
- Players must select the correct translation to score points
- All character sets are included in the core game files
- Progressive difficulty levels
- Score tracking system

### Future Plans (Kanji Extension)

The next major update will introduce Kanji learning features:
- New memory game format focused on Kanji characters
- Input-based gameplay where users write translations
- Core set of 100 common Kanji words
- API integration for expanding word sets
- Custom word group creation
- Progress tracking system

## Technical Details

### Development Environment
- Expo SDK Version: 52.0.28
- Platform: Android only
- React Native

### Project Structure
```
KANJIKING/
├── assets/
│   ├── music/
│   ├── images/
│── components/
├── domain/
├── hooks/
├── storage/
└── app.json
```

### Key Dependencies
- expo
- react-native
- expo-av (for audio handling)


## Installation

1. Clone the repository:
```bash
git clone [repository-url]
```

2. Install dependencies:
```bash
npm install
```

3. Step into the app folder:
```bash
cd KnajiKing
```

4. Start the development server:
```bash
npx start
```

## Usage

The app features:
- Character selection between Hiragana and Katakana
- Multiple difficulty levels
- Score tracking
- Sound effects and background music (adding soon)
- Settings customization

## Contributing

Contributions are welcome! Feel free to:
1. Fork the project
2. Create your feature branch (`git checkout -b feature/YourNewFeature`)
3. Commit your changes (`git commit -m 'Add some YourNewFeature'`)
4. Push to the branch (`git push origin feature/YourNewFeature`)
5. Open a Pull Request

## License

This project is open source and available under the [MIT License](LICENSE).

## Development Status

Current Version: 1.0.0
- ✅ Basic game mechanics
- ✅ Hiragana and Katakana support
- ✅ Score tracking
- 🚧 Kanji extension (In Development)
- 🚧 API integration (Planned)
- 🚧 Custom word sets (Planned)

## Acknowledgments

- Japanese character data sourced from [[wikipedia](https://en.wikipedia.org/wiki)]

## Contact

NGDeveloper@outlook.com

---
**Note**: This is a learning project and is continuously being improved. Screenshots and additional documentation will be added as the project develops.
