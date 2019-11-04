namespace PL
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnAddPodcast = new System.Windows.Forms.Button();
            this.lvPodcasts = new System.Windows.Forms.ListView();
            this.btnEditPodcast = new System.Windows.Forms.Button();
            this.btnRemovePodcast = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.cmbCat = new System.Windows.Forms.ComboBox();
            this.cmbFreq = new System.Windows.Forms.ComboBox();
            this.lvEpisodes = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lvCats = new System.Windows.Forms.ListView();
            this.btnRemoveCat = new System.Windows.Forms.Button();
            this.btnEditCat = new System.Windows.Forms.Button();
            this.btnCreateCat = new System.Windows.Forms.Button();
            this.txtCatName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.wbDescription = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // btnAddPodcast
            // 
            this.btnAddPodcast.Location = new System.Drawing.Point(9, 22);
            this.btnAddPodcast.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddPodcast.Name = "btnAddPodcast";
            this.btnAddPodcast.Size = new System.Drawing.Size(139, 25);
            this.btnAddPodcast.TabIndex = 0;
            this.btnAddPodcast.Text = "Lägg till";
            this.btnAddPodcast.UseVisualStyleBackColor = true;
            this.btnAddPodcast.Click += new System.EventHandler(this.btnAddPodcast_Click);
            // 
            // lvPodcasts
            // 
            this.lvPodcasts.BackColor = System.Drawing.SystemColors.Window;
            this.lvPodcasts.HideSelection = false;
            this.lvPodcasts.Location = new System.Drawing.Point(9, 121);
            this.lvPodcasts.Margin = new System.Windows.Forms.Padding(2);
            this.lvPodcasts.Name = "lvPodcasts";
            this.lvPodcasts.Size = new System.Drawing.Size(343, 164);
            this.lvPodcasts.TabIndex = 1;
            this.lvPodcasts.UseCompatibleStateImageBehavior = false;
            this.lvPodcasts.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvPodcasts_Click);
            this.lvPodcasts.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LV_MouseUp);
            // 
            // btnEditPodcast
            // 
            this.btnEditPodcast.Location = new System.Drawing.Point(174, 22);
            this.btnEditPodcast.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditPodcast.Name = "btnEditPodcast";
            this.btnEditPodcast.Size = new System.Drawing.Size(82, 25);
            this.btnEditPodcast.TabIndex = 2;
            this.btnEditPodcast.Text = "Ändra";
            this.btnEditPodcast.UseVisualStyleBackColor = true;
            this.btnEditPodcast.Click += new System.EventHandler(this.btnEditPodcast_Click);
            // 
            // btnRemovePodcast
            // 
            this.btnRemovePodcast.Location = new System.Drawing.Point(268, 22);
            this.btnRemovePodcast.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemovePodcast.Name = "btnRemovePodcast";
            this.btnRemovePodcast.Size = new System.Drawing.Size(82, 25);
            this.btnRemovePodcast.TabIndex = 3;
            this.btnRemovePodcast.Text = "Ta bort";
            this.btnRemovePodcast.UseVisualStyleBackColor = true;
            this.btnRemovePodcast.Click += new System.EventHandler(this.btnRemovePodcast_Click);
            // 
            // txtURL
            // 
            this.txtURL.BackColor = System.Drawing.SystemColors.Window;
            this.txtURL.Location = new System.Drawing.Point(9, 72);
            this.txtURL.Margin = new System.Windows.Forms.Padding(2);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(140, 20);
            this.txtURL.TabIndex = 4;
            // 
            // cmbCat
            // 
            this.cmbCat.BackColor = System.Drawing.SystemColors.Window;
            this.cmbCat.FormattingEnabled = true;
            this.cmbCat.Location = new System.Drawing.Point(268, 71);
            this.cmbCat.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCat.Name = "cmbCat";
            this.cmbCat.Size = new System.Drawing.Size(82, 21);
            this.cmbCat.TabIndex = 5;
            // 
            // cmbFreq
            // 
            this.cmbFreq.BackColor = System.Drawing.SystemColors.Window;
            this.cmbFreq.FormattingEnabled = true;
            this.cmbFreq.Location = new System.Drawing.Point(174, 71);
            this.cmbFreq.Margin = new System.Windows.Forms.Padding(2);
            this.cmbFreq.Name = "cmbFreq";
            this.cmbFreq.Size = new System.Drawing.Size(82, 21);
            this.cmbFreq.TabIndex = 6;
            // 
            // lvEpisodes
            // 
            this.lvEpisodes.BackColor = System.Drawing.SystemColors.Window;
            this.lvEpisodes.HideSelection = false;
            this.lvEpisodes.Location = new System.Drawing.Point(9, 316);
            this.lvEpisodes.Margin = new System.Windows.Forms.Padding(2);
            this.lvEpisodes.Name = "lvEpisodes";
            this.lvEpisodes.Size = new System.Drawing.Size(343, 115);
            this.lvEpisodes.TabIndex = 7;
            this.lvEpisodes.UseCompatibleStateImageBehavior = false;
            this.lvEpisodes.Click += new System.EventHandler(this.lvEpisodes_Click);
            this.lvEpisodes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LV_MouseUp);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(366, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 425);
            this.label1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(366, 234);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 2);
            this.label2.TabIndex = 9;
            // 
            // lvCats
            // 
            this.lvCats.BackColor = System.Drawing.SystemColors.Window;
            this.lvCats.HideSelection = false;
            this.lvCats.Location = new System.Drawing.Point(383, 121);
            this.lvCats.Margin = new System.Windows.Forms.Padding(2);
            this.lvCats.Name = "lvCats";
            this.lvCats.Size = new System.Drawing.Size(284, 101);
            this.lvCats.TabIndex = 10;
            this.lvCats.UseCompatibleStateImageBehavior = false;
            this.lvCats.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvCats_Click);
            this.lvCats.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LV_MouseUp);
            // 
            // btnRemoveCat
            // 
            this.btnRemoveCat.Location = new System.Drawing.Point(585, 22);
            this.btnRemoveCat.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveCat.Name = "btnRemoveCat";
            this.btnRemoveCat.Size = new System.Drawing.Size(82, 25);
            this.btnRemoveCat.TabIndex = 11;
            this.btnRemoveCat.Text = "Ta bort";
            this.btnRemoveCat.UseVisualStyleBackColor = true;
            this.btnRemoveCat.Click += new System.EventHandler(this.btnRemoveCat_Click);
            // 
            // btnEditCat
            // 
            this.btnEditCat.Location = new System.Drawing.Point(484, 22);
            this.btnEditCat.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditCat.Name = "btnEditCat";
            this.btnEditCat.Size = new System.Drawing.Size(82, 25);
            this.btnEditCat.TabIndex = 12;
            this.btnEditCat.Text = "Ändra";
            this.btnEditCat.UseVisualStyleBackColor = true;
            this.btnEditCat.Click += new System.EventHandler(this.btnEditCat_Click);
            // 
            // btnCreateCat
            // 
            this.btnCreateCat.Location = new System.Drawing.Point(383, 22);
            this.btnCreateCat.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreateCat.Name = "btnCreateCat";
            this.btnCreateCat.Size = new System.Drawing.Size(82, 25);
            this.btnCreateCat.TabIndex = 13;
            this.btnCreateCat.Text = "Skapa";
            this.btnCreateCat.UseVisualStyleBackColor = true;
            this.btnCreateCat.Click += new System.EventHandler(this.btnCreateCat_Click);
            // 
            // txtCatName
            // 
            this.txtCatName.BackColor = System.Drawing.SystemColors.Window;
            this.txtCatName.Location = new System.Drawing.Point(383, 72);
            this.txtCatName.Margin = new System.Windows.Forms.Padding(2);
            this.txtCatName.Name = "txtCatName";
            this.txtCatName.Size = new System.Drawing.Size(284, 20);
            this.txtCatName.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "URL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(171, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Frekvens (minuter)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(265, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Kategori";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(380, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Namn";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(380, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Kategorier";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Podcasts";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 301);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Avsnitt";
            // 
            // wbDescription
            // 
            this.wbDescription.Location = new System.Drawing.Point(383, 253);
            this.wbDescription.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbDescription.Name = "wbDescription";
            this.wbDescription.Size = new System.Drawing.Size(284, 178);
            this.wbDescription.TabIndex = 24;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(690, 456);
            this.Controls.Add(this.wbDescription);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCatName);
            this.Controls.Add(this.btnCreateCat);
            this.Controls.Add(this.btnEditCat);
            this.Controls.Add(this.btnRemoveCat);
            this.Controls.Add(this.lvCats);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvEpisodes);
            this.Controls.Add(this.cmbFreq);
            this.Controls.Add(this.cmbCat);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.btnRemovePodcast);
            this.Controls.Add(this.btnEditPodcast);
            this.Controls.Add(this.lvPodcasts);
            this.Controls.Add(this.btnAddPodcast);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RSS Reader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddPodcast;
        private System.Windows.Forms.ListView lvPodcasts;
        private System.Windows.Forms.Button btnEditPodcast;
        private System.Windows.Forms.Button btnRemovePodcast;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.ComboBox cmbCat;
        private System.Windows.Forms.ComboBox cmbFreq;
        private System.Windows.Forms.ListView lvEpisodes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvCats;
        private System.Windows.Forms.Button btnRemoveCat;
        private System.Windows.Forms.Button btnEditCat;
        private System.Windows.Forms.Button btnCreateCat;
        private System.Windows.Forms.TextBox txtCatName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.WebBrowser wbDescription;
    }
}

