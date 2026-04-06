namespace Minesweeper.Core;

public class ScoreManager
{
    private string filePath = "scores.txt";

    public void SaveScore(int score, TimeSpan time)
    {
        string entry = $"{DateTime.Now} | Score: {score} | Time: {time.TotalSeconds}s";
        File.AppendAllText(filePath, entry + Environment.NewLine);
    }
}