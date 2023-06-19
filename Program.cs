class Program
{
    // METODO QUE VERIFICA DERROTA
    public static bool vrfderrota(char[,] matriz, int a, int b)


    {
        bool derrota = false;

        if (matriz[a, b] == 'B')
        {
            derrota = true;
        }

        return derrota;
    }

    // METODO VERIFICA VITORIA
    public static bool VerfWin(char[,] matriz, char[,] gabarito, int a, int b)
    {
        bool vitoria = false;
        int contaX = 0;
        int contaB = 0;

        for (int i = 0; i < a; i++)
        {
            for (int j = 0; j < b; j++)
            {
                if (matriz[i, j] == 'X')
                {
                    contaX++;
                }
            }
        }
        for (int i = 0; i < a; i++)
        {
            for (int j = 0; j < b; j++)
            {
                if (gabarito[i, j] == 'B')
                {
                    contaB++;
                }
            }
        }
        if (contaX != contaB)
        {
            vitoria = false;
        }
        else
            vitoria = true;

        return vitoria;
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
    public static char[,] RevelaMapa(char[,] m1, char[,] m2, int a, int b, int l, int c)
    {
        int linhas = l;
        int colunas = c;

        if (a >= 0 && a < linhas && b >= 0 && b < colunas)
        {
            m1[a, b] = m2[a, b]; // m2 = mapa com X e m1 = gabarito 

            // Verificações para as posições acima e abaixo
            if (a - 1 >= 0)
            {
                m1[a - 1, b] = m2[a - 1, b];
                if (m2[a - 1, b] == 'B')
                {
                    m1[a - 1, b] = 'X';
                }
            }
            if (a + 1 < linhas)
            {
                m1[a + 1, b] = m2[a + 1, b];
                if (m2[a + 1, b] == 'B')
                {
                    m1[a + 1, b] = 'X';
                }
            }
            // Verificações para as posições à esquerda e à direita

            if (b - 1 >= 0) //esquerda
            {
                m1[a, b - 1] = m2[a, b - 1];
                if (m2[a, b - 1] == 'B')
                {
                    m1[a, b - 1] = 'X';
                }
            }
            if (b + 1 < colunas) //DIREITA 
            {
                m1[a, b + 1] = m2[a, b + 1];
                if (m2[a, b + 1] == 'B')
                {
                    m1[a, b + 1] = 'X';
                }
            }
            // Verificações para as diagonais superiores
            if (a - 1 >= 0 && b - 1 >= 0)
            {
                m1[a - 1, b - 1] = m2[a - 1, b - 1];
                if (m2[a - 1, b - 1] == 'B')
                {
                    m1[a - 1, b - 1] = 'X';
                }
            }
            if (a - 1 >= 0 && b + 1 < colunas)
            {
                m1[a - 1, b + 1] = m2[a - 1, b + 1];
                if (m2[a - 1, b + 1] == 'B')
                {
                    m1[a - 1, b + 1] = 'X';
                }
            }
            // Verificações para as diagonais inferiores
            if (a + 1 < linhas && b - 1 >= 0)
            {
                m1[a + 1, b - 1] = m2[a + 1, b - 1];
                if (m2[a + 1, b - 1] == 'B')
                {
                    m1[a + 1, b - 1] = 'X';
                }
            }
            if (a + 1 < linhas && b + 1 < colunas)
            {
                m1[a + 1, b + 1] = m2[a + 1, b + 1];
                if (m2[a + 1, b + 1] == 'B')
                {
                    m1[a + 1, b + 1] = 'X';
                }
            }
        }

        return m1;
    }

    // METODO QUE PRINTA UM MAPA COBERTO
    public static void printamapaCoberto(int a, int b)
    {
        int cont = 1;
        char[,] m = new char[a, b];
        int[] indicaColunas = new int[b];
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
        Console.Write("    ");
        for (int i = 0; i < b; i++)
        {
            Console.Write(indicaColunas[i] + " ");
        }
        Console.WriteLine();
    }


    // METODO QUE CRIA UMA MATRIZ COM O GABARITO 

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

            Console.WriteLine(+linhas + " Linhas, " + colunas + " colunas e " + bomba + " bombas." + "\n");
            printamapaCoberto(linhas, colunas);

            // WHILE QUE RODA O MAPA ATE A DERROTA OU VITORIA DO JOGADOR 

            bool wl = true;

            char[,] mapaX = mapacoberto(linhas, colunas);


        }

        catch (FileNotFoundException) // VERIFICA SE O CAMINHO INFORMADO EXISTE 
        {
            Console.WriteLine("Arquivo não encontrado! \nLembre-se de adicionar o caminho do mapa desejado dessa forma:  ex:'C:\\mapasexemplos\\mapa1.txt' ");
        }

    }
}
