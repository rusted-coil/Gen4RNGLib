using Gen4RngLib.Rng;

namespace Gen4RngLib.Individual
{
    public static class LcgRngExtensions
    {
        /// <summary>
        /// LcgRngを使用して性格の決定処理を実行します。
        /// <para> * Rngの状態を進めます。</para>
        /// </summary>
        /// <param name="rng">使用するRng</param>
        /// <param name="gameVersion">ゲームのバージョン</param>
        /// <param name="synchroNature">シンクロの性格。シンクロを使用しない場合は-1を指定</param>
        /// <returns>決定した性格</returns>
        public static uint DetermineNature(this ILcgRng rng, GameVersion gameVersion, int synchroNature)
        {
            int nature = -1;
            if (synchroNature >= 0) // シンクロあり
            {
                uint random = rng.Next();
                if (gameVersion == GameVersion.DPt)
                {
                    if (((random >> 15) & 1) == 0)
                    {
                        nature = synchroNature;
                    }
                }
                else
                {
                    if ((random & 1) == 0)
                    {
                        nature = synchroNature;
                    }
                }
            }
            if (nature < 0) // シンクロなしか不発だった場合は通常の性格決定処理
            {
                uint random = rng.Next();
                if (gameVersion == GameVersion.DPt)
                {
                    nature = (int)(random / 0xa3e);
                }
                else
                {
                    nature = (int)(random % 25);
                }
            }
            return (uint)nature;
        }

        /// <summary>
        /// RNGを使用して個体を生成します。
        /// <para> * 膨大な回数呼び出すことを想定しているため、ヒープを使用しないために結果格納用のIndividualを直接渡します。</para>
        /// <para> * 性格決定処理などを含まず、そのまま性格値を決定します。</para>
        /// </summary>
        /// <param name="rng">使用するRng</param>
        /// <param name="nature">指定する性格。-1を指定した場合、直ちにPIDを生成します。</param>
        /// <param name="createdIndividual">結果を格納するためのIndividualインスタンス</param>
        public static void GenerateIndividual(this ILcgRng rng, int nature, Individual createdIndividual)
        {
            uint pid;
            do
            {
                pid = rng.Next();
                pid |= (rng.Next() << 16);
            } while (nature >= 0 && pid % 25 != nature);

            createdIndividual.PID = pid;
            uint ivs = rng.Next();
            createdIndividual.HpIV = (ushort)(ivs & 0b11111);
            createdIndividual.AtkIV = (ushort)((ivs >> 5) & 0b11111);
            createdIndividual.DefIV = (ushort)((ivs >> 10) & 0b11111);
            ivs = rng.Next();
            createdIndividual.SpdIV = (ushort)(ivs & 0b11111);
            createdIndividual.SpAtkIV = (ushort)((ivs >> 5) & 0b11111);
            createdIndividual.SpDefIV = (ushort)((ivs >> 10) & 0b11111);
            rng.Next(); // 謎消費
        }
    }
}
