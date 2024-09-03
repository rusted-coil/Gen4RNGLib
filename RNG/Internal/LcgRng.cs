namespace Gen4RngLib.Rng.Internal
{
    internal sealed class LcgRng : ILcgRng
    {
        public uint Seed { get; set; }

        readonly uint m_Multiplier;
        readonly uint m_Adder;
        readonly ILcgRngCache? m_Cache;

        public LcgRng(uint initialSeed, uint multiplier, uint adder, ILcgRngCache? cache = null)
        {
            Seed = initialSeed;
            m_Multiplier = multiplier;
            m_Adder = adder;
            m_Cache = cache;
        }

        public uint Next()
        {
            Seed = Seed * m_Multiplier + m_Adder;
            return Seed >> 16;
        }

        public uint Advance(uint count)
        {
            // キャッシュが利用できる場合はそれを使う
            if (m_Cache != null)
            {
                Seed = m_Cache.Advance(Seed, count);
            }
            else
            {
                for (uint i = 0; i < count; ++i)
                {
                    Next();
                }
            }
            return Seed >> 16;
        }
    }
}
