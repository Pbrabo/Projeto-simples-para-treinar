using System;

namespace First.Project
{
    class Program
    {
        static AutomovelRepositorio repositorio = new AutomovelRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						listaCarro();
						break;
					case "2":
						InserirAutomovel();
						break;
					case "3":
						AtualizarAutomovel();
						break;
					case "4":
						ExcluirAutomovel();
						break;
					case "5":
						VisualizarAutomovel();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirAutomovel()
		{
			Console.Write("Digite o id do carro: ");
			int indiceAutomovel = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceAutomovel);
		}

        private static void VisualizarAutomovel()
		{
			Console.Write("Digite o id do carro: ");
			int indiceAutomovel = int.Parse(Console.ReadLine());

			var Automovel = repositorio.RetornaPorId(indiceAutomovel);

			Console.WriteLine(Automovel);
		}

        private static void AtualizarAutomovel()
		{
			Console.Write("Digite o id do carro: ");
			int indiceAutomovel = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite a Marca entre as opções acima: ");
			int entradaMarca = int.Parse(Console.ReadLine());

			Console.Write("Digite o Modelo do Carro: ");
			string entradaModelo = Console.ReadLine();

			Console.Write("Digite o Ano de fabricação do carro: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite o que o carro possui ex: Ar-condicionado, trava elétrica, vidro elétrico: ");
			string entradaDescricao = Console.ReadLine();

			Console.Write("Digite o Preço do carro: ");
			decimal entradaPreco = decimal.Parse(Console.ReadLine());

			Automovel atualizaAutomovel = new Automovel(id: indiceAutomovel,
										Marca: (Genero)entradaMarca,
										Modelo: entradaModelo,
										ano: entradaAno,
										descricao: entradaDescricao,
										Preco: entradaPreco);

			repositorio.Atualiza(indiceAutomovel, atualizaAutomovel);
		}
        private static void listaCarro()
		{
			Console.WriteLine("Listar Carros");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Cadastre um carro e tente novamente.");
				return;
			}

			foreach (var Automovel in lista)
			{
                var excluido = Automovel.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", Automovel.retornaId(), Automovel.retornaModelo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirAutomovel()
		{
			Console.WriteLine("Inserir novo carro");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite a Marca entre as opções acima: ");
			int entradaMarca = int.Parse(Console.ReadLine());

			Console.Write("Digite o Modelo do Carro: ");
			string entradaModelo = Console.ReadLine();

			Console.Write("Digite o Ano de Fabricação do carro: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do carro. EX: ar, direção, vidro, trava. ");
			string entradaDescricao = Console.ReadLine();

			Console.Write("Coloque o valor do carro. ");
			decimal entradaPreco = decimal.Parse(Console.ReadLine());

			Automovel novoCarro = new Automovel(id: repositorio.ProximoId(),
										Marca: (Genero)entradaMarca,
										Modelo: entradaModelo,
										ano: entradaAno,
										descricao: entradaDescricao,
										Preco: entradaPreco);

			repositorio.Insere(novoCarro);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Controle de Estoque.");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Estoque");
			Console.WriteLine("2- Inserir novo Carro");
			Console.WriteLine("3- Atualizar Carro");
			Console.WriteLine("4- Excluir Carro");
			Console.WriteLine("5- Visualizar Carro");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}

