using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Policy;
using System.Text.RegularExpressions;

using Newtonsoft.Json;

using Ban3.Sites.ViaMicrosoft.Enums;
using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Sites.ViaMicrosoft
{
    public static class Helper
    {
        public static string ToAPIVersionString( this APIVersion version )
        {
            switch( (version) )
            {
                case APIVersion.AzureDevOpsServiceRESTAPI50: return "5.0";
                case APIVersion.AzureDevOpsServiceRESTAPI51: return "5.1";
                case APIVersion.AzureDevOpsServiceRESTAPI60: return "6.0";
                case APIVersion.AzureDevOpsServiceRESTAPI61: return "6.1";
                case APIVersion.AzureDevOpsServiceRESTAPI70: return "7.0";
                case APIVersion.AzureDevOpsServiceRESTAPI71: return "7.1";
                case APIVersion.TFS2018U2: return "4.1";
                case APIVersion.AzureDevOpsServer2019: return "5.0";
                case APIVersion.AzureDevOpsServer2020: return "6.0";
                default: return "";
            }
        }

        public static string ToAPIResourceString(
                this APIResource resource,
                object id = null,
                object addition = null )
        {
            switch( resource )
            {
                case APIResource.Projects: return "_apis/projects";
                case APIResource.Teams: return $"_apis/projects/{id}/teams";
                case APIResource.TeamMembers: return $"_apis/projects/{id}/teams/{addition}/members";

                case APIResource.Portrait: return $"_api/_common/identityImage?id={id}";

                //case APIResource.Branch: return "_apis/tfvc/branches";
                //case APIResource.BranchRefs: return "_apis/tfvc/branches";

                //case APIResource.Changeset: return $"_apis/tfvc/changesets/{id}";
                //case APIResource.ChangesetChanges: return $"_apis/tfvc/changesets/{id}/changes";
                case APIResource.ChangesetWorkItems: return $"_apis/tfvc/changesets/{id}/workItems";

                //case APIResource.Item: return "_apis/tfvc/items";

                //case APIResource.Label: return $"_apis/tfvc/labels/{id}";
                //case APIResource.LabelItems: return $"_apis/tfvc/labels/{id}/items";

                //case APIResource.Shelveset: return $"_apis/tfvc/shelvesets";
                //case APIResource.ShelvesetChanges: return "_apis/tfvc/shelvesets/changes";
                case APIResource.ShelvesetWorkItems:
                    return "_apis/tfvc/shelvesets/workitems";
                //case APIResource.Shelvesets

                //case APIResource.WIQL: return "_apis/wit/wiql";

                case APIResource.ChangesetDiscussion:
                    return $"_apis/discussion/threads?artifactUri=vstfs:///VersionControl/Changeset/{id}";

                case APIResource.ShelvesetDiscussion:
                    var queryString = WebUtility.UrlEncode( $"vstfs:///VersionControl/Shelveset/{id}&shelvesetOwner={addition}" );
                    return $"_apis/discussion/threads?artifactUri={queryString}";

                default: return $"_apis/tfvc/{resource.ToString().ToLower()}";
            }
        }

        public static Dictionary<string, object> ToDictionary( this Request.IRequest obj )
        {
            var result = new Dictionary<string, object>();

            obj.Parse( result );

            return result;
        }

        private static void Parse(
                this object obj,
                Dictionary<string, object> keyValuePairs,
                string prefix = "" )
        {
            var properties = obj.GetType()
                                .GetProperties();

            foreach( var prop in properties )
            {
                var attribute = prop.GetCustomAttribute<JsonPropertyAttribute>();
                if( attribute != null )
                {
                    var key = attribute?.PropertyName;
                    var val = prop?.GetValue( obj );
                    var type = prop?.PropertyType;

                    var isPrimitive = type != null && (type.IsPrimitive || type == typeof( string ));

                    if( !isPrimitive )
                    {
                        val?.Parse( keyValuePairs, key + "" );
                    }
                    else
                    {
                        if( key != null && val != null )
                        {
                            var newKey = string.IsNullOrEmpty( prefix )
                                                 ? key
                                                 : $"{prefix}.{key}";
                            keyValuePairs.Add( newKey, val );
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val">注意，区分大小写</param>
        /// <returns></returns>
        public static T GetEnum<T>( this string val ) where T : Enum
        {
            return (T)Enum.Parse( typeof( T ), val );
        }

        public static string ShowName( this string displayName )
        {
            if( string.IsNullOrEmpty( displayName ) ) return "-";

            try
            {
                return displayName.Substring( 0, (displayName + "").IndexOf( "(" ) );
            }
            catch( Exception ) {}

            return displayName;
        }

        public static string ShowTitle( this string displayName )
        {
            if( string.IsNullOrEmpty( displayName ) ) return "-";

            try
            {
                var start = (displayName + "").IndexOf( "(" ) + 1;
                return displayName.Substring( start, (displayName + "").IndexOf( ")" ) - start );
            }
            catch( Exception ) {}

            return displayName;
        }

        public static string ShowDate( this string dateString )
        {
            try
            {
                return dateString.ToDateTime()
                                 .ToLocalTime().ToString( "MM-dd HH:mm" );
            }
            catch( Exception ) {}

            return dateString;
        }

        public static bool IsDateTime( this string dateString )
        {
            try
            {
                DateTime d;
                return DateTime.TryParse( dateString, out d );
            }
            catch( Exception ) {}

            return false;
        }

        public static string FromDateStringInQuery( this string date )
        {
            return date.IsDateTime()
                           ? date.ToDateTime().ToString( "yyyy-MM-dd" )
                           : "";
        }

        public static string ToDateStringInQuery( this string date )
        {
            return date.IsDateTime()
                           ? date.ToDateTime().AddDays( 1 ).ToString( "yyyy-MM-dd" )
                           : "";
        }

        public static IQueryable<Models.ReportChangeset> Apply(
                this IQueryable<Models.ReportChangeset> ori,
                Request.Reports.DataFilter filter,
                bool highLight
        )
        {
            if( filter.LimitIdentityIds != null && filter.LimitIdentityIds.Any() )
                ori = ori.Where( o => filter.LimitIdentityIds.Any( x => x.ToLower() == o.Author.Identity.UniqueName.ToLower() ) );

            if( !string.IsNullOrEmpty( filter.FromDate ) )
                ori = ori.Where( o => o.CreatedDate.ToDateTime() >= filter.FromDate.ToDateTime() );

            if( !string.IsNullOrEmpty( filter.ToDate ) )
                ori = ori.Where( o => o.CreatedDate.ToDateTime() <= filter.ToDate.ToDateTime() );

            if( !string.IsNullOrEmpty( filter.Keyword ) )
                ori = ori.Where( o => o.IsMatch( filter.Keyword, highLight ) );

            if( !string.IsNullOrEmpty( filter.Exclude ) )
                ori = ori.Where( o => !o.IsMatch( filter.Exclude, false ) );

            return ori;
        }

        public static List<Models.ReportShelveset> Apply(
                this List<Models.ReportShelveset> ori,
                Request.Reports.DataFilter filter,
                bool highLight
        )
        {
            if( filter.LimitIdentityIds != null && filter.LimitIdentityIds.Any() )
                ori = ori.FindAll( o => filter.LimitIdentityIds.Any( x => x.ToLower() == o.Owner.Identity.UniqueName.ToLower() ) );

            if( !string.IsNullOrEmpty( filter.FromDate ) )
                ori = ori.FindAll( o => o.CreatedDate.ToDateTime() >= filter.FromDate.ToDateTime() );

            if( !string.IsNullOrEmpty( filter.ToDate ) )
                ori = ori.FindAll( o => o.CreatedDate.ToDateTime() <= filter.ToDate.ToDateTime() );

            if( !string.IsNullOrEmpty( filter.Keyword ) )
                ori = ori.FindAll( o => o.IsMatch( filter.Keyword, highLight ) );

            if( !string.IsNullOrEmpty( filter.Exclude ) )
                ori = ori.FindAll( o => !o.IsMatch( filter.Exclude, false ) );

            return ori;
        }

        public static bool IsMatch( this Models.ReportChangeset changeset, string keyword, bool highLight )
        {
            if( string.IsNullOrEmpty( keyword ) )
                return true;

            if( changeset.ChangesetId == 375409 )
            {
                Console.WriteLine( "Match" );
            }

            var result = changeset.Comment.IsMatch( keyword )
                         || changeset.Discussion.Any(
                                                     x => x.Comments.Any(
                                                                         y => y.Content.IsMatch( keyword ) ) );

            if( result )
            {
                if( changeset.Comment.IsMatch( keyword ) )
                    changeset.Comment = changeset.Comment.HighLight( keyword, highLight );

                foreach( var thread in changeset.Discussion )
                {
                    foreach( var tc in thread.Comments )
                    {
                        if( tc.Content.IsMatch( keyword ) )
                            tc.Content = tc.Content.HighLight( keyword, highLight );
                    }
                }
            }

            return result;
        }

        public static bool IsMatch( this Models.ReportShelveset shelveset, string keyword, bool highLight )
        {
            if( string.IsNullOrEmpty( keyword ) )
                return true;

            var result = shelveset.Name.IsMatch( keyword )
                         || shelveset.Comment.IsMatch( keyword )
                         || shelveset.Discussion.Any(
                                                     x => x.Comments.Any(
                                                                         y => y.Content.IsMatch( keyword ) ) );

            if( result )
            {
                if( shelveset.Name.IsMatch( keyword ) )
                    shelveset.Name = shelveset.Comment.HighLight( keyword, highLight );

                if( shelveset.Comment.IsMatch( keyword ) )
                    shelveset.Comment = shelveset.Comment.HighLight( keyword, highLight );

                foreach( var thread in shelveset.Discussion )
                {
                    foreach( var tc in thread.Comments )
                    {
                        if( tc.Content.IsMatch( keyword ) )
                            tc.Content = tc.Content.HighLight( keyword, highLight );
                    }
                }
            }

            return result;
        }

        public static string HighLight( this string input, string pattern, bool highLight )
        {
            //var s= Regex.Replace(input,pattern, $"<span class='highlightWords'>{pattern}</span>",
            //    RegexOptions.IgnoreCase |
            //    RegexOptions.IgnorePatternWhitespace |
            //    RegexOptions.Multiline
            //    );

            return highLight ? $"<b>{input}</b>" : input;
        }

        public static bool IsIgnored( this string input )
        {
            return Config.IgnoreWords
                         .Any( o => input.IsMatch( o ) );
        }
    }
}