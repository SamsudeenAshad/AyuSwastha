using System.Drawing;
using System.Windows.Forms;
using AyuSwastha.Core;

namespace AyuSwastha.Forms
{
    partial class PatientsControl
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelLeft;
        private Label lblListTitle;
        private TextBox txtSearch;
        private ListBox lstPatients;
        private Button btnNew;
        private Button btnDelete;

        private Panel panelRight;
        private Panel recPanel;
        private Label lblRecTitle;
        private TextBox txtRec;
        private Panel fieldsPanel;

        private Label lblFormTitle;
        private Label lblCode; private TextBox txtCode;
        private Label lblName; private TextBox txtName;
        private Label lblGender; private ComboBox cmbGender;
        private Label lblAge; private Label lblAgeValue;
        private Label lblDob; private DateTimePicker dtpDob;
        private Label lblPhone; private TextBox txtPhone;
        private Label lblAddress; private TextBox txtAddress;
        private Label lblPrakriti; private ComboBox cmbPrakriti;
        private Label lblHistory; private TextBox txtHistory;
        private Label lblAllergies; private TextBox txtAllergies;
        private Label lblLifestyle; private TextBox txtLifestyle;
        private Label lblNotes; private TextBox txtNotes;
        private Button btnSave; private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelLeft = new Panel();
            this.lblListTitle = new Label();
            this.txtSearch = new TextBox();
            this.lstPatients = new ListBox();
            this.btnNew = new Button();
            this.btnDelete = new Button();
            this.panelRight = new Panel();
            this.recPanel = new Panel();
            this.lblRecTitle = new Label();
            this.txtRec = new TextBox();
            this.fieldsPanel = new Panel();
            this.lblFormTitle = new Label();
            this.lblCode = new Label(); this.txtCode = new TextBox();
            this.lblName = new Label(); this.txtName = new TextBox();
            this.lblGender = new Label(); this.cmbGender = new ComboBox();
            this.lblAge = new Label(); this.lblAgeValue = new Label();
            this.lblDob = new Label(); this.dtpDob = new DateTimePicker();
            this.lblPhone = new Label(); this.txtPhone = new TextBox();
            this.lblAddress = new Label(); this.txtAddress = new TextBox();
            this.lblPrakriti = new Label(); this.cmbPrakriti = new ComboBox();
            this.lblHistory = new Label(); this.txtHistory = new TextBox();
            this.lblAllergies = new Label(); this.txtAllergies = new TextBox();
            this.lblLifestyle = new Label(); this.txtLifestyle = new TextBox();
            this.lblNotes = new Label(); this.txtNotes = new TextBox();
            this.btnSave = new Button(); this.btnCancel = new Button();
            this.SuspendLayout();
            //
            // panelLeft
            //
            this.panelLeft.BackColor = Theme.Surface;
            this.panelLeft.Dock = DockStyle.Left;
            this.panelLeft.Width = 270;
            this.panelLeft.Padding = new Padding(12);
            this.panelLeft.Controls.Add(this.lstPatients);
            this.panelLeft.Controls.Add(this.txtSearch);
            this.panelLeft.Controls.Add(this.lblListTitle);
            this.panelLeft.Controls.Add(this.btnNew);
            this.panelLeft.Controls.Add(this.btnDelete);
            //
            // lblListTitle
            //
            this.lblListTitle.AutoSize = true;
            this.lblListTitle.Font = Theme.Subheading;
            this.lblListTitle.ForeColor = Theme.TextPrimary;
            this.lblListTitle.Location = new Point(12, 12);
            this.lblListTitle.Text = "Patients";
            //
            // txtSearch
            //
            this.txtSearch.Location = new Point(14, 42);
            this.txtSearch.Size = new Size(242, 25);
            this.txtSearch.Font = Theme.Body;
            //
            // lstPatients
            //
            this.lstPatients.Location = new Point(14, 76);
            this.lstPatients.Size = new Size(242, 360);
            this.lstPatients.Font = Theme.Body;
            this.lstPatients.IntegralHeight = false;
            //
            // btnNew
            //
            this.btnNew.BackColor = Theme.Primary;
            this.btnNew.FlatStyle = FlatStyle.Flat;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.ForeColor = Color.White;
            this.btnNew.Font = new Font("Segoe UI Semibold", 9.5f);
            this.btnNew.Location = new Point(14, 446);
            this.btnNew.Size = new Size(118, 34);
            this.btnNew.Text = "+ New";
            this.btnNew.UseVisualStyleBackColor = false;
            //
            // btnDelete
            //
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderColor = Theme.Border;
            this.btnDelete.ForeColor = Theme.Danger;
            this.btnDelete.Font = new Font("Segoe UI", 9.5f);
            this.btnDelete.Location = new Point(138, 446);
            this.btnDelete.Size = new Size(118, 34);
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            //
            // panelRight
            //
            this.panelRight.BackColor = Theme.Background;
            this.panelRight.Dock = DockStyle.Fill;
            this.panelRight.Controls.Add(this.fieldsPanel);
            this.panelRight.Controls.Add(this.recPanel);
            //
            // recPanel
            //
            this.recPanel.BackColor = Theme.Surface;
            this.recPanel.BorderStyle = BorderStyle.FixedSingle;
            this.recPanel.Dock = DockStyle.Right;
            this.recPanel.Width = 300;
            this.recPanel.Padding = new Padding(14);
            this.recPanel.Controls.Add(this.txtRec);
            this.recPanel.Controls.Add(this.lblRecTitle);
            //
            // lblRecTitle
            //
            this.lblRecTitle.Dock = DockStyle.Top;
            this.lblRecTitle.Height = 52;
            this.lblRecTitle.Font = Theme.Subheading;
            this.lblRecTitle.ForeColor = Theme.Primary;
            this.lblRecTitle.Text = "★ Dosha Guidance";
            this.lblRecTitle.TextAlign = ContentAlignment.MiddleLeft;
            //
            // txtRec
            //
            this.txtRec.Dock = DockStyle.Fill;
            this.txtRec.Multiline = true;
            this.txtRec.ReadOnly = true;
            this.txtRec.ScrollBars = ScrollBars.Vertical;
            this.txtRec.BorderStyle = BorderStyle.None;
            this.txtRec.BackColor = Theme.Surface;
            this.txtRec.Font = Theme.Body;
            this.txtRec.Text = "Select a patient to see tailored Ayurvedic guidance.";
            //
            // fieldsPanel
            //
            this.fieldsPanel.BackColor = Theme.Surface;
            this.fieldsPanel.Dock = DockStyle.Fill;
            this.fieldsPanel.AutoScroll = true;
            this.fieldsPanel.Padding = new Padding(24, 16, 24, 16);
            this.fieldsPanel.Controls.Add(this.lblFormTitle);
            this.fieldsPanel.Controls.Add(this.lblCode); this.fieldsPanel.Controls.Add(this.txtCode);
            this.fieldsPanel.Controls.Add(this.lblName); this.fieldsPanel.Controls.Add(this.txtName);
            this.fieldsPanel.Controls.Add(this.lblGender); this.fieldsPanel.Controls.Add(this.cmbGender);
            this.fieldsPanel.Controls.Add(this.lblAge); this.fieldsPanel.Controls.Add(this.lblAgeValue);
            this.fieldsPanel.Controls.Add(this.lblDob); this.fieldsPanel.Controls.Add(this.dtpDob);
            this.fieldsPanel.Controls.Add(this.lblPhone); this.fieldsPanel.Controls.Add(this.txtPhone);
            this.fieldsPanel.Controls.Add(this.lblAddress); this.fieldsPanel.Controls.Add(this.txtAddress);
            this.fieldsPanel.Controls.Add(this.lblPrakriti); this.fieldsPanel.Controls.Add(this.cmbPrakriti);
            this.fieldsPanel.Controls.Add(this.lblHistory); this.fieldsPanel.Controls.Add(this.txtHistory);
            this.fieldsPanel.Controls.Add(this.lblAllergies); this.fieldsPanel.Controls.Add(this.txtAllergies);
            this.fieldsPanel.Controls.Add(this.lblLifestyle); this.fieldsPanel.Controls.Add(this.txtLifestyle);
            this.fieldsPanel.Controls.Add(this.lblNotes); this.fieldsPanel.Controls.Add(this.txtNotes);
            this.fieldsPanel.Controls.Add(this.btnSave); this.fieldsPanel.Controls.Add(this.btnCancel);
            //
            // lblFormTitle
            //
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = Theme.Heading;
            this.lblFormTitle.ForeColor = Theme.TextPrimary;
            this.lblFormTitle.Location = new Point(20, 12);
            this.lblFormTitle.Text = "Patient Details";
            //
            // rows
            //
            Field(this.lblCode, "Patient ID", this.txtCode, 56); this.txtCode.ReadOnly = true; this.txtCode.Width = 140;
            Field(this.lblName, "Full Name", this.txtName, 92); this.txtName.Width = 330;
            Field(this.lblGender, "Gender", this.cmbGender, 128); this.cmbGender.Width = 150;
            this.cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            //
            // Age (shares the Gender row, to the right)
            //
            this.lblAge.AutoSize = true; this.lblAge.Font = Theme.Body; this.lblAge.ForeColor = Theme.TextMuted;
            this.lblAge.Location = new Point(320, 132); this.lblAge.Text = "Age:";
            this.lblAgeValue.AutoSize = true; this.lblAgeValue.Font = new Font("Segoe UI Semibold", 9.75f);
            this.lblAgeValue.ForeColor = Theme.TextPrimary; this.lblAgeValue.Location = new Point(360, 132);
            this.lblAgeValue.Text = "—";
            //
            Field(this.lblDob, "Date of Birth", this.dtpDob, 164); this.dtpDob.Width = 200;
            this.dtpDob.Format = DateTimePickerFormat.Short; this.dtpDob.ShowCheckBox = true;
            Field(this.lblPhone, "Phone", this.txtPhone, 200); this.txtPhone.Width = 200;
            //
            // Address (multiline)
            //
            Label(this.lblAddress, "Address", 236);
            this.txtAddress.Location = new Point(150, 234); this.txtAddress.Size = new Size(330, 46);
            this.txtAddress.Multiline = true; this.txtAddress.Font = Theme.Body;
            //
            Field(this.lblPrakriti, "Prakriti (Dosha)", this.cmbPrakriti, 300); this.cmbPrakriti.Width = 200;
            this.cmbPrakriti.DropDownStyle = ComboBoxStyle.DropDownList;
            //
            Label(this.lblHistory, "Medical History", 340);
            this.txtHistory.Location = new Point(150, 338); this.txtHistory.Size = new Size(330, 46);
            this.txtHistory.Multiline = true; this.txtHistory.Font = Theme.Body;
            //
            Label(this.lblAllergies, "Allergies", 396);
            this.txtAllergies.Location = new Point(150, 394); this.txtAllergies.Size = new Size(330, 40);
            this.txtAllergies.Multiline = true; this.txtAllergies.Font = Theme.Body;
            //
            Label(this.lblLifestyle, "Lifestyle", 446);
            this.txtLifestyle.Location = new Point(150, 444); this.txtLifestyle.Size = new Size(330, 40);
            this.txtLifestyle.Multiline = true; this.txtLifestyle.Font = Theme.Body;
            //
            Label(this.lblNotes, "Notes", 496);
            this.txtNotes.Location = new Point(150, 494); this.txtNotes.Size = new Size(330, 46);
            this.txtNotes.Multiline = true; this.txtNotes.Font = Theme.Body;
            //
            // btnSave / btnCancel
            //
            this.btnSave.BackColor = Theme.Primary; this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0; this.btnSave.ForeColor = Color.White;
            this.btnSave.Font = new Font("Segoe UI Semibold", 10f);
            this.btnSave.Location = new Point(150, 556); this.btnSave.Size = new Size(120, 38);
            this.btnSave.Text = "Save"; this.btnSave.UseVisualStyleBackColor = false;
            //
            this.btnCancel.FlatStyle = FlatStyle.Flat; this.btnCancel.FlatAppearance.BorderColor = Theme.Border;
            this.btnCancel.ForeColor = Theme.TextPrimary; this.btnCancel.Font = new Font("Segoe UI", 10f);
            this.btnCancel.Location = new Point(280, 556); this.btnCancel.Size = new Size(110, 38);
            this.btnCancel.Text = "Cancel"; this.btnCancel.UseVisualStyleBackColor = true;
            //
            // PatientsControl
            //
            this.BackColor = Theme.Background;
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Load += this.PatientsControl_Load;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Helpers to keep the row layout terse and consistent.
        private void Label(Label lbl, string text, int y)
        {
            lbl.AutoSize = true;
            lbl.Font = Theme.Body;
            lbl.ForeColor = Theme.TextMuted;
            lbl.Location = new Point(20, y);
            lbl.Text = text;
        }

        private void Field(Label lbl, string text, Control input, int y)
        {
            Label(lbl, text, y + 4);
            input.Location = new Point(150, y);
            input.Font = Theme.Body;
        }
    }
}
