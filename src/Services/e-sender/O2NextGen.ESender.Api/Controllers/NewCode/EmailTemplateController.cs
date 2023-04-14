using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using O2NextGen.ESender.Data.Entities;

namespace O2NextGen.ESender.Api.Controllers.NewCode
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class EmailTemplateController: ControllerBase
    {
        [HttpGet]
        public void Tests()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string path = System.IO.Path.GetDirectoryName(asm.Location);
            System.IO.File.WriteAllText(path+@"\index.html", EmailNotificationTemplateConstants.OuterBody);
        }
        
    }
    
    // [AllowAnonymous]
    // [Route("api/[controller]")]
    // public class EmailTemplateController: ControllerBase
    // {
    //     
    // }
}