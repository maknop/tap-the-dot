# Tap The Dot
### Contributors: Matt Knop, Luke Monington, Khadijo Muhumed, Gwen McFadden
Capstone project for BACS487 & BACS488 at the University of Northern Colorado. We  
developed an implementation of the Pop the Lock game as a mobile application for  
both Android and IOS.   
<br />

Libraries Used
--------------
<li>Skiasharp</li>
<li>SQLite</li>
<li>.NET Framework</li>
<br />

### 10 Functional User Requirements
1. The level should always appear on the game screen.<br />
2. The play area, the first dot and a bar should appear at the beginning of the game.<br />
3. The player must be able to start the game once the initial components appear.<br />
4. The bar should always move towards the dot.<br />
5. The player must tap the screen when the bar aligns with the dot in order to avoid losing a life.<br />
6. If the player successfully taps 5 dots, they must be moved to the next level.<br />
7. If a player loses all ten of their lives, they must proceed to the end screen.<br />
8. It should be shown that the player has lost when they lose all their lives and their score should be shown at the end screen.<br />
9. After the player has lost, a new screen appears displaying the end game screen.<br />
a. The user will be able to see their score and have the option to go to the leaderboard or go to the main menu.<br />
10. If the user exceeds any top score, they will have the option to enter their name for placement on the leaderboard.<br />

### 16 Functional System Requirements
1. The score shall be increased by 1 for every successful dot tap. <br />
2. The level will proceed after every 5 successful dot taps.<br />
3. The player movement speed will increase every 2 levels.<br />
4. The user is given 10 lives at the beginning of the game.<br />
5. If the user taps while the player is not overlapping with the dot, then the user loses a life.<br />
6. If the user fails to tap while the player moves past the dot, then the user loses a life. <br />
7. If the user has 1 life and loses another life, then the game ends and the end game screen shows up.<br />
8. If the game ends and the user has a score that is higher than the lowest score on the leaderboard, the user will be prompted to <br /> enter their name into a dialog box and the leaderboard will be updated with the user name and score.<br />
9. If the user is not connected to the internet the leaderboard feature is disabled and high scores will not be updated.<br />
10. If the user taps the leaderboard button in the top right, then the game will be paused and the user will be taken to the leaderboard.<br />
11. If the user taps the settings button in the middle, then the game will be paused and the user will be taken to the settings screen.<br />
12. If the user taps the main menu button in the top left, then the game will be paused and the user will be taken to the main menu.<br />
13. If the game is paused and the user taps the Resume button on the main menu screen, the game is resumed.<br />
14. If the game is paused and the user taps the Restart button, a new game begins.<br />
15. If the game is paused while the user is on the main menu when the user taps the Leaderboard button, the Leaderboard will pop up.<br />
a. The scores of the paused game will not reflect on the leaderboard.<br />
16. The Leaderboard can be closed by tapping the “Main Menu” button on the Leaderboard.<br />
