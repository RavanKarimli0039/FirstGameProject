namespace FirstGameProject
{
    internal class ValidationHelper
    {
        public static bool IsValidDifficulty(string input)
        {
            return string.Equals(input, "easy", StringComparison.OrdinalIgnoreCase)
                || string.Equals(input, "medium", StringComparison.OrdinalIgnoreCase)
                || string.Equals(input, "hard", StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsValidGuess(string input, int min, int max)
        {
            bool isNumber = int.TryParse(input, out int number);

            return isNumber && number >= min && number <= max;
        }

    }
}
