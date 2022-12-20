using Assets.CodeBase.Data;

namespace Assets.CodeBase.Infrastructure.Services.PersistentProgress
{
    public interface IPersistentProgress: IService
    {
        PlayerProgress Progress { get; set; }

        PlayerProgress LoadProgress();
        void SaveProgress();
    }
}