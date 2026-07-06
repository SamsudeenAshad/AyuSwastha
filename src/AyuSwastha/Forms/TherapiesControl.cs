using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AyuSwastha.Core;
using AyuSwastha.Data;
using AyuSwastha.Models;

namespace AyuSwastha.Forms
{
    public partial class TherapiesControl : UserControl
    {
        private readonly TherapySessionRepository _repo = new TherapySessionRepository();
        private List<TherapySession> _all = new List<TherapySession>();

        public TherapiesControl()
        {
            InitializeComponent();

            txtSearch.TextChanged += (s, e) => ApplyFilter();
            btnNew.Click += (s, e) => OpenEditor(new TherapySession { ScheduledAt = DateTime.Today.AddHours(9) });
            btnEdit.Click += (s, e) => EditSelected();
            btnDelete.Click += (s, e) => DeleteSelected();
            lstTherapies.DoubleClick += (s, e) => EditSelected();
        }

        private void TherapiesControl_Load(object sender, EventArgs e)
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
                : _all.Where(s =>
                    (s.PatientName ?? "").ToLowerInvariant().Contains(q) ||
                    (s.TherapyName ?? "").ToLowerInvariant().Contains(q) ||
                    (s.DoctorName ?? "").ToLowerInvariant().Contains(q)).ToList();

            lstTherapies.DataSource = null;
            lstTherapies.DataSource = filtered;
        }

        private void EditSelected()
        {
            if (lstTherapies.SelectedItem is TherapySession s)
                OpenEditor(s);
        }

        private void OpenEditor(TherapySession session)
        {
            int previousId = session.Id;
            using (var dlg = new TherapySessionForm(session))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    ReloadList();
                    SelectById(session.Id != 0 ? session.Id : previousId);
                }
            }
        }

        private void DeleteSelected()
        {
            if (!(lstTherapies.SelectedItem is TherapySession s) || s.Id == 0)
                return;

            if (MessageBox.Show("Delete therapy session for " + s.PatientName + "?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                _repo.Delete(s.Id);
                ReloadList();
            }
            catch (AppException ex)
            {
                MessageBox.Show(ex.Message, "AyuSwastha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectById(int id)
        {
            for (int i = 0; i < lstTherapies.Items.Count; i++)
            {
                if (lstTherapies.Items[i] is TherapySession s && s.Id == id)
                {
                    lstTherapies.SelectedIndex = i;
                    return;
                }
            }
        }
    }
}
