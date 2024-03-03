using SisNet.Application.Interfaces;
using SisNet.Domain.Interfaces.Services;
using SisNet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisNet.Application.Services
{
    public class CandidatoApplicationService : ICandidatoApplicationService
    {
        private readonly ICandidatoDomainService candidatoDomainService;

        public void Add(Candidato entity)
        {
            var candidato = new Candidato
            {
                Id = Guid.NewGuid(),
            };


        }

        public void Update(Candidato entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Candidato entity)
        {
            throw new NotImplementedException();
        }

        public List<Candidato> GetAll()
        {
            throw new NotImplementedException();
        }

        public Candidato GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
