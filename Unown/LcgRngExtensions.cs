using Gen4RngLib.Rng;

namespace Gen4RNGLib.Unown
{
    public static class LcgRngExtensions
    {
        /// <summary>
        /// LcgRngを使用して、アンノーン出現判定におけるラジオの効果が有効かどうかを取得します。
        /// </summary>
        /// <param name="rng">使用するRng</param>
        /// <returns>有効かどうか(trueなら未所持の文字のアンノーンが出る)</returns>
        public static bool CheckRadioEffect(this ILcgRng rng)
        {
            return rng.Next() % 100 < 50;
        }

        /// <summary>
        /// LcgRngを使用して、出現するアンノーンの文字を取得します。
        /// <para> * すべての文字を開放していることを前提とします。</para>
        /// </summary>
        /// <param name="rng">使用するRng</param>
        /// <returns>出現するアンノーン文字の内部インデックス。A-Z順になっていないことに注意。</returns>
        public static int GenerateUnownLetterInGameIndex(this ILcgRng rng)
        {
            return (int)(rng.Next() % 26);
        }
    }
}
