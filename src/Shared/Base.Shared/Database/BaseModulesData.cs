﻿
using Base.Shared.Entities;
using Base.Shared.Helper101;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Shared.Database
{
    public static class BaseModulesData
    {
        public static List<ModuleSetting> ModuleSettings { get; set; }=new List<ModuleSetting>();
        public static List<TreePower> TreePowers { get; set; } = new List<TreePower>();


        private static  async void SetTreePowers(DbContext db)
        {
            try
            {
                List<TreePower> treePowers = await db.Set<TreePower>().ToListAsync();
                TreePower row = treePowers.Where(a => a.CodeName.Count(f => (f == '/')) == 1).FirstOrDefault();
                List<TreePower> all = db.Set<TreePower>().Include(x => x.Parent).ToList();
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
                TreePowers.Add(parents[0]);
            }
            catch (Exception ex) { }
        }

        private static async void SetModuleSettings(DbContext db)
        {
            try
            {
                ModuleSettings.Add(await db.Set<ModuleSetting>().FirstOrDefaultAsync());
            }
            catch(Exception ex) { }
        }

        public static  void SetBaseModulesData(DbContext db)
        {
            SetTreePowers(db);
            SetModuleSettings(db);
        }

    }
}