namespace GameLoop
{
    public class ScoreKeeper : IScoreKeeper
    {
        private int _playerScore, _aiScore, _scoreToWin;

        public string CurrentScoreString => $"Score:\n{_aiScore} - {_playerScore}";

        public ScoreKeeper(int scoreToWin)
        {
            _scoreToWin = scoreToWin;
        }

        public void UpdateScore(bool playerScored)
        {
            if (playerScored)
                _playerScore++;
            else
                _aiScore++;
        }

        public bool CheckGameOver()
        {
            return _playerScore >= _scoreToWin || _aiScore >= _scoreToWin;
        }
    }
}