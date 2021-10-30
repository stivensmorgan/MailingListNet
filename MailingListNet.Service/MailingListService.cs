using MailingListNet.Persistence.Implementations;
using MailingListNet.Service.Contract;
using MailingListNet.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingListNet.Service
{
    public class MailingListService : IMailingListService
    {
        /// <summary>
        /// Mailing List Repository reference
        /// </summary>
        private readonly MaillingListRepository _repository;

        public MailingListService()
        {
            _repository = new MaillingListRepository();
        }

        /// <summary>
        /// Adds new contact
        /// </summary>
        /// <param name="person">Person parameter</param>
        public void AddContact(Person person)
        {
            _repository.AddContact(person);
        }

        /// <summary>
        /// Get Contacts
        /// </summary>
        /// <param name="lastName">Filter Last Name</param>
        /// <param name="asc">Filter ordered</param>
        /// <returns></returns>
        public List<Person> GetContacts(string lastName, bool asc = true)
        {
            return _repository.GetContacts(lastName, asc);
        }
    }
}
