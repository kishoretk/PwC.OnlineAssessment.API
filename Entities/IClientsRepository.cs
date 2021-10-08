using PwC.OnlineAssessment.API.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PwC.OnlineAssessment.API.Entities
{
    public interface IClientsRepository
    {
        Task<IEnumerable<Client>> GetAll();
        Task<Client> Get(Guid id);
        Task Create(Client client);
        Task Update(Client currentClient, Client newClient);
        Task Delete(Client client);
    }
}
