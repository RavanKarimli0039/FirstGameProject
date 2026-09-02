namespace FirstGameProject
{
    internal class Game
    {
        public int SecretNumber { get; set; }
        public int TimeRemaining { get; set; }
        public string DifficultyLevel { get; set; }
        public int AttemptsUsed { get; set; }
        public int MaxAttempts { get; set; }

        public int MinRange { get; set; }
        public int MaxRange { get; set; }




        public void SetDifficulty(string difficulty)
        {
            DifficultyLevel = difficulty;

            if (difficulty.Equals("easy", StringComparison.OrdinalIgnoreCase))
            {
                TimeRemaining = 20;
                MaxAttempts = 4;
                MinRange = 1;
                MaxRange = 10;
            }
            else if (difficulty.Equals("medium", StringComparison.OrdinalIgnoreCase))
            {
                TimeRemaining = 30;
                MaxAttempts = 6;
                MinRange = 1;
                MaxRange = 50;
            }
            else if (difficulty.Equals("hard", StringComparison.OrdinalIgnoreCase))
            {
                TimeRemaining = 45;
                MaxAttempts = 7;
                MinRange = 1;
                MaxRange = 100;
            }
        }


        public void GenerateSecretNumber()
        {
            Random random = new Random();
            SecretNumber = random.Next(MinRange, MaxRange + 1);
        }

        public string GetPlayerGuess()
        {
            Console.WriteLine("Enter your guess : ");
            string input = Console.ReadLine();
            return input;
        }

        public bool IsTimeRemaining()
        {
            return TimeRemaining > 0;
        }
        public bool HasAttemptsRemaining()
        {
            return AttemptsUsed < MaxAttempts;
        }

        public string CheckGuess(int guess)
        {
            AttemptsUsed++;
            if(guess > SecretNumber)
            {
                return "Too High";
            }
            else if (guess < SecretNumber)
            {
                return "Too Low"; ;
            }
            else
            {
                return "Correct";
            }
        }

        public void ShowWinScreen()
        {
            if (DifficultyLevel.Equals("easy", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine("Congrats! Want to move to the next level?");
            else if (DifficultyLevel.Equals("medium", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine("Congrats! Want to move to the hard and final level?");
            else if (DifficultyLevel.Equals("hard", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine("Congrats, you've won the game!");
        }

        public void ShowLoseScreen()
        {
            if (!IsTimeRemaining())
                Console.WriteLine("Out of time! You lost.");
            else if (!HasAttemptsRemaining())
                Console.WriteLine("Out of attempts! You lost.");
        }

    }

    
  
}
