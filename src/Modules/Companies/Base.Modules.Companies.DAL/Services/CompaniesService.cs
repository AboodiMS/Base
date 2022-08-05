using Base.Modules.Companies.DAL.Exceptions.Company;
using Base.Modules.Companies.Domain.DTO.Company;
//using Base.Modules.Companies.Domain.Events.Company;
using Base.Modules.Companies.Domain.IServices;
using Base.Modules.Companies.Domain.Mappings;
using Base.Shared.Messaging;
using Base.Shared.Time;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Base.Modules.Companies.DAL.Database;

namespace Base.Modules.Companies.DAL.Services
{
    public class CompaniesService : ICompaniesService
    {
        private readonly CompaniesDbContext _dbContext;
        //private readonly IMessageBroker _messageBroker;
        private readonly IClock _clock;
        private readonly ILogger<CompaniesService> _logger;

       public CompaniesService(CompaniesDbContext dbContext, 
           //IMessageBroker messageBroker,
           IClock clock,
                         ILogger<CompaniesService> logger)
        {
            _dbContext = dbContext;
            //_messageBroker = messageBroker;
            _clock = clock;
            _logger = logger;
        }

        public async Task<GetCompanyResponseDto> GetCompany(Guid id)
        {
            var entity = await _dbContext.Companies.SingleOrDefaultAsync(x => x.Id == id);
            if (entity is null)
                throw new CompanyNotFoundException(id);
            else
                return entity.AsDto();
        }

        public async Task Update(UpdateCompanyRequestDto dto)
        {
            var entity = await _dbContext.Companies.SingleOrDefaultAsync(x => x.Id == dto.Id);
            if (entity is null)
                throw new CompanyNotFoundException(dto.Id);
            else
            {
                _dbContext.Companies.Update(dto.AsEntity(entity));
                await _dbContext.SaveChangesAsync();
                //await _messageBroker.PublishAsync(new CompanyUpdated(dto.Id, dto.Name, dto.CompanyWork));
                _logger.LogInformation($"Updated the company with ID: '{dto.Id}'.");
            }

        }

        public async Task UpdateActiveSections(UpdateActiveSectionsCompanyRequestDto dto)
        {
            var entity = await _dbContext.Companies.SingleOrDefaultAsync(x => x.Id == dto.Id);
            if (entity is null)
                throw new CompanyNotFoundException(dto.Id);
            else
            {
                if (dto.ActiveSections is null)
                    throw new InvalidCompanyActiveSectionsException();
                _dbContext.Companies.Update(dto.AsEntity(entity));
                await _dbContext.SaveChangesAsync();
                //await _messageBroker.PublishAsync(new CompanyUpdateActiveSections(dto.Id,dto.ActiveSections));
                _logger.LogInformation($"Updated the company active sections with ID: '{dto.Id}'.");
            }
        }
    }
}
