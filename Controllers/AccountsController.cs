using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using SfmcOdataDemo.Models;

namespace SfmcOdataDemo.Controllers
{
    // Controller name follows convention per: http://odata.github.io/WebApi/#03-01-routing-abstract
    [Produces("application/json")]
    public class AccountsController : ODataController
    {
        private readonly SfmcContext context;
    
        public AccountsController(SfmcContext context) => this.context = context;
    
        // GET: odata/Accounts
        [EnableQuery]
        public IQueryable<Account> Get() => this.context.Accounts.AsQueryable();
    }
}