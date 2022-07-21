using EVE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVE.Data.Services;
using EVE.Data.Base;

namespace EVE.Data.Services
{
    public class DriversService :EntityBaseRepository<BusDriver>, IBusDriversService
    {

        private readonly AppDbContext _context;
        public DriversService(AppDbContext context): base(context) { }
    }
}
