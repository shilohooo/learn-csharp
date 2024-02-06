namespace Di.HelloWorld;

/// <summary>
/// 向其他对象提供服务的对象，在依赖项注入术语中，称为：Service
/// </summary>
public interface IMessageWriter
{
    void Write(string message);
}