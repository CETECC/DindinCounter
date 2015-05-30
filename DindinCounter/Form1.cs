using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DindinCounter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            // Obtém o valor da campo txtValor
            int valor = int.Parse(txtValor.Text);

            // Se o valor for inválido, exibir mensagem
            if (valor <= 0)
            {
                MessageBox.Show("Valor inválido", "Seu trouxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Calcula a quantidade de notas de 50;
            int notas50 = valor / 50;
            int notas20 = 0;

            // Calcula o resto da divisão por 50
            int resto50 = valor % 50;

            // Enquanto o resto de 50 for maior que zero
            while (resto50 > 0)
            {
                // Calcula o resto da divisão do resto de 50 por 20
                int resto20 = resto50 % 20;

                // Se o resto de 20 for maior que zero
                if (resto20 > 0)
                {
                    // Verifica se é possível retirar notas de 50 e adicionar
                    // ao resto de 50
                    if ((valor - resto20) >= 50 && notas50 > 0)
                    {
                        notas50--;
                        resto50 += 50;
                    }
                    else
                    {
                        MessageBox.Show("Valor inválido", "Seu trouxa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else
                {
                    // Calcula a quatidade de notas de 20
                    notas20 = resto50 / 20;
                    break;
                }
            }

            lbl50.Text = notas50.ToString();
            lbl20.Text = notas20.ToString();

            #region Versão antiga 
            /*
            // Calcular o resto da divisão por 100
            // Por que 100? Porque 100 é MMC de 50 e 20.
            float resto100 = valor % 100.0f;
            float resto20 = 0.0f;
            float resultValorMenos100 = valor - resto100;

            if (valor < 100)
            {
                // Se o resto de 50 for maior que 0, verifica o resto de 20
                float resto50 = valor % 50;
                if (resto50 > 0)
                {
                    // Se o resto de 50 for menor que 20, significa que o saque
                    // deve conter apenas notas de 20.
                    if(resto50 < 20)
                    {
                        resto20 = valor % 20;
                    }
                    else
                    {
                        resto20 = resto50 % 20;
                    }

                    // Se o resto de 20 for maior que 0, o saque é INVÁLIDO
                    if (resto20 > 0)
                    {
                        MessageBox.Show("O valor é inválido para saque.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        float resultValorMenos50 = valor - resto50;
                        float total50 = 0.0f;
                        float total20 = 0.0f;

                        if (resto50 >= 20)
                        {
                            total50 = resultValorMenos50 / 50.0f;
                            total20 = resto50 / 20.0f;
                        }
                        else
                        {
                            total20 = resto100 / 20.0f;
                        }

                        lbl20.Text = total20.ToString();
                        lbl50.Text = total50.ToString();
                    }
                }
            }
            else
            {
                // Se o resto de 100 for maior que 0, verifica o resto de 20
                if (resto100 > 0)
                {
                    resto20 = resto100 % 20;

                    // Se o resto de 20 for maior que 0, o saque é INVÁLIDO
                    if (resto20 > 0)
                    {
                        MessageBox.Show("O valor é inválido para saque.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else // Se o resto de 20 for 0, o saque é VÁLIDO. Proceder para cálculo.
                    {
                        float total50 = resultValorMenos100 / 50.0f;
                        float total20 = resto100 / 20.0f;

                        lbl20.Text = total20.ToString();
                        lbl50.Text = total50.ToString();
                    }
                }
                // Se o resto de 50 for 0, está OK e não tem notas de 20
                else
                {
                    float total50 = resultValorMenos100 / 50.0f;

                    lbl20.Text = "0";
                    lbl50.Text = total50.ToString();
                }
            }
            */
            #endregion
        }
    }
}
