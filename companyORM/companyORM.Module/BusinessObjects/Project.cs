using DevExpress.Persistent.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace companyORM.Module.BusinessObjects
{
    [NavigationItem("Company")]
    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int ProjectNumber { get; set;}
        public virtual string ProjectName { get; set; }
        public virtual string ProjectLocation { get; set;}
        public virtual Department ManagedByDepartment {  get; set; }
        public virtual ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
    }
}
