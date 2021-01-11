using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EBRAXADMIN
{
    public partial class EditarMeuRegistro : Form
    {
        protected string _Matricula;
        public EditarMeuRegistro(string MatriculaMan)
        {
            _Matricula = MatriculaMan;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.Compare(txtSenha.Text, txtNovaSenha.Text, true) == 0)
            {
                if (MessageBox.Show("você irá alterar sua senha de acesso ao ambiente Administrativo Ebrax", "Confirmar Alteração?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)

                {
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = ConexaoComBanco.abrirConexao();
                    comm.CommandText = "UPDATE   EBRX_FUNC_PROFILE set SENH_STR_ACESS='" + txtNovaSenha.Text + "' where MATRIC_STR_ACESS='" + txtMatricula.Text + "'";

                    comm.ExecuteNonQuery();


                    ConexaoComBanco.fecharConexa(comm.Connection);

                    MessageBox.Show("Dados Atualizados");
                    Hide();
                }
            }
            else
            {
                MessageBox.Show("As senhas digitadas não iguais");
            }
            
        }

        private void EditarMeuRegistro_Load(object sender, EventArgs e)
        {
            txtMatricula.Text = _Matricula;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
