namespace FirstGameProject
{
    internal class GameController
    {
        public void StartNewGame(Game game)
        {
            string difficultyLevel;
            bool isValid;

            do
            {
                Console.WriteLine("Enter your type of difficulty:");
                difficultyLevel = Console.ReadLine();
                isValid = ValidationHelper.IsValidDifficulty(difficultyLevel);

                if (!isValid)
                {
                    Console.WriteLine("The input is wrong, try again.");
                }

            } while (!isValid);

            game.SetDifficulty(difficultyLevel);
            game.GenerateSecretNumber();
        }


        public int GetValidatedGuess(Game game)
        {
            string guess;
            bool IsValidGuess;

            do
            {
                Console.WriteLine("Enter your guess :");
                guess = Console.ReadLine();
                IsValidGuess = ValidationHelper.IsValidGuess(guess, game.MinRange, game.MaxRange);

                if (!IsValidGuess)
                {
                    Console.WriteLine("The input is wrong, try again.");
                }
            } while (!IsValidGuess);
            int number = int.Parse(guess);
            return number;   
        }
    }
}
