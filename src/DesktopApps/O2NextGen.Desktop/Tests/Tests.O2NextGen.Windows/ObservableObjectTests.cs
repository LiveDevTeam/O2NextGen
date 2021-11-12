using NUnit.Framework;
using Tests.O2NextGen.Windows.Stub;

namespace Tests.O2NextGen.Windows
{
    public class ObservableObjectTests
    {
        [Test]
        public void ObservableObject_PropertyChangedEventHandlerIsRaised_Test()
        {
            var obj = new StubObservableObject();
            var raised = false;
            obj.PropertyChanged += (sender, e) =>
            {
                Assert.IsTrue(e.PropertyName == "ChangedProperty");
                raised = true;
            };
            obj.ChangedProperty = "Some Value";
            
            if (!raised) 
                Assert.Fail("PropertyChanged was newer invoked.");
        }
    }
}