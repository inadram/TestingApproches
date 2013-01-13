using NUnit.Framework;
using Rhino.Mocks;
using Rhino_mock;

namespace Test_Rhino_Mock
{
    [TestFixture]
    class TestMachine
    {
        [Test]
        public void Given_Device_When_RegisterNewDevice_then_AddShouldCalled()
        {
            //Arange
            var deviceManager = MockRepository.GenerateMock<IDeviceManager>();
            var machine = new Machine(deviceManager);
            var device=new Device {Id = 1, Name = "printer"};
            
            //Act
            machine.RegisterNewDevice(device);

            //Assert
            deviceManager.AssertWasCalled(x=>x.Add(device));

        }

        [Test]
        public void Given_Device_When_RegisterNewDevice_then_AddedSucessfullyShouldSettoTrue()
        {
            //Arange
            var deviceManager = MockRepository.GenerateMock<IDeviceManager>();
            var machine = new Machine(deviceManager);
            var device = new Device { Id = 1, Name = "printer" };

            //Act
            machine.RegisterNewDevice(device);

            //Assert
            deviceManager.AssertWasCalled(x => x.AddedSucessfully=true);

        }

        [Test]
        public void Given_Device_When_IfSpecialProduct_then_SpecialShouldSet()
        {
            //Arange
            var deviceManager = MockRepository.GenerateMock<IDeviceManager>();
            deviceManager.Stub(x => x.IsSpecialProduct(Arg<Device>.Is.Anything)).Return(true);
            var machine = new Machine(deviceManager);
            var device = new Device { Id = 1, Name = "printer" };

            //Act
            machine.RegisterNewDevice(device);

            //Assert
           deviceManager.AssertWasCalled(x => x.special="Special");

        }

      
    }
}
