using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFHE.Topic.Model;

namespace DFHE.Topic.IService
{
    public interface ITopicService
    {
        ResultVO Insert(Topic.Model.Topic topic);
    }
}
