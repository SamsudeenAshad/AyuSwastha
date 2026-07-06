namespace AyuSwastha.Models
{
    /// <summary>An Ayurvedic physician. Extends <see cref="Person"/>.</summary>
    public class Doctor : Person
    {
        public string DoctorCode { get; set; }      // e.g. "D001"
        public string Specialization { get; set; }  // e.g. Panchakarma, Kayachikitsa
        public string LicenseNo { get; set; }
        public decimal ConsultationFee { get; set; }
        public bool IsActive { get; set; } = true;

        public override string DisplayRole => "Doctor";

        public override string ToString()
        {
            string name = "Dr. " + FullName;
            return string.IsNullOrEmpty(Specialization) ? name : name + " (" + Specialization + ")";
        }
    }
}
