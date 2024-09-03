using System.Diagnostics;

namespace Gen4RngLib.Unown
{
    public static class UnownUtil
    {
        /// <summary>
        /// アンノーン文字のHGSS内部のインデックスを、Aを0としアルファベット順に並べた場合のインデックスに変換します。
        /// <para> * !と?には非対応です。</para>
        /// </summary>
        public static int ConvertUnownLetter(int inGameIndex)
        {
            Debug.Assert(inGameIndex >= 0 && inGameIndex <= 25);

            // 0～9: A～J
            // 10～14: R～V
            // 15～21: K～Q
            // 22～25: W～Z
            if (inGameIndex <= 9)
            {
                return inGameIndex;
            }
            else if (inGameIndex <= 14)
            {
                return inGameIndex + 7;
            }
            else if (inGameIndex <= 21)
            {
                return inGameIndex - 5;
            }
            else
            {
                return inGameIndex;
            }
        }
    }
}
