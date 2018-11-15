<!-- default file list -->
*Files to look at*:

* [ThemeGroupModel.cs](./CS/App_Code/ThemeGroupModel.cs) (VB: [ThemeGroupModel.vb](./VB/App_Code/ThemeGroupModel.vb))
* [ThemeModel.cs](./CS/App_Code/ThemeModel.cs) (VB: [ThemeModel.vb](./VB/App_Code/ThemeModel.vb))
* [ThemeModelBase.cs](./CS/App_Code/ThemeModelBase.cs) (VB: [ThemeModelBase.vb](./VB/App_Code/ThemeModelBase.vb))
* [ThemesModel.cs](./CS/App_Code/ThemesModel.cs) (VB: [ThemesModel.vb](./VB/App_Code/ThemesModel.vb))
* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
* [Global.asax](./CS/Global.asax) (VB: [Global.asax](./VB/Global.asax))
* [MasterPage.master.cs](./CS/MasterPage.master.cs) (VB: [MasterPage.master.vb](./VB/MasterPage.master.vb))
* [ThemeSelector.ascx](./CS/UserControl/ThemeSelector.ascx) (VB: [ThemeSelector.ascx.vb](./VB/UserControl/ThemeSelector.ascx.vb))
* [ThemeSelector.ascx.cs](./CS/UserControl/ThemeSelector.ascx.cs) (VB: [ThemeSelector.ascx.vb](./VB/UserControl/ThemeSelector.ascx.vb))
<!-- default file list end -->
# How to implement a Theme Selector control similar to DevExpress Demo (Old Style)


<p>The sample provides a web user control(ThemeSelector) that can be used in your project. To use this control in your solution, execute these steps:</p>
<p>1. Copy following files, taking into account their location:</p>
<p>   a. an xml file with theme groups and themes: Themes.xml.</p>
<p>   b. classes that are responsible for getting and presenting data from Themes.xml: ThemeGroupModel.cs, ThemeModel.cs, ThemeModelBase.cs, ThemesModel.cs.</p>
<p>   c. Sprite.png with images.</p>
<p>   d. ThemeSelector.css with css classes.</p>
<p>   e. ThemeSelector.ascx and ThemeSelector.ascx.cs.</p>
<p>2. Register the ThemeSelector web user control in your web.config file:</p>


```aspx
<pages>
  <controls>
    <add src="~/UserControl/ThemeSelector.ascx" tagName="ThemeSelector" tagPrefix="dx" />
  </controls>
</pages>

```


<p>3. In the sample, a chosen theme is written to a cookie. To apply this theme from the cookie, subscribe to the Application.PreRequestHandlerExecute in your Global.asax file and handle it</p>
<p>in the following manner:</p>


```cs
protected void Application_PreRequestHandlerExecute(object sender, EventArgs e) {
    if(Request.Cookies["CurrentThemeCookieKey"] != null) {
        DevExpress.Web.ASPxWebControl.GlobalTheme = Request.Cookies["CurrentThemeCookieKey"].Value;
    }
}

```


<p>4. The ThemeSelector control allows you to show a popup left or right relative to the "Themes" anchor. Use the ThemeSelector.PopupAlign property. The default value is PopupAlign.Right. </p>


```aspx
<dx:ThemeSelector runat="server" ID="ts2" PopupAlign="Left" />
```


<p><br><strong>Starting with v17.2</strong> we have changed our Theme Selector implementation. Now, this user control is placed to ASPxPanel and is mobile friendly. A new sample can be found in the following thread: <a href="https://www.devexpress.com/Support/Center/p/T590818">How to implement a Theme Selector control similar to DevExpress Demo</a></p>

<br/>


