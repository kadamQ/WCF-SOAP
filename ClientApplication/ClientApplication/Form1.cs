using ClientApplication.BookshopServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApplication
{
    public partial class Form1 : Form
    {
        private MyBookshopServiceClient client;
        private User user;
        List<BookModel> records_BooksList;
        BackgroundWorker bgWorker;
        public Form1()
        {
            InitializeComponent();
            bgWorker = new BackgroundWorker();
            dataGridViewBooks.Hide();
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
        }

        private void Loading()
        {
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.DoWork += BgWorker_DoWork;
            bgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;
            InitDataGridView();
        }
        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            FillDataGridView();
        }
        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                records_BooksList = client.ListAll(user).ToList();
            }
            catch (FaultException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void InitDataGridView()
        {
            dataGridViewBooks.Rows.Clear();
            dataGridViewBooks.Columns.Clear();

            DataGridViewColumn IsbnColumn = new DataGridViewTextBoxColumn()
            {
                Name = "isbn",
                HeaderText = "ISBN",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dataGridViewBooks.Columns.Add(IsbnColumn);

            DataGridViewColumn TitleColumn = new DataGridViewTextBoxColumn()
            {
                Name = "title",
                HeaderText = "Title",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dataGridViewBooks.Columns.Add(TitleColumn);

            DataGridViewColumn AuthorColumn = new DataGridViewTextBoxColumn()
            {
                Name = "author",
                HeaderText = "Author",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dataGridViewBooks.Columns.Add(AuthorColumn);

            DataGridViewColumn PublicationDateColumn = new DataGridViewTextBoxColumn()
            {
                Name = "publicationDate",
                HeaderText = "PublicationDate",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dataGridViewBooks.Columns.Add(PublicationDateColumn);

            DataGridViewColumn PriceColumn = new DataGridViewTextBoxColumn()
            {
                Name = "price",
                HeaderText = "Price",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dataGridViewBooks.Columns.Add(PriceColumn);

            DataGridViewColumn DiscountPriceColumn = new DataGridViewTextBoxColumn()
            {
                Name = "discountPrice",
                HeaderText = "DiscountPrice",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dataGridViewBooks.Columns.Add(DiscountPriceColumn);

            DataGridViewColumn InstockColumn = new DataGridViewTextBoxColumn()
            {
                Name = "instock",
                HeaderText = "Instock",
                Visible = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            };
            dataGridViewBooks.Columns.Add(InstockColumn);
        }
        private void FillDataGridView()
        {
            if (records_BooksList != null)
            {
                DataGridViewRow[] dataGridViewRows = new DataGridViewRow[records_BooksList.Count];

                for (int i = 0; i < records_BooksList.Count; i++)
                {
                    DataGridViewRow dataGridViewRow = new DataGridViewRow();

                    DataGridViewCell IsbnCell = new DataGridViewTextBoxCell();
                    IsbnCell.Value = records_BooksList[i].Isbn;
                    dataGridViewRow.Cells.Add(IsbnCell);

                    DataGridViewCell TitleCell = new DataGridViewTextBoxCell();
                    TitleCell.Value = records_BooksList[i].Title;
                    dataGridViewRow.Cells.Add(TitleCell);

                    DataGridViewCell AuthorCell = new DataGridViewTextBoxCell();
                    AuthorCell.Value = records_BooksList[i].Author;
                    dataGridViewRow.Cells.Add(AuthorCell);

                    DataGridViewCell PublicationDateCell = new DataGridViewTextBoxCell();
                    PublicationDateCell.Value = records_BooksList[i].PublicationDate;
                    dataGridViewRow.Cells.Add(PublicationDateCell);

                    DataGridViewCell PriceCell = new DataGridViewTextBoxCell();
                    PriceCell.Value = records_BooksList[i].Price;
                    dataGridViewRow.Cells.Add(PriceCell);

                    DataGridViewCell DiscountPriceCell = new DataGridViewTextBoxCell();
                    DiscountPriceCell.Value = records_BooksList[i].DiscountPrice;
                    dataGridViewRow.Cells.Add(DiscountPriceCell);

                    DataGridViewCell InstockCell = new DataGridViewTextBoxCell();
                    InstockCell.Value = records_BooksList[i].Instock;
                    dataGridViewRow.Cells.Add(InstockCell);

                    dataGridViewRows[i] = dataGridViewRow;
                }
                dataGridViewBooks.Rows.Clear();
                dataGridViewBooks.Rows.AddRange(dataGridViewRows);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                try
                {
                    if (DateTime.Now.Year < int.Parse(textBoxPublicationDate.Text))
                        throw new Exception("The year must not greater than the actual year!");
                    if (1450 > int.Parse(textBoxPublicationDate.Text))
                        throw new Exception("The year must greater than 1450!");
                    client.Insert(user, textBoxISBN.Text, textBoxTitle.Text, textBoxAuthor.Text, textBoxPublicationDate.Text, int.Parse(textBoxPrice.Text), int.Parse(textBoxInstock.Text));
                    bgWorker.RunWorkerAsync();
                }
                catch (EndpointNotFoundException)
                {
                    MessageBox.Show("Problem with the server!");
                }
                catch (FaultException<ArgumentFault>)
                {
                    MessageBox.Show("Wrong or missing parameter/parameters!");
                }
                catch (FaultException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (FormatException)
                {
                    MessageBox.Show("The format of an argument/arguments is invalid!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("You need to login first!");
        }

        private void buttonListByISBN_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                try
                {
                    if (textBoxISBN.Text.Contains("-"))
                        textBoxISBN.Text = textBoxISBN.Text.Replace("-", "");
                    BookModel book = client.ListByIsbn(user, textBoxISBN.Text);
                    if (textBoxISBN.Text != book.Isbn)
                    {
                        MessageBox.Show("ISBN code not found in database!");
                    }
                    else
                    {
                        textBoxAuthor.Text = book.Author;
                        textBoxTitle.Text = book.Title;
                        textBoxPublicationDate.Text = book.PublicationDate;
                        textBoxPrice.Text = book.Price.ToString();
                        textBoxInstock.Text = book.Instock.ToString();
                    }
                }
                catch (EndpointNotFoundException)
                {
                    MessageBox.Show("Problem with the server!");
                }
                catch (FaultException<ArgumentNullFault>)
                {
                    MessageBox.Show("ISBN number is required!");
                }
                catch (FaultException<IndexOutOfRangeFault>)
                {
                    MessageBox.Show("Wrong ISBN code!");
                }
                catch (FaultException<ArgumentFault> ex)
                {
                    MessageBox.Show("Wrong ISBN code!");
                }
                catch (FaultException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("You need to login first!");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                try
                {
                    if (textBoxISBN.Text.Contains("-"))
                        textBoxISBN.Text = textBoxISBN.Text.Replace("-", "");
                    BookModel book = client.ListByIsbn(user, textBoxISBN.Text);
                    client.Delete(user, textBoxISBN.Text);
                    if (textBoxISBN.Text != book.Isbn)
                    {
                        MessageBox.Show("ISBN code not found in database!");
                    }
                    bgWorker.RunWorkerAsync();
                }
                catch (EndpointNotFoundException)
                {
                    MessageBox.Show("Problem with the server!");
                }
                catch (FaultException<ArgumentNullFault>)
                {
                    MessageBox.Show("ISBN number is required!");
                }
                catch (FaultException<IndexOutOfRangeFault>)
                {
                    MessageBox.Show("Wrong ISBN code!");
                }
                catch (FaultException<ArgumentFault> ex)
                {
                    MessageBox.Show("Wrong ISBN code!");
                }
                catch (FaultException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("You need to login first!");
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                try
                {
                    if (textBoxISBN.Text.Contains("-"))
                        textBoxISBN.Text = textBoxISBN.Text.Replace("-", "");
                    BookModel book = client.ListByIsbn(user, textBoxISBN.Text);
                    if (textBoxISBN.Text != book.Isbn)
                    {
                        MessageBox.Show("ISBN code not found in database!");
                    }
                    else if (client.Update(user, client.ListByIsbn(user, textBoxISBN.Text), int.Parse(textBoxPrice.Text), int.Parse(textBoxInstock.Text)))
                        bgWorker.RunWorkerAsync();
                }
                catch (EndpointNotFoundException)
                {
                    MessageBox.Show("Problem with the server!");
                }
                catch (FaultException<ArgumentNullFault>)
                {
                    MessageBox.Show("ISBN number is required!");
                }
                catch (FaultException<IndexOutOfRangeFault>)
                {
                    MessageBox.Show("Wrong ISBN code!");
                }
                catch (FaultException<ArgumentFault> ex)
                {
                    MessageBox.Show("Wrong or missing parameter / parameters!");
                }
                catch (FormatException)
                {
                    MessageBox.Show("The format of an argument/arguments is invalid!");
                }
                catch (FaultException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("You need to login first!");
        }

        private void buttonDiscountAll_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                try
                {
                    client.DiscountAll(user, int.Parse(textBoxPricePercentage.Text));
                    bgWorker.RunWorkerAsync();
                }
                catch (EndpointNotFoundException)
                {
                    MessageBox.Show("Problem with the server!");
                }
                catch (FormatException)
                {
                    MessageBox.Show("The format of an argument/arguments is invalid!");
                }
                catch (FaultException<ArgumentFault>)
                {
                    MessageBox.Show("Number must be an integer between 0 and 100!");
                }
                catch (FaultException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("You need to login first!");
        }

        private void buttonDiscountOne_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                try
                {
                    if (textBoxISBN.Text.Contains("-"))
                        textBoxISBN.Text = textBoxISBN.Text.Replace("-", "");
                    BookModel book = client.ListByIsbn(user, textBoxISBN.Text);
                    if (textBoxISBN.Text != book.Isbn)
                    {
                        MessageBox.Show("ISBN code not found in database!");
                    }
                    else
                        client.DiscountOne(user, textBoxISBN.Text, int.Parse(textBoxPricePercentage.Text));                 
                    bgWorker.RunWorkerAsync();
                }
                catch (EndpointNotFoundException)
                {
                    MessageBox.Show("Problem with the server!");
                }
                catch (FaultException<ArgumentNullFault>)
                {
                    MessageBox.Show("ISBN number is required!");
                }
                catch (FormatException)
                {
                    MessageBox.Show("The format of an argument/arguments is invalid!");
                }
                catch (FaultException<ArgumentFault>)
                {
                    MessageBox.Show("Wrong or missing parameter / parameters!");
                }
                catch (FaultException<IndexOutOfRangeFault>)
                {
                    MessageBox.Show("Wrong ISBN code!");
                }
                catch (FaultException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("You need to login first!");
        }

        private void buttonDiscountByAuthor_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                try
                {                  
                   if( !(client.DiscountByAuthor(user, textBoxAuthor.Text, int.Parse(textBoxPricePercentage.Text))))
                    MessageBox.Show("Author not found in database!");
                    bgWorker.RunWorkerAsync();
                }
                catch (EndpointNotFoundException)
                {
                    MessageBox.Show("Problem with the server!");
                }
                catch (FaultException<ArgumentNullFault>)
                {
                    MessageBox.Show("Author is required!");
                }
                catch (FormatException)
                {
                    MessageBox.Show("The format of an argument/arguments is invalid!");
                }
                catch (FaultException<ArgumentFault>)
                {
                    MessageBox.Show("Wrong or missing parameter / parameters!");
                }
                catch (FaultException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("You need to login first!");
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var formLogin = new formLogin();
            formLogin.ShowDialog();
            if (formLogin.textBoxUsername.Text != "" && formLogin.textBoxPassword.Text != "")
            {
                try
                {
                    this.client = new MyBookshopServiceClient();
                    this.user = client.Login(formLogin.textBoxUsername.Text, formLogin.textBoxPassword.Text);
                    buttonLogin.Enabled = false;
                    buttonLogout.Enabled = true;
                    dataGridViewBooks.Show();
                    Loading();
                    bgWorker.RunWorkerAsync();
                }
                catch (FaultException<UnsuccessfullLoginFault>)
                {
                    MessageBox.Show("Unsuccessful login!");
                }
                catch (Exception ex)
                {
                    buttonLogin.Enabled = true;
                    buttonLogout.Enabled = false;
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                try
                {
                    bool logoutResult = client.Logout(user);
                    if (logoutResult)
                    {
                        user = null;
                        buttonLogin.Enabled = true;
                        buttonLogout.Enabled = false;
                        dataGridViewBooks.Hide();
                        textBoxISBN.Text = string.Empty;
                        textBoxAuthor.Text = string.Empty;
                        textBoxTitle.Text = string.Empty;
                        textBoxPublicationDate.Text = string.Empty;
                        textBoxPrice.Text = string.Empty;
                        textBoxInstock.Text = string.Empty;
                        textBoxPricePercentage.Text = string.Empty;
                    }
                }
                catch (FaultException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
