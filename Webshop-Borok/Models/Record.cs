using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Webshop_Borok.Models
{
    [DataContract]
    public class Record
    {
        [DataMember]
        public int? termekId { get; set; }
    }
}