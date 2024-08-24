namespace Gen4RngLib.Individual
{
    /// <summary>
    /// 第4世代のRngが生成する個体のクラスです。
    /// </summary>
    public sealed class Individual
    {
        /// <summary>
        /// 性格値を取得します。
        /// </summary>
        public uint PID { get; set; }

        /// <summary>
        /// HP個体値を取得します。
        /// </summary>
        public ushort HpIV { get; set; }

        /// <summary>
        /// 攻撃個体値を取得します。
        /// </summary>
        public ushort AtkIV { get; set; }

        /// <summary>
        /// 防御個体値を取得します。
        /// </summary>
        public ushort DefIV { get; set; }

        /// <summary>
        /// 特攻個体値を取得します。
        /// </summary>
        public ushort SpAtkIV { get; set; }

        /// <summary>
        /// 特防個体値を取得します。
        /// </summary>
        public ushort SpDefIV { get; set; }

        /// <summary>
        /// 素早さ個体値を取得します。
        /// </summary>
        public ushort SpdIV { get; set; }
    }
}
