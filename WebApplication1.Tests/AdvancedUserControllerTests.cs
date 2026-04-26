using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApplication1.Controllers;
using WebApplication1.Models;
using WebApplication1.Repositories.Abstract;

namespace WebApplication1.Tests;

public class AdvancedUserControllerTests
{
    private readonly Mock<IUserRepository> userRepositoryMock = new();
    private readonly AdvancedUserController controller;

    public AdvancedUserControllerTests()
    {
        controller = new AdvancedUserController(userRepositoryMock.Object);
    }

    [Fact]
    public void Update_ShouldReturnNotFound_WhenUserDoesNotExist()
    {
        userRepositoryMock
            .Setup(x => x.GetById(1))
            .Returns((AdvancedUser)null);

        var patchDoc = new JsonPatchDocument<AdvancedUser>();
        patchDoc.Replace(x => x.Password, "Aa1#աaaaa");

        var result = controller.Update(1, patchDoc);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Update_ShouldUpdatePassword_WhenPatchIsValid()
    {
        var user = new AdvancedUser
        {
            Id = 1,
            Username = "artur",
            Password = "OldAa1#ա",
            DateOfBirth = DateTime.Today.AddYears(-20),
            Quantity = 1,
            Price = 100,
            Amount = 10
        };

        userRepositoryMock
            .Setup(x => x.GetById(1))
            .Returns(user);

        var patchDoc = new JsonPatchDocument<AdvancedUser>();
        patchDoc.Replace(x => x.Password, "NewAa1#ա");

        var result = controller.Update(1, patchDoc);

        var objectResult = Assert.IsType<ObjectResult>(result);
        var updatedUser = Assert.IsType<AdvancedUser>(objectResult.Value);

        Assert.Equal("NewAa1#ա", updatedUser.Password);
        Assert.Equal(1, updatedUser.Id);
        Assert.Equal("artur", updatedUser.Username);
    }

    [Fact]
    public void Update_ShouldReturnBadRequest_WhenPatchPathIsInvalid()
    {
        var user = new AdvancedUser
        {
            Id = 1,
            Username = "artur",
            Password = "OldAa1#ա",
            DateOfBirth = DateTime.Today.AddYears(-20),
            Quantity = 1,
            Price = 100,
            Amount = 10
        };

        userRepositoryMock
            .Setup(x => x.GetById(1))
            .Returns(user);

        var patchDoc = new JsonPatchDocument<AdvancedUser>();
        patchDoc.Operations.Add(new Operation<AdvancedUser>
        {
            op = "replace",
            path = "/notExistingProperty",
            value = "value"
        });

        var result = controller.Update(1, patchDoc);

        Assert.IsType<BadRequestObjectResult>(result);
        Assert.False(controller.ModelState.IsValid);
    }

    [Fact]
    public void Post_ShouldCallRepositoryAdd()
    {
        var user = new AdvancedUser
        {
            Username = "artur",
            Password = "Aa1#աaaaa",
            DateOfBirth = DateTime.Today.AddYears(-20),
            Quantity = 1,
            Price = 100,
            Amount = 10
        };

        controller.Post(user);

        userRepositoryMock.Verify(x => x.Add(It.Is<AdvancedUser>(u =>
            u.Username == "artur" &&
            u.Password == "Aa1#աaaaa" &&
            u.Quantity == 1 &&
            u.Price == 100 &&
            u.Amount == 10 &&
            u.Id >= 0 &&
            u.Id < 1000
        )), Times.Once);
    }
}