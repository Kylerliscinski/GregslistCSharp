namespace csharp_gregslist_api.Models;

public class House
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public int Bedrooms { get; set; }
  public int Bathrooms { get; set; }
  public int Levels { get; set; }
  public int? Price { get; set; }
  public string imgUrl { get; set; }
  public string Description { get; set; }
  public int Year { get; set; }
  public string CreatorId { get; set; }
  public Account Creator { get; set; }
}