using Moq;
using NUnit.Framework;
using O2NextGen.CertificateManagement.Application.Services;
using Tests.O2NextGen.CertificateManagement.Application.Base;

namespace Tests.O2NextGen.CertificateManagement.Application;

public class KeyGeneratorTests:BaseConfigTests<KeyGenerator>
{
    private const int MaxLenght = 8;

    [Test]
    [TestCase("KeyGenerator")]
    public override void It_CheckClassName(string name = "")
    {
        base.It_CheckClassName(name);
    }
    
    [Test]
    public void KeyGenerator_Generate_Tests()
    {
        var expectedKey = "test";
        var mock = new Mock<IKeyGenerator>();

        mock.Setup(_ => _.Generate(MaxLenght)).Returns(expectedKey);
        var keyGenerator = new KeyGenerator();
        var key = KeyGenerator.Instance.Generate(MaxLenght);
        
        Assert.NotNull(key);
        Assert.Equals(expectedKey, key);
    }
    
    [Test]
    public void KeyGenerator_Validate_Tests()
    {
        var keyGenerator = new KeyGenerator();
        
        var key = KeyGenerator.Instance.Generate(MaxLenght);
        
        //Act
        var isValidate = KeyGenerator.Instance.Validate(MaxLenght, key);
        
        //Assert
        Assert.True(isValidate);
    }
}