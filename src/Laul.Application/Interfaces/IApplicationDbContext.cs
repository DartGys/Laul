using Laul.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laul.Application.Interfaces
{
    internal interface IApplicationDbContext
    {
        DbSet<Album>
    }
}
