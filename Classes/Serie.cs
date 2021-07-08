using System;

namespace First.Project
{
    public class Automovel : EntidadeBase
    {
        // Atributos
		private Genero Marca { get; set; }
		private string Modelo { get; set; }
		private string Descricao { get; set; }
		private int Ano { get; set; }

		private decimal Preco { get; set; }
        private bool Excluido {get; set;}

        // Métodos
		public Automovel(int id, Genero Marca, string Modelo, string descricao, int ano, decimal Preco)
		{
			this.Id = id;
			this.Marca = Marca;
			this.Modelo = Modelo;
			this.Descricao = descricao;
			this.Ano = ano;
			this.Preco = Preco;
            this.Excluido = false;
		}

        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Marca: " + this.Marca + Environment.NewLine;
            retorno += "Modelo: " + this.Modelo + Environment.NewLine;
            retorno += "Descrição do veiculo: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Fabricação: " + this.Ano + Environment.NewLine;
			retorno += "Preço do carro: " + this.Preco + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string retornaModelo()
		{
			return this.Modelo;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}