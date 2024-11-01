using IsApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsApp.Service.Interface
{
    public interface ITicketService
    {
        public List<Ticket> GetProducts();
        public Ticket GetProductById(Guid? id);
        void CreateNewProduct(Ticket product);
        void UpdateProduct(Ticket product);
        void DeleteProduct(Guid id);
    }
}
