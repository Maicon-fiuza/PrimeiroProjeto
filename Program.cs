// Screen Sound
string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
//List<string>   listaDasBandas = new List<string> {"Calcinha preta", "The beatles", "Link Park"};// Lista já com itens 

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Link Park", new List<int> { 10, 8, 6 });
bandasRegistradas.Add("Beatles", new List<int> ());


void ExibirLogo() //void função que não retorna. //PascalCase
{
    Console.WriteLine(@"

█▀ █▀▀ █▀█ █▀▀ █▀▀ █▄░█   █▀ █▀█ █░█ █▄░█ █▀▄
▄█ █▄▄ █▀▄ ██▄ ██▄ █░▀█   ▄█ █▄█ █▄█ █░▀█ █▄▀

"); // @ significa verbartin literal , onde minha string é mostrada do jeito que ela é.
    Console.WriteLine(mensagemDeBoasVindas); //Padrão camel case

}

void ExibirOpçõesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a media de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida= Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    
    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBanda();
            break;
        case 2: MostrarBandasRegistradas();
            break;
        case 3: AvaliarUmaBanda();
            break;
        case 4: ExibirMedia();
            break;
        case -1: Console.WriteLine("Volte sempre! :) " + opcaoEscolhidaNumerica);
            break;
        default: Console.WriteLine("Opção inválida");
            break;
    }
}

void RegistrarBanda()
{
    Console.Clear(); //Limpar meu console se tiver algo.o
    ExibirTituloDaOpcao("Registro das Bandas");
    Console.Write("Digite o nome da banda que deseja registar: ");
    string nomeDaBanda = Console.ReadLine()!; // a exclamção indica que eu não quero trabalhar com valor nulo.
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso");
    Thread.Sleep(4000);
    Console.Clear();
    ExibirOpçõesDoMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas");
   
    foreach(string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda : {banda}");
    }

    Console.WriteLine("\nDigite qualquer tecla para voltar ao menu principal ");
    Console.ReadKey();
    Console.Clear();
    ExibirOpçõesDoMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras,'*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarUmaBanda()
{
    // digite qual banda deseja avaliar
    // se a banda existir no dicionario >> atribuir uma nota
    // senão, voltar ao menu principal

    Console.Clear();
    ExibirTituloDaOpcao("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar:");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.WriteLine($"Qual a nota que a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpçõesDoMenu();
    } else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpçõesDoMenu();
        
    }
}

void ExibirMedia()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibir média da banda");
    Console.Write("Digite a banda que deseja exibir média:");
    string nomeDaBanda = Console.ReadLine()!;
    if(bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
        Console.WriteLine($"A media da banda{nomeDaBanda} é {notasDaBanda.Average()}");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpçõesDoMenu();
    } else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpçõesDoMenu();
    }
}


ExibirOpçõesDoMenu();
