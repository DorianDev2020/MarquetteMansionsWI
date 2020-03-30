using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Marquette_Mansions.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId {get;set;}
    }
}
