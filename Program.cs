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


        if (a >= 0 && a < l && b >= 0 && b < c)
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
            if (a + 1 < l)
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
            if (b + 1 < c) //DIREITA 
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
            if (a - 1 >= 0 && b + 1 < c)
            {
                m1[a - 1, b + 1] = m2[a - 1, b + 1];
                if (m2[a - 1, b + 1] == 'B')
                {
                    m1[a - 1, b + 1] = 'X';
                }
            }
            // Verificações para as diagonais inferiores
            if (a + 1 < l && b - 1 >= 0)
            {
                m1[a + 1, b - 1] = m2[a + 1, b - 1];
                if (m2[a + 1, b - 1] == 'B')
                {
                    m1[a + 1, b - 1] = 'X';
                }
            }
            if (a + 1 < l && b + 1 < c)
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
        Console.Write("\n" + "    ");
        for (int i = 0; i < b; i++)
        {
            indicaColunas[i] = i + 1;
            Console.Write(indicaColunas[i] + " ");
        }
        Console.WriteLine("\n");
    }

    //METODO QUE CRIA UMA MATRIZ COM O GABARITO 
    public static char[,] Gabarito(int l, int c, int b)
    {
        char[,] mapa = new char[l, c];

        Random rd = new Random();

        for (int i = 0; i < b; i++)
        {
            int linha = rd.Next(l);
            int coluna = rd.Next(c);

            if (mapa[linha, coluna] != 'B')
            {
                mapa[linha, coluna] = 'B';
            }
            else
            {
                i--;
            }
        }

        for (int i = 0; i < l; i++)
        {
            for (int j = 0; j < c; j++)
            {
                int countB = 0; // Variável de contagem

                if (mapa[i, j] != 'B')
                {
                    // Verificações para as posições acima e abaixo
                    if (i - 1 >= 0)
                    {
                        if (mapa[i - 1, j] == 'B')
                        {
                            countB++;
                        }
                    }
                    if (i + 1 < l)
                    {
                        if (mapa[i + 1, j] == 'B')
                        {
                            countB++;
                        }
                    }

                    // Verificações para as posições à esquerda e à direita
                    if (j - 1 >= 0)
                    {
                        if (mapa[i, j - 1] == 'B')
                        {
                            countB++;
                        }
                    }
                    if (j + 1 < c)
                    {
                        if (mapa[i, j + 1] == 'B')
                        {
                            countB++;
                        }
                    }
                    // Verificações para as diagonais superiores
                    if (i - 1 >= 0 && j - 1 >= 0)
                    {
                        if (mapa[i - 1, j - 1] == 'B')
                        {
                            countB++;
                        }
                    }
                    if (i - 1 >= 0 && j + 1 < c)
                    {
                        if (mapa[i - 1, j + 1] == 'B')
                        {
                            countB++;
                        }
                    }
                    // Verificações para as diagonais inferiores
                    if (i + 1 < l && j - 1 >= 0)
                    {
                        if (mapa[i + 1, j - 1] == 'B')
                        {
                            countB++;
                        }
                    }
                    if (i + 1 < l && j + 1 < c)
                    {
                        if (mapa[i + 1, j + 1] == 'B')
                        {
                            countB++;
                        }
                    }

                    mapa[i, j] = countB.ToString()[0]; // Atualiza a posição com a quantidade de letras 'B' adjacentes
                }
            }
        }

        return mapa;
    }



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
            printamapaCoberto(linhas, colunas);

            // WHILE QUE RODA O MAPA ATE A DERROTA OU VITORIA DO JOGADOR 

            bool wl = true;

            char[,] mapaX = mapacoberto(linhas, colunas);
            char[,] mapaGabarito = Gabarito(linhas, colunas, bomba);


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
                bool verificaDerrota = vrfderrota(mapaGabarito, linhap, colunap);
                char[,] campo = RevelaMapa(mapaX, mapaGabarito, linhap, colunap, linhas, colunas);
                bool verificaWin = VerfWin(campo, mapaGabarito, linhas, colunas);
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