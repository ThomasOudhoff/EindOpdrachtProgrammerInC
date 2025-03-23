using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PersoonsBeheer
{
    public partial class FormPerson : Form
    {
        public string PersonName => txtName.Text;
        public int PersonAge => int.TryParse(txtAge.Text, out int age) ? age : 0;

        public FormPerson()
        {
            InitializeComponent();
        }

        public FormPerson(string name, int age) : this() 
        {
            txtName.Text = name;
            txtAge.Text = age.ToString();
        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || PersonAge <= 0)
            {
                MessageBox.Show("Vul een geldige naam en leeftijd in.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}


