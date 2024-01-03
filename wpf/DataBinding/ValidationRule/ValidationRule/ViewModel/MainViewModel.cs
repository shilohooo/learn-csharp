using ValidationRule.Model;

namespace ValidationRule.ViewModel;

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
}