namespace Gen4RngLib.Rng
{
    /// <summary>
    /// 第4世代のMTの乱数生成器のインターフェースです。
    /// </summary>
    public interface IMtRng
    {
        /// <summary>
        /// 乱数を1つ取り出し、内部状態を1進めます。
        /// </summary>
        uint Next();
    }
}
