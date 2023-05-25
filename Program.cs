

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

    // METODO QUE PRINTA O MAPA

    public static void printaMapa(char[,] m, int l, int c)
    {
         Console.WriteLine("    A B C D E F G H I");
         int cont = 0;
        for (int i = 0; i < l; i++)
        {
            cont++;
            Console.Write(cont+ " - ");
            for (int j = 0; j < c; j++)
            {
                Console.Write(m [i,j] + " ");
            }
            Console.WriteLine();
        }
         Console.WriteLine("\n");
    }

    // METODO QUE VERIFICA SE A ENTRADA É UMA BOMBA 💣

    public static bool vrfderrota (char [,] matriz ,int a, int b)
    {
        bool derrota = false;

        if( matriz[a,b]== 'B')
        {
            derrota = true;
        }

        return derrota;
    }


    static void Main()
    {

        // VARIAVEL QUE RECEBERA DO USUÁRIO O LOCAL ONDE ESTA O MAPA 

        // Console.WriteLine("Digite o caminho do arquivo mapa: ");
        string caminho = @"C:\mapasteste\mapa2.txt";



        try
        {
            string conteudo = File.ReadAllText(caminho);
            conteudo = conteudo.Replace(" ", "");       // ARMAZENA TODO O TEXTO DO TXT EM UMA STRING, LOGO DEPOIS RETIRA TODO O ESPAÇO VAZIO


            int linhas = contLinhas(conteudo);
            int colunas = contLinhas(conteudo);

            string mapavet = conteudo.Replace("\n", "").Replace("\r", "");  
            char[,] mapa = MapaMatriz(linhas, colunas, mapavet); // ARMAZENA TODO O CONTEUDO NOVAMENTE EM UMA STRING MAS SEM CONTABILIZAR AS QUEBRAS DE LINHA E DPS EM UMA MATRIZ

            Console.WriteLine("Colunas: " + colunas + " Linhas: " + linhas + " Tamanho: " + mapavet.Length + "\n");

            printaMapa(mapa, linhas, colunas);


            int linhap;
            int colunap;

            bool wl = true;

            while ( wl == true)
            {
                Console.Write("Digite as posições: ");
                linhap = int.Parse(Console.ReadLine())+1;
                colunap = int.Parse(Console.ReadLine())+1;

                bool verifica = vrfderrota (mapa, linhap, colunap);

                if (verifica==true)
                {
                    wl =false;
                    Console.Write ("VOCÊ PERDEU!");
                }

            }

        }
        catch (FileNotFoundException) // VERIFICA SE O CAMINHO INFORMADO EXISTE 
        {
            Console.WriteLine("Arquivo não encontrado! \nLembre-se de adicionar o caminho do mapa desejado dessa forma:  ex:'C:\\mapasexemplos\\mapa1.txt' ");
        }

    }
}
