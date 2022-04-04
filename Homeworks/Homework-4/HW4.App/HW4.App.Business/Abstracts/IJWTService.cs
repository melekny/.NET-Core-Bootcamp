using HW4.App.Business.DTOs;

namespace HW4.App.Business.Abstracts
{
    public interface IJWTService
    {
        TokenDto Authenticate(UserDto user);
    }
}