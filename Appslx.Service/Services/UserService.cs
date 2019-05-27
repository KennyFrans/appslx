using Appslx.Core.Models;
using Appslx.Repository.Base;
using Appslx.Repository.Users;
using Appslx.Service.Base;
using System.Collections.Generic;

namespace Appslx.Service.Services
{
    public interface IUserService:IEntityService<User>
    {
        User GetById(int id);
        List<int> FindRole(int userid);
    }
    public class UserService:EntityService<User>,IUserService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork):base(unitOfWork, userRepository)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public List<int> FindRole(int userid)
        {
            return _userRepository.FindRole(userid);
        }
    }
}
