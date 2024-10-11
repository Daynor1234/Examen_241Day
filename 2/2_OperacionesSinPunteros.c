#include "stdio.h"
int suma(int a, int b);
int resta(int a, int b);
int multiplicacion(int a, int b);
float division(int a, int b);

int main() {
    int num1, num2;
    printf("Introduce número: ");
    scanf("%d", &num1);
    printf("Introduce número: ");
    scanf("%d", &num2);

    printf("Suma: %d\n", suma(num1, num2));
    printf("Resta: %d\n", resta(num1, num2));
    printf("Multiplicación: %d\n", multiplicacion(num1, num2));
    
    if (num2 != 0) {
        printf("División: %.2f\n", division(num1, num2));
    } else {
        printf("No se puede dividir entre 0.\n");
    }

    return 0;
}

int suma(int a, int b) {
    return a + b;
}

int resta(int a, int b) {
    return a - b;
}

int multiplicacion(int a, int b) {
    return a * b;
}

float division(int a, int b) {
    return (float) a / b;
}
