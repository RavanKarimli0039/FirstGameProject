using FirstGameProject;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace FirstGameProject;

[ApiController]
[Route("api/[controller]")]

public class GameController : ControllerBase    
{
    private static readonly ConcurrentDictionary<string, GameSession> Sessions = new();


    [HttpPost("start")]
    public IActionResult StartGame([FromBody] string difficulty)
    {
        var session = new GameSession();
        session.SetDifficulty(difficulty);
        Sessions[session.Id] = session;

        return Ok(new { sessionId = session.Id, min = session.MinRange, max = session.MaxRange, maxAttempts = session.MaxAttempts, timeRemaining = session.TimeRemaining });
    }



    [HttpPost("guess")]

    //	This method checks: "Does a game session with that ID exist?"
    public IActionResult MakeGuess([FromBody] GuessRequest request)
    {
        if(!Sessions.TryGetValue(request.SessionId, out var session))
        {
            return NotFound(new { message = "Game session not found." });
        }
        if (!session.IsTimeRemaining())
        {
            Sessions.TryRemove(request.SessionId, out _);
            return Ok(new { status = "Lost", message = "Out Of Time!, You Lost.", correctNumber = session.SecretNumber });
        }
        if (!session.HasAttemptsRemaining())
        {
            Sessions.TryRemove(request.SessionId, out _);
            return Ok(new { status = "Lost", message = "Out of Attempts!, You Lost.", correctNumber = session.SecretNumber });
        }

        bool IsValid = ValidationHelper.IsValidGuess(request.Guess.ToString(), session.MinRange, session.MaxRange);

        if (!IsValid)
        {
            return Ok(new { status = "Invalid", message = $"Please Enter a number between {session.MinRange} and {session.MaxRange}" });
        }

        string result = session.CheckGuess(request.Guess);
        int AttemptRemaining = session.MaxAttempts - session.AttemptsUsed;

        if(result == "Correct")
        {
            double timeTaken = (DateTime.Now - session.StartTime).TotalSeconds;
            Sessions.TryRemove(request.SessionId, out _);
            return Ok(new { status = "Won", message = "Congrats!, You guessed correctly", timeTaken = (int)timeTaken });
        }

        if (!session.HasAttemptsRemaining())
        {
            Sessions.TryRemove(request.SessionId, out _);
            return Ok(new { status = "Lost", message = "Out of Attempts!, You lost", correctNumber = session.SecretNumber });
        }

        return Ok(new
        {
            status = "InGame",
            result = result,
            AttemptRemaining = AttemptRemaining
        });
    }
   
    public class GuessRequest
    {
        public string SessionId { get; set; } = string.Empty;
        public int Guess { get; set; }
    }
}


