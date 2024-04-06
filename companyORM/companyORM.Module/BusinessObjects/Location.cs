using DevExpress.Persistent.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace companyORM.Module.BusinessObjects
{
    [NavigationItem("Company")]
    public class Location
    {
        public virtual string departamentLocation { get; set; } = GenerateDefault();
        public virtual int DepartmentId {  get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        private static string GenerateDefault()
        {
            return "default";
        }
    }
}
