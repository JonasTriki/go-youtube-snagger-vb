Public Class frmSearchOptions

    Dim langFile As IniFile

    Private Sub loadSettings()
        cbResultType.SelectedIndex = My.Settings.resultType
        cbSortBy.SelectedIndex = My.Settings.sortBy
        cbUploadDate.SelectedIndex = My.Settings.uploadDate
        cbCategories.SelectedIndex = My.Settings.categories
        cbDuration.SelectedIndex = My.Settings.duration
        cbFunctions.SelectedIndex = My.Settings.functions
    End Sub

    Public Sub CheckLang()
        langFile = ControlCL.GetLangFile
        LoadLang()
    End Sub

    Private Sub LoadLang()

        'SearchOptions = langFile.GetString("SearchOptions", "")
        cbResultType.Items.Add(langFile.GetString("SearchOptions", "All"))
        cbResultType.Items.Add(langFile.GetString("SearchOptions", "Videos"))
        cbResultType.Items.Add(langFile.GetString("SearchOptions", "Channels"))
        cbResultType.Items.Add(langFile.GetString("SearchOptions", "Playlists"))
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        cbSortBy.Items.Add(langFile.GetString("SearchOptions", "Relevance"))
        cbSortBy.Items.Add(langFile.GetString("SearchOptions", "UploadDate"))
        cbSortBy.Items.Add(langFile.GetString("SearchOptions", "ViewCount"))
        cbSortBy.Items.Add(langFile.GetString("SearchOptions", "Rating"))
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        cbUploadDate.Items.Add(langFile.GetString("SearchOptions", "Anytime"))
        cbUploadDate.Items.Add(langFile.GetString("SearchOptions", "Today"))
        cbUploadDate.Items.Add(langFile.GetString("SearchOptions", "ThisWeek"))
        cbUploadDate.Items.Add(langFile.GetString("SearchOptions", "ThisMonth"))
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        cbCategories.Items.Add(langFile.GetString("SearchOptions", "All"))
        cbCategories.Items.Add(langFile.GetString("SearchOptions", "CarsAndVehicles"))
        cbCategories.Items.Add(langFile.GetString("SearchOptions", "Comedy"))
        cbCategories.Items.Add(langFile.GetString("SearchOptions", "Education"))
        cbCategories.Items.Add(langFile.GetString("SearchOptions", "Entertainment"))
        cbCategories.Items.Add(langFile.GetString("SearchOptions", "FilmAndAnimation"))
        cbCategories.Items.Add(langFile.GetString("SearchOptions", "Gaming"))
        cbCategories.Items.Add(langFile.GetString("SearchOptions", "HowtoAndStyle"))
        cbCategories.Items.Add(langFile.GetString("SearchOptions", "Music"))
        cbCategories.Items.Add(langFile.GetString("SearchOptions", "NewsAndPolitics"))
        cbCategories.Items.Add(langFile.GetString("SearchOptions", "Non-profitAndActivism"))
        cbCategories.Items.Add(langFile.GetString("SearchOptions", "PeopleAndBlogs"))
        cbCategories.Items.Add(langFile.GetString("SearchOptions", "PetsAndAnimals"))
        cbCategories.Items.Add(langFile.GetString("SearchOptions", "ScienceAndTechnology"))
        cbCategories.Items.Add(langFile.GetString("SearchOptions", "Sport"))
        cbCategories.Items.Add(langFile.GetString("SearchOptions", "TravelAndEvents"))
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        cbDuration.Items.Add(langFile.GetString("SearchOptions", "All"))
        cbDuration.Items.Add(langFile.GetString("SearchOptions", "Short"))
        cbDuration.Items.Add(langFile.GetString("SearchOptions", "Long"))
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        cbFunctions.Items.Add(langFile.GetString("SearchOptions", "All"))
        cbFunctions.Items.Add(langFile.GetString("SearchOptions", "ClosedCaptions"))
        cbFunctions.Items.Add(langFile.GetString("SearchOptions", "HD"))
        cbFunctions.Items.Add(langFile.GetString("SearchOptions", "PartnerVideos"))
        cbFunctions.Items.Add(langFile.GetString("SearchOptions", "Rental"))
        cbFunctions.Items.Add(langFile.GetString("SearchOptions", "WebM"))

        'frmSearchOptions = langFile.GetString("frmSearchOptions", "")
        Me.Text = langFile.GetString("frmSearchOptions", "Text")

        'frmSearchOptionsControls = langFile.GetString("frmSearchOptionsControls", "")
        lResultType.Text = langFile.GetString("frmSearchOptionsControls", "ResultType")
        lOrderBy.Text = langFile.GetString("frmSearchOptionsControls", "SortBy")
        lUploadDate.Text = langFile.GetString("frmSearchOptionsControls", "UploadDate")
        lCategories.Text = langFile.GetString("frmSearchOptionsControls", "Categories")
        lDuration.Text = langFile.GetString("frmSearchOptionsControls", "Duration")
        lFunctions.Text = langFile.GetString("frmSearchOptionsControls", "Functions")
        llReset.Text = langFile.GetString("frmSearchOptionsControls", "ResetOptions")
        btnOK.Text = langFile.GetString("frmSearchOptionsControls", "OK")
        btnCancel.Text = langFile.GetString("frmSearchOptionsControls", "Cancel")

    End Sub

    Private Sub frmSearchOptions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CheckLang()
        loadSettings()
    End Sub

    Private Sub cb_SelectedIndexChanged(sender As ComboBox, e As System.EventArgs) Handles cbResultType.SelectedIndexChanged, cbSortBy.SelectedIndexChanged, cbUploadDate.SelectedIndexChanged, cbCategories.SelectedIndexChanged, cbDuration.SelectedIndexChanged, cbFunctions.SelectedIndexChanged
        If sender Is cbResultType Then
            cbSortBy.Enabled = cbResultType.SelectedIndex < 2
            cbSortBy.SelectedIndex = IIf(cbResultType.SelectedIndex > 2, 0, cbSortBy.SelectedIndex)
            cbUploadDate.Enabled = cbResultType.SelectedIndex < 2
            cbUploadDate.SelectedIndex = If(cbResultType.SelectedIndex > 2, 0, cbUploadDate.SelectedIndex)
            cbCategories.Enabled = cbResultType.SelectedIndex < 2
            cbCategories.SelectedIndex = If(cbResultType.SelectedIndex > 2, 0, cbCategories.SelectedIndex)
            cbDuration.Enabled = cbResultType.SelectedIndex < 2
            cbDuration.SelectedIndex = If(cbResultType.SelectedIndex > 2, 0, cbDuration.SelectedIndex)
            cbFunctions.Enabled = cbResultType.SelectedIndex < 2
            cbFunctions.SelectedIndex = If(cbResultType.SelectedIndex > 2, 0, cbFunctions.SelectedIndex)
        End If
        btnOK.Enabled = My.Settings.resultType <> cbResultType.SelectedIndex Or My.Settings.sortBy <> cbSortBy.SelectedIndex Or My.Settings.uploadDate <> cbUploadDate.SelectedIndex Or My.Settings.categories <> cbCategories.SelectedIndex Or My.Settings.duration <> cbDuration.SelectedIndex Or My.Settings.functions <> cbFunctions.SelectedIndex
    End Sub

    Private Sub llReset_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llReset.LinkClicked
        My.Settings.resultType = 0
        My.Settings.sortBy = 0
        My.Settings.uploadDate = 0
        My.Settings.categories = 0
        My.Settings.duration = 0
        My.Settings.functions = 0
        My.Settings.Save()
        loadSettings()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        My.Settings.resultType = cbResultType.SelectedIndex
        My.Settings.sortBy = cbSortBy.SelectedIndex
        My.Settings.uploadDate = cbUploadDate.SelectedIndex
        My.Settings.categories = cbCategories.SelectedIndex
        My.Settings.duration = cbDuration.SelectedIndex
        My.Settings.functions = cbFunctions.SelectedIndex
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class