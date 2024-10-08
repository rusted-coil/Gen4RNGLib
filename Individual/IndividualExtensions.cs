﻿namespace Gen4RngLib.Individual
{
    public static class IndividualExtensions
    {
        /// <summary>
        /// 個体の性格Indexを取得します。
        /// </summary>
        public static uint GetNature(this Individual individual)
        {
            return individual.PID % 25;
        }

        /// <summary>
        /// 個体が色違いかどうかを取得します。
        /// </summary>
        public static bool IsShiny(this Individual individual, uint tid, uint sid)
        {
            return individual.IsShiny(tid ^ sid);
        }

        /// <summary>
        /// 個体が色違いかどうかを取得します。
        /// </summary>
        public static bool IsShiny(this Individual individual, uint tsv)
        {
            return (tsv ^ (individual.PID & 0xffff) ^ ((individual.PID >> 16) & 0xffff)) <= 7;
        }
    }
}
