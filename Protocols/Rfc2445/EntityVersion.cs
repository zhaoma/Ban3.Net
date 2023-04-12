// This file is Part of CalDavSynchronizer (http://outlookcaldavsynchronizer.sourceforge.net/)
// Copyright (c) 2015 Gerhard Zehetbauer
// Copyright (c) 2015 Alexander Nimmervoll
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using Ban3.Protocols.Rfc2445.Interfaces;

namespace Ban3.Protocols.Rfc2445
{
    /// <summary>
    /// Represents the Id and the Version of an entity
    /// </summary>
    public class EntityVersion<TEntityId, TVersion> : IEntity<TEntityId>
    {
        /// <summary>
        /// 
        /// </summary>
        public TEntityId Id { get; }

        /// <summary>
        /// 
        /// </summary>
        public readonly TVersion Version;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="version"></param>
        public EntityVersion( TEntityId id, TVersion version )
        {
            Id = id;
            Version = version;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class EntityVersion
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntityId"></typeparam>
        /// <typeparam name="TVersion"></typeparam>
        /// <param name="id"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public static EntityVersion<TEntityId, TVersion> Create<TEntityId, TVersion>( TEntityId id, TVersion version )
        {
            return new EntityVersion<TEntityId, TVersion>( id, version );
        }
    }
}