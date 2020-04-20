using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W4D1_BookAPI.Models;

namespace CS321_W4D1_BookAPI.Services
{
    public interface IPublisherService
    {
        // CRUDL - create (add), read (get), update, delete (remove), list

        // create
        Publisher Add(Publisher addPublisher);
        // read
        Publisher Get(int id);
        // update
        Publisher Update(Publisher updatePublisher);
        // delete
        void Remove(Publisher deletePublisher);
        // list
        IEnumerable<Publisher> GetAll();
    }
}
