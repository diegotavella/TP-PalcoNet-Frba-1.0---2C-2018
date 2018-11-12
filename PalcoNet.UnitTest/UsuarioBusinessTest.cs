using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using AutoMapper;
using Moq;
using PalcoNet.Entities.Implementations;
using PalcoNet.Business.Implementations;
using PalcoNet.Repositories;
using PalcoNet.Infraestructure.Logging;
using PalcoNet.Dtos;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Core.Objects;

namespace PalcoNet.UnitTest
{
    [TestClass]
    public class UsuarioBusinessTest
    {
        private readonly Fixture _fixture;
        private readonly IMapper _mapper;
        private readonly ILoggerFactory _loggerFactory;

        public UsuarioBusinessTest()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _mapper = Mock.Of<IMapper>();
            _loggerFactory = new NLogLoggerFactory();
        }

        [TestMethod]
        public void Should_loggin_ok()
        {
            // Arrange
            var usuario = _fixture.Create<UsuarioDto>();
            usuario.UserName = "Diego";
            usuario.Password = "123456";
            var palcoNetContextMock = new Mock<PalcoNetContext>();
            var business = new UsuarioBusiness(palcoNetContextMock.Object, _mapper, _loggerFactory);
            //palcoNetContextMock.Setup(x => x.GetRepository<UsuarioDto>().GetQuery()).Returns(MockDbSet(usuario));

            // Act
            var response = business.GetByUserNamePassword("Diego", "123456");

            // Assert
            Assert.AreEqual(response.Result.HasErrors, false);
            Assert.AreEqual(response.Data.UserName, "Diego");
        }

        private static IDbSet<T> MockDbSet<T>(params T[] sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();
            var dbSet = new Mock<IDbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            return dbSet.Object;
        }
    }
}
