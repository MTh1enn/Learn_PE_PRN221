using CandidateManagement_BusinessObjects;
using Microsoft.EntityFrameworkCore;
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
        public CandidateProfileDAO()
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

        public CandidateProfile GetCandidateProfileById(string id)
        {
            return dbContext.CandidateProfiles.SingleOrDefault(m => m.CandidateId.Equals(id));
        }

        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSucess = false;
            CandidateProfile candidate = GetCandidateProfileById(candidateProfile.CandidateId);
            try
            {
                if (candidate == null)
                {
                    dbContext.CandidateProfiles.Add(candidateProfile);
                    dbContext.SaveChanges();
                    isSucess = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSucess;
        }

        public bool DeleteCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSucess = false;
            CandidateProfile candidate = GetCandidateProfileById(candidateProfile.CandidateId);
            try
            {
                if (candidate != null)
                {
                    dbContext.CandidateProfiles.Remove(candidateProfile);
                    dbContext.SaveChanges();
                    isSucess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSucess;
        }
        public bool UpdateCandidateProfile(CandidateProfile candidateProfile)
        {
            bool isSuccess = false;
            try
            {
                var existingCandidate = GetCandidateProfileById(candidateProfile.CandidateId);

                if (existingCandidate != null)
                {
                    dbContext.Entry(existingCandidate).State = EntityState.Detached;
                    dbContext.CandidateProfiles.Attach(candidateProfile);
                    dbContext.Entry(candidateProfile).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }
    }
}
