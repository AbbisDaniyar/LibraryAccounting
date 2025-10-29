using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryAccounting
{
    public static class JsonDataSerice
    {
        private static readonly string FilePath = "books.json";

        public static void SaveBooks(List<Book> books)
        {
            try
            {
                string json = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(FilePath, json);
            }
            catch(Exception ex) {
                MessageBox.Show("Ошибка сохранения!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static List<Book> LoadBooks()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string json = File.ReadAllText(FilePath);
                    return JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return new List<Book>();
        }
    }
}
