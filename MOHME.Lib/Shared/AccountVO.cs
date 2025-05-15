using Mapper.GSB.Share.Resource;
using MOHME.Lib.Helper.Validator;
using Services.ExceptionManager;
using Services.ExceptionManager.Resources;

namespace MOHME.Lib.Shared;

/// <summary>
/// مشخصات صندوق های مرتبط با بیمه شده
/// </summary>
public class AccountVO
{
    /// <summary>
    /// ایجاد صندوق مرتبط با بیمه شده
    /// </summary>
    /// <param name="accountID"></param>
    /// <param name="accountType"></param>
    /// <param name="createDate"></param>
    /// <param name="insuranceLength"></param>
    /// <param name="initiateDate"></param>
    /// <param name="waitingLength"></param>
    /// <param name="activeFrom"></param>
    /// <param name="activeTo"></param>
    /// <param name="accountStatus"></param>
    /// <exception cref="ManualException"></exception>
    public AccountVO(string accountID, DO_CODED_TEXT accountType, DO_DATE? createDate, int? insuranceLength, DO_DATE? initiateDate, int? waitingLength, DO_DATE activeFrom, DO_DATE activeTo, DO_CODED_TEXT accountStatus)
    {        
        if (string.IsNullOrWhiteSpace(accountID))
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.AccountVO).Replace("{1}",Names.AccountVO_AccountID),ExceptionType.InValid, typeof(AccountVO).FullName + "." + nameof(AccountID));        
        if (accountType is null)
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.AccountVO).Replace("{1}", Names.AccountVO_AccountType), ExceptionType.InValid, typeof(AccountVO).FullName + "." + nameof(AccountType));
        accountType.Validate(Names.AccountVO, Names.AccountVO_AccountType, typeof(AccountVO).FullName + "." + nameof(AccountType));

        createDate?.Validate(Names.AccountVO, Names.AccountVO_CreateDate, typeof(AccountVO).FullName + "." + nameof(CreateDate));
        initiateDate?.Validate(Names.AccountVO, Names.AccountVO_InitiateDate, typeof(AccountVO).FullName + "." + nameof(InitiateDate));

        if (activeFrom is null)
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.AccountVO).Replace("{1}", Names.AccountVO_ActiveFrom), ExceptionType.InValid, typeof(AccountVO).FullName + "." + nameof(ActiveFrom));
        activeFrom.Validate(Names.AccountVO, Names.AccountVO_ActiveFrom, typeof(AccountVO).FullName + "." + nameof(ActiveFrom));
        if (activeTo is null)
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.AccountVO).Replace("{1}", Names.AccountVO_ActiveTo), ExceptionType.InValid, typeof(AccountVO).FullName + "." + nameof(ActiveTo));
        activeTo.Validate(Names.AccountVO, Names.AccountVO_ActiveTo, typeof(AccountVO).FullName + "." + nameof(ActiveTo));
        if (accountStatus is null)
            throw new ManualException(ExceptionsMessages.Data_Is_not_valid_Value_Is_mandatory.Replace("{0}", Names.AccountVO).Replace("{1}", Names.AccountVO_AccountStatus), ExceptionType.InValid, typeof(AccountVO).FullName + "." + nameof(AccountStatus));
        accountStatus.Validate(Names.AccountVO, Names.AccountVO_AccountStatus, typeof(AccountVO).FullName + "." + nameof(AccountStatus));

        if (activeFrom.ToDateTime() > activeTo.ToDateTime())
            throw new ManualException(ExceptionsMessages.Data_is_not_valid_Value_is_wrong.Replace("{0}", Names.PersonPolicyVO).Replace("{1}", Names.AccountVO_ActiveFrom + "-" + Names.AccountVO_ActiveTo) + " - activeFrom<=activeTo", ExceptionType.InValid, typeof(PersonPolicyVO).FullName + "." + nameof(ActiveFrom));

        AccountID = accountID;
        AccountType = accountType;
        CreateDate = createDate;
        InsuranceLength = insuranceLength;
        InitiateDate = initiateDate;
        WaitingLength = waitingLength;
        ActiveFrom = activeFrom;
        ActiveTo = activeTo;
        AccountStatus = accountStatus;
    }
    /// <summary>
    /// شماره سریال مرتبط با صندوق یا خدمت ثبت شده برای این بیمه شده در نرم افزار بیمه گری
    /// </summary>
    public string AccountID { get; private set; }
    /// <summary>
    /// کد نوع صندوق – خدمت ، از  ترمینولوژی thritaEHR.insuranceBox استفاده گردد و برای بیمه فول درمان اجباری است.  --- ؟  insuranceBox 
    /// </summary>
    public DO_CODED_TEXT AccountType { get; private set; }
    /// <summary>
    /// تاریخ ایجاد-چاپ – تمدید    --- ؟ policyIssueDate 
    /// </summary>
    public DO_DATE? CreateDate { get; private set; }
    /// <summary>
    /// سابقه بیمه در این نوع صندوق یا خدمت -روز
    /// </summary>
    public int? InsuranceLength { get; private set; }
    /// <summary>
    /// تاریخ اولین ثبت نام برای این نوع خدمت
    /// </summary>
    public DO_DATE? InitiateDate { get; private set; }
    /// <summary>
    /// حداقل مدت انتظار از تاریخ شروع جهت ارایه خدمت - روز
    /// </summary>
    public int? WaitingLength { get; private set; }
    /// <summary>
    /// تاریخ شروع اعتبار  --- ؟  effectiveDate
    /// </summary>
    public DO_DATE ActiveFrom { get; private set; }
    /// <summary>
    /// تاریخ پایان اعتبار ---- ؟  insuranceExpirationDate
    /// </summary>
    public DO_DATE ActiveTo { get; private set; }
    /// <summary>
    /// وضعیت اعتباری صندوق یا خدمت -معتبر -غیر معتبر 
    /// </summary>
    public DO_CODED_TEXT AccountStatus { get; private set; }
}
