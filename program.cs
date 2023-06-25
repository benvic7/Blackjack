using System;
using System.Collections;
using System.Collections.Generic;

namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayGame();

        }


        static void PlayGame()
        {
            List<Player> players = PlayerInformation();
            Dealer dealer = (Dealer)DealerInformation();
            CurrentRound round = new CurrentRound();
            DeckOfCards deck = (DeckOfCards)PopulateDictionary();

            int i = 1;

            //Lets make this so that all these methods just call eachother instead of having to call each of these 
            while (true)
            {
                round.beginRound(i);
                round.dealCards(players, dealer);
                round.makeBets(players);
                round.hitOrStay(players, dealer, deck);
                i++;
            }
        }

        static List<Player> PlayerInformation()
        {

            //Create Players

            Console.WriteLine("Hello and Welcome to Black Jack\n");
            Console.Write("Please enter the number of players (Ex. 2): ");

            int numberOfPlayers;

            while (true)
            {
                try
                {
                    numberOfPlayers = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.Write("Invalid Input! Please enter an integer for the number of players (Ex. 2): ");
                    continue;
                }
            }


            List<Player> playerObjects = new List<Player>();
            for (int i = 1; i < numberOfPlayers + 1; i++)
            {
                Console.Write("Player " + i + ", what is your name (Ex. Jack): ");
                string playerName = Console.ReadLine();
                Console.Write("Player " + i + ", what is your total balance in dollars (Ex. 1000): ");

                int playerBalance;
                while (true)
                {
                    try
                    {
                        playerBalance = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.Write("Invalid Input! Please enter an integer value for your balance which is in US dollars (Ex. 1000): ");
                        continue;
                    }
                }

                playerObjects.Add(new Player(playerName, playerBalance));
            }

            return playerObjects;

            //Create Dealer
            //Interesting idea: pull names from a database for the dealer (randomly generate a number then choose a name from the dataBase)


        }

        static Object DealerInformation()
        {
            //Create Dealer
            //Interesting idea: pull names from a database for the dealer (randomly generate a number then choose a name from the dataBase)

            Dealer dealer = new Dealer();

            //temporary hard coded dealer
            dealer.DealerName = "Jack";
            dealer.Balance = 100000;
            return dealer;


        }

        public static Object PopulateDictionary()
        {
            DeckOfCards deck = new DeckOfCards();

            deck.PopulateDictionary("Ace of Clubs", 11);
            deck.PopulateDictionary("Ace of Diamonds", 11);
            deck.PopulateDictionary("Ace of Hearts", 11);
            deck.PopulateDictionary("Ace of Spades", 11);
            deck.PopulateDictionary("King of Clubs", 10);
            deck.PopulateDictionary("King of Diamonds", 10);
            deck.PopulateDictionary("King of Hearts", 10);
            deck.PopulateDictionary("King of Spades", 10);
            deck.PopulateDictionary("Queen of Clubs", 10);
            deck.PopulateDictionary("Queen of Diamonds", 10);
            deck.PopulateDictionary("Queen of Hearts", 10);
            deck.PopulateDictionary("Queen of Spades", 10);
            deck.PopulateDictionary("Jack of Clubs", 10);
            deck.PopulateDictionary("Jack of Diamonds", 10);
            deck.PopulateDictionary("Jack of Hearts", 10);
            deck.PopulateDictionary("Jack of Spades", 10);
            deck.PopulateDictionary("Ten of Clubs", 10);
            deck.PopulateDictionary("Ten of Diamonds", 10);
            deck.PopulateDictionary("Ten of Hearts", 10);
            deck.PopulateDictionary("Ten of Spades", 10);
            deck.PopulateDictionary("Nine of Clubs", 9);
            deck.PopulateDictionary("Nine of Diamonds", 9);
            deck.PopulateDictionary("Nine of Hearts", 9);
            deck.PopulateDictionary("Nine of Spades", 9);
            deck.PopulateDictionary("Eight of Clubs", 8);
            deck.PopulateDictionary("Eight of Diamonds", 8);
            deck.PopulateDictionary("Eight of Hearts", 8);
            deck.PopulateDictionary("Eight of Spades", 8);
            deck.PopulateDictionary("Seven of Clubs", 7);
            deck.PopulateDictionary("Seven of Diamonds", 7);
            deck.PopulateDictionary("Seven of Hearts", 7);
            deck.PopulateDictionary("Seven of Spades", 7);
            deck.PopulateDictionary("Six of Clubs", 6);
            deck.PopulateDictionary("Six of Diamonds", 6);
            deck.PopulateDictionary("Six of Hearts", 6);
            deck.PopulateDictionary("Six of Spades", 6);
            deck.PopulateDictionary("Five of Clubs", 5);
            deck.PopulateDictionary("Five of Diamonds", 5);
            deck.PopulateDictionary("Five of Hearts", 5);
            deck.PopulateDictionary("Five of Spades", 5);
            deck.PopulateDictionary("Four of Clubs", 4);
            deck.PopulateDictionary("Four of Diamonds", 4);
            deck.PopulateDictionary("Four of Hearts", 4);
            deck.PopulateDictionary("Four of Spades", 4);
            deck.PopulateDictionary("Three of Clubs", 3);
            deck.PopulateDictionary("Three of Diamonds", 3);
            deck.PopulateDictionary("Three of Hearts", 3);
            deck.PopulateDictionary("Three of Spades", 3);
            deck.PopulateDictionary("Two of Clubs", 2);
            deck.PopulateDictionary("Two of Diamonds", 2);
            deck.PopulateDictionary("Two of Hearts", 2);
            deck.PopulateDictionary("Two of Spades", 2);

            return deck;
        }
    }

    class Player
    {
        //initializing variables
        private string playerName;
        private int balance;
        private ArrayList currentPlayerHand = new ArrayList();
        private int currentWager;
        private string winOrLose;
        private int currentHandTotal;
        private Boolean hasAce;


        //constructor for player object
        public Player()
        {
            playerName = "";
            balance = 0;
            currentWager = 0;
            winOrLose = "";
            currentHandTotal = 0;
            hasAce = false;
        }

        public Player(string playerName, int balance)
        {
            this.playerName = playerName;
            this.balance = balance;
            currentWager = 0;
            winOrLose = "";
            currentHandTotal = 0;
            hasAce = false;
        }

        //setter and getter for the player's name
        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        //setter and getter for the player's balance
        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        //setter and getter for the player's current wager
        public int CurrentWager
        {
            get { return currentWager; }
            set { currentWager = value; }
        }

        //setter and getter for the player's current hand
        public ArrayList CurrentPlayerHand
        {
            get { return currentPlayerHand; }
            set { currentPlayerHand.Add(value); }
        }

        public string WinOrLose
        {
            get { return winOrLose; }
            set { winOrLose = value; }
        }

        public int CurrentHandTotal
        {
            get { return currentHandTotal; }
            set { currentHandTotal = value; }
        }

        public Boolean HasAce
        {
            get { return hasAce; }
            set { hasAce = value; }
        }

    }

    class Dealer //Dealer Class 
    {
        //Declaring Variables 
        private string dealerName;
        private ArrayList currentDealerHand = new ArrayList();
        private int balance;
        private int currentHandTotal;
        private Boolean hasAce;

        //Default Constructor
        public Dealer()
        {
            dealerName = "";
            balance = 0;
            currentHandTotal = 0;
            hasAce = false;
        }

        //Getters and Setters for Balance
        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        //Getters and Setters for DealerName
        public string DealerName
        {
            get { return dealerName; }
            set { dealerName = value; }
        }

        //Getters and Setter for DealersCurrentHand
        public ArrayList DealersCurrentHand
        {
            get { return currentDealerHand; }
            set { currentDealerHand = value; }
        }

        public int CurrentHandTotal
        {
            get { return currentHandTotal; }
            set { currentHandTotal = value; }
        }

        public Boolean HasAce
        {
            get { return hasAce; }
            set { hasAce = value; }
        }
    }


    class DeckOfCards
    {
        private Dictionary<string, ArrayList> deck = new Dictionary<string, ArrayList>();

        //setter and getter for deck
        public void PopulateDictionary(string key, int value)
        {
            //temporary arrayList, which adds the value passed in and sets the number of appearences to 0
            ArrayList tempAL = new ArrayList();
            tempAL.Add(value);
            tempAL.Add(0);
            deck.Add(key, tempAL);
        }

        public int GetCardValue(string key)
        {
            return (int)deck[key][0];
        }

        public int GetCardCount(string key)
        {
            return (int)deck[key][1];
        }

        public void updateDeck(string key)
        {
            deck[key][1] = (int)deck[key][1] + 1;
            if ((int)deck[key][1] == 4)
            {
                shuffleDeck();
            }
        }

        public void shuffleDeck()
        {
            foreach (KeyValuePair<string, ArrayList> entry in deck)
            {
                // do something with entry.Value or entry.Key
                entry.Value[1] = 0;
            }
        }
    }

    class Card
    {
        public string drawCard()
        {
            return cardValue() + suitType();

        }

        public string cardValue()
        {
            Random rand = new Random();
            int cardValue = rand.Next(1, 14); //select card value

            if (cardValue == 13)
            {
                return "King of ";
            }
            else if (cardValue == 12)
            {
                return "Queen of ";
            }
            else if (cardValue == 11)
            {
                return "Jack of ";
            }
            else if (cardValue == 10)
            {
                return "Ten of ";
            }
            else if (cardValue == 9)
            {
                return "Nine of ";
            }
            else if (cardValue == 8)
            {
                return "Eight of ";
            }
            else if (cardValue == 7)
            {
                return "Seven of ";
            }
            else if (cardValue == 6)
            {
                return "Six of ";
            }
            else if (cardValue == 5)
            {
                return "Five of ";
            }
            else if (cardValue == 4)
            {
                return "Four of ";
            }
            else if (cardValue == 3)
            {
                return "Three of ";
            }
            else if (cardValue == 2)
            {
                return "Two of ";
            }
            else
            {
                return "Ace of ";
            }
        }

        public string suitType()
        {
            Random rand = new Random();
            int suitType = rand.Next(0, 4); //select suit of cards

            if (suitType == 0)
            {
                return "Clubs";
            }
            else if (suitType == 1)
            {
                return "Spades";
            }
            else if (suitType == 2)
            {
                return "Hearts";
            }
            else
            {
                return "Diamonds";
            }
        }
    }

    class CurrentRound
    {
        public Boolean bust(int total)
        {
            return total > 21;

        }

        public int handTotal(ArrayList hand, DeckOfCards deck, Boolean hasAce)
        {
            int total = 0;


            for (int i = 0; i < hand.Count; i++)
            {
                total += deck.GetCardValue((string)hand[i]);

                if (hasAce && bust(total))
                {
                    total -= 10;
                }

            }

            return total;

        }

        public void dealCards(List<Player> players, Dealer dealer)
        {

            Card card = new Card();
            string cardName = "";

            for (int i = 0; i < players.Count; i++)
            {
                cardName = card.drawCard();
                if (cardName.Substring(0, 1) == "A") //if the card is an ace
                {
                    players[i].HasAce = true;
                }
                players[i].CurrentPlayerHand.Add(cardName);
            }
            cardName = card.drawCard();
            if (cardName.Substring(0, 1) == "A") //if the card is an ace
            {
                dealer.HasAce = true;
            }
            dealer.DealersCurrentHand.Add(cardName);

            for (int i = 0; i < players.Count; i++)
            {
                cardName = card.drawCard();
                if (cardName.Substring(0, 1) == "A") //if the card is an ace
                {
                    players[i].HasAce = true;
                }
                players[i].CurrentPlayerHand.Add(cardName);
            }
            cardName = card.drawCard();
            if (cardName.Substring(0, 1) == "A") //if the card is an ace
            {
                dealer.HasAce = true;
            }
            dealer.DealersCurrentHand.Add(cardName);

        }

        public void makeBets(List<Player> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                Console.Write(players[i].PlayerName + ", please enter how much you want to bet (Ex. 50): ");

                //Need to check if the current wager is bigger than the players balance 
                while (true)
                {
                    try
                    {
                        players[i].CurrentWager = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.Write("Please enter an integer value for wager which is in US dollars (Ex. 50): ");
                        continue;
                    }
                }


            }

        }


        //might have to break this into three methods (hitOrStay, hit, stay)
        public void hitOrStay(List<Player> players, Dealer dealer, DeckOfCards deck)
        {
            int i = 0;
            int bustCounter = 0;
            Card card = new Card();
            while (i < players.Count)
            {
                players[i].CurrentHandTotal = handTotal(players[i].CurrentPlayerHand, deck, players[i].HasAce);

                if (players[i].CurrentHandTotal == 21 && players[i].CurrentPlayerHand.Count == 2) //Check for blackjack
                {
                    Console.Write("\nBLACKJACK! " + players[i].PlayerName + ", your cards are: " +
                    players[i].CurrentPlayerHand[0] + " " + players[i].CurrentPlayerHand[1] + " (" + players[i].CurrentHandTotal + ")\n");
                    players[i].Balance += players[i].CurrentHandTotal / 2; //3 to 2 return on BLACKJACK
                    i++;

                }
                else //prompt the user to hit or stay
                {
                    Console.Write("\n" + players[i].PlayerName + ", your cards are: ");

                    for (int j = 0; j < players[i].CurrentPlayerHand.Count; j++)
                    {
                        Console.Write(players[i].CurrentPlayerHand[j] + " ");
                    }
                    Console.Write("(" + players[i].CurrentHandTotal + ")");

                    Console.Write("\nThe dealer's card is: " + dealer.DealersCurrentHand[0]);
                    Console.Write("\n Hit (h) or stay (s): ");


                    string userInput = Console.ReadLine();
                    while (true)
                    {
                        if (userInput.ToLower() == "h") //player hits
                        {
                            //draw a card and find new hand total
                            players[i].CurrentPlayerHand.Add(card.drawCard());
                            players[i].CurrentHandTotal = handTotal(players[i].CurrentPlayerHand, deck, players[i].HasAce);

                            if (bust(players[i].CurrentHandTotal)) //player busts
                            {
                                bustCounter++;
                                Console.Write("\nBUST " + players[i].PlayerName + ", your cards are: "); //tell user they busted
                                for (int j = 0; j < players[i].CurrentPlayerHand.Count; j++) //print users hand
                                {
                                    Console.Write(players[i].CurrentPlayerHand[j] + " ");
                                }
                                Console.Write("(" + players[i].CurrentHandTotal + ")\n"); //print value of the hand next to their cards

                                i++; //increment to next player
                            }
                            else if (players[i].CurrentHandTotal == 21) //player gets 21
                            {
                                Console.Write(players[i].PlayerName + ", your cards are: "); //print players cards
                                for (int j = 0; j < players[i].CurrentPlayerHand.Count; j++)
                                {
                                    Console.Write(players[i].CurrentPlayerHand[j] + " ");
                                }
                                Console.Write("(" + dealer.CurrentHandTotal + ")\n");
                                i++;
                            }
                            break;

                        }
                        else if (userInput.ToLower() == "s") //user stays
                        {
                            i++;
                            break;
                        }
                        else
                        {
                            Console.Write("Invalid Input: Write 'h' for hit and 's' for stay: ");
                            userInput = Console.ReadLine();
                        }
                    }

                }

            }

            int k = 2;

            dealer.CurrentHandTotal = handTotal(dealer.DealersCurrentHand, deck, dealer.HasAce);

            Console.Write("\nThe dealers cards are: " + dealer.DealersCurrentHand[0] + " " + dealer.DealersCurrentHand[1] + " ");

            while (dealer.CurrentHandTotal < 17 && bustCounter != players.Count)
            {
                dealer.DealersCurrentHand.Add(card.drawCard());
                dealer.CurrentHandTotal = handTotal(dealer.DealersCurrentHand, deck, dealer.HasAce);
                Console.Write(dealer.DealersCurrentHand[k] + " ");
                k++;
            }

            Console.Write("(" + dealer.CurrentHandTotal + ")");

            determineWinnersAndLosers(players, dealer, deck);
        }



        public void determineWinnersAndLosers(List<Player> players, Dealer dealer, DeckOfCards deck)
        {
            Console.WriteLine("\n");

            for (int i = 0; i < players.Count; i++)
            {

                if (players[i].CurrentHandTotal > 21)
                {
                    players[i].WinOrLose = "L";
                }
                else if (players[i].CurrentHandTotal > dealer.CurrentHandTotal)
                {
                    players[i].WinOrLose = "W";
                }
                else if (players[i].CurrentHandTotal < dealer.CurrentHandTotal)
                {
                    if (dealer.CurrentHandTotal <= 21)
                    {
                        players[i].WinOrLose = "L";
                    }
                    else
                    {
                        players[i].WinOrLose = "W";
                    }
                }
                else
                {
                    players[i].WinOrLose = "P";
                }

            }
            updateBalances(players, dealer, deck);
        }

        public void updateBalances(List<Player> players, Dealer dealer, DeckOfCards deck)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].WinOrLose == "L")
                {
                    players[i].Balance -= players[i].CurrentWager;
                    dealer.Balance += players[i].CurrentWager;
                }
                else if (players[i].WinOrLose == "W")
                {
                    players[i].Balance += players[i].CurrentWager;
                    dealer.Balance -= players[i].CurrentWager;
                }
            }
            endRound(players, dealer, deck);
        }

        public void beginRound(int roundNumber)
        {
            Console.WriteLine("\nRound " + roundNumber + ": Place Your Bets\n");

        }

        public void endRound(List<Player> players, Dealer dealer, DeckOfCards deck)
        {
            Console.WriteLine("Updated Player Balances: \n");
            //update deck
            for (int i = 0; i < players.Count; i++)
            {

                Console.WriteLine(players[i].PlayerName + "'s Balance: " + players[i].Balance);

                for (int j = 0; j < players[i].CurrentPlayerHand.Count; j++)
                {
                    //update deck
                    string card = (string)players[i].CurrentPlayerHand[j];
                    deck.updateDeck(card);

                }
            }


            //reset all variables
            for (int i = 0; i < players.Count; i++)
            {
                players[i].CurrentHandTotal = 0;
                players[i].CurrentPlayerHand.Clear();
                players[i].CurrentWager = 0;
                players[i].WinOrLose = "";
                players[i].HasAce = false;
            }
            dealer.CurrentHandTotal = 0;
            dealer.DealersCurrentHand.Clear();

        }
    }
}