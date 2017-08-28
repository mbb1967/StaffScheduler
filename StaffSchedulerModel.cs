namespace StaffScheduler
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class StaffSchedulerModel : DbContext
    {
        // Your context has been configured to use a 'StaffSchedulerModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'StaffScheduler.StaffSchedulerModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'StaffSchedulerModel' 
        // connection string in the application configuration file.
        public StaffSchedulerModel()
            : base("name=StaffSchedulerModel")
        {
            Database.SetInitializer<StaffSchedulerModel>(new SchedulerDBInitializer());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<EFAppointment> MyAppointments { get; set; }
        public virtual DbSet<EFResource> MyResources { get; set; }
    }

    public class EFAppointment
    {
        [Key()]
        public int UniqueID { get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public bool AllDay { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int Label { get; set; }
        public string ResourceIDs { get; set; }
        public string ReminderInfo { get; set; }
        public string RecurrenceInfo { get; set; }
    }

    public class EFResource
    {
        [Key()]
        public int UniqueID { get; set; }
        public int ResourceID { get; set; }
        public string ResourceName { get; set; }
        public int Color { get; set; }
    }

    public class SchedulerDBInitializer : CreateDatabaseIfNotExists<StaffSchedulerModel>
    {
        protected override void Seed(StaffSchedulerModel context)
        {
            IList<EFResource> defaultResources = new List<EFResource>();

            defaultResources.Add(new EFResource() { ResourceID = 1, ResourceName = "Service Desk" });
            defaultResources.Add(new EFResource() { ResourceID = 2, ResourceName = "Technical" });
            defaultResources.Add(new EFResource() { ResourceID = 3, ResourceName = "Development" });

            foreach (EFResource res in defaultResources)
                context.MyResources.Add(res);
            base.Seed(context);
        }
    }

}