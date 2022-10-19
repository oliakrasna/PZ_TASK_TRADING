using AutoMapper;
using DAL.Concrete;
using DTO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestFixture]
    public class UnitTest2
    {

        private IMapper _mapper;
        [OneTimeSetUp]
        public void SetupOnce()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(PublishingHouseDAL).Assembly)
                );
            _mapper = config.CreateMapper();
        }

        [Test]
        public void CreatePublishingHouseTest()
        {
            PublishingHouseDAL dal = new PublishingHouseDAL(_mapper);
            var result = dal.CreatePublishingHouse(new PublishingHouseDTO
            {
                PublishingHouseID = 11,
                PublishingHouseName = "test_publishing_house_name",
                Adress = "test_adress",
                Number = "test_number"

            });
            Assert.IsTrue(result.PublishingHouseID != 0);
        }


        [Test]
        public void GetAllPublishingHousesTest()
        {
            PublishingHouseDAL dal = new PublishingHouseDAL(_mapper);

            var publishing_houses = dal.GetAllPublishingHouses();
            Assert.IsTrue(publishing_houses.Count > 0);
        }

        [Test]
        public void UpdatePublishingHouseByIDTest()
        {
            PublishingHouseDTO newPublishingHouse = new PublishingHouseDTO
            {
                Adress = "23 Jaily Drive"
            };
            string _testPublishingHouse = " ";

            var dal = new PublishingHouseDAL(_mapper);

            var publishing_housesList = dal.GetAllPublishingHouses();
            int id = publishing_housesList.SingleOrDefault(x => x.Adress == _testPublishingHouse).PublishingHouseID;

            Assert.IsTrue(dal.UpdatePublishingHouseByID(newPublishingHouse, id).Adress == newPublishingHouse.Adress);
        }


        [Test]
        public void RemovePublishingHouseTest()
        {
            PublishingHouseDAL dal = new PublishingHouseDAL(_mapper);
            var publishing_house = dal.CreatePublishingHouse(new PublishingHouseDTO
            {
                PublishingHouseID = 12,
                PublishingHouseName = "test_publishing_house_name_4",
                Adress = "test_adress_4",
                Number = "test_number_4"
            });
            dal.RemovePublishingHouseByID(publishing_house.PublishingHouseID);
            var deleted = dal.GetAllPublishingHouses().Find(x => x.PublishingHouseName == publishing_house.PublishingHouseName);

            Assert.IsNull(deleted);
        }

    }
}

