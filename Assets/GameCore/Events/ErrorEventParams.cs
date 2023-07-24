namespace GameCore.Events
{
    public class ErrorEventParams : BaseEventParams
    {
        public string ErrorMessage { get; }

        public ErrorEventParams(string errorMsg)
        {
            ErrorMessage = errorMsg;
        }
    }
}