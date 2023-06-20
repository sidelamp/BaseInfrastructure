namespace Infrastructure.Services.Builders
{
    public abstract class CanvasBuilderBase
    {
        public abstract CanvasBuilderBase CreateStartPopup();

        public abstract CanvasBuilderBase CreateCompletionPopup();

        public abstract CanvasBuilderBase CreateGamePopup();

        public abstract void Build();
    }
}