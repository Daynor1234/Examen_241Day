#include "mpi.h"
#include "stdio.h"
#include "stdlib.h"

#define N 4


void print_matrix(int matrix[N][N], int rows, int cols) {
    for (int i = 0; i < rows; i++) {
        for (int j = 0; j < cols; j++) {
            printf("%d ", matrix[i][j]);
        }
        printf("\n");
    }
}


int main(int argc, char *argv[]) {
    int rank, size;
    
    
    MPI_Init(&argc, &argv);
    MPI_Comm_rank(MPI_COMM_WORLD, &rank);  
    MPI_Comm_size(MPI_COMM_WORLD, &size);  

    int A[N][N], B[N][N], C[N][N];  
    int rows_per_process = N / size;  

   
    if (rank == 0) {
        printf("Matriz A:\n");
        for (int i = 0; i < N; i++) {
            for (int j = 0; j < N; j++) {
                A[i][j] = i + j + 1;
                printf("%d ", A[i][j]);
            }
            printf("\n");
        }

        printf("\nMatriz B:\n");
        for (int i = 0; i < N; i++) {
            for (int j = 0; j < N; j++) {
                B[i][j] = i * j + 1;
                printf("%d ", B[i][j]);
            }
            printf("\n");
        }
    }

   
    MPI_Bcast(B, N*N, MPI_INT, 0, MPI_COMM_WORLD);

    
    int sub_A[rows_per_process][N];

    if (rank == 0) {
      
        for (int i = 1; i < size; i++) {
            MPI_Send(&A[i * rows_per_process], rows_per_process * N, MPI_INT, i, 0, MPI_COMM_WORLD);
        }
    
        for (int i = 0; i < rows_per_process; i++) {
            for (int j = 0; j < N; j++) {
                sub_A[i][j] = A[i][j];
            }
        }
    } else {
    
        MPI_Recv(sub_A, rows_per_process * N, MPI_INT, 0, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
    }

    int sub_C[rows_per_process][N];

  
    for (int i = 0; i < rows_per_process; i++) {
        for (int j = 0; j < N; j++) {
            sub_C[i][j] = 0;
            for (int k = 0; k < N; k++) {
                sub_C[i][j] += sub_A[i][k] * B[k][j];
            }
        }
    }


    if (rank == 0) {
  
        for (int i = 0; i < rows_per_process; i++) {
            for (int j = 0; j < N; j++) {
                C[i][j] = sub_C[i][j];
            }
        }

        for (int i = 1; i < size; i++) {
            MPI_Recv(&C[i * rows_per_process], rows_per_process * N, MPI_INT, i, 0, MPI_COMM_WORLD, MPI_STATUS_IGNORE);
        }

    
        printf("\nMatriz C (Resultado de A x B):\n");
        print_matrix(C, N, N);

    } else {
        
        MPI_Send(sub_C, rows_per_process * N, MPI_INT, 0, 0, MPI_COMM_WORLD);
    }

  
    MPI_Finalize();
    return 0;
}
