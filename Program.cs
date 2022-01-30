using System;
using AppCadastro.src.Classes;
using AppCadastro.src.Enums;

namespace AppCadastro
{
    class Program
    {
        static GameRepository Repository = new GameRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

			while (userOption.ToUpper() != "X")
			{
				switch (userOption)
				{
					case "1":
						ListGames();
						break;
					case "2":
						InsertGame();
						break;
					case "3":
						UpdateGame();
						break;
					case "4":
						DeleteGame();
						break;
					case "5":
						ViewGame();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				userOption = GetUserOption();
			}

			Console.WriteLine("Obrigado pela Preferência.");
			Console.ReadLine();
        }

        private static void DeleteGame()
		{
			Console.Write("Digite o id do Game: ");
			int GameIndex = int.Parse(Console.ReadLine());

			Repository.Delete(GameIndex);
		}

        private static void ViewGame()
		{
			Console.Write("Digite o id da série: ");
			int GameIndex = int.Parse(Console.ReadLine());

			var Game = Repository.ReturnById(GameIndex);

			Console.WriteLine(Game);
		}

        private static void UpdateGame()
		{
			Console.Write("Digite o id do Game: ");
			int GameIndex = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Gender)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int GenderInput = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Game: ");
			string TitleInput = Console.ReadLine();

			Console.Write("Digite o Ano de Criação do Game: ");
			int YearInput = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Game: ");
			string DescriptionInput = Console.ReadLine();

			Game UpdateGame = new Game(id: GameIndex,
										genero: (Gender)GenderInput,
										title: TitleInput,
										year: YearInput,
										description: DescriptionInput);

			Repository.Update(GameIndex, UpdateGame);
		}
        private static void ListGames()
		{
			Console.WriteLine("Listar Games");

			var lista = Repository.List();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum Game cadastrado.");
				return;
			}

			foreach (var Game in lista)
			{
                var excluido = Game.ReturnDeleted();
                
				Console.WriteLine("#ID {0}: - {1} {2}", Game.ReturnId(), Game.ReturnTitle(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InsertGame()
		{
			Console.WriteLine("Inserir novo Game");

			foreach (int i in Enum.GetValues(typeof(Gender)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int GenderInput = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Game: ");
			string TitleInput = Console.ReadLine();

			Console.Write("Digite o Ano de Criação do Game: ");
			int YearInput = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Game: ");
			string DescriptionInput = Console.ReadLine();

			Game newGame = new Game(id: Repository.NextId(),
										genero: (Gender)GenderInput,
									    title: TitleInput,
										year: YearInput,
										description: DescriptionInput);

			Repository.Insert(newGame);
		}

        private static string GetUserOption()
		{
			Console.WriteLine();
			Console.WriteLine("Bem-vindo a Loja Digital Forbiddome Games!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar games");
			Console.WriteLine("2- Inserir novo game");
			Console.WriteLine("3- Atualizar um game");
			Console.WriteLine("4- Excluir um game");
			Console.WriteLine("5- Visualizar um game");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string userOption = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return userOption;
        }
    }
}