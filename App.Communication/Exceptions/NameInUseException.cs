using System;
using System.Runtime.Serialization;

namespace App.Communication.Exceptions
{
    /// <summary>
    /// This exception is thrown by Chat server if a user wants to login
    /// with a nick that is being used by another user.
    /// </summary>
    [Serializable]
    public class NameInUseException : ApplicationException
    {
        /// <summary>
        /// Contstructor.
        /// </summary>
        public NameInUseException()
        {

        }

        /// <summary>
        /// Contstructor.
        /// </summary>
        public NameInUseException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }

        /// <summary>
        /// Contstructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        public NameInUseException(string message)
            : base(message)
        {

        }
    }
}
