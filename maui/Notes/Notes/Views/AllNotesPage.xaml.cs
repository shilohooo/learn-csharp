using Microsoft.Maui.Controls;

namespace Notes.Views;

public partial class AllNotesPage : ContentPage
{
    public AllNotesPage()
    {
        InitializeComponent();
    }

    private void AllNotesPage_OnNavigatedTo(object? sender, NavigatedToEventArgs e)
    {
        NotesCollection.SelectedItem = null;
    }
}