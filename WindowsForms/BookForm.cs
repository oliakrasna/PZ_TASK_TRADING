using BLL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class BookForm : Form
    {
        protected readonly IRegistered _reg;
        private List<BookDTO> _book;
        public BookForm(IRegistered reg)
        {
            InitializeComponent();
            _reg = reg;

        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            
            _book = _reg.GetAllBooks();
            BindingList<BookDTO> bl = new BindingList<BookDTO>(_book);
            bookBindingSource.DataSource = bl;

            var currBook = bookBindingSource.Current;

            dataGridView1.DataSource = bookBindingSource;
            bookBindingNavigator.BindingSource = bookBindingSource;

        }

        


    }
}




