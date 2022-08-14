using Base.Modules.Users.DAL.Database;
using Base.Modules.Users.Domain.Entities;
using Base.Modules.Users.Domain.IServices;
using Base.Shared.Helper101;
using Microsoft.EntityFrameworkCore;

namespace Base.Modules.Users.DAL.Services
{
    public class TreePowesService : ITreePowesService
    {
        private readonly UsersDbContext _dbContext;
    

        public TreePowesService(UsersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TreePower> GetAsTreeAsync()
        {
            List<TreePower> all = await _dbContext.TreePowers.Include(x => x.Parent).ToListAsync();
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
            return parents[0];
        }
    }
}
