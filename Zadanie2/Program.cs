using System;
using System.Collections.Generic;

namespace HouseCatalogApp
{
    public class HouseType
    {
        public string Material { get; set; }
        public List<string> AdditionalBuildings { get; set; } = new List<string>();

        public override string ToString()
        {
            string buildings = AdditionalBuildings.Count > 0 ? string.Join(", ", AdditionalBuildings) : "Нет";
            return $"{Material} дом, дополнительные постройки: {buildings}";
        }
    }

    public static class AdditionalBuilding
    {
        public const string Pool = "Бассейн";
        public const string Garage = "Гараж";
        public const string FrontGarden = "Полисадник";
        public const string Path = "Тропинка";
    }


    public class HouseCatalog
    {
        private List<HouseType> _houseTypes = new List<HouseType>();

        public void AddHouseType(HouseType houseType)
        {
            _houseTypes.Add(houseType);
        }

        public void RemoveHouseType(HouseType houseType)
        {
            _houseTypes.Remove(houseType);
        }

        public List<HouseType> GetAllHouseTypes()
        {
            return _houseTypes;
        }


        public void PrintCatalog()
        {
            if (_houseTypes.Count == 0)
            {
                Console.WriteLine("Каталог пуст.");
                return;
            }

            Console.WriteLine("Строительный каталог домов:");
            foreach (var houseType in _houseTypes)
            {
                Console.WriteLine("- " + houseType);
            }
        }
    }


    public class CatalogFiller
    {
        public static void FillCatalog(HouseCatalog catalog)
        {
            var stoneHouse = new HouseType { Material = "Камень" };
            stoneHouse.AdditionalBuildings.Add(AdditionalBuilding.Pool);
            stoneHouse.AdditionalBuildings.Add(AdditionalBuilding.Garage);
            catalog.AddHouseType(stoneHouse);

            var brickHouse = new HouseType { Material = "Кирпич" };
            brickHouse.AdditionalBuildings.Add(AdditionalBuilding.FrontGarden);
            brickHouse.AdditionalBuildings.Add(AdditionalBuilding.Path);
            catalog.AddHouseType(brickHouse);

            var mixedHouse = new HouseType { Material = "Кирпич и камень" };
            mixedHouse.AdditionalBuildings.Add(AdditionalBuilding.Pool);
            mixedHouse.AdditionalBuildings.Add(AdditionalBuilding.Garage);
            mixedHouse.AdditionalBuildings.Add(AdditionalBuilding.FrontGarden);
            mixedHouse.AdditionalBuildings.Add(AdditionalBuilding.Path);
            catalog.AddHouseType(mixedHouse);
        }
    }
}