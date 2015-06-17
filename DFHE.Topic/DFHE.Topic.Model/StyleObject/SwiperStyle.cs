using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFHE.Topic.Model
{
    /// <summary>
    /// 滑动样式
    /// </summary>
    public class SwiperStyle
    {
        /// <summary>
        /// 背景色
        /// </summary>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// 前景色
        /// </summary>
        public string ForegroundColor { get; set; }
        /// <summary>
        /// 显示分页
        /// </summary>
        public bool ShowPagination { get; set; }

        /// <summary>
        /// 滑动方向
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        /// 是否自动播放
        /// </summary>
        public bool Autoplay { get; set; }

        /// <summary>
        /// 自动播放间隔时间
        /// </summary>
        public int AutoplayTimeInterval { get; set; }

        /// <summary>
        /// 自动播放是否可打断
        /// </summary>
        public bool AutoplayDisableOnInteraction { get; set; }

        /// <summary>
        /// 循环
        /// </summary>
        public bool Loop { get; set; }
    }
}
