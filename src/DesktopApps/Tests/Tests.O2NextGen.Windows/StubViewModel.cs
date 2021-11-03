using O2NextGen.Windows;
using System.ComponentModel.DataAnnotations;

namespace Tests.O2NextGen.Windows
{
    internal class StubViewModel:ViewModel
    {
        [Required]
        public string RequiredProperty { get; set; }
    }
}