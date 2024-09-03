using Gen4RngLib.Rng;

namespace Gen4RngLib.Trainer
{
    public static class MtRngExtensions
    {
        /// <summary>
        /// MtRngを使用して、トレーナーIDを生成します。
        /// <para> * 下位2byteが表ID、上位2byteが裏IDとなります。</para>
        /// </summary>
        /// <param name="rng">使用するRNG</param>
        /// <returns>32bitのトレーナーID</returns>
        public static uint GenerateTrainerId(this IMtRng rng)
        {
            rng.Next(); // 不明な消費
            return rng.Next();
        }
    }
}
