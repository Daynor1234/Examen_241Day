using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CalculadoraNotacion
{
    public partial class Form1 : Form
    {
        string c;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            c = "";
        }

        private void composicion(object sender, EventArgs e)
        {
            c += ((Button)sender).Text;
            textBox1.Text = c;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            c = "";
            textBox1.Text = c;
            textBox2.Text = c;
            textBox3.Text = c;
        }

        public static int Precedencia(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                case '^':
                    return 3;
                default:
                    return -1;
            }
        }

        public static string ConvertirInfijoAPostfijo(string exp)
        {
            string resultado = "";
            Stack<char> pila = new Stack<char>();

            for (int i = 0; i < exp.Length; i++)
            {
                char c = exp[i];

                if (char.IsDigit(c) || c == '.')
                {
                    while (i < exp.Length && (char.IsDigit(exp[i]) || exp[i] == '.'))
                    {
                        resultado += exp[i];
                        i++;
                    }
                    resultado += ' ';
                    i--;
                }
                else if (c == '(')
                {
                    pila.Push(c);
                }
                else if (c == ')')
                {
                    while (pila.Count > 0 && pila.Peek() != '(')
                    {
                        resultado += pila.Pop() + " ";
                    }
                    pila.Pop();
                }
                else
                {
                    while (pila.Count > 0 && Precedencia(c) <= Precedencia(pila.Peek()))
                    {
                        resultado += pila.Pop() + " ";
                    }
                    pila.Push(c);
                }
            }

            while (pila.Count > 0)
            {
                resultado += pila.Pop() + " ";
            }

            return resultado.Trim();
        }

        public static double EvaluarPostfijo(string exp)
        {
            Stack<double> pila = new Stack<double>();
            string[] tokens = exp.Split(' ');

            foreach (string token in tokens)
            {
                if (double.TryParse(token, out double numero))
                {
                    pila.Push(numero);
                }
                else
                {
                    double val1 = pila.Pop();
                    double val2 = pila.Pop();

                    switch (token)
                    {
                        case "+":
                            pila.Push(val2 + val1);
                            break;
                        case "-":
                            pila.Push(val2 - val1);
                            break;
                        case "*":
                            pila.Push(val2 * val1);
                            break;
                        case "/":
                            pila.Push(val2 / val1);
                            break;
                    }
                }
            }

            return pila.Pop();
        }

        private void MostrarResultado(double resultado)
        {
            if (resultado % 1 == 0)
            {
                textBox1.Text = Math.Round(resultado).ToString();
            }
            else
            {
                textBox1.Text = resultado.ToString("F5").TrimEnd('0').TrimEnd('.');
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
            textBox3.Text = ConvertirInfijoAPostfijo(textBox1.Text);
            double resultado = EvaluarPostfijo(textBox3.Text);
            MostrarResultado(resultado);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (c.Length > 0)
            {
                c = c.Substring(0, c.Length - 1);
                textBox1.Text = c;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            double n = Convert.ToDouble(textBox1.Text);
            if (n >= 0)
            {
                n = Math.Sqrt(n);
                MostrarResultado(n);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            double n = Convert.ToDouble(textBox1.Text);
            n = Math.Pow(n, 2);
            MostrarResultado(n);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            double n = Convert.ToDouble(textBox1.Text);
            if (n > 0)
            {
                n = Math.Log10(n);
                MostrarResultado(n);
            }
        }
    }
}
