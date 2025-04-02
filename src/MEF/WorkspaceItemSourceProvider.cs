using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.Internal.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.Utilities;

namespace WorkspaceFiles
{
    [Export(typeof(IAttachedCollectionSourceProvider))]
    [Name(nameof(WorkspaceItemNode))]
    internal class WorkspaceItemSourceProvider : IAttachedCollectionSourceProvider
    {
        private WorkspaceRootNode _rootNode;

        public WorkspaceItemSourceProvider()
        {
            Microsoft.VisualStudio.Shell.Events.SolutionEvents.OnBeforeCloseSolution += OnBeforeCloseSolution;
        }

        private void OnBeforeCloseSolution(object sender, EventArgs e)
        {
            _rootNode?.Dispose();
            _rootNode = null;
        }

        public IEnumerable<IAttachedRelationship> GetRelationships(object item)
        {
            // Checking if the item is the solution node
            if (item is IVsHierarchyItem hierarchyItem && hierarchyItem.Parent == null)
            {
                yield return Relationships.Contains;
            }
        }

        public IAttachedCollectionSource CreateCollectionSource(object item, string relationshipName)
        {
            if (relationshipName == KnownRelationships.Contains)
            {
                if (item is IVsHierarchyItem hierarchyItem && hierarchyItem.Parent == null)
                {
                    return _rootNode ??= new WorkspaceRootNode();
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
