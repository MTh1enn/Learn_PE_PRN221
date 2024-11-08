using CandidateManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_DAO
{
    public class CandidateProfileDAO
    {
        public CandidateManagementContext dbContext;
        public static CandidateProfileDAO instance;
        public  CandidateProfileDAO()
        {
            dbContext = new CandidateManagementContext();
        }
        public static CandidateProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }
        }
        public List<CandidateProfile> GetCandidates()
        {
            return dbContext.CandidateProfiles.ToList();
        }
    }
}
