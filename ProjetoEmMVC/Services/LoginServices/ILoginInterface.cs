using ProjetoEmMVC.Dto;
using ProjetoEmMVC.Models;

namespace ProjetoEmMVC.Services.LoginServices
{
    public interface ILoginInterface
    {
        Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioRegisterDto usuarioRegisterDto);
        Task<ResponseModel<UsuarioModel>> Login(UsuarioLoginDto loginDto);
    }
}
