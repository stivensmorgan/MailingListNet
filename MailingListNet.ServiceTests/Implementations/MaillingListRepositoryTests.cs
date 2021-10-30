using Microsoft.VisualStudio.TestTools.UnitTesting;
using MailingListNet.Persistence.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailingListNet.Shared.Models;

namespace MailingListNet.Persistence.Implementations.Tests
{
    [TestClass()]
    public class MaillingListRepositoryTests
    {
        /// <summary>
        /// Validate if add Contact works
        /// </summary>
        [TestMethod()]
        public void AddContactTest()
        {
            MaillingListRepository _repository = new MaillingListRepository();
            Person person1 = new Person()
            {
                FirstName = "Stivens",
                LastName = "Morgan",
                Email = "stivensmorgan@gmail.com"
            };

            _repository.AddContact(person1);

            var person2 = _repository.GetContacts("Morgan").FirstOrDefault();

            Assert.AreSame(person2, person1);
        }
    }
}