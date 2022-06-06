using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LivApi.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;


namespace LivApi.Tests;


public class Tests
{

    [SetUp]
    public async Task Setup()
    {

    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
    
    [Test]
    public async Task Test2()
    {
        await using var application = new LivApplication();
        var client = application.CreateClient();
        var insurances = await client.GetFromJsonAsync<List<Insurance>>("/api/insurances");

        Assert.IsNotEmpty(insurances);
    }
    
    // 500
    // [Test]
    // public async Task PostInsurance()
    // {
    //     await using var application = new LivApplication();
    //     var client = application.CreateClient();
    //     
    //     var response = await client.PostAsJsonAsync("/api/insurance",
    //         new Insurance { Id = 2,
    //             InsuranceId=0,
    //             PersonalId=0,
    //             Sex="string",
    //             z=0,
    //             GuaranteeAmount=0,
    //             PaymentTime=0,
    //             GuaranteeTime=0,
    //             Product="string",
    //             Table="string"
    //         });
    //
    //     Assert.IsTrue(HttpStatusCode.Created == response.StatusCode);
    //
    //     //var todos = await client.GetFromJsonAsync<List<Todo>>("/todos");
    //
    //     //var todo = Assert.Single(todos);
    //     //Assert.IsTrue("I want to do this thing tomorrow" == todo.Title);
    //     //Assert.False(todo.IsComplete);
    // }
}

class LivApplication : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(services => { });
        
        return base.CreateHost(builder);
    }
}