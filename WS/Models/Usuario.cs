using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WS.Models
{
    [Table("Usuario", Schema = "Login")]
    public class Usuario
    {
        [Key]
        public Int32 IdUsuario { get; set; }
        public String Login { get; set; }
        public String Senha { get; set; }
        public String Nome { get; set; }
        public Byte IdCulture { get; set; }
        public Int16 IdPais { get; set; }
        public Int32 IdGMT { get; set; }
		public String CodigoAtivacao { get; set; }
		public DateTime? ExpiracaoAtivacao { get; set; }
		public Boolean IsHorarioVerao { get; set; }
		public Boolean IsTrocarSenha { get; set; }
		public Int32 IterationCount { get; set; }
		public Boolean IsAtivo { get; set; }
		public Double Correcao { get; set; }
		public String Culture { get; set; }
		public Int32 IdCentral { get; set; }
		public Int32 IdCliente { get; set; }
		public DateTime DataInicio { get; set; }
		public DateTime DataFim { get; set; }
		public String Hashcode { get; set; }
        [Timestamp]
        public Byte[] ConsecutiveErrors { get; set; }
        public DateTime? DataBloqueio { get; set; }
    }
}
