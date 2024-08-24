namespace Gen4RngLib.Rng
{
    /// <summary>
    /// 第4世代の乱数生成器のファクトリクラスです。
    /// </summary>
    public static class RngFactory
    {
        /// <summary>
        /// 初期seedを与えてLcgRngを生成します。
        /// </summary>
        public static ILcgRng Create(uint initialSeed)
        {
            return new Internal.Rng(initialSeed);
        }

        /// <summary>
        /// 日付と待機フレームを与えてLcgRngを生成します。
        /// </summary>
        public static ILcgRng Create(DateTime dateTime, uint waitFrames)
        {
            return new Internal.Rng(dateTime, waitFrames);
        }
    }
}
