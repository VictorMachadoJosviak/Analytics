using Analytics.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Core.Models
{
    [Table("ApplicationUser")]
    public class ApplicationUser : EntityBase
    {   
        public string Email { get; set; }

        public string RegistrationId { get; set; }

        public string Name { get; set; }
    }
}
