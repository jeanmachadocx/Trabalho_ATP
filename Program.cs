class Program
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

        for (int i = 0; i < x.Length; i++)
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

        return colunas - 1;
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
                if (index < content.Length)
                    mapa[i, j] = content[index++];
                else
                    mapa[i, j] = ' ';
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


    public static bool VerfWin(char[,] matriz, int a, int b)
    {
        bool vitoria = false;
        int contaX = 0;

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
        if (contaX > 0)
        {
            vitoria = false;
        }
        else
            vitoria = true;

        return vitoria;
    }

    static void Main()
    {

        // VARIAVEL QUE RECEBERA DO USUÁRIO O LOCAL ONDE ESTA O MAPA 

        // Console.WriteLine("Digite o caminho do arquivo mapa: ");
        string caminho = @"C:\mapasteste\mapa3.txt";



        try
        {
            string conteudo = File.ReadAllText(caminho);
            conteudo = conteudo.Replace(" ", "");       // ARMAZENA TODO O TEXTO DO TXT EM UMA STRING, LOGO DEPOIS RETIRA TODO O ESPAÇO VAZIO


            int linhas = contLinhas(conteudo);
            int colunas = contColunas(conteudo);

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
                // RECEBE AS COORDENADAS
                Console.WriteLine("Digite a linha: ");
                linhap = int.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("Digite a coluna: ");
                colunap = int.Parse(Console.ReadLine()) - 1;
                Console.WriteLine();


                //RECEBE OS METODOS DE VITORIA, DERROTA E DE ATUALIZAÇÃO DO MAPA
                bool verificaDerrota = vrfderrota(mapaGabarito, linhap, colunap);
                char[,] campo = RevelaMapa(mapaX, mapaGabarito, linhap, colunap, linhas, colunas);
                bool verificaWin = VerfWin(campo, linhas, colunas);

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
