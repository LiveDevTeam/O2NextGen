using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace O2NextGen.Windows
{
    public abstract class ViewModel: ObservableObject, IDataErrorInfo
    {
        public string Error => throw new NotSupportedException();

        public string this[string columnName] => OnValidate(columnName);

        protected virtual string OnValidate(string propertyName)
        {
            var context = new ValidationContext(this)
            {
                MemberName = propertyName
            };
            var results = new Collection<ValidationResult>();
            var isValid
                = Validator.TryValidateObject(this,context,results,true );
            return !isValid ?  results[0].ErrorMessage: null;
        }
    }
}