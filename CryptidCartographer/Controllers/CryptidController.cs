﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using CryptidCartographer.Models;
using CryptidCartographer.Repositories;

namespace CryptidCartographer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

 
    public class CryptidController : ControllerBase
    {
        private readonly ICryptidRepository _cryptidRepo;
        private readonly IUserRepository _userRepo;


        public CryptidController(ICryptidRepository cryptidRepo, IUserRepository userRepo)
        {
            _cryptidRepo = cryptidRepo;
            _userRepo = userRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cryptidRepo.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cryptids = _cryptidRepo.GetCryptidById(id);
            return Ok(cryptids);
        }

        [HttpPost]
        public IActionResult Post(Cryptid cryptid)
        {
            cryptid.DateCreated = DateTime.Now;
            _cryptidRepo.Add(cryptid);
            return CreatedAtAction("Get", new { id = cryptid.Id }, cryptid);
        }

        [HttpPut]
        public IActionResult Put(Cryptid cryptid)
        {
            _cryptidRepo.Update(cryptid);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _cryptidRepo.Delete(id);
        }

        [HttpGet("GetCryptidByStateName/{name}")]
        public IActionResult GetCryptidByStateName(string name)
        {
            var cryptids = _cryptidRepo.GetCryptidByStateName(name);
            return Ok(cryptids);
        }

        [HttpGet("GetCryptidSightingByUserId/{id}")]
        public IActionResult GetSightingsByUserId(int id)
        {
            var sightings = _cryptidRepo.GetCryptidSightingByUserId(id);
            return Ok(sightings);
        }

        [HttpGet("GetCryptidByClassification/{id}")]
        public IActionResult GetCryptidByClass(int id)
        {
            var cryptids = _cryptidRepo.GetCryptidByClassification(id);
            return Ok(cryptids);
        }

        [HttpGet("GetAllUserTrackedCryptids/{id}")]
        public IActionResult GetTrackedCryptids(int id)
        {
            var cryptids = _cryptidRepo.GetAllUserTrackedCryptids(id);
            return Ok(cryptids);
        }

        [HttpGet("UserTrackedCryptids")]
        public IActionResult UserTrackedCryptids(int userId, int cryptidId)
        {
            var res = _cryptidRepo.IsCryptidTrackedByUser(userId, cryptidId);
            return Ok(res);
        }
    }
}
