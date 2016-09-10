namespace _CSharp_CEU_Consolidated_Calendar_System
{
    partial class Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.rpv_main = new Telerik.WinControls.UI.RadPageViewPage();
            this.rpv_accounts = new Telerik.WinControls.UI.RadPageViewPage();
            this.rpv_events = new Telerik.WinControls.UI.RadPageViewPage();
            this.rpv_notes = new Telerik.WinControls.UI.RadPageViewPage();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.rpv_main);
            this.radPageView1.Controls.Add(this.rpv_notes);
            this.radPageView1.Controls.Add(this.rpv_events);
            this.radPageView1.Controls.Add(this.rpv_accounts);
            this.radPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageView1.Location = new System.Drawing.Point(0, 0);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.rpv_main;
            this.radPageView1.Size = new System.Drawing.Size(1310, 628);
            this.radPageView1.TabIndex = 0;
            this.radPageView1.Text = "radPageView1";
            this.radPageView1.SelectedPageChanged += new System.EventHandler(this.radPageView1_SelectedPageChanged);
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // rpv_main
            // 
            this.rpv_main.ItemSize = new System.Drawing.SizeF(41F, 28F);
            this.rpv_main.Location = new System.Drawing.Point(10, 37);
            this.rpv_main.Name = "rpv_main";
            this.rpv_main.Size = new System.Drawing.Size(1289, 580);
            this.rpv_main.Text = "Main";
            // 
            // rpv_accounts
            // 
            this.rpv_accounts.ItemSize = new System.Drawing.SizeF(127F, 28F);
            this.rpv_accounts.Location = new System.Drawing.Point(10, 37);
            this.rpv_accounts.Name = "rpv_accounts";
            this.rpv_accounts.Size = new System.Drawing.Size(379, 252);
            this.rpv_accounts.Text = "Account Management";
            // 
            // rpv_events
            // 
            this.rpv_events.ItemSize = new System.Drawing.SizeF(118F, 28F);
            this.rpv_events.Location = new System.Drawing.Point(10, 37);
            this.rpv_events.Name = "rpv_events";
            this.rpv_events.Size = new System.Drawing.Size(379, 252);
            this.rpv_events.Text = "Events Management";
            // 
            // rpv_notes
            // 
            this.rpv_notes.ItemSize = new System.Drawing.SizeF(116F, 28F);
            this.rpv_notes.Location = new System.Drawing.Point(10, 37);
            this.rpv_notes.Name = "rpv_notes";
            this.rpv_notes.Size = new System.Drawing.Size(1289, 580);
            this.rpv_notes.Text = "Notes Management";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 628);
            this.Controls.Add(this.radPageView1);
            this.Name = "Main";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage rpv_main;
        private Telerik.WinControls.UI.RadPageViewPage rpv_accounts;
        private Telerik.WinControls.UI.RadPageViewPage rpv_events;
        private Telerik.WinControls.UI.RadPageViewPage rpv_notes;
    }
}
