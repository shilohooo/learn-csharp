namespace MultiValueConverter.Model;

public class Person : ObservableObject
{
    private string _name;

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    private int _age;

    public int Age
    {
        get => _age;
        set
        {
            _age = value;
            OnPropertyChanged();
        }
    }

    private int _money;

    public int Money
    {
        get => _money;
        set
        {
            _money = value;
            OnPropertyChanged();
        }
    }

    private string _address;

    public string Address
    {
        get => _address;
        set
        {
            _address = value;
            OnPropertyChanged();
        }
    }
}