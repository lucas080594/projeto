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
    public partial class EncerrarContaCliente : Form
    {

        protected string _CodProtocolo, _CodCliente, _NomeCliente, _TipoAtendimento, _EmailCliente, _MotivoEncerramento;

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnEncerrarConta_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Você esta prestes a encerrar uma conta de um colaborador.", "Confirmar Encerramento?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)

            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = ConexaoComBanco.abrirConexao();
                comm.CommandText = "UPDATE EBRX_CLIENT_SOLICIT SET SITUAC_ATENDMNT= 1 WHERE PROTOCOL_INT_ID='" + txtProtocolo.Text + "'";

                comm.ExecuteNonQuery();

                

                SqlCommand DelUser = new SqlCommand();
                DelUser.Connection = ConexaoComBanco.abrirConexao();
                DelUser.CommandText = "UPDATE EBRX_CLIENTE SET CPF_STR_CLI = '', STATS_STR_CLI = '1', DAT_ATUALIZC = GETDATE() WHERE CLI_INT_ID= '" + txtCodCliente.Text + "'";
                DelUser.ExecuteNonQuery();

                SqlCommand ZerarCliente = new SqlCommand();
                ZerarCliente.Connection = ConexaoComBanco.abrirConexao();
                ZerarCliente.CommandText = "UPDATE EBRX_CARTEIRA SET SALD_STR_CRIP = '', SALD_STR_DINHR = '' WHERE EBRX_CLIENT_ID = '" + txtCodCliente.Text + "'";
                ZerarCliente.ExecuteNonQuery();

                ConexaoComBanco.fecharConexa(comm.Connection);

                MessageBox.Show("Ação Realizada Com Sucesso");
                Hide();
            }
        }

        public EncerrarContaCliente(string CodProtocolo,string CodCliente, String NomeCliente, string TipoAtendimento, string EmailCliente, string MotivoEncerramento)
        {
            _CodProtocolo = CodProtocolo;
            _CodCliente = CodCliente;
            _NomeCliente = NomeCliente;
            _TipoAtendimento = TipoAtendimento;
            _EmailCliente = EmailCliente;
            _MotivoEncerramento = MotivoEncerramento;

            InitializeComponent();
        }

        private void EncerrarContaCliente_Load(object sender, EventArgs e)
        {
            txtProtocolo.Text = _CodProtocolo;
            txtCodCliente.Text = _CodCliente;
            txtNomeCliente.Text = _NomeCliente;
            txtTipoSolicitacao.Text = _TipoAtendimento;
            txtEmailCliente.Text = _EmailCliente;
            txtMotivoEncerrar.Text = _MotivoEncerramento;
        }
    }
}
