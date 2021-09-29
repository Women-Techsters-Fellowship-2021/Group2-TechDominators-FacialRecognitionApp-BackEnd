using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FaceRecognition.Models;
using FaceRecognition.DTOs;
using FaceRecognition.BL;
using System;

namespace FaceRecognition.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ParentController : ControllerBase
    {
        private readonly IParentService _parentService;
        public ParentController(IParentService parentService)
        {
            _parentService = parentService;
        }

        //    adds new parent/guardian
        [HttpPost]
        public async Task<ActionResult<ParentResponseDTO>> CreateParent(ParentRequest request)
        {
            try
            {
                var response = await _parentService.CreateParent(request);
                // var request = SchoolMappings.GetUserRequest(response);
                return Created("~/api/v1/parent/" + response.Id, response);
            }
            catch (MissingFieldException message)
            {
                return BadRequest(message.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //   gets a particular parent using their id
        [HttpGet("{parentId}")]
        public async Task<ActionResult<ParentResponseDTO>> GetParent(string parentId)
        {
            try
            {
                var response = await _parentService.GetParent(parentId);
                return Ok(response);
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        //   gets a particular parent using their email
        [HttpGet("ByEmail")]
        public async Task<ActionResult<ParentResponseDTO>> GetParentByEmail(string email)
        {
            try
            {
                var response = await _parentService.GetParentByEmail(email);
                return Ok(response);
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // get all parents registered on the system for a specific child
        [HttpGet]
        public async Task<ActionResult<List<Parent>>> GetAllParents(string studentId)
        {
            try
            {
                var response = await _parentService.GetAllParents(studentId);
                return Ok(response);
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // remove parent
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteParent(string parentId)
        {
            try
            {
                var response = await _parentService.DeleteParent(parentId);
                return Ok(response);
            }

            catch (ArgumentNullException)
            {
                return BadRequest();
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}