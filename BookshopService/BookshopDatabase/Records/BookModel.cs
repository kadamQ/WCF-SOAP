 using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BookshopDatabase
{
    [DataContract]
    public class BookModel
    {

        private string isbn;

        public static bool IsValidIsbn10(string isbn)
        {
            try
            {
                bool result = false;
                string isbn10 = isbn;
                if (!string.IsNullOrEmpty(isbn10))
                {
                    if (isbn10.Length != 10 || !int.TryParse(isbn10.Substring(0, isbn10.Length - 1), out int j))
                        result = false;
                    int sum = 0;
                    for (int i = 0; i < 9; i++)
                        sum += int.Parse(isbn10[i].ToString()) * (i + 1);
                    int remainder = sum % 11;
                    if (isbn10[isbn10.Length - 1] == 'X')
                    {
                        result = (remainder == 10);
                    }
                    else if (int.TryParse(isbn10[isbn10.Length - 1].ToString(), out sum))
                    {
                        result = (remainder == int.Parse(isbn10[isbn10.Length - 1].ToString()));
                    }
                }
                return result;
            }
            catch (IndexOutOfRangeException)
            {
                throw new FaultException(new FaultReason("The format of an argument/arguments is invalid!"));
            }
            catch (FormatException)
            {
                throw new FaultException(new FaultReason("The format of an argument/arguments is invalid!"));
            }
        }
        public static bool IsValidIsbn13(string isbn)
        {
            try
            {
                bool result = false;
                string isbn13 = isbn;
                if (!string.IsNullOrEmpty(isbn13))
                {

                    if (isbn13.Length != 13 || !int.TryParse(isbn13, out int k))
                        result = false;

                    int sum = 0;
                    for (int i = 0; i < 12; i++)
                    {
                        sum += int.Parse(isbn13[i].ToString()) * (i % 2 == 1 ? 3 : 1);
                    }
                    int remainder = sum % 10;
                    int checkDigit = 10 - remainder;
                    if (checkDigit == 10) checkDigit = 0;
                    result = (checkDigit == int.Parse(isbn13[12].ToString()));
                }
                return result;
            }
            catch (IndexOutOfRangeException)
            {
                throw new FaultException(new FaultReason("The format of an argument/arguments is invalid!"));
            }
            catch (FormatException)
            {
                throw new FaultException(new FaultReason("The format of an argument/arguments is invalid!"));
            }
        }

        [DataMember]
        public string Isbn
        {
            get
            {
                return isbn;
            }
            set
            {
                if (value.Contains("-")) value = value.Replace("-", "");
                if (IsValidIsbn10(value) || IsValidIsbn13(value))
                    isbn = value;
            }
        }       
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public string PublicationDate { get; set; }
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public int DiscountPrice { get; set; }
        [DataMember]
        public int Instock { get; set; }

        public BookModel()
        {

        }
    }
}
