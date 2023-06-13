﻿class Program
{

    // METODO QUE CONTA QUANTAS LINHAS TEM O MAPA INFORMADO
    public static int contLinhas(string x)
    {
        int linhas = 0;

        for (int i = 0; i <= x.Length - 1; i++)
        {

            if (x[i] == '\n')
            {
                linhas++;

            }
        }
        return linhas + 1;
    }

    //METODO QUE CONTA QUANTAS COLUNAS TEM O MATA INFORMADO
    public static int contColunas(string x)
    {
        int colunas = 0;

        for (int i = 0; i <= x.Length - 1; i++)
        {
            if (x[i] != '\n')
            {
                colunas++;

            }
            else
            {
                break;
            }
        }
        return colunas + 1;
    }

    //METODO QUE CONVERTE A STRING COM O CONTEUDO DO MAPA EM UMA MATRIZ
    public static char[,] MapaMatriz(int l, int c, string content)
    {
        char[,] mapa = new char[l, c];

        int index = 0;
        for (int i = 0; i < l; i++)
        {
            for (int j = 0; j < c; j++)
            {
                mapa[i, j] = content[index++];
            }
        }

        return mapa;
    }

    // METODO QUE VERIFICA SE A ENTRADA É UMA BOMBA 💣
    public static bool vrfderrota(char[,] matriz, int a, int b)
    {
        bool derrota = false;

        if (matriz[a, b] == 'B')
        {
            derrota = true;
        }

        return derrota;
    }

    // METODO QUE CRIA UM MAPA COBERTO
    public static char[,] mapacoberto(int a, int b)
    {

        char[,] mapaX = new char[a, b];

        for (int i = 0; i < a; i++)
        {
            for (int j = 0; j < b; j++)
            {
                mapaX[i, j] = 'X';
            }
        }

        return mapaX;

    }

    //METODO QUE REVELA AS POSIÇÕES ADJCENTES 
    public static char[,] revelamapa(char[,] m1, char[,] m2, int a, int b)
    {
        int linhas = m1.GetLength(0);
        int colunas = m1.GetLength(1);

        if (a >= 0 && a < linhas && b >= 0 && b < colunas)
        {
            m1[a, b] = m2[a, b];

            // Verificações para as posições acima e abaixo
            if (a - 1 >= 0)
                m1[a - 1, b] = m2[a - 1, b];
            if (a + 1 < linhas)
                m1[a + 1, b] = m2[a + 1, b];

            // Verificações para as posições à esquerda e à direita
            if (b - 1 >= 0)
                m1[a, b - 1] = m2[a, b - 1];
            if (b + 1 < colunas)
                m1[a, b + 1] = m2[a, b + 1];

            // Verificações para as diagonais superiores
            if (a - 1 >= 0 && b - 1 >= 0)
                m1[a - 1, b - 1] = m2[a - 1, b - 1];
            if (a - 1 >= 0 && b + 1 < colunas)
                m1[a - 1, b + 1] = m2[a - 1, b + 1];

            // Verificações para as diagonais inferiores
            if (a + 1 < linhas && b - 1 >= 0)
                m1[a + 1, b - 1] = m2[a + 1, b - 1];
            if (a + 1 < linhas && b + 1 < colunas)
                m1[a + 1, b + 1] = m2[a + 1, b + 1];
        }

        return m1;
    }

    // METODO QUE PRINTA UM MAPA COBERTO
    public static void printamapaCoberto(int a, int b)
    {
        Console.Write("    A B C D E F G H I\n");
        int cont = 1;
        char[,] m = new char[a, b];
        for (int i = 0; i < a; i++)
        {
            if (cont > 9)
            {
                Console.Write(cont++ + "- ");
            }
            else
                Console.Write(cont++ + " - ");
            for (int j = 0; j < b; j++)
            {
                m[i, j] = 'X';
                Console.Write(m[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }



    static void Main()
    {

        // VARIAVEL QUE RECEBERA DO USUÁRIO O LOCAL ONDE ESTA O MAPA 

        // Console.WriteLine("Digite o caminho do arquivo mapa: ");
        string caminho = @"C:\mapasteste\mapa.txt";



        try
        {
            string conteudo = File.ReadAllText(caminho);
            conteudo = conteudo.Replace(" ", "");       // ARMAZENA TODO O TEXTO DO TXT EM UMA STRING, LOGO DEPOIS RETIRA TODO O ESPAÇO VAZIO


            int linhas = contLinhas(conteudo);
            int colunas = contLinhas(conteudo);

            string mapavet = conteudo.Replace("\n", "").Replace("\r", "");
            char[,] mapaGabarito = MapaMatriz(linhas, colunas, mapavet); // ARMAZENA TODO O CONTEUDO NOVAMENTE EM UMA STRING MAS SEM CONTABILIZAR AS QUEBRAS DE LINHA E DPS EM UMA MATRIZ
            char[,] mapaX = mapacoberto(linhas, colunas); // RECEBE UM MAPA COBERTO



            // VARIAVEIS QUE RECEBEM A COORDENADA DIGITADA
            int linhap;
            int colunap;

            printamapaCoberto(linhas, colunas);

            bool wl = true;


            while (wl == true)
            {


                Console.WriteLine("Digite a linha: ");
                linhap = int.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("Digite a coluna: ");
                colunap = int.Parse(Console.ReadLine()) - 1;
                Console.WriteLine();

                bool verifica = vrfderrota(mapaGabarito, linhap, colunap);

                char[,] campo = revelamapa(mapaX, mapaGabarito, linhap, colunap);

                if (verifica == true)
                {
                    wl = false;
                    Console.Write("    A B C D E F G H I\n");
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
                    Console.WriteLine();
                    Console.Write("VOCÊ PERDEU!");

                }
                else
                {
                    Console.Write("    A B C D E F G H I\n");
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
