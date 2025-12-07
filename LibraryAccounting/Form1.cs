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
        private List<Book> originalBooks;

        public Form1()
        {
            InitializeComponent();
            InitializeData();
            originalBooks = new List<Book>(books);
        }

        private void InitializeData()
        {
            books = JsonDataService.LoadBooks();

            if (books.Count == 0)
            {books.Add(new Book("A.C. Пушкин", 1833, "Евгений Онегин", 5));
            books.Add(new Book("Л.Н. Толстой", 1869, "Война и мир", 3));
            books.Add(new Book("Ф.М. Достоевский", 1866, "Преступление и наказание", 2));
            books.Add(new Book("A.C. Грибоедов", 1833, "Горе от ума", 4));
            books.Add(new Book("М.Ю. Лермонтов", 1840, "Герой нашего времени", 1));
            }

            originalBooks = new List<Book>(books);  
            bindingBooks = new BindingList<Book>(books);
            dataGridViewLibrary.DataSource = bindingBooks;
            
        }

        private void RefreshDataGrid()
        {
            bindingBooks = new BindingList<Book>(books);
            dataGridViewLibrary.DataSource = null;
            dataGridViewLibrary.DataSource = bindingBooks;
            dataGridViewLibrary.Refresh();
        }

        private void SaveData()
        {
            JsonDataService.SaveBooks(books);
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
                        originalBooks.Remove(selectedBook);
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


        private void addBook_Click(object sender, EventArgs e)
        {
            using (var addForm = new Form2()) {
                if (addForm.ShowDialog() == DialogResult.OK) {
                    books.Add(addForm.NewBook);
                    originalBooks.Add(addForm.NewBook);
                    RefreshDataGrid();
                    SaveData();

                    MessageBox.Show("Книга успешно добавлена!", "Успешно",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            string selectedField = comboBoxField.SelectedItem.ToString();

            if (string.IsNullOrEmpty(selectedField)) {
                MessageBox.Show("Выберете поле для сортировки", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            switch (selectedField)
            {
                case "Автор":
                    books.Sort((x, y) => x.Author.CompareTo(y.Author));
                    break;
                case "Год издания":
                    books.Sort((x, y) => x.Year.CompareTo(y.Year));
                    break;
                case "Название":
                    books.Sort((x, y) => x.Title.CompareTo(y.Title));
                    break;
                case "Кол-во экземпляров":
                    books.Sort((x, y) => x.Copies.CompareTo(y.Copies));
                    break;
            }

            RefreshDataGrid();
            MessageBox.Show($"Книги отсортированы по полю:{selectedField}", "Сортировка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            string selectedField = comboBoxField.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Введите текст для поиска", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearch.Focus();
                return;
            }

            List<Book> searchResults = new List<Book>();

            switch (selectedField)
            {
                case "Автор":
                    searchResults = books.Where(b => b.Author.ToLower().Contains(searchText.ToLower())).ToList();
                    break;
                case "Год издания":
                    if (int.TryParse(searchText, out int year))
                    {
                        searchResults = books.Where(b => b.Year == year).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Введите коректный год для поиска", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                case "Название":
                    searchResults = books.Where(b => b.Title.ToLower().Contains(searchText.ToLower())).ToList();
                    break;
                case "Кол-во экземпляров":
                    if (int.TryParse(searchText, out int copies))
                    {
                        searchResults = books.Where(b => b.Copies == copies).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Введите коректное число для поиска", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
            }

            if (originalBooks.Count != books.Count || !books.SequenceEqual(originalBooks))
            {
                originalBooks = new List<Book>(books);
            }

            bindingBooks = new BindingList<Book>(searchResults);
            dataGridViewLibrary.DataSource = bindingBooks;
            dataGridViewLibrary.Refresh();

            MessageBox.Show($"Найдено {searchResults.Count} книг", "Результат поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            books = new List<Book>(originalBooks);
            txtSearch.Clear();
            RefreshDataGrid();
        }


    }
}
