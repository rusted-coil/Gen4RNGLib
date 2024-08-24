namespace Gen4RngLib.Rng
{
    /// <summary>
    /// 現在の状態のみを取得することができるLcgRngです。状態を変更することはできません。
    /// </summary>
    public interface IReadOnlyLcgRng
    {
        /// <summary>
        /// 現在のSeedを取得します。一度もNextを呼んでいない時、初期Seedと一致する値をとります。
        /// </summary>
        uint Seed { get; }
    }
}
