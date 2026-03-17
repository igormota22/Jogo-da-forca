using System.Security.Cryptography;

class Program
{

    /*
    Requisitos
1. Ao iniciar o jogo, deve ser selecionada uma palavra aleatória à partir de uma lista.
2. O jogador poderá chutar a palavra secreta letra por letra, cada letra certa deverá ser apresentada,
assim como as letras erradas.
3. O jogador poderá cometer até cinco erros, caso erre pela quinta vez, ou acerte a palavra a partida
acaba.
4. Deve-se apresentar um desenho da forca sendo atualizado a cada erro.
    */

    public static void Main(string[] args)
    {
        while (true)
        {
            ExibirCabecalho();

            string palavraAleatoria = EscolherPalavraAleatoria();
            char[] letrasAcertadas = PreencherLetrasAcertadas(palavraAleatoria);
            ExecutarTentativa(letrasAcertadas, palavraAleatoria);

            if (!JogadorDesejaContinuar())
            {
                break;
            }

        }

    }

    static void ExibirCabecalho()
    {
        System.Console.WriteLine("--------------------");
        System.Console.WriteLine("JOGO DA FORCA");
        System.Console.WriteLine("--------------------");
    }

    static string EscolherPalavraAleatoria()
    {
        string[] palavras = [
          "ABACATE",
            "ABACAXI",
            "ACEROLA",
            "AÇAÍ",
            "ARAÇÁ",
            "ABACATE",
            "BACABA",
            "BACURI",
            "BANANA",
            "CAJÁ",
            "CAJU",
            "CARAMBOLA",
            "CUPUAÇU",
            "GRAVIOLA",
            "GOIABA",
            "JABUTICABA",
            "JENIPAPO",
            "MAÇÃ",
            "MANGABA",
            "MANGA",
            "MARACUJÁ",
            "MURICI",
            "PEQUI",
            "PITANGA",
            "PITAYA",
            "SAPOTI",
            "TANGERINA",
            "UMBU",
            "UVA",
            "UVAIA"
      ];

        int indiceAleatorio = RandomNumberGenerator.GetInt32(palavras.Length);

        string palavraAleatoria = palavras[indiceAleatorio];

        return palavraAleatoria;
    }

    static char[] PreencherLetrasAcertadas(string palavraAleatoria)
    {
        char[] letrasAcertadas = new char[palavraAleatoria.Length];
        for (int caractere = 0; caractere < letrasAcertadas.Length; caractere++)
        {
            letrasAcertadas[caractere] = '_';
        }
        return letrasAcertadas;
    }

    static void ExecutarTentativa(char[] letrasAcertadas, string palavraAleatoria)
    {
        bool jogadorAcertouPalavra = false;
        bool jogadorPerdeu = false;

        int erros = 0;



        while (jogadorPerdeu == false && jogadorAcertouPalavra == false)
        {
            DesenharForca(erros);

            System.Console.WriteLine(letrasAcertadas);
            System.Console.WriteLine("Tentativas Erradas: " + erros);

            System.Console.Write("Digite uma letra:");
            string? strLetra = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(strLetra))
            {
                System.Console.WriteLine("Digite um caractere valido");
                Console.ReadKey();
                continue;
            }

            char letraChute = Convert.ToChar(strLetra.ToUpper());

            bool letraFoiEncontrada = false;

            for (int contador = 0; contador < palavraAleatoria.Length; contador++)
            {
                char letraAtual = palavraAleatoria[contador];

                if (letraChute == letraAtual)
                {
                    letrasAcertadas[contador] = letraAtual;
                    letraFoiEncontrada = true;
                }

            }

            if (letraFoiEncontrada == false)
            {
                erros++;
            }

            jogadorAcertouPalavra = palavraAleatoria == string.Join("", letrasAcertadas);
            jogadorPerdeu = erros > 5;
        }

        if (jogadorAcertouPalavra)
        {
            System.Console.WriteLine($"Parabens, a palavra secreta era: {palavraAleatoria}.Voce ganhou!");
        }
        else
        {
            System.Console.WriteLine($"Que pena, a palavra secreta era: {palavraAleatoria}.Tente novamente");
        }
    }

    static void DesenharForca(int erros)
    {

        if (erros == 0)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |               ");
            Console.WriteLine(@" |               ");
            Console.WriteLine(@" |                ");
            Console.WriteLine(@" |              ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        else if (erros == 1)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |               ");
            Console.WriteLine(@" |                 ");
            Console.WriteLine(@" |              ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        else if (erros == 2)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |        |       ");
            Console.WriteLine(@" |                 ");
            Console.WriteLine(@" |               ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        else if (erros == 3)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |         |      ");
            Console.WriteLine(@" |         |        ");
            Console.WriteLine(@" |                ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        else if (erros == 4)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |        /|\       ");
            Console.WriteLine(@" |         |        ");
            Console.WriteLine(@" |                ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
        else if (erros == 5)
        {
            Console.WriteLine(@" ___________        ");
            Console.WriteLine(@" |/        |        ");
            Console.WriteLine(@" |         o        ");
            Console.WriteLine(@" |        /|\       ");
            Console.WriteLine(@" |         |        ");
            Console.WriteLine(@" |        / \       ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@" |                  ");
            Console.WriteLine(@"_|____              ");
        }
    }

    static bool JogadorDesejaContinuar()
    {
        System.Console.Write("Deseja continuar?(s/N)");
        string? opcaoContinar = Console.ReadLine()?.ToUpper();

        if (opcaoContinar != "S")
        {
            return false;
        }
        return true;

    }


}

