using Base.Modules.Companies.DAL.Exceptions.Company;
using Base.Modules.Companies.Domain.DTO.Company;
using Base.Modules.Companies.Domain.IServices;
using Base.Modules.Companies.Domain.Mappings;
using Microsoft.EntityFrameworkCore;
using Base.Modules.Companies.DAL.Database;
using Base.Modules.Companies.Domain.Entities;
using System.Linq;
using Base.Shared.Exceptions.ModulesExceptions;

namespace Base.Modules.Companies.DAL.Services
{
    public class CompaniesService : ICompaniesService
    {
        private readonly CompaniesDbContext _dbContext;

        public CompaniesService(CompaniesDbContext dbContext)
        {
           _dbContext = dbContext;
        }

        private async Task IsNameExist(Guid id,string name)
        {
            var resulte= await _dbContext.Companies.AnyAsync(c => c.Name == name && c.Id != id);
            if(resulte)
                throw new ExistException(new ExceptionData
                {
                    TableName= "Companies",
                    PropertieName = "Name",
                    PropertieValue=name
                });
        }
        private async Task<Company> getById(Guid id)
        {
            var entity=await _dbContext.Companies.SingleAsync(a=>a.Id == id && a.IsDeleted ==false);
            if(entity==null)
                throw new NotFoundException(new ExceptionData
                {
                    TableName = "Companies",
                    PropertieName = "Id",
                    PropertieValue = id.ToString()
                });
            return entity;
        }
        public async Task Create(CreateCompanyRequestDto dto)
        {
            await IsNameExist(dto.Id, dto.Name);
            _dbContext.Companies.Add(dto.AsEntity());
            await _dbContext.SaveChangesAsync();
        }
        public async Task Delete(Guid id, Guid Companyid)
        {
            var entity = await getById(id);
            entity.IsDeleted = true;
            entity.LastUpdateDate=DateTimeOffset.Now;
            entity.LastUpdateCompanyId=Companyid;
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<GetCompanyResponseDto>> GetAll()
        {
            return await _dbContext.Companies.Where(x => x.IsDeleted == false).Select(a=>a.AsDto()).ToListAsync();
        }
        public async Task<GetCompanyDetailsResponseDto> GetById(Guid id)
        {
            var entity = await getById(id);
            return entity.AsDto(await _dbContext.Sections.ToListAsync());
        }
        public async Task Update(UpdateCompanyRequestDto dto)
        {
            await IsNameExist(dto.Id, dto.Name);
            var entity = await getById(dto.Id);
            dto.AsEntity(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateActiveSections(UpdateActiveSectionsCompanyRequestDto dto)
        {
            var entity = await getById(dto.Id);
            dto.AsEntity(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Restore(Guid id, Guid Companyid)
        {
            var entity = await getById(id);
            entity.IsDeleted = false;
            entity.LastUpdateDate = DateTimeOffset.Now;
            entity.LastUpdateCompanyId = Companyid;
            await _dbContext.SaveChangesAsync();

        }

        public Task ActiveOneMonth(Guid id, Guid Companyid)
        {
            throw new NotImplementedException();
        }
    }
}
