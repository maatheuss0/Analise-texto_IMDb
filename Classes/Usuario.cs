using System;
using POOOC.Interfaces;

namespace POOOC.Classes
{
    public class Usuario : IUsuario
    {
        private int Codigo;
        private string Nome;
        private string Email;
        private string Senha;
        private DateTime DataCadastro;
        public Usuario()
        {
        }
        public void NovoUsuario(int _Codigo, string _Nome, string _Email, string _Senha)
        {
            Codigo = _Codigo;
            Nome = _Nome;
            Email = _Email;
            Senha = _Senha;
            DataCadastro = DateTime.Now;
        }
        public string Cadastrar(Usuario usuario)
        {
            return "Usuário cadastrado!";
        }

        public string Deletar(Usuario usuario)
        {
            usuario.Codigo = 0;
            usuario.Nome = null;
            usuario.Email = null;
            usuario.Senha = null;

            return "Usuario Deletado";
        }
    }
}