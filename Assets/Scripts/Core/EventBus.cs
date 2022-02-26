using System;

namespace Core
{
    public static class EventBus
    {
        public static Action OnLevelReset;
        public static Action OnLevelWin;
        public static Action OnLevelLose;
    }
}
