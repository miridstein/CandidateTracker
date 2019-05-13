using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace CandidateTracker.Data
{
    public class CandidateRepository
    {
        private string _connectionString;

        public CandidateRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IEnumerable<Candidate> GetPendingCandidates()
        {
            using (var cc = new CandidateContext(_connectionString))
            {
                return cc.Candidates.Where(c => c.Status == null).ToList();
            }
        }
        public IEnumerable<Candidate> GetConfirmedCandidates()
        {
            using (var cc = new CandidateContext(_connectionString))
            {
                return cc.Candidates.Where(c => c.Status == true).ToList();
            }
        }
        public IEnumerable<Candidate> GetDeclinedCandidates()
        {
            using (var cc = new CandidateContext(_connectionString))
            {
                return cc.Candidates.Where(c => c.Status == false).ToList();
            }
        }
        public void AddCandidate(Candidate c)
        {
            using (var cc = new CandidateContext(_connectionString))
            {
                cc.Candidates.Add(c);
                cc.SaveChanges();
            }
        }
        public void ConfirmCandidate(int id)
        {
            using (var cc = new CandidateContext(_connectionString))
            {
                cc.Database.ExecuteSqlCommand("UPDATE candidates SET status = 1 WHERE Id = @id",
                       new SqlParameter("@id", id));
            }
        }
        public void DeclineCandidate(int id)
        {
            using (var cc = new CandidateContext(_connectionString))
            {
                cc.Database.ExecuteSqlCommand("UPDATE candidates SET status = 0 WHERE Id = @id",
                       new SqlParameter("@id", id));
            }
        }
        public Candidate GetCandidate(int id)
        {
            using (var cc = new CandidateContext(_connectionString))
            {
                return cc.Candidates.FirstOrDefault(c => c.Id == id);
            }
        }

    }
}
