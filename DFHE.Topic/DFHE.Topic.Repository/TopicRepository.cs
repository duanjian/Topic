using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFHE.Topic.IRepository;

namespace DFHE.Topic.Repository
{
    public class TopicRepository : BaseRepository<Topic.Model.Topic>, ITopicRepository
    {
        public TopicRepository(DbContext dbContext)
            : base(dbContext)
        {

        }

    }
}
