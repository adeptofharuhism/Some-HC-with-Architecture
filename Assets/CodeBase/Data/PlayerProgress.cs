using System;

namespace Assets.CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public int Level;

        public PlayerProgress(int initialLevel) {
            Level = initialLevel;
        }

        public void AddLevel() => Level++;
    }
}
