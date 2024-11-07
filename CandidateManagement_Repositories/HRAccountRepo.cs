using CandidateManagement_BusinessObjects;
using CandidateManagement_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Repositories
{
    public class HRAccountRepo : IHRAccountRepo
    {
        public Hraccount GetHraccountByEmail(string email)
            => HRAccountDAO.Instance.GetHraccountByEmail(email);

        public List<Hraccount> GetHraccounts() => HRAccountDAO.Instance.GetHraccounts();

        
    }
}
