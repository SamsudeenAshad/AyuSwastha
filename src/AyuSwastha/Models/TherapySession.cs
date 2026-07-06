using System;

namespace AyuSwastha.Models
{
    /// <summary>A scheduled instance of a <see cref="Therapy"/> for a patient.</summary>
    public class TherapySession
    {
        public int Id { get; set; }
        public int TherapyId { get; set; }
        public int PatientId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime ScheduledAt { get; set; }
        public TherapyStatus Status { get; set; } = TherapyStatus.Booked;
        public string Notes { get; set; }

        // Display helpers populated via joins.
        public string TherapyName { get; set; }
        public string PatientName { get; set; }
    }
}
