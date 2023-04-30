using System;
using System.ComponentModel;

namespace nanoFramework.IO
{

    /////////////////
    ///
    // Microsoft code

    ////////////////

    //------------------------------------------------------------------------------
    // <copyright file="DescriptionAttribute.cs" company="Microsoft">
    //     Copyright (c) Microsoft Corporation.  All rights reserved.
    // </copyright>                                                                
    //------------------------------------------------------------------------------

    /*
     */
    /// <devdoc>
    ///    <para>Specifies a description for a property
    ///       or event.</para>
    /// </devdoc>
    [AttributeUsage(AttributeTargets.All)]
    public class DescriptionAttribute : Attribute
    {
        /// <devdoc>
        /// <para>Specifies the default value for the <see cref='System.ComponentModel.DescriptionAttribute'/> , which is an
        ///    empty string (""). This <see langword='static'/> field is read-only.</para>
        /// </devdoc>
        public static readonly DescriptionAttribute Default = new DescriptionAttribute();
        private string description;

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public DescriptionAttribute() : this(string.Empty)
        {
        }

        /// <devdoc>
        ///    <para>Initializes a new instance of the <see cref='System.ComponentModel.DescriptionAttribute'/> class.</para>
        /// </devdoc>
        public DescriptionAttribute(string description)
        {
            this.description = description;
        }

        /// <devdoc>
        ///    <para>Gets the description stored in this attribute.</para>
        /// </devdoc>
        public virtual string Description
        {
            get
            {
                return DescriptionValue;
            }
        }

        /// <devdoc>
        ///     Read/Write property that directly modifies the string stored
        ///     in the description attribute. The default implementation
        ///     of the Description property simply returns this value.
        /// </devdoc>
        protected string DescriptionValue
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }

            DescriptionAttribute other = obj as DescriptionAttribute;

            return (other != null) && other.Description == Description;
        }

        public override int GetHashCode()
        {
            return Description.GetHashCode();
        }
    }







    /// <devdoc>
    ///    <para>Specifies whether a property can only be set at
    ///       design time.</para>
    /// </devdoc>
    [AttributeUsage(AttributeTargets.All)]
    public sealed class DesignOnlyAttribute : Attribute
    {
        private bool isDesignOnly = false;

        /// <devdoc>
        ///    <para>
        ///       Initializes a new instance of the <see cref='System.ComponentModel.DesignOnlyAttribute'/> class.
        ///    </para>
        /// </devdoc>
        public DesignOnlyAttribute(bool isDesignOnly)
        {
            this.isDesignOnly = isDesignOnly;
        }

        /// <devdoc>
        ///    <para>
        ///       Gets a value indicating whether a property
        ///       can be set only at design time.
        ///    </para>
        /// </devdoc>
        public bool IsDesignOnly
        {
            get
            {
                return isDesignOnly;
            }
        }

        /// <devdoc>
        ///    <para>
        ///       Specifies that a property can be set only at design time. This
        ///    <see langword='static '/>field is read-only. 
        ///    </para>
        /// </devdoc>
        public static readonly DesignOnlyAttribute Yes = new DesignOnlyAttribute(true);

        /// <devdoc>
        ///    <para>
        ///       Specifies
        ///       that a
        ///       property can be set at design time or at run
        ///       time. This <see langword='static '/>field is read-only.
        ///    </para>
        /// </devdoc>
        public static readonly DesignOnlyAttribute No = new DesignOnlyAttribute(false);

        /// <devdoc>
        ///    <para>
        ///       Specifies the default value for the <see cref='System.ComponentModel.DesignOnlyAttribute'/>, which is <see cref='System.ComponentModel.DesignOnlyAttribute.No'/>. This <see langword='static'/> field is
        ///       read-only.
        ///    </para>
        /// </devdoc>
        public static readonly DesignOnlyAttribute Default = No;

        /// <devdoc>
        /// </devdoc>
        /// <internalonly/>
        public bool IsDefaultAttribute()
        {
            return IsDesignOnly == Default.IsDesignOnly;
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }

            DesignOnlyAttribute other = obj as DesignOnlyAttribute;

            return (other != null) && other.isDesignOnly == isDesignOnly;
        }

        public override int GetHashCode()
        {
            return isDesignOnly.GetHashCode();
        }
    }
}
