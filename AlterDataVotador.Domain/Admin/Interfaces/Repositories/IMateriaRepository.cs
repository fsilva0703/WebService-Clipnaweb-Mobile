using AlterDataVotador.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlterDataVotador.Domain.Admin.Interfaces.Repositories
{
    public interface IMateriaRepository
    {
        List<MateriaResult> ListMateria(MateriaParameter filtro, string ClientId);
    }
}