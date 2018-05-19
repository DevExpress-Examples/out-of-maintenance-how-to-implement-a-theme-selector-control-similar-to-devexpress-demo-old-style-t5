Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.Xml.Serialization
Imports System.Web.UI


Public Class ThemeGroupModel
    Inherits ThemeModelBase

    Private _themes As New List(Of ThemeModel)()

    <XmlElement(ElementName := "Theme")> _
    Public ReadOnly Property Themes() As List(Of ThemeModel)
        Get
            Return _themes
        End Get
    End Property

    <XmlAttribute("Float")> _
    Public Property Float() As String
End Class


