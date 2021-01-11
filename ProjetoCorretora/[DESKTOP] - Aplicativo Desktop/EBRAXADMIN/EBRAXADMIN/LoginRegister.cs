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
    public partial class LoginRegister : Form
    {
        public LoginRegister()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            LoginRegister telaLoginCad = new LoginRegister();
            Hide();
            ValidarMatricula telaValidarMatricula = new ValidarMatricula();
            telaValidarMatricula.Show();

            

            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            AcceptButton = btnLogin;

            int i = 0;
            SqlCommand comm = new SqlCommand();
            comm.Connection = ConexaoComBanco.abrirConexao();
            comm.CommandText = "SELECT * FROM EBRX_FUNC_PROFILE where MATRIC_STR_ACESS= '" + txtMatricula.Text + "'and SENH_STR_ACESS='" + txtSenha.Text + "'";
            //comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {

                MessageBox.Show("Matrícula ou Senha incorretas");

            }
            else
            {

                Principal telaAdministrativaInicial = new Principal(txtMatricula.Text);
                telaAdministrativaInicial.Show();
                LoginRegister lg = new LoginRegister();
                Hide();
            }

            ConexaoComBanco.fecharConexa(comm.Connection);
        }

        private void LoginRegister_Load(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
