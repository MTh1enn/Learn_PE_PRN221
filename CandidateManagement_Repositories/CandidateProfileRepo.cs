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
        public CandidateProfile GetCandidateProfileById(string id)
        => CandidateProfileDAO.Instance.GetCandidateProfileById(id);
        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        => CandidateProfileDAO.Instance.AddCandidateProfile(candidateProfile);
        public bool DeleteCandidateProfile(CandidateProfile candidateProfile)
        => CandidateProfileDAO.Instance.DeleteCandidateProfile(candidateProfile);

        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        => CandidateProfileDAO.Instance.UpdateCandidateProfile(candidateProfile);
    }
}
