namespace Wpf.Dp.AttachedDp.Model;

/// <summary>
/// 人员实体
/// </summary>
public class Person : ObservableObject
{
    #region PrivateFields

    /// <summary>
    /// backing field of <see cref="Username"/>
    /// </summary>
    private string _username;

    /// <summary>
    /// backing field of <see cref="Password"/>
    /// </summary>
    private string _password;

    #endregion

    #region PublicProperties

    /// <summary>
    /// 用户名
    /// </summary>
    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// 密码
    /// </summary>
    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }

    #endregion
}