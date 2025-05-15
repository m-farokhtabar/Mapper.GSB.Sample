using MOHME.Lib.Shared;
using MOHME.Lib.Helper.Validator;
using Services.ExceptionManager;

namespace Mapper.GSB.Application.Insurance.Commands.Save;

/// <summary>
/// مشخصات صندوق های مرتبط با بیمه شده
/// </summary>
public class AccountVODto
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
    public AccountVODto(string? accountID, DO_CODED_TEXT? accountType, DO_DATE? createDate, int? insuranceLength, DO_DATE? initiateDate, int? waitingLength, DO_DATE? activeFrom, DO_DATE? activeTo, DO_CODED_TEXT? accountStatus)
    {
        
        AccountID = accountID;
        AccountType = accountType is not null && accountType.areAllPropsNullOrEmpty() ? null : accountType;
        CreateDate = createDate is not null && createDate.areAllPropsNullOrEmpty() ? null : createDate;
        InsuranceLength = insuranceLength;
        InitiateDate = initiateDate is not null && initiateDate.areAllPropsNullOrEmpty() ? null : initiateDate;
        WaitingLength = waitingLength;
        ActiveFrom = activeFrom is not null && activeFrom.areAllPropsNullOrEmpty() ? null : activeFrom;
        ActiveTo = activeTo is not null && activeTo.areAllPropsNullOrEmpty() ? null : activeTo;
        AccountStatus = accountStatus is not null && accountStatus.areAllPropsNullOrEmpty() ? null : accountStatus;
    }
    /// <summary>
    /// شماره سریال مرتبط با صندوق یا خدمت ثبت شده برای این بیمه شده در نرم افزار بیمه گری
    /// </summary>
    public string? AccountID { get; private set; }
    /// <summary>
    /// کد نوع صندوق – خدمت ، از  ترمینولوژی thritaEHR.insuranceBox استفاده گردد و برای بیمه فول درمان اجباری است.  --- ؟  insuranceBox 
    /// </summary>
    public DO_CODED_TEXT? AccountType { get; private set; }
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
    public DO_DATE? ActiveFrom { get; private set; }
    /// <summary>
    /// تاریخ پایان اعتبار ---- ؟  insuranceExpirationDate
    /// </summary>
    public DO_DATE? ActiveTo { get; private set; }
    /// <summary>
    /// وضعیت اعتباری صندوق یا خدمت -معتبر -غیر معتبر 
    /// </summary>
    public DO_CODED_TEXT? AccountStatus { get; private set; }
}
