using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BancoDeDadosMySql
{
    internal class Program
    {
        static MySqlConnection connection;

        static void Main(string[] args)
        {
            //ESTABELECENDO A CONEXÃO COM O BANCO ANTES DE INICIAR
            Conexao();

            Console.WriteLine(@"
░██████╗██╗░██████╗████████╗  ░█████╗░░█████╗░██████╗░  ░█████╗░███╗░░██╗██╗███╗░░░███╗░█████╗░██╗░░░░░
██╔════╝██║██╔════╝╚══██╔══╝  ██╔══██╗██╔══██╗██╔══██╗  ██╔══██╗████╗░██║██║████╗░████║██╔══██╗██║░░░░░
╚█████╗░██║╚█████╗░░░░██║░░░  ██║░░╚═╝███████║██║░░██║  ███████║██╔██╗██║██║██╔████╔██║███████║██║░░░░░
░╚═══██╗██║░╚═══██╗░░░██║░░░  ██║░░██╗██╔══██║██║░░██║  ██╔══██║██║╚████║██║██║╚██╔╝██║██╔══██║██║░░░░░
██████╔╝██║██████╔╝░░░██║░░░  ╚█████╔╝██║░░██║██████╔╝  ██║░░██║██║░╚███║██║██║░╚═╝░██║██║░░██║███████╗
╚═════╝░╚═╝╚═════╝░░░░╚═╝░░░  ░╚════╝░╚═╝░░╚═╝╚═════╝░  ╚═╝░░╚═╝╚═╝░░╚══╝╚═╝╚═╝░░░░░╚═╝╚═╝░░╚═╝╚══════╝");

            Console.WriteLine("1 - Cadastrar");
            Console.WriteLine("2 - Consultar");
            Console.WriteLine("3 - Atualizar");
            Console.WriteLine("4 - Excluir");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1: //Cadastrar();
                    break;
                case 2:
                    Consultar();
                    break;
                case 3: //Atualizar();
                    break;
                case 4: //Excuir()
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

        }

        static void Conexao()
        {
            string connectionString = "Server=127.0.0.1;Database=bd_cad_animal;User Id=root;Password=root";

            using (connection = new MySqlConnection(connectionString))
            {

                try
                {
                    connection.Open();
                    Console.WriteLine("CONEXÃO COM O BANCO DE DADOS REALIZADA COM SUCESSO!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }
        }
        static void Consultar()
        {

            //CONSULTANDO DADOS DO BANCO DE DADOS
            connection.Open();

            string query = "SELECT * FROM Animal";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["nome"].ToString() +
                            " | " + reader["idade"].ToString() + "\n");
                    }
                }
            }

        }
    }
}
