using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFHE.Topic.Model
{
    public class TabStyle
    {
        /// <summary>
        /// 是否显示顶部标题
        /// </summary>
        public bool ShowHeader { get; set; }

        /// <summary>
        /// 头部导航背景色
        /// </summary>
        public string HeaderBackgroundColor { get; set; }

        /// <summary>
        /// 头部导航前景色
        /// </summary>
        public string HeaderForegroundColor { get; set; }

        /// <summary>
        /// 标签位置
        /// </summary>
        public string TabPosition { get; set; }

        /// <summary>
        /// 标签背景色
        /// </summary>
        public string TabBackgroundColor { get; set; }

        /// <summary>
        /// 标签前景色
        /// </summary>
        public string TabForegroundColor { get; set; }

        /// <summary>
        /// 标签前景色RGB值
        /// </summary>
        public string TabForegroundColorRGB { get; set; }


        /// <summary>
        /// 内容背景色
        /// </summary>
        public string ContentBackgroundColor { get; set; }

        /// <summary>
        /// 内容前景色
        /// </summary>
        public string ContentForegroundColor { get; set; }

        /// <summary>
        /// 是否显示底部提交按钮
        /// </summary>
        public bool ShowBottomSubmitButton { get; set; }

        /// <summary>
        /// 提交按钮背景色
        /// </summary>
        public string SubmitButtonBackgroundColor { get; set; }

        /// <summary>
        /// 提交按钮前景色
        /// </summary>
        public string SubmitButtonForegroundColor { get; set; }

    }
}
