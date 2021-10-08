using Microsoft.EntityFrameworkCore;
using PwC.OnlineAssessment.API.Entities.Models;

namespace PwC.OnlineAssessment.API.Entities
{
    public class ClientsContext:DbContext
    {
        public ClientsContext(DbContextOptions<ClientsContext> options) : base(options) {}
        public  DbSet<Client> Clients { get; set; }
    }
}
