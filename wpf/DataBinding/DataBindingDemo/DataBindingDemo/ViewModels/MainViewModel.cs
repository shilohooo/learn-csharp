using DataBindingDemo.Models;

namespace DataBindingDemo.ViewModels;

/// <summary>
/// 主窗体的 ViewModel
/// </summary>
public class MainViewModel : ObservableObject
{
    private Person _person;

    public Person Person
    {
        get => _person;
        set
        {
            _person = value;
            // 如果本类没有继承 ObservableObject，那么 Person 中的属性发生更改时，
            // 前端 UI 的内容会发生同步更新，但是，如果对 Person 属性本身重新赋值，
            // 前端 UI 是不会发生改变的
            OnPropertyChanged();
        }
    }

    public MainViewModel()
    {
        _person = new Person
        {
            Name = "Shiloh",
            Age = 20,
            Address = "Beijing"
        };
    }
}