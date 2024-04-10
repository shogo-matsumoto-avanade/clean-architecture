using FluentAssertions;
using Practice.Ddd.Application.Requests.Commands;

namespace Practice.Ddd.Tests.Application.Units.Validators;

[TestClass]
public class UserCreateCommandValidatorTest
{

    [TestMethod]
    [DynamicData(nameof(InvalidCreateUserCommandData))]
    public async Task InvalidParameters(string firstName, string familyName, string email, int exceptedErrorCount, string testMessage)
    {
        //Arrange
        var query = new CreateUserCommand(firstName, familyName, email);
        var sut = new CreateUserCommandValidator();

        //Act
        var result = await sut.ValidateAsync(query);

        //Assert
        result.IsValid.Should().BeFalse(testMessage);
        result.Errors.Should().HaveCount(exceptedErrorCount, testMessage);
    }

    public static IEnumerable<object[]> InvalidCreateUserCommandData => [
            [null, "unittest", "xxx@xxx", 1, "When first name is null, validation should be error"],
            ["", "unittest", "xxx@xxx", 1, "When first name is empty, validation should be error"],
            ["xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxz", "unittest", "xxx@xxx", 1, "When first name exceeds tha max length, validation should be error"],
            ["test", null, "xxx@xxx", 1, "When family name is null, validation should be error"],
            ["test", "", "xxx@xxx", 1, "When family name is empty, validation should be error"],
            ["test", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxz", "xxx@xxx", 1, "When family name exceeds tha max length, validation should be error"],
            ["test", "unittest", null, 1, "When email is null, validation should be error"],
            ["test", "unittest", "", 1, "When email is empty, validation should be error"],
            ["test", "unittest", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxz", 1, "When email exceeds tha max length, validation should be error"],
        ];

    [TestMethod]
    [DynamicData(nameof(ValidCreateUserCommandData))]
    public async Task ValidParameters(string firstName, string familyName, string email, string testMessage)
    {
        //Arrange
        var query = new CreateUserCommand(firstName, familyName, email);
        var sut = new CreateUserCommandValidator();

        //Act
        var result = await sut.ValidateAsync(query);

        //Assert
        result.IsValid.Should().BeTrue(testMessage);
        result.Errors.Should().BeEmpty(testMessage);
    }

    public static IEnumerable<object[]> ValidCreateUserCommandData => [
            ["test", "unittest", "xxx@xxx", "When input parameters are valid, validation should be success"],
            [
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "When input parameters are valid, validation should be success"
            ],
         ];

}
