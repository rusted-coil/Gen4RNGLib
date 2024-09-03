namespace Gen4RngLib.Rng.Internal
{
    internal sealed class MtRng : IMtRng
    {
        private const int N = 624;
        private const int M = 397;
        private const uint MatrixA = 0x9908B0DFU;
        private const uint UpperMask = 0x80000000U;
        private const uint LowerMask = 0x7FFFFFFFU;

        private uint[] mt = new uint[N];
        private int mti = N;

        public MtRng(uint initialSeed)
        {
            mt[0] = initialSeed;
            for (mti = 1; mti < N; mti++)
            {
                mt[mti] = (uint)((1812433253U * (mt[mti - 1] ^ (mt[mti - 1] >> 30)) + mti) & 0xFFFFFFFFU);
            }
        }

        public uint Next()
        {
            uint y;
            uint[] mag01 = { 0x0U, MatrixA };

            if (mti >= N)
            {
                int kk;

                for (kk = 0; kk < N - M; kk++)
                {
                    y = (mt[kk] & UpperMask) | (mt[kk + 1] & LowerMask);
                    mt[kk] = mt[kk + M] ^ (y >> 1) ^ mag01[y & 0x1U];
                }
                for (; kk < N - 1; kk++)
                {
                    y = (mt[kk] & UpperMask) | (mt[kk + 1] & LowerMask);
                    mt[kk] = mt[kk + (M - N)] ^ (y >> 1) ^ mag01[y & 0x1U];
                }
                y = (mt[N - 1] & UpperMask) | (mt[0] & LowerMask);
                mt[N - 1] = mt[M - 1] ^ (y >> 1) ^ mag01[y & 0x1U];

                mti = 0;
            }

            y = mt[mti++];

            // Tempering
            y ^= (y >> 11);
            y ^= (y << 7) & 0x9D2C5680U;
            y ^= (y << 15) & 0xEFC60000U;
            y ^= (y >> 18);

            return y;
        }
    }
}
