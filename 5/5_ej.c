#include <stdio.h>
#include <stdlib.h>
#include <pthread.h>
#include <decimal.h>  
#define PRECISION 100

typedef struct {
    int inicio;
    int fin;
    decimal suma_parcial;
} Rango;


void* calcular_segmento_nilakantha(void* args) {
    Rango* rango = (Rango*) args;
    decimal suma_parcial = 0;
    int signo = 1;
    
    for (int i = rango->inicio; i < rango->fin; i++) {
        int n = 2 + 2 * i;
        decimal termino = (decimal) 4 / (n * (n + 1) * (n + 2));
        suma_parcial += signo * termino;
        signo *= -1;
    }
    
    rango->suma_parcial = suma_parcial;
    pthread_exit(NULL);
}

int main() {
    int iteraciones = 1000000;
    int num_procesadores = sysconf(_SC_NPROCESSORS_ONLN); 
    
    int chunk_size = iteraciones / num_procesadores;


    Rango* rangos = (Rango*) malloc(num_procesadores * sizeof(Rango));
    pthread_t* threads = (pthread_t*) malloc(num_procesadores * sizeof(pthread_t));

    
    for (int i = 0; i < num_procesadores; i++) {
        rangos[i].inicio = i * chunk_size;
        rangos[i].fin = (i + 1) * chunk_size;
        
   
        if (i == num_procesadores - 1 && iteraciones % num_procesadores != 0) {
            rangos[i].fin = iteraciones;
        }

        
        pthread_create(&threads[i], NULL, calcular_segmento_nilakantha, (void*)&rangos[i]);
    }

  
    for (int i = 0; i < num_procesadores; i++) {
        pthread_join(threads[i], NULL);
    }


    decimal suma_total = 0;
    for (int i = 0; i < num_procesadores; i++) {
        suma_total += rangos[i].suma_parcial;
    }

    decimal pi_aproximado = 3 + suma_total;

    printf("Valor aproximado de Pi con %d términos: %.100Lf\n", iteraciones, pi_aproximado);

    free(rangos);
    free(threads);

    return 0;
}
