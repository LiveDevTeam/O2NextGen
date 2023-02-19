using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTests.O2NextGen.CertificateManagement.Api
{
    // public class CertificateServiceTests : CertificateScenarioBase
    // {
    //     
    //     // [Fact]
    //     // public async Task Get_get_all_stored_orders_and_response_ok_status_code()
    //     // {
    //     //     using (var server = CreateServer())
    //     //     {
    //     //         var response = await server.CreateClient()
    //     //             .GetAsync(Get.Certificates);
    //     //
    //     //         response.EnsureSuccessStatusCode();
    //     //     }
    //     // }
    //     //
    //     // [Fact]
    //     // public async Task Get_get_catalogitem_by_id_and_response_ok_status_code()
    //     // {
    //     //     using (var server = CreateServer())
    //     //     {
    //     //         var response = await server.CreateClient()
    //     //             .GetAsync(Get.CertificateBy(1));
    //     //
    //     //         response.EnsureSuccessStatusCode();
    //     //     }
    //     // }
    //     //
    //     // [Fact]
    //     // public async Task Get_get_catalogitem_by_id_and_response_bad_request_status_code()
    //     // {
    //     //     using (var server = CreateServer())
    //     //     {
    //     //         var response = await server.CreateClient()
    //     //             .GetAsync(Get.CertificateBy(1));
    //     //
    //     //         Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    //     //     }
    //     // }
    //
    //     [Fact]
    //     public async Task Get_certificate_item_by_id_and_response_not_found_status_code()
    //     {
    //         using (var server = CreateServer())
    //         {
    //             var response = await server.CreateClient()
    //                 .GetAsync(Get.CertificateBy(int.MaxValue));
    //
    //             Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    //         }
    //     }
    // }
}