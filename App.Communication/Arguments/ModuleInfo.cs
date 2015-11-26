using System;

namespace App.Communication.Arguments
{
    /// <summary>
    /// Represents a chat user.
    /// This object particularly used in Login of a user.
    /// </summary>
    [Serializable]
    public class ModuleInfo
    {
        /// <summary>
        /// Name of user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Bytes of avatar of user.
        /// </summary>
        public byte[] AvatarBytes { get; set; }

        /// <summary>
        /// Status of user.
        /// </summary>
        public UserStatus Status { get; set; }
    }
}
