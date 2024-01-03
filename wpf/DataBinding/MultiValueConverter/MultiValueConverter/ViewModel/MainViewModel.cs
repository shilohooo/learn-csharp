using System.Collections.ObjectModel;
using MultiValueConverter.Model;

namespace MultiValueConverter.ViewModel;

public class MainViewModel : ObservableObject
{
    private Person _person;

    public Person Person
    {
        get => _person;
        set
        {
            _person = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Person> Persons { get; set; } = [];
}