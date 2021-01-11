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
    public partial class GerarRelatoriosConfidenciais : Form
    {
        public GerarRelatoriosConfidenciais()
        {
            InitializeComponent();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            RelatorioConfidentialGerado relatorioGerado = new RelatorioConfidentialGerado(txtClientes.Text, txtDinheiroCustodia.Text, txtSolicitacoes.Text);
            relatorioGerado.Show();
        }

        private void GerarRelatoriosConfidenciais_Load(object sender, EventArgs e)
        {
            SqlCommand comm = new SqlCommand();
            comm.Connection = ConexaoComBanco.abrirConexao();
            comm.CommandText = "SELECT COUNT(*) AS TOTAL_CLIENTES FROM EBRX_CLIENTE WHERE STATS_STR_CLI IS NULL";
            SqlDataAdapter da = new SqlDataAdapter(comm);
            SqlDataReader dr = null;

            dr = comm.ExecuteReader();
            if (dr.Read())
            {
                txtClientes.Text = dr["TOTAL_CLIENTES"].ToString();

            }

            SqlCommand custodia = new SqlCommand();
            custodia.Connection = ConexaoComBanco.abrirConexao();
            custodia.CommandText = "SELECT SUM(SALD_STR_DINHR) as CUSTODIA FROM EBRX_CARTEIRA;";
            SqlDataAdapter custoAdapter = new SqlDataAdapter(comm);
            SqlDataReader custoReader = null;

            custoReader = custodia.ExecuteReader();
            if (custoReader.Read())
            {
                txtDinheiroCustodia.Text = custoReader["CUSTODIA"].ToString();

            }

            SqlCommand pendencias = new SqlCommand();
            pendencias.Connection = ConexaoComBanco.abrirConexao();
            pendencias.CommandText = "SELECT COUNT(*) AS ATENDIMENTO_PENDENTE FROM EBRX_CLIENT_SOLICIT WHERE SITUAC_ATENDMNT IS NULL;";
            SqlDataAdapter pendenciaAdapter = new SqlDataAdapter(comm);
            SqlDataReader pendenciaReader = null;

            pendenciaReader = pendencias.ExecuteReader();
            if (pendenciaReader.Read())
            {
                txtSolicitacoes.Text = pendenciaReader["ATENDIMENTO_PENDENTE"].ToString();

            }

            ConexaoComBanco.fecharConexa(comm.Connection);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
