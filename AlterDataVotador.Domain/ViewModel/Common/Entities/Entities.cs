using Flunt.Notifications;
using System;
using System.ComponentModel.DataAnnotations;

namespace AlterDataVotador.Domain.ViewModel.Common.Entities
{
    public abstract class Entities
    {
        public Entities()
        {
            IdSetor = Guid.NewGuid();
        }
        [Key]
        public Guid IdSetor { get; set; }
    }
}
