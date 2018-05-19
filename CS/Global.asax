<%@ Application Language="C#" %>

<script RunAt="server">
    protected void Application_PreRequestHandlerExecute(object sender, EventArgs e) {
        if(Request.Cookies["CurrentThemeCookieKey"] != null) {
            DevExpress.Web.ASPxWebControl.GlobalTheme = Request.Cookies["CurrentThemeCookieKey"].Value;
        }
    }
</script>
