using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace QueuingSystem.DAL
{
    public class ContextManager
    {
        public ContextManager(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration;

        public static QueuingSystemContext GetContext()
        {
            //var connectionstring = Configuration.GetConnectionString("QueuingSystemContext");
            var connectionstring = "data source=localhost; Initial Catalog=QueuingSystem; Integrated Security=True;";
            var optionsBuilder = new DbContextOptionsBuilder<QueuingSystemContext>();
            optionsBuilder.UseSqlServer(connectionstring);
            QueuingSystemContext context = new QueuingSystemContext(optionsBuilder.Options);
            return context;
        }
    }
}
