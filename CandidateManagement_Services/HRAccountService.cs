using CandidateManagement_BusinessObjects;
using CandidateManagement_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Services
{
    public class HRAccountService : IHRAccountService
    {
        private IHRAccountRepo iAccountRepo;
        public HRAccountService()
        {
            iAccountRepo = new HRAccountRepo();
        }
        public Hraccount GetHraccountByEmail(string email)
        {
           return iAccountRepo.GetHraccountByEmail(email);
        }

        public List<Hraccount> GetHraccounts()
        {
            return iAccountRepo.GetHraccounts();
        }
    }
}
