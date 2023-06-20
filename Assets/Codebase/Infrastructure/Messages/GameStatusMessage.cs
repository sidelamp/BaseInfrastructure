namespace  Infrastructure.Messages
{
    public enum LevelStatusMessage
    { Loaded, Started, Finished };

    public class GameStatusMessage
    {
        public LevelStatusMessage Message { get; }

        public GameStatusMessage(LevelStatusMessage message)
        {
            Message = message;
        }
    }
}