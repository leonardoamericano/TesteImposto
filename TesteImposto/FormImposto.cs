using Imposto.Core.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Imposto.Core.Domain;
using System.Configuration;
using Imposto.Core.Data;
using System.Data.Common;
using Imposto.Core.Repositories;
using Imposto.Shared;
using Imposto.Shared.Enums;
using System.Collections;

namespace TesteImposto
{
    public partial class FormImposto : Form
    {
        private Pedido pedido = new Pedido();
        private string _pathXml = ConfigurationManager.AppSettings["PathXmlNotaFiscal"];

        public FormImposto()
        {
            InitializeComponent();
            dataGridViewPedidos.AutoGenerateColumns = true;                       
            dataGridViewPedidos.DataSource = GetTablePedidos();
            ResizeColumns();
        }

        private void ResizeColumns()
        {
            double mediaWidth = dataGridViewPedidos.Width / dataGridViewPedidos.Columns.GetColumnCount(DataGridViewElementStates.Visible);

            for (int i = dataGridViewPedidos.Columns.Count - 1; i >= 0; i--)
            {
                var coluna = dataGridViewPedidos.Columns[i];
                coluna.Width = Convert.ToInt32(mediaWidth);
            }   
        }

        private object GetTablePedidos()
        {
            DataTable table = new DataTable("pedidos");
            table.Columns.Add(new DataColumn("Nome do produto", typeof(string)));
            table.Columns.Add(new DataColumn("Codigo do produto", typeof(string)));
            table.Columns.Add(new DataColumn("Valor", typeof(decimal)));
            table.Columns.Add(new DataColumn("Brinde", typeof(bool)));
                     
            return table;
        }

        private void buttonGerarNotaFiscal_Click(object sender, EventArgs e)
        {
            IObterConexaoBD conn = new MinhaDbConnection();

            bool abort = false;
            if (this.cbbEstadoOrigem.SelectedItem == null)
            {
                txtEstadoOrigem.Text = "";
                this.lblOrigem.Visible = true;
                abort = true;
            }
            if (this.cbbEstadoDestino.SelectedItem == null)
            {
                txtEstadoDestino.Text = "";
                this.lblDestino.Visible = true;
                abort = true;
            }

            if (abort)
            {
                return;
            }

            NotaFiscalService service = new NotaFiscalService(new NotaFiscalRepository(conn), _pathXml);
            pedido.EstadoOrigem = txtEstadoOrigem.Text;
            pedido.EstadoDestino = txtEstadoDestino.Text;
            pedido.NomeCliente = textBoxNomeCliente.Text;

            DataTable table = (DataTable)dataGridViewPedidos.DataSource;

            foreach (DataRow row in table.Rows)
            {
                pedido.ItensDoPedido.Add(
                    new PedidoItem()
                    {
                        Brinde = Convert.ToBoolean((row["Brinde"]==null)?1:0),
                        CodigoProduto =  row["Codigo do produto"].ToString(),
                        NomeProduto = row["Nome do produto"].ToString(),
                        ValorItemPedido = Convert.ToDouble(row["Valor"].ToString())            
                    });
            }

            var retorno = service.GerarNotaFiscal(pedido);

            if (retorno.Success)
            {
                MessageBox.Show(retorno.Message, "Sucesso");
                LimparCampos();
            }
            else
                MessageBox.Show(retorno.Message, "Atenção!");
        }

        private void LimparCampos()
        {
            this.cbbEstadoDestino.SelectedIndex = -1;
            this.cbbEstadoOrigem.SelectedIndex = -1;
            txtEstadoOrigem.Text = "";
            txtEstadoDestino.Text = "";
            textBoxNomeCliente.Text = "";
            dataGridViewPedidos.DataSource = GetTablePedidos();
            pedido = new Pedido();
            this.lblDestino.Visible = false;
            this.lblOrigem.Visible = false;
        }

        private void FormImposto_Load(object sender, EventArgs e)
        {
            this.cbbEstadoOrigem.DataSource = Util<EEstados>.EnumToList();
            this.cbbEstadoOrigem.SelectedIndex = -1;

            this.cbbEstadoDestino.DataSource = Util<EEstados>.EnumToList();
            this.cbbEstadoDestino.SelectedIndex = -1;
        }

        private void cbbEstadoOrigem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbbEstadoOrigem.SelectedItem == null)
            {
                txtEstadoOrigem.Text = "";
            }
            else
            {
                txtEstadoOrigem.Text = ((EEstados)this.cbbEstadoOrigem.SelectedItem).ToString();
                this.lblOrigem.Visible = false;
            }

        }

        private void cbbEstadoDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbbEstadoDestino.SelectedItem == null)
            {
                txtEstadoDestino.Text = "";
            }
            else
            {
                txtEstadoDestino.Text = ((EEstados)this.cbbEstadoDestino.SelectedItem).ToString();
                this.lblDestino.Visible = false;
            }

        }
    }
}
