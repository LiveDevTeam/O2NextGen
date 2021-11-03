using O2NextGen.Windows;

namespace Tests.O2NextGen.Windows.Stub
{
    public class StubObservableObject : ObservableObject
    {
        private string _changedProperty;

        public string ChangedProperty
        {
            get => _changedProperty;
            set
            {
                _changedProperty = value;
                OnPropertyChanged();
            }
        }
    }
}