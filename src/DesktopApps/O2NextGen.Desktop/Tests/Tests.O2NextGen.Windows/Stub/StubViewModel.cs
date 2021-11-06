using System.ComponentModel.DataAnnotations;
using O2NextGen.Windows;

namespace Tests.O2NextGen.Windows.Stub
{
    internal class StubViewModel : ViewModel
    {
        [Required] 
        public string RequiredProperty { get; set; }
    }
}