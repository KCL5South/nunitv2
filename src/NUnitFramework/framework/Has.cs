// ****************************************************************
// Copyright 2007, Charlie Poole
// This is free software licensed under the NUnit license. You may
// obtain a copy of the license at http://nunit.org/?p=license&r=2.4
// ****************************************************************

using System;
using NUnit.Framework.Constraints;

namespace NUnit.Framework
{
    /// <summary>
    /// With is essentially a synonym for has
    /// </summary>
    public class With : Has { }

	/// <summary>
	/// Summary description for Has.
	/// </summary>
	public class Has
	{
        /// <summary>
        /// Nested class that allows us to restrict the number
        /// of key words that may appear after Has.No.
        /// </summary>
		public class HasNoPrefixBuilder
		{
            /// <summary>
            /// Return a ConstraintBuilder conditioned to apply
            /// the following constraint to a property.
            /// </summary>
            /// <param name="name">The property name</param>
            /// <returns>A ConstraintBuilder</returns>
			public ConstraintExpression Property(string name)
			{
				return new PartialConstraintExpression().Not.Append( new PropertyExistsConstraint (name) );
			}

            /// <summary>
            /// Return a Constraint that succeeds if the expected object is
            /// not contained in a collection.
            /// </summary>
            /// <param name="expected">The expected object</param>
            /// <returns>A Constraint</returns>
            public Constraint Member(object expected)
			{
				return new NotConstraint( new CollectionContainsConstraint(expected) ) ;
			}
		}

		#region Prefix Operators
		/// <summary>
		/// Has.No returns a ConstraintBuilder that negates
		/// the constraint that follows it.
		/// </summary>
		public static HasNoPrefixBuilder No
		{
			get { return new HasNoPrefixBuilder(); }
		}

		/// <summary>
		/// Has.AllItems returns a ConstraintBuilder, which will apply
		/// the following constraint to all members of a collection,
		/// succeeding if all of them succeed.
		/// </summary>
		public static PartialConstraintExpression All
		{
			get { return new PartialConstraintExpression().All; }
		}

		/// <summary>
		/// Has.Some returns a ConstraintBuilder, which will apply
		/// the following constraint to all members of a collection,
		/// succeeding if any of them succeed. It is a synonym
		/// for Has.Item.
		/// </summary>
		public static PartialConstraintExpression Some
		{
			get { return new PartialConstraintExpression().Some; }
		}

		/// <summary>
		/// Has.None returns a ConstraintBuilder, which will apply
		/// the following constraint to all members of a collection,
		/// succeeding only if none of them succeed.
		/// </summary>
		public static PartialConstraintExpression None
		{
			get { return new PartialConstraintExpression().None; }
		}

        /// <summary>
        /// Returns a new ConstraintBuilder, which will apply the
        /// following constraint to a named property of the object
        /// being tested.
        /// </summary>
        /// <param name="name">The name of the property</param>
		public static PendingConstraintExpression Property( string name )
		{
            //return new ResolvableConstraintExpression( new PropOperator() );
            return new PartialConstraintExpression().Property(name);
		}

        /// <summary>
        /// Returns a new ConstraintBuilder, which will apply the
        /// following constraint to the Length property of the object
        /// being tested.
        /// </summary>
        public static PendingConstraintExpression Length
        {
            get { return new PartialConstraintExpression().Length; }
        }

        /// <summary>
        /// Returns a new ConstraintBuilder, which will apply the
        /// following constraint to the Count property of the object
        /// being tested.
        /// </summary>
        public static PendingConstraintExpression Count
        {
            get { return new PartialConstraintExpression().Count; }
        }

        /// <summary>
        /// Returns a new ConstraintBuilder, which will apply the
        /// following constraint to the Message property of the object
        /// being tested.
        /// </summary>
        public static PendingConstraintExpression Message
        {
            get { return new PartialConstraintExpression().Message; }
        }
        #endregion

		#region Member Constraint
		/// <summary>
		/// Returns a new CollectionContainsConstraint checking for the
		/// presence of a particular object in the collection.
		/// </summary>
		/// <param name="expected">The expected object</param>
		public static ConstraintExpression Member( object expected )
		{
			return new PartialConstraintExpression().Member( expected );
		}
		#endregion

        #region Attribute Constraint
        /// <summary>
        /// Returns a new ConstraintExpression checking for the
        /// presence of a particular attribute on an object.
        /// </summary>
        /// <param name="expected">The expected object</param>
        public static ConstraintExpression Attribute(Type type)
        {
            return new PartialConstraintExpression().Attribute(type);
        }

#if NET_2_0
        /// <summary>
        /// Returns a new ConstraintExpression checking for the
        /// presence of a particular attribute on an object.
        /// </summary>
        /// <param name="expected">The expected object</param>
        public static ConstraintExpression Attribute<T>()
        {
            return Attribute( typeof(T) );
        }
#endif
        #endregion
    }
}
