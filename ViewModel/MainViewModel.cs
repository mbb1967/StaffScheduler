using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace StaffScheduler.ViewModel
{
    partial class MainViewModel
    {
        public BindingList<Staff> Staffs { get; set; }
        public BindingList<OfficeAppointment> Appointments { get; set; }
        public MainViewModel()
        {
            Staffs = new BindingList<Staff>();
            Appointments = new BindingList<OfficeAppointment>();
            //FillEmployees();
            //FillTasks();
        }

        public class Staff
        {
            public object Id { get; set; }
            public string Name { get; set; }
        }

        public class OfficeAppointment
        {
            public string StaffName { get; set; }
            public string Location { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            //public string InsuranceNumber { get; set; }
            //public bool FirstVisit { get; set; }
            public object StaffId { get; set; }
            public string Notes { get; set; }
        }
    }
}
