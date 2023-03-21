using System.Net;
using Microsoft.Extensions.Logging;
using Moq;
using WebApplication1;
using WebApplication1.Controllers;

namespace TestProject1;

public class WeatherForecastControllerTest
{
    private readonly WeatherForecastController _controller;

    public WeatherForecastControllerTest()
    {
        var logger = Mock.Of<ILogger<WeatherForecastController>>();
        _controller = new WeatherForecastController(logger);
    }

    [Fact]
    public void get_previsao_tempo_com_sucesso()
    {
        //Arrange(preparar)
        
        //Act(agir)
        var result = _controller.Get();
        
        //Assert(verificar)
        Assert.IsAssignableFrom<IEnumerable<WeatherForecast>>(result);
        var result2 = Assert.IsType<List<WeatherForecast>>(result);
        Assert.Equal(5, result2.Count);
    }

    [Fact]
    public void get_previsao_tempo_com_falha()
    {
        //Arrange(preparar)
        var mockTempo = HttpStatusCode.BadRequest;

        //Act(agir)
        var result = _controller.Get();

        //Assert(verificar)
        Assert.IsType<List<WeatherForecast>>(result);
        var result2 = Assert.IsType<List<WeatherForecast>>(result);
        Assert.False(result2.All(x => x.TemperatureC < 0));
    }
}