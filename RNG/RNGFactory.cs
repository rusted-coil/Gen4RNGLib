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
        public static ILcgRng CreateLcgRng(uint initialSeed)
        {
            return new Internal.LcgRng(initialSeed, 0x41C64E6Du, 0x6073);
        }

        /// <summary>
        /// 日付と待機フレームを与えてLcgRngを生成します。
        /// </summary>
        public static ILcgRng CreateLcgRng(DateTime dateTime, uint waitFrames)
        {
            uint initialSeed  =
                ((uint)((dateTime.Month * dateTime.Day + dateTime.Minute + dateTime.Second) & 0xff) << 24)
                | ((uint)dateTime.Hour << 16)
                | ((uint)(dateTime.Year - 2000));
            initialSeed += waitFrames;
            return CreateLcgRng(initialSeed);
        }

        /// <summary>
        /// 初期seedを与えて逆に進むLcgRngを生成します。
        /// <para> * 逆RNGは、同じ初期seedで初期化した通常のRNGに対し、通常のRNGの乱数列をr[0],r[1]…とするとr[-2],r[-3]…を返します。</para>
        /// </summary>
        public static ILcgRng CreateReverseLcgRng(uint initialSeed)
        {
            return new Internal.LcgRng(initialSeed, 0xEEB9EB65u, 0xA3561A1u);
        }
    }
}
