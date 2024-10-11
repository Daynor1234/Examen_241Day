#include "stdio.h"

void suma(int *a, int *b, int *resultado);
void resta(int *a, int *b, int *resultado);
void multiplicacion(int *a, int *b, int *resultado);
void division(int *a, int *b, float *resultado);

int main() {
    int num1, num2, res_int;
    float res_float;

    printf("Introduce : ");
    scanf("%d", &num1);
    printf("Introduce: "
    scanf("%d", &num2);

    suma(&num1, &num2, &res_int);
    printf("Suma: %d\n", res_int);

    resta(&num1, &num2, &res_int);
    printf("Resta: %d\n", res_int);

    multiplicacion(&num1, &num2, &res_int);
    printf("Multiplicación: %d\n", res_int);

    if (num2 != 0) {
        division(&num1, &num2, &res_float);
        printf("División: %.2f\n", res_float);
    } else {
        printf("No se puede dividir entre 0.\n");
    }

    return 0;
}

void suma(int *a, int *b, int *resultado) {
    *resultado = *a + *b;
}

void resta(int *a, int *b, int *resultado) {
    *resultado = *a - *b;
}

void multiplicacion(int *a, int *b, int *resultado) {
    *resultado = *a * *b;
}

void division(int *a, int *b, float *resultado) {
    *resultado = (float) *a / *b;
}
