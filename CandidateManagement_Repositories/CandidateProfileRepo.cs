using CandidateManagement_BusinessObjects;
using CandidateManagement_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Repositories
{
    public class CandidateProfileRepo : ICandidateProfileRepo
    {
        public List<CandidateProfile> GetCandidates()
        => CandidateProfileDAO.Instance.GetCandidates();
    }
}
