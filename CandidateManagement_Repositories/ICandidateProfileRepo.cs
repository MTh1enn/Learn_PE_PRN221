using CandidateManagement_BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Repositories
{
    public interface ICandidateProfileRepo
    {
        public List<CandidateProfile> GetCandidates();
    }
}
