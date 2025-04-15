using Business_Layer;
using Data_Layer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Test_Layer


{
    [TestFixture]
    public class DistrictContextTest
    {




        static DistrictContext districtContext;
        static DistrictContextTest()
        {
            districtContext = new DistrictContext(TestManager.dbContext);
        }

        [Test]
        public void CreateDistrict()
        {
            District district = new District("Plovdiv");
            int districtsBefore = TestManager.dbContext.Districts.Count();

            districtContext.Create(district);

            int districtsAfter = TestManager.dbContext.Districts.Count();
            District lastDistrict = TestManager.dbContext.Districts.Last();
            Assert.That(districtsBefore + 1 == districtsAfter && lastDistrict.Name == district.Name,
                "Names are not equal or district is not created!");
        }

        [Test]
        public void ReadDistrict()
        {
            District newDistrict = new District("Plovdiv");
            districtContext.Create(newDistrict);

            District district = districtContext.Read(newDistrict.Id);

            Assert.That(district.Name == "Plovdiv", "Read() does not get District by id!");
        }

        [Test]
        public void ReadAllDistrict()
        {
            int districtBefore = TestManager.dbContext.Districts.Count();

            int districtAfter = ((List<District>)districtContext.ReadAll()).Count;

            Assert.That(districtBefore == districtAfter, "ReadAll() does not return all of the District!");
        }

        [Test]
        public void UpdateDistrict()
        {
            District newDistrict = new("Plovdiv");
            districtContext.Create(newDistrict);

            District lastDistrict = districtContext.ReadAll().Last();
            lastDistrict.Name = "Updated District";

            districtContext.Update(lastDistrict, false);

            Assert.That(districtContext.Read(lastDistrict.Id).Name == "Updated District",
            "Update() does not change the District's name!");
        }

        [Test]
        public void DeleteDistrict()
        {
            District newDistrict = new District("Plovdiv");
            districtContext.Create(newDistrict);

            List<District> districts = (List<District>)districtContext.ReadAll();
            int districtBefore = districts.Count;
            District district = districts.Last();

            districtContext.Delete(district.Id);

            int districtAfter = ((List<District>)districtContext.ReadAll()).Count;
            Assert.That(districtBefore == districtAfter + 1, "Delete() does not delete a district!");
        }

        [Test]
        public void DeleteDistrict2()
        {
            District newDistrict = new District("Plovdiv");
            districtContext.Create(newDistrict);

            District district = districtContext.ReadAll().Last();
            int districtId = district.Id;

            districtContext.Delete(districtId);

            ArgumentException ex = Assert.Throws<ArgumentException>(() => districtContext.Read(districtId));
            Assert.That(ex.Message, Is.EqualTo($"District with Id {districtId} does not exist!"));
        }
    }
}
