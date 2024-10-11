#include "stdio.h"
#include "omp.h"

#define N 20

int main() {
    int fib1 = 0, fib2 = 1;

    printf("Serie de Fibonacci:\n");
    printf("%d ", fib1);
    printf("%d ", fib2);

    #pragma omp parallel
    {
        int next_fib_local, fib1_local, fib2_local;
        
        fib1_local = fib1;
        fib2_local = fib2;

        #pragma omp for
        for (int i = 2; i < N; i++) {
            #pragma omp critical
            {
                next_fib_local = fib1_local + fib2_local;
                printf("%d ", next_fib_local);

                fib1_local = fib2_local;
                fib2_local = next_fib_local;
            }
        }
    }

    printf("\n");
    return 0;
}



