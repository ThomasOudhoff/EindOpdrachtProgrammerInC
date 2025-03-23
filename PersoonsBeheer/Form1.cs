using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersoonsBeheer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DatabaseManager.CreateDatabase(); 
            LoadPersons(); 
        }

        private void LoadPersons()
        {
            dataGridView1.DataSource = DatabaseManager.GetPersons();

            
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["Id"].HeaderText = "ID";
                dataGridView1.Columns["Name"].HeaderText = "Naam";
                dataGridView1.Columns["Age"].HeaderText = "Leeftijd";
                dataGridView1.Columns["Education"].HeaderText = "Opleiding";
                dataGridView1.Columns["Job"].HeaderText = "Beroep";
            }
        }

        private void btnToevoegen_Click(object sender, EventArgs e)
        {
            using (var form = new FormPerson())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    DatabaseManager.AddPerson(form.PersonName, form.PersonAge);
                    LoadPersons(); 
                }
            }
        }

        private void btnBewerken_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                string name = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
                int age = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Age"].Value);

                using (var form = new FormPerson(name, age))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        DatabaseManager.UpdatePerson(id, form.PersonName, form.PersonAge);
                        LoadPersons(); 
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecteer eerst een persoon om te bewerken.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVerwijderen_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                DialogResult result = MessageBox.Show("Weet je zeker dat je deze persoon wilt verwijderen?", "Bevestigen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DatabaseManager.DeletePerson(id);
                    LoadPersons(); 
                }
            }
            else
            {
                MessageBox.Show("Selecteer eerst een persoon om te verwijderen.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void bttnKansBerekenen_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecteer eerst een persoon!", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
            string name = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();

            bttnKansBerekenen.Enabled = false; 
            progressBarKans.Value = 0; 
            progressBarKans.Visible = true; 

            await Task.Run(() =>
            {
                Random rand = new Random();
                double opleidingKans = rand.NextDouble() * (1.0 - 0.1) + 0.1; 
                double baanKans = rand.NextDouble() * (1.0 - 0.1) + 0.1; 
                double uiteindelijkeKans = opleidingKans * baanKans; 

                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(rand.Next(100, 1000)); 
                    this.Invoke((MethodInvoker)delegate
                    {
                        progressBarKans.Value = (i + 1) * 10; 
                    });
                }

                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show($"Kans voor {name}: {uiteindelijkeKans:P2}", "Kansberekening", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bttnKansBerekenen.Enabled = true; 
                    progressBarKans.Visible = false; 
                });
            });
        }

        private void bttnResetDatabase_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Weet je zeker dat je de database wilt resetten? Alle gegevens gaan verloren!",
                "Database Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    string dbPath = "mydatabase.db";
                    if (System.IO.File.Exists(dbPath))
                    {
                        System.IO.File.Delete(dbPath);
                    }

                    DatabaseManager.CreateDatabase();
                    LoadPersons();

                    MessageBox.Show("De database is opnieuw opgebouwd!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fout bij resetten van database: " + ex.Message, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}



