using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop_Borok.Models;

namespace Webshop_Borok.DataBaseManager
{
    internal interface IDQL
    {
        string Insert(Record record);
        string Update(Record record);
        string Delete(int Id);
    }
}
