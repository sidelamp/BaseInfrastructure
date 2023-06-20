namespace  Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadService : IService, ISaveLoad
    {
        void Register(ISaveLoad variable);
    }
}