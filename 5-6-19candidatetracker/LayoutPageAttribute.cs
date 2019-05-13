using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandidateTracker.Data;

namespace _5_6_19candidatetracker
{
    public class LayoutPageAttribute : ActionFilterAttribute
    {
        private string _connectionString;

        public LayoutPageAttribute(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");

        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var controller = (Controller)context.Controller;
            var repo = new CandidateRepository(_connectionString);
            controller.ViewBag.Pending = repo.GetPendingCandidates().Count().ToString();
            controller.ViewBag.Confirmed = repo.GetConfirmedCandidates().Count().ToString();
            controller.ViewBag.Declined = repo.GetDeclinedCandidates().Count().ToString();
            base.OnActionExecuted(context);
        }
    }
}



