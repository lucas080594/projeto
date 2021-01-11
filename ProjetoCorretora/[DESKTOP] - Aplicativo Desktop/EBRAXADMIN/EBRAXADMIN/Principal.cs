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
    public partial class Principal : Form
    {
        protected string _nomeColaborador;
        public Principal(string nomeColaborador)
        {

            _nomeColaborador = nomeColaborador;
            InitializeComponent();
        }

        private void btnSairApp_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCriarManifesto_Click(object sender, EventArgs e)
        {
            EditarMeuRegistro telaEdicaoRegistro = new EditarMeuRegistro(txtNome.Text);
            telaEdicaoRegistro.Show();
        }

        

        private void btnConsultarUsuario_Click(object sender, EventArgs e)
        {
            int i = 0;
            SqlCommand comm = new SqlCommand();
            comm.Connection = ConexaoComBanco.abrirConexao();
            string Query = "SELECT PROTOCOL_INT_ID AS PROTOCÓLO, NOME_STR_CLI AS CLIENTE, DESC_NOM_SOL AS Solicitação, DESC_STR_SOL AS MOTIVO, CLI_INT_ID AS Identificador, EMAIL_STR_CLI AS EMAIL FROM EBRX_CLIENT_SOLICIT INNER JOIN EBRX_SOLICT ON COD_INT_SOL = TIP_STR_SOL INNER JOIN EBRX_CLIENTE ON EBRX_CLIENTE_CPF = CPF_STR_CLI WHERE SITUAC_ATENDMNT IS NULL;";

            comm.CommandText = Query;
            SqlDataReader dr = comm.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            ConexaoComBanco.fecharConexa(comm.Connection);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                MessageBox.Show("Nenhuma Solicitação encontrado!");

            }


        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Encerrar"].Index && e.RowIndex >= 0)
            {
                String CodProtocolo = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                String CodCliente = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                String NomeCliente = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                String TipoAtendimento = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                String EmailCliente = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                String MotivoEncerramento = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

                EncerrarContaCliente EncerrarConta = new EncerrarContaCliente(CodProtocolo, CodCliente, NomeCliente, TipoAtendimento, EmailCliente, MotivoEncerramento);
                EncerrarConta.Show();
            }
            else
            {
                String CodProtocolo = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                String CodCliente = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                String NomeCliente = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                String TipoAtendimento = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                String EmailCliente = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                String MotivoEncerramento = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

                EnviarRelatorioCliente EnviarRelatorio = new EnviarRelatorioCliente(CodProtocolo, CodCliente, NomeCliente, TipoAtendimento, EmailCliente, MotivoEncerramento);
                EnviarRelatorio.Show();
            }

        }

        private void Principal_Load(object sender, EventArgs e)
        {
            txtNome.Text = _nomeColaborador;


            SqlCommand nameCommand = new SqlCommand();
            nameCommand.Connection = ConexaoComBanco.abrirConexao();
            nameCommand.CommandText = "SELECT NOME_STR_FUNC FROM EBRX_FUNCRH where MATRIC_STR_FUNC= '" + txtNome.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(nameCommand);
            SqlDataReader nameResult = null;

            nameResult = nameCommand.ExecuteReader();
            if (nameResult.Read())
            {
                lblNomeColaborador.Text = nameResult["NOME_STR_FUNC"].ToString();
            }

            


            int i = 0;
            SqlCommand comm = new SqlCommand();
            comm.Connection = ConexaoComBanco.abrirConexao();
            string Query = "SELECT PROTOCOL_INT_ID AS PROTOCÓLO, NOME_STR_CLI AS CLIENTE, DESC_NOM_SOL AS Solicitação, DESC_STR_SOL AS MOTIVO, CLI_INT_ID AS Identificador, EMAIL_STR_CLI AS EMAIL FROM EBRX_CLIENT_SOLICIT INNER JOIN EBRX_SOLICT ON COD_INT_SOL = TIP_STR_SOL INNER JOIN EBRX_CLIENTE ON EBRX_CLIENTE_CPF = CPF_STR_CLI WHERE SITUAC_ATENDMNT IS NULL;";

            comm.CommandText = Query;
            SqlDataReader dr = comm.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            ConexaoComBanco.fecharConexa(comm.Connection);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                MessageBox.Show("Nenhuma Solicitação encontrado!");

            }

            ConexaoComBanco.fecharConexa(comm.Connection);
        }



        private void timer1_Tick_1(object sender, EventArgs e)
        {
            txtHora.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNovoUsuario_Click(object sender, EventArgs e)
        {
            GerarRelatoriosConfidenciais telaRelatorios = new GerarRelatoriosConfidenciais();
            telaRelatorios.Show();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }
    }
}
