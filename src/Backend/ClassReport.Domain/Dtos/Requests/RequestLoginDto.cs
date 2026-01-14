namespace MyRecipeBook.Domain.Dtos.Requests;

public record RequestLoginDto
{
    public string Username { get; set; } =  string.Empty;
    public string Password { get; set; } =  string.Empty;
}