using System;

namespace O2NextGen.SmallTalk.Api.Helpers
{
    //Converter Off/On
    public static class ConfigFunctionStateConverter
    {
        public static bool GetStateFunction(string value)
        {
            if (value.ToLower().Contains("on"))
                return true;
            else
            {
                if (value.ToLower().Contains("off"))
                    return false;
                throw new ArgumentException(nameof(value));
            }
        }
    }
}