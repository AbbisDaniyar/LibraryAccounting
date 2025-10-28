namespace LibraryAccounting
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridViewLibrary = new System.Windows.Forms.DataGridView();
            this.addBook = new System.Windows.Forms.Button();
            this.deleteBook = new System.Windows.Forms.Button();
            this.sortData = new System.Windows.Forms.Button();
            this.sortAutor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLibrary)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewLibrary
            // 
            this.dataGridViewLibrary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLibrary.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewLibrary.Name = "dataGridViewLibrary";
            this.dataGridViewLibrary.RowHeadersWidth = 51;
            this.dataGridViewLibrary.RowTemplate.Height = 24;
            this.dataGridViewLibrary.Size = new System.Drawing.Size(776, 282);
            this.dataGridViewLibrary.TabIndex = 0;
            // 
            // addBook
            // 
            this.addBook.Location = new System.Drawing.Point(12, 300);
            this.addBook.Name = "addBook";
            this.addBook.Size = new System.Drawing.Size(388, 76);
            this.addBook.TabIndex = 1;
            this.addBook.Text = "Добавить книгу";
            this.addBook.UseVisualStyleBackColor = true;
            // 
            // deleteBook
            // 
            this.deleteBook.Location = new System.Drawing.Point(400, 300);
            this.deleteBook.Name = "deleteBook";
            this.deleteBook.Size = new System.Drawing.Size(388, 76);
            this.deleteBook.TabIndex = 2;
            this.deleteBook.Text = "Удалить книгу";
            this.deleteBook.UseVisualStyleBackColor = true;
            // 
            // sortData
            // 
            this.sortData.Location = new System.Drawing.Point(400, 382);
            this.sortData.Name = "sortData";
            this.sortData.Size = new System.Drawing.Size(388, 76);
            this.sortData.TabIndex = 3;
            this.sortData.Text = "Сортировать по дате выпуска";
            this.sortData.UseVisualStyleBackColor = true;
            // 
            // sortAutor
            // 
            this.sortAutor.Location = new System.Drawing.Point(12, 382);
            this.sortAutor.Name = "sortAutor";
            this.sortAutor.Size = new System.Drawing.Size(388, 76);
            this.sortAutor.TabIndex = 4;
            this.sortAutor.Text = "Сортировать по авторам";
            this.sortAutor.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 479);
            this.Controls.Add(this.sortAutor);
            this.Controls.Add(this.sortData);
            this.Controls.Add(this.deleteBook);
            this.Controls.Add(this.addBook);
            this.Controls.Add(this.dataGridViewLibrary);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "LibraryApp";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLibrary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLibrary;
        private System.Windows.Forms.Button addBook;
        private System.Windows.Forms.Button deleteBook;
        private System.Windows.Forms.Button sortData;
        private System.Windows.Forms.Button sortAutor;
    }
}

