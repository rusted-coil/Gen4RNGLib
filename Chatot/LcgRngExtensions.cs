using Gen4RngLib.Rng;

namespace Gen4RNGLib.Chatot
{
    public static class LcgRngExtensions
    {
        /// <summary>
        /// LcgRngを使用しておしゃべりの音程を取得します。
        /// </summary>
        /// <param name="rng">使用するRng</param>
        /// <returns>音程の高さを0～8191の値で返します。</returns>
        public static uint Chatter(this ILcgRng rng)
        {
            return rng.Next() % 8192;
        }
    }
}
