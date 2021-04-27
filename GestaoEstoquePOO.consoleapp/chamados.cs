using System;

namespace GestaoEstoquePOO.consoleapp
{
    internal class chamados
    {
        private string chamado;
        private string equipamento;
        private string descricao;
        private DateTime dataAbertura;
        private int diasaberto;

        public chamados(string chamado, string equipamento, string descricao, DateTime dataAbertura, int diasaberto)
        {
            this.chamado = chamado;
            this.equipamento = equipamento;
            this.descricao = descricao;
            this.dataAbertura = dataAbertura;
            this.Diasaberto = diasaberto;
        }

    


        public string Chamado { get => chamado; set => chamado = value; }
        public string Equipamento { get => equipamento; set => equipamento = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public DateTime DataAbertura { get => dataAbertura; set => dataAbertura = value; }
        public int Diasaberto { get => diasaberto; set => diasaberto = value; }


        private int diasemAberto()
        {
            DateTime dataAtual = DateTime.Now;

            TimeSpan diferenca = dataAtual.Subtract(DataAbertura);

            diasaberto = Convert.ToInt32(diferenca.TotalDays);

            return diasaberto ;
        }

        public override string ToString()
        {
            return $"Titulo do Chamado:{chamado}\n Nome do Equipamento :{equipamento}\n descrição do Chamado : {descricao}\n  data de abertura do Chamado: {dataAbertura}\n {diasaberto}";
        }
        
    }
}