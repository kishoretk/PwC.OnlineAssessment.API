using PwC.OnlineAssessment.API.Entities.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace PwC.OnlineAssessment.API.Entities
{
    public class ClientsRepository: IClientsRepository
    {
        private readonly ClientsContext clientsContext;
        public ClientsRepository(ClientsContext _clientsContext)
        {
            clientsContext = _clientsContext;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await clientsContext.Clients.ToListAsync();
        }

        public async Task<Client> Get(Guid id)
        {
            return await clientsContext.Clients.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Create(Client client)
        {
            clientsContext.Clients.Add(client);
            await clientsContext.SaveChangesAsync();
        }

        public async Task Update(Client currentClient, Client newClient)
        {
            clientsContext.Entry(currentClient).CurrentValues.SetValues(newClient);
            clientsContext.Update(currentClient);
            await clientsContext.SaveChangesAsync();
        }

        public async Task Delete(Client client)
        {
            clientsContext.Clients.Remove(client);
            await clientsContext.SaveChangesAsync();
        }

    }
}
