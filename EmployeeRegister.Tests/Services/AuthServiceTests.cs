using EmployeeRegister.BusinessLogic.Interfaces;
using EmployeeRegister.BusinessLogic.Services;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace EmployeeRegister.Tests.Services
{
    [TestFixture]
    public class AuthServiceTests
    {
        [Test]
        public void Get_WhenInValidLogin_ShouldReturnFalse()
        {
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            string login = "le";// длина логина должна быть более 5 символов при валидации
            string password = "12345";
            var service = mocker.CreateInstance<AuthService>();

            var actualResult = service.IsLogin(login, password, out int id);
            
            Assert.AreEqual(false, actualResult);
        }
        
        [Test]
        public void Get_WhenInValidEmail_ShouldReturnFalse()
        {
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            string login = "lemif";
            string email = "lemifmail.ru"; //почты без @ не может быть в бд из-за валидации.
            var service = mocker.CreateInstance<AuthService>();

            var actualResult = service.IsRegistration(login, email);
            
            Assert.AreEqual(false, actualResult);
        }
    }
}