
Imports Microsoft.VisualBasic
Imports System.Diagnostics
Imports System.IO

''' <summary>
''' Provides the core functionality for exporing the RadHtmlChart - SVG conversion and a helper method for sending the file to the client.
''' </summary>
Public Class HtmlChartExporter
    ''' <summary>
    ''' Uses a third party library called Inkscape to create a file from the SVG representation of the RadHtmlChart (already saved as a file).
    ''' </summary>
    ''' <param name="settings">The current settings that are used on the page.</param>
    Public Shared Sub ExportHtmlChart(settings As HtmlChartExportSettings)
        '' The actual export takes place here
        '' Full list of export options is available at
        '' http://tavmjong.free.fr/INKSCAPE/MANUAL/html/CommandLine-Export.html
        Dim inkscape As New Process()
        inkscape.StartInfo.FileName = HtmlChartExportSettings.InkscapePath
        inkscape.StartInfo.Arguments = [String].Format("--file ""{0}"" --export-{1} ""{2}"" --export-width {3} --export-height {4}", settings.SvgFilePath, settings.Extension, settings.OutputFilePath, settings.Width, settings.Height)
        inkscape.StartInfo.UseShellExecute = True
        inkscape.Start()
        inkscape.WaitForExit()
    End Sub

    ''' <summary>
    ''' Returns a byte[] array from the file so that it can be sent to the browser.
    ''' </summary>
    ''' <param name="filePath">the physical path to the file to read.</param>
    ''' <returns>Returns a byte[] array</returns>
    Public Shared Function ReadFile(filePath As String) As Byte()

        Dim buffer As Byte()
        Dim fileStream As New FileStream(filePath, FileMode.Open, FileAccess.Read)
        Try
            Dim length As Integer = CType(fileStream.Length, Integer)
            ' get file length
            buffer = New Byte(length) {}
            ' create buffer
            Dim count As Integer
            ' actual number of bytes read
            Dim sum As Integer = 0
            ' total number of bytes read
            ' read until Read method returns 0 (end of the stream has been reached)
            While (count = fileStream.Read(buffer, sum, length - sum)) > 0
                sum += count
                ' sum is a buffer offset for next reading
            End While
        Finally
            fileStream.Close()
        End Try
        Return buffer
    End Function
End Class

