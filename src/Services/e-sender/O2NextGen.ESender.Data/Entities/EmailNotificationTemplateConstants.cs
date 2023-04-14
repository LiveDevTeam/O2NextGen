namespace O2NextGen.ESender.Data.Entities
{
    public class EmailNotificationTemplateConstants
    {
        public static string OuterBody =>
            $@"
                <!doctype html>
                <html lang='en'>
                    <head>
                        <meta charset='utf-8'>
                        <meta name='viewport' content='width=device-width, initial-scale=1'>
                        <title>Mesh Global Sourcing</title>
                        <meta name='description' content='Metrics Works'>
                        <link rel='preconnect' href='https://fonts.googleapis.com'>
                        <link rel='preconnect' href='https://fonts.gstatic.com' crossorigin>
                        <link href='https://fonts.googleapis.com/css2?family=Roboto:wght@300;400;500;700;900&display=swap' rel='stylesheet'>
                        <style>
                            body
                            {{
                                background:#f1f0f5;
                                margin: 20px 0;
                                font-size:14px;
                                color:rgba(0,0,0,0.8);
                            }}
                            table
                            {{
                                max-width: 700px;
                                background: #fff;
                                border-radius:10px;
                                width: 100%;
                                font-family: 'Roboto', sans-serif;
                                box-shadow: 0px 0px 11px 0px rgba(0,0,0,0.19);
                                -webkit-box-shadow: 0px 0px 11px 0px rgba(0,0,0,0.19);
                                -moz-box-shadow: 0px 0px 11px 0px rgba(0,0,0,0.19);
                            }}
                            a
                            {{
                                text-decoration: none;
                            }}
                            table td
                            {{
                                padding:10px;
                            }}
                            .logo
                            {{
                                display: block;
                                margin-left: auto;
                                margin-right: auto;
                            }}
                            .footer .logo
                            {{
                                width: 110px;
                            }}
                            .highlighted-text
                            {{
                                color: #FF8C00;
                            }}
                            .button
                            {{
                                background-color: #FF8C00;
                                border: none;
                                color: white;
                                padding: 12px 20px;
                                text-align: center;
                                text-decoration: none;
                                display: inline-block;
                                font-size: 16px;
                                cursor: pointer;
                                border-radius: 120px;
                            }}
                            .contact-information {{
                                color: #D0D0D0
                            }}
                        </style>
                    </head>
                    <body>
                        <table width='100%' border='0' cellspacing='0' cellpadding='0'  align='center'>
                            <tr align='left' valign='middle'>
                                <td><img src='{PlaceholderLogoUrl}' class='logo'></td>
                            </tr>
                            <tr>
                                <td colspan='2' style='text-align:center'>
                                    <br /><b class='highlighted-text'>{PlaceholderSubject}</b>
                                <td>
                            </tr>
                            <tr>
                                <td colspan='2' style=' padding:10px 20px'>
                                    <br />Hello,<br /><br />
                                    {PlaceholderContent}
                                </td>
                            </tr>
                            <tr>
                                <td colspan='2' style='padding:10px 20px'>
                                    <br />Thank you,<br />O2Bionics Team
                                </td>
                            </tr>
                            <tr class='footer'>
                                <td colspan='2' style='border-top:1px solid #f1f0f5; padding:20px 10px; text-align:center'>
                                    <p><a href='{PlaceholderViewDetailsUrl}' target='_blank'><button class='button'>View Details</button></a></p>
                                    <br />
                                    <p><img src='{PlaceholderLogoUrl}' class='logo'></p>
                                    <p>O2 Bionics LLC</p>
                                    <p class='contact-information'>1-833-MESHRFQ</p>
                                    <p class='contact-information'>info@o2bionics.com</p>
                                    <p class='contact-information'>16192 Coastal Highway Lewes, DE 19958</p>
                                    <p>
                                        <a href='https://www.linkedin.com/company/meshglobalsourcing' target='_blank'>
                                            <img src='{PlaceholderLinkedinUrl}' title='Go to O2Bionics Linkedin' />
                                        </a>
                                        <a href='https://www.facebook.com/meshglobalsourcing' target='_blank'>
                                            <img src='{PlaceholderFacebookUrl}' title='Go to O2Bionics Facebook' />
                                        </a>
                                        <a href='https://twitter.com/MESHsourcing' target='_blank'>
                                            <img src='{PlaceholderTwitterUrl}' title='Go to O2Bionics Twitter' />
                                        </a>
                                    </p>
                                </td>
                            </tr>
                        </table>
                    </body>
                </html>";

        // Common
        public const string PlaceholderCreated = "##Created##";
        public const string PlaceholderUpdated = "##Updated##";
        public const string PlaceholderCreatedBy = "##CreatedBy##";
        public const string PlaceholderUpdatedBy = "##UpdatedBy##";
        public const string PlaceholderLogoUrl = "##LogoUrl##";
        public const string PlaceholderSubject = "##Subject##";
        public const string PlaceholderContent = "##Content##";
        public const string PlaceholderViewDetailsUrl = "##ViewDetailsUrl##";
        public const string PlaceholderLinkedinUrl = "##LinkedinUrl##";
        public const string PlaceholderFacebookUrl = "##FacebookUrl##";
        public const string PlaceholderTwitterUrl = "##TwitterUrl##";

        // APQP project
        public const string PlaceholderApqpProjectName = "##ApqpProjectName##";
        public const string PlaceholderApqpProjectTemplateName = "##ApqpProjectTemplateName##";
        public const string PlaceholderApqpProjectDescription = "##ApqpProjectDescription##";
        public const string PlaceholderApqpUpdateDateTime = "##ApqpProjectDateTime##";
        public const string PlaceholderApqpProjectComment = "##ApqpProjectComment##";
        public const string PlaceholderApqpProjectDocumentType = "##ApqpProjectDocumentType##";
        public const string PlaceholderApqpProjectDocumentName = "##ApqpProjectDocumentName##";
        public const string PlaceholderApqpProjectGateName = "##ApqpProjectGateName##";
        public const string PlaceholderApqpProjectPartNumbers = "##ApqpProjectPartNumbers##";

        // APQP Gate Closure
        public const string PlaceholderGateClosureMessage = "##ClosureMessage##";
        public const string PlaceholderGateClosureApprovalStatus = "##ApprovalStatus##";
        public const string PlaceholderGateClosureEmailRecipient = "##ClosureEmailRecipient##";
        public const string PlaceholderGateClosureEmailSender = "##ClosureEmailSender##";

        // Incident
        public const string IncidentStatusOpenedDescription = "opened";
        public const string IncidentStatusClosedDescription = "closed";
        public const string PlaceholderIncidentNumber = "##IncidentNumber##";
        public const string PlaceholderIncidentPartNumbers = "##IncidentPartNumbers##";
        public const string PlaceholderIncidentTypeName = "##IncidentTypeName##";
        public const string PlaceholderIncidentSupplierPlant = "##IncidentSupplierPlant##";
        public const string PlaceholderIncidentIsProblem = "##IncidentIsProblem##";
        public const string PlaceholderIncidentDefectType = "##IncidentDefectType##";
        public const string PlaceholderIncidentQuantity = "##IncidentQuantity##";
        public const string PlaceholderIncidentStatusDescription = "##IncidentStatusDescription##";

        // Part
        public const string ModifiedFieldValueTemplate =
            "<b class='highlighted-text'>{0}:</b> from '{1}' to '{2}'<br />";

        public const string PlaceholderPartNumber = "##PartNumber##";
        public const string PlaceholderPartModifiedFieldsSummary = "##PartModifiedFieldsSummary##";
    }
}