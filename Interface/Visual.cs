using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    //Визуальная логика. Вывод необходимых полей для ввода , их сокрытие , отображение байтов ответа.
    public partial class Form1
    {
        private void ShowAnswerBytes(byte[] answer)
        {
            for (int i = 0; i < answer.Length; i++)
            {
                outputText.Text += answer[i].ToString("x");
                outputText.Text += " ";
            }

            outputText.Text += "\n";
            portStatus.Text = port.StatusPort();
        }

        private void Show1()
        {
            textArg.Visible = true;
            us1.Visible = true;
            us2.Visible = true;
            ushort1.Visible = true;
            ushort2.Visible = true;
        }

        private void Show2()
        {
            textArg.Visible = true;
            b1.Visible = true;
            b2.Visible = true;
            byte1.Visible = true;
            byte2.Visible = true;
            us1.Visible = true;
            ushort1.Visible = true;
        }

        private void Show3()
        {
            textArg.Visible = true;
            b1.Visible = true;
            byte1.Visible = true;
            us1.Visible = true;
            us2.Visible = true;
            ushort1.Visible = true;
            ushort2.Visible = true;
        }



        private void Show5()
        {
            textArg.Visible = true;
            b1.Visible = true;
            byte1.Visible = true;
            us1.Visible = true;
            us2.Visible = true;
            us3.Visible = true;
            ushort1.Visible = true;
            ushort2.Visible = true;
            ushort3.Visible = true;
        }

        private void Show6()
        {
            textArg.Visible = true;
            b1.Visible = true;
            byte1.Visible = true;
            us1.Visible = true;
            us2.Visible = true;
            us3.Visible = true;
            us4.Visible = true;
            ushort1.Visible = true;
            ushort2.Visible = true;
            ushort3.Visible = true;
            ushort4.Visible = true;
        }

        private void Show7()
        {
            textArg.Visible = true;
            b1.Visible = true;
            byte1.Visible = true;
            us1.Visible = true;
            us2.Visible = true;
            ushort1.Visible = true;
            ushort2.Visible = true;
            b3.Visible = true;
            b4.Visible = true;
            b5.Visible = true;
            b6.Visible = true;
            byte3.Visible = true;
            byte4.Visible = true;
            byte5.Visible = true;
            byte6.Visible = true;
        }

        private void Show8()
        {
            textArg.Visible = true;
            b1.Visible = true;
            byte1.Visible = true;
            us1.Visible = true;
            us2.Visible = true;
            us3.Visible = true;
            ushort1.Visible = true;
            ushort2.Visible = true;
            ushort3.Visible = true;
            b3.Visible = true;
            b4.Visible = true;
            b5.Visible = true;
            b6.Visible = true;
            b7.Visible = true;
            b8.Visible = true;
            byte3.Visible = true;
            byte4.Visible = true;
            byte5.Visible = true;
            byte6.Visible = true;
            byte7.Visible = true;
            byte8.Visible = true;
        }

        private new void Hide()
        {
            textArg.Visible = false;
            b1.Visible = false;
            byte1.Visible = false;
            us1.Visible = false;
            us2.Visible = false;
            us3.Visible = false;
            us4.Visible = false;
            ushort1.Visible = false;
            ushort2.Visible = false;
            ushort3.Visible = false;
            ushort4.Visible = false;
            b2.Visible = false;
            b3.Visible = false;
            b4.Visible = false;
            b5.Visible = false;
            b6.Visible = false;
            b7.Visible = false;
            b8.Visible = false;
            byte2.Visible = false;
            byte3.Visible = false;
            byte4.Visible = false;
            byte5.Visible = false;
            byte6.Visible = false;
            byte7.Visible = false;
            byte8.Visible = false;
        }
    }
}
