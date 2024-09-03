namespace Gen4RngLib.Rng.Internal
{
    internal interface ILcgRngCache
    {
        /// <summary>
        /// seedをcount回進めて返します。
        /// </summary>
        uint Advance(uint seed, uint count);
    }
}
