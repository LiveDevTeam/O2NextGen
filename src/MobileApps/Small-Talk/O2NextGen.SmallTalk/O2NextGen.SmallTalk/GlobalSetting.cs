namespace O2NextGen.SmallTalk.Core
{
    public class GlobalSetting
    {
        public string GatewayChatEndpoint { get; set; } = "https://api-smalltalk.o2bus.com";
        public static GlobalSetting Instance { get; } = new GlobalSetting();
    }
}
