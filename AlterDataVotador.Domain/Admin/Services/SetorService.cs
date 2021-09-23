using AlterDataVotador.Domain.Admin.Interfaces;
using AlterDataVotador.Domain.Admin.Interfaces.Repositories;
using AlterDataVotador.Domain.ViewModel;
using AlterDataVotador.Domain.ViewModel.Dto;
using AlterDataVotador.Domain.ViewModel.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlterDataVotador.Domain.Admin.Services
{
    public class SetorService : ISetorService
    {
        private ISetorRepository _SetorRepository;

        public SetorService(ISetorRepository paramSetorRepository)
        {
            _SetorRepository = paramSetorRepository;
        }

        public ServiceResult<List<SetorResult>> ListSetor(SetorListParameter paramObj)
        {
            ServiceResult<List<SetorResult>> result = new ServiceResult<List<SetorResult>>();
            result.Data = _SetorRepository.ListSetor(paramObj);
            return result;
        }

        public ServiceResult<Task<Setor>> InsertSetor(SetorInsertParameter paramObj)
        {
            ServiceResult<Task<Setor>> result = new ServiceResult<Task<Setor>>();
            result.Data = _SetorRepository.InsertSetor(paramObj);
            return result;
        }

        public ServiceResult<Boolean> UpdateSetor(SetorUpdateParameter paramObj)
        {
            ServiceResult<Boolean> result = new ServiceResult<Boolean>();
            result.Data = _SetorRepository.UpdateSetor(paramObj);
            return result;
        }

        public ServiceResult<Boolean> DeleteSetor(SetorDeleteParameter paramObj)
        {
            ServiceResult<Boolean> result = new ServiceResult<Boolean>();
            result.Data = _SetorRepository.DeleteSetor(paramObj);
            return result;
        }
    }
}
