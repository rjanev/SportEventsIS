using IsApp.Domain.Models;
using IsApp.Repository.Interface;
using IsApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsApp.Service.Implementation
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> _ticketRepository;

        public TicketService(IRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public void CreateNewProduct(Ticket product)
        {
            _ticketRepository.Insert(product);
        }

        public void DeleteProduct(Guid id)
        {
            Ticket t = _ticketRepository.Get(id);
            _ticketRepository.Delete(t);
        }

        public Ticket GetProductById(Guid? id)
        {
            return _ticketRepository.Get(id);
        }

        public List<Ticket> GetProducts()
        {
            return _ticketRepository.GetAll().ToList();
        }

        public void UpdateProduct(Ticket product)
        {
            _ticketRepository.Update(product);
        }
    }
}
