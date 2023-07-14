using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public Guid UserGuid { get; set; }

    [Required]
    public string Username { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string StreetAddress { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string State { get; set; }

    [Required]
    public string Country { get; set; }

    [Required]
    public string ZipCode { get; set; }

    [Required]
    public int CardNumber { get; set; }

    [Required]
    public DateTime ExpirationDate { get; set; }

    [Required]
    public string CVV { get; set; }
}