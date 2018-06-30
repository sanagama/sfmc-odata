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
    public class ContactsController : ODataController
    {
        private readonly SfmcContext context;
    
        public ContactsController(SfmcContext context) => this.context = context;
    
        // GET: odata/Contacts
        [EnableQuery]
        public IQueryable<Contact> Get() => context.Contacts.AsQueryable();
    }
}