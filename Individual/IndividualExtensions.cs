using Gen4RngLib.Rng;

namespace Gen4RngLib.Individual
{
    public static class IndividualExtensions
    {
        static ILcgRng s_TempRng = RngFactory.Create(0);

        /// <summary>
        /// 現在のrng状態から生成される個体を取得します。
        /// <para> * 膨大な回数呼び出すことを想定しているため、ヒープを使用しないために結果格納用のIndividualを直接渡します。</para>
        /// <para> * 性格決定処理などを含まず、そのまま性格値を決定します。</para>
        /// </summary>
        /// <param name="rng">現在のRng</param>
        /// <param name="createdIndividual">結果を格納するためのIndividualインスタンス</param>
        public static void GetIndividual(this IReadOnlyLcgRng rng, Individual createdIndividual)
        {
            s_TempRng.ChangeSeed(rng.Seed);

            createdIndividual.PID = s_TempRng.Next();
            createdIndividual.PID |= (s_TempRng.Next() << 16);
            uint ivs = s_TempRng.Next();
            createdIndividual.HpIV = (ushort)(ivs & 0b11111);
            createdIndividual.AtkIV = (ushort)((ivs >> 5) & 0b11111);
            createdIndividual.DefIV = (ushort)((ivs >> 10) & 0b11111);
            ivs = s_TempRng.Next();
            createdIndividual.SpdIV = (ushort)(ivs & 0b11111);
            createdIndividual.SpAtkIV = (ushort)((ivs >> 5) & 0b11111);
            createdIndividual.SpDefIV = (ushort)((ivs >> 10) & 0b11111);
        }

        /// <summary>
        /// 現在のrng状態から、性格決定処理を経由して生成される個体を取得します。
        /// <para> * 膨大な回数呼び出すことを想定しているため、ヒープを使用しないために結果格納用のIndividualを直接渡します。</para>
        /// </summary>
        /// <param name="rng">現在のRng</param>
        /// <param name="gameVersion">ゲームバージョン</param>
        /// <param name="synchroNature">シンクロの性格。シンクロではない場合は-1を指定</param>
        /// <param name="createdIndividual">結果を格納するためのIndividualインスタンス</param>
        public static void GetIndividualWithNatureDetermination(this IReadOnlyLcgRng rng, GameVersion gameVersion, int synchroNature, Individual createdIndividual)
        {
            s_TempRng.ChangeSeed(rng.Seed);

            int nature = -1;
            if (synchroNature >= 0) // シンクロあり
            {
                uint random = s_TempRng.Next();
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
                uint random = s_TempRng.Next();
                if (gameVersion == GameVersion.DPt)
                {
                    nature = (int)(random / 0xa3e);
                }
                else
                {
                    nature = (int)(random % 25);
                }
            }

            uint pid;
            do {
                pid = s_TempRng.Next();
                pid |= (s_TempRng.Next() << 16);
            } while (pid % 25 != nature);

            createdIndividual.PID = pid;
            uint ivs = s_TempRng.Next();
            createdIndividual.HpIV = (ushort)(ivs & 0b11111);
            createdIndividual.AtkIV = (ushort)((ivs >> 5) & 0b11111);
            createdIndividual.DefIV = (ushort)((ivs >> 10) & 0b11111);
            ivs = s_TempRng.Next();
            createdIndividual.SpdIV = (ushort)(ivs & 0b11111);
            createdIndividual.SpAtkIV = (ushort)((ivs >> 5) & 0b11111);
            createdIndividual.SpDefIV = (ushort)((ivs >> 10) & 0b11111);
        }
    }
}
