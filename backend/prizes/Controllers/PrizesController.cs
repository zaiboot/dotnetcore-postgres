﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Prizes.Models;

namespace prizes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrizesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Prize>> Get()
        {
            return new[] {
                    new Prize(){ Id= 1,Description ="Test01", Amount = 120 },
                    new Prize(){ Id= 2,Description ="Test01", Amount = 120 },
                    new Prize(){ Id= 3,Description ="Test01", Amount = 120 },
                    new Prize(){ Id= 4,Description ="Test01", Amount = 120 }
             };
        }

        // POST api/values
        [HttpPost("{id}/Claim")]
        public void Claim(int id)
        {
            //TODO: Validate prize is still available
            //then mark it as claimed

        }        

    }
}
