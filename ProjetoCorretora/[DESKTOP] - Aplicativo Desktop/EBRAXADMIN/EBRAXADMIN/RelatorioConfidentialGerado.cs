using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EBRAXADMIN
{
    public partial class RelatorioConfidentialGerado : Form
    {

        public RelatorioConfidentialGerado(string totalClientes, string totalDinheiroCustodia, string totalPendenciaAtendmnt)
        {

            InitializeComponent();
            
            
            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[3];

            p[0] = new Microsoft.Reporting.WinForms.ReportParameter("ClienteAtivo", totalClientes);
            p[1] = new Microsoft.Reporting.WinForms.ReportParameter("DinheiroCustodia", totalDinheiroCustodia);
            p[2] = new Microsoft.Reporting.WinForms.ReportParameter("PendenciasAtendmnt", totalPendenciaAtendmnt);

            repConfidential.LocalReport.SetParameters(p);
            repConfidential.LocalReport.Refresh();
            repConfidential.Refresh();
            
        }

        private void RelatorioConfidentialGerado_Load(object sender, EventArgs e)
        {
            this.repConfidential.RefreshReport();
        }
    }
}
