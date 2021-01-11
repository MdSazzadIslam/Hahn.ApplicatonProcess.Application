using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Microsoft.AspNetCore.Http;

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;

using MediatR;
using Hahn.ApplicatonProcess.December2020.Data.Handlers.Queries;
using Hahn.ApplicatonProcess.December2020.Data.Handlers.Commands;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Hahn.ApplicatonProcess.December2020.Web.Utils;

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class ApplicantController : ControllerBase
    {
        private readonly IStringLocalizer<ApplicantController> _localizer;

        // HttpClient is intended to be instantiated once per application, rather than per-use. 
        private static readonly HttpClient _client = new HttpClient();
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public ApplicantController(IStringLocalizer<ApplicantController> localizer, IMediator mediator, ILogger<ApplicantController> logger)
        {
            _localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
           
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetApplicant()
        {
            try
            {

                _logger.LogInformation(_localizer[ "GetApplicant method fired on {date}"], DateTime.Now);
                var response = await _mediator.Send(new GetApplicant());
                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetApplicant: {ex.Message}");
                //_logger.LogError("Error retrieving data from the database on {date}", DateTime.Now);
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error retrieving data from the database");

                
                
            }



        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetApplicantById(int id)
        {
            try
            {
                _logger.LogInformation("GetApplicantById method fired on {date}", DateTime.Now);
                var response = await _mediator.Send(new GetApplicantById { Id = id });
                if (response == null)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception)
            {
                _logger.LogError("Error retrieving data from the database on {date} and {Id} NOT FOUND", id,  DateTime.Now);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database by Id");
            }

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateApplicant(CreateApplicant command)
        {

            try
            {
                _logger.LogInformation("CreateApplicant method fired on {date}", DateTime.Now);
                string  result = await Countries.GetCountryById(command.CountryOfOrigin);
                if(result == "OK")
                {
                    var response = await _mediator.Send(command);

                    if (response == 1)
                    {
                        return Ok(StatusCode(201));

                    }
                    else
                    {

                        return BadRequest(StatusCode(400));

                    }
                }
                else
                {
                    _logger.LogError("CountryOfOrigin – must be a valid Country {CountryOfOrigin} on {date}", command.CountryOfOrigin, DateTime.Now);
                    return StatusCode(StatusCodes.Status400BadRequest, "CountryOfOrigin – must be a valid Country");
                }


            }
            catch (Exception ex)
            {
                _logger.LogError("Error saving data on {date}", DateTime.Now , ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error saving data");
            }
           

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateApplicant(int id, UpdateApplicant command)
        {
            try
            {
                _logger.LogInformation("UpdateApplicant method fired on {date}", DateTime.Now);
                if(id !=  command.Id)
                {
                    _logger.LogError("Updating error. Id not found... on {date}", DateTime.Now);
                    return BadRequest();
                }

                string result = await Countries.GetCountryById(command.CountryOfOrigin);
                if (result == "OK")
                {
                    var response = await _mediator.Send(command);

                    if (response == 1)
                    {
                        return Ok(StatusCode(201));

                    }
                    else
                    {
                        return BadRequest(StatusCode(400));
                    }

                }
                else
                {
                    _logger.LogError("CountryOfOrigin – must be a valid Country {CountryOfOrigin} on {date}", command.CountryOfOrigin, DateTime.Now);
                    return StatusCode(StatusCodes.Status400BadRequest, "CountryOfOrigin – must be a valid Country");

                    
                }
                  

            }
            catch(Exception)
            {
                _logger.LogWarning("Error updating data on {date}", DateTime.Now);
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error updating data");
            }

        }

    
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteApplicant(int id)
        {
            try
            {
                _logger.LogInformation("DeleteApplicant method fired on {date}", DateTime.Now);
                var response = await _mediator.Send(new DeleteApplicant { Id = id });
                if (response == 1)
                {
                    return Ok(StatusCode(201));

                }
                else
                {
                    return BadRequest(StatusCode(400));
                }
            }
            catch(Exception)
            {
                _logger.LogError("Error deleting data on {date}", DateTime.Now);
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Error deleting data");
            }

        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Country>> GetCountry()

        {
            _logger.LogInformation(_localizer["GetCountry method fired on {date}"], DateTime.Now);
            var response = await _client.GetAsync("https://restcountries.eu/rest/v2/all");

            string resBody = response.Content.ReadAsStringAsync().Result;
            List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(resBody, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            return countries;


        }


    }
}
