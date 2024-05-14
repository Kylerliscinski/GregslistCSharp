


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

  internal House UpdateHouse(int houseId, string userId, House houseData)
  {
    House houseToUpdate = GetHouseById(houseId);

    if (houseToUpdate.CreatorId != userId)
    {
      throw new Exception("You cannot delete a post that is not yours");
    }

    houseToUpdate.Bedrooms = houseData.Bedrooms ?? houseToUpdate.Bedrooms;
    houseToUpdate.Bathrooms = houseData.Bathrooms ?? houseToUpdate.Bathrooms;
    houseToUpdate.Levels = houseData.Levels ?? houseToUpdate.Levels;

    House updatedHouse = _repository.UpdateHouse(houseToUpdate);

    return updatedHouse;
  }
}