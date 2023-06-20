
class Program
{
    static void Main()
    {

        // VARIAVEL QUE RECEBERA DO USUÁRIO O LOCAL ONDE ESTA O MAPA 

        // Console.WriteLine("Digite o caminho do arquivo mapa: ");
        string caminho = @"C:\mapasteste\mapa1.txt";

        int linhas = 0, colunas = 0, bomba = 0;
        try
        {
            // LE O ARQUIVO E ARMAZENA O NUMERO DE LINHAS, COLUNAS E BOMBAS.
            using (StreamReader sr = new StreamReader(caminho))
            {
                int caractere;

                // Lê e exibe cada caractere do arquivo até o final
                while ((caractere = sr.Read()) != -1)
                {
                    char caractereChar = (char)caractere;

                    if (char.IsDigit(caractereChar))
                    {
                        int numero = int.Parse(caractereChar.ToString());

                        if (linhas == 0)
                            linhas = numero;
                        else if (colunas == 0)
                            colunas = numero;
                        else if (bomba == 0)
                            bomba = numero;
                    }
                }
            }

            Console.WriteLine(+linhas + " Linhas, " + colunas + " colunas e " + bomba + " bombas.");
            Console.WriteLine();
            Metodos.printamapaCoberto(linhas, colunas);

            // WHILE QUE RODA O MAPA ATE A DERROTA OU VITORIA DO JOGADOR 

            bool wl = true;

            char[,] mapaX = Metodos.mapacoberto(linhas, colunas);
            char[,] mapaGabarito =  Metodos.Gabarito(linhas, colunas, bomba);


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
                bool verificaDerrota = Metodos.vrfderrota(mapaGabarito, linhap, colunap);
                char[,] campo = Metodos.RevelaMapa(mapaX, mapaGabarito, linhap, colunap, linhas, colunas);
                bool verificaWin = Metodos.VerfWin(campo, mapaGabarito, linhas, colunas);
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
                    Console.Write( "\n" + "    ");
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
