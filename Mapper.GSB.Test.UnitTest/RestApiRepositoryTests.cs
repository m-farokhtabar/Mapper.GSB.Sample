using Mapper.GSB.Application.GSBAPICaller.SeedWorks.RestApi;
using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.ResponseBody;
using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.SendPerson;
using Mapper.GSB.Application.GSBAPICaller.Serviecs.GSBService.Token;
using Mapper.GSB.Infrastructure.RestApi;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;
using System.Text.Json;

namespace Mapper.GSB.Test.UnitTest;
public class RestApiRepositoryTests
{
    ILogger<RestApiRepository> logger;
    public RestApiRepositoryTests()
    {
        var mock = new Mock<ILogger<RestApiRepository>>();
        logger = mock.Object;
    }
    /// <summary>
    /// بررسی صحت ریپو پیاده سازی با صدا زدن سرویس شبیه سازی شده تولید توکن کاربران
    /// </summary>
    [Fact]
    public async Task When_CallGetTokenRestApiWithValidData_Expect_SuceessResult()
    {

        //Arrange
        RestApiRepository repo = new("https://r74gl.wiremockapi.cloud/", logger);
        Dictionary<string, string> headers = new()
        {
            { "USER_KEY", "4fff7165-5f36-43c9-b15a-663332e593ed" },
            { "bundle-id", "ccdf0e3a85194ab4b4a2beaf7b1cafbe" },
        };
        var serializeOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull };

        //Act        
        var result = await repo.PostAsync(new Uri("bimehsalamat/GetToken", UriKind.Relative), headers, System.Text.Json.JsonSerializer.Serialize(new
        {
            userName = "M12345",
            password = "abc-def-ghi"
        }), "application/json");
        var resultObj = System.Text.Json.JsonSerializer.Deserialize<RootResultDto<TokenResultDto>>(result!.Data!, serializeOptions);
        //Assert
        Assert.Equal(HttpStatusCode.OK, result?.Status);
    }
    /// <summary>
    /// بررسی صحت ریپو پیاده سازی با صدا زدن سرویس شبیه سازی شده تولید توکن کاربران
    /// </summary>
    [Fact]
    public async Task When_CallSendPersonInfoRestApiWithValidData_Expect_SuceessResult()
    {
        //Arrange
        RestApiRepository repo = new("https://r74gl.wiremockapi.cloud/bimehsalamat/", logger);
        Dictionary<string, string> headers = new()
        {
            { "X_Authorization", "Basic Y2VudGluc3VyZV9nc2I6Q2VuZXIhTUA0Mzg5" },
            { "Token", "eyJhbGciOiJBMTI4S1ciLCJlbmMiOiJBMTI4Q0JDLUhTMjU2IiwidHlwIjoiSldUIn0.uWyLvRPqScpEH-DqmkEcIS-NtjE0QgQ7uVy9rUXxHAraTZ45c5OyFw.rZhYjZGZTPA0GABmoVIiMg.-Xao4dWcci56r2vkBhDfDyAX_5HPAkRDE1GLPExobT5Cz9sLZxRaL2h0GpVBHJDp1NVzCLsygDWNQ5VBXvmLtQC4taBA8GZNBWMXXsUlhzRNSWVnVNAX7ZqdFhjkFmCFv1cJs3QQQ4elGXFbd4LMYqFIKiPgVcRg8dU7l07uuiesl-VZmKRQz9lW4q3KOBM5N17EJw27bGFqanEjQ3d0JGMAJaPAXpVQ-QelGJhGd62BX5YnZPN1O0wvUdTQMIvJS1hDh1RI1VGId8Q7_NLEjWLbwwgCfvEVzi0CL7uIdaqIpwpSXYfOAcxtbFvirXcVqoY9QQz4EPASgs-vejS9-k3VopCLryfhRwsowDsVnvxWkWEHrv6QxTm88yAqo8YAsSEqjBNvdNOk-c_tsRaBalt4QiGI1VfEwGCGKsnGTAo1Id85AfRkCc208NJlklyV8JrcmodOQdqAsv3z1ndZzIDLQnaa6U1QycW1AvdXD3yhkGXiwp8u6Z_kgt0nNoenVd5-JGln9uL6TzYIJs604yrv_2Dt4qxmUHucShBbrtXiXy6QE3BfbBAOL7vZsvq9zWV5YWK2CFmSrNIsz65Dry9Uv797z7g3HgIUIme9CdzVe4MpWgzC2vk4PsEtVYGu2WwyHBhwbtx0NXZGZd50y1LOQYrvYCJdYRlNw4FJFmkUp5lDvh4SxyIKT9ifXxbKxM_TFrTtaxHmtyJAitY5TjgOkB-qsxbYzBlrP1hWUd3AOSv6_TbiLFRHlnX6xE19.9y5k6bM5lbkVQPFygoeUqg" },
            { "USER_KEY", "4fff7165-5f36-43c9-b15a-663332e593ed"},
            {  "bundle-id", "ccdf0e3a85194ab4b4a2beaf7b1cafbe"}
        };
        var serializeOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull };

        //Act        
        var result = await repo.PostAsync(new Uri("SendPersonInfo", UriKind.Relative), headers, "{\"data\":\"test\"}", "application/json");
        var resultObj = System.Text.Json.JsonSerializer.Deserialize<RootResultDto<SendPersonResultDto>>(result!.Data!, serializeOptions);
        //Assert
        Assert.Equal(HttpStatusCode.OK, result.Status);
    }

}