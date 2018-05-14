using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using SfmcOdataDemo.Models;

namespace SfmcOdataDemo.Controllers
{
    // Controller name follows convention per: http://odata.github.io/WebApi/#03-01-routing-abstract
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