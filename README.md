# Blackjack

## Description
"Blackjack" is a console-based application that allows multiple players to play Blackjack against a dealer, with the goal of getting a hand total as close to 21 as possible without busting. I created this game for fun with one of my peers, John Delucia.

Authors: **Ben Vicinelli** and **John Delucia**

Date: **April 2022**

Langauge: **C#**


## Game Components

The game consists of the following classes:
- `Program`: contains the main method that starts the game.
- `Player`: represents the player in the game. Each player has a name, balance, current hand, current wager, win/loss status, current hand total, and a flag for an Ace in their hand.
- `Dealer`: represents the dealer in the game. The dealer has a name, current hand, current hand total, and a flag for an Ace in their hand.
- `DeckOfCards`: represents the deck of cards used in the game. The deck is implemented as a dictionary.
- `Card`: represents a single card and includes methods for drawing a card, randomizing card values, and randomizing card suits.
- `CurrentRound`: contains methods for running the game logic, such as dealing cards, making bets, determining winners and losers, and updating player balances at the end of each round.


## How to Use/Play

1. Clone this repository: `https://github.com/benvic7/Blackjack.git`.
2. In a C# compiler, run the `Program.cs` file to start the game. Or, run `mono Program.exe`.
3. Enter the number of players participating in the game.
4. For each player, enter their name and starting balance.
5. The game will begin, and each player will be dealt two cards along with the dealer.
6. Each player takes a turn and chooses to hit (draw another card) or stay (keep their current hand).
7. The goal is to get a hand total as close to 21 as possible without going over (busting). A hand with a total of 21 is a "Blackjack."
8. After all players complete their turns, the dealer will draw cards until their hand total is 17 or higher.
9. The game will determine the winners and losers:
   - If a player has a higher total than the dealer, they win.
   - If a player has the same or lower total as the dealer, the dealer wins.
10. Player balances will be updated accordingly based on the game outcome.
11. The game will display the updated player balances, and a new round will begin automatically.
12. To play another round, enter 'Y' or 'y' when prompted. To quit the game, enter any other character.


Enjoy the game and good luck at the Blackjack table!
