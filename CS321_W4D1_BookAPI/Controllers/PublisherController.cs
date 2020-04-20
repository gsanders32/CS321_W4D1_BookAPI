﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W4D1_BookAPI.ApiModels;
using CS321_W4D1_BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS321_W4D1_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var publisherModels = _publisherService
                .GetAll()
                .ToApiModels();
            return Ok(publisherModels);
        }

        [HttpGet("{publisherId}")]
        public IActionResult Get(int publisherId)
        {
            var publisher = _publisherService
                .Get(publisherId)
                .ToApiModel();
            if (publisher == null) return NotFound();

            return Ok(publisher);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PublisherModel newPublisher)
        {
            try
            {
                _publisherService.Add(newPublisher.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddPublisher", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }
            return CreatedAtAction("Get", new { Id = newPublisher.Id }, newPublisher);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var publisher = _publisherService.Get(id);
            if (publisher == null) return NotFound();
            _publisherService.Remove(publisher);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PublisherModel updatePublisher)
        {
            var publisher = _publisherService.Update(updatePublisher.ToDomainModel());
            if (publisher == null) return NotFound();
            return Ok(publisher);
        }

    }
}