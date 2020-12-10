namespace Atividade_1
{
    public class Pedido
    {
        public Pedido(string descricao)
        {
            this.descricao = descricao;

        }
        public string descricao { get; set; }

        public string valorUnitario;

        public string quantidade;

        public Pedido(string _descr, string _valorUni, string _quant)
        {
            descricao = _descr;
            valorUnitario = _valorUni;
            quantidade = _quant;

        }

        public Pedido()
        {
        }

        public string ConvertString()
        {
            string texto = "Descrição: " + descricao +
            "; Valor Unitário: " + valorUnitario +
            "; Quantidade: " + quantidade;

            return texto;
        }
    }
}