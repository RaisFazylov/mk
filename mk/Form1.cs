using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Получаем текст из поля ввода
            string userText = txtUserInput.Text;

            // Очищаем поле ввода
            txtUserInput.Text = "";

            // Фокус возвращаем в поле ввода
            txtUserInput.Focus();
        }

        private void txtUserInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Если нажат Enter (код 13)
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Вызываем тот же обработчик, что и для кнопки
                btnSubmit_Click(sender, e);

                // Подавляем стандартный звук Windows
                e.Handled = true;
            }
        }
    }
}
