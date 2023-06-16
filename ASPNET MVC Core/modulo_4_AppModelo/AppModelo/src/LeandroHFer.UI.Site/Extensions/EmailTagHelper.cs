using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace LeandroHFer.UI.Site.Extensions
{
    public class EmailTagHelper : TagHelper
    {
        public string EmailDomain { get; set; } = "leandrohenrique.com";
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // Seta a saída como a tag <a> do html (link)
            output.TagName = "a";

            // Retorna o conteúdo dentro da tag helper
            var content = await output.GetChildContentAsync();

            // Basicamente é a frase que será utilizada como retorno do conteúdo
            var target = content.GetContent() + "@" + EmailDomain;

            // Seta no atributo href da saída (tag <a>) o link para o e-mail definido em target
            output.Attributes.SetAttribute("href", "mailto:" + target);

            // Substitui o conteúdo do tag helper pela frase em target com o SetContent()
            output.Content.SetContent(target);
        }
    }
}
