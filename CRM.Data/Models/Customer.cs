using System;
using GalaSoft.MvvmLight;

namespace CRM.Data.Models
{
    public class Customer : ObservableObject
    {
        private string _address;
        private Guid _customerId;
        private string _firstName;
        private string _lastName;
        private string _mail;
        private string _phoneNumber;

        public Guid CustomerId
        {
            get => _customerId;
            set { Set(() => CustomerId, ref _customerId, value); }
        }

        public string FirstName
        {
            get => _firstName;
            set { Set(() => FirstName, ref _firstName, value); }
        }

        public string LastName
        {
            get => _lastName;
            set { Set(() => LastName, ref _lastName, value); }
        }

        public string Mail
        {
            get => _mail;
            set { Set(() => Mail, ref _mail, value); }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set { Set(() => PhoneNumber, ref _phoneNumber, value); }
        }


        public string Address
        {
            get => _address;
            set { Set(() => Address, ref _address, value); }
        }
    }
}