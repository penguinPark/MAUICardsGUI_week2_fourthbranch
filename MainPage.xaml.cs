using Microsoft.UI.Xaml.Controls;
using RaceTo21;
using System.Reflection;
using static System.Formats.Asn1.AsnWriter;

namespace MAUICardsGUI;
public partial class MainPage : ContentPage
{
    // need to have draw and stay work
    // need to start new game if people want to
    // scoring and end of game should work
    int numOfPlayers; // number of players in current game
    List<Player> players = new List<Player>(); // list of objects containing player data
    Deck deck = new Deck(); // deck of cards
    int currentPlayer = 0; // current player on list
    public RaceTo21.Task nextTask = RaceTo21.Task.GetNumberOfPlayers; // keeps track of game state through enum Task
    Player previousWinner; // to keep track of the player who won
    public int winningScore; // variable to represent the winning total score
    public bool finishedTask = false;
    public string response;
    int count; // counter
    int fullNumber = 0; // full winning score number
    int numResponse; // response
    int intro = 0;
    List<Label> FinalScores;
    public MainPage()
    {
        InitializeComponent();
        FinalScores = new List<Label> { FinalTotalScore, FinalTotalScore2, FinalTotalScore3, FinalTotalScore4, FinalTotalScore5, FinalTotalScore6, FinalTotalScore7, FinalTotalScore8 };
    }
   
    public void DoNextTask()
    {
        if (nextTask == RaceTo21.Task.GetNumberOfPlayers)
        {
            StartButton.IsVisible = false;
            gameLabel.Text = "How many players?";
            NumberOfPlayers.IsVisible = true;
            NumberPlayersButton.IsVisible = true;
        }
        else if (nextTask == RaceTo21.Task.GetNames)
        {
            InvalidNumbersText.IsVisible = false;
            NumberOfPlayers.IsVisible = false;
            NumberPlayersButton.IsVisible = false;
            gameLabel.Text = "What is your name?";
            NamesOfPlayers.IsVisible = true;
            NameButton.IsVisible = true;
        }
        else if (nextTask == RaceTo21.Task.AgreedScore)
        {
            InvalidName.IsVisible = false;
            NamesOfPlayers.IsVisible = false;
            NameButton.IsVisible = false;
            TotalWinningScore.IsVisible = true;
            ScoreButton.IsVisible = true;
            gameLabel.Text = "What does " + players[intro].Name + " want the winning score to be?";

        }
        else if (nextTask == RaceTo21.Task.Intro)
        {
            deck.Shuffle();
            InvalidScore.IsVisible = false;
            TotalWinningScore.IsVisible = false;
            ScoreButton.IsVisible = false;
            gameLabel.IsVisible = false;
            TotalScore.IsVisible = true;
            NonScoreButton.IsVisible = true;
            TotalScore.Text = "Total Winning Score: " + winningScore;
            while (currentPlayer < players.Count)
            {
                PlayersNames.IsVisible = true;
                PlayersNames.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                currentPlayer++;
                while (currentPlayer < players.Count)
                {
                    PlayersNames2.IsVisible = true;
                    PlayersNames2.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                    currentPlayer++;
                    while (currentPlayer < players.Count)
                    {
                        PlayersNames3.IsVisible = true;
                        PlayersNames3.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                        currentPlayer++;
                        while (currentPlayer < players.Count)
                        {
                            PlayersNames4.IsVisible = true;
                            PlayersNames4.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                            currentPlayer++;
                            while (currentPlayer < players.Count)
                            {
                                PlayersNames5.IsVisible = true;
                                PlayersNames5.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                                currentPlayer++;
                                while (currentPlayer < players.Count)
                                {
                                    PlayersNames6.IsVisible = true;
                                    PlayersNames6.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                                    currentPlayer++;
                                    while (currentPlayer < players.Count)
                                    {
                                        PlayersNames7.IsVisible = true;
                                        PlayersNames7.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + "  Game Score: " + players[currentPlayer].score;
                                        currentPlayer++;
                                        while (currentPlayer <= players.Count)
                                        {
                                            PlayersNames8.IsVisible = true;
                                            PlayersNames8.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + "  Game Score: " + players[currentPlayer].score;
                                            currentPlayer++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        else if (nextTask == RaceTo21.Task.FirstTurn)
        {
            NonScoreButton.IsVisible = false;
            DrawScoreButton.IsVisible = true;
            DrawCard.IsVisible = true;
            StayScoreButton.IsVisible = true;
            DrawCard.Text = "Do you want to draw a card " + players[intro].Name;
            currentPlayer = 0;
            if (players[currentPlayer].cards.Count == 0)
            {
                while (currentPlayer < players.Count)
                {
                    Card card = deck.DealTopCard();
                    players[currentPlayer].cards.Add(card);
                    players[currentPlayer].score = ScoreHand(players[currentPlayer]);
                    PlayersNames.IsVisible = true;
                    PlayersNames.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                    currentPlayer++;
                    while (currentPlayer < players.Count)
                    {
                        card = deck.DealTopCard();
                        players[currentPlayer].cards.Add(card);
                        players[currentPlayer].score = ScoreHand(players[currentPlayer]);
                        PlayersNames2.IsVisible = true;
                        PlayersNames2.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                        currentPlayer++;
                        while (currentPlayer < players.Count)
                        {
                            card = deck.DealTopCard();
                            players[currentPlayer].cards.Add(card);
                            players[currentPlayer].score = ScoreHand(players[currentPlayer]);
                            PlayersNames3.IsVisible = true;
                            PlayersNames3.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                            currentPlayer++;
                            while (currentPlayer < players.Count)
                            {
                                card = deck.DealTopCard();
                                players[currentPlayer].cards.Add(card);
                                players[currentPlayer].score = ScoreHand(players[currentPlayer]);
                                PlayersNames4.IsVisible = true;
                                PlayersNames4.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                                currentPlayer++;
                                while (currentPlayer < players.Count)
                                {
                                    card = deck.DealTopCard();
                                    players[currentPlayer].cards.Add(card);
                                    players[currentPlayer].score = ScoreHand(players[currentPlayer]);
                                    PlayersNames5.IsVisible = true;
                                    PlayersNames5.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                                    currentPlayer++;
                                    while (currentPlayer < players.Count)
                                    {
                                        card = deck.DealTopCard();
                                        players[currentPlayer].cards.Add(card);
                                        players[currentPlayer].score = ScoreHand(players[currentPlayer]);
                                        PlayersNames6.IsVisible = true;
                                        PlayersNames6.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                                        currentPlayer++;
                                        while (currentPlayer < players.Count)
                                        {
                                            card = deck.DealTopCard();
                                            players[currentPlayer].cards.Add(card);
                                            players[currentPlayer].score = ScoreHand(players[currentPlayer]);
                                            PlayersNames7.IsVisible = true;
                                            PlayersNames7.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + "  Game Score: " + players[currentPlayer].score;
                                            currentPlayer++;
                                            while (currentPlayer <= players.Count)
                                            {
                                                card = deck.DealTopCard();
                                                players[currentPlayer].cards.Add(card);
                                                players[currentPlayer].score = ScoreHand(players[currentPlayer]);
                                                PlayersNames8.IsVisible = true;
                                                PlayersNames8.Text = "Player #" + (currentPlayer + 1) + " name: " + players[currentPlayer].Name + "  Game Score: " + players[currentPlayer].score;
                                                currentPlayer++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        else if (nextTask == RaceTo21.Task.PlayerTurn)
        {
            
            while (players[count].status == PlayerStatus.stay || players[count].status == PlayerStatus.bust)
            {
                count = (count + 1) % players.Count;
                if (!CheckActivePlayers())
                {
                    Player winner = StayScore();
                    AnnounceWinner(winner);
                    NextButton.IsVisible = true;
                    break;
                }
            }
            DrawCard.Text = "Do you want to draw a card " + players[count].Name;
            currentPlayer = 0;
            while (currentPlayer < players.Count)
            {
           
                PlayersNames.Text = "Player 1 name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                currentPlayer++;
                while (currentPlayer < players.Count)
                {
                    PlayersNames2.Text = "Player 2 name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                    currentPlayer++;
                    while (currentPlayer < players.Count)
                    {
                        PlayersNames3.Text = "Player 3 name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                        currentPlayer++;
                        while (currentPlayer < players.Count)
                        {
                            PlayersNames4.Text = "Player 4 name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                            currentPlayer++;
                            while (currentPlayer < players.Count)
                            {
                                PlayersNames5.Text = "Player 5 name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                                currentPlayer++;
                                while (currentPlayer < players.Count)
                                {
                                    PlayersNames6.Text = "Player 6 name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                                    currentPlayer++;
                                    while (currentPlayer < players.Count)
                                    {
                                        PlayersNames7.Text = "Player 7 name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                                        currentPlayer++;
                                        while (currentPlayer < players.Count)
                                        {
                                            PlayersNames8.Text = "Player 8 name: " + players[currentPlayer].Name + " Game Score: " + players[currentPlayer].score;
                                            currentPlayer++;
                                        }
                                    }
                                }
                            }
                        }
                    }
               }
        }
            int winningIndex = Reached21();
            if (winningIndex != -1)
            {
                AnnounceWinner(players[winningIndex]);
                NextButton.IsVisible = true;
            }
            else
            {
                currentPlayer++;
                if (currentPlayer > players.Count - 1)
                {
                    currentPlayer = 0; // back to the first player...
                }
                nextTask = RaceTo21.Task.PlayerTurn;
            }
        }
        else if (nextTask == RaceTo21.Task.GameOver)
        {
            DoFinalScoring();
        }
        else if (nextTask == RaceTo21.Task.Final)
        {
            FinalTask();
        }
}

    public int Reached21()
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].score == 21)
            {
                return i;
            }
        }
        return -1;
    }

    public void AnnounceWinner(Player player)
    {
        if (player != null)
        {
            player.status = PlayerStatus.win;
            Status.IsVisible = true;
            Status.Text = player.Name + " wins this round!"; 
        }
        else
        {
            Status.IsVisible = true;
            Status.Text = "Everyone busted!";
        }
    }

    public int ScoreHand(Player player)
    {
        int score = 0;
        foreach (Card card in player.cards)
        { 
            string faceValue = card.ID[0].ToString(); // made string faceValue to show the cardName string that the player has
            switch (faceValue)
            {
                case "K":
                case "Q":
                case "J":
                case "1": // to make sure that the 10 card will score +10
                    score = score + 10;
                    break;
                case "A":
                    score = score + 1;
                    break;
                default:
                    score = score + int.Parse(faceValue);
                    break;
            }
        }
        return score;
    }

    private void StartButton_Clicked(object sender, EventArgs e)
    {
        DoNextTask();
    }

    private void NumberPlayersButton_Clicked(object sender, EventArgs e)
    {
        response = NumberOfPlayers.Text;
        if (int.TryParse(response, out numOfPlayers) == false || numOfPlayers < 2 || numOfPlayers > 8) // if they type less than 2 or greater than 8, it will not run 
        {
            InvalidNumbersText.IsVisible = true; // it will say that it is invalid if what the user inputs is NOT the numbers 2-8
        }
        else
        {
            finishedTask = true;
            nextTask = RaceTo21.Task.GetNames;
            DoNextTask();
        }
    }

    private void NameButton_Clicked(object sender, EventArgs e)
    {
        string PlayerName = NamesOfPlayers.Text;
        if (PlayerName == null)
        {
            InvalidName.IsVisible = true;
        }
        else if (PlayerName.Length < 1)
        {
            InvalidName.IsVisible = true;
        }
        else
        {
            players.Add(new Player(PlayerName));
            NamesOfPlayers.Text = "";
            count++;
            if (numOfPlayers == count)
            {
                finishedTask = true;
                count = 0;
                nextTask = RaceTo21.Task.AgreedScore;
                DoNextTask();
            }
        }
    }
    private void ScoreButton_Clicked(object sender, EventArgs e)
    {
        string response = TotalWinningScore.Text; // their input
        if (int.TryParse(response, out numResponse) == false || numResponse < 50 || numResponse > 500) // if they type less than 2 or greater than 8, it will not run 
        {
            InvalidScore.IsVisible = true; // it will say that it is invalid if what the user inputs is NOT the numbers 2-8
        }
        else
        {
            intro++;
            fullNumber += numResponse;
            TotalWinningScore.Text = "";
            count++;
            if (players.Count == count)
            {
                count = 0;
                intro = 0;
                winningScore = fullNumber / players.Count;
                finishedTask = true;
                nextTask = RaceTo21.Task.Intro;
                DoNextTask();
            }
            DoNextTask();
        }
    }

    private void NonScoreButton_Clicked(object sender, EventArgs e)
    {
        nextTask = RaceTo21.Task.FirstTurn;
        DoNextTask();
    }


    private void DrawScoreButton_Clicked(object sender, EventArgs e)
    {
        Card card = deck.DealTopCard();
        players[count].cards.Add(card);
        players[count].score = ScoreHand(players[count]);
        if (players[count].score > 21)
        {
            players[count].status = PlayerStatus.bust;
        }
        int counter = 0; // counting how many players bust
        Player notBusted = null; // assigned to null just in case this situation doesn't run and causes an error
        for (int i = 0; i < numOfPlayers; i++) // created a loop to check how many players bust
        {
            if (players[i].status == PlayerStatus.bust) // if the player busts...
            {
                counter++; // ...counter will go up
            }
            else
            {
                notBusted = players[i]; // whoever doesn't bust will be saved
            }
        }
        if (numOfPlayers - 1 == counter) // if the numberOfPlayers-1 busted (meaning 1 did not bust)
        {
            Player winner = notBusted; // whoever didn't bust will win
            AnnounceWinner(winner); // announce winner
            winner.status = PlayerStatus.win; // wins the game                        
            previousWinner = winner; // keeps the winner in this variable
            NextButton.IsVisible = true;
            nextTask = RaceTo21.Task.GameOver;
        }
            nextTask = RaceTo21.Task.PlayerTurn;
            count = (count + 1) % players.Count;
            DoNextTask();
    }

    private void StayScoreButton_Clicked(object sender, EventArgs e)
    {
        players[count].status = PlayerStatus.stay;
        nextTask = RaceTo21.Task.PlayerTurn;
        count = (count + 1) % players.Count;
        DoNextTask();
    }
    private void NextButton_Clicked(object sender, EventArgs e)
    {
        nextTask = RaceTo21.Task.GameOver;
        DoNextTask();
    }

    public bool CheckActivePlayers()
    {
        foreach (var player in players)
        {
            if (player.status == PlayerStatus.active)
            {
                return true; // at least one player is still going!
            }
        }
        return false; // everyone has stayed or busted, or someone won!
    }



    

    public void showFinalTotalScores(List<Player> players) // I made this method to show the total final scores of every player after each round
    {
        for (int i = 0; i < players.Count; i++)
        {
            FinalScores[i].IsVisible = true;
            FinalScores[i].Text = players[i].Name + "'s total score is " + players[i].TotalScore;
        }
        FinalButton.IsVisible = true;
    }

    public Player StayScore()
    {
        FinalTotalScore.IsVisible = true;
        int highScore = 0;
        foreach (var player in players)
        {
            if (player.status == PlayerStatus.stay) // still could win...
            {
                if (player.Score > highScore)
                {
                    highScore = player.Score;
                }
            }
        }
        Player winner = players.Find(player => player.Score == highScore);
        return winner;
    }
    public Player DoFinalScoring()
    {
        FinalTotalScore.IsVisible = true;
        int highScore = 0;
        foreach (var player in players)
        {
            if (player.status == PlayerStatus.bust)
            {
                player.TotalScore -= (player.Score - 21);
            }
            if(player.status == PlayerStatus.win)
            {
                player.TotalScore += player.Score;
            }
        }
        if (highScore > 0) // someone scored, anyway!
        {
            // find the FIRST player in list who meets win condition
            Player winner = players.Find(player => player.Score == highScore);
            winner.TotalScore += winner.Score; // the winner's + winner's with the highest score when they stay total score will be updated with their score
            showFinalTotalScores(players); // shows all the player's final scores
            return winner; // returns the winner
        }
        showFinalTotalScores(players);
        return null; // everyone must have busted because nobody won!
    }

    public void FinalTask() // created FinalTask() LEVEL2 on the homework pdf where: At end of round, each player is asked if they want to keep playing. If a player says no, they are removed from the player list. If only 1 player remains, that player is the winner(equivalent to everyone else “folding” in a card game)
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].TotalScore >= winningScore) // if a player has a total score that is greater than or equal to the winning score, they win the whole game
            {
                FullWinningLabel.IsVisible = true;
                FullWinningLabel.Text = players[i].Name + " won the whole game! They are the TRUEEEEE WINNERRRR!!! YIPPEEEEEEE!!!!!! :DDDD";
                winTheGame(); // goes to the method winTheGame
                return; // gets out of this method
            }
        }
        nextTask = RaceTo21.Task.Continue;
        List<Player> finishedPlayers = new List<Player>(); // created a new player list to hold the finishedPlayers
        int playerCount = numOfPlayers; // counter for numberOfPlayers
        for (int i = 0; i < playerCount; i++) // created for loop to go through the players after game finished
        {
            ContinueLabel.IsVisible = true;
            ContinueResponse.IsVisible = true;
            ContinueLabel.Text = players[i].Name + " Do you want to continue playing?";
            string choice = ContinueResponse.Text;
            if (!(choice.ToUpper().StartsWith("Y") || choice.ToUpper().StartsWith("N"))) // if they do not type Y or N
            {
                ContinueYesOrNoLabel.IsVisible = true;
                ContinueYesOrNoLabel.Text = "Please answer Y(es) or N(o)!";
                i--; // so it goes back to the current player and asks them again
            }
            else if (choice.ToUpper().StartsWith("N")) // if they type N
            {
                finishedPlayers.Add(players[i]); // will add players to the finishedPlayers list
                numOfPlayers--; // will count down the numberOfPlayers decreases when added to the finishedPlayers list
            }
        }
        foreach (Player finishedplayer in finishedPlayers) // goes through each item in finishedPlayers and references each player with the finishedPlayer variable
        {
            players.Remove(finishedplayer);

        }
        if (players.Count == 1) // if the number of remaining players is 1
        {
            AnnounceWinner(players[0]); // announce winner
        }
        else if (players.Count == 0) // if the number of remaining players is 0
        {
            ContinueYesOrNoLabel.Text ="Everyone quit... LAME... >:("; // >:(
        }
        else 
        {
            nextTask = RaceTo21.Task.PlayerTurn; // goes to playerturn
            currentPlayer = 0; // current player resets to 0

            ContinueYesOrNoLabel.Text = "Shuffling Players...";
            Restart(); // goes to method Restart that I made
        }
    }
        public void winTheGame() // restarts the whole game after there is a true winner
        {
            currentPlayer = 0;
            winningScore = 0; // resets the winningScore
            players = new List<Player>(); // resets the list of players
            deck = new Deck(); // new deck
            deck.Shuffle(); // shuffles deck
            deck.ShowAllCards();
            nextTask = RaceTo21.Task.GetNumberOfPlayers; // goes back to the first task

        }

        public void PlayerShuffle() // I created this method to shuffle all the players after the game is over. 
        {
            Console.WriteLine("Shuffling Players..."); // letting players know that the players are being shuffled
            Random random = new Random();
            for (int i = 0; i < players.Count; i++) // loop to shuffle the players. Inspired by the Deck Shuffle method in the Deck Class.
            {
                Player tempPlayer = players[i];
                int swapping = random.Next(players.Count);
                players[i] = players[swapping];
                players[swapping] = tempPlayer;
            }
            if (previousWinner.status == PlayerStatus.active) // this is to make sure that the players still shuffle even after the winner leaves. So if the winner stays, this code will run.
            {
                int winTrack = players.IndexOf(previousWinner); // keeps track if the index the previous winner was on
                Player lastPlayer = players[players.Count - 1]; // keeps the last player object
                players[winTrack] = lastPlayer; // the position that the winning player was in gets replaced with the last player
                players[players.Count - 1] = previousWinner; // the winning player goes into the last position of the list
            }
        }

        public void Restart() // made method Restart to refresh the player and deck when a new game starts
        {
            foreach (Player player in players)
            {
                player.Restart(); // calls the Restart method made in the Player class to reset the player score, status, and cards
            }
            deck = new Deck(); // new deck
            deck.Shuffle(); // shuffles deck
            deck.ShowAllCards();
            PlayerShuffle(); // shuffles players!
        }

    bool FinalButtonClicked = false;
    private void FinalButton_Clicked(object sender, EventArgs e)
    {
        FinalButtonClicked = true;
        nextTask = RaceTo21.Task.Final;
        DoNextTask();
    }

    private void YesOrNoButton_Clicked(object sender, EventArgs e)
    {
        count++;

    }
}


