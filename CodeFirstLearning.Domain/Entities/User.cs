namespace CodeFirstLearning.Domain.Entities;

public class User
{
    /// <summary>
    /// snowflake ID
    /// </summary>
    public long UserId { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public UserType UserType { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}

public enum UserType
{
    Regular,
    SpecialContributor
}