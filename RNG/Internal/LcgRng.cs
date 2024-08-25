namespace Gen4RngLib.Rng.Internal
{
    internal sealed class LcgRng : ILcgRng
    {
        public uint Seed { get; set; }

        public LcgRng(uint initialSeed)
        {
            Seed = initialSeed;
        }

        public LcgRng(DateTime dateTime, uint waitFrames)
        {
            Seed = 
                ((uint)((dateTime.Month * dateTime.Day + dateTime.Minute + dateTime.Second) & 0xff) << 24)
                | ((uint)dateTime.Hour << 16)
                | ((uint)(dateTime.Year - 2000));
            Seed += waitFrames;
        }

        public uint Next()
        {
            Seed = Seed * 0x41C64E6Du + 0x6073;
            return Seed >> 16;
        }
    }
}
