namespace GameCore.Events
{
    public class ScoreParams : BaseEventParams
    {
        public readonly bool PlayerScored;

        public ScoreParams(bool playerScored)
        {
            PlayerScored = playerScored;
        }
    }
}