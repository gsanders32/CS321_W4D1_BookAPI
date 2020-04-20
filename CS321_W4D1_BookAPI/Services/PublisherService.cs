using CS321_W4D1_BookAPI.Data;
using CS321_W4D1_BookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS321_W4D1_BookAPI.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly BookContext _bookContext;

        public PublisherService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public Publisher Add(Publisher addPublisher)
        {
            _bookContext.Publishers.Add(addPublisher);
            _bookContext.SaveChanges();
            return addPublisher;
        }

        public Publisher Get(int id)
        {
            Publisher publisher = _bookContext.Publishers
                .Include(x => x.Books)
                .FirstOrDefault(x => x.Id == id);

            return publisher;
        }

        public IEnumerable<Publisher> GetAll()
        {
            var publisher = _bookContext.Publishers.ToList();
            return publisher;
        }

        public void Remove(Publisher deletePublisher)
        {
            _bookContext.Publishers.Remove(deletePublisher);
            _bookContext.SaveChanges();
        }

        public Publisher Update(Publisher updatePublisher)
        {
            Publisher currentPublisher = _bookContext.Publishers.Find(updatePublisher.Id);
            if (currentPublisher == null) return null;

            _bookContext.Entry(currentPublisher)
                .CurrentValues
                .SetValues(updatePublisher);

            _bookContext.Publishers.Update(currentPublisher);
            _bookContext.SaveChanges();
            return currentPublisher;
        }
    }
}
