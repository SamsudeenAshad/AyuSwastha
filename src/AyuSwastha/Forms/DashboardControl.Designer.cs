using System.Drawing;
using System.Windows.Forms;
using AyuSwastha.Core;

namespace AyuSwastha.Forms
{
    partial class DashboardControl
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblHeading;
        private Label lblSub;
        private FlowLayoutPanel flowTiles;
        private Label lblFeatureTitle;
        private Label lblFeatureBody;
        private Panel featureCard;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblHeading = new Label();
            this.lblSub = new Label();
            this.flowTiles = new FlowLayoutPanel();
            this.featureCard = new Panel();
            this.lblFeatureTitle = new Label();
            this.lblFeatureBody = new Label();
            this.SuspendLayout();
            //
            // lblHeading
            //
            this.lblHeading.AutoSize = true;
            this.lblHeading.Font = new Font("Segoe UI Semibold", 18f, FontStyle.Bold);
            this.lblHeading.ForeColor = Theme.TextPrimary;
            this.lblHeading.Location = new Point(8, 8);
            this.lblHeading.Text = "Dashboard";
            //
            // lblSub
            //
            this.lblSub.AutoSize = true;
            this.lblSub.Font = Theme.Body;
            this.lblSub.ForeColor = Theme.TextMuted;
            this.lblSub.Location = new Point(10, 46);
            this.lblSub.Text = "Clinic overview";
            //
            // flowTiles
            //
            this.flowTiles.Location = new Point(8, 80);
            this.flowTiles.Size = new Size(760, 150);
            this.flowTiles.AutoSize = true;
            this.flowTiles.WrapContents = true;
            //
            // featureCard
            //
            this.featureCard.BackColor = Theme.Surface;
            this.featureCard.BorderStyle = BorderStyle.FixedSingle;
            this.featureCard.Location = new Point(8, 250);
            this.featureCard.Size = new Size(700, 150);
            this.featureCard.Controls.Add(this.lblFeatureTitle);
            this.featureCard.Controls.Add(this.lblFeatureBody);
            //
            // lblFeatureTitle
            //
            this.lblFeatureTitle.AutoSize = true;
            this.lblFeatureTitle.Font = Theme.Subheading;
            this.lblFeatureTitle.ForeColor = Theme.Primary;
            this.lblFeatureTitle.Location = new Point(18, 16);
            this.lblFeatureTitle.Text = "★ Dosha-Based Recommendation Engine";
            //
            // lblFeatureBody
            //
            this.lblFeatureBody.AutoSize = false;
            this.lblFeatureBody.Font = Theme.Body;
            this.lblFeatureBody.ForeColor = Theme.TextMuted;
            this.lblFeatureBody.Location = new Point(20, 48);
            this.lblFeatureBody.Size = new Size(660, 90);
            this.lblFeatureBody.Text =
                "AyuSwastha profiles each patient's Prakriti (Vata / Pitta / Kapha) and suggests " +
                "suitable herbs, therapies, and diet/lifestyle guidance — turning records into " +
                "decision support. Open a patient to see it in action.";
            //
            // DashboardControl
            //
            this.BackColor = Theme.Background;
            this.Controls.Add(this.featureCard);
            this.Controls.Add(this.flowTiles);
            this.Controls.Add(this.lblSub);
            this.Controls.Add(this.lblHeading);
            this.Load += this.DashboardControl_Load;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
