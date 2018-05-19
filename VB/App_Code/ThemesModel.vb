Imports System.Xml.Serialization
Imports System.Collections.Generic
Imports System.IO
Imports System.Web
Imports System.Linq


<XmlRoot("Themes")> _
Public Class ThemesModel
    Private Shared _current As ThemesModel
    Private Shared ReadOnly _currentLock As New Object()

    Public Shared ReadOnly Property Current() As ThemesModel
        Get
            SyncLock _currentLock
                If _current Is Nothing Then
                    Using stream As Stream = File.OpenRead(HttpContext.Current.Server.MapPath("~/App_Data/Themes.xml"))
                        Dim serializer As New XmlSerializer(GetType(ThemesModel))
                        _current = DirectCast(serializer.Deserialize(stream), ThemesModel)
                    End Using
                End If
                Return _current
            End SyncLock
        End Get
    End Property

    Private _groups As New List(Of ThemeGroupModel)()

    <XmlElement("ThemeGroup")> _
    Public ReadOnly Property Groups() As List(Of ThemeGroupModel)
        Get
            Return _groups
        End Get
    End Property
    Public ReadOnly Property LeftGroups() As List(Of ThemeGroupModel)
        Get
            Return ( _
                From g In Groups _
                Where g.Float = "Left" _
                Select g).ToList()
        End Get
    End Property
    Public ReadOnly Property RightGroups() As List(Of ThemeGroupModel)
        Get
            Return ( _
                From g In Groups _
                Where g.Float = "Right" _
                Select g).ToList()
        End Get
    End Property
End Class


