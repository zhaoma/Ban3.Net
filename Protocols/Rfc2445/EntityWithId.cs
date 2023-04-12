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

namespace Ban3.Protocols.Rfc2445
{
    /// <summary>
    /// Represents the Id and the Version of an entity
    /// </summary>
    public class EntityWithId<TEntityId, TEntity>
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly TEntityId Id;

        /// <summary>
        /// 
        /// </summary>
        public readonly TEntity Entity;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        public EntityWithId( TEntityId id, TEntity entity )
        {
            Id = id;
            Entity = entity;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class EntityWithId
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntityId"></typeparam>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static EntityWithId<TEntityId, TEntity> Create<TEntityId, TEntity>( TEntityId id, TEntity entity )
        {
            return new EntityWithId<TEntityId, TEntity>( id, entity );
        }
    }
}