using DIO.Series;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.Series
{
    public class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        public static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
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
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nosso SErviço");
            Console.WriteLine();

        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o Id da Serie: ");
            int indicaSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indicaSerie);
            Console.WriteLine(serie);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o Id da Serie: ");
            int indicaSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indicaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Atualizar Serie");
            Console.WriteLine("Digite o ID da Serie: ");
            int entraId = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entraGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da Serie: ");
            string entraTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de inicio da Serie: ");
            int entraAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição: ");
            string entraDescricao = Console.ReadLine();

            Series atualizaSerie = new Series(id: entraId,
                                                    genero: (Genero)entraGenero,
                                                    titulo: entraTitulo,
                                                    ano: entraAno,
                                                    descricao: entraDescricao
                                                     );
            repositorio.Atualiza(entraId, atualizaSerie);
        }
    

    private static void InserirSerie()
    {
        Console.WriteLine("Inserir nova Serie");

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
        }
        Console.WriteLine("Digite o genêro entre as opções acima: ");
        int entraGenero = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o titulo da Serie: ");
        string entraTitulo = Console.ReadLine();

        Console.WriteLine("Digite o ano de inicio da Serie: ");
        int entraAno = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite a Descrição: ");
        string entraDescricao = Console.ReadLine();

        Series novaSerie = new Series(id: repositorio.ProximoId(),
                                                genero: (Genero)entraGenero,
                                                titulo: entraTitulo,
                                                ano: entraAno,
                                                descricao: entraDescricao
                                                 );
            repositorio.Insere(novaSerie);
    }


        private static void ListarSeries()
        {
            Console.WriteLine("Listar Series");
            var lista = repositorio.Lista();
            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada");
                return;
            }
            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluidoId();
                if (!excluido)
                {
                    Console.WriteLine("#ID {0} : - {1}", serie.retornaId(), serie.retornaTitulo());
                }
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Series ao seu Dispor!!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar Series");
            Console.WriteLine("2 - Inserir nova Serie");
            Console.WriteLine("3 - Atualizar Serie");
            Console.WriteLine("4 - Excluir Serie");
            Console.WriteLine("5 - Visualizar Serie");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }


    }
}
