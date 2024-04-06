using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace companyORM.Module.BusinessObjects
{
    [NavigationItem("Company")]
    public class Dependent
    {
        public virtual string Name { get; set; } = GenerateDefault();
        [FieldSize(1)]
        public virtual string Sex {  get; set; }
        public virtual string Relationship { get; set; }
        public virtual DateTime Bdate { get; set; }
        public virtual int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        private static string GenerateDefault()
        {
            return "default";
        }
    }
}
