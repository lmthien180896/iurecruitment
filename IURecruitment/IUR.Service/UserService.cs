using IUR.Data.Infrastructure;
using IUR.Data.Repositories;
using IUR.Model.Models;
using System.Collections.Generic;

namespace IUR.Service
{
    public interface IUserService
    {
        User Add(User user);

        User GetById(int id);

        User GetByUsername(string username);

        User Delete(int id);

        IEnumerable<User> GetAll();

        void Update(User user);

        void SaveChanges();

        int CheckLogin(string username, string hashedPassword);

        bool CheckUsername(string username);
    }

    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;
        }

        public User Add(User user)
        {
            return _userRepository.Add(user);
        }

        public int CheckLogin(string username, string hashedPassword)
        {
            var user = _userRepository.GetSingleByCondition(x => x.Username == username && x.HashedPassword == hashedPassword);
            if (user != null)
                return user.ID;
            else
                return -1;
        }

        public bool CheckUsername(string username)
        {
            var isExisted = _userRepository.CheckContains(x => x.Username == username);
            return isExisted;
        }

        public User Delete(int id)
        {
            return _userRepository.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetSingleById(id);
        }

        public User GetByUsername(string username)
        {
            return _userRepository.GetSingleByCondition(x => x.Username == username);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }
    }
}