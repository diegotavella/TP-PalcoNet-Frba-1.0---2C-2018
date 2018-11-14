using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using AutoMapper;
using Moq;
using PalcoNet.Entities.Implementations;
using PalcoNet.Business.Implementations;
using PalcoNet.Repositories;
using PalcoNet.Infraestructure.Logging;
using PalcoNet.Infraestructure.Extensions;
using PalcoNet.Dtos;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.Core.Objects;
using PalcoNet.Repositories.Interfaces;
using System.Collections.Generic;
using Unity;
using PalcoNet.Infraestructure.Security;

namespace PalcoNet.UnitTest
{
    [TestClass]
    public class UsuarioBusinessTest
    {
        private readonly Fixture _fixture;
        private readonly IMapper _mapper;
        private readonly ILoggerFactory _loggerFactory;
        protected readonly IUnityContainer _container = new UnityContainer();
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
            var usuarioDto = _fixture.Create<UsuarioDto>();
            usuarioDto.UserName = "Diego";
            var userDtoList = new List<UsuarioDto> { usuarioDto };
            var usuario = _fixture.Create<Usuario>();
            usuario.UserName = "Diego";
            usuario.Password = SecurityHelper.EncodePassword("123456", Algorithm.Sha256);

            var loggerFactoryMock = new Mock<ILoggerFactory>();
            var loggerFake = new LoggerFake();
            loggerFactoryMock.Setup(x => x.Get<UsuarioBusiness>()).Returns(loggerFake);

            var repositoryMock = new Mock<IRepository<Usuario>>();
            repositoryMock.Setup(x => x.GetQuery()).Returns(MockDbSet(usuario));
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(x => x.GetRepository<Usuario>()).Returns(repositoryMock.Object);
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<List<UsuarioDto>>(It.IsAny<List<Usuario>>())).Returns(userDtoList);
            var business = new UsuarioBusiness(uow.Object, mapperMock.Object, loggerFactoryMock.Object);            

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
