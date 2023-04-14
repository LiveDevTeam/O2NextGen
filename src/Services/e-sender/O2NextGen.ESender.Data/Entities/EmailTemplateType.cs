namespace O2NextGen.ESender.Data.Entities
{
    public enum EmailTemplateType
    {
        /// <summary>
        /// The supplier company register
        /// </summary>
        SupplierCompanyRegister = 1,

        /// <summary>
        /// Creates new supplierregistration.
        /// </summary>
        NewSupplierRegistration = 2,

        /// <summary>
        /// The customer company register
        /// </summary>
        CustomerCompanyRegister = 3,

        /// <summary>
        /// Creates new customerregistration.
        /// </summary>
        NewCustomerRegistration = 4,

        /// <summary>
        /// Creates new useradded.
        /// </summary>
        NewUserAdded = 5,

        /// <summary>
        /// The user activation
        /// </summary>
        UserActivation = 6,

        /// <summary>
        /// The forgot password
        /// </summary>
        ForgotPassword = 7,

        /// <summary>
        /// The contact us to admin
        /// </summary>
        ContactUsToAdmin = 8,

        /// <summary>
        /// The company new membership plan
        /// </summary>
        CompanyNewMembershipPlan = 9,

        /// <summary>
        /// Creates new membershipplantobeactivated.
        /// </summary>
        NewMembershipPlanToBeActivated = 10,

        /// <summary>
        /// The activate membership plan
        /// </summary>
        ActivateMembershipPlan = 11,

        /// <summary>
        /// The renew membership plan
        /// </summary>
        RenewMembershipPlan = 12,

        ///// <summary>
        ///// Creates new plantobeactivatedforsupplier.
        ///// </summary>
        //PlanToBeActivatedForSupplier = 13,

        ///// <summary>
        ///// The customer new membership plan
        ///// </summary>
        //SupplierNewMembershipPlan = 14,

        ///// <summary>
        ///// The renew membership plan
        ///// </summary>
        //RenewMembershipPlanForSupplier = 15,

        ///// <summary>
        ///// The activate membership plan
        ///// </summary>
        //ActivatePlanForSupplier = 16,
    }
}