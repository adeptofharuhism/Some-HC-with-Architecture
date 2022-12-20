using Assets.CodeBase.Data;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.PersistentProgress
{
    public class PersistentProgress : IPersistentProgress
    {
        private const string ProgressKey = "Progress";

        public PlayerProgress Progress { get; set; }

        public PlayerProgress LoadProgress() =>
            PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<PlayerProgress>();

        public void SaveProgress() =>
            PlayerPrefs.SetString(ProgressKey, Progress.ToJson());
    }
}
