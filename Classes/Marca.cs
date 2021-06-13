using System;
using System.Collections.Generic;
using POOOC.Interfaces;

namespace POOOC.Classes
{
    public class Marca : IMarca
    {

        public int CodigoMarca;

        public string NomeMarca;

        private DateTime DataCadastro;

        public List<Marca> ListaMarcas = new List<Marca>();

        public void Valores(int _CodigoMarca, string _Nomemarca)
        {
            CodigoMarca = _CodigoMarca;
            NomeMarca = _Nomemarca;
            DataCadastro = DateTime.Now;
        }
        public string Cadastrar(Marca marca)
        {

            ListaMarcas.Add(marca);

            return "Marca Cadastrada Com Sucesso";
        }

        public string Deletar(Marca marca)
        {
            ListaMarcas.Remove(marca);

            return "Marca excluída com sucesso!";
        }

        public void Listar()
        {
            foreach (Marca item in ListaMarcas)
            {
                Console.WriteLine($@"{item.CodigoMarca} - {item.NomeMarca}");
            }
        }
    }
}
