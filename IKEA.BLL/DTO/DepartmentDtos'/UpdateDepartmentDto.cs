public interface IUpdateDepartmentDto
{
    int Id { get; set; }
    string Name { get; set; }
    string Code { get; set; }
    string Description { get; set; }
    DateOnly DateOfCreation { get; set; }
}

public class UpdateDepartmentDto : IUpdateDepartmentDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateOnly DateOfCreation { get; set; }
}
