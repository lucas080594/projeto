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
    public partial class Registro : Form
    {
        protected string _matricula;
        public Registro(string matricCliente)
        {
              _matricula = matricCliente;

                InitializeComponent();
            
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            txtMatricFunc.Text = _matricula;

            SqlCommand comm = new SqlCommand();
            comm.Connection = ConexaoComBanco.abrirConexao();
            comm.CommandText = "SELECT COD_FUNC FROM EBRX_FUNCRH where MATRIC_STR_FUNC= '" + txtMatricFunc.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(comm);
            SqlDataReader dr = null;

            dr = comm.ExecuteReader();
            if (dr.Read())
            {
                txtFuncCod.Text = dr["COD_FUNC"].ToString();
            }

            ConexaoComBanco.fecharConexa(comm.Connection);
        }
    

        private void button1_Click(object sender, EventArgs e)
        {

            if(string.Compare (txtSenha.Text, txtConfirmarSenha.Text, true) ==0)
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = ConexaoComBanco.abrirConexao();
                comm.CommandText = "INSERT INTO EBRX_FUNC_PROFILE(EBRX_FUNCRH_COD,SENH_STR_ACESS,MATRIC_STR_ACESS)" +
                    "VALUES('" + txtFuncCod.Text + "', '" + txtSenha.Text + "','" + txtMatricFunc.Text + "')";

                comm.ExecuteNonQuery();

                ConexaoComBanco.fecharConexa(comm.Connection);


                MessageBox.Show("Parabéns!! Você esta registrado, agora poderá efetuar o seu login utilizando sua matricula e sua senha!!! :D");


                Close();

                LoginRegister lg = new LoginRegister();
                lg.Show();
            }
            else
            {
                MessageBox.Show("As digitadas não correspondem!, certifique que digitou igualmente a senha.");
            }
            
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            LoginRegister telaLogin = new LoginRegister();
            telaLogin.Show();
        }
    }
}
