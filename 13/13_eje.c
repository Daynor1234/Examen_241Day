#include "mpi.h"
#include "stdio.h"
#include "string.h"

#define TAM_VECTOR 6
#define LONGITUD_MAX 100

int main(int argc, char* argv[]) {
    int proceso, total_procesos;
    MPI_Init(&argc, &argv);
    MPI_Comm_rank(MPI_COMM_WORLD, &proceso); // Identificador del proceso
    MPI_Comm_size(MPI_COMM_WORLD, &total_procesos); // Número total de procesos

    char cadenas[TAM_VECTOR][LONGITUD_MAX]; // Matriz de cadenas
    int cantidad_elementos = TAM_VECTOR;

    if (proceso == 0) {
        // Inicializar el vector de cadenas
        strcpy(cadenas[0], "elemento_0");
        strcpy(cadenas[1], "elemento_1");
        strcpy(cadenas[2], "elemento_2");
        strcpy(cadenas[3], "elemento_3");
        strcpy(cadenas[4], "elemento_4");
        strcpy(cadenas[5], "elemento_5");

        // Enviar el vector de cadenas a otros procesos
        MPI_Send(&cadenas, TAM_VECTOR * LONGITUD_MAX, MPI_CHAR, 1, 0, MPI_COMM_WORLD);
        MPI_Send(&cadenas, TAM_VECTOR * LONGITUD_MAX, MPI_CHAR, 2, 0, MPI_COMM_WORLD);
    } else if (proceso == 1) {
        // Proceso 1: recibir el vector y mostrar las posiciones pares
        MPI_Recv(&cadenas, TAM_VECTOR * LONGITUD_MAX, MPI_CHAR, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);

        printf("Proceso 1 - Elementos en posiciones pares:\n");
        for (int indice = 0; indice < cantidad_elementos; indice += 2) {
            printf("Posicion %d: %s\n", indice, cadenas[indice]);
        }
    } else if (proceso == 2) {
        // Proceso 2: recibir el vector y mostrar las posiciones impares
        MPI_Recv(&cadenas, TAM_VECTOR * LONGITUD_MAX, MPI_CHAR, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);

        printf("Proceso 2 - Elementos en posiciones impares:\n");
        for (int indice = 1; indice < cantidad_elementos; indice += 2) {
            printf("Posicion %d: %s\n", indice, cadenas[indice]);
        }
    }

    MPI_Finalize();
    return 0;
}

