using Scriban;

// const string sql = """
//                    create table T_Users(
//                        id bigint primary key identity ,
//                        username varchar(255) not null
//                    );
//                    """;


// var ast = new Parser().ParseSql(sql, new MsSqlDialect());

var template = Template.Parse("Hello {{name}}");
var result = template.Render(new { Name = "World" });
Console.WriteLine(result);

var products = new List<Product>([
    new Product { Name = "Apple", Price = 1.99m, Description = "A red apple" },
    new Product { Name = "Banana", Price = 0.99m, Description = "A yellow banana" },
    new Product { Name = "Orange", Price = 1.49m, Description = "A sweet orange" }
]);

var listTemplate = Template.Parse("""
                                  <ul id="products">
                                  {{ for product in products }}
                                    <li>
                                      <strong>{{ product.name }}</strong> - {{ product.price }}
                                      <p>{{ product.description }}</p>
                                    </li>
                                  {{ end }}
                                  </ul>
                                  """);
var listResult = listTemplate.Render(new { Products = products });
Console.WriteLine(listResult);

/// <summary>
/// 产品类
/// </summary>
internal class Product
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
}