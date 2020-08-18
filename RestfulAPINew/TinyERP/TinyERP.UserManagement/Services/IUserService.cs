using System;
using TinyERP.UserManagement.Share.Dtos;

namespace TinyERP.UserManagement.Services
{
    public interface IUserService
    {
        Guid Create(CreateAuthorDto request);
        AuthorInfo GetAuthorInfo(Guid id);
    }
}
