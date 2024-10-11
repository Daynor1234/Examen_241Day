#include "stdio.h"

// iterativa
void calcular_pi_iter(double *pi, int iterac) {
    double suma = 0.0;
    for (int i = 0; i < iterac; i++) {
        double termino = (i % 2 == 0 ? 1.0 : -1.0) / (2.0 * i + 1.0);
        suma += termino;
    }
    *pi = suma * 4.0;
}

// recursiva
void calcular_pi_recur(double *pi, int iterac, int actual, double suma) {
    if (actual >= iterac) {
        *pi = suma * 4.0;
        return;
    }

    double termino = (actual % 2 == 0 ? 1.0 : -1.0) / (2.0 * actual + 1.0);
    calcular_pi_recur(pi, iterac, actual + 1, suma + termino);
}

int main() {
    double pi = 0.0;
    int iterac = 1000000; 
    int opcion;
    printf("elija método para calcular pi:\n");
    printf("1. Iterativo\n");
    printf("2. Recursivo\n");
    printf("Opción: ");
    scanf("%d", &opcion);

    if (opcion == 1) {
        calcular_pi_iter(&pi, iterac);
        printf("iterativo: %.15f\n", pi);
    } else if (opcion == 2) {
        calcular_pi_recur(&pi, iterac, 0, 0.0);
        printf("recursivo: %.15f\n", pi);
    } else {
        printf("Opción no válida.\n");
    }

    return 0;
}
