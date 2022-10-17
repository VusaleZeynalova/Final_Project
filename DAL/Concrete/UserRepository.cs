using DAL.GenericRepositories;
using DAL.Abstract;
using DAL.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CoreEntities.Concrete;

namespace DAL.Concrete
{
    public class UserRepository : EntityRepositoryBase<User>, IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;

        }
        public List<OperationClaim> GetClaims(User user)
        {

            var result = from operationClaim in _dataContext.OperationClaims
                         join userOperationClaim in _dataContext.UserOperationClaims
                             on operationClaim.OperationClaimId equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.UserId
                         select new OperationClaim { OperationClaimId = operationClaim.OperationClaimId, Name = operationClaim.Name };
            return result.ToList();


        }
    }
}
