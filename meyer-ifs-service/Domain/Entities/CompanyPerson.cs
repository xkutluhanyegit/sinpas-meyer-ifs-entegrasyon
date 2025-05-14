using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class CompanyPerson:IEntity
    {
       public string COMPANY_ID { get; set; }
       public string EMP_NO { get; set; }
       public string FNAME { get; set; }
       public string LNAME { get; set; }
       public byte[] DATA { get; set; }

    }
}