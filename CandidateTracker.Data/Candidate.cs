using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTracker.Data
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool? Status { get; set; }
        public string Notes { get; set; }
    }
}
