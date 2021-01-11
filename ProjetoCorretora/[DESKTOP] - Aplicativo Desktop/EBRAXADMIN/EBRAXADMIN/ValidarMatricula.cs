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
    public partial class ValidarMatricula : Form
    {
        public ValidarMatricula()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AcceptButton = btnValidar;

            int i = 0;
            SqlCommand comm = new SqlCommand();
            comm.Connection = ConexaoComBanco.abrirConexao();
            comm.CommandText = "SELECT * FROM EBRX_FUNCRH where MATRIC_STR_FUNC='" + txtValidarMatricula.Text +"'AND SITU_STR_FUNC = 1";
            //comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comm);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {

                MessageBox.Show("Esta Matricula não existe!");

            }
            else
            {
                int existe = 0;
                SqlCommand validacao = new SqlCommand();
                validacao.Connection = ConexaoComBanco.abrirConexao();
                validacao.CommandText = "SELECT * FROM EBRX_FUNC_PROFILE where MATRIC_STR_ACESS='" + txtValidarMatricula.Text + "'";
                //comm.ExecuteNonQuery();
                DataTable validando = new DataTable();
                SqlDataAdapter localizado = new SqlDataAdapter(validacao);
                localizado.Fill(validando);
                existe = Convert.ToInt32(validando.Rows.Count.ToString());

                if (existe != 0)
                {

                    MessageBox.Show("Esta Matricula ja possui registro!");

                }
                else
                {

                    Registro telaRegistro = new Registro(txtValidarMatricula.Text);
                    telaRegistro.Show();
                    ValidarMatricula lg = new ValidarMatricula();
                    Hide();
                }
            }


            
        }

        private void ValidarMatricula_Load(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
 
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            AjudaCadastro messageAjuda = new AjudaCadastro();
            messageAjuda.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Hide();
            LoginRegister telaLogin = new LoginRegister();
            telaLogin.Show();
        }
    }
}
