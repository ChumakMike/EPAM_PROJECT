using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.ModelsDTO;

namespace WebApi.Controllers {

    /// <summary>
    /// User api
    /// </summary>
    [Authorize(Roles = "Admin, Manager")]
    [RoutePrefix("api/user")]
    public class UserController : ApiController {

        private IUserService userService;
        /// <summary>
        /// Auth Controller constructor
        /// </summary>
        /// <param name="service">Service for crud users</param>
        public UserController(IUserService userService) {
            this.userService = userService;
        }

        // GET: api/user
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>
        /// <response code="200">Users found</response>
        /// <response code="404">Users not found</response>
        /// </returns>
        [HttpGet]
        public IHttpActionResult GetAllUsers() {
            return Ok(userService.GetAll());
        }

        // GET: api/user/{id}
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">Id of user to delete</param>
        /// <returns>
        /// <response code="200">User found</response>
        /// <response code="404">User was not found</response>
        /// </returns>
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetUserById(string id) {
            UserDTO resultUser = userService.GetUserById(id);
            if (resultUser == null) return NotFound();
            else return Ok(resultUser);
        }

        // POST api/user/delete
        /// <summary>
        /// Delete an existing user
        /// </summary>
        /// <param name="userDTO">User to delete</param>
        /// <returns>
        /// <response code="200">User deleted</response>
        /// <response code="404">User not found</response>
        /// </returns>
        [HttpPost]
        [Route("delete")]
        public IHttpActionResult deleteUser([FromBody] UserDTO userDTO) {
            UserDTO existingUser = userService.GetUserById(userDTO.Id);
            if (existingUser == null) return NotFound();

            if (userDTO == null) {
                return BadRequest($"{userDTO} must be passed");
            }
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            userService.Remove(userDTO);
            return Ok();
        }

    }
}
