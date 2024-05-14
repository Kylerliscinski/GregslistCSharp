


namespace csharp_gregslist_api.Services;

public class HousesService
{
  private readonly HousesRepository _repository;

  public HousesService(HousesRepository repository)
  {
    _repository = repository;
  }


  internal List<House> GetHouses()
  {
    List<House> houses = _repository.GetHouses();
    return houses;
  }

  internal House CreateHouse(House houseData)
  {
    House house = _repository.CreateHouse(houseData);
    return house;
  }

  internal House GetHouseById(int houseId)
  {
    House house = _repository.GetHouseById(houseId);

    if (house == null)
    {
      throw new Exception($"INvalid id: {houseId}");
    }

    return house;
  }
}