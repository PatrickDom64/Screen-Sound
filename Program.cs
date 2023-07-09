using System;
using System.Runtime.CompilerServices;

Dictionary<string, List<int>> BandasRegistradas = new Dictionary<string, List<int>>();
BandasRegistradas.Add("Link Park", new List<int> { 10, 2, 9 } );
BandasRegistradas.Add("Korn", new List<int> { 10, 10, 9 });

//List<string> ListaBandas = new List<string>();

void ExibirMensagemDeBoasVindas()
    {
    Console.WriteLine(@"
     ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░░██████╗
     ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗██╔════╝
     ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║╚█████╗░
     ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║░╚═══██╗
     ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝██████╔╝
     ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░╚═════╝░
     ");
    }

    void OpçoesMenu(){

    Console.WriteLine("\n 1    - Opição registrar banda");
    Console.WriteLine(" 2    - Opição mostrar todas as bandas");
    Console.WriteLine(" 3    - Opição avaliar uma banda");
    Console.WriteLine(" 4    - Opição exibir a media de notas das bandas");
    Console.WriteLine("-1    - Sair");

    Console.Write("Escolha uma opição:");
    
     string escolha = Console.ReadLine()!;
     int OpicaoEscolhida = int.Parse(escolha);
    
    switch (OpicaoEscolhida)
    {
        case 1:
            titulo("Registrar Banda");
            RegistrarBanda();
            break;
        case 2:
            titulo("Mostrar Lista");
            MostrarLista();
            break;
        case 3:
            titulo("Avaliar Banda");
            AvaliarUmaBanda();
            break;
        case 4:
            titulo("Media das Bandas");
            MediaDasBandas();
            break;
        case -1:
            Console.WriteLine("\nVocê escolheu opição| " + OpicaoEscolhida + "\nAté mais!");
            break;
        default: 
            Console.WriteLine("\nErro nada digiado"); 
            break;
    }
}
    
    void RegistrarBanda()
    {
        Console.WriteLine("\nDigite o nome da Banda:");
            string nomeBanda=  Console.ReadLine()!;
        
        //ListaBandas.Add(nomeBanda);
        BandasRegistradas.Add(nomeBanda, new List<int>());
        
        Console.WriteLine($"A banda {nomeBanda}, foi registrada com sucesso.");
        Thread.Sleep(1000);

    OpçoesMenu();
    }

    void MostrarLista()
    {
    /*     
        for(int i = 0; i < ListaBandas.Count ; i++)
        {
        Console.WriteLine($"Bandas {ListaBandas[i]}");
        }
    */
      foreach (string banda in BandasRegistradas.Keys)
      {
        Console.WriteLine($"Banda: {banda}");
     }

      Console.WriteLine("Digite tecla para sair da lista.");
      Console.ReadKey();
      Console.Clear();

      OpçoesMenu() ;
    }

    void titulo(string titulo)
    {
    Console.Clear() ;
    int quantidadeDeLetras = titulo.Length;
     string asteristicos = string.Empty.PadLeft(quantidadeDeLetras, '*'); //revisar depois 

      Console.WriteLine(asteristicos);
      Console.WriteLine(titulo);
      Console.WriteLine(asteristicos, "\n");
    }

    void AvaliarUmaBanda()
    {
        Console.Clear();
        titulo("Avaliar banda");

        Console.Write("Digite nome da banda para avaliar:");
        string nomeDaBanda = Console.ReadLine()!;
        if (BandasRegistradas.ContainsKey(nomeDaBanda)) 
        {
            Console.Write($"Qual nota você daria para {nomeDaBanda} ?:");
            int nota = int.Parse(Console.ReadLine()!);
            BandasRegistradas[nomeDaBanda].Add(nota);
            Console.WriteLine($"Você deu a nota = {nota} para Banda {nomeDaBanda}");
            Thread.Sleep(4000);
            Console.Clear();
        OpçoesMenu();

        }
        else
        {
        Console.WriteLine($"\n{nomeDaBanda} não existe!!!");
        Console.WriteLine("Digite uma tecla para sair: ");
        Console.ReadKey();
        Console.Clear();
        OpçoesMenu();
        }
    }

    void MediaDasBandas()
    {
        Console.Clear();
        titulo("Media das Bandas");

        Console.Write("Qual banda você deseja visualizar a nota:");
    string nomeDaBanda = Console.ReadLine()!;
    if (BandasRegistradas.ContainsKey(nomeDaBanda))
    {
        BandasRegistradas.TryGetValue(nomeDaBanda, out var nota);

        int soma = 0;
        foreach (int valor in nota)
        {
            soma += valor;
        }

        double media = (double)soma / nota.Count;

        Console.WriteLine($"A media  da Banda {nomeDaBanda} é: {media}");
        Thread.Sleep(4000);
        Console.Clear();
        OpçoesMenu();
    }
    else
    {
        Console.WriteLine($"\n{nomeDaBanda} não existe!!!");
        Console.WriteLine("Digite uma tecla para sair: ");
        Console.ReadKey();
        Console.Clear();
        OpçoesMenu();
    }
}

ExibirMensagemDeBoasVindas();
OpçoesMenu();