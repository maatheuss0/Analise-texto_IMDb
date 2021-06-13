using System;
using POOOC.Interfaces;

namespace POOOC.Classes
{
        public class Login : ILogin
        {
            Usuario NovoUsuario = new Usuario();
            private bool Logado = false;
            private bool Sair;
            private int ContMarca = 1;
            private int ContProduto = 1;
            private string Nome;
            private string Email;
            private string Senha;
            Produto Produtinho = new Produto();
            Marca marca = new Marca();
            Marca AntiErro = new Marca();
            private string MarcaAntiErro;

            public string Deslogar()
            {
                Logado = false;
                return "Deslogado do sistema";
            }

            public string Logar()
            {
                Logado = true;
                return "Logado no sistema";
            }

            public Login()
            {
                Sair = false;
                AntiErro.Valores(0, "Sadia");
                marca.Cadastrar(AntiErro);
                do
                {
                    Console.WriteLine(@"
____________________________________
| Bem vindo a vendinha do seu José |
|¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨|
|    0 - Sair                      |
|    1 - Cadastrar-se              |
|    2 - Logar                     |
|__________________________________|");

                    string opcao = Console.ReadLine();

                    switch (opcao)
                    {
                        case "0":
                            Sair = true;
                            Console.WriteLine("Obrigado por utilizar o sistema!");
                            break;
                        case "1":
                            int c = 1;

                            Console.Write("\nDigite seu nome de usuário: ");
                            Nome = Console.ReadLine();

                            Console.Write("Digite seu E-mail: ");
                            Email = Console.ReadLine();

                            Console.Write("Digite sua senha: ");
                            Senha = Console.ReadLine();

                            NovoUsuario.NovoUsuario(c, Nome, Email, Senha);
                            Console.WriteLine("Usuário cadastrado com sucesso!");
                            Console.WriteLine($"Seu horário de cadastro foi {DateTime.Now}");
                            c++;
                            break;
                        case "2":
                            bool VerificarLogin = false;
                            if (Nome != null)
                            {
                                do
                                {
                                    Console.Write("Digite seu Nome de Usuario ou E-mail: ");
                                    string Login = Console.ReadLine();
                                    Console.Write("Digite sua senha: ");
                                    string SenhaLogin = Console.ReadLine();

                                    if ((Nome == Login || Email == Login) && SenhaLogin == Senha)
                                    {
                                        Console.WriteLine(Logar());
                                        VerificarLogin = true;
                                        Logado = true;

                                        bool Logado2 = true;
                                        do
                                        {
                                            Console.WriteLine($@"
____________________________________
|    0 - Sair                      |
|    1 - Cadastrar Um produto      |
|    2 - Deletar um produto        |
|    3 - Cadastrar uma marca       |
|    4 - Deletar uma marca         |
|    5 - Deslogar                  |
|    6 - Deletar usuario           |
|    7 - Listar Marcas             |
|    8 - Listar Produtos           |
|__________________________________|
                                    
                                    ");
                                            string opcao2 = Console.ReadLine();
                                            switch (opcao2)
                                            {
                                                case "0":
                                                    Sair = true;
                                                    Console.WriteLine("Obrigado por utilizar o sistema da Vendinha do seu José");
                                                    Logado = false;
                                                    Logado2 = false;
                                                    break;
                                                case "1":
                                                    Produto ProdutoCadastro = new Produto();
                                                    Console.Write("Digite o nome do produto: ");
                                                    string NomeProduto = Console.ReadLine();

                                                    Console.Write("Digite o preço do produto: ");
                                                    float PrecoProduto = float.Parse(Console.ReadLine());

                                                    marca.Listar();
                                                    Console.Write("Digite o código da marca do produto: ");
                                                    int MarcaEscolhida = int.Parse(Console.ReadLine());
                                                    MarcaAntiErro = marca.ListaMarcas.Find(x => x.CodigoMarca == MarcaEscolhida).NomeMarca;

                                                    ProdutoCadastro.Valores(ContProduto, NomeProduto, PrecoProduto, MarcaAntiErro, Nome);
                                                    Console.WriteLine(Produtinho.Cadastrar(ProdutoCadastro));
                                                    ContProduto++;
                                                    break;
                                                case "2":
                                                    Console.Write($"Digite o código de qual produto deseja apagar: ");
                                                    Produtinho.Listar();
                                                    int CodigoProduto = int.Parse(Console.ReadLine());
                                                    Produtinho.Deletar(Produtinho.ListaProdutos.Find(x => x.Codigo == CodigoProduto));
                                                    break;
                                                case "3":
                                                    Marca MarcaCadastro = new Marca();
                                                    Console.Write("Digite o nome da marca: ");
                                                    string NomeMarca = Console.ReadLine();

                                                    MarcaCadastro.Valores(ContMarca, NomeMarca);
                                                    Console.WriteLine(marca.Cadastrar(MarcaCadastro));
                                                    ContMarca++;
                                                    break;
                                                case "4":
                                                    Console.Write($"Digite o código de qual produto deseja apagar: ");
                                                    marca.Listar();
                                                    int CodigoMarca = int.Parse(Console.ReadLine());
                                                    marca.Deletar(marca.ListaMarcas.Find(x => x.CodigoMarca == CodigoMarca));
                                                    break;
                                                case "5":
                                                    Console.WriteLine(Deslogar());
                                                    Logado = false;
                                                    Logado2 = false;
                                                    break;
                                                case "6":
                                                    Console.WriteLine(NovoUsuario.Deletar(NovoUsuario));
                                                    break;
                                                case "7":
                                                    marca.Listar();
                                                    break;
                                                case "8":
                                                    Produtinho.Listar();
                                                    break;
                                                default:
                                                    Console.WriteLine("Comando inválido");
                                                    break;
                                            }
                                        } while (Logado2 == true);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Login falho, Tente Novamente!\n");
                                    }
                                } while (VerificarLogin == false);
                            }
                            else
                            {
                                Console.WriteLine("Você precisa se cadastrar!");
                            }

                            break;
                        default:
                            break;
                    }
                } while (Sair == false);
            }
        }
    }
