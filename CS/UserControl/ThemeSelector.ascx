<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ThemeSelector.ascx.cs" Inherits="ThemeSelector" %>
<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<script type="text/javascript">
    function SetCurrentTheme(s, e) {
        var themeSelectorPopup = ASPxClientControl.GetControlCollection().GetByName("<%=ThemeSelectorPopup.ClientID%>");
        themeSelectorPopup.HideWindow();
        ASPxClientUtils.SetCookie("CurrentThemeCookieKey", e.item.name);
        e.processOnServer = true;
    }
    function selectorPopupContainerElement_Click(popupControl, event) {
        var eventSource = ASPx.Evt.GetEventSource(event);
        if (eventSource && eventSource.className.indexOf('dxpc-content') >= 0) {
            popupControl.HideWindow();
        }
    }
    function SelectorPopupContainer_Init(sender) {
        var content = sender.GetWindowContentElement(-1);
        ASPxClientUtils.AttachEventToElement(content, 'click', function (event) { selectorPopupContainerElement_Click(sender, event); });
    }

</script>

<link href="<%= ResolveUrl("~/UserControl/ThemeSelector.css") %>" rel="stylesheet" />
    <a href="javascript:void(0)" runat="server" class="ThemeButton" id="ThemeButton">
        <dx:ASPxImage runat="server" ID="tPic" CssClass="Icon"></dx:ASPxImage>
        THEMES
    <dx:ASPxImage runat="server" ID="tGlyph" CssClass="Glyph"></dx:ASPxImage>
    </a>


<dx:ASPxPopupControl ID="ThemeSelectorPopup" EnableClientSideAPI="true" runat="server"
    EnableTheming="false" ShowHeader="False" ShowShadow="false" PopupAnimationType="None"
    PopupElementID="ThemeButton" PopupVerticalAlign="TopSides"
    PopupVerticalOffset="-19" PopupAlignCorrection="Disabled"
    PopupAction="LeftMouseClick" Width="450px">
    <ClientSideEvents Init="SelectorPopupContainer_Init" />
    <ContentCollection>
        <dx:PopupControlContentControl runat="server">
            <div class="ButtonWrapper">
                <div class="ThemeButtonBorder">
                </div>
            </div>
            <div class="ButtonWrapperBtmBorder"></div>
            <div class="ContainerWrapper">
                <div class="ThemeContainer">
                    <div class="ThemeColumnLeft">
                        <asp:Repeater runat="server" ID="ThemesContainerRepeaterLeft" EnableViewState="false">
                            <ItemTemplate>
                                <div class="ThemeGroupItem">
                                    <div class="ThemeGroup">
                                        <%# ((string)Eval("Title")).ToUpper() %>
                                    </div>
                                    <dx:ASPxMenu ID="ThemeGroupMenu1" CssClass="ThemeGroupMenu" runat="server" EnableTheming="false"
                                        EnableViewState="false" Orientation="Vertical" ItemImagePosition="Left" ItemSpacing="0px"
                                        OnDataBinding="Menu_DataBinding">
                                        <ClientSideEvents ItemClick="SetCurrentTheme" />
                                        <ItemTextTemplate>
                                            <div class="ThemeIco"><span class="Theme<%# Eval("Name") %>"></span></div>
                                            <%# Eval("Text") %>
                                        </ItemTextTemplate>
                                    </dx:ASPxMenu>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="ThemeColumnRight">
                        <asp:Repeater runat="server" ID="ThemesContainerRepeaterRight" EnableViewState="false">
                            <ItemTemplate>
                                <div class="ThemeGroupItem">
                                    <div class="ThemeGroup">
                                        <%# ((string)Eval("Title")).ToUpper() %>
                                    </div>
                                    <dx:ASPxMenu ID="ThemeGroupMenu2" CssClass="ThemeGroupMenu" runat="server" EnableTheming="false"
                                        EnableViewState="false" Orientation="Vertical" ItemImagePosition="Left" ItemSpacing="0px"
                                        OnDataBinding="Menu_DataBinding">
                                        <ClientSideEvents ItemClick="SetCurrentTheme" />
                                        <ItemTextTemplate>
                                            <div class="ThemeIco"><span class="Theme<%# Eval("Name") %>"></span></div>
                                            <%# Eval("Text") %>
                                        </ItemTextTemplate>
                                    </dx:ASPxMenu>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </dx:PopupControlContentControl>
    </ContentCollection>
</dx:ASPxPopupControl>





