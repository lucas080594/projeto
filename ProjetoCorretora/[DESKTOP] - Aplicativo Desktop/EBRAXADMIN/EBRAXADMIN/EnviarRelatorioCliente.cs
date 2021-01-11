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
    public partial class EnviarRelatorioCliente : Form
    {
        protected string _Protocolo, _CodCliente, _NomeCliente, _TipoAtendimento, _EmailCliente, _MotivoEncerramento;

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmar Encerramento?", "Você esta prestes a encerrar uma conta de um colaborador.", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)

            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = ConexaoComBanco.abrirConexao();
                comm.CommandText = "UPDATE EBRX_CLIENT_SOLICIT SET SITUAC_ATENDMNT= 1 WHERE PROTOCOL_INT_ID='" + txtProtocolo.Text + "'";

                comm.ExecuteNonQuery();

                ConexaoComBanco.fecharConexa(comm.Connection);
                MessageBox.Show("Ação Realizada Com Sucesso");
                Hide();
            }
        }
        public EnviarRelatorioCliente(string Protocolo, string CodCliente, String NomeCliente, string TipoAtendimento, string EmailCliente, string MotivoEncerramento)
        {
            _Protocolo = Protocolo;
            _CodCliente = CodCliente;
            _NomeCliente = NomeCliente;
            _TipoAtendimento = TipoAtendimento;
            _EmailCliente = EmailCliente;
            _MotivoEncerramento = MotivoEncerramento;

            InitializeComponent();
        }

        private void EnviarRelatorioCliente_Load(object sender, EventArgs e)
        {
            txtProtocolo.Text = _Protocolo;
            txtCodClient.Text = _CodCliente;
            txtClientNome.Text = _NomeCliente;
            txtTipoSolicit.Text = _TipoAtendimento;
            txtDestinatario.Text = _EmailCliente;
            txtMotivo.Text = _MotivoEncerramento;
        }
    }
}
