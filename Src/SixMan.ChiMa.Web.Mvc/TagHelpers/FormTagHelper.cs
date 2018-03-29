using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SixMan.ChiMa.Web.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixMan.ChiMa.Web.TagHelpers
{
    [HtmlTargetElement("bg-form")]
    public class FormTagHelper
        : TagHelper
    {
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }

        protected IHtmlGenerator Generator { get; }

        public FormTagHelper(IHtmlGenerator generator)
        {
            Generator = generator;
        }

        [HtmlAttributeName("asp-controller")]
        public string Controller { get; set; }

        [HtmlAttributeName("asp-action")]
        public string Action { get; set; }

        //异步方法
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "form";
            if (!string.IsNullOrWhiteSpace(Controller))
            {
                output.Attributes.Add("action", "/" + Controller + "/" + Action);
            }

            output.Attributes.Add("class", "form-horizontal");

            //获取子属性
            //var props = For.ModelExplorer.EditProperties();
            var props = ((IModelExplorerProvider)For.Model).ModelExplorer.EditProperties();
            var innnerHtml = (await output.GetChildContentAsync()).GetContent();
            Dictionary<string,string> propHtmls = HtmlParser.GetPropHtmls( innnerHtml);
            foreach (var prop in props)
            {
                string propHtml = propHtmls.ContainsKey(prop.Metadata.PropertyName)?
                                        propHtmls[prop.Metadata.PropertyName] : null;
                if( propHtml != null)
                {
                    output.Content.AppendHtml(propHtml);
                }
                else
                {
                    //生成表单
                    var div = new TagBuilder("div");
                    div.AddCssClass("form-group");
                    var label = Generator.GenerateLabel(ViewContext, prop, null, prop.Metadata.DisplayName, null);
                    TagBuilder input = GenerateInput(prop);
                    var span = Generator.GenerateValidationMessage(ViewContext, prop, prop.Metadata.PropertyName, null, ViewContext.ValidationMessageElement
                            , null);
                    div.InnerHtml.AppendHtml(label);
                    div.InnerHtml.AppendHtml("\n");
                    div.InnerHtml.AppendHtml(input);
                    div.InnerHtml.AppendHtml("\n");
                    div.InnerHtml.AppendHtml(span);
                    div.InnerHtml.AppendHtml("\n");
                    output.Content.AppendHtml(div);
                }

                output.Content.AppendHtml("\n");
            }
            ////添加按钮
            //var btn = new TagBuilder("div");
            //btn.AddCssClass("form-group");
            //var submit = new TagBuilder("input");
            //submit.Attributes.Add("type", "submit");
            //submit.Attributes.Add("value", "提交");
            //var reset = new TagBuilder("input");
            //reset.Attributes.Add("type", "reset");
            //reset.Attributes.Add("value", "重置");
            //btn.InnerHtml.AppendHtml(submit);
            //btn.InnerHtml.AppendHtml(reset);
            //output.Content.AppendHtml(btn);

            //将原有的内容添加到标签内部
            //output.Content.AppendHtml(await output.GetChildContentAsync());

        }

        private TagBuilder GenerateInput(ModelExplorer prop)
        {
            return Generator.GenerateTextBox(ViewContext, prop, prop.Metadata.PropertyName, null, null
                    , new { data_bind = $"value:{prop.Metadata.JsonPropertyName()}" });
        }
    }
}
