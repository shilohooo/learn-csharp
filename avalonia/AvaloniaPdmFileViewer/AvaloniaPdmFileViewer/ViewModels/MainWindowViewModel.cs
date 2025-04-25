using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using AvaloniaPdmFileViewer.Models;
using AvaloniaPdmFileViewer.Readers;

namespace AvaloniaPdmFileViewer.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia! This is my added text";

    public ObservableCollection<Person> People { get; }
    public ObservableCollection<Table> Tables { get; }

    public MainWindowViewModel()
    {
        List<Person> people =
        [
            new("Shiloh", "Lee"),
            new("Bruce", "Lee"),
            new("Tome", "Han")
        ];
        People = new ObservableCollection<Person>(people);

        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates/test.xml");
        Tables = new ObservableCollection<Table>(PdmFileReader.Read(filePath));
    }
}