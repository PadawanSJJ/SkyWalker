using Microsoft.VisualBasic;
using SkyWalker.IRepository;
using SkyWalker.IService;
using SkyWalker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyWalker.Service
{
    public class CitizenService : BaseService<Citizen>, ICitizenService
    {
        private readonly ICitizenRepository _citizenRepository;
        public CitizenService(ICitizenRepository citizenRepository) : base(citizenRepository)
        {
            _citizenRepository = citizenRepository;
        }

        public async Task<Citizen> QueryByEmailAsync(string email)
        {
            return await _citizenRepository.QueryByEmailAsync(email);
        }

        public async Task<Citizen> QueryByPhoneNoAsync(string phoneNo)
        {
            return  await  _citizenRepository.QueryByPhoneNoAsync(phoneNo);
        }
    }
}
