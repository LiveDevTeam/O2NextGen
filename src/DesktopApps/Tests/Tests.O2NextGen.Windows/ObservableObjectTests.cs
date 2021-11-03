using NUnit.Framework;

namespace Tests.O2NextGen.Windows
{
    public class ObservableObjectTests
    {
        [Test]
        public void ObservableObject_PropertyChangedEventHandlerIsRaised_Test()
        {
            var obj = new StubObservableObject();
            bool raised = false;
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