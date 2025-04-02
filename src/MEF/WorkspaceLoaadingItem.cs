using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Imaging.Interop;

namespace WorkspaceFiles.MEF
{
    internal class WorkspaceLoadingItem() : WorkspaceItemNode(null, null, null)
    {
        public new string Text { get; } = $"{Vsix.Name} loading...";

        public new string ToolTipText => "Loading...";

        public new ImageMoniker IconMoniker => KnownMonikers.LinkedFolderClosed;
        public new ImageMoniker ExpandedIconMoniker => KnownMonikers.LinkedFolderClosed;

        public new string StateToolTipText => null;

        public new object ToolTipContent => "Loading...";

        public new bool IsCut => true;

        public new object SourceItem => this;

        public new bool HasItems => false;

        public new IEnumerable Items { get; } = new List<object>();
    }
}
