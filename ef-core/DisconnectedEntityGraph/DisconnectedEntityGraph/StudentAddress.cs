namespace DisconnectedEntityGraph;

/// <summary>
/// 学生地址实体，一个地址只能属于一个学生
/// </summary>
public class StudentAddress
{
    public int StudentAddressId { get; set; }

    public string Address { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string Country { get; set; }

    public int AddressOfStudentId { get; set; }

    public Student Student { get; set; }
}