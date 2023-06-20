class Metodos
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

    //METODO QUE PREENCHE A MATRIZ
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
}