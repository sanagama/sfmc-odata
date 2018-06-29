using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using SfmcOdataDemo.Models;

namespace SfmcOdataDemo.Controllers
{
    // Controller name follows convention per: http://odata.github.io/WebApi/#03-01-routing-abstract
    [Produces("application/json")]
    public class EmailsController : ODataController
    {
        private readonly SfmcContext context;
    
        public EmailsController(SfmcContext context) => this.context = context;
    
        // GET: odata/Emails
        [EnableQuery]
        public IQueryable<Email> Get() => context.Emails.AsQueryable();
    }
}