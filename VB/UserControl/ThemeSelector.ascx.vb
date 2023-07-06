Imports DevExpress.Web
Imports DevExpress.Web.Internal
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Public Enum PopupAlign
	Right
	Left
End Enum
Partial Public Class ThemeSelector
	Inherits System.Web.UI.UserControl

	Protected Overrides Sub OnInit(ByVal e As EventArgs)
		MyBase.OnInit(e)
		Me.AssignRepeatersDataSource()
		Me.ChangeControlLayout()
	End Sub


	<System.ComponentModel.DefaultValue(PopupAlign.Right)>
	Public Property PopupAlign() As PopupAlign

	Public Sub ChangeControlLayout()
		If PopupAlign = PopupAlign.Right Then
			ThemeSelectorPopup.CssClass = "ThemeSelectorPopup Right"
			ThemeSelectorPopup.PopupHorizontalAlign = PopupHorizontalAlign.LeftSides
			ThemeSelectorPopup.PopupHorizontalOffset = -24
		Else
			ThemeSelectorPopup.CssClass = "ThemeSelectorPopup Left"
			ThemeSelectorPopup.PopupHorizontalAlign = PopupHorizontalAlign.RightSides
			ThemeSelectorPopup.PopupHorizontalOffset = 24
		End If
	End Sub
	Protected Sub AssignRepeatersDataSource()
		ThemesContainerRepeaterLeft.DataSource = ThemesModel.Current.LeftGroups
		ThemesContainerRepeaterLeft.DataBind()
		ThemesContainerRepeaterRight.DataSource = ThemesModel.Current.RightGroups
		ThemesContainerRepeaterRight.DataBind()
	End Sub

	Protected Sub Menu_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
		Dim menu As ASPxMenu = DirectCast(sender, ASPxMenu)
		Dim item As RepeaterItem = TryCast(menu.NamingContainer, RepeaterItem)
		If item IsNot Nothing Then
			Dim group As ThemeGroupModel = TryCast(item.DataItem, ThemeGroupModel)
			For Each theme As ThemeModel In group.Themes
				Dim menuItem As DevExpress.Web.MenuItem = menu.Items.Add(theme.Title, theme.Name)
				menuItem.ToolTip = theme.Title
			Next theme
		End If
	End Sub

End Class