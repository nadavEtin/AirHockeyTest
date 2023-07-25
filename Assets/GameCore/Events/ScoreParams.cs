namespace GameCore.Events
{
    public class ScoreParams : BaseEventParams
    {
        public bool PlayerScored;

        public ScoreParams(bool playerScored)
        {
            PlayerScored = playerScored;
        }
    }
}