using System;

namespace GestaoEstoquePOO.consoleapp
{
     class equipamento
    {

        private string nome;
        private double precoAquisicao;
        private int numeroserie;
        private DateTime dataFabricacao;
        private string fabricante;

      

        public equipamento(string nome, double precoAquisicao, int numeroserie, DateTime dataFabricacao, string fabricante)
        {
            this.nome = nome;
            this.precoAquisicao = precoAquisicao;
            this.numeroserie = numeroserie;
            this.dataFabricacao = dataFabricacao;
            this.fabricante = fabricante;
        }

        public string Nome { get => nome; set => nome = value; }
        public double PrecoAquisicao { get => precoAquisicao; set => precoAquisicao = value; }
        public int Numeroserie { get => numeroserie; set => numeroserie = value; }
        public DateTime DataFabricacao { get => dataFabricacao; set => dataFabricacao = value; }
        public string Fabricante { get => fabricante; set => fabricante = value; }

        public override string ToString()
        {
            return $"Nome do equipamento: {nome}\nPreço de aquisição: {precoAquisicao}\nNúmero de série: {numeroserie}\nData de Fabricação:  {dataFabricacao}\nFabricante: {fabricante}";

        }
    }
    
}