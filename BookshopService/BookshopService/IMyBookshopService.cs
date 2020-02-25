using BookshopDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BookshopService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMyBookshopService" in both code and config file together.
    [ServiceContract]
    public interface IMyBookshopService
    {
        [OperationContract]
        [FaultContract(typeof(UnsuccessfullLoginFault))]
        User Login(string username, string password);

        [OperationContract]
        bool Logout(User user);

        [OperationContract]
        List<BookModel> ListAll(User user);

        [OperationContract]
        [FaultContract(typeof(ArgumentFault))]
        [FaultContract(typeof(ArgumentNullFault))]
        [FaultContract(typeof(IndexOutOfRangeFault))]
        BookModel ListByIsbn(User user, string isbn);

        [OperationContract]
        [FaultContract(typeof(ArgumentFault))]
        bool Insert(User user, string isbn, string title, string author, string publicationDate, int price, int instock);

        [OperationContract]
        [FaultContract(typeof(ArgumentFault))]
        [FaultContract(typeof(ArgumentNullFault))]
        [FaultContract(typeof(IndexOutOfRangeFault))]
        bool Update(User user, BookModel bookModel, int price, int instock);

        [OperationContract]
        [FaultContract(typeof(ArgumentFault))]
        [FaultContract(typeof(ArgumentNullFault))]
        [FaultContract(typeof(IndexOutOfRangeFault))]
        bool Delete(User user, string isbn);

        [OperationContract]
        [FaultContract(typeof(ArgumentFault))]
        [FaultContract(typeof(IndexOutOfRangeFault))]
        bool DiscountAll(User user, int pricePercentage);

        [OperationContract]
        [FaultContract(typeof(ArgumentFault))]
        [FaultContract(typeof(ArgumentNullFault))]
        [FaultContract(typeof(IndexOutOfRangeFault))]
        bool DiscountOne(User user, string isbn, int pricePercentage);

        [OperationContract]
        [FaultContract(typeof(ArgumentFault))]
        [FaultContract(typeof(ArgumentNullFault))]
        bool DiscountByAuthor(User user, string author, int pricePercentage);
    }
}
