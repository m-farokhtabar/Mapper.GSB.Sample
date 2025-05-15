using System.Text.Json.Serialization;

namespace Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.ResponseBody
{
    /// <summary>
    /// 
    /// </summary>
    public class RootResultDto<T> where T : IBodyData
    {
        /// <summary>
        /// 
        /// </summary>
        public DataResultDto<T>? Result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Status? Status { get; set; }
        /// <summary>
        /// داده های مورد نظر در این کلاس به صورت رشته جی سان
        /// </summary>
        [JsonIgnore]
        public string JsonStringifyData { get; set; } = string.Empty;
    }
}
