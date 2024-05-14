



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
        bedrooms,
        bathrooms,
        levels,
        price,
        imgUrl,
        description,
        year,
        creatorId
      )
      VALUES(
        @Bedrooms,
        @Bathrooms,
        @Levels,
        @Price,
        @ImgUrl,
        @Description,
        @Year,
        @CreatorId
      );

      SELECT * FROM houses WHERE id = LAST_INSERT_ID();";

    House house = _db.Query<House>(sql, houseData).FirstOrDefault();

    return house;
  }

  internal House GetHouseById(int houseId)
  {
    string sql = @"
      SELECT
      houses.*,
      accounts.*
      FROM houses
      JOIN accounts ON accounts.id = houses.creatorId
      WHERE houses.id = @houseId;";

    House house = _db.Query<House, Account, House>(sql, (house, account) =>
    {
      house.Creator = account;
      return house;
    }, new { houseId }).FirstOrDefault();

    return house;
  }

  internal House UpdateHouse(House houseToUpdate)
  {
    string sql = @"
      UPDATE houses
      SET
      bedrooms = @Bedrooms,
      bathrooms = @Bathrooms,
      levels = @Levels
      WHERE id = @Id;
      
      SELECT
      houses.*,
      accounts.*
      FROM houses
      JOIN accounts ON accounts.id = houses.creatorId
      WHERE houses.id = @Id;";

    House house = _db.Query<House, Account, House>(sql, (house, account) =>
    {
      house.Creator = account;
      return house;
    }, houseToUpdate).FirstOrDefault();

    return house;
  }
}