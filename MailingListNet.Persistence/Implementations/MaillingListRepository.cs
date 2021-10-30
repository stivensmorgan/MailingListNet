using MailingListNet.Persistence.Data;
using MailingListNet.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingListNet.Persistence.Implementations
{
    public class MaillingListRepository
    {

        private readonly DataContext _dataContext;

        public MaillingListRepository()
        {
            // create DataContext
            _dataContext = new DataContext();
        }

        /// <summary>
        /// Add new contact to Contacts list
        /// </summary>
        /// <param name="person">Person to be added</param>
        public void AddContact(Person person)
        {
            var contact = _dataContext.Contacts.Where(c => c.Email == person.Email).FirstOrDefault();

            if (contact != null)
            {
                contact.FirstName = person.FirstName;
                contact.LastName = person.LastName;
            }
            else
            {
                person.Id = Guid.NewGuid();
                _dataContext.Contacts.Add(person);
            }
        }

        /// <summary>
        /// Get contacts from Contact collection
        /// </summary>
        /// <param name="lastName">Filter by LastName</param>
        /// <param name="asc">Filter Ordered</param>
        /// <returns></returns>
        public List<Person> GetContacts(string lastName, bool asc = true)
        {
            if (lastName != null && lastName.Length > 0)
            {
                if (asc)
                {
                    return _dataContext.Contacts.Where(c => c.LastName.StartsWith(lastName)).OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ToList();
                }
                else
                {
                    return _dataContext.Contacts.Where(c => c.LastName.StartsWith(lastName)).OrderByDescending(c => c.LastName).ThenByDescending(c => c.FirstName).ToList();
                }
            }
            if (asc)
            {
                return _dataContext.Contacts.OrderBy(c => c.LastName).ThenBy(c => c.FirstName).ToList();
            }
            else
            {
                return _dataContext.Contacts.OrderByDescending(c => c.LastName).ThenByDescending(c => c.FirstName).ToList();
            }
        }
    }
}
