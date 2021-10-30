using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailingListNet.Shared.Models
{
    /// <summary>
    /// Person Model
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Id GUID
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Email Address
        /// </summary>
        [Required]
        public string Email { get; set; }
    }
}
