namespace Gen4RngLib.Rng.Internal
{
    internal sealed class LcgRngCache : ILcgRngCache
    {
        uint[,] cachedMultipliers = new uint[4, 256];
        uint[,] cachedAdders = new uint[4, 256];

        public LcgRngCache(uint multiplier, uint adder)
        {
            for (int a = 0; a < 4; ++a)
            {
                cachedMultipliers[a, 0] = 1;
                cachedAdders[a, 0]      = 0;
                for (int b = 1; b < 256; ++b)
                {
                    // S[n] = S[0] * A' + B'
                    // S[n+1] = S[0] * A' * A + A * B' + B
                    cachedMultipliers[a, b] = cachedMultipliers[a, b - 1] * multiplier; // A' * A
                    cachedAdders[a, b] = cachedAdders[a, b - 1] * multiplier + adder; // B' * A + B
                }
                adder = cachedAdders[a, 255] * multiplier + adder;
                multiplier = cachedMultipliers[a, 255] * multiplier;
            }
        }

        public uint Advance(uint seed, uint count)
        {
            for (int i = 0; i < 4; ++i)
            {
                if (count == 0)
                {
                    break;
                }
                seed = seed * cachedMultipliers[i, (count & 0xff)] + cachedAdders[i, (count & 0xff)];
                count = count >> 8;
            }
            return seed;
        }
    }
}
