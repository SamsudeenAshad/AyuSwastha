using System;
using System.Collections.Generic;

namespace AyuSwastha.Models
{
    /// <summary>
    /// A herbal prescription. Demonstrates <b>composition</b>: a Prescription
    /// owns its list of <see cref="PrescriptionItem"/>s.
    /// </summary>
    public class Prescription
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime IssuedOn { get; set; } = DateTime.Today;
        public string GeneralInstructions { get; set; }

        public List<PrescriptionItem> Items { get; } = new List<PrescriptionItem>();

        public void AddItem(PrescriptionItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            Items.Add(item);
        }
    }

    /// <summary>A single herbal medicine line within a prescription.</summary>
    public class PrescriptionItem
    {
        public int Id { get; set; }
        public int PrescriptionId { get; set; }
        public string HerbName { get; set; }   // e.g. Ashwagandha, Triphala
        public string Dosage { get; set; }     // e.g. "1 tsp twice daily"
        public string Duration { get; set; }   // e.g. "14 days"
        public string Instructions { get; set; }
    }
}
