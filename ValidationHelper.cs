namespace FirstGameProject
{
    internal class ValidationHelper
    {
        
        public static bool IsValidGuess(string input, int min, int max)
        {
            bool isNumber = int.TryParse(input, out int number);

            return isNumber && number >= min && number <= max;
        }

    }
}
