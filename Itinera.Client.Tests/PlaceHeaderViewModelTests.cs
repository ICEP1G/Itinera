using Itinera.Client.ViewModels.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.Tests
{
    public class PlaceHeaderViewModelTests
    {
        private readonly PlaceHeaderViewModel _sut;
        public PlaceHeaderViewModelTests()
        {
            _sut = new PlaceHeaderViewModel();
        }

        [Theory]
        [InlineData()]
        public void GetCorrectScheduleStatus_ShouldReturnOpen()
        {
            // Arrange
            // Il faut changer la fonction pour lui passer un DateTime fixe et pas un DateTime.Now dedans sinon les tests ne seront pas justes

            // Act

            // Assert
        }
    }
}
