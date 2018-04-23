Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		If (Not IsPostBack) Then
			grid.DataBind()
		End If
	End Sub

	Protected Sub grid_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
		grid.DataSource = TempData
	End Sub

	Protected Sub grid_RowDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
		Dim key As Int32 = Convert.ToInt32(e.Keys(0))

		' emulate accident exceptions
		If key Mod 2 = 0 Then
			Throw New Exception("This record is readonly :(")
		End If

		TempData.RemoveAll(Function(i) i.Id = key)

		e.Cancel = True
	End Sub

	' Fake data source 

	Private ReadOnly Property TempData() As List(Of GridDataItem)
		Get
			Const key As String = "(some key)"
			If Session(key) Is Nothing Then

				Dim lst As New List(Of GridDataItem)()

				' Initialization with some values 

				For i As Int32 = 0 To 11
					If i Mod 2 = 0 Then
						lst.Add(New GridDataItem() With {.Id = i, .Name = ("Exception!"), .CurrentDate = New DateTime(2008 + i, i + 1, 17 + i)})
					Else
						lst.Add(New GridDataItem() With {.Id = i, .Name = ("Delete me!"), .CurrentDate = New DateTime(2008 + i, i + 1, 17 + i)})
					End If
				Next i

				Session(key) = lst
			End If
			Return CType(Session(key), List(Of GridDataItem))
		End Get
	End Property
End Class