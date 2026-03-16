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

        System.Console.WriteLine(palavraAleatoria);

        return palavraAleatoria;
    }

    public static void Main(string[] args)
    {
        while (true)
        {
            System.Console.WriteLine("--------------------");
            System.Console.WriteLine("JOGO DA FORCA");
            System.Console.WriteLine("--------------------");

            string pavraAleatoria = EscolherPalavraAleatoria();
            char[] letrasAcertadas = new char[pavraAleatoria.Length];
            for (int caractere = 0; caractere < letrasAcertadas.Length; caractere++)
            {
                letrasAcertadas[caractere] = '_';
            }

            bool jogadorAcertouPalavra = false;

            while (jogadorAcertouPalavra == false)
            {

                System.Console.WriteLine(letrasAcertadas);

                System.Console.Write("Digite uma letra:");
                string? strLetra = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(strLetra))
                {
                    System.Console.WriteLine("Digite um caractere valido");
                    Console.ReadKey();
                    continue;
                }

                char letraChute = Convert.ToChar(strLetra.ToUpper());

                for (int contador = 0; contador < pavraAleatoria.Length; contador++)
                {
                    char letraAtual = pavraAleatoria[contador];

                    if (letraChute == letraAtual)
                    {
                        letrasAcertadas[contador] = letraAtual;
                    }
                }
                jogadorAcertouPalavra = pavraAleatoria == string.Join("", letrasAcertadas);
            }

            System.Console.Write("Deseja continuar?(s/N)");
            string? opcaoContinar = Console.ReadLine()?.ToUpper();

            if (opcaoContinar != "S")
            {
                break;
            }
        }

    }

}

