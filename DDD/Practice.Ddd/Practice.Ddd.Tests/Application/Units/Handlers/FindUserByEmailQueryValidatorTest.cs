using FluentAssertions;
using Practice.Ddd.Application.Requests.Queries;

namespace Practice.Ddd.Tests.Application.Units.Handlers;

[TestClass]
public class FindUserByEmailQueryValidatorTest : BaseUnitTest
{

    [TestMethod]
    [DataRow("testmail@test.xxx.com", "Input a valid parameter")]
    public async Task ValidParameters(string email, string testMessage)
    {
        //Arrange
        var query = new FindUserByEmailQuery(email);
        var sut = new FindUserByEmailQueryValidator();

        //Act
        var result = await sut.ValidateAsync(query);

        //Assert
        result.IsValid.Should().BeTrue(testMessage);
        result.Errors.Should().HaveCount(0, testMessage);
    }


    [TestMethod]
    [DataRow(null, 1, "'Email' は空であってはなりません。", "Input an invalid parameter: null")]
    [DataRow("", 2, "'Email' は空であってはなりません。", "Input an invalid parameter: empty")]
    [DataRow("", 2, "'Email' は正しい形式ではありません。", "Input an invalid parameter: empty")]
    [DataRow("aaa", 1, "'Email' は正しい形式ではありません。", "Input an invalid parameter: not including @")]
    [DataRow("aaa@aaa", 1, "'Email' は正しい形式ではありません。", "Input an invalid parameter: not including \'.\' in domain")]
    public async Task InvalidParameters(string email, int expectedErrorCount, string expectedErrorMessage, string testMessage)
    {
        //Arrange
        var query = new FindUserByEmailQuery(email);
        var sut = new FindUserByEmailQueryValidator();

        //Act
        var result = await sut.ValidateAsync(query);

        //Assert
        result.IsValid.Should().BeFalse(testMessage);
        result.Errors.Should().HaveCount(expectedErrorCount, testMessage);
        result.Errors.Select(x => x.ErrorMessage).Should().Contain(expectedErrorMessage, testMessage);
        //Remark: It may not be necessary to check messages from libraries.
    }

}
