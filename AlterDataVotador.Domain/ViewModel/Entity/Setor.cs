using AlterDataVotador.Domain.ViewModel.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlterDataVotador.Domain.ViewModel.Entity
{
    public class Setor : Entities
    {
        public Setor() { }

        public Setor(String nome, String nomeGerente, Guid? id = null)
        {
            IdSetor = id ?? IdSetor;
            Nome = nome;
            NomeGerente = nomeGerente;
        }

        public String Nome { get; set; }
        public String NomeGerente { get; set; }
    }
}
