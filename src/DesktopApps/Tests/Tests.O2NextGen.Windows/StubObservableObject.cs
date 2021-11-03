using O2NextGen.Windows;

namespace Tests.O2NextGen.Windows
{
    public class StubObservableObject : ObservableObject
    {
        private string changedProperty;

        public string ChangedProperty
        {
            get { return changedProperty; }
            set
            {
                changedProperty = value;
                OnPropertyChanged();
            }
        }
    }
}