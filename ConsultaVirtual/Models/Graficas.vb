Public Class Column1

    Public Property Nombre As String
    Public Property Afinidad As Integer
    Public Property Ascendencia As Integer
    Public Property Popularidad As Integer

End Class

Public Class Column2
    Public Property Genero As String
    Public Property Total As Integer
End Class


Public Class DataWrapperColumn1
    Public Property data As List(Of Column1)
End Class