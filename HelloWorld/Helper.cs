// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Helper.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace HelloWorld
{
    using System;

    /// <summary>
    /// </summary>
    public enum ExceptionArgument
    {
        /// <summary>
        /// </summary>
        capacity, 

        /// <summary>
        /// </summary>
        CollectionCurrentSize, 
    }

    /// <summary>
    /// </summary>
    public enum ExceptionResource
    {
        /// <summary>
        /// </summary>
        ArgumentOutOfRange_NeedNonNegNum, 

        /// <summary>
        /// </summary>
        ArgumentOutOfRange_NeedNonNegNumRequired, 

        /// <summary>
        /// </summary>
        Capacity_CapacityIsFull, 

        /// <summary>
        /// </summary>
        CurrentSizeIsZero, 
    }

    /// <summary>
    /// </summary>
    public static class Helper
    {
        #region Public Methods and Operators

        /// <summary>
        /// </summary>
        /// <param name="argument">
        /// The argument.
        /// </param>
        /// <param name="resource">
        /// The resource.
        /// </param>
        /// <exception cref="Exception">
        /// </exception>
        public static void ThorwArgumentCurrentSize(ExceptionArgument argument, ExceptionResource resource)
        {
            throw new Exception(argument + " : " + resource);
        }

        /// <summary>
        /// </summary>
        /// <param name="argument">
        /// The argument.
        /// </param>
        /// <param name="resource">
        /// The resource.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// </exception>
        public static void ThrowArgumentCapacityIsFull(ExceptionArgument argument, ExceptionResource resource)
        {
            throw new ArgumentOutOfRangeException(argument.ToString(), resource.ToString());
        }

        /// <summary>
        /// </summary>
        /// <param name="argument">
        /// The argument.
        /// </param>
        /// <param name="resource">
        /// The resource.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// </exception>
        public static void ThrowArgumentOutOfRangeException(ExceptionArgument argument, ExceptionResource resource)
        {
            throw new ArgumentOutOfRangeException(argument.ToString(), resource.ToString());
        }

        #endregion
    }
}