using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dapper.HelloWorld.Entities;

/// <summary>
///     User Entity
/// </summary>
public class UserEntity
{
    /// <summary>
    ///     id
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    /// <summary>
    ///     name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     age
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    ///     birthday
    /// </summary>
    public DateOnly Birth { get; set; }

    /// <summary>
    ///     status
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    ///     create time
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return
            $"UserEntity {{Id={Id}, Name={Name}, Age={Age}, Birth={Birth:yyyy-MM-dd}, Enabled={Enabled}, CreateTime={CreateTime:yyyy-MM-dd HH:mm:ss}}}";
    }
}