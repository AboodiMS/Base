using Base.Modules.Users.DAL.Database;
using Base.Modules.Users.Domain.DTO.CustomPower;
using Base.Modules.Users.Domain.Entities;
using Base.Modules.Users.Domain.IServices;
using Base.Shared.Helper101;
using Base.Shared.Time;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Modules.Users.DAL.Services
{
    public class CustomPowerService : ICustomPowersService
    {

        private readonly UsersDbContext _dbContext;
        private readonly IClock _clock;
        private readonly ILogger<CustomPowerService> _logger;

        public CustomPowerService(UsersDbContext dbContext,
            IClock clock,
            ILogger<CustomPowerService> logger)
        {
            _dbContext = dbContext;
            _clock = clock;
            _logger = logger;
        }

        public Task<GetCustomPowerResponseDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<GetCustomPowerDetailsResponseDto> GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<TreePower> GetTreePowers()
        {
            List<TreePower> all = _dbContext.TreePowers.Include(x => x.Parent).ToList();
            TreeExtensions.ITree<TreePower> virtualRootNode = all.ToTree((parent, child) => child.ParentCodeName == parent.CodeName);
            List<TreeExtensions.ITree<TreePower>> rootLevelFoldersWithSubTree = virtualRootNode.Children.ToList();
            List<TreeExtensions.ITree<TreePower>> flattenedListOfFolderNodes = virtualRootNode.Children.Flatten(node => node.Children).ToList();
            // Each Folder entity can be retrieved via node.Data property:
            TreeExtensions.ITree<TreePower> folderNode = flattenedListOfFolderNodes.First(node => node.Data.CodeName == "companies-module");
            TreePower folder = folderNode.Data;
            int level = folderNode.Level;
            bool isLeaf = folderNode.IsLeaf;
            bool isRoot = folderNode.IsRoot;
            ICollection<TreeExtensions.ITree<TreePower>> children = folderNode.Children;
            TreeExtensions.ITree<TreePower> parent = folderNode.Parent;
            var parents = TreeExtensions.GetParents(folderNode);
            return parents;
        }

    }
}
