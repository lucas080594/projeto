using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBRAXADMIN
{
    class ConexaoComBanco
    {
        private static SqlConnection objConexao = null;

        // string mysql acessa o banco do servidor de hospedagem
        private String stringconnection1 = "server=DESKTOP-AFHKHDV\\SQLEXPRESS; Database=BDPIM;Trusted_Connection=True;";

        //string mysql rodando na maquina do desenvolvedor.
        private String stringconnection2 = "server=DESKTOP-AFHKHDV\\SQLEXPRESS; Database=BDPIM;Trusted_Connection=True;";

        #region metodos que tentam abrir conexao com projeto rodando local ou hospedado

        public void tentarAbrirConexaoLocal()
        {
            objConexao = new SqlConnection();
            objConexao.ConnectionString = stringconnection1;
            objConexao.Open();
        }

        public void tentarAbrirConexaoRemota()
        {
            objConexao = new SqlConnection();
            objConexao.ConnectionString = stringconnection2;
            objConexao.Open();
        }
        #endregion

        public ConexaoComBanco()
        {
            try
            {
                tentarAbrirConexaoRemota();
            }
            catch
            {
                try
                {
                    tentarAbrirConexaoLocal();
                }
                catch
                {
                    Console.WriteLine("Não foi possível validar seu acesso.Tente novamente.");


                }
            }

        }

        public static SqlConnection abrirConexao()
        {
            new ConexaoComBanco();
            return objConexao;
        }
        public static void fecharConexa(SqlConnection cn_aberta)
        {
            if (cn_aberta.State == System.Data.ConnectionState.Open)
            {
                cn_aberta.Close();
            }

        }
    }
}

