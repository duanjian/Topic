using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DFHE.Topic.IRepository;
using DFHE.Topic.IService;
using DFHE.Topic.Model;
using DFHE.Topic.Utils;

namespace DFHE.Topic.Service
{
    public class TemplateService : ITemplateService
    {

        private ITemplateRepository _templateRepository;
        private IUnitOfWork _unitOfWork;
        public TemplateService(ITemplateRepository templateRepository, IUnitOfWork unitOfWork)
        {
            _templateRepository = templateRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 添加模版
        /// </summary>
        /// <param name="template">模版对象</param>
        /// <returns>结果视图对象</returns>
        public async Task<Model.ResultVO> Insert(TemplateVO template)
        {
            var result = new ResultVO() { Result = 0 };

            try
            {
                using (TransactionScope trans = new TransactionScope())
                {
                    var imageName = string.Empty;
                    var datetime = DateTime.Now.ToString("yyyyMMddhhmmsss");

                    switch (template.TemplateType)
                    {
                        case TemplateType.Tab:
                            imageName = string.Format("tab{0}.png", datetime);
                            break;
                        case TemplateType.Swiper:
                            imageName = string.Format("swiper{0}.png", datetime);
                            break;
                        default:
                            imageName = string.Format("other{0}.png", datetime);
                            break;
                    }

                    var tmpl = new Template()
                    {
                        TemplateTitle = template.TemplateTitle,
                        Type = template.TemplateType.GetHashCode(),
                        TemplateContent = template.TemplateContent,
                        ImageURI = string.Format("\\{0}\\{1}", "Statics\\Templates\\TemplateImages", imageName),
                        CreateTime = DateTime.Now,
                        CreateID = 0,
                        Deleted = false,
                        UpdateTime = DateTime.Now,
                        URI = string.Empty,
                        Remark = string.Empty
                    };

                    var insertedTemplate = _templateRepository.Insert(tmpl);
                    _unitOfWork.Commit();

                    #region 截图部分
                    var args = new List<string>(){
                        "http://localhost:2381/Statics/Samples/Tab/TabTemplatePreview.html",
                        string.Format("{0}{1}\\{2}", System.Web.HttpRuntime.AppDomainAppPath, "Statics\\Templates\\TemplateImages",imageName)
                        };
                    PhantomJSHelper.Rasterize(args);
                    #endregion

                    result.Data = insertedTemplate;

                    trans.Complete();
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
        /// <param name="template">模版对象</param>
        /// <returns>结果视图对象</returns>
        public async Task<ResultVO> GenerateSample(TemplateVO template)
        {
            var result = new ResultVO() { Result = 0 };
            try
            {
                Object SampleObject = new object();
                string targetPath;

                switch (template.TemplateType)
                {
                    case TemplateType.Tab:
                        #region 标签页mock
                        SampleObject = new
                        {
                            Topic = new Topic.Model.Topic()
                            {
                                TopicTitle = "预览样式",
                                PageCount = 3
                            },
                            Pages = new List<Page>(){
                                new Page(){
                                    PageTitle = "标签一",
                                    PageContent = "当你看到这里的时候有没有觉得这个页面很牛X..."
                                },
                                new Page(){
                                    PageTitle = "标签二",
                                    PageContent = "切换过来你也会觉得牛X的..."
                                },
                                new Page(){
                                    PageTitle = "标签三",
                                    PageContent = "总之就是很牛X对吧..."
                                }
                            },
                            Template = new
                            {
                                TemplateContent = JsonHelper.Deserialize<TabStyle>(template.TemplateContent)
                            }
                        };
                        if (GenerateSample(SampleObject, TemplateType.Tab, out targetPath))
                        {
                            result.Data = targetPath;
                            result.Result = 1;
                        }
                        #endregion                       
                        break;
                    case TemplateType.Swiper:
                        #region 滑动页mock
                        SampleObject = new
                        {
                            Topic = new Topic.Model.Topic()
                            {
                                TopicTitle = "预览样式",
                                PageCount = 3
                            },
                            Pages = new List<Page>(){
                                new Page(){
                                    PageTitle = "页面一",
                                    PageContent = "当你看到这里的时候有没有觉得这个页面很牛X..."
                                },
                                new Page(){
                                    PageTitle = "页面二",
                                    PageContent = "切换过来你也会觉得牛X的..."
                                },
                                new Page(){
                                    PageTitle = "页面三",
                                    PageContent = "总之就是很牛X对吧..."
                                }
                            },
                            Template = new
                            {
                                TemplateContent = JsonHelper.Deserialize<SwiperStyle>(template.TemplateContent)
                            }
                        };
                        if (GenerateSample(SampleObject, TemplateType.Swiper, out targetPath))
                        {
                            result.Data = targetPath;
                            result.Result = 1;
                        }
                        #endregion
                        break;                   
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
        private bool GenerateSample(object template, TemplateType templateType, out string targetPath)
        {

            var outputPath = string.Empty;
            var previewPageName = string.Empty;
            var templateName = string.Empty;
            var templateKey = string.Empty;

            switch (templateType)
            {
                case TemplateType.Tab:
                    outputPath = "Statics\\Samples\\Tab";
                    previewPageName = "TabTemplatePreview.html";
                    templateName = "Statics\\Templates\\TabTemplate.html";
                    templateKey = "tabTemplate";
                    break;
                case TemplateType.Swiper:
                    outputPath = "Statics\\Samples\\Swiper";
                    previewPageName = "SwiperTemplatePreview.html";
                    templateName = "Statics\\Templates\\SwiperTemplate.html";
                    templateKey = "swiperTemplate";
                    break;
                default:
                    outputPath = "Statics\\Samples\\Tab";
                    previewPageName = "TabTemplatePreview.html";
                    templateName = "Statics\\Templates\\TabTemplate.html";
                    templateKey = "tabTemplate";
                    break;
            }

            RazorHelper razor = new RazorHelper();
            razor.TemplateName = templateName;
            razor.OutputFolderPath = outputPath;
            razor.StaticPageName = previewPageName;
            razor.ParseObject = template;
            razor.TemplateKey = templateKey;

            razor.GenerateHtml();
            targetPath = string.Format("{0}\\{1}", razor.OutputFolderPath, razor.StaticPageName);

            return true;
        }
    }
}
