using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace escritorio_loteria
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
            btnCrearPtda.BackColor = Color.FromArgb(70,207,0);
            btnUnirsePtda.BackColor = Color.FromArgb(70, 207, 0);
        }

        private void btnCrearPtda_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombUsu.Text))
            {
                MessageBox.Show("Dato Invalido","Al tiro Compa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                mesa_de_juego FrmMjuego = new mesa_de_juego(txtNombUsu.Text, "no");
                FrmMjuego.Show();
                this.Hide();
            }
        }

        private void btnUnirsePtda_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombUsu.Text))
            {
                MessageBox.Show("Dato Invalido", "Al tiro Compa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                mesa_de_juego FrmMjuego = new mesa_de_juego(txtNombUsu.Text, "si");
                FrmMjuego.Show();
                this.Hide();
            }
        }
    }
}
