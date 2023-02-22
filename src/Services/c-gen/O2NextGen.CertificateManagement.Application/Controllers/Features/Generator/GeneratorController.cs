using System.Drawing;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using O2NextGen.CertificateManagement.Application.Helpers;
using O2NextGen.CertificateManagement.Application.Services;
using O2NextGen.CertificateManagement.Domain.Entities;
using O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.GetCategories;
using O2NextGen.CertificateManagement.Domain.UseCases.ForCategory.GetCategory;
using O2NextGen.CertificateManagement.Domain.UseCases.ForCertificate.GetCertificate;
using O2NextGen.CertificateManagement.Domain.UseCases.ForCertificate.GetCertificates;

namespace O2NextGen.CertificateManagement.Application.Controllers.Features.Generator;
[Authorize]
[ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiController]
    // ReSharper disable once RouteTemplates.RouteParameterConstraintNotResolved
    [Route("api/v{v:apiVersion}/generator")]
    public class GeneratorController : ControllerBase
    {
    
        #region Ctors
        
        public GeneratorController(
            ITemplateService templateService,
            IQrCodeService qrCodeService,IMediator mediator)
        {
            _templateService = templateService;
            _qrCodeService = qrCodeService;
            _mediator = mediator;
        }
        
        #endregion

        #region Methods
        
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetCertificate([FromQuery(Name = "certificateId")] long certificateId,CancellationToken ct)
        {
            var languageId = 1;
            var existCertificate = await _mediator.Send(new GetCertificateQuery(certificateId), ct);;//await _certificateService.GetAsync(certificateId);
        
            if (existCertificate == null)
                throw new ArgumentException($"Certificate {nameof(existCertificate)} not found");
        
            //category
            var catId = existCertificate.CategoryId;
            var category = await _mediator.Send(new GetCategoryQuery(catId), ct);//await _categoryService.GetAsync(catId);

            var categoryEntity = new CategoryEntity()
            {
               CategoryDescription = category.CategoryDescription,
               CategorySeries = category.CategorySeries,
               CustomerId = category.CustomerId,
               CategoryName = category.CategoryName,
               QuantityCertificates = category.QuantityCertificates,
               QuantityPublishCode = category.QuantityPublishCode,
               
               Id = category.Id,
               DeletedDate = category.DeletedDate,
               ModifiedDate = category.ModifiedDate,
               IsDeleted = category.IsDeleted,
               AddedDate = category.AddedDate,
            };
            
            existCertificate.CategoryEntity = categoryEntity ;
            var fio = string.Empty;
            //LanguageInfoModel infoLanguage;
            // if (languageId == 1)
            // {
            //     infoLanguage = existCertificate.LanguageInfos.Where(x => x.LanguageId == 1).FirstOrDefault();
            //     if (!string.IsNullOrEmpty(infoLanguage.Lastname))
            //         fio = infoLanguage.Lastname.Trim();
            //     
            //     if (!string.IsNullOrEmpty(infoLanguage.Firstname))
            //         fio = fio + " " + infoLanguage.Firstname.Trim();
            //    
            //     if (!string.IsNullOrEmpty(infoLanguage.Middlename))
            //         fio = fio + "\n" + infoLanguage.Middlename.Trim();
            // }
            //
            // if (languageId == 2)
            // {
            //     infoLanguage = existCertificate.LanguageInfos.Where(x => x.LanguageId == 1).FirstOrDefault();
            //     if (!string.IsNullOrEmpty(infoLanguage.Firstname))
            //         fio = infoLanguage.Firstname.Trim();
            //     if (!string.IsNullOrEmpty(infoLanguage.Lastname))
            //         fio = fio + " " + infoLanguage.Lastname.Trim();
            //     
            // }
        
           
        
            var certificateNumber =
                existCertificate.CategoryEntity.CategorySeries + " - " + existCertificate.PublishCode;
        
            if (category == null)
                throw new ArgumentException($"CategoryModel {nameof(category)} not found");
        
        
            var categoryModelId = existCertificate.CategoryEntity.Id;
        
            var templateImage = _templateService.GetTemplate(categoryModelId);
        
            var bitmapClear = new Bitmap(templateImage.Width, templateImage.Height);
        
            var template = _templateService.GetSettingsOtTemplate(categoryModelId);
        
            var templateSettings = template.Items;
        
            Image qrCodeImage = null;
        
            if (templateSettings.Any(x => x.ElementType == TemplateService.ElementType.QrCode))
            {
                var templateSetting = templateSettings.Where(x => x.ElementType == TemplateService.ElementType.QrCode)
                    .FirstOrDefault();
                qrCodeImage = await _qrCodeService.GetQrCodeBasicCertificate(existCertificate.CategoryId,
                    templateSetting.Width);
            }
        
        
            using (var graphics = Graphics.FromImage(bitmapClear))
            {
                graphics.DrawImage(templateImage, 0, 0, templateImage.Width, templateImage.Height);
        
                var myTaskList = new List<Task>();
        
        
                foreach (var templateSetting in templateSettings)
                    switch (templateSetting.ElementType)
                    {
                        case TemplateService.ElementType.QrCode:
                        {
                            //var taskR = new Task(
                            //    () =>
                            //    {
        
                            // For pedagogical use only: in general, don't do this!
        
                            graphics.DrawImage(qrCodeImage, templateSetting.PointX, templateSetting.PointY,
                                qrCodeImage.Width, qrCodeImage.Height);
                            //    });
                            //myTaskList.Add(taskR);
                        }
                            break;
                        case TemplateService.ElementType.Text:
                        {
                            //var taskR = new Task(
                            //    () =>
                            //    {
                            ImageHelper.AddedText(fio, bitmapClear, graphics, "Arial", 95, Brushes.Black,
                                templateSetting.PointY,
                                StringAlignment.Center, StringAlignment.Center);
                            //    });
                            //myTaskList.Add(taskR);
                        }
                            break;
                        case TemplateService.ElementType.SpecialNumber:
                        {
                            //var taskR = new Task(
                            //    () =>
                            //    {
                            ImageHelper.AddedText(certificateNumber, bitmapClear, graphics, "Arial", 45, Brushes.Red,
                                templateSetting.PointY,
                                StringAlignment.Center, StringAlignment.Near);
                            //    });
                            //myTaskList.Add(taskR);
                        }
                            break;
                        case TemplateService.ElementType.Signature:
                            break;
                        case TemplateService.ElementType.Stamp:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
        
                Parallel.ForEach(myTaskList, task => task.Start());
        
                //ImageHelper.AddedText(fio, bitmapClear, graphics, "Arial", 95, Brushes.Black, 1550,
                //    StringAlignment.Center, StringAlignment.Center);
        
                //added serial_number
        
                //graphics.DrawImage(qrCodeImage, 1070, 2901, qrCodeImage.Width, qrCodeImage.Height);
            }
        
            var bitmapBytes = ImageHelper.BitmapToBytes(bitmapClear); //Convert bitmap into a byte array
        
            return File(bitmapBytes, "image/jpeg");
        }
        
        #endregion
        
        
        #region Fields
        
        // private readonly ICertificateReService<CertificateModel> _certificateService;
        // private readonly ICategoryReService<CategoryModel> _categoryService;
        //
        // private readonly
        //     ICertificateManagementHistoryReService<CertificateManagementHistoryModel> _certificateManagementHistoryRe;
        //
        private readonly ITemplateService _templateService;
        
        private readonly IQrCodeService _qrCodeService;
        private readonly IMediator _mediator;

        #endregion
    }