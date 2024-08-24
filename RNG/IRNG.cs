namespace Gen4RNGLib.RNG
{
    /// <summary>
    /// 第4世代の乱数生成器のインターフェースです。
    /// </summary>
    public interface IRNG
    {
        /// <summary>
        /// 乱数を1つ取り出し、内部状態を1進めます。
        /// </summary>
        UInt32 Next();
    }
}
