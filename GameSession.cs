using System;

namespace FirstGameProject
{
    public class GameSession
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int SecretNumber { get; set; }
        public int TimeRemaining { get; set; }
        public string DifficultyLevel { get; set; } = string.Empty; 
        public int AttemptsUsed { get; set; }
        public int MaxAttempts { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }
        public DateTime StartTime { get; set; }

        public void SetDifficulty(string difficulty)
        {
            DifficultyLevel = difficulty;
            StartTime = DateTime.Now;

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
                MaxAttempts = 5;
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

            Random random = new Random();
            SecretNumber = random.Next(MinRange, MaxRange + 1);
        }

        public bool IsTimeRemaining() => (DateTime.Now - StartTime).TotalSeconds < TimeRemaining;
        public bool HasAttemptsRemaining() => AttemptsUsed < MaxAttempts;

        public string CheckGuess(int guess)
        {
            AttemptsUsed++;
            if (guess > SecretNumber) return "Too High";
            if (guess < SecretNumber) return "Too Low";
            return "Correct";
        }
    }
}