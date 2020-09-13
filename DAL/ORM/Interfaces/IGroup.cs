﻿namespace ResultsOfTheSession.DAL.ORM.Interfaces
{
    /// <summary>Interface describes group model</summary>
    public interface IGroup
    {
        /// <summary>Id</summary>
        int Id { get; set; }

        /// <summary>Name</summary>
        string Name { get; set; }

        /// <summary>Group specialty id</summary>
        int GroupSpecialtyId { get; set; }
    }
}