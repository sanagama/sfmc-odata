using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using SfmcOdataDemo.Models;

namespace SfmcOdataDemo.Controllers.V2
{
    // Controller name follows convention per: http://odata.github.io/WebApi/#03-01-routing-abstract
    [ApiVersion( "2.0" )]
    [ODataRoutePrefix("v{version:apiVersion}")]
    [Produces("application/json")]
    public class EmailsController : ODataController
    {
        private readonly SfmcContext context;
    
        public EmailsController(SfmcContext context) => this.context = context;
    
        // GET ~/v2/emails
        [EnableQuery]
        public IQueryable<Email> Get() => this.context.Emails.AsQueryable();

        // GET ~/v2/emails(1)
        [EnableQuery]
        public SingleResult Get(int messageKey)
        {
            var result = this.context.Emails.Where(e => e.MessageKey == messageKey);
            return SingleResult.Create(result);
        }
    }
}