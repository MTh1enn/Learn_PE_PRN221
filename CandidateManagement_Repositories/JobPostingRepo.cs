using CandidateManagement_BusinessObjects;
using CandidateManagement_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement_Repositories
{
    public class JobPostingRepo : IJobPostingRepo
    {
        public List<JobPosting> GetJobPostings()
        => JobPostingDAO.Instance.GetJobPostings();

        public JobPosting GetJobPostings(string id)
        => JobPostingDAO.Instance.GetJobPostingById(id);
    }
}
