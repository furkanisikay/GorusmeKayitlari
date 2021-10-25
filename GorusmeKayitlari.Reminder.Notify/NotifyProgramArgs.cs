using GorusmeKayitlari.Extensions.Reminder;

namespace GorusmeKayitlari.Reminder.Notify
{
    public class NotifyProgramArgs
    {
        public NotifyProgramArgs(int Id, string taskName, Hatirlatma ht, bool firstRun)
        {
            this.Id = Id;
            this.taskName = taskName;
            this.ht = ht;
            this.firstRun = firstRun;
        }
        public NotifyProgramArgs(int Id, string taskName, Hatirlatma ht)
        {
            this.Id = Id;
            this.taskName = taskName;
            this.ht = ht;
            this.firstRun = false;
        }
        public NotifyProgramArgs(int Id, string taskName, bool firstRun)
        {
            this.Id = Id;
            this.taskName = taskName;
            this.ht = null;
            this.firstRun = firstRun;
        }
        public NotifyProgramArgs()
        {
            this.Id = -1;
            this.taskName = string.Empty;
            this.ht = null;
            this.firstRun = false;
        }
        public int Id { get; set; }
        public string taskName { get; set; }
        public Hatirlatma ht { get; set; }
        public bool firstRun { get; set; }
    }
}
