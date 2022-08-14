using Base.Modules.Companies.DAL.Exceptions.Company;
using Base.Modules.Companies.Domain.DTO.Company;
using Base.Modules.Companies.Domain.IServices;
using Base.Modules.Companies.Domain.Mappings;
using Microsoft.EntityFrameworkCore;
using Base.Modules.Companies.DAL.Database;
namespace Base.Modules.Companies.DAL.Services
{
    public class CompaniesService : ICompaniesService
    {
        private readonly CompaniesDbContext _dbContext;

       public CompaniesService(CompaniesDbContext dbContext)
        {
            _dbContext = dbContext;
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
            }
        }
    }
}
