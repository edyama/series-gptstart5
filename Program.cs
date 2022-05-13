using series_gptstart5.Enum;
using series_gptstart5.Models;

namespace series_gptstart5
{
    public class Program
    {
        static RepositorioSeries repositorio = new RepositorioSeries();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "S")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "L":
                        Console.Clear();
                        break;
                    default:
						throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nosso serviço!");
            Console.ReadLine();
        }
        private static void ListarSerie()
        {
            Console.WriteLine();
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série de TV cadastrada");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornarExcluído();
                Console.WriteLine($"#ID {serie.retornarId()}: {serie.retornarTitulo()} {(excluido ? "*Série de TV Excluída*" : "")}");
            }
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir uma nova série de TV");
			foreach (int i in System.Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine($"{i}-{System.Enum.GetName(typeof(Genero), i)}");
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entrarGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entrarTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entrarAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entrarDescricao = Console.ReadLine();

			Series novaSerie = new Series(id: repositorio.ProximoId(),
                                        genero: (Genero)entrarGenero,
                                        titulo: entrarTitulo,
                                        descricao: entrarDescricao,
                                        ano: entrarAno);

			repositorio.Inserir(novaSerie);
        }
        private static void AtualizarSerie()
        {
            Console.Write("Digite o ID da série de TV: ");
			int indiceSerie = int.Parse(Console.ReadLine());
			foreach (int i in System.Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine($"{i}-{System.Enum.GetName(typeof(Genero), i)}");
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entrarGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entrarTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entrarAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entrarDescricao = Console.ReadLine();

			Series atualizaSerie = new Series(id: indiceSerie,
										genero: (Genero)entrarGenero,
										titulo: entrarTitulo,
										ano: entrarAno,
										descricao: entrarDescricao);

			repositorio.Atualizar(indiceSerie, atualizaSerie);
        }
        private static void ExcluirSerie()
        {
            Console.Write("Digite o ID da série de TV: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Excluir(indiceSerie);
        }
        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série de TV: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornarPorId(indiceSerie);

			Console.WriteLine(serie);
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("----------------");
            Console.WriteLine("Informe a sua opção:");
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("L - Limpar Tela");
            Console.WriteLine("S - Sair");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
