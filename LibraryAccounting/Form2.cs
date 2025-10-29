using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryAccounting
{
    public partial class Form2 : Form
    {
        public Book NewBook { get; set; }
        public Form2()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    string author = txtAutor.Text.Trim();
                    int year = int.Parse(txtYear.Text.Trim());
                    string title = txtTitle.Text.Trim();
                    int copies = int.Parse(txtCopies.Text.Trim());

                    NewBook = new Book(author, year, title, copies);

                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }
                catch (Exception ex) {
                    MessageBox.Show("Ошибка при добавлении книги!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtAutor.Text))
            {
                MessageBox.Show("Введите инициалы и фамилию автора!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAutor.Focus();
                return false;
            }

            if (!int.TryParse(txtYear.Text, out int year) || year < 1000 || year > DateTime.Now.Year)
            {
                MessageBox.Show("Введите коректный год издания!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtYear.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Введите название книги!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTitle.Focus();
                return false;
            }

            if (!int.TryParse(txtCopies.Text, out int copies) || copies < 1)
            {
                MessageBox.Show("Введите корректноное количество экземпляров!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCopies.Focus();
                return false;
            }

            return true;
        }

        private void ClearInputFields()
        {
            txtAutor.Clear();
            txtYear.Clear();
            txtTitle.Clear();
            txtCopies.Clear();
            txtAutor.Focus();
        }

        private void cansel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
