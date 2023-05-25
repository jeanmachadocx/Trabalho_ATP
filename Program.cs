

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
         Console.WriteLine("\n");
        for (int i = 0; i < l; i++)
        {
            for (int j = 0; j < c; j++)
            {
                
                Console.Write(m [i,j] + " ");
            }
            Console.WriteLine();
        }
         Console.WriteLine("\n");
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

            string mapavet = conteudo.Replace("\n", "").Replace("\r", "");  // ARMAZENA TODO O CONTEUDO NOVAMENTE EM UMA STRING MAS SEM CONTABILIZAR AS QUEBRAS DE LINHA
  

            

            char[,] mapa = MapaMatriz(linhas, colunas, mapavet);

            printaMapa(mapa, linhas, colunas);

            Console.WriteLine("Colunas: " + colunas + "\nLinhas: " + linhas + "\nTamanho: " + mapavet.Length);


        }
        catch (FileNotFoundException) // VERIFICA SE O CAMINHO INFORMADO EXISTE 
        {
            Console.WriteLine("Arquivo não encontrado! \nLembre de adicionar o caminho do mapa desejado dessa forma:  ex:'C:\\mapasexemplos\\mapa1.txt' ");
        }

    }
}
