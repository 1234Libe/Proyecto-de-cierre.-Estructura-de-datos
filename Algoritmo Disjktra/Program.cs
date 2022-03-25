using System;


   
        class Dijkstra
        {

            private static int DistanciaMinima(int[] distancia, bool[] rutacorta, int Conteovertices)
            {
                int min = int.MaxValue;
                int minIndex = 0;

                for (int v = 0; v < Conteovertices; ++v)
                {
                    if (rutacorta[v] == false && distancia[v] <= min)
                    {
                        min = distancia[v];
                        minIndex = v;
                    }
                }

                return minIndex;
            }

            private static void Imprimir(int[] distancia, int Conteovertices)
            {
                Console.WriteLine("Distancia del vertice!"); 

                for (int i = 0; i < Conteovertices; ++i)
                    Console.WriteLine("{0}\t  {1}", i, distancia[i]);
            }

            public static void DijkstraAlgo(int[,] grafico, int source, int Conteovertices)
            {
                int[] distancia = new int[Conteovertices];
                bool[] rutacorta = new bool[Conteovertices];

                for (int i = 0; i < Conteovertices; ++i)
                {
                    distancia[i] = int.MaxValue;
                    rutacorta[i] = false;
                }

                distancia[source] = 0;

                for (int count = 0; count < Conteovertices - 1; ++count)
                {
                    int u = DistanciaMinima(distancia, rutacorta, Conteovertices);
                    rutacorta[u] = true;

                    for (int v = 0; v < Conteovertices; ++v)
                        if (!rutacorta[v] && Convert.ToBoolean(grafico[u, v]) && distancia[u] != int.MaxValue && distancia[u] + grafico[u, v] < distancia[v])
                            distancia[v] = distancia[u] + grafico[u, v];
                }

                Imprimir(distancia, Conteovertices);
            }

            static void Main(string[] args)
            {
                int[,] grafico =  {
                          { 0, 6, 0, 0, 0, 0, 0, 9, 0 },
                          { 6, 0, 9, 0, 0, 0, 0, 11, 0 },
                          { 0, 9, 0, 5, 0, 6, 0, 0, 2 },
                          { 0, 0, 5, 0, 9, 16, 0, 0, 0 },
                          { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                          { 0, 0, 6, 0, 10, 0, 2, 0, 0 },
                          { 0, 0, 0, 16, 0, 2, 0, 1, 6 },
                          { 9, 11, 0, 0, 0, 0, 1, 0, 5 },
                          { 0, 0, 2, 0, 0, 0, 6, 5, 0 }
                            };

                DijkstraAlgo(grafico, 0, 9);
            }
        }
    

    

