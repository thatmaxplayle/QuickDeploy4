namespace QuickDeploy4.UI
{
    partial class DeploymentCard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDeploymentName = new System.Windows.Forms.Label();
            this.lblDeploymentDescription = new System.Windows.Forms.Label();
            this.lblOverview = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDeploymentName
            // 
            this.lblDeploymentName.AutoSize = true;
            this.lblDeploymentName.Font = new System.Drawing.Font("Inter Tight", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDeploymentName.Location = new System.Drawing.Point(10, 10);
            this.lblDeploymentName.Name = "lblDeploymentName";
            this.lblDeploymentName.Size = new System.Drawing.Size(183, 28);
            this.lblDeploymentName.TabIndex = 0;
            this.lblDeploymentName.Text = "Deployment Name";
            // 
            // lblDeploymentDescription
            // 
            this.lblDeploymentDescription.AutoSize = true;
            this.lblDeploymentDescription.Location = new System.Drawing.Point(10, 50);
            this.lblDeploymentDescription.Name = "lblDeploymentDescription";
            this.lblDeploymentDescription.Size = new System.Drawing.Size(89, 23);
            this.lblDeploymentDescription.TabIndex = 1;
            this.lblDeploymentDescription.Text = "Description";
            // 
            // lblOverview
            // 
            this.lblOverview.AutoSize = true;
            this.lblOverview.Font = new System.Drawing.Font("Inter Tight", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOverview.Location = new System.Drawing.Point(10, 130);
            this.lblOverview.Name = "lblOverview";
            this.lblOverview.Size = new System.Drawing.Size(132, 19);
            this.lblOverview.TabIndex = 2;
            this.lblOverview.Text = "Content Placeholder";
            // 
            // DeploymentCard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Controls.Add(this.lblOverview);
            this.Controls.Add(this.lblDeploymentDescription);
            this.Controls.Add(this.lblDeploymentName);
            this.Font = new System.Drawing.Font("Inter Tight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "DeploymentCard";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.Size = new System.Drawing.Size(980, 160);
            this.Load += new System.EventHandler(this.DeploymentCard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblDeploymentName;
        private Label lblDeploymentDescription;
        private Label lblOverview;
    }
}
