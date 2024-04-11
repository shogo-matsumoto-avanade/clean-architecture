using FluentAssertions;
using Practice.Ddd.Application.Requests.Commands;

namespace Practice.Ddd.Tests.Application.Units.Validators;

[TestClass]
public class UserCreateCommandValidatorTest
{

    [TestMethod]
    [DynamicData(nameof(InvalidCreateUserCommandData))]
    public async Task InvalidParameters(
        string firstName, 
        string familyName, 
        string email, 
        int expectedErrorCount, 
        string expectedErrorMessage, 
        string testMessage)
    {
        //Arrange
        var query = new CreateUserCommand(firstName, familyName, email);
        var sut = new CreateUserCommandValidator();

        //Act
        var result = await sut.ValidateAsync(query);

        //Assert
        result.IsValid.Should().BeFalse(testMessage);
        result.Errors.Should().HaveCount(expectedErrorCount, testMessage);
        result.Errors.Select(x => x.ErrorMessage).Should().Contain(expectedErrorMessage, testMessage);
    }

    public static IEnumerable<object[]> InvalidCreateUserCommandData => [
            [null, "unittest", "xxx@xxx.xxx", 1, "'First Name' は空であってはなりません。", "When first name is null, validation should be error"],
            ["", "unittest", "xxx@xxx.xxx", 1, "'First Name' は空であってはなりません。", "When first name is empty, validation should be error"],
            ["xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxz", "unittest", "xxx@xxx.xxx", 1, "'First Name' は 50 文字以下でなければなりません。 51  文字入力されています。", "When first name exceeds tha max length, validation should be error"],
            ["test", null, "xxx@xxx.xxx", 1, "'Family Name' は空であってはなりません。", "When family name is null, validation should be error"],
            ["test", "", "xxx@xxx.xxx", 1, "'Family Name' は空であってはなりません。", "When family name is empty, validation should be error"],
            ["test", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxz", "xxx@xxx.xxx", 1, "'Family Name' は 50 文字以下でなければなりません。 51  文字入力されています。", "When family name exceeds tha max length, validation should be error"],
            ["test", "unittest", null, 1, "'Email' は空であってはなりません。", "When email is null, validation should be error"],
            ["test", "unittest", "", 2, "'Email' は空であってはなりません。", "When email is empty, validation should be error"],
            ["test", "unittest", "xxx@xxx", 1, "'Email' は正しい形式ではありません。", "When email is invalid, validation should be error"],
            ["test", "unittest", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx@xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx.xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxz", 1, "'Email' は 255 文字以下でなければなりません。 256  文字入力されています。", "When email exceeds tha max length, validation should be error"],
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
            ["test", "unittest", "xxx@xxx.xxx", "When input parameters are valid, validation should be success"],
            [
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx@xxxxxxxxxxxxxxxxxxxxxxxxxxxx.xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "When input parameters are valid, validation should be success (set values to the max length)"
            ],
         ];

}
