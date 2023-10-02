using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Web;

namespace Webshop_Borok.Models
{
    [DataContract]

    public class Borok : Record
        {
            [DataMember]
            public string neve { get; set; }

            [DataMember]
            public int evjarat { get; set; }

            [DataMember]

            public int urtartalom_liter { get; set; }

            [DataMember]

            public string fajta { get; set; }

            [OperationContract]

            public override string ToString()
            {
                return $"Név: {neve}\nÉvjárat: {evjarat}\nŰrtartalom/liter: {urtartalom_liter}\nFajta: {fajta}";
            }

        }
    }
