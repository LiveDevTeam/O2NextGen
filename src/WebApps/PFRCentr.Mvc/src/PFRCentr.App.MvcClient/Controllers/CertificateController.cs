using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PFRCentr.App.MvcClient.Models.Dto;
using PFRCentr.App.MvcClient.Services;

namespace PFRCentr.App.MvcClient.Controllers;

[Authorize]
public class CertificateController : Controller
{
    private readonly ICGenCertificateService _cGenCertificateService;

    public CertificateController(ICGenCertificateService cGenCertificateService)
    {
        _cGenCertificateService = cGenCertificateService;
    }
    public async Task<ViewResult> CertificateIndex()
    {
        var response = await _cGenCertificateService.GetCertificatesAsync<List<CertificateDto>>();
        List<ResponseDto> list = null;
        // if (response != null && response.IsSuccess)
        // {
        //     list = JsonConvert.DeserializeObject<List<ResponseDto>>(response.ToString());
        // }
        return View(response);
    }

    public IActionResult CreateCertificate()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateCertificate(CertificateDto model)
    {
        if (ModelState.IsValid)
        {
            var response = await _cGenCertificateService.CreateCertificateAsync<CertificateDto>(model);
            List<ResponseDto> list = null;
            // if (response != null && response.IsSuccess)
            // {
            //     list = JsonConvert.DeserializeObject<List<ResponseDto>>(response.ToString());
            // }
            // if (response == null)
            //     return View(model);
            return RedirectToAction(nameof(CertificateIndex));
        }
        return View(model);
    }
    
    public async Task<IActionResult> EditCertificate(long CertificateId)
    {
        var response = await _cGenCertificateService.GetCertificateByIdAsync<CertificateDto>(CertificateId);
        List<ResponseDto> list = null;
        if (response != null )
            return View(response);
        return NotFound();
        // {
        //     list = JsonConvert.DeserializeObject<List<ResponseDto>>(response.ToString());
        // }
        // if (response == null)
        //     return View(model);

    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditCertificate(CertificateDto model)
    {
        if (ModelState.IsValid)
        {
            var response = await _cGenCertificateService.UpdateCertificateAsync<CertificateDto>(model.Id, model);
            List<ResponseDto> list = null;
            // if (response != null && response.IsSuccess)
            // {
            //     list = JsonConvert.DeserializeObject<List<ResponseDto>>(response.ToString());
            // }
            // if (response == null)
            //     return View(model);
            return RedirectToAction(nameof(CertificateIndex));
        }
        return View(model);
    }
    
    public async Task<IActionResult> DeleteCertificate(long CertificateId)
    {
        var response = await _cGenCertificateService.GetCertificateByIdAsync<CertificateDto>(CertificateId);
        List<ResponseDto> list = null;
        if (response != null )
            return View(response);
        return NotFound();

    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteCertificate(CertificateDto model)
    {
        
            await _cGenCertificateService.DeleteCertificateAsync<CertificateDto>(model.Id);
            return RedirectToAction(nameof(CertificateIndex));
            
    }
}