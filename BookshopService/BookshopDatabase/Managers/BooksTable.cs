using BookshopDatabase;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace BookshopDatabase.Managers
{
    public class BooksTable
    {
        OracleConnection GetOracleConnection()
        {
            OracleConnection oc = new OracleConnection();
            string connectionstring = @"Data Source=193.225.33.71;User Id=DNOVC0;Password=aA123456;";
            oc.ConnectionString = connectionstring;
            return oc;
        }
        #region Select
        public List<BookModel> Select()
        {
            try
            {
                List<BookModel> records = new List<BookModel>();

                OracleConnection oc = GetOracleConnection();
                oc.Open();

                OracleCommand command = new OracleCommand()
                {
                    CommandType = System.Data.CommandType.Text,
                    CommandText = "SELECT * FROM books"
                };

                command.Connection = oc;

                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BookModel book = new BookModel();
                    book.Isbn = reader["isbn"].ToString();
                    book.Title = reader["title"].ToString();
                    book.Author = reader["author"].ToString();
                    book.PublicationDate = DateTime.Parse(reader["publication_date"].ToString()).ToString("yyyy");
                    book.Price = int.Parse(reader["price"].ToString());
                    book.DiscountPrice = int.Parse(reader["discount_price"].ToString());
                    book.Instock = int.Parse(reader["instock"].ToString());

                    records.Add(book);
                }
                oc.Close();
                return records;
            }
            catch (Exception ex)
            {
                throw new FaultException(new FaultReason(ex.Message));
            }
        }
        #endregion

        #region Delete
        public int Delete(BookModel record)
        {
            OracleConnection oc = GetOracleConnection();
            oc.Open();

            OracleTransaction ot = oc.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            try
            {

                OracleCommand command = new OracleCommand()
                {
                    CommandType = System.Data.CommandType.Text,
                    CommandText = "DELETE FROM books WHERE isbn = :isbn"
                };

                OracleParameter isbnParameter = new OracleParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = ":isbn",
                    Direction = System.Data.ParameterDirection.Input,
                    Value = record.Isbn
                };
                command.Parameters.Add(isbnParameter);
                command.Connection = oc;
                command.Transaction = ot;

                int affectedRows = 0;
                affectedRows = command.ExecuteNonQuery();
                ot.Commit();
                return affectedRows;
            }
            catch (OracleException ex)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault(ex.Message));
            }
            catch (Exception ex)
            {
                ot.Rollback();
                throw new FaultException(new FaultReason(ex.Message));
            }
        }
        #endregion

        #region Insert
        public int Insert(BookModel record)
        {
            OracleConnection oc = GetOracleConnection();
            oc.Open();

            OracleTransaction ot = oc.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            OracleCommand command = new OracleCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "INSERT INTO books VALUES (:isbn, :title, :author, TO_DATE(:publication_date, 'YYYY'), :price, :discount_price, :instock)"
            };

            #region Parameters
            OracleParameter isbnParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = ":isbn",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Isbn
            };
            command.Parameters.Add(isbnParameter);

            OracleParameter titleParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = ":title",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Title
            };
            command.Parameters.Add(titleParameter);

            OracleParameter authorParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = ":author",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Author
            };
            command.Parameters.Add(authorParameter);

            OracleParameter publicationDateParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = ":publication_date",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.PublicationDate
            };
            command.Parameters.Add(publicationDateParameter);

            OracleParameter priceParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.Int32,
                ParameterName = ":price",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Price
            };
            command.Parameters.Add(priceParameter);

            OracleParameter priceDiscountParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.Int32,
                ParameterName = ":discount_price",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.DiscountPrice
            };
            command.Parameters.Add(priceDiscountParameter);

            OracleParameter instockParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.Int32,
                ParameterName = ":instock",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Instock
            };
            command.Parameters.Add(instockParameter);
            #endregion
            command.Connection = oc;
            command.Transaction = ot;

            int affectedRows = 0;
            try
            {
                affectedRows = command.ExecuteNonQuery();
                ot.Commit();
            }
            catch (OracleException ex)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault(ex.Message));
            }
            catch (Exception ex)
            {
                ot.Rollback();
                throw new FaultException(new FaultReason(ex.Message));
            }
            return affectedRows;
        }
        #endregion

        #region Update
        public int Update(BookModel record, int price, int instock)
        {
            OracleConnection oc = GetOracleConnection();
            oc.Open();

            OracleTransaction ot = oc.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            OracleCommand command = new OracleCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "UPDATE books SET price = :price, instock = :instock WHERE isbn = :isbn"
            };

            #region Parameters

            OracleParameter priceParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.Int32,
                ParameterName = ":price",
                Direction = System.Data.ParameterDirection.Input,
                Value = price
            };
            command.Parameters.Add(priceParameter);

            OracleParameter instockParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.Int32,
                ParameterName = ":instock",
                Direction = System.Data.ParameterDirection.Input,
                Value = instock
            };
            command.Parameters.Add(instockParameter);

            OracleParameter isbnParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = ":isbn",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Isbn
            };
            command.Parameters.Add(isbnParameter);

            #endregion
            command.Connection = oc;
            command.Transaction = ot;

            int affectedRows = 0;
            try
            {
                affectedRows = command.ExecuteNonQuery();
                ot.Commit();
            }
            catch (OracleException ex)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault(ex.Message));
            }
            catch (Exception ex)
            {
                ot.Rollback();
                throw new FaultException(new FaultReason(ex.Message));
            }
            return affectedRows;
        }
        #endregion

        #region ListByISBN
        public BookModel ListByISBN(string isbn)
        {
            try
            {
                if (isbn == string.Empty)
                    throw new ArgumentNullException();

                if (!(BookModel.IsValidIsbn10(isbn) || BookModel.IsValidIsbn13(isbn)))
                    throw new ArgumentException();

                BookModel record = new BookModel();
                OracleConnection oc = GetOracleConnection();
                oc.Open();

                OracleCommand command = new OracleCommand()
                {
                    CommandType = System.Data.CommandType.Text,
                    CommandText = "SELECT * FROM books WHERE isbn = :isbn"
                };

                OracleParameter isbnParameter = new OracleParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = ":isbn",
                    Direction = System.Data.ParameterDirection.Input,
                    Value = isbn
                };
                command.Parameters.Add(isbnParameter);

                command.Connection = oc;

                OracleDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BookModel book = new BookModel();
                    book.Isbn = reader["isbn"].ToString();
                    book.Title = reader["title"].ToString();
                    book.Author = reader["author"].ToString();
                    book.PublicationDate = DateTime.Parse(reader["publication_date"].ToString()).ToString("yyyy");
                    book.Price = int.Parse(reader["price"].ToString());
                    book.Instock = int.Parse(reader["instock"].ToString());

                    record = book;
                }
                oc.Close();

                return record;
            }
            catch (OracleException ex)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault(ex.Message));
            }
            catch (ArgumentNullException ex)
            {
                throw new FaultException<ArgumentNullFault>(new ArgumentNullFault(ex.Message));
            }
            catch (ArgumentException ex)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault(ex.Message), new FaultReason(ex.Message));
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new FaultException<IndexOutOfRangeFault>(new IndexOutOfRangeFault(ex.Message));
            }
            catch (Exception ex)
            {
                throw new FaultException(new FaultReason(ex.Message));
            }
        }
        #endregion

        #region DiscountAll
        public int DiscountAll(int percentage)
        {
            OracleConnection oc = GetOracleConnection();
            oc.Open();

            OracleTransaction ot = oc.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            try
            {
                if (percentage < 0)
                    throw new ArgumentException();

                OracleCommand command = new OracleCommand()
                {
                    CommandType = System.Data.CommandType.Text,
                    CommandText = "UPDATE books SET discount_price = price * (1 - :percentage)"
                };

                OracleParameter PercentageParameter = new OracleParameter()
                {
                    DbType = System.Data.DbType.Double,
                    ParameterName = ":percentage",
                    Direction = System.Data.ParameterDirection.Input,
                    Value = percentage / 100.0
                };
                command.Parameters.Add(PercentageParameter);

                command.Connection = oc;
                command.Transaction = ot;

                int affectedRows = 0;
                affectedRows = command.ExecuteNonQuery();
                ot.Commit();

                return affectedRows;
            }
            catch (OracleException ex)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault(ex.Message));
            }
            catch (ArgumentException ex)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault(ex.Message));
            }
            catch (Exception ex)
            {
                ot.Rollback();
                throw new FaultException(new FaultReason(ex.Message));
            }
        }
        #endregion

        #region DiscountOne
        public int DiscountOne(string isbn, int percentage)
        {
            OracleConnection oc = GetOracleConnection();
            oc.Open();

            OracleTransaction ot = oc.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            try
            {
                if (isbn == string.Empty)
                    throw new ArgumentNullException();

                if (percentage < 0)
                    throw new ArgumentException();


                OracleCommand command = new OracleCommand()
                {
                    CommandType = System.Data.CommandType.Text,
                    CommandText = "UPDATE books SET discount_price = price * (1 - :percentage) WHERE isbn = :isbn"
                };

                OracleParameter PercentageParameter = new OracleParameter()
                {
                    DbType = System.Data.DbType.Double,
                    ParameterName = ":percentage",
                    Direction = System.Data.ParameterDirection.Input,
                    Value = percentage / 100.0
                };

                command.Parameters.Add(PercentageParameter);
                OracleParameter isbnParameter = new OracleParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = ":isbn",
                    Direction = System.Data.ParameterDirection.Input,
                    Value = isbn
                };
                command.Parameters.Add(isbnParameter);

                command.Connection = oc;
                command.Transaction = ot;

                int affectedRows = 0;
                affectedRows = command.ExecuteNonQuery();
                ot.Commit();
                return affectedRows;
            }
            catch (OracleException ex)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault(ex.Message));
            }
            catch (ArgumentNullException ex)
            {
                throw new FaultException<ArgumentNullFault>(new ArgumentNullFault(ex.Message));
            }
            catch (ArgumentException ex)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault(ex.Message));
            }
            catch (Exception ex)
            {
                ot.Rollback();
                throw new FaultException(new FaultReason(ex.Message));
            }
        }
        #endregion

        #region DiscountByAuthor
        public int DiscountByAuthor(string author, int percentage)
        {
            OracleConnection oc = GetOracleConnection();
            oc.Open();

            OracleTransaction ot = oc.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            try
            {
                if (author == string.Empty)
                    throw new ArgumentNullException();

                if (percentage < 0)
                    throw new ArgumentException();    


                OracleCommand command = new OracleCommand()
                {
                    CommandType = System.Data.CommandType.Text,
                    CommandText = "UPDATE books SET discount_price = price * (1 - :percentage) WHERE author = :author"
                };

                OracleParameter PercentageParameter = new OracleParameter()
                {
                    DbType = System.Data.DbType.Double,
                    ParameterName = ":percentage",
                    Direction = System.Data.ParameterDirection.Input,
                    Value = percentage / 100.0
                };
                command.Parameters.Add(PercentageParameter);

                OracleParameter authorParameter = new OracleParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = ":author",
                    Direction = System.Data.ParameterDirection.Input,
                    Value = author
                };
                command.Parameters.Add(authorParameter);

                command.Connection = oc;
                command.Transaction = ot;

                int affectedRows = 0;
                affectedRows = command.ExecuteNonQuery();
                ot.Commit();

                return affectedRows;
            }
            catch (OracleException ex)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault(ex.Message));
            }
            catch (ArgumentNullException ex)
            {
                throw new FaultException<ArgumentNullFault>(new ArgumentNullFault(ex.Message));
            }
            catch (ArgumentException ex)
            {
                throw new FaultException<ArgumentFault>(new ArgumentFault(ex.Message));
            }
            catch (Exception ex)
            {
                ot.Rollback();
                throw new FaultException(new FaultReason(ex.Message));
            }
        }
        #endregion
    }
}
