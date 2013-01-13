using System.Collections.Generic;
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

        [Test]
        public void Given_Name_Id_When_SetupAndRegisterNewDevice_then_AddSameDeviceType()
        {
            //Arange
            var deviceManager = MockRepository.GenerateMock<IDeviceManager>();
            var machine = new Machine(deviceManager);
            var device = new Device { Id = 1, Name = "printer" };

            //Act
            machine.SetupAndRegisterNewDevice(device.Id,device.Name);

            //Assert
            deviceManager.AssertWasCalled(x => x.Add(Arg<Device>.Matches(y => y.Id == device.Id && y.Name == device.Name)));
            deviceManager.AssertWasCalled(x => x.Add(Arg<Device>.Is.Anything));
            deviceManager.AssertWasCalled(x => x.Add(Arg<Device>.Is.NotNull));
        }
        [Test]
        public void Given_Name_Id_When_SetupAndRegisterNewDevice_then_AddSuceefullySetToSpecial()
        {
            //Arange
            var deviceManager = MockRepository.GenerateMock<IDeviceManager>();
            var machine = new Machine(deviceManager);
            var device = new Device { Id = 1, Name = "printer" };

            //Act
            machine.SetupAndRegisterNewDevice(device.Id, device.Name);

            //Assert
            deviceManager.AssertWasCalled(x => x.special = Arg<string>.Matches(Rhino.Mocks.Constraints.Text.StartsWith("Not")));
            deviceManager.AssertWasCalled(x => x.special = Arg<string>.Matches(Rhino.Mocks.Constraints.Text.Like("Special")));
            deviceManager.AssertWasCalled(x => x.special = Arg<string>.Matches(Rhino.Mocks.Constraints.Text.Contains("Special")));
        }

        [Test]
        public void Given_Name_Id_When_RegisterDevices_then_AddAllContainsExpectedList()
        {
            //Arange
            var deviceManager = MockRepository.GenerateMock<IDeviceManager>();
            var machine = new Machine(deviceManager);
            var device1 = new Device { Id = 1, Name = "printer1" };
            var device2 = new Device { Id = 2, Name = "printer2" };
            var device3 = new Device { Id = 2, Name = "printer3" };
            var deviceList=new List<Device> {device1,device2,device3};

            //Act
            machine.RegisterDevices(deviceList);

            //Assert
            deviceManager.AssertWasCalled(x => x.AddAll(Arg<List<Device>>.List.IsIn(device1)));
            deviceManager.AssertWasCalled(x => x.AddAll(Arg<List<Device>>.List.Count(Rhino.Mocks.Constraints.Is.Equal(3))));
            deviceManager.AssertWasCalled(x => x.AddAll(Arg<List<Device>>.List.ContainsAll(deviceList)));
        }


    }
}
