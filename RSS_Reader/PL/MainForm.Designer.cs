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
            this.btnAddPodcast = new System.Windows.Forms.Button();
            this.lvPodcasts = new System.Windows.Forms.ListView();
            this.btnSavePodcast = new System.Windows.Forms.Button();
            this.btnRemovePodcast = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.cmbCat = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.lvEpisodes = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lvCats = new System.Windows.Forms.ListView();
            this.btnRemoveCat = new System.Windows.Forms.Button();
            this.btnSaveCat = new System.Windows.Forms.Button();
            this.btnCreateCat = new System.Windows.Forms.Button();
            this.txtCatName = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAddPodcast
            // 
            this.btnAddPodcast.Location = new System.Drawing.Point(12, 27);
            this.btnAddPodcast.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddPodcast.Name = "btnAddPodcast";
            this.btnAddPodcast.Size = new System.Drawing.Size(185, 31);
            this.btnAddPodcast.TabIndex = 0;
            this.btnAddPodcast.Text = "Lägg till";
            this.btnAddPodcast.UseVisualStyleBackColor = true;
            this.btnAddPodcast.Click += new System.EventHandler(this.btnAddPodcast_Click);
            // 
            // lvPodcasts
            // 
            this.lvPodcasts.HideSelection = false;
            this.lvPodcasts.Location = new System.Drawing.Point(12, 149);
            this.lvPodcasts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvPodcasts.Name = "lvPodcasts";
            this.lvPodcasts.Size = new System.Drawing.Size(456, 201);
            this.lvPodcasts.TabIndex = 1;
            this.lvPodcasts.UseCompatibleStateImageBehavior = false;
            this.lvPodcasts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvPodcasts_MouseDoubleClick);
            // 
            // btnSavePodcast
            // 
            this.btnSavePodcast.Location = new System.Drawing.Point(232, 27);
            this.btnSavePodcast.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSavePodcast.Name = "btnSavePodcast";
            this.btnSavePodcast.Size = new System.Drawing.Size(109, 31);
            this.btnSavePodcast.TabIndex = 2;
            this.btnSavePodcast.Text = "Spara";
            this.btnSavePodcast.UseVisualStyleBackColor = true;
            // 
            // btnRemovePodcast
            // 
            this.btnRemovePodcast.Location = new System.Drawing.Point(357, 27);
            this.btnRemovePodcast.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemovePodcast.Name = "btnRemovePodcast";
            this.btnRemovePodcast.Size = new System.Drawing.Size(109, 31);
            this.btnRemovePodcast.TabIndex = 3;
            this.btnRemovePodcast.Text = "Ta bort";
            this.btnRemovePodcast.UseVisualStyleBackColor = true;
            this.btnRemovePodcast.Click += new System.EventHandler(this.btnRemovePodcast_Click);
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(12, 89);
            this.txtURL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(185, 22);
            this.txtURL.TabIndex = 4;
            // 
            // cmbCat
            // 
            this.cmbCat.FormattingEnabled = true;
            this.cmbCat.Location = new System.Drawing.Point(357, 87);
            this.cmbCat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCat.Name = "cmbCat";
            this.cmbCat.Size = new System.Drawing.Size(108, 24);
            this.cmbCat.TabIndex = 5;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(232, 87);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(108, 24);
            this.comboBox2.TabIndex = 6;
            // 
            // lvEpisodes
            // 
            this.lvEpisodes.HideSelection = false;
            this.lvEpisodes.Location = new System.Drawing.Point(12, 389);
            this.lvEpisodes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvEpisodes.Name = "lvEpisodes";
            this.lvEpisodes.Size = new System.Drawing.Size(456, 141);
            this.lvEpisodes.TabIndex = 7;
            this.lvEpisodes.UseCompatibleStateImageBehavior = false;
            this.lvEpisodes.Click += new System.EventHandler(this.lvEpisodes_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(488, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(3, 523);
            this.label1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(488, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(437, 2);
            this.label2.TabIndex = 9;
            // 
            // lvCats
            // 
            this.lvCats.HideSelection = false;
            this.lvCats.Location = new System.Drawing.Point(511, 149);
            this.lvCats.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvCats.Name = "lvCats";
            this.lvCats.Size = new System.Drawing.Size(377, 123);
            this.lvCats.TabIndex = 10;
            this.lvCats.UseCompatibleStateImageBehavior = false;
            // 
            // btnRemoveCat
            // 
            this.btnRemoveCat.Location = new System.Drawing.Point(780, 27);
            this.btnRemoveCat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveCat.Name = "btnRemoveCat";
            this.btnRemoveCat.Size = new System.Drawing.Size(109, 31);
            this.btnRemoveCat.TabIndex = 11;
            this.btnRemoveCat.Text = "Ta bort";
            this.btnRemoveCat.UseVisualStyleBackColor = true;
            // 
            // btnSaveCat
            // 
            this.btnSaveCat.Location = new System.Drawing.Point(645, 27);
            this.btnSaveCat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveCat.Name = "btnSaveCat";
            this.btnSaveCat.Size = new System.Drawing.Size(109, 31);
            this.btnSaveCat.TabIndex = 12;
            this.btnSaveCat.Text = "Spara";
            this.btnSaveCat.UseVisualStyleBackColor = true;
            // 
            // btnCreateCat
            // 
            this.btnCreateCat.Location = new System.Drawing.Point(511, 27);
            this.btnCreateCat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreateCat.Name = "btnCreateCat";
            this.btnCreateCat.Size = new System.Drawing.Size(109, 31);
            this.btnCreateCat.TabIndex = 13;
            this.btnCreateCat.Text = "Skapa";
            this.btnCreateCat.UseVisualStyleBackColor = true;
            this.btnCreateCat.Click += new System.EventHandler(this.btnCreateCat_Click);
            // 
            // txtCatName
            // 
            this.txtCatName.Location = new System.Drawing.Point(511, 89);
            this.txtCatName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCatName.Name = "txtCatName";
            this.txtCatName.Size = new System.Drawing.Size(377, 22);
            this.txtCatName.TabIndex = 14;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(507, 309);
            this.lblTitle.MaximumSize = new System.Drawing.Size(383, 49);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(171, 17);
            this.lblTitle.TabIndex = 15;
            this.lblTitle.Text = "Podcast #0: Avsnitt #0";
            // 
            // lblDesc
            // 
            this.lblDesc.Location = new System.Drawing.Point(507, 370);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(383, 160);
            this.lblDesc.TabIndex = 16;
            this.lblDesc.Text = "Beskrivning...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 70);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "URL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(228, 69);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Uppdatera...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(353, 70);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Kategori";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(507, 69);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "Namn";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(507, 130);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "Kategorier";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 130);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 17);
            this.label10.TabIndex = 22;
            this.label10.Text = "Podcasts";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 370);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 17);
            this.label11.TabIndex = 23;
            this.label11.Text = "Avsnitt";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 561);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtCatName);
            this.Controls.Add(this.btnCreateCat);
            this.Controls.Add(this.btnSaveCat);
            this.Controls.Add(this.btnRemoveCat);
            this.Controls.Add(this.lvCats);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvEpisodes);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.cmbCat);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.btnRemovePodcast);
            this.Controls.Add(this.btnSavePodcast);
            this.Controls.Add(this.lvPodcasts);
            this.Controls.Add(this.btnAddPodcast);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "RSS Reader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddPodcast;
        private System.Windows.Forms.ListView lvPodcasts;
        private System.Windows.Forms.Button btnSavePodcast;
        private System.Windows.Forms.Button btnRemovePodcast;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.ComboBox cmbCat;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ListView lvEpisodes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvCats;
        private System.Windows.Forms.Button btnRemoveCat;
        private System.Windows.Forms.Button btnSaveCat;
        private System.Windows.Forms.Button btnCreateCat;
        private System.Windows.Forms.TextBox txtCatName;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}

