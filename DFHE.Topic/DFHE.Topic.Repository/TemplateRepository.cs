using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFHE.Topic.IRepository;
using DFHE.Topic.Model;

namespace DFHE.Topic.Repository
{
    public class TemplateRepository : BaseRepository<Template>, ITemplateRepository
    {
        public TemplateRepository(DbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
