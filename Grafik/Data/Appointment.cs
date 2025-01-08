namespace Grafik.Data
{
    public class Appointment
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string Text { get; set; }
        public Guid UserId { get; set; }
    }
}
