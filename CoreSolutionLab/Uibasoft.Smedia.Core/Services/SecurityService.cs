using System.Threading.Tasks;
using Uibasoft.Smedia.Core.Entities;
using Uibasoft.Smedia.Core.Interfaces;

namespace Uibasoft.Smedia.Core.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SecurityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Security> GetLoginByCredentials(UserLogin userLogin)
        {
            return await _unitOfWork.RepoSecurities.GetLoginByCredential(userLogin);
        }

        public async Task RegisterUser(Security security)
        {
            await _unitOfWork.RepoSecurities.Add(security);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}
