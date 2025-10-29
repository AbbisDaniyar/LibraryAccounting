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
    public partial class Form1 : Form
    {
        private List<Book> books;
        private BindingList<Book> bindingBooks;

        public Form1()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            books = JsonDataSerice.LoadBooks();

            if (books.Count == 0)
            {books.Add(new Book("A.C. Пушкин", 1833, "Евгений Онегин", 5));
            books.Add(new Book("Л.Н. Толстой", 1869, "Война и мир", 3));
            books.Add(new Book("Ф.М. Достоевский", 1866, "Преступление и наказание", 2));
            books.Add(new Book("A.C. Грибоедов", 1833, "Горе от ума", 4));
            books.Add(new Book("М.Ю. Лермонтов", 1840, "Герой нашего времени", 1));
            }

            bindingBooks = new BindingList<Book>(books);
            dataGridViewLibrary.DataSource = bindingBooks;
            
        }

        private void RefreshDataGrid()
        {
            bindingBooks = new BindingList<Book>(books);
            dataGridViewLibrary.DataSource = bindingBooks;
            dataGridViewLibrary.Refresh();
        }

        private void SaveData()
        {
            JsonDataSerice.SaveBooks(books);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }

        private void deleteBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewLibrary.SelectedRows.Count > 0)
            {
                var selectedBook = dataGridViewLibrary.SelectedRows[0].DataBoundItem as Book;
                if (selectedBook != null)
                {
                    var masage = MessageBox.Show($"Вы уверены что хотите списать книги:\n\"{selectedBook.Title}\"?",
                        "Потверждение списания", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (masage == DialogResult.Yes)
                    {
                        books.Remove(selectedBook);
                        RefreshDataGrid();
                        SaveData();
                        MessageBox.Show("Книга успешно списана!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите книгу для списания!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void sortAutor_Click(object sender, EventArgs e)
        {
            books.Sort((x,y) => x.Author.CompareTo(y.Author));
            RefreshDataGrid();
            MessageBox.Show("Книги отсортированы по авторам.", "Сортировка",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void sortData_Click(object sender, EventArgs e)
        {
            books.Sort((x, y) => x.Year.CompareTo(y.Year));
            RefreshDataGrid();
            MessageBox.Show("Книги отсортированы по годам издания.", "Сортировка",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void addBook_Click(object sender, EventArgs e)
        {
            using (var addForm = new Form2()) {
                if (addForm.ShowDialog() == DialogResult.OK) {
                    books.Add(addForm.NewBook);
                    RefreshDataGrid();
                    SaveData();

                    MessageBox.Show("Книга успешно добавлена!", "Успешно",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
    }
}
