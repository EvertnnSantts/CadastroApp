//Aplicação de cadastro e consultas de usuarios.
//Nome da aplicação: "cadastroEconsultas".
namespace CadastroEConsultas
{
    class Program {
        static List<Pessoa> pessoas = new List<Pessoa>();
        static void Main(string[] args){
            // Coleta de nome do usuário:
            Console.WriteLine("");
            Console.WriteLine("===================================================");
            Console.WriteLine("===================================================");
            Console.WriteLine("=============== CadastroEconsultas ================");
            Console.WriteLine("===================================================");
            Console.WriteLine("===================================================");
            Console.WriteLine("POR FAVOR, INFORME SEU NOME?");
            string? nome = Console.ReadLine();
            // Se o usuário recusar a digitar seu nome, os serviços da aplicação não serão disponíveis:
            if (string.IsNullOrEmpty(nome)){
                Console.WriteLine("Não pdemos continuar sem seu nome :(");
                return;
            }
            // Bloco de serviços da aplicação:
            while (true){
                // Bloco de serviços da aplicação:
                Console.WriteLine("===================================================");
                Console.WriteLine("===================================================");
                Console.WriteLine($"================= Bem-vindo {nome} ================");
                Console.WriteLine("===================== MENU ========================");
                Console.WriteLine("===================================================");
                Console.WriteLine("===================================================");
                Console.WriteLine("============== 1. Cadastrar Usuario ===============");
                Console.WriteLine("============== 2. Lista de Usuarios ===============");
                Console.WriteLine("============== 3. Sair ============================");
                Console.WriteLine("===================================================");
                Console.WriteLine("===================================================");
                Console.WriteLine("Obs: Digite apenas o número do serviço desejado!");
                string opcao = Console.ReadLine();
                switch (opcao){
                    case "1":
                        CadastrarPessoa();
                        break;
                    case "2":
                        ListarUsuarios();
                        break;
                    case "3":
                        Console.WriteLine("Encerrado....");
                        return; 
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.\n");
                        break; 
                }
            }
        }

        // Cadastro de usuários
        static void CadastrarPessoa()
        {
            //Área de cadastro de Usuario
            Console.WriteLine("===================================================");
            Console.WriteLine("===================================================");
            Console.WriteLine("================= ÁREA DE CADASTRO ================");
            Console.WriteLine("===================================================");
            Console.WriteLine("===================================================");
            Console.Write("Nome do usuário: ");
            string nome = Console.ReadLine();
            Console.Write("Email do usuário: ");
            string email = Console.ReadLine();
            Console.Write("Idade do usuário: ");
            int idade;
            while (!int.TryParse(Console.ReadLine(), out idade)){
                Console.WriteLine("Idade inválida. Por favor, insira um número válido.");
            }
            //Criação do objeto Pessoa
            Pessoa novaPessoa = new Pessoa(nome, email, idade);
            //Adicionando o novo usuário à lista de cadastro
            pessoas.Add(novaPessoa);
            //Mensagem de sucesso:
            Console.WriteLine($"Usuário {nome} cadastrado com sucesso!");
            //escolha da consulta
            Console.WriteLine("Pronto, agora você quê ir para lista Usuario? responda com: Sim ou Não");
            string? resposta = Console.ReadLine();
            if (resposta == "Sim" || resposta == "sim" || resposta == "s" || resposta == "S"){
              ListarUsuarios();
            }else if(resposta == "Nao" || resposta == "nao" || resposta == "n" || resposta == "N"){
            Console.WriteLine("Ok, encerrado...");
            }else{
               Console.WriteLine("Tente novamente");
               CadastrarPessoa();
            }
        }

        // Função de busca e listagem de usuários:
        static void ListarUsuarios(){
            if (pessoas.Count == 0){
            //Se não existe usuário na aplicação, a seguinte mensagem irá aparecer:
            Console.WriteLine("Ops, ainda não existe usuário cadastrado :(");
            }

            //Lista de usuários:
            Console.WriteLine("===================================================");
            Console.WriteLine("===================================================");
            Console.WriteLine("================= Lista de Pessoas ================");
            Console.WriteLine("===================================================");
            Console.WriteLine("===================================================");
            foreach (var pessoa in pessoas){
             Console.WriteLine($"Nome: {pessoa.Nome}, Email: {pessoa.Email}, Idade: {pessoa.Idade}");
            }
            Console.WriteLine("===================================================");
            Console.WriteLine("===================================================");
            Console.WriteLine("======================= MENU ======================");
            Console.WriteLine("===================================================");
            Console.WriteLine("===================================================");
            Console.WriteLine("============== 1. Cadastrar Usuario ===============");
            Console.WriteLine("============== 2. Lista de Usuarios ===============");
            Console.WriteLine("============== 3. Sair ============================");
            Console.WriteLine("===================================================");
            Console.WriteLine("===================================================");
             string? resposta = Console.ReadLine();
                 switch (resposta){
                case "1":
                    BuscarUsuario();
                    break;
                case "2":
                     CadastrarPessoa();
                    break;
                case "3":
                    Console.WriteLine("Encerrado....");
                    return;
                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    ListarUsuarios();
                    break;
            }
        }

        static void BuscarUsuario(){
        Console.WriteLine("Digite o nome do usuário que deseja buscar:");
        string? nomeBusca = Console.ReadLine();

         //A busca atraves o usuário na lista pelo nome (case-insensitive)
        var usuarioEncontrado = pessoas.Find(p => p.Nome.Equals(nomeBusca, StringComparison.OrdinalIgnoreCase));

        if (usuarioEncontrado != null) {
        //Exibe as informações do usuário encontrado
        Console.WriteLine($"Usuário encontrado: Nome: {usuarioEncontrado.Nome}, Email: {usuarioEncontrado.Email}, Idade: {usuarioEncontrado.Idade}");
        }else{
        //Caso o usuário não seja encontrado:
        Console.WriteLine("Usuário não encontrado.");
        }
        Console.WriteLine("===================================================");
        Console.WriteLine("===================================================");
        Console.WriteLine("======================== MENU =====================");
        Console.WriteLine("===================================================");
        Console.WriteLine("===================================================");
        Console.WriteLine("============== 1. Cadastrar Usuario ===============");
        Console.WriteLine("============== 2. Lista de Usuarios ===============");
        Console.WriteLine("============== 3. Sair ============================");
        Console.WriteLine("===================================================");
        Console.WriteLine("===================================================");
        Console.WriteLine("Obs: Digite apenas o número do serviço desejado!");
        // A aplicação irá direcionar o usuário de acordo com a escolha
        string opcao1 = Console.ReadLine();
         switch (opcao1){
                case "1":
                    CadastrarPessoa();
                    break;
                case "2":
                    ListarUsuarios();
                    break;
                case "3":
                    Console.WriteLine("Encerrado....");
                    return;
                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    BuscarUsuario();
                    break;
            }
        }
    }
        // Classe do objeto "pessoa":
        class Pessoa{
            public string Nome { get; set; }
            public string Email { get; set; }
            public int Idade { get; set; }
            public Pessoa(string nome, string email, int idade) {
                Nome = nome;
                Email = email;
                Idade = idade;
            }
        }

    }
