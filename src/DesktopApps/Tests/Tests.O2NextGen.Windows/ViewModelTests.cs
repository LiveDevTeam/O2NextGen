using NUnit.Framework;
using O2NextGen.Windows;
using System;
using System.ComponentModel;
using Tests.O2NextGen.Windows.Stub;

namespace Tests.O2NextGen.Windows
{
    public class ViewModelTests
    {
        [Test]
        public void ViewModel_IsAbstractBaseClass_Test()
        {
            var t = typeof(ViewModel);
            Assert.IsTrue(t.IsAbstract);
        }

        [Test]
        public void ViewModel_IsDataErrorInfo_Test()
        {
            Assert.IsTrue(typeof(IDataErrorInfo).IsAssignableFrom(typeof(ViewModel)));
        }

        [Test]
        public void ViewModel_IsDataErrorInfo_ErrorProperty_IsNotImplemented()
        {
            //Arrange

            //Act
            var viewModel = new StubViewModel();
            // Assert
            // ReSharper disable once UnusedVariable
            Assert.Throws<NotSupportedException>(() =>
            {
                var value = viewModel.Error;
            });
        }

        [Test]
        public void ViewModel_IndexerPropertyValidatesPropertyNameWithInvalidValue()
        {
            //Arrange

            //Act
            var viewModel = new StubViewModel();
            // Assert
            Assert.IsNotNull(viewModel["RequiredProperty"]);
        }

        [Test]
        public void ViewModel_IndexerPropertyValidatesPropertyNameWithValidValue()
        {
            //Arrange

            //Act
            var viewModel = new StubViewModel()
            {
                RequiredProperty = "Some Value"
            };
            // Assert
            Assert.IsNull(viewModel["RequiredProperty"]);
        }

        [Test]
        public void ViewModel_IsObservableObject()
        {
            Assert.IsTrue(typeof(ViewModel).BaseType == typeof(ObservableObject));
        }
    }
}