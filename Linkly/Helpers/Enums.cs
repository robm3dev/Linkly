using System;
using System.Collections.Generic;
using System.Text;

namespace Linkly
{
    /// <summary>
    /// Specifies the supported browser types that can be launched by the BrowserService.
    /// </summary>
    public enum BrowserType
    {
        None,
        Chrome,
        Edge,
        Firefox,
        InternetExplorer,
        Brave,
        Opera,
        Safari
    }

    /// <summary>
    /// Specifies the types of menu items that can be displayed in the context menu.
    /// </summary>
    public enum MenuItemType
    {
        Link,
        Header,
        Separator
    }

    /// <summary>
    /// Specifies the Edit Mode Type (Either New or Edit Existing Item)
    /// </summary>
    public enum EditModeType
    {
        New,
        Edit
    }
}
