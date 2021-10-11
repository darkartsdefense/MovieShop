using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;

        public UserController(IUserService userService, ICurrentUserService currentUserService)
        {
            _userService = userService;
            _currentUserService = currentUserService;
        }

        // showing list of movies user purchased
        // Filters
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Purchases()
        {
            var userId = _currentUserService.UserId;
            // call the User Service to get movies purchased by user, and send the data to the view, and use the existing MovieCard partial View
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Favorites()
        {
            var userId = _currentUserService.UserId;
            // call the User Service to get movies Favorited by user, and send the data to the view, and use the existing MovieCard partial View

            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details()
        {
            // call the User Service to get User Details and display in a View
            // get user id from httpcontext and send it to user services
            // 
            var userId = _currentUserService.UserId;

            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var userId = _currentUserService.UserId;
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(UserEditRequestModel model)
        {
            return View();
        }

    }
}
