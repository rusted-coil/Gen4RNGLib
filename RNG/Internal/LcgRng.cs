namespace Gen4RngLib.Rng.Internal
{
    internal sealed class LcgRng : ILcgRng
    {
        public uint Seed { get; set; }

        readonly uint m_Multiplier;
        readonly uint m_Adder;

        public LcgRng(uint initialSeed, uint multiplier, uint adder)
        {
            Seed = initialSeed;
            m_Multiplier = multiplier;
            m_Adder = adder;
        }

        public uint Next()
        {
            Seed = Seed * m_Multiplier + m_Adder;
            return Seed >> 16;
        }
    }
}
