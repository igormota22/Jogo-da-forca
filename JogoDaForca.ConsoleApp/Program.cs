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

            string palavraAleatoria = EscolherPalavraAleatoriaEDificuldade();
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

    static string EscolherPalavraAleatoriaEDificuldade()
    {
        System.Console.WriteLine("--------------------");
        System.Console.WriteLine("1 - Frutas");
        System.Console.WriteLine("2 - Animais");
        System.Console.WriteLine("3 - Paises");
        System.Console.WriteLine("--------------------");
        System.Console.Write("Escolha a dificuldade:");
        string? opcaoDificuldade = Console.ReadLine();

        string[] palavras = new string[0];

        switch (opcaoDificuldade)
        {
            case "1":

                palavras = [
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
break;
case "2":
 palavras = [
"ÁGUIA",
"CACHORRO",
"CAMELO",
"CANTEIRO",
"CAVALO",
"COBRA",
"COELHO",
"CORUJA",
"ELEFANTE",
"FALA",
"GATO",
"GIRAFA",
"GORILA",
"HAMSTER",
"HIPOPÓTAMO",
"JACARÉ",
"LEÃO",
"LOBO",
"MACACO",
"MORCEGO",
"ONÇA",
"PATO",
"PEIXE",
"PORCO",
"RATO",
"SAPO",
"TARTARUGA",
"TIGRE",
"URSO",
"ZEBRA"
];
break;
case "3":
palavras = [
"ÁFRICA DO SUL",
"ALEMANHA",
"AUSTLIA",
"BÉLGICA",
"BRASIL",
"CANADÁ",
"CHINA",
"COREIA DO SUL",
"ESPANHA",
"ESTADOS UNIDOS",
"FRANÇA",
"GRÉCIA",
"HOLANDA",
"ÍNDIA",
"IRLANDA",
"ISRAEL",
"ITÁLIA",
"JAPÃO",
"MARROCOS",
"MÉXICO",
"NORUEGA",
"NOVA ZELÂNDIA",
"POLÔNIA",
"PORTUGAL",
"REINO UNIDO",
"RÚSSIA",
"SUÉCIA",
"SUÍÇA",
"TAILÂNDIA",
"TURQUIA"                    
];
break;
default:
System.Console.WriteLine("Opção invalida");
break;
 }


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

        List<char> letrasErradas = new List<char>();

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

            if(letrasAcertadas.Contains(letraChute) || letrasErradas.Contains(letraChute))
            {
                System.Console.WriteLine("Voce ja chutou essa letra");
                continue;
            }

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
                if (!letrasErradas.Contains(letraChute))
                {
                    letrasErradas.Add(letraChute);
                }
            }

            jogadorAcertouPalavra = palavraAleatoria == string.Join("", letrasAcertadas);
            System.Console.WriteLine("Letras Erradas: " + string.Join(", ", letrasErradas));
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

