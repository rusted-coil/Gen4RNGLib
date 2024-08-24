namespace Gen4RngLib.Rng
{
    /// <summary>
    /// 第4世代のLCGの乱数生成器のインターフェースです。
    /// </summary>
    public interface ILcgRng : IReadOnlyLcgRng
    {
        /// <summary>
        /// 現在のSeedを変更します。
        /// </summary>
        void ChangeSeed(uint seed);

        /// <summary>
        /// 乱数を1つ取り出し、内部状態を1進めます。
        /// </summary>
        uint Next();
    }
}
