using BlazorWebAssemblyApp.Server.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWebAssemblyApp.Shared.Business;

namespace BlazorWebAssemblyApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessUserController : ControllerBase // MUA : Remember ControllerBase class belongs to AspNetCore WebAPI
    {
        private readonly IBusinessUserRepository userRepository;
        public BusinessUserController(IBusinessUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<BusinessUser>>> Search(string username, string email, int? roleId)
        {
            try
            {
                return Ok(await userRepository.GetUsers());

                var result = await userRepository.Search(username, email);

                if(result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                return Ok(await userRepository.GetUsers());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        //[HttpGet("{id}")]
        [HttpGet("{id:guid}")] //MUA : If wants to specify the type of the expected input
        public async Task<ActionResult> GetUser(Guid id)
        {
            try
            {
                var result =  Ok(await userRepository.GetUser(id));
                
                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(BusinessUser user)
        {
            try
            {
                if (user == null) 
                        return BadRequest();
                
                if (user.Id == Guid.Empty) 
                        user.Id = Guid.NewGuid(); // MUA: Optional
                
                if (string.IsNullOrEmpty(user.Username)) 
                { 
                    ModelState.AddModelError("Username","Username is missing"); 
                }
                else
                {
                    var username = await userRepository.GetUserByUsername(user.Username);
                    
                    if(username != null)
                    {
                        ModelState.AddModelError("Username", "Username is already in use");
                        return BadRequest(ModelState);
                    }
                }
                

                var result = await userRepository.AddUser(user);

                return CreatedAtAction(nameof(GetUser), new { id = result.Id }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new user record");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(Guid Id ,BusinessUser user)
        {
            //MUA: testing done ?
            try
            {
                if (Id != user.Id) 
                    return BadRequest("User ID mismatched");

                var userUpdate = await userRepository.GetUser(Id);
                
                if(userUpdate == null)
                {
                    return NotFound($"User ID = {Id} not found ");
                }
                
                if (user.Id == Guid.Empty) user.Id = Guid.NewGuid(); // MUA: Optional

                if (string.IsNullOrEmpty(user.Username))
                {
                    ModelState.AddModelError("Username", "Username is missing");
                }
                else
                {
                    var username = userRepository.GetUserByUsername(user.Username);

                    if (username != null)
                    {
                        ModelState.AddModelError("Username", "Username is already in use");
                        return BadRequest(ModelState);
                    }
                }

                var result = await userRepository.UpdateUser(user);

                return CreatedAtAction(nameof(GetUser), new { id = result.Id }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating new user record");
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteUser(Guid Id)
        {
            //MUA: testing done ?
            try
            {
                var userDelete = await userRepository.GetUser(Id);

                if(userDelete == null)
                {
                    return NotFound($"User ID = {Id} not found");
                }

                await userRepository.DeleteUser(Id);

                return Ok($"User with ID = {Id} deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting user record");
            }
        }
    }
}
