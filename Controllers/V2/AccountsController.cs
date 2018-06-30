using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using SfmcOdataDemo.Models;

namespace SfmcOdataDemo.Controllers.V2
{
    // Controller name follows convention per: http://odata.github.io/WebApi/#03-01-routing-abstract
    [ApiVersion( "2.0" )]
    //[ODataRoutePrefix("v{version:apiVersion}")]
    [Produces("application/json")]
    public class AccountsController : ODataController
    {
        private readonly SfmcContext context;
    
        public AccountsController(SfmcContext context) => this.context = context;
    
        // GET ~/v1/Accounts
        [EnableQuery]
        public IQueryable<Account> Get() => this.context.Accounts.AsQueryable();

        // GET ~/v1/Accounts(1)
        [EnableQuery]
        public SingleResult Get(int id)
        {
            var result = this.context.Accounts.Where(a => a.AccountId == id);
            return SingleResult.Create(result);
        }
    }
}