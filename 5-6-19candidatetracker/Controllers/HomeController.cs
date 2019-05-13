using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _5_6_19candidatetracker.Models;
using CandidateTracker.Data;
using Microsoft.Extensions.Configuration;

namespace _5_6_19candidatetracker.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString;

        public HomeController(IConfiguration configuration )
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }
        public IActionResult AddCandidateToDb(Candidate c)
        {
            var repo = new CandidateRepository(_connectionString);
            repo.AddCandidate(c);
            return Redirect("/home/index");
        }
        public IActionResult AddCandidate()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PendingView()
        {
            var repo = new CandidateRepository(_connectionString);
           IEnumerable<Candidate> candies= repo.GetPendingCandidates();
            return View(candies);
        }

        public IActionResult ConfirmedView()
        {
            var repo = new CandidateRepository(_connectionString);
            IEnumerable<Candidate> candies = repo.GetConfirmedCandidates();
            return View(candies);
        }
        public IActionResult DeclinedView()
        {
            var repo = new CandidateRepository(_connectionString);
            IEnumerable<Candidate> candies = repo.GetDeclinedCandidates();
            return View(candies);
        }
        public IActionResult CandidateDetails(int id)
        {
            var repo = new CandidateRepository(_connectionString);
           Candidate c=  repo.GetCandidate(id);
            return View(c);
                    }
        public void ConfirmCandidate(int id)
        {
            var repo = new CandidateRepository(_connectionString);
            repo.ConfirmCandidate(id);
        }
        public void DeclineCandidate(int id)
        {
            var repo = new CandidateRepository(_connectionString);
            repo.DeclineCandidate(id);
        }
    }
}
