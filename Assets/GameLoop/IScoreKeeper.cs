namespace GameLoop
{
    public interface IScoreKeeper
    {
        string CurrentScoreString { get; }
        void UpdateScore(bool playerScored);
        bool CheckGameOver();
    }
}