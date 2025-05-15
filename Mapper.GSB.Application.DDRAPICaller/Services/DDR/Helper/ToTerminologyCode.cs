using openEHR.Library.Base.FoundationTypes.Terminology;
using openEHR.Library.Rm.DataTypes.Text;

namespace Mapper.GSB.Application.DDRAPICaller.Services.DDR.Helper;

/// <summary>
/// مبدل داده
/// به کلاس 
/// TerminologyCode
/// طبق استاندارد 
/// openEHR
/// </summary>
public static class ToTerminologyCode
{
    /// <summary>
    /// مبدل از 
    /// DvCodedText
    /// به
    /// TerminologyCode
    /// </summary>
    /// <param name="Code"></param>
    /// <returns></returns>
    public static TerminologyCode Map(DvCodedText Code) => new(Code.DefiningCode.TerminologyId.Name(), Code.DefiningCode.TerminologyId.VersionId(), Code.DefiningCode.CodeString, null);
}
