

namespace csharp_gregslist_api.Repositories;

public class HousesRepository
{
  private readonly IDbConnection _db;
  public HousesRepository(IDbConnection db)
  {
    _db = db;
  }


  internal List<House> GetHouses()
  {
    string sql = @"
    SELECT
    houses.*,
    accounts.*
    FROM houses
    JOIN accounts ON accounts.id = houses.creatorId;";

    List<House> houses = _db.Query<House, Account, House>(sql, (house, account) =>
    {
      house.Creator = account;
      return house;
    }).ToList();

    return houses;
  }

  internal House CreateHouse(House houseData)
  {
    string sql = @"
      INSERT INTO
      houses(
        
      )
      ";
  }
}