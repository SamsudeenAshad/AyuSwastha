using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AyuSwastha.Core;
using AyuSwastha.Data;
using AyuSwastha.Models;
using AyuSwastha.Services;

namespace AyuSwastha.Forms
{
    public partial class PatientsControl : UserControl
    {
        private readonly PatientRepository _repo = new PatientRepository();
        private readonly DoshaRecommendationService _dosha = new DoshaRecommendationService();

        private List<Patient> _all = new List<Patient>();
        private Patient _current;   // the patient being edited (null = brand-new, unsaved)

        public PatientsControl()
        {
            InitializeComponent();

            cmbGender.DataSource = Enum.GetValues(typeof(Gender));
            cmbPrakriti.DataSource = Enum.GetValues(typeof(DoshaType));

            lstPatients.SelectedIndexChanged += (s, e) => OnSelectionChanged();
            txtSearch.TextChanged += (s, e) => ApplyFilter();
            cmbPrakriti.SelectedIndexChanged += (s, e) => UpdateRecommendation();
            dtpDob.ValueChanged += (s, e) => UpdateAge();
            btnNew.Click += (s, e) => NewPatient();
            btnDelete.Click += (s, e) => DeletePatient();
            btnSave.Click += (s, e) => Save();
            btnCancel.Click += (s, e) => OnSelectionChanged();
        }

        private void PatientsControl_Load(object sender, EventArgs e)
        {
            ReloadList();
        }

        private void ReloadList()
        {
            try
            {
                _all = _repo.GetAll().ToList();
                ApplyFilter();
            }
            catch (AppException ex)
            {
                MessageBox.Show(ex.Message, "AyuSwastha", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ApplyFilter()
        {
            string q = txtSearch.Text.Trim().ToLowerInvariant();
            var filtered = string.IsNullOrEmpty(q)
                ? _all
                : _all.Where(p =>
                    (p.FullName ?? "").ToLowerInvariant().Contains(q) ||
                    (p.PatientCode ?? "").ToLowerInvariant().Contains(q) ||
                    (p.Phone ?? "").ToLowerInvariant().Contains(q)).ToList();

            lstPatients.DataSource = null;
            lstPatients.DataSource = filtered;
            if (filtered.Count > 0) lstPatients.SelectedIndex = 0;
            else ClearForm();
        }

        private void OnSelectionChanged()
        {
            if (lstPatients.SelectedItem is Patient p)
                Bind(p);
        }

        private void Bind(Patient p)
        {
            _current = p;
            txtCode.Text = p.PatientCode;
            txtName.Text = p.FullName;
            cmbGender.SelectedItem = p.Gender;
            cmbPrakriti.SelectedItem = p.Prakriti;
            txtPhone.Text = p.Phone;
            txtAddress.Text = p.Address;
            txtHistory.Text = p.MedicalHistory;
            txtAllergies.Text = p.Allergies;
            txtLifestyle.Text = p.Lifestyle;
            txtNotes.Text = p.Notes;

            if (p.DateOfBirth.HasValue)
            {
                dtpDob.Value = p.DateOfBirth.Value;
                dtpDob.Checked = true;
            }
            else
            {
                dtpDob.Checked = false;
            }

            UpdateAge();
            UpdateRecommendation();
        }

        private void NewPatient()
        {
            lstPatients.ClearSelected();
            ClearForm();
            txtName.Focus();
        }

        private void ClearForm()
        {
            _current = null;
            txtCode.Text = "(auto)";
            txtName.Clear();
            cmbGender.SelectedItem = Gender.Male;
            cmbPrakriti.SelectedItem = DoshaType.Unknown;
            txtPhone.Clear();
            txtAddress.Clear();
            txtHistory.Clear();
            txtAllergies.Clear();
            txtLifestyle.Clear();
            txtNotes.Clear();
            dtpDob.Checked = false;
            lblAgeValue.Text = "—";
            UpdateRecommendation();
        }

        private void Save()
        {
            try
            {
                Patient p = _current ?? new Patient();
                p.FullName = txtName.Text.Trim();
                p.Gender = (Gender)cmbGender.SelectedItem;
                p.Prakriti = (DoshaType)cmbPrakriti.SelectedItem;
                p.Phone = txtPhone.Text.Trim();
                p.Address = txtAddress.Text.Trim();
                p.MedicalHistory = txtHistory.Text.Trim();
                p.Allergies = txtAllergies.Text.Trim();
                p.Lifestyle = txtLifestyle.Text.Trim();
                p.Notes = txtNotes.Text.Trim();
                p.DateOfBirth = dtpDob.Checked ? dtpDob.Value.Date : (DateTime?)null;

                if (p.Id == 0) _repo.Add(p);
                else _repo.Update(p);

                int savedId = p.Id;
                ReloadList();
                SelectById(savedId);

                MessageBox.Show("Patient saved.", "AyuSwastha",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message, "Please check the form",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (AppException ex)
            {
                MessageBox.Show(ex.Message, "AyuSwastha",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeletePatient()
        {
            if (_current == null || _current.Id == 0)
                return;

            if (MessageBox.Show("Delete " + _current.FullName + "?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                _repo.Delete(_current.Id);
                ReloadList();
            }
            catch (AppException ex)
            {
                MessageBox.Show(ex.Message, "AyuSwastha",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectById(int id)
        {
            for (int i = 0; i < lstPatients.Items.Count; i++)
            {
                if (lstPatients.Items[i] is Patient p && p.Id == id)
                {
                    lstPatients.SelectedIndex = i;
                    return;
                }
            }
        }

        private void UpdateAge()
        {
            if (!dtpDob.Checked)
            {
                lblAgeValue.Text = "—";
                return;
            }
            var probe = new Patient { DateOfBirth = dtpDob.Value.Date };
            lblAgeValue.Text = probe.Age.HasValue ? probe.Age.Value + " yrs" : "—";
        }

        private void UpdateRecommendation()
        {
            if (!(cmbPrakriti.SelectedItem is DoshaType dosha))
                return;

            DoshaRecommendation rec = _dosha.GetRecommendation(dosha);

            var sb = new StringBuilder();
            sb.AppendLine(rec.Summary);
            sb.AppendLine();
            AppendSection(sb, "Herbs", rec.RecommendedHerbs);
            AppendSection(sb, "Therapies", rec.RecommendedTherapies);
            AppendSection(sb, "Diet", rec.DietTips);
            AppendSection(sb, "Lifestyle", rec.LifestyleTips);
            txtRec.Text = sb.ToString();
        }

        private static void AppendSection(StringBuilder sb, string heading, IReadOnlyList<string> items)
        {
            if (items == null || items.Count == 0) return;
            sb.AppendLine(heading + ":");
            foreach (var item in items)
                sb.AppendLine("  • " + item);
            sb.AppendLine();
        }
    }
}
