using System;
using System.Collections.Generic;

namespace Ban3.Sites.ViaMicrosoft.Models
{
	public class AppEnvironment
	{
		public AppEnvironment()
        {
            Target = new Target();
        }

        public Target Target { get; set; }

        public string ReportsDataPath { get; set; }

        public List<string> LimitUniqueNames { get; set; }

        /*
        * "id":"da88a9e7-aba6-4ced-82c0-c9b905efedcb","displayName":"Fan, Liang Yan (SHS DI CT R&D MEQ ISA SOM10 SMS)","uniqueName":"AD005\\z003591w"
         *"id":"d032d80c-70e3-41c3-a21e-1e62c57ea007","displayName":"Mao, Guo Chen (SHS DI CT R&D MEQ ISA SOM10 SMS)","uniqueName":"AD005\\z0038p9x"
         *"id":"b230c551-38e0-48b5-b04f-444a45e1f289","displayName":"Wang, Zhao Jun (SHS DI CT R&D MEQ ISA SOM10 SMS)","uniqueName":"AD005\\z00494jm"
         *"id":"d94a90bf-ffd8-448a-a39a-3260a5fc58c6","displayName":"Su, Li Gang (SHS DI CT R&D MEQ ISA SOM10 SMS)","uniqueName":"AD005\\z003csxj"
         *"id":"c65b4592-426c-49b8-a40d-5efffcf09444","displayName":"Zhou, Wei Sheng (EXT) (SHS DI CT R&D MEQ ISA SOM10 SMS)","uniqueName":"AD005\\z004d5sh"
         *"id":"fa607751-5f43-4967-8f07-9e5b7eb4d87d","displayName":"Feng, Yong Feng (SHS DI CT R&D MEQ ISA SOM10 SMS)","uniqueName":"AD005\\z004hk0j"
         *"id":"f08968c7-73f4-471e-973a-c361ed5cc97e","displayName":"Guo, Yao Yao (SHS DI CT R&D MEQ ISA SOM10 SMS)","uniqueName":"AD005\\z003n4hr"
         *"id":"decd968a-6b47-4742-a5d6-49c8c9765665","displayName":"Liu, Xing Chao (SHS DI CT R&D MEQ ISA SOM10 SMS)","uniqueName":"AD005\\z004en4e"
         *"id":"d55314e1-47e3-48fb-9b67-c6290b3c71dc","displayName":"Zeng, Yun Jie (SHS DI CT R&D MEQ ISA SOM10 SMS)","uniqueName":"AD005\\z003wb7p"
         *"id":"16ac8314-4a1b-407a-9170-62d46e167827","displayName":"Zheng, Si Long (SHS DI CT R&D MEQ ISA SOM10 SMS)","uniqueName":"AD005\\z004b0jf"
         *
         */

        public List<string> LimitTeams { get; set; }

        public string DefaultTeamName { get; set; } = "SERVICE-SMS_SSME";
    }
}

