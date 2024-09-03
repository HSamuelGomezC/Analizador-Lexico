using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analizador_Lexico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void entrada_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void Analizar_Click(object sender, EventArgs e)
        {
            string cadena0 = entrada.Text; // Obtener el texto del TextBox 'entrada'


            List<Dictionary<string, object>> elementos = new List<Dictionary<string, object>>();
            int estado = 0;
            int indice = 0;
            string cadena = cadena0 + '$';

            while (indice <= (cadena.Length - 1) && estado == 0)
            {
                string lexema = "";
                string token = "error";
                int numero = -1;

                while (indice <= (cadena.Length - 1) && estado != 20)
                {
                    if (estado == 0)
                    {
                        if (char.IsWhiteSpace(cadena[indice]))
                        {
                            estado = 0;
                        }
                        else if (char.IsDigit(cadena[indice]))
                        {
                            estado = 3;
                            lexema += cadena[indice];
                        }
                        else if (char.IsLetter(cadena[indice]) || cadena[indice] == '_')
                        {
                            estado = 4;
                            lexema += cadena[indice];
                        }
                        else if (cadena[indice] == '$')
                        {
                            estado = 20;
                            lexema += cadena[indice];
                            token = "pesos";
                            numero = 18;
                        }
                        else if (cadena[indice] == '=')
                        {
                            lexema += cadena[indice];
                            token = "asignación";
                            numero = 8;
                            estado = 5;
                        }
                        else if (cadena[indice] == '(')
                        {
                            token += "parentesisIz";
                            numero = 4;
                            estado = 20;
                            lexema += cadena[indice];
                        }
                        else if (cadena[indice] == ')')
                        {
                            token += "paretensisDer";
                            numero = 5;
                            estado = 20;
                            lexema += cadena[indice];
                        }
                        else if (cadena[indice] == '{')
                        {
                            token += "llaveIz";
                            numero = 6;
                            estado = 20;
                            lexema += cadena[indice];
                        }
                        else if (cadena[indice] == '}')
                        {
                            token += "llaveDer";
                            numero = 7;
                            estado = 20;
                            lexema += cadena[indice];
                        }
                        else if (cadena[indice] == '>')
                        {
                            token += "opRelacional";
                            numero = 17;
                            estado = 6;
                            lexema += cadena[indice];
                        }
                        else if (cadena[indice] == '<')
                        {
                            token += "opRelacional";
                            numero = 17;
                            estado = 7;
                            lexema += cadena[indice];
                        }
                        else if (cadena[indice] == ',')
                        {
                            token += "coma";
                            numero = 3;
                            estado = 20;
                            lexema += cadena[indice];
                        }
                        else if (cadena[indice] == ';')
                        {
                            token += "puntoComa";
                            numero = 2;
                            estado = 20;
                            lexema += cadena[indice];
                        }
                        else if (cadena[indice] == '+' || cadena[indice] == '-')
                        {
                            token += "opSuma";
                            numero = 14;
                            estado = 20;
                            lexema += cadena[indice];
                        }
                        else if (cadena[indice] == '*' || cadena[indice] == '/')
                        {
                            token += "opMul";
                            numero = 16;
                            estado = 20;
                            lexema += cadena[indice];
                        }
                        else if (cadena[indice] == '!')
                        {
                            numero = 17;
                            estado = 8;
                            lexema += cadena[indice];
                        }
                        else if (cadena[indice] == '|')
                        {
                            numero = 17;
                            estado = 9;
                            lexema += cadena[indice];
                        }
                        else if (cadena[indice] == '&')
                        {
                            numero = 17;
                            estado = 10;
                            lexema += cadena[indice];
                        }
                        else
                        {
                            estado = 20;
                            token = "error";
                            lexema = cadena[indice].ToString();
                        }
                        indice++;
                    }
                    else if (estado == 3)
                    {
                        if (char.IsDigit(cadena[indice]))
                        {
                            estado = 3;
                            token = "constante";
                            numero = 13;
                            indice++;
                            lexema += cadena[indice];
                        }
                        else
                        {
                            estado = 20;
                            // ...
                        }
                    }
                    else if (estado == 4)
                    {
                        if (char.IsDigit(cadena[indice]) || char.IsLetter(cadena[indice]) || cadena[indice] == '_')
                        {
                            estado = 4;
                            lexema += cadena[indice];
                            token = "id";
                            numero = 1;
                            indice++;
                        }
                        else
                        {
                            estado = 20;
                        }
                    }
                    else if (estado == 5)
                    {
                        if (cadena[indice] != '=')
                        {
                            estado = 20;
                        }
                        else
                        {
                            estado = 20;
                            lexema += cadena[indice];
                            token = "opRelacional";
                            numero = 17;
                            indice++;
                        }
                    }
                    else if (estado == 6)
                    {
                        if (cadena[indice] != '=')
                        {
                            estado = 20;
                        }
                        else
                        {
                            estado = 20;
                            lexema += cadena[indice];
                            token += "opRelacional";
                            indice++;
                        }
                    }
                    else if (estado == 7)
                    {
                        if (cadena[indice] != '=')
                        {
                            estado = 20;
                        }
                        else
                        {
                            estado = 20;
                            lexema += cadena[indice];
                            token += "opRelacional";
                            indice++;
                        }
                    }
                    else if (estado == 8)
                    {
                        if (cadena[indice] != '=')
                        {
                            estado = 20;
                        }
                        else
                        {
                            estado = 20;
                            lexema += cadena[indice];
                            token += "opRelacional";
                            indice++;
                        }
                    }
                    else if (estado == 9)
                    {
                        if (cadena[indice] != '|')
                        {
                            estado = 20;
                        }
                        else
                        {
                            estado = 20;
                            lexema += cadena[indice];
                            token += "opLogica";
                            indice++;
                        }
                    }
                    else if (estado == 10)
                    {
                        if (cadena[indice] != '&')
                        {
                            estado = 20;
                        }
                        else
                        {
                            estado = 20;
                            lexema += cadena[indice];
                            token += "opLogica";
                            indice++;
                        }
                    }
                }
                estado = 0;
                elementos.Add(new Dictionary<string, object>
            {
                { "token", token },
                { "lexema", lexema },
                { "numero", numero }
            });
            }

            foreach (var elemento in elementos)
            {
                if (elemento["lexema"].ToString() == "if")
                {
                    elemento["token"] = "condicional SI";
                    elemento["numero"] = 9;
                }
                if (elemento["lexema"].ToString() == "while")
                {
                    elemento["token"] = "while";
                    elemento["numero"] = 10;
                }
                if (elemento["lexema"].ToString() == "return")
                {
                    elemento["token"] = "return";
                    elemento["numero"] = 11;
                }
                if (elemento["lexema"].ToString() == "else")
                {
                    elemento["token"] = "else";
                    elemento["numero"] = 12;
                }

                //Console.WriteLine(elemento);
            }

            // Limpia el DataGridView antes de mostrar los resultados
            dataGridView1.Rows.Clear();

            // Agrega los resultados al DataGridView
            foreach (var elemento in elementos)
            {
                string lexema = elemento["lexema"].ToString();
                string token = elemento["token"].ToString();
                int numero = (int)elemento["numero"];

                dataGridView1.Rows.Add(lexema, token, numero);
            }

            LR1.Text = "NO Aceptada";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LR1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
