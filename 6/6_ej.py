cantFibos = 30
Fibonacci = serie_fibo(cantFibos)
print(Fibonacci)

def serie_fibo(tamaño):
    fibos = []
    rho = (1 + 5**0.5) / 2
    for x in range(tamaño):
        a = rho**x
        b = (-1 / rho) ** x
        fibonacci = round((a - b) / 5**0.5)
        fibos.append(fibonacci)
    return fibos
