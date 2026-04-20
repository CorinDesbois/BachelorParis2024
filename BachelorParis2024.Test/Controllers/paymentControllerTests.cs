namespace BachelorParis2024.Test.Controllers;

using BachelorParis2024.Controllers;
using BachelorParis2024.Domain.Identity;
using BachelorParis2024.Domain.Models;
using BachelorParis2024.Repository.Context;
using BachelorParis2024.Services.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.PowerBI.Api.Models;
using Moq;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;


public class PaymentControllerTests
{
    [Fact]
    public async Task ProcessPayment_CartNotFound_ReturnsNotFound()
    {
        var userId = "user123";
        var user = new BachelorParis2024User { Id = userId, FirstName = "Corinne", LastName = "Dev" };

        var userStore = new Mock<IUserStore<BachelorParis2024User>>();
        var userManagerMock = new Mock<UserManager<BachelorParis2024User>>(userStore.Object, null, null, null, null, null, null, null, null);
        userManagerMock.Setup(um => um.GetUserAsync(It.IsAny<ClaimsPrincipal>()))
                       .ReturnsAsync(user);

        var paymentProcessorMock = new Mock<IPaymentProcessor>();
        paymentProcessorMock.Setup(p => p.ProcessPaymentAsync(userId))
                            .ReturnsAsync(true); // on simule que le paiement réussit

        // Mock du DbContext avec un panier inexistant
        var cartData = new List<Cart>().AsQueryable();
        var cartDbSetMock = new Mock<DbSet<Cart>>();
        cartDbSetMock.As<IQueryable<Cart>>().Setup(m => m.Provider).Returns(cartData.Provider);
        cartDbSetMock.As<IQueryable<Cart>>().Setup(m => m.Expression).Returns(cartData.Expression);
        cartDbSetMock.As<IQueryable<Cart>>().Setup(m => m.ElementType).Returns(cartData.ElementType);
        cartDbSetMock.As<IQueryable<Cart>>().Setup(m => m.GetEnumerator()).Returns(cartData.GetEnumerator());

        var contextMock = new Mock<DbProjectContext>();
        contextMock.Setup(c => c.Cart).Returns(cartDbSetMock.Object);

        var configMock = new Mock<IConfiguration>();
        var qrCodeServiceMock = new Mock<QrCodeService>();



        var controller = new PaymentController(contextMock.Object, paymentProcessorMock.Object, userManagerMock.Object, configMock.Object, qrCodeServiceMock.Object);
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.NameIdentifier, userId)
                }, "mock"))
            }
        };

        // Act
        var result = await controller.ProcessPayment();

        // Assert
        Assert.NotNull(result);
        var notFound = Assert.IsType<NotFoundObjectResult>(result);
        Assert.Equal("aucun panier trouvé", ((dynamic)notFound.Value).message);

        return;
    }


    [Fact]
    public async Task ProcessPayment_PaymentFails_ReturnsBadRequest()
    {
        // Arrange
        var userId = "user123";
        var user = new BachelorParis2024User { Id = userId, FirstName = "Corinne", LastName = "Dev" };

        var userStore = new Mock<IUserStore<BachelorParis2024User>>();
        var userManagerMock = new Mock<UserManager<BachelorParis2024User>>(userStore.Object, null, null, null, null, null, null, null, null);
        userManagerMock.Setup(um => um.GetUserAsync(It.IsAny<ClaimsPrincipal>()))
                       .ReturnsAsync(user);

        var paymentProcessorMock = new Mock<IPaymentProcessor>();
        paymentProcessorMock.Setup(p => p.ProcessPaymentAsync(userId))
                            .ReturnsAsync(false); // simulate payment failure

        var cart = new Cart { UserId = userId };

        var cartItems = new List<CartItem>
        {
             new CartItem
                    {
                        IdTicket =123456799,
                        IdEvent = 2,
                        Sport = "Gymnastique",
                        Event = "Final Dames",
                        Date = DateTime.UtcNow,
                        Location = "Paris",
                        IdOffer = 2,
                        OfferName = "solo",
                        OfferDescription = "billlet pour 1 personne",
                        OfferPersonNb = 1,
                        Price = 95,
                        Quantity = 1,
                        Total = 95,
                        Cart = cart
                    }
        };

        cart.Items = cartItems;

        var cartData = new List<Cart> { cart }.AsQueryable();
        var cartDbSetMock = new Mock<DbSet<Cart>>();
        cartDbSetMock.As<IQueryable<Cart>>().Setup(m => m.Provider).Returns(cartData.Provider);
        cartDbSetMock.As<IQueryable<Cart>>().Setup(m => m.Expression).Returns(cartData.Expression);
        cartDbSetMock.As<IQueryable<Cart>>().Setup(m => m.ElementType).Returns(cartData.ElementType);
        cartDbSetMock.As<IQueryable<Cart>>().Setup(m => m.GetEnumerator()).Returns(cartData.GetEnumerator());

        var contextMock = new Mock<DbProjectContext>();
        contextMock.Setup(c => c.Cart).Returns(cartDbSetMock.Object);

        var configMock = new Mock<IConfiguration>();
        var qrCodeServiceMock = new Mock<QrCodeService>();

        var controller = new PaymentController(contextMock.Object, paymentProcessorMock.Object, userManagerMock.Object, configMock.Object, qrCodeServiceMock.Object);
        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.NameIdentifier, userId)
            }, "mock"))
            }
        };

        // Act
        var result = await controller.ProcessPayment();

        // Assert
        Assert.NotNull(result);
        var badRequest = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("échec du paiement", ((dynamic)badRequest.Value).message);

        return;
    }

}

