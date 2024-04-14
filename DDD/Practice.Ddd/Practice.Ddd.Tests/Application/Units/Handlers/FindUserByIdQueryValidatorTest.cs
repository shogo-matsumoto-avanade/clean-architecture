using FluentAssertions;
using Practice.Ddd.Application.Requests.Queries;

namespace Practice.Ddd.Tests.Application.Units.Handlers;

[TestClass]
public class FindUserByIdQueryValidatorTest : BaseUnitTest
{

    [TestMethod]
    [DataRow("test-id", "Input a valid parameter")]
    public async Task ValidParameters(string id, string testMessage)
    {
        //Arrange
        var query = new FindUserByIdQuery(id);
        var sut = new FindUserByIdQueryValidator();

        //Act
        var result = await sut.ValidateAsync(query);

        //Assert
        result.IsValid.Should().BeTrue(testMessage);
        result.Errors.Should().HaveCount(0, testMessage);
    }



    [TestMethod]
    [DataRow(null, 1, "'Id' は空であってはなりません。", "Input an invalid parameter: null")]
    [DataRow("", 1, "'Id' は空であってはなりません。", "Input an invalid parameter: empty")]
    public async Task InvalidParameters(string id, int expectedErrorCount, string expectedErrorMessage, string testMessage)
    {
        //Arrange
        var query = new FindUserByIdQuery(id);
        var sut = new FindUserByIdQueryValidator();

        //Act
        var result = await sut.ValidateAsync(query);

        //Assert
        result.IsValid.Should().BeFalse(testMessage);
        result.Errors.Should().HaveCount(expectedErrorCount, testMessage);
        result.Errors.Select(x => x.ErrorMessage).Should().Contain(expectedErrorMessage, testMessage);
        //Remark: It may not be necessary to check messages from libraries.
    }


}
