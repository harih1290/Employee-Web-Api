using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace APISTUDENT.Models.Interface
{
    public interface ISqlHelpernterface
    {
        DataSet SqlCommander(Employee emp, string action); 
    }
}
