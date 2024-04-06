using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using Microsoft.EntityFrameworkCore;
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
    public class Employee
    {
        [Range(100000000, 999999999)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int SSN { get; set; }
        public virtual string FirstName {  get; set; }
        public virtual string LastName { get; set; }
        [FieldSize(1)]
        public virtual string MiddleInitial {  get; set; }
        [FieldSize(1)]
        public virtual string Sex {  get; set; }
        public virtual string Address {  get; set; }
        public virtual int Salary { get; set; }
        public virtual int? SuperVisorId { get; set; }
        public virtual Employee SuperVisor { get; set; }
        public virtual ObservableCollection<Employee> SuperVisee { get; set; } = new ObservableCollection<Employee>();
        public virtual int DepartmentId { get; set; } // Foreign key for Department
        [ForeignKey("DepartmentId")]
        public virtual Department WorksForDepartment { get; set; }
        public virtual int? ManagesDepartmentId { get; set; } // Nullable foreign key for managed department
        [ForeignKey("ManagesDepartmentId")]
        public virtual Department? Manages { get; set; }
        public virtual ObservableCollection<Project> WorksOnProjects { get; set; } = new ObservableCollection<Project>();
        public virtual ObservableCollection<Dependent> Dependees { get; set; } = new ObservableCollection<Dependent>();
    }
}
