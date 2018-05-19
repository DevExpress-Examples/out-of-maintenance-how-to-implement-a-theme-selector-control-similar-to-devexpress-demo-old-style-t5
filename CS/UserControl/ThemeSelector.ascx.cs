using DevExpress.Web;
using DevExpress.Web.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public enum PopupAlign { Right, Left }
public partial class ThemeSelector : System.Web.UI.UserControl {
    protected override void OnInit(EventArgs e) {
        base.OnInit(e);
        this.AssignRepeatersDataSource();
        this.ChangeControlLayout();
    }


    [System.ComponentModel.DefaultValue(PopupAlign.Right)]
    public PopupAlign PopupAlign { get; set; }

    public void ChangeControlLayout() {
        if(PopupAlign == PopupAlign.Right) {
            ThemeSelectorPopup.CssClass = "ThemeSelectorPopup Right";
            ThemeSelectorPopup.PopupHorizontalAlign = PopupHorizontalAlign.LeftSides;
            ThemeSelectorPopup.PopupHorizontalOffset = -24;
        } else {
            ThemeSelectorPopup.CssClass = "ThemeSelectorPopup Left";
            ThemeSelectorPopup.PopupHorizontalAlign = PopupHorizontalAlign.RightSides;
            ThemeSelectorPopup.PopupHorizontalOffset = 24;
        }        
    }
    protected void AssignRepeatersDataSource() {
        ThemesContainerRepeaterLeft.DataSource = ThemesModel.Current.LeftGroups;
        ThemesContainerRepeaterLeft.DataBind();
        ThemesContainerRepeaterRight.DataSource = ThemesModel.Current.RightGroups;
        ThemesContainerRepeaterRight.DataBind();
    }

    protected void Menu_DataBinding(object sender, EventArgs e) {
        ASPxMenu menu = (ASPxMenu)sender;
        RepeaterItem item = menu.NamingContainer as RepeaterItem;
        if(item != null) {
            ThemeGroupModel group = item.DataItem as ThemeGroupModel;
            foreach(ThemeModel theme in group.Themes) {
                DevExpress.Web.MenuItem menuItem = menu.Items.Add(theme.Title, theme.Name);
                menuItem.ToolTip = theme.Title;
            }
        }
    }

}