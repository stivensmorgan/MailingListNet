using MailingListNet.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingListNet.Persistence.Data
{
    public class DataContext
    {
        private static List<Person> contacts = new List<Person>();

        /// <summary>
        /// Contacts table
        /// </summary>
        public List<Person> Contacts => contacts;

    }
}
