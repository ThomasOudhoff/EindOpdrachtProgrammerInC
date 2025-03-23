namespace PersoonsBeheer
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bttnToevoegen = new System.Windows.Forms.Button();
            this.bttnBewerken = new System.Windows.Forms.Button();
            this.bttnVerwijderen = new System.Windows.Forms.Button();
            this.bttnKansBerekenen = new System.Windows.Forms.Button();
            this.progressBarKans = new System.Windows.Forms.ProgressBar();
            this.bttnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1355, 693);
            this.dataGridView1.TabIndex = 0;
            // 
            // bttnToevoegen
            // 
            this.bttnToevoegen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttnToevoegen.Location = new System.Drawing.Point(24, 699);
            this.bttnToevoegen.Name = "bttnToevoegen";
            this.bttnToevoegen.Size = new System.Drawing.Size(150, 60);
            this.bttnToevoegen.TabIndex = 1;
            this.bttnToevoegen.Text = "Toevoegen";
            this.bttnToevoegen.UseVisualStyleBackColor = true;
            this.bttnToevoegen.Click += new System.EventHandler(this.btnToevoegen_Click);
            // 
            // bttnBewerken
            // 
            this.bttnBewerken.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttnBewerken.Location = new System.Drawing.Point(222, 699);
            this.bttnBewerken.Name = "bttnBewerken";
            this.bttnBewerken.Size = new System.Drawing.Size(150, 60);
            this.bttnBewerken.TabIndex = 2;
            this.bttnBewerken.Text = "Bewerken";
            this.bttnBewerken.UseVisualStyleBackColor = true;
            this.bttnBewerken.Click += new System.EventHandler(this.btnBewerken_Click);
            // 
            // bttnVerwijderen
            // 
            this.bttnVerwijderen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttnVerwijderen.Location = new System.Drawing.Point(808, 699);
            this.bttnVerwijderen.Name = "bttnVerwijderen";
            this.bttnVerwijderen.Size = new System.Drawing.Size(150, 60);
            this.bttnVerwijderen.TabIndex = 3;
            this.bttnVerwijderen.Text = "Verwijderen";
            this.bttnVerwijderen.UseVisualStyleBackColor = true;
            this.bttnVerwijderen.Click += new System.EventHandler(this.btnVerwijderen_Click);
            // 
            // bttnKansBerekenen
            // 
            this.bttnKansBerekenen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttnKansBerekenen.Location = new System.Drawing.Point(423, 699);
            this.bttnKansBerekenen.Name = "bttnKansBerekenen";
            this.bttnKansBerekenen.Size = new System.Drawing.Size(150, 60);
            this.bttnKansBerekenen.TabIndex = 4;
            this.bttnKansBerekenen.Text = "Bereken kans";
            this.bttnKansBerekenen.UseVisualStyleBackColor = true;
            this.bttnKansBerekenen.Click += new System.EventHandler(this.bttnKansBerekenen_Click);
            // 
            // progressBarKans
            // 
            this.progressBarKans.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBarKans.Location = new System.Drawing.Point(596, 714);
            this.progressBarKans.Name = "progressBarKans";
            this.progressBarKans.Size = new System.Drawing.Size(186, 28);
            this.progressBarKans.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarKans.TabIndex = 5;
            // 
            // bttnReset
            // 
            this.bttnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttnReset.Location = new System.Drawing.Point(1006, 699);
            this.bttnReset.Name = "bttnReset";
            this.bttnReset.Size = new System.Drawing.Size(150, 60);
            this.bttnReset.TabIndex = 6;
            this.bttnReset.Text = "Reset";
            this.bttnReset.UseVisualStyleBackColor = true;
            this.bttnReset.Click += new System.EventHandler(this.bttnResetDatabase_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 754);
            this.Controls.Add(this.bttnReset);
            this.Controls.Add(this.progressBarKans);
            this.Controls.Add(this.bttnKansBerekenen);
            this.Controls.Add(this.bttnVerwijderen);
            this.Controls.Add(this.bttnBewerken);
            this.Controls.Add(this.bttnToevoegen);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bttnToevoegen;
        private System.Windows.Forms.Button bttnBewerken;
        private System.Windows.Forms.Button bttnVerwijderen;
        private System.Windows.Forms.Button bttnKansBerekenen;
        private System.Windows.Forms.ProgressBar progressBarKans;
        private System.Windows.Forms.Button bttnReset;
    }
}

