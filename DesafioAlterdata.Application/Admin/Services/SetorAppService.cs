using AlterdataVotador.Application.Admin.Interfaces;
using AlterDataVotador.Domain.Admin.Interfaces;
using AlterDataVotador.Domain.ViewModel;
using AlterDataVotador.Domain.ViewModel.Dto;
using AlterDataVotador.Domain.ViewModel.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlterdataVotador.Application.Admin.Services
{
    public class SetorAppService : ISetorAppService
    {
        private const String _thisClassName = "SetorAppService";
        private readonly ISetorService _setorService;

        public SetorAppService(ISetorService paramSetorService)
        {
            _setorService = paramSetorService;
        }

        public ServiceResult<List<SetorResult>> ListSetor(SetorListParameter paramObj)
        {
            return _setorService.ListSetor(paramObj);
        }

        public ServiceResult<Task<Setor>> InsertSetor(SetorInsertParameter paramObj)
        {
            return _setorService.InsertSetor(paramObj);
        }

        public ServiceResult<Boolean> UpdateSetor(SetorUpdateParameter paramObj)
        {
            return _setorService.UpdateSetor(paramObj);
        }

        public ServiceResult<Boolean> DeleteSetor(SetorDeleteParameter paramObj)
        {
            return _setorService.DeleteSetor(paramObj);
        }
    }
}
