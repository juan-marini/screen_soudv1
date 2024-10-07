// Screen Sound

string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";

Dictionary<string, List<int>> bandasNotas = new Dictionary<string, List<int> >();
bandasNotas.Add("hahaha", new List<int> { 10, 8, 9 });
bandasNotas.Add("hahaha2", new List<int>());

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
    Console.WriteLine(mensagemDeBoasVindas);
}

void opcoesMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            registrarBanda();
            break;
        case 2:
            listarBandas();
            break;
        case 3:
            avaliarBanda();
            break;
        case 4:
            exibirMedia();
            break;
        case -1:
            Console.WriteLine("Tchau tchau :)");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}


void registrarBanda()
{
    Console.Clear();

    exibirTitulo("Registro das bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasNotas.Add(nomeDaBanda, new List<int>());

    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();

    opcoesMenu();
}


void avaliarBanda()
{
    Console.Clear();

    exibirTitulo("Avaliar banda");

    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;

    if(bandasNotas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual nota para a banda {nomeDaBanda}");
        int nota = int.Parse(Console.ReadLine())!;
        bandasNotas[nomeDaBanda].Add(nota);

        Console.WriteLine("A nota foi registrada com sucesso!");

        Thread.Sleep(2000);

        Console.Clear();

        opcoesMenu();

    } else
    {
        Console.WriteLine($"{nomeDaBanda} não foi encontrada.");
        Console.WriteLine("Digite uma tecla para voltar pro menu principal.");
        Console.ReadKey();

        Console.Clear();

        opcoesMenu();

    }
}
void listarBandas()
{
    Console.Clear();
    exibirTitulo("Exibindo as bandas registradas");

    foreach (string banda in bandasNotas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    opcoesMenu();

}

void exibirTitulo(string titulo)
{
    int qtdLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(qtdLetras,'*');

    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos);
    Console.WriteLine();

}

void exibirMedia()
{
    Console.Clear();

    exibirTitulo("Media da banda");

    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandasNotas.ContainsKey(nomeDaBanda))
    {
        List<int> notas = bandasNotas[nomeDaBanda];

        if (notas.Count == 0)
        {
            Console.WriteLine($"{nomeDaBanda} ainda não possui avaliações.");
        } else
        {
            double media = notas.Average();
            Console.WriteLine("Média: " + media);
        }

    }
    else
    {
        Console.WriteLine($"{nomeDaBanda} não foi encontrada.");
        Console.WriteLine("Digite uma tecla para voltar pro menu principal.");
        Console.ReadKey();

        Console.Clear();

        opcoesMenu();

    }
}

opcoesMenu();