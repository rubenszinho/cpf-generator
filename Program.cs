using System;
using System.Windows.Forms;

namespace CpfGenerator
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                string cpf = GenerateCpf();
                AddToClipboard(cpf);
                MessageBox.Show($"CPF Gerado: {cpf}\nEle foi copiado para a área de transferência.", "Gerador de CPF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Console.WriteLine("Pressione qualquer tecla para sair...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static string GenerateCpf()
        {
            Random random = new Random();
            int[] cpf = new int[11];
            for (int i = 0; i < 9; i++)
            {
                cpf[i] = random.Next(0, 10);
            }
            for (int j = 0; j < 2; j++)
            {
                int sum = 0;
                for (int i = 0; i < 9 + j; i++)
                {
                    sum += cpf[i] * ((10 + j) - i);
                }
                int val = sum % 11;
                cpf[9 + j] = (val < 2) ? 0 : 11 - val;
            }

            return string.Join("", cpf);
        }
        static void AddToClipboard(string text)
        {
            Clipboard.SetText(text);
        }
    }
}
