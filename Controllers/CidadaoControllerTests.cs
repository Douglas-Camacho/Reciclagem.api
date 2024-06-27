using Xunit;
using Moq;
using AutoMapper;
using Reciclagem.api.Controllers;
using Reciclagem.api.Services;
using Reciclagem.api.Models;
using Reciclagem.api.ViewModel;
using Microsoft.AspNetCore.Mvc;

public class CidadaoControllerTests
{
    private readonly Mock<ICidadaoService> _cidadaoServiceMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly CidadaoController _controller;

    public CidadaoControllerTests()
    {
        _cidadaoServiceMock = new Mock<ICidadaoService>();
        _mapperMock = new Mock<IMapper>();
        _controller = new CidadaoController(_cidadaoServiceMock.Object, _mapperMock.Object, null);
    }

    [Fact]
    public void Get_ReturnsOkResult()
    {
        // Arrange
        int cidadaoId = 1;
        var cidadaoModel = new CidadaoModel { CidadaoId = cidadaoId, Nome = "Test" };
        var cidadaoViewModel = new CidadaoViewModel { CidadaoId = cidadaoId, Nome = "Test" };

        _cidadaoServiceMock.Setup(service => service.ObterCidadaoPorId(cidadaoId)).Returns(cidadaoModel);
        _mapperMock.Setup(mapper => mapper.Map<CidadaoViewModel>(cidadaoModel)).Returns(cidadaoViewModel);

        // Act
        var result = _controller.Get(cidadaoId);

        // Assert verifica se o status code é 200
        Assert.IsType<OkObjectResult>(result.Result);
        var okResult = result.Result as OkObjectResult;
        Assert.Equal(200, okResult.StatusCode);
    }
}

