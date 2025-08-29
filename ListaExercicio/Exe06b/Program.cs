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

//Ordenar o vetor com uma função da linguagem
Array.Sort(vetor);

Console.WriteLine("\n");
for (int i = 0; i < vetor.Length; i++)
{
    Console.Write(vetor[i] + " ");
}