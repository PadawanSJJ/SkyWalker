using SkyWalker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWalker.IService
{
    public interface ICitizenService:IBaseService<Citizen>
    {
        Task<Citizen> QueryByEmailAsync(string email);
        Task<Citizen> QueryByPhoneNoAsync(string phoneNo);
    }
}
