using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.GSB.Domain.Insurance
{
    /// <summary>
    /// ریپو جهت ذخیره سازی اطلاعات فرد و بیمه نامه
    /// </summary>
    public interface IPersonInsuranceRepository
    {
        /// <summary>
        /// ثبت اطلاعات فرد و بیمه نامه
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(PersonInsurance entity);
        /// <summary>
        /// ویرایش اطلاعات فرد و بیمه نامه
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(PersonInsurance entity);
    }
}
