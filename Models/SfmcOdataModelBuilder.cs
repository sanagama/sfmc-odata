
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;

namespace SfmcOdataDemo.Models
{
    public class SfmcOdataModelBuilder
    {
        public IEdmModel GetEdmModel(System.IServiceProvider serviceProvider)
        {
            var builder = new ODataConventionModelBuilder(serviceProvider);
            //builder.EntitySet<Account>("Accounts");
            //builder.EntitySet<Contact>("Contacts");
            //builder.EntitySet<Email>("Emails");

            builder.EntitySet<Account>("Accounts")
                            .EntityType
                            .Filter() // Allow for the $filter Command
                            .Count() // Allow for the $count Command
                            .Expand() // Allow for the $expand Command
                            .OrderBy() // Allow for the $orderby Command
                            .Page() // Allow for the $top and $skip Commands
                            .Select();// Allow for the $select Command; 

            builder.EntitySet<Contact>("Contacts")
                            .EntityType
                            .Filter() // Allow for the $filter Command
                            .Count() // Allow for the $count Command
                            .Expand() // Allow for the $expand Command
                            .OrderBy() // Allow for the $orderby Command
                            .Page() // Allow for the $top and $skip Commands
                            .Select() // Allow for the $select Command
                            .Expand(); 

            builder.EntitySet<Email>("Emails")
                            .EntityType
                            .Filter() // Allow for the $filter Command
                            .Count() // Allow for the $count Command
                            .Expand() // Allow for the $expand Command
                            .OrderBy() // Allow for the $orderby Command
                            .Page() // Allow for the $top and $skip Commands
                            .Select() // Allow for the $select Command
                            .Expand(); 

            return builder.GetEdmModel();
        }
    }
}