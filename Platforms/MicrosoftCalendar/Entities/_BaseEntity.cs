/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            当前应用域实体基类
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using Ban3.Infrastructures.Common.Contracts.Entities;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Entities
{
    /// <summary>
    /// 当前应用域实体基类
    /// </summary>
    public class _BaseEntity
        :ExplicitStringKeyEntity
    {
        /// ctor
        public _BaseEntity()
        {
        }

    }
}

