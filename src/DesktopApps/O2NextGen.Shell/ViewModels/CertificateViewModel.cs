using System.ComponentModel.DataAnnotations;
using O2NextGen.Windows;

namespace O2NextGen.Shell.ViewModels
{
    public class CertificateViewModel: ViewModel
    {
        #region Ctors


        #endregion


        #region Fields

        private string _certificateName;

        #endregion


        #region Props

        [Required]
        [StringLength(32,MinimumLength = 4)]
        public string CertificateName
        {
            get => _certificateName;
            set
            {
                _certificateName = value;
                OnPropertyChanged();
            }
        }

        #endregion


        #region Methods

        #region Overrides of ViewModel

        protected override string OnValidate(string propertyName)
        {
            if (CertificateName!=null && !CertificateName.Contains(""))
                return "The name of the certificate must include at least 2 words";
            
            return base.OnValidate(propertyName);
        }

        #endregion


        #endregion
    }
}
