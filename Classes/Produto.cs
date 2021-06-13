using System;
using System.Collections.Generic;
using POOOC.Interfaces;

namespace POOOC.Classes
{
    public class Produto : IProduto
    {
        public int Codigo;
        private string NomeProduto;
        private float Preco;
        private DateTime DataCadastro = DateTime.Now;
        private string marca;
        private string CadastradoPor;
        public List<Produto> ListaProdutos = new List<Produto>();
        public void Valores(int _Codigo, string _NomeProduto, float _Preco, string _marca, string _CadastradoPor)
        {
            Codigo = _Codigo;
            NomeProduto = _NomeProduto;
            Preco = _Preco;
            marca = _marca;
            CadastradoPor = _CadastradoPor;
        }
        public string Cadastrar(Produto produto)
        {
            ListaProdutos.Add(produto);

            return "Produto cadastrado com sucesso";
        }

        public string Deletar(Produto produto)
        {
            ListaProdutos.Remove(produto);

            return "Produto removido com sucesso";
        }

        public void Listar()
        {
            foreach (Produto p in ListaProdutos)
            {
                Console.WriteLine($@"
Nome: {p.NomeProduto}
Preço: {p.Preco:C2}
Data de Cadastro: {p.DataCadastro}
Codigo: {p.Codigo}
Marca: {p.marca}
Cadastrado por {p.CadastradoPor}");
            }
        }
    }
}