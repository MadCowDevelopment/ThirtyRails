using System;

namespace Hextasy.Framework
{
    public static class RNG
    {
        #region Fields

        private static readonly Random Random = new Random((int)DateTime.Now.Ticks);

        #endregion Fields

        #region Public Static Methods

        public static bool Chance(int percent)
        {
            return Next(1, 100) <= percent;
        }

        public static int Next(int min, int max)
        {
            return Random.Next(min, max + 1);
        }

        public static T ChooseOne<T>(params T[] choices)
        {
            var number = RNG.Next(0, choices.Length);
            return choices[number];
        }

        #endregion Public Static Methods
    }
}