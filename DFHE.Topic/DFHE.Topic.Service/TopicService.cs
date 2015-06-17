using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFHE.Survey.Utility;
using DFHE.Topic.IRepository;
using DFHE.Topic.IService;
using DFHE.Topic.Model;
using DFHE.Topic.Utils;

namespace DFHE.Topic.Service
{
    public class TopicService : ITopicService
    {
        ITopicRepository _topicRepositpry;
        ITemplateRepository _templateRepository;
        IUnitOfWork _unitOfWork;

        public TopicService(ITopicRepository topicRepository, ITemplateRepository templateRepository, IUnitOfWork unitOfWork)
        {
            _topicRepositpry = topicRepository;
            _templateRepository = templateRepository;
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// 插入新专题
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        public async Task<ResultVO> Insert(Model.Topic topic)
        {
            ResultVO result = new ResultVO { Result = 0 };

            try
            {
                //var insertedTopic = _topicRepositpry.Insert(topic);

                //await GenerateStaticPage(insertedTopic, insertedTopic.StaticURI.Split("/".ToCharArray())[1].Split('.')[0]);

                //result.Data = insertedTopic;
                //_unitOfWork.Commit();

                //result.Result = 1;
            }
            catch (Exception ex)
            {
                result.ErrorMsg = ex.Message;
                throw ex;
            }

            return result;
        }

        //public async Task<ResultVO> Update(Model.Topic topic)
        //{
        //    ResultVO result = new ResultVO() { Result = 0 };

        //    try
        //    {
        //        _topicRepositpry.Update(topic);

        //        await GenerateStaticPage(topic, topic.StaticURI.Split("/".ToCharArray())[1].Split('.')[0]);

        //        _unitOfWork.Commit();

        //    }
        //    catch (Exception ex)
        //    {
        //        result.ErrorMsg = ex.Message;
        //        throw ex;
        //    }

        //    return result;
        //}

        /// <summary>
        /// 生成静态页面
        /// </summary>
        /// <param name="survey"></param>
        /// <param name="tmplName"></param>
        /// <param name="staticPageName"></param>
        /// <returns></returns>
        //public async Task GenerateStaticPage(Object topic, string staticPageName, string tmplName = "wapTmpl.html")
        //{
        //    try
        //    {
        //        VelocityHelper helper = new VelocityHelper("/statics/tmpl/");
        //        //NVTools tools = new NVTools();
        //        //helper.Put("tools", tools);
        //        helper.Put("Topic", topic);
        //        await Task.Run(() => helper.GenerateHtml(tmplName, string.Format("/statics/{0}.html", staticPageName)));// ;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    //return result;
        //}

        /// <summary>
        /// 生成示例
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public async Task<ResultVO> GenerateSample(TopicVO topic)
        {
            var result = new ResultVO() { Result = 0 };

            try
            {

                var template = _templateRepository.LoadEntities(t => t.ID.Equals(topic.TemplateId)).FirstOrDefault();

                object templateContent;

                if (topic.Type == 1)
                {
                    templateContent = JsonHelper.Deserialize<TabStyle>(template.TemplateContent);
                }
                else
                {
                    templateContent = string.Empty;
                }

                var tmpPages = new List<Page>();

                topic.Pages.ToList().ForEach(t =>
                {
                    tmpPages.Add(new Page()
                    {
                        PageTitle = t.PageTitle,
                        PageContent = t.PageContent
                    });
                });

                object SampleObject = new
                {
                    Topic = new Topic.Model.Topic()
                    {
                        TopicTitle = topic.Title,
                        PageCount = topic.PageCount
                    },
                    Pages = tmpPages,                  
                    Template = new
                    {
                        TemplateContent = templateContent
                    }
                };

                string targetPath;

                if (GenerateSample(SampleObject,TemplateType.Tab, out targetPath))
                {
                    result.Data = targetPath;
                    result.Result = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// 生成示例
        /// </summary>
        /// <param name="template"></param>
        /// <param name="targetPath"></param>
        /// <returns></returns>
        private bool GenerateSample(object template,TemplateType templateType, out string targetPath)
        {
            string outputPath = string.Empty;
            string previewPageName = string.Empty;

            switch (templateType)
            {
                case TemplateType.Tab:
                    outputPath = "Statics\\Samples\\Tab";
                    previewPageName = "TabPreview.html";
                    break;
                case TemplateType.Swiper:
                    outputPath = "Statics\\Samples\\Swiper";
                    previewPageName = "SwiperPreview.html";
                    break;               
                default:
                    outputPath = "Statics\\Samples\\Tab";
                    previewPageName = "TabPreview.html";
                    break;
            }

            RazorHelper razor = new RazorHelper();
            razor.TemplateName = "Statics\\Templates\\TabTemplate.html";
            razor.OutputFolderPath = outputPath;
            razor.StaticPageName = previewPageName;
            razor.ParseObject = template;

            razor.GenerateHtml();
            targetPath = string.Format("{0}\\{1}", razor.OutputFolderPath, razor.StaticPageName);

            return true;
        }


        public Task<ResultVO> Update(Model.Topic topic)
        {
            throw new NotImplementedException();
        }
    }
}
