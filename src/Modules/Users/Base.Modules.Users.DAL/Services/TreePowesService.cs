using Base.Modules.Users.DAL.Database;
using Base.Modules.Users.Domain.Entities;
using Base.Modules.Users.Domain.IServices;
using Base.Shared.Database;
using Base.Shared.Entities;
using Base.Shared.Helper101;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Base.Modules.Users.DAL.Services
{
    public class TreePowesService : ITreePowesService
    {
        private readonly UsersDbContext _dbContext;
        private readonly IServiceProvider _serviceProvider;

        public TreePowesService(IServiceProvider serviceProvider,UsersDbContext dbContext)
        {
            _serviceProvider = serviceProvider;
            _dbContext = dbContext;
        }

        private List<DbContext> getBaseDbContexts()
        {
            List<DbContext> baseDbContexts = new List<DbContext>();

            var dbContextTypes = AppDomain.CurrentDomain.GetAssemblies()
                                          .SelectMany(x => x.GetTypes())
                                          .Where(x => typeof(BaseDbContext)
                                          .IsAssignableFrom(x) && !x.IsInterface && x != typeof(DbContext));
            using var scope = _serviceProvider.CreateScope();
            foreach (var dbContextType in dbContextTypes)
            {
                var dbContext = scope.ServiceProvider.GetService(dbContextType) as DbContext;
                if (dbContext is null)
                {
                    continue;
                }
                else
                {
                    baseDbContexts.Add(dbContext);
                }

            }
            return baseDbContexts;
        }

        private TreePower getTreePowers(List<TreePower> db)
        {
                var row =  db.Where(a => a.CodeName.Count(f => (f == '/')) == 1).FirstOrDefault();
                List<TreePower> all =  db.Select(x => x.Parent).ToList();
                TreeExtensions.ITree<TreePower> virtualRootNode = all.ToTree((parent, child) => child.ParentCodeName == parent.CodeName);
                List<TreeExtensions.ITree<TreePower>> rootLevelFoldersWithSubTree = virtualRootNode.Children.ToList();
                List<TreeExtensions.ITree<TreePower>> flattenedListOfFolderNodes = virtualRootNode.Children.Flatten(node => node.Children).ToList();
                // Each Folder entity can be retrieved via node.Data property:
                TreeExtensions.ITree<TreePower> folderNode = flattenedListOfFolderNodes.First(node => node.Data.CodeName == row?.CodeName);
                TreePower folder = folderNode.Data;
                int level = folderNode.Level;
                bool isLeaf = folderNode.IsLeaf;
                bool isRoot = folderNode.IsRoot;
                ICollection<TreeExtensions.ITree<TreePower>> children = folderNode.Children;
                TreeExtensions.ITree<TreePower> parent = folderNode.Parent;
                var parents = TreeExtensions.GetParents(folderNode);
                return parents[0];
        }

        private async Task<List<TreePower>> getAllTreePowers()
        {
            //List<TreePower> treePowers = new List<TreePower>();
            //var Dbs = getBaseDbContexts();
            //foreach (var db in Dbs)
            //{
            //    treePowers.Add(await getTreePowers(db));
            //}
            try
            {
                //var a = new List<TreePower>();
                //a.Add(getTreePowers(BaseTreePowers.TreePowers));
                return BaseModulesData.TreePowers;
            }
            catch(Exception ex)
            {
                throw ex;
            }
          
        }

        public async Task<List<TreePower>> GetAsTreeAsync()
        {
            return await getAllTreePowers();
        }
    }
}
