using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Library;

namespace DataAccessLayer.Library
{
    public class Repository
    {
        IUserDAO _userDao;
        IBookDAO _bookDao;
        IReservationDAO _reservationDao;
        public Repository(IUserDAO userDao, IBookDAO bookDao, IReservationDAO reservationDAO)
        {
            this._userDao = userDao;
            this._bookDao = bookDao;
            this._reservationDao = reservationDAO;
        }

        public void UpdateBookByiD(int id, Book book) => _bookDao.Update(id, book);

        public List<User> GetAllUsers() => _userDao.Read();

        public User GetUserById(int id) => _userDao.GetElementById(id);

        public Book GetBookById(int id) => _bookDao.GetElementById(id);

        public List<Book> GetAllBooks() => _bookDao.Read();

        public void AddBook(Book book) => _bookDao.Create(book);

        public void DeleteReservation(int reservationId) => _reservationDao.Delete(reservationId);

        public void UpdateReservation(int id, Reservation reservation) => _reservationDao.Update(id, reservation);

        public void AddReservation(Reservation reservation) => _reservationDao.Create(reservation);

        public List<Reservation> GetAllReservations() => _reservationDao.Read();

        public void DeleteBook(int id) => _bookDao.Delete(id);
    }
}
