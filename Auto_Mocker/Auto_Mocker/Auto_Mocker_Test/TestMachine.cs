using Auto_Mocker;
using NUnit.Framework;
using Rhino.Mocks;
using StructureMap.AutoMocking;

namespace Auto_Mocker_Test
{
    [TestFixture]
    class TestMachine
    {
        [Test]
        public void Given_device_when_RegisterNewDevice_then_AddedSucessfullyShouldSetToTrue()
        {
            var autoMocker=new RhinoAutoMocker<Machine>();
            var device=new Device {ID=1,Name = "printer"};
            autoMocker.ClassUnderTest.RegisterNewDevice(device);
            autoMocker.Get<IDeviceManager>().AssertWasCalled(x => x.AddedSucessfully = true);
        }

        [Test]
        public void Given_device_when_TheStockIsNotOutOfOrder_then_AddMethodShouldCalled()
        {
            var autoMocker = new RhinoAutoMocker<Machine>();
            var device = new Device { ID = 1, Name = "printer" };
            var product = autoMocker.Get<Iproduct>();
            product.Stub(x => x.IsOutOfStock(Arg<Device>.Is.Anything)).Return(false);
            autoMocker.ClassUnderTest.RegisterNewDevice(device);
            autoMocker.Get<IDeviceManager>().AssertWasCalled(x => x.Add(device));
        }
    }
}
