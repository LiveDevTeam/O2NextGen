namespace O2NextGen.SmartSubscriber.Application;

public interface IServiceUrl
{
    string IdentityUrl { get; set; }
    
    string CGenUrl { get; set; }
}
public class ServiceUrls: IServiceUrl
{
    public string IdentityUrl { get; set; }
    
    public string CGenUrl { get; set; }
}