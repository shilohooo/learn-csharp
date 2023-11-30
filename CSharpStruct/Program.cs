namespace CSharpStruct
{
    // struct - 结构体
    internal class Program
    {
        static void Main(string[] args)
        {
            // 声明结构体类型的变量
            // 与类不同，结构体可以不用 New 操作符来实例化，当使用 New 操作符来实例化结构体时会自动调用结构体中的构造函数；
            // 如果不使用 New 操作符来实例化结构体，结构体对象中的字段将保持未分配状态，并且在所有字段初始化之前无法使用该结构体实例。
            // 类与结构体的区别：
            // 1.类是引用类型，结构体是值类型；
            // 2.结构体不支持继承，但可以实现接口；
            // 3.结构体中不能声明默认的构造函数。
            Book book = new Book();
            book.Init(1, "海底两万里", "儒勒·凡尔纳", "科幻");
            book.Display();
            //book.id = 1;
            //book.title = "海底两万里";
            //book.author = "儒勒·凡尔纳";
            //book.subject = "科幻";
            // 输出 book 的属性信息
            //Console.WriteLine("book id: {0}", book.id);
            //Console.WriteLine("book title: {0}", book.title);
            //Console.WriteLine("book author: {0}", book.author);
            //Console.WriteLine("book subject: {0}", book.subject);
        }
    }

    // 要定义一个结构体需要使用 struct 关键字，每个结构体都可以被看作是一种新的数据类型，其中可以包含多个成员（成员属性和成员方法）
    struct Book
    {
        // 定义成员属性

        // ID
        public int id;
        // 标题
        public string title;
        // 作者
        public string author;
        // 主题/类别
        public string subject;

        // 定义成员方法
        public void Init(int i, string t, string a, string s)
        {
            id = i;
            title = t;
            author = a;
            subject = s;
        }

        public void Display()
        {
            Console.WriteLine("book id: {0}", id);
            Console.WriteLine("book title: {0}", title);
            Console.WriteLine("book author: {0}", author);
            Console.WriteLine("book subject: {0}", subject);
        }
    }
}
