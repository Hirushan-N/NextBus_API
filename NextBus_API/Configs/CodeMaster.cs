namespace NextBus_API.Configs
{
    public class CodeMaster
    {
        private CodeMaster() { }
        private static CodeMaster instance = null;
        public static CodeMaster Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CodeMaster();
                }
                return instance;
            }
        }

        public static string GenerateCode(string Prefix)
        {
            DateTime now = DateTime.Now;
            string code = string.Format("-{0:d4}{1:d2}{2:d2}-{3:d2}{4:d2}{5:d2}{6:d3}",
                now.Year, now.Month, now.Day,
                now.Hour, now.Minute, now.Second, now.Millisecond);
            return Prefix + code;
        }
    }
}
