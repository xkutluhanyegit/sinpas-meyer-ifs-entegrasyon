using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class CompanyPersonImg:IEntity
    {
        public int BLOB_ID { get; set; }
        public byte[] DATA { get; set; }
    }
}