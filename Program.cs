// O trabalho prático consiste na implementação de um jogo, Campo Minado. O objetivo trata-se  de ler um arquivo de texto onde encontram-se as 
// informações sobre a quantidade de linhas, colunas e bombas. Após isso, construir um mapa correspondente às informações e fazer com que o usuário 
// consiga jogá-lo ao inserir a linha e coluna desejada . 

//Guilherme Henrique, Jean Carlo, Vinícius Morais, Lucca Cenisio 
class Program
{
    static void Main()
    {

        // VARIAVEL QUE RECEBERA DO USUÁRIO O LOCAL ONDE ESTA O MAPA 
        Console.WriteLine("Digite o caminho do arquivo:");
        string caminho = Console.ReadLine();

        int linhas = 0, colunas = 0, bombas = 0;
        try
        {
            using (StreamReader sr = new StreamReader(caminho))
            {
                string conteudo = sr.ReadToEnd(); // Lê todo o conteúdo do arquivo

                // Separar o conteúdo em partes usando espaços como delimitadores
                string[] partes = conteudo.Split(' ');

                // Percorre o for para encontrar os números correspondentes a linhas, colunas e bombas

                for (int i = 0; i < partes.Length - 2; i++)
                {
                    // Tenta converter as partes em inteiros 
                    if (int.TryParse(partes[i], out linhas) && int.TryParse(partes[i + 2], out colunas) && int.TryParse(partes[i + 4], out bombas))
                    {
                        break;
                    }
                }
            }


            Console.WriteLine(+linhas + " Linhas, " + colunas + " colunas e " + bombas + " bombas.");
            Console.WriteLine();
            Metodos.PrintaMapaCoberto(linhas, colunas);

            // WHILE QUE RODA O MAPA ATE A DERROTA OU VITORIA DO JOGADOR 

            bool wl = true;

            char[,] mapaX = Metodos.MapaCoberto(linhas, colunas);
            char[,] mapaGabarito = Metodos.Gabarito(linhas, colunas, bombas);


            while (wl == true)
            {
                // RECEBE AS COORDENADAS
                Console.WriteLine();
                Console.WriteLine("Digite a linha: ");
                int linhap = int.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("Digite a coluna: ");
                int colunap = int.Parse(Console.ReadLine()) - 1;
                Console.WriteLine();


                //RECEBE OS METODOS DE VITORIA, DERROTA E DE ATUALIZAÇÃO DO MAPA
                bool verificaDerrota = Metodos.VerificaDerrota(mapaGabarito, linhap, colunap);
                char[,] campo = Metodos.RevelaMapa(mapaX, mapaGabarito, linhap, colunap, linhas, colunas);
                bool verificaWin = Metodos.VerificafWin(campo, mapaGabarito, linhas, colunas);
                int[] indicaColunas = new int[colunas];

                if (verificaDerrota == true) // VERIFICA SE O USUARIO PERDEU E ENCERRA O WHILE
                {
                    wl = false;
                    Console.WriteLine();
                    int cont = 1;
                    for (int g = 0; g < linhas; g++)
                    {
                        if (cont > 9)
                        {
                            Console.Write(cont++ + "- ");
                        }
                        else
                            Console.Write(cont++ + " - ");
                        for (int a = 0; a < colunas; a++)
                        {
                            Console.Write(campo[g, a] + " ");
                        }
                        Console.WriteLine();
                    }
                    Console.Write("\n" + "    ");
                    for (int i = 0; i < colunas; i++)
                    {
                        indicaColunas[i] = i + 1;
                        Console.Write(indicaColunas[i] + " ");
                    }
                    Console.WriteLine("\n");
                    Console.WriteLine();
                    Console.Write("VOCÊ PERDEU!");

                }
                else if (verificaWin == true) // VERIFICA SE O USUARIO GANHOU E ENCERRA O WHILE
                {
                    int cont = 1;
                    for (int g = 0; g < linhas; g++)
                    {
                        if (cont > 9)
                        {
                            Console.Write(cont++ + "- ");
                        }
                        else
                            Console.Write(cont++ + " - ");
                        for (int a = 0; a < colunas; a++)
                        {
                            Console.Write(campo[g, a] + " ");
                        }
                        Console.WriteLine();
                    }
                    Console.Write("\n" + "    ");
                    for (int i = 0; i < colunas; i++)
                    {
                        indicaColunas[i] = i + 1;
                        Console.Write(indicaColunas[i] + " ");
                    }
                    Console.WriteLine();
                    Console.Write("VOCÊ GANHOU!");
                    break;
                }
                else // PRINTA O MAPA DENTRO DO WHILE ATUALIZANDO DE ACORDO COM AS COODERNADAS DIGITAS 
                {

                    int cont = 1;
                    for (int g = 0; g < linhas; g++)
                    {
                        if (cont > 9)
                        {
                            Console.Write(cont++ + "- ");
                        }
                        else
                            Console.Write(cont++ + " - ");
                        for (int a = 0; a < colunas; a++)
                        {
                            Console.Write(campo[g, a] + " ");
                        }
                        Console.WriteLine();
                    }
                    Console.Write("\n" + "    ");
                    for (int i = 0; i < colunas; i++)
                    {
                        indicaColunas[i] = i + 1;
                        Console.Write(indicaColunas[i] + " ");
                    }
                    Console.WriteLine();
                }

            }

        }

        catch (FileNotFoundException) // VERIFICA SE O CAMINHO INFORMADO EXISTE 
        {
            Console.WriteLine("Arquivo não encontrado! \nLembre-se de adicionar o caminho do mapa desejado dessa forma:  ex:'C:\\mapasexemplos\\mapa1.txt' ");
        }

    }
}
