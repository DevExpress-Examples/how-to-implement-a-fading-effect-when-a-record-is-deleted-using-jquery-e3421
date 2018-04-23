Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text

Public Class GridDataItem
	Private privateId As Int32
	Public Property Id() As Int32
		Get
			Return privateId
		End Get
		Set(ByVal value As Int32)
			privateId = value
		End Set
	End Property
	Private privateName As String
	Public Property Name() As String
		Get
			Return privateName
		End Get
		Set(ByVal value As String)
			privateName = value
		End Set
	End Property
	Private privateCurrentDate As DateTime
	Public Property CurrentDate() As DateTime
		Get
			Return privateCurrentDate
		End Get
		Set(ByVal value As DateTime)
			privateCurrentDate = value
		End Set
	End Property
End Class
