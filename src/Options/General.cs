using System.ComponentModel;
using System.Runtime.InteropServices;

namespace WorkspaceFiles
{
    internal partial class OptionsProvider
    {
        [ComVisible(true)]
        public class GeneralOptions : BaseOptionPage<General> { }
    }

    public class General : BaseOptionModel<General>, IRatingConfig
    {
        [Category("General")]
        [DisplayName("Show workspace node")]
        [Description("Determines if the Workspace node should be visible in Solution Explorer. Reopen solution for changes to take effect")]
        [DefaultValue(true)]
        public bool Enabled { get; set; } = true;

        [Category("General")]
        [DisplayName("Ignore list")]
        [Description("A semicolon separated list file patterns to ignore")]
        [DefaultValue("**/*.tmp; .git; **/~*")]
        public string IgnoreList { get; set; } = "**/*.tmp; .git; **/~*";

        // Used for the rating prompt
        [Browsable(false)]
        public int RatingRequests { get; set; }
    }
}
