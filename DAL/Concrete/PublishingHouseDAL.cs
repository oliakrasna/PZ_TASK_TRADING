using AutoMapper;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class PublishingHouseDAL : IPublishingHouseDAL
    {
        private readonly IMapper _mapper;

        public PublishingHouseDAL(IMapper mapper)
        {
            _mapper = mapper;

        }
        public PublishingHouseDTO CreatePublishingHouse(PublishingHouseDTO publishing_house)
        {
            using (var entities = new TradingEntities())
            {
                var publishing_houseInDB = _mapper.Map<PublishingHous>(publishing_house);
                publishing_houseInDB.RowInsertTime = System.DateTime.Now;
                publishing_houseInDB.RowUpdateTime = System.DateTime.Now;
                entities.PublishingHouses.Add(publishing_houseInDB);
                entities.SaveChanges();
                return _mapper.Map<PublishingHouseDTO>(publishing_houseInDB);
            }
        }

        public List<PublishingHouseDTO> GetAllPublishingHouses()
        {
            using (var entities = new TradingEntities())
            {
                var publishing_houses = entities.PublishingHouses.ToList();
                return _mapper.Map<List<PublishingHouseDTO>>(publishing_houses);

            }

        }


        public PublishingHouseDTO RemovePublishingHouseByID(int id)
        {
            using (var entites = new TradingEntities())
            {
                var publishing_houseInDB = entites.PublishingHouses.SingleOrDefault(x => x.PublishingHouseID == id);
                if (publishing_houseInDB != null)
                {
                    entites.PublishingHouses.Remove(publishing_houseInDB);
                    entites.SaveChanges();
                }
                return _mapper.Map<PublishingHouseDTO>(publishing_houseInDB);
            }

        }

        public PublishingHouseDTO UpdatePublishingHouseByID(PublishingHouseDTO publishing_house, int id)
        {
            using (var entites = new TradingEntities())
            {
                var publishing_houseInDB = _mapper.Map<PublishingHous>(publishing_house);
                publishing_houseInDB = entites.PublishingHouses.SingleOrDefault(x => x.PublishingHouseID == id);
                if (publishing_houseInDB != null)
                {
                    publishing_houseInDB.RowUpdateTime = DateTime.Now;
                    publishing_houseInDB.PublishingHouseID = publishing_house.PublishingHouseID;
                    publishing_houseInDB.PublishingHouseName = publishing_house.PublishingHouseName;
                    publishing_houseInDB.Adress = publishing_house.Adress;
                    publishing_houseInDB.Number = publishing_house.Number;

                    entites.SaveChanges();
                }
                return _mapper.Map<PublishingHouseDTO>(publishing_houseInDB);
            }
        }


    }
}
