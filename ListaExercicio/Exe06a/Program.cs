//1 - Criar um vetor para receber os valores aleatórios
//2 - Percorrer o vetor com um laço de repetição
//3 - Preencher cada posição com um valor aleatório
//4 - Imprimir o vetor com valores aleatórios

int tamanho = 100;
int[] vetor = new int[tamanho];

Random random = new Random();
for (int i = 0; i < vetor.Length; i++)
{
    vetor[i] = random.Next(1000);
}

for (int i = 0; i < vetor.Length; i++)
{
    Console.Write(vetor[i] + " ");
}

//5 - Percorrer o vetor com um laço de repetição
//6 - Comparar a posição atual com a próxima
//7 - Trocar os valores entre a posição atual e a próxima
//8 - Imprimir o vetor com valores ordenados

bool troca = false;
do
{
    troca = false;
    for (int i = 0; i < vetor.Length - 1; i++)
    {        
        int atual = vetor[i];
        int proxima = vetor[i + 1];
        if (atual > proxima)
        {
            int auxiliar = vetor[i];
            vetor[i] = vetor[i + 1];
            vetor[i + 1] = auxiliar;
            troca = true;
        }
    }
} while (troca);

Console.WriteLine("\n");
for (int i = 0; i < vetor.Length; i++)
{
    Console.Write(vetor[i] + " ");
}