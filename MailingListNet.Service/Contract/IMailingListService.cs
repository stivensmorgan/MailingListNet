using MailingListNet.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingListNet.Service.Contract
{
    public interface IMailingListService
    {
        /// <summary>
        /// add new Person to Mailing List
        /// </summary>
        /// <param name="person">Person to add</param>
        void AddContact(Person person);

        /// <summary>
        /// Get Contacts from Mailing List
        /// </summary>
        /// <param name="lastName">filter Last Name</param>
        /// <param name="asc">Filter ordered</param>
        /// <returns></returns>
        List<Person> GetContacts(string lastName, bool asc = true);
    }
}
