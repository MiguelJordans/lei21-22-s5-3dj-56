using GestArm.Domain.Encomendas;
using GestArm.Controllers;
using Moq;
using GestArm.Domain.Shared;
using Newtonsoft.Json;
namespace Controladores;

public class EncomendaControllerTest
{
    
    private readonly EncomendaController _controller;
    private readonly Mock<IEncomendasService> _ServiceMock = new Mock<IEncomendasService>();
    
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
    
    
    public EncomendaControllerTest()
    {
        _controller = new EncomendaController(_ServiceMock.Object);
    }
    
    [Fact]
    public void GetAllAsyncTest()
    {
        var listDto = new List<EncomendaDto>();

        Encomenda en = new Encomenda(new DataEntrega(DateTime.Parse("2022-12-27")) , new MassaEntrega(10), new TempoEncomenda(120), new TempoEncomenda(120),"A12");

        EncomendaDto encomendaDto = EncomendaDtoParser.convertToDto(en);
        
        listDto.Add(encomendaDto);

        _ServiceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(listDto);
        
        var result = _controller.GetAllAsync().Result;
        
        var objExpected = result.Value.First();
        var objActual = listDto.First();

        var obj1StrExpected = JsonConvert.SerializeObject(objExpected);
        var obj2StrActual = JsonConvert.SerializeObject(objActual);
        
        Assert.Equal(obj1StrExpected,obj2StrActual);
    }
    
    [Fact]
    public void GetByArmazemIdAysncTest()
    {
        var listDto = new List<EncomendaDto>();

        Encomenda en = new Encomenda(new DataEntrega(DateTime.Parse("2022-12-27")) , new MassaEntrega(10), new TempoEncomenda(120), new TempoEncomenda(120),"A12");

        EncomendaDto encomendaDto = EncomendaDtoParser.convertToDto(en);
        
        listDto.Add(encomendaDto);

        _ServiceMock.Setup(x => x.GetByArmazemIdAsync(en.ArmazemId)).ReturnsAsync(listDto);
        var result = _controller.GetByArmazemIdAysnc(en.ArmazemId).Result;
        
        var objExpected = result.Value.First();
        var objActual = listDto.First();

        var obj1StrExpected = JsonConvert.SerializeObject(objExpected);
        var obj2StrActual = JsonConvert.SerializeObject(objActual);
        
        Assert.Equal(obj1StrExpected,obj2StrActual);
    }
    
    [Fact]
    public void GetByDataDeEntregaAysncTest()
    {
        var listDto = new List<EncomendaDto>();

        Encomenda en = new Encomenda(new DataEntrega(DateTime.Parse("2022-12-27")) , new MassaEntrega(10), new TempoEncomenda(120), new TempoEncomenda(120),"A12");

        EncomendaDto encomendaDto = EncomendaDtoParser.convertToDto(en);
        
        listDto.Add(encomendaDto);

        _ServiceMock.Setup(x => x.GetByDataEntregaAysnc(en.DataEntrega.Data)).ReturnsAsync(listDto);
        var result = _controller.GetByDataDeEntregaAysnc(en.DataEntrega.Data).Result;
        
        var objExpected = result.Value.First();
        var objActual = listDto.First();

        var obj1StrExpected = JsonConvert.SerializeObject(objExpected);
        var obj2StrActual = JsonConvert.SerializeObject(objActual);
        
        Assert.Equal(obj1StrExpected,obj2StrActual);
    }
    
    [Fact]
    public void GetByFiltragemAysncTest()
    {
        var listDto = new List<EncomendaDto>();

        Encomenda en = new Encomenda(new DataEntrega(DateTime.Parse("2022-12-27")) , new MassaEntrega(10), new TempoEncomenda(120), new TempoEncomenda(120),"A12");

        EncomendaDto encomendaDto = EncomendaDtoParser.convertToDto(en);
        
        listDto.Add(encomendaDto);

        _ServiceMock.Setup(x => x.GetByFiltragemAysnc(en.ArmazemId,en.DataEntrega.Data)).ReturnsAsync(listDto);
        var result = _controller.GetByFiltragemAysnc(en.ArmazemId,en.DataEntrega.Data).Result;
        
        var objExpected = result.Value.First();
        var objActual = listDto.First();

        var obj1StrExpected = JsonConvert.SerializeObject(objExpected);
        var obj2StrActual = JsonConvert.SerializeObject(objActual);
        
        Assert.Equal(obj1StrExpected,obj2StrActual);
    }
    
    [Fact]
    public void AddAsyncTest()
    {
       //TODO: implementar este teste
    }
    
    [Fact]
    public void DeleteAsyncTest()
    {
       //TODO: implementar este teste
    }
    
    
}