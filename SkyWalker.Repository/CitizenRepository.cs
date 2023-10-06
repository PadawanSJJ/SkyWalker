using SkyWalker.IRepository;
using SkyWalker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWalker.Repository
{
    public class CitizenRepository:BaseRepository<Citizen>,ICitizenRepository
    {
        public async Task<Citizen> QueryByEmailAsync(string email)
        {
            return await FindAsync(n=>n.Email == email);
        }

        public async Task<Citizen> QueryByPhoneNoAsync(string phoneNo)
        {
            return await FindAsync(n=>n.PhoneNo == phoneNo);
        }
    }
}
