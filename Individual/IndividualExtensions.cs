namespace Gen4RNGLib.Individual
{
    public static class IndividualExtensions
    {
        /// <summary>
        /// 個体の性格Indexを取得します。
        /// </summary>
        public static int GetNature(this Gen4RngLib.Individual.Individual individual)
        {
            return (int)(individual.PID % 25);
        }

        /// <summary>
        /// 個体が色違いかどうかを取得します。
        /// </summary>
        public static bool IsShiny(this Gen4RngLib.Individual.Individual individual, uint tid, uint sid)
        { 
            return (tid ^ sid ^ (individual.PID & 0xffff) ^ ((individual.PID >> 16) & 0xffff)) <= 7;
        }
    }
}
