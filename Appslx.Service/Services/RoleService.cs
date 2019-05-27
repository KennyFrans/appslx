using System;
using System.Collections.Generic;
using System.Text;
using Appslx.Core.Models;
using Appslx.Repository.Base;
using Appslx.Repository.Roles;
using Appslx.Service.Base;

namespace Appslx.Service.Services
{
    public interface IRoleService:IEntityService<Role>
    {
        Role GetById(int id);
    }
    public class RoleService:EntityService<Role>,IRoleService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IRoleRepository _roleRepository;
        public RoleService(IUnitOfWork unitOfWork, IRoleRepository roleRepository) : base(unitOfWork, roleRepository)
        {
            _unitOfWork = unitOfWork;
            _roleRepository = roleRepository;
        }

        public Role GetById(int id)
        {
            return _roleRepository.GetById(id);
        }
    }
}
