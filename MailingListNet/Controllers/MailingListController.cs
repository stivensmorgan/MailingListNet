using MailingListNet.Models;
using MailingListNet.Service;
using MailingListNet.Service.Contract;
using MailingListNet.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MailingListNet.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MailingListController : ApiController
    {
        private readonly IMailingListService _service = null;

        public MailingListController()
        {
            _service = new MailingListService();
        }

        // GET: api/MailingList
        public IEnumerable<PersonVM> Get()
        {
            var contacts = _service.GetContacts(string.Empty);

            List<PersonVM> result = new List<PersonVM>();
            foreach (var person in contacts)
            {
                result.Add(new PersonVM() 
                { 
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Email = person.Email
                });
            }

            return result;
        }

        [HttpGet]
        public IEnumerable<PersonVM> Get(string lastName, bool asc)
        {
            var contacts = _service.GetContacts(lastName, asc);

            List<PersonVM> result = new List<PersonVM>();
            foreach (var person in contacts)
            {
                result.Add(new PersonVM()
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Email = person.Email
                });
            }

            return result;
        }

        // POST: api/MailingList
        public void Post([FromBody]PersonVM person)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));
            }

            _service.AddContact(new Person() 
            { 
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email
            });
        }

        // PUT: api/MailingList/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/MailingList/5
        public void Delete(int id)
        {
        }
    }
}
