using System;

namespace O2NextGen.Auth.Web.Utilities
{
    public interface IBase64QrCodeGenerator
    {
        string Generate(Uri target);
    }
}