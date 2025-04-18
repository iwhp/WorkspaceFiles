using System.Collections.Generic;
using System.ComponentModel.Composition;
using EnvDTE;
using Microsoft.Internal.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.Utilities;

namespace WorkspaceFiles
{
    [Export(typeof(IAttachedCollectionSourceProvider))]
    [Name(nameof(WorkspaceItemNode))]
    [Order(Before = HierarchyItemsProviderNames.Contains)]
    internal class WorkspaceItemSourceProvider : IAttachedCollectionSourceProvider
    {
        private WorkspaceRootNode _rootNode;
        private readonly DTE _dte;

        public WorkspaceItemSourceProvider()
        {
            _dte = VS.GetRequiredService<DTE, DTE>();
            VS.Events.SolutionEvents.OnBeforeCloseSolution += OnBeforeCloseSolution;
        }

        private void OnBeforeCloseSolution()
        {
            _rootNode?.Dispose();
            _rootNode = null;
        }

        public IEnumerable<IAttachedRelationship> GetRelationships(object item)
        {
            // Checking if the item is the solution node
            if (item is IVsHierarchyItem hierarchyItem && HierarchyUtilities.IsSolutionNode(hierarchyItem.HierarchyIdentity))
            {
                yield return Relationships.Contains;
            }
        }

        public IAttachedCollectionSource CreateCollectionSource(object item, string relationshipName)
        {
            if (relationshipName == KnownRelationships.Contains)
            {
                if (item is IVsHierarchyItem hierarchyItem && HierarchyUtilities.IsSolutionNode(hierarchyItem.HierarchyIdentity))
                {
                    if (!string.IsNullOrEmpty(_dte?.Solution?.FullName))
                    {
                        return _rootNode ??= new WorkspaceRootNode(_dte);
                    }
                }
                else if (item is WorkspaceItemNode node)
                {
                    return node;
                }
            }

            return null;
        }
    }
}
