// Screen Sound 
string mensagem = "Boas vindas ao Screen Sound!";
//List <string> lista_das_bandas = new List<string> { "U2", "The Beatles", "Calipso" };

Dictionary<String, List<int>> bandas_registradas = new Dictionary<String, List<int>>();
bandas_registradas.Add("Linkin Park", new List<int> {10, 8, 6});
bandas_registradas.Add("The Beatles", new List<int>());

void ExibirLogo()
{
    Console.WriteLine(@"
    
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
    
");
    Console.WriteLine(mensagem);   
}

void ExibirOpcoesDoMenu()
{
   ExibirLogo();
   Console.WriteLine("\nDigite 1 para registrar uma banda");  
   Console.WriteLine("Digite 2 para mostrar todas as bandas");  
   Console.WriteLine("Digite 3 para avaliar uma banda"); 
   Console.WriteLine("Digite 4 para exibir a média de uma banda "); 
   Console.WriteLine("Digite -1 para sair"); 

   Console.Write("\nDigite a sua opção: ");
   string opcao = Console.ReadLine()!;
   int opcao_numero = int.Parse(opcao);
    
   switch(opcao_numero)
   {
    case 1: RegistrarBanda();
        break;
    
    case 2: ; MostrarBandasRegistradas();
        break;

    case 3: AvaliarUmaBanda();
        break;

    case 4: ExibirMedia();
        break;

    case -1: Console.WriteLine("Tchau tchau *");
        break;
    
    default: Console.WriteLine("Opção inválida");
        break;
   }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro das bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomebanda = Console.ReadLine()!;
    bandas_registradas.Add(nomebanda, new List<int>());
    Console.WriteLine($"A banda {nomebanda} foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void MostrarBandasRegistradas()
{
   Console.Clear();
   ExibirTituloDaOpcao("Exibindo todas as bandas registradas");

   foreach (string banda in bandas_registradas.Keys)
   {
    Console.WriteLine($"Banda: {banda}");
   }

   Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
   Console.ReadKey();
   Console.Clear();
   ExibirOpcoesDoMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidade_letras =  titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidade_letras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarUmaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nome_banda = Console.ReadLine()!;
    if (bandas_registradas.ContainsKey(nome_banda))
    {
        Console.WriteLine($"Qual a nota que a banda {nome_banda} merece? ");
        int nota = int.Parse(Console.ReadLine()!);
        bandas_registradas[nome_banda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi resgistrada com sucesso para a banda {nome_banda}");
        Thread.Sleep(4000);
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nome_banda} não foi encontrada ");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();

    }
}

void ExibirMedia()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibir média da banda");
    Console.Write("Digite o nome da banda que deseja exibir a média: ");
    string nome_banda = Console.ReadLine()!;
    if (bandas_registradas.ContainsKey(nome_banda))
    {
        List<int> notas_banda =  bandas_registradas[nome_banda];
        Console.WriteLine($"\nA média da banda {nome_banda} é {notas_banda.Average()}.");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nome_banda} não foi encontrada");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

ExibirOpcoesDoMenu();

