using DevExpress.Persistent.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace companyORM.Module.BusinessObjects
{
    [NavigationItem("Company")]
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int DepartmentNumber { get; set; }
        public virtual string DepartmentName {  get; set; }
        public virtual Location? DepartamentLocation {  get; set; }
        public virtual IList<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
        public virtual Employee Manager {  get; set; }
        public virtual DateTime ManagerStartDate { get; set; }
        public virtual ObservableCollection<Project> Projects { get; set; } = new ObservableCollection<Project>();
    }
}
