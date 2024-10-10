using ProjetoEmMVC.Models;

namespace ProjetoEmMVC.Services.SessaoService
{
    public interface ISessaoInterface
    {
        UsuarioModel BuscarSessao();
        void CriarSessao(UsuarioModel usuarioModel);

        void RomoveSessao();
    }
}
