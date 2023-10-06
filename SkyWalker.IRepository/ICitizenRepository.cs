using SkyWalker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWalker.IRepository
{
    public interface  ICitizenRepository:IBaseRepository<Citizen>
    {
        Task<Citizen> QueryByEmailAsync(string email);
        Task<Citizen> QueryByPhoneNoAsync(string phoneNo);
    }
}
