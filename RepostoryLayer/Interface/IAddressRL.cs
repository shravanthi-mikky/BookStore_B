using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepostoryLayer.Interface
{
    public interface IAddressRL
    {
        public AddressModel AddAddress(AddressModel addAddress);
        public Address_Model UpdateAddress(Address_Model addAddress);
        public List<AddressModel> GetUserAddress();
        public List<AddressModel> GetUserAddressById(long userid);

        public List<Address_Model1> GetUserAddressAndUserDetails();
    }
}
