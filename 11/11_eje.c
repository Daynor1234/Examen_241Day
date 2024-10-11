#include "mpi.h"
#include "stdio.h"
#include "stdlib.h"

#define TAM_VECTOR 10

int main(int argc, char* argv[]) {
    int rango, total_procesos;
    MPI_Init(&argc, &argv);
    MPI_Comm_rank(MPI_COMM_WORLD, &rango);
    MPI_Comm_size(MPI_COMM_WORLD, &total_procesos);

    int vector1[TAM_VECTOR], vector2[TAM_VECTOR], vector_suma[TAM_VECTOR];
    int elementos = TAM_VECTOR;

    if (rango == 0) {
        printf("Inicializando vectores en el proceso %d...\n", rango);
        for (int i = 0; i < TAM_VECTOR; i++) {
            vector1[i] = i + 1;
            vector2[i] = (i + 1) * 2;
        }

        printf("Vector 1:\n");
        for (int i = 0; i < TAM_VECTOR; i++) {
            printf("%d ", vector1[i]);
        }
        printf("\n");

        printf("Vector 2:\n");
        for (int i = 0; i < TAM_VECTOR; i++) {
            printf("%d ", vector2[i]);
        }
        printf("\n");

        // Enviar los vectores a los procesos 1 y 2
        MPI_Send(&vector1, TAM_VECTOR, MPI_INT, 1, 0, MPI_COMM_WORLD);
        MPI_Send(&vector2, TAM_VECTOR, MPI_INT, 1, 0, MPI_COMM_WORLD);

        MPI_Send(&vector1, TAM_VECTOR, MPI_INT, 2, 0, MPI_COMM_WORLD);
        MPI_Send(&vector2, TAM_VECTOR, MPI_INT, 2, 0, MPI_COMM_WORLD);

        // Recibir resultados de los procesos 1 y 2
        int resultado_impares[TAM_VECTOR];
        int resultado_pares[TAM_VECTOR];

        MPI_Recv(&resultado_impares, TAM_VECTOR, MPI_INT, 1, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
        MPI_Recv(&resultado_pares, TAM_VECTOR, MPI_INT, 2, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);

        // Combinar los resultados en el vector final
        for (int i = 0; i < TAM_VECTOR; i++) {
            if (i % 2 == 0) {
                vector_suma[i] = resultado_pares[i];
            } else {
                vector_suma[i] = resultado_impares[i];
            }
        }

        printf("Vector resultado (suma de vector 1 y vector 2):\n");
        for (int i = 0; i < TAM_VECTOR; i++) {
            printf("%d ", vector_suma[i]);
        }
        printf("\n");

    } else if (rango == 1) {
        MPI_Recv(&vector1, TAM_VECTOR, MPI_INT, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
        MPI_Recv(&vector2, TAM_VECTOR, MPI_INT, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);

        int resultado_impares[TAM_VECTOR] = {0};
        for (int i = 1; i < TAM_VECTOR; i += 2) {
            resultado_impares[i] = vector1[i] + vector2[i];
        }

        // Enviar los resultados al proceso maestro
        MPI_Send(&resultado_impares, TAM_VECTOR, MPI_INT, 0, 0, MPI_COMM_WORLD);

    } else if (rango == 2) {
        MPI_Recv(&vector1, TAM_VECTOR, MPI_INT, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
        MPI_Recv(&vector2, TAM_VECTOR, MPI_INT, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);

        int resultado_pares[TAM_VECTOR] = {0};
        for (int i = 0; i < TAM_VECTOR; i += 2) {
            resultado_pares[i] = vector1[i] + vector2[i];
        }

        // Enviar los resultados al proceso maestro
        MPI_Send(&resultado_pares, TAM_VECTOR, MPI_INT, 0, 0, MPI_COMM_WORLD);
    }

    MPI_Finalize();
    return 0;
}





