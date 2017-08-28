#region #usings
using System.Windows;
using System.Data.Entity;
using DevExpress.XtraScheduler;
using DevExpress.Xpf.Ribbon;
#endregion #usings

namespace StaffScheduler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXRibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        #region #window_loaded
        StaffSchedulerModel context = new StaffSchedulerModel();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context.MyAppointments.Load();
            context.MyResources.Load();

            this.schedulerControl1.Storage.AppointmentStorage.DataContext = context.MyAppointments.Local;
            this.schedulerControl1.Storage.ResourceStorage.DataContext = context.MyResources.Local;


            this.schedulerControl1.Storage.AppointmentsInserted +=
                new PersistentObjectsEventHandler(Storage_AppointmentsModified);
            this.schedulerControl1.Storage.AppointmentsChanged +=
                new PersistentObjectsEventHandler(Storage_AppointmentsModified);
            this.schedulerControl1.Storage.AppointmentsDeleted +=
                new PersistentObjectsEventHandler(Storage_AppointmentsModified);
        }
        #endregion #window_loaded
        #region #storage_appointmentsmodified
        void Storage_AppointmentsModified(object sender, PersistentObjectsEventArgs e)
        {
            context.SaveChanges();
        }
        #endregion #storage_appointmentsmodified
        #region #onclosing
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            this.context.Dispose();
        }
        #endregion #onclosing



        private void biGroupByDate_Click(object sender, System.EventArgs e)
        {
            schedulerControl1.GroupType = SchedulerGroupType.Date;
        }

        private void biCalendar_Click(object sender, System.EventArgs e)
        {
            schedulerControl1.GroupType = SchedulerGroupType.None;
            schedulerControl1.ActiveViewType = SchedulerViewType.Week;

        }

        private void biGroupByResource_Click(object sender, System.EventArgs e)
        {
            schedulerControl1.GroupType = SchedulerGroupType.Resource;
        }

        private void biAnnual_Click(object sender, System.EventArgs e)
        {
            schedulerControl1.ActiveViewType = SchedulerViewType.Timeline;
            //schedulerControl1.TimelineView.Scales

        }
    }
}
