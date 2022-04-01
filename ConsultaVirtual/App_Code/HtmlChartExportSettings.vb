Imports Microsoft.VisualBasic

''' <summary>
''' The settings needed for exporting the RadHtmlChart
''' </summary>
Public Class HtmlChartExportSettings
    Private _Height As Integer
    Private _Width As Integer
    Private _SvgFilePath As String
    Private _OutputFilePath As String
    Private _Extension As String
    Private _ClientFileName As String


    Public Sub New()
    End Sub

    ''' <summary>
    ''' The path to the Inkscape executable on the server.
    ''' </summary>
    'Public Const InkscapePath As String = "C:\Program Files (x86)\Inkscape\inkscape.exe" 'Local
    Public Const InkscapePath As String = "C:\Program Files\Inkscape\inkscape.exe" 'Server
    'the path to the Inkscape executable on your machine
    ''' <summary>
    ''' A list with the appropriate content-type values for the file formats.
    ''' </summary>
    Public Shared ReadOnly ContentTypeList As New Dictionary(Of String, String)() From {{"png", "image/png"}, {"pdf", "application/pdf"}}

    ''' <summary>
    ''' The height of the exported file, usually the height of the chart.
    ''' </summary>
    Public Property Height() As Integer
        Get
            Return _Height
        End Get
        Set(value As Integer)
            _Height = value
        End Set
    End Property

    ''' <summary>
    ''' The width of the exported file, usually the width of the chart.
    ''' </summary>
    Public Property Width() As Integer
        Get
            Return _Width
        End Get
        Set(value As Integer)
            _Width = value
        End Set
    End Property

    ''' <summary>
    ''' The path to the SVG file that will be passed to Inkscape.
    ''' </summary>
    Public Property SvgFilePath() As String
        Get
            Return _SvgFilePath
        End Get
        Set(value As String)
            _SvgFilePath = value
        End Set
    End Property

    ''' <summary>
    ''' The paht to the file created by Inkscape that will be sent to the client.
    ''' </summary>
    Public Property OutputFilePath() As String
        Get
            Return _OutputFilePath
        End Get
        Set(value As String)
            _OutputFilePath = value
        End Set
    End Property

    ''' <summary>
    ''' The format in which the chart will be exported.
    ''' </summary>
    Public Property Extension() As String
        Get
            Return _Extension
        End Get
        Set(value As String)
            _Extension = value
        End Set
    End Property

    ''' <summary>
    ''' The file name the client will receive for the file.
    ''' </summary>
    Public Property ClientFileName() As String
        Get
            Return _ClientFileName
        End Get
        Set(value As String)
            _ClientFileName = value + "." + Me.Extension
        End Set
    End Property
End Class


