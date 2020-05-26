using CarRentalCo.Common.Domain;
using CarRentalCo.Users.Domain.Users.Events;
using CarRentalCo.Users.Domain.Users.Exceptions;
using System;
using System.Collections.Generic;

namespace CarRentalCo.Users.Domain.Users
{
    public class User : AggregateRoot, IEntity<UserId>
    {
        public UserId Id { get; set; }

        private string fullName;
        private string password;
        private string email;
        private DateTime dateOfBirth;
        private DateTime creationDate;
        private DateTime modificationDate;

        private IList<UserRole> roles;
        private readonly IUsersUniqueChecker usersUniqueChecker;

        private User()
        {
        }

        private User( string fullName, string password, string email, DateTime dateOfBirth,
            DateTime creationDate, DateTime modificationDate, IList<UserRole> roles, IUsersUniqueChecker usersUniqueChecker)
        {
            this.Id = new UserId(Guid.NewGuid());
            this.fullName = fullName;
            this.password = password;
            this.email = email;
            this.dateOfBirth = dateOfBirth;
            this.creationDate = creationDate;
            this.modificationDate = modificationDate;
            this.roles = roles;
            this.usersUniqueChecker = usersUniqueChecker;

            AddDomainEvent(new UserCreatedDomainEvent(Id, roles));
        }

        public static User Create(string fullName, string password, string email, DateTime dateOfBirth,
            DateTime creationDate, DateTime modificationDate, IList<UserRole> roles, IUsersUniqueChecker usersUniqueChecker)
        {
            if(!usersUniqueChecker.IsUnique())
            {
                throw new UserEmailAlreadyExistsException($"Cannot create user. Email '{email}' already exists");
            }

            return new User(fullName, password, email, dateOfBirth, creationDate, modificationDate, roles,usersUniqueChecker);
        }

    }
}
