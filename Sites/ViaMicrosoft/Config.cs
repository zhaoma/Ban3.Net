/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            ViaMicrosoft设置项定义
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Sites.ViaMicrosoft
{
    public class Config
    {
        public Config()
        {
        }

        public static string[] IgnoreWords => new[]
        {
            "Forward Integration",
            "Reverse Integration"
        };

        public static Models.AppEnvironment CurrrentEnvironment
        {
            get
            {
                return $"{DomainIdentity}.Config"
                    .LoadOrSetDefault<Models.AppEnvironment>
                    (
                        new Models.AppEnvironment(),
                        DomainConfig
                    );
            }
        }

        const string DomainIdentity = "ban3.viaMicrosoft";
        static string DomainConfig = $"{DomainIdentity}.json".WorkPath();
    }
}